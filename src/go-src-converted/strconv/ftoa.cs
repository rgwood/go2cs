// Copyright 2009 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// Binary to decimal floating point conversion.
// Algorithm:
//   1) store mantissa in multiprecision decimal
//   2) shift decimal by exponent
//   3) read digits out & format

// package strconv -- go2cs converted at 2020 October 09 05:06:33 UTC
// import "strconv" ==> using strconv = go.strconv_package
// Original source: C:\Go\src\strconv\ftoa.go
using math = go.math_package;
using static go.builtin;

namespace go
{
    public static partial class strconv_package
    {
        // TODO: move elsewhere?
        private partial struct floatInfo
        {
            public ulong mantbits;
            public ulong expbits;
            public long bias;
        }

        private static floatInfo float32info = new floatInfo(23,8,-127);
        private static floatInfo float64info = new floatInfo(52,11,-1023);

        // FormatFloat converts the floating-point number f to a string,
        // according to the format fmt and precision prec. It rounds the
        // result assuming that the original was obtained from a floating-point
        // value of bitSize bits (32 for float32, 64 for float64).
        //
        // The format fmt is one of
        // 'b' (-ddddp±ddd, a binary exponent),
        // 'e' (-d.dddde±dd, a decimal exponent),
        // 'E' (-d.ddddE±dd, a decimal exponent),
        // 'f' (-ddd.dddd, no exponent),
        // 'g' ('e' for large exponents, 'f' otherwise),
        // 'G' ('E' for large exponents, 'f' otherwise),
        // 'x' (-0xd.ddddp±ddd, a hexadecimal fraction and binary exponent), or
        // 'X' (-0Xd.ddddP±ddd, a hexadecimal fraction and binary exponent).
        //
        // The precision prec controls the number of digits (excluding the exponent)
        // printed by the 'e', 'E', 'f', 'g', 'G', 'x', and 'X' formats.
        // For 'e', 'E', 'f', 'x', and 'X', it is the number of digits after the decimal point.
        // For 'g' and 'G' it is the maximum number of significant digits (trailing
        // zeros are removed).
        // The special precision -1 uses the smallest number of digits
        // necessary such that ParseFloat will return f exactly.
        public static @string FormatFloat(double f, byte fmt, long prec, long bitSize)
        {
            return string(genericFtoa(make_slice<byte>(0L, max(prec + 4L, 24L)), f, fmt, prec, bitSize));
        }

        // AppendFloat appends the string form of the floating-point number f,
        // as generated by FormatFloat, to dst and returns the extended buffer.
        public static slice<byte> AppendFloat(slice<byte> dst, double f, byte fmt, long prec, long bitSize)
        {
            return genericFtoa(dst, f, fmt, prec, bitSize);
        }

        private static slice<byte> genericFtoa(slice<byte> dst, double val, byte fmt, long prec, long bitSize) => func((_, panic, __) =>
        {
            ulong bits = default;
            ptr<floatInfo> flt;
            switch (bitSize)
            {
                case 32L: 
                    bits = uint64(math.Float32bits(float32(val)));
                    flt = _addr_float32info;
                    break;
                case 64L: 
                    bits = math.Float64bits(val);
                    flt = _addr_float64info;
                    break;
                default: 
                    panic("strconv: illegal AppendFloat/FormatFloat bitSize");
                    break;
            }

            var neg = bits >> (int)((flt.expbits + flt.mantbits)) != 0L;
            var exp = int(bits >> (int)(flt.mantbits)) & (1L << (int)(flt.expbits) - 1L);
            var mant = bits & (uint64(1L) << (int)(flt.mantbits) - 1L);

            switch (exp)
            {
                case 1L << (int)(flt.expbits) - 1L: 
                    // Inf, NaN
                    @string s = default;

                    if (mant != 0L) 
                        s = "NaN";
                    else if (neg) 
                        s = "-Inf";
                    else 
                        s = "+Inf";
                                    return append(dst, s);
                    break;
                case 0L: 
                    // denormalized
                    exp++;
                    break;
                default: 
                    // add implicit top bit
                    mant |= uint64(1L) << (int)(flt.mantbits);
                    break;
            }
            exp += flt.bias; 

            // Pick off easy binary, hex formats.
            if (fmt == 'b')
            {
                return fmtB(dst, neg, mant, exp, flt);
            }

            if (fmt == 'x' || fmt == 'X')
            {
                return fmtX(dst, prec, fmt, neg, mant, exp, flt);
            }

            if (!optimize)
            {
                return bigFtoa(dst, prec, fmt, neg, mant, exp, flt);
            }

            ref decimalSlice digs = ref heap(out ptr<decimalSlice> _addr_digs);
            var ok = false; 
            // Negative precision means "only as much as needed to be exact."
            var shortest = prec < 0L;
            if (shortest)
            { 
                // Try Grisu3 algorithm.
                ptr<object> f = @new<extFloat>();
                var (lower, upper) = f.AssignComputeBounds(mant, exp, neg, flt);
                array<byte> buf = new array<byte>(32L);
                digs.d = buf[..];
                ok = f.ShortestDecimal(_addr_digs, _addr_lower, _addr_upper);
                if (!ok)
                {
                    return bigFtoa(dst, prec, fmt, neg, mant, exp, flt);
                } 
                // Precision for shortest representation mode.
                switch (fmt)
                {
                    case 'e': 

                    case 'E': 
                        prec = max(digs.nd - 1L, 0L);
                        break;
                    case 'f': 
                        prec = max(digs.nd - digs.dp, 0L);
                        break;
                    case 'g': 

                    case 'G': 
                        prec = digs.nd;
                        break;
                }

            }
            else if (fmt != 'f')
            { 
                // Fixed number of digits.
                var digits = prec;
                switch (fmt)
                {
                    case 'e': 

                    case 'E': 
                        digits++;
                        break;
                    case 'g': 

                    case 'G': 
                        if (prec == 0L)
                        {
                            prec = 1L;
                        }

                        digits = prec;
                        break;
                }
                if (digits <= 15L)
                { 
                    // try fast algorithm when the number of digits is reasonable.
                    buf = new array<byte>(24L);
                    digs.d = buf[..];
                    f = new extFloat(mant,exp-int(flt.mantbits),neg);
                    ok = f.FixedDecimal(_addr_digs, digits);

                }

            }

            if (!ok)
            {
                return bigFtoa(dst, prec, fmt, neg, mant, exp, flt);
            }

            return formatDigits(dst, shortest, neg, digs, prec, fmt);

        });

        // bigFtoa uses multiprecision computations to format a float.
        private static slice<byte> bigFtoa(slice<byte> dst, long prec, byte fmt, bool neg, ulong mant, long exp, ptr<floatInfo> _addr_flt)
        {
            ref floatInfo flt = ref _addr_flt.val;

            ptr<object> d = @new<decimal>();
            d.Assign(mant);
            d.Shift(exp - int(flt.mantbits));
            decimalSlice digs = default;
            var shortest = prec < 0L;
            if (shortest)
            {
                roundShortest(d, mant, exp, _addr_flt);
                digs = new decimalSlice(d:d.d[:],nd:d.nd,dp:d.dp); 
                // Precision for shortest representation mode.
                switch (fmt)
                {
                    case 'e': 

                    case 'E': 
                        prec = digs.nd - 1L;
                        break;
                    case 'f': 
                        prec = max(digs.nd - digs.dp, 0L);
                        break;
                    case 'g': 

                    case 'G': 
                        prec = digs.nd;
                        break;
                }

            }
            else
            { 
                // Round appropriately.
                switch (fmt)
                {
                    case 'e': 

                    case 'E': 
                        d.Round(prec + 1L);
                        break;
                    case 'f': 
                        d.Round(d.dp + prec);
                        break;
                    case 'g': 

                    case 'G': 
                        if (prec == 0L)
                        {
                            prec = 1L;
                        }

                        d.Round(prec);
                        break;
                }
                digs = new decimalSlice(d:d.d[:],nd:d.nd,dp:d.dp);

            }

            return formatDigits(dst, shortest, neg, digs, prec, fmt);

        }

        private static slice<byte> formatDigits(slice<byte> dst, bool shortest, bool neg, decimalSlice digs, long prec, byte fmt)
        {
            switch (fmt)
            {
                case 'e': 

                case 'E': 
                    return fmtE(dst, neg, digs, prec, fmt);
                    break;
                case 'f': 
                    return fmtF(dst, neg, digs, prec);
                    break;
                case 'g': 
                    // trailing fractional zeros in 'e' form will be trimmed.

                case 'G': 
                    // trailing fractional zeros in 'e' form will be trimmed.
                    var eprec = prec;
                    if (eprec > digs.nd && digs.nd >= digs.dp)
                    {
                        eprec = digs.nd;
                    } 
                    // %e is used if the exponent from the conversion
                    // is less than -4 or greater than or equal to the precision.
                    // if precision was the shortest possible, use precision 6 for this decision.
                    if (shortest)
                    {
                        eprec = 6L;
                    }

                    var exp = digs.dp - 1L;
                    if (exp < -4L || exp >= eprec)
                    {
                        if (prec > digs.nd)
                        {
                            prec = digs.nd;
                        }

                        return fmtE(dst, neg, digs, prec - 1L, fmt + 'e' - 'g');

                    }

                    if (prec > digs.dp)
                    {
                        prec = digs.nd;
                    }

                    return fmtF(dst, neg, digs, max(prec - digs.dp, 0L));
                    break;
            } 

            // unknown format
            return append(dst, '%', fmt);

        }

        // roundShortest rounds d (= mant * 2^exp) to the shortest number of digits
        // that will let the original floating point value be precisely reconstructed.
        private static void roundShortest(ptr<decimal> _addr_d, ulong mant, long exp, ptr<floatInfo> _addr_flt)
        {
            ref decimal d = ref _addr_d.val;
            ref floatInfo flt = ref _addr_flt.val;
 
            // If mantissa is zero, the number is zero; stop now.
            if (mant == 0L)
            {
                d.nd = 0L;
                return ;
            } 

            // Compute upper and lower such that any decimal number
            // between upper and lower (possibly inclusive)
            // will round to the original floating point number.

            // We may see at once that the number is already shortest.
            //
            // Suppose d is not denormal, so that 2^exp <= d < 10^dp.
            // The closest shorter number is at least 10^(dp-nd) away.
            // The lower/upper bounds computed below are at distance
            // at most 2^(exp-mantbits).
            //
            // So the number is already shortest if 10^(dp-nd) > 2^(exp-mantbits),
            // or equivalently log2(10)*(dp-nd) > exp-mantbits.
            // It is true if 332/100*(dp-nd) >= exp-mantbits (log2(10) > 3.32).
            var minexp = flt.bias + 1L; // minimum possible exponent
            if (exp > minexp && 332L * (d.dp - d.nd) >= 100L * (exp - int(flt.mantbits)))
            { 
                // The number is already shortest.
                return ;

            } 

            // d = mant << (exp - mantbits)
            // Next highest floating point number is mant+1 << exp-mantbits.
            // Our upper bound is halfway between, mant*2+1 << exp-mantbits-1.
            ptr<decimal> upper = @new<decimal>();
            upper.Assign(mant * 2L + 1L);
            upper.Shift(exp - int(flt.mantbits) - 1L); 

            // d = mant << (exp - mantbits)
            // Next lowest floating point number is mant-1 << exp-mantbits,
            // unless mant-1 drops the significant bit and exp is not the minimum exp,
            // in which case the next lowest is mant*2-1 << exp-mantbits-1.
            // Either way, call it mantlo << explo-mantbits.
            // Our lower bound is halfway between, mantlo*2+1 << explo-mantbits-1.
            ulong mantlo = default;
            long explo = default;
            if (mant > 1L << (int)(flt.mantbits) || exp == minexp)
            {
                mantlo = mant - 1L;
                explo = exp;
            }
            else
            {
                mantlo = mant * 2L - 1L;
                explo = exp - 1L;
            }

            ptr<decimal> lower = @new<decimal>();
            lower.Assign(mantlo * 2L + 1L);
            lower.Shift(explo - int(flt.mantbits) - 1L); 

            // The upper and lower bounds are possible outputs only if
            // the original mantissa is even, so that IEEE round-to-even
            // would round to the original mantissa and not the neighbors.
            var inclusive = mant % 2L == 0L; 

            // As we walk the digits we want to know whether rounding up would fall
            // within the upper bound. This is tracked by upperdelta:
            //
            // If upperdelta == 0, the digits of d and upper are the same so far.
            //
            // If upperdelta == 1, we saw a difference of 1 between d and upper on a
            // previous digit and subsequently only 9s for d and 0s for upper.
            // (Thus rounding up may fall outside the bound, if it is exclusive.)
            //
            // If upperdelta == 2, then the difference is greater than 1
            // and we know that rounding up falls within the bound.
            byte upperdelta = default; 

            // Now we can figure out the minimum number of digits required.
            // Walk along until d has distinguished itself from upper and lower.
            for (long ui = 0L; >>MARKER:FOREXPRESSION_LEVEL_1<<; ui++)
            { 
                // lower, d, and upper may have the decimal points at different
                // places. In this case upper is the longest, so we iterate from
                // ui==0 and start li and mi at (possibly) -1.
                var mi = ui - upper.dp + d.dp;
                if (mi >= d.nd)
                {
                    break;
                }

                var li = ui - upper.dp + lower.dp;
                var l = byte('0'); // lower digit
                if (li >= 0L && li < lower.nd)
                {
                    l = lower.d[li];
                }

                var m = byte('0'); // middle digit
                if (mi >= 0L)
                {
                    m = d.d[mi];
                }

                var u = byte('0'); // upper digit
                if (ui < upper.nd)
                {
                    u = upper.d[ui];
                } 

                // Okay to round down (truncate) if lower has a different digit
                // or if lower is inclusive and is exactly the result of rounding
                // down (i.e., and we have reached the final digit of lower).
                var okdown = l != m || inclusive && li + 1L == lower.nd;


                if (upperdelta == 0L && m + 1L < u) 
                    // Example:
                    // m = 12345xxx
                    // u = 12347xxx
                    upperdelta = 2L;
                else if (upperdelta == 0L && m != u) 
                    // Example:
                    // m = 12345xxx
                    // u = 12346xxx
                    upperdelta = 1L;
                else if (upperdelta == 1L && (m != '9' || u != '0')) 
                    // Example:
                    // m = 1234598x
                    // u = 1234600x
                    upperdelta = 2L;
                // Okay to round up if upper has a different digit and either upper
                // is inclusive or upper is bigger than the result of rounding up.
                var okup = upperdelta > 0L && (inclusive || upperdelta > 1L || ui + 1L < upper.nd); 

                // If it's okay to do either, then round to the nearest one.
                // If it's okay to do only one, do it.

                if (okdown && okup) 
                    d.Round(mi + 1L);
                    return ;
                else if (okdown) 
                    d.RoundDown(mi + 1L);
                    return ;
                else if (okup) 
                    d.RoundUp(mi + 1L);
                    return ;
                
            }


        }

        private partial struct decimalSlice
        {
            public slice<byte> d;
            public long nd;
            public long dp;
            public bool neg;
        }

        // %e: -d.ddddde±dd
        private static slice<byte> fmtE(slice<byte> dst, bool neg, decimalSlice d, long prec, byte fmt)
        { 
            // sign
            if (neg)
            {
                dst = append(dst, '-');
            } 

            // first digit
            var ch = byte('0');
            if (d.nd != 0L)
            {
                ch = d.d[0L];
            }

            dst = append(dst, ch); 

            // .moredigits
            if (prec > 0L)
            {
                dst = append(dst, '.');
                long i = 1L;
                var m = min(d.nd, prec + 1L);
                if (i < m)
                {
                    dst = append(dst, d.d[i..m]);
                    i = m;
                }

                while (i <= prec)
                {
                    dst = append(dst, '0');
                    i++;
                }


            } 

            // e±
            dst = append(dst, fmt);
            var exp = d.dp - 1L;
            if (d.nd == 0L)
            { // special case: 0 has exponent 0
                exp = 0L;

            }

            if (exp < 0L)
            {
                ch = '-';
                exp = -exp;
            }
            else
            {
                ch = '+';
            }

            dst = append(dst, ch); 

            // dd or ddd

            if (exp < 10L) 
                dst = append(dst, '0', byte(exp) + '0');
            else if (exp < 100L) 
                dst = append(dst, byte(exp / 10L) + '0', byte(exp % 10L) + '0');
            else 
                dst = append(dst, byte(exp / 100L) + '0', byte(exp / 10L) % 10L + '0', byte(exp % 10L) + '0');
                        return dst;

        }

        // %f: -ddddddd.ddddd
        private static slice<byte> fmtF(slice<byte> dst, bool neg, decimalSlice d, long prec)
        { 
            // sign
            if (neg)
            {
                dst = append(dst, '-');
            } 

            // integer, padded with zeros as needed.
            if (d.dp > 0L)
            {
                var m = min(d.nd, d.dp);
                dst = append(dst, d.d[..m]);
                while (m < d.dp)
                {
                    dst = append(dst, '0');
                    m++;
                }
            else


            }            {
                dst = append(dst, '0');
            } 

            // fraction
            if (prec > 0L)
            {
                dst = append(dst, '.');
                for (long i = 0L; i < prec; i++)
                {
                    var ch = byte('0');
                    {
                        var j = d.dp + i;

                        if (0L <= j && j < d.nd)
                        {
                            ch = d.d[j];
                        }

                    }

                    dst = append(dst, ch);

                }


            }

            return dst;

        }

        // %b: -ddddddddp±ddd
        private static slice<byte> fmtB(slice<byte> dst, bool neg, ulong mant, long exp, ptr<floatInfo> _addr_flt)
        {
            ref floatInfo flt = ref _addr_flt.val;
 
            // sign
            if (neg)
            {
                dst = append(dst, '-');
            } 

            // mantissa
            dst, _ = formatBits(dst, mant, 10L, false, true); 

            // p
            dst = append(dst, 'p'); 

            // ±exponent
            exp -= int(flt.mantbits);
            if (exp >= 0L)
            {
                dst = append(dst, '+');
            }

            dst, _ = formatBits(dst, uint64(exp), 10L, exp < 0L, true);

            return dst;

        }

        // %x: -0x1.yyyyyyyyp±ddd or -0x0p+0. (y is hex digit, d is decimal digit)
        private static slice<byte> fmtX(slice<byte> dst, long prec, byte fmt, bool neg, ulong mant, long exp, ptr<floatInfo> _addr_flt)
        {
            ref floatInfo flt = ref _addr_flt.val;

            if (mant == 0L)
            {
                exp = 0L;
            } 

            // Shift digits so leading 1 (if any) is at bit 1<<60.
            mant <<= 60L - flt.mantbits;
            while (mant != 0L && mant & (1L << (int)(60L)) == 0L)
            {
                mant <<= 1L;
                exp--;
            } 

            // Round if requested.
 

            // Round if requested.
            if (prec >= 0L && prec < 15L)
            {
                var shift = uint(prec * 4L);
                var extra = (mant << (int)(shift)) & (1L << (int)(60L) - 1L);
                mant >>= 60L - shift;
                if (extra | (mant & 1L) > 1L << (int)(59L))
                {
                    mant++;
                }

                mant <<= 60L - shift;
                if (mant & (1L << (int)(61L)) != 0L)
                { 
                    // Wrapped around.
                    mant >>= 1L;
                    exp++;

                }

            }

            var hex = lowerhex;
            if (fmt == 'X')
            {
                hex = upperhex;
            } 

            // sign, 0x, leading digit
            if (neg)
            {
                dst = append(dst, '-');
            }

            dst = append(dst, '0', fmt, '0' + byte((mant >> (int)(60L)) & 1L)); 

            // .fraction
            mant <<= 4L; // remove leading 0 or 1
            if (prec < 0L && mant != 0L)
            {
                dst = append(dst, '.');
                while (mant != 0L)
                {
                    dst = append(dst, hex[(mant >> (int)(60L)) & 15L]);
                    mant <<= 4L;
                }


            }
            else if (prec > 0L)
            {
                dst = append(dst, '.');
                for (long i = 0L; i < prec; i++)
                {
                    dst = append(dst, hex[(mant >> (int)(60L)) & 15L]);
                    mant <<= 4L;
                }


            } 

            // p±
            var ch = byte('P');
            if (fmt == lower(fmt))
            {
                ch = 'p';
            }

            dst = append(dst, ch);
            if (exp < 0L)
            {
                ch = '-';
                exp = -exp;
            }
            else
            {
                ch = '+';
            }

            dst = append(dst, ch); 

            // dd or ddd or dddd

            if (exp < 100L) 
                dst = append(dst, byte(exp / 10L) + '0', byte(exp % 10L) + '0');
            else if (exp < 1000L) 
                dst = append(dst, byte(exp / 100L) + '0', byte((exp / 10L) % 10L) + '0', byte(exp % 10L) + '0');
            else 
                dst = append(dst, byte(exp / 1000L) + '0', byte(exp / 100L) % 10L + '0', byte((exp / 10L) % 10L) + '0', byte(exp % 10L) + '0');
                        return dst;

        }

        private static long min(long a, long b)
        {
            if (a < b)
            {
                return a;
            }

            return b;

        }

        private static long max(long a, long b)
        {
            if (a > b)
            {
                return a;
            }

            return b;

        }
    }
}
