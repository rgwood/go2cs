// Copyright 2015 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// This file implements Float-to-string conversion functions.
// It is closely following the corresponding implementation
// in strconv/ftoa.go, but modified and simplified for Float.

// package big -- go2cs converted at 2020 August 29 08:29:11 UTC
// import "math/big" ==> using big = go.math.big_package
// Original source: C:\Go\src\math\big\ftoa.go
using bytes = go.bytes_package;
using fmt = go.fmt_package;
using strconv = go.strconv_package;
using static go.builtin;

namespace go {
namespace math
{
    public static partial class big_package
    {
        // Text converts the floating-point number x to a string according
        // to the given format and precision prec. The format is one of:
        //
        //    'e'    -d.dddde±dd, decimal exponent, at least two (possibly 0) exponent digits
        //    'E'    -d.ddddE±dd, decimal exponent, at least two (possibly 0) exponent digits
        //    'f'    -ddddd.dddd, no exponent
        //    'g'    like 'e' for large exponents, like 'f' otherwise
        //    'G'    like 'E' for large exponents, like 'f' otherwise
        //    'b'    -ddddddp±dd, binary exponent
        //    'p'    -0x.dddp±dd, binary exponent, hexadecimal mantissa
        //
        // For the binary exponent formats, the mantissa is printed in normalized form:
        //
        //    'b'    decimal integer mantissa using x.Prec() bits, or -0
        //    'p'    hexadecimal fraction with 0.5 <= 0.mantissa < 1.0, or -0
        //
        // If format is a different character, Text returns a "%" followed by the
        // unrecognized format character.
        //
        // The precision prec controls the number of digits (excluding the exponent)
        // printed by the 'e', 'E', 'f', 'g', and 'G' formats. For 'e', 'E', and 'f'
        // it is the number of digits after the decimal point. For 'g' and 'G' it is
        // the total number of digits. A negative precision selects the smallest
        // number of decimal digits necessary to identify the value x uniquely using
        // x.Prec() mantissa bits.
        // The prec value is ignored for the 'b' or 'p' format.
        private static @string Text(this ref Float x, byte format, long prec)
        {
            long cap = 10L; // TODO(gri) determine a good/better value here
            if (prec > 0L)
            {
                cap += prec;
            }
            return string(x.Append(make_slice<byte>(0L, cap), format, prec));
        }

        // String formats x like x.Text('g', 10).
        // (String must be called explicitly, Float.Format does not support %s verb.)
        private static @string String(this ref Float x)
        {
            return x.Text('g', 10L);
        }

        // Append appends to buf the string form of the floating-point number x,
        // as generated by x.Text, and returns the extended buffer.
        private static slice<byte> Append(this ref Float x, slice<byte> buf, byte fmt, long prec)
        { 
            // sign
            if (x.neg)
            {
                buf = append(buf, '-');
            } 

            // Inf
            if (x.form == inf)
            {
                if (!x.neg)
                {
                    buf = append(buf, '+');
                }
                return append(buf, "Inf");
            } 

            // pick off easy formats
            switch (fmt)
            {
                case 'b': 
                    return x.fmtB(buf);
                    break;
                case 'p': 
                    return x.fmtP(buf);
                    break;
            } 

            // Algorithm:
            //   1) convert Float to multiprecision decimal
            //   2) round to desired precision
            //   3) read digits out and format

            // 1) convert Float to multiprecision decimal
            decimal d = default; // == 0.0
            if (x.form == finite)
            { 
                // x != 0
                d.init(x.mant, int(x.exp) - x.mant.bitLen());
            } 

            // 2) round to desired precision
            var shortest = false;
            if (prec < 0L)
            {
                shortest = true;
                roundShortest(ref d, x); 
                // Precision for shortest representation mode.
                switch (fmt)
                {
                    case 'e': 

                    case 'E': 
                        prec = len(d.mant) - 1L;
                        break;
                    case 'f': 
                        prec = max(len(d.mant) - d.exp, 0L);
                        break;
                    case 'g': 

                    case 'G': 
                        prec = len(d.mant);
                        break;
                }
            }
            else
            { 
                // round appropriately
                switch (fmt)
                {
                    case 'e': 
                        // one digit before and number of digits after decimal point

                    case 'E': 
                        // one digit before and number of digits after decimal point
                        d.round(1L + prec);
                        break;
                    case 'f': 
                        // number of digits before and after decimal point
                        d.round(d.exp + prec);
                        break;
                    case 'g': 

                    case 'G': 
                        if (prec == 0L)
                        {
                            prec = 1L;
                        }
                        d.round(prec);
                        break;
                }
            } 

            // 3) read digits out and format
            switch (fmt)
            {
                case 'e': 

                case 'E': 
                    return fmtE(buf, fmt, prec, d);
                    break;
                case 'f': 
                    return fmtF(buf, prec, d);
                    break;
                case 'g': 
                    // trim trailing fractional zeros in %e format

                case 'G': 
                    // trim trailing fractional zeros in %e format
                    var eprec = prec;
                    if (eprec > len(d.mant) && len(d.mant) >= d.exp)
                    {
                        eprec = len(d.mant);
                    } 
                    // %e is used if the exponent from the conversion
                    // is less than -4 or greater than or equal to the precision.
                    // If precision was the shortest possible, use eprec = 6 for
                    // this decision.
                    if (shortest)
                    {
                        eprec = 6L;
                    }
                    var exp = d.exp - 1L;
                    if (exp < -4L || exp >= eprec)
                    {
                        if (prec > len(d.mant))
                        {
                            prec = len(d.mant);
                        }
                        return fmtE(buf, fmt + 'e' - 'g', prec - 1L, d);
                    }
                    if (prec > d.exp)
                    {
                        prec = len(d.mant);
                    }
                    return fmtF(buf, max(prec - d.exp, 0L), d);
                    break;
            } 

            // unknown format
            if (x.neg)
            {
                buf = buf[..len(buf) - 1L]; // sign was added prematurely - remove it again
            }
            return append(buf, '%', fmt);
        }

        private static void roundShortest(ref decimal d, ref Float x)
        { 
            // if the mantissa is zero, the number is zero - stop now
            if (len(d.mant) == 0L)
            {
                return;
            } 

            // Approach: All numbers in the interval [x - 1/2ulp, x + 1/2ulp]
            // (possibly exclusive) round to x for the given precision of x.
            // Compute the lower and upper bound in decimal form and find the
            // shortest decimal number d such that lower <= d <= upper.

            // TODO(gri) strconv/ftoa.do describes a shortcut in some cases.
            // See if we can use it (in adjusted form) here as well.

            // 1) Compute normalized mantissa mant and exponent exp for x such
            // that the lsb of mant corresponds to 1/2 ulp for the precision of
            // x (i.e., for mant we want x.prec + 1 bits).
            var mant = nat(null).set(x.mant);
            var exp = int(x.exp) - mant.bitLen();
            var s = mant.bitLen() - int(x.prec + 1L);

            if (s < 0L) 
                mant = mant.shl(mant, uint(-s));
            else if (s > 0L) 
                mant = mant.shr(mant, uint(+s));
                        exp += s; 
            // x = mant * 2**exp with lsb(mant) == 1/2 ulp of x.prec

            // 2) Compute lower bound by subtracting 1/2 ulp.
            decimal lower = default;
            nat tmp = default;
            lower.init(tmp.sub(mant, natOne), exp); 

            // 3) Compute upper bound by adding 1/2 ulp.
            decimal upper = default;
            upper.init(tmp.add(mant, natOne), exp); 

            // The upper and lower bounds are possible outputs only if
            // the original mantissa is even, so that ToNearestEven rounding
            // would round to the original mantissa and not the neighbors.
            var inclusive = mant[0L] & 2L == 0L; // test bit 1 since original mantissa was shifted by 1

            // Now we can figure out the minimum number of digits required.
            // Walk along until d has distinguished itself from upper and lower.
            foreach (var (i, m) in d.mant)
            {
                var l = lower.at(i);
                var u = upper.at(i); 

                // Okay to round down (truncate) if lower has a different digit
                // or if lower is inclusive and is exactly the result of rounding
                // down (i.e., and we have reached the final digit of lower).
                var okdown = l != m || inclusive && i + 1L == len(lower.mant); 

                // Okay to round up if upper has a different digit and either upper
                // is inclusive or upper is bigger than the result of rounding up.
                var okup = m != u && (inclusive || m + 1L < u || i + 1L < len(upper.mant)); 

                // If it's okay to do either, then round to the nearest one.
                // If it's okay to do only one, do it.

                if (okdown && okup) 
                    d.round(i + 1L);
                    return;
                else if (okdown) 
                    d.roundDown(i + 1L);
                    return;
                else if (okup) 
                    d.roundUp(i + 1L);
                    return;
                            }
        }

        // %e: d.ddddde±dd
        private static slice<byte> fmtE(slice<byte> buf, byte fmt, long prec, decimal d)
        { 
            // first digit
            var ch = byte('0');
            if (len(d.mant) > 0L)
            {
                ch = d.mant[0L];
            }
            buf = append(buf, ch); 

            // .moredigits
            if (prec > 0L)
            {
                buf = append(buf, '.');
                long i = 1L;
                var m = min(len(d.mant), prec + 1L);
                if (i < m)
                {
                    buf = append(buf, d.mant[i..m]);
                    i = m;
                }
                while (i <= prec)
                {
                    buf = append(buf, '0');
                    i++;
                }

            } 

            // e±
            buf = append(buf, fmt);
            long exp = default;
            if (len(d.mant) > 0L)
            {
                exp = int64(d.exp) - 1L; // -1 because first digit was printed before '.'
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
            buf = append(buf, ch); 

            // dd...d
            if (exp < 10L)
            {
                buf = append(buf, '0'); // at least 2 exponent digits
            }
            return strconv.AppendInt(buf, exp, 10L);
        }

        // %f: ddddddd.ddddd
        private static slice<byte> fmtF(slice<byte> buf, long prec, decimal d)
        { 
            // integer, padded with zeros as needed
            if (d.exp > 0L)
            {
                var m = min(len(d.mant), d.exp);
                buf = append(buf, d.mant[..m]);
                while (m < d.exp)
                {
                    buf = append(buf, '0');
                    m++;
                }
            else

            }            {
                buf = append(buf, '0');
            } 

            // fraction
            if (prec > 0L)
            {
                buf = append(buf, '.');
                for (long i = 0L; i < prec; i++)
                {
                    buf = append(buf, d.at(d.exp + i));
                }

            }
            return buf;
        }

        // fmtB appends the string of x in the format mantissa "p" exponent
        // with a decimal mantissa and a binary exponent, or 0" if x is zero,
        // and returns the extended buffer.
        // The mantissa is normalized such that is uses x.Prec() bits in binary
        // representation.
        // The sign of x is ignored, and x must not be an Inf.
        private static slice<byte> fmtB(this ref Float _x, slice<byte> buf) => func(_x, (ref Float x, Defer _, Panic panic, Recover __) =>
        {
            if (x.form == zero)
            {
                return append(buf, '0');
            }
            if (debugFloat && x.form != finite)
            {
                panic("non-finite float");
            } 
            // x != 0

            // adjust mantissa to use exactly x.prec bits
            var m = x.mant;
            {
                var w = uint32(len(x.mant)) * _W;


                if (w < x.prec) 
                    m = nat(null).shl(m, uint(x.prec - w));
                else if (w > x.prec) 
                    m = nat(null).shr(m, uint(w - x.prec));

            }

            buf = append(buf, m.utoa(10L));
            buf = append(buf, 'p');
            var e = int64(x.exp) - int64(x.prec);
            if (e >= 0L)
            {
                buf = append(buf, '+');
            }
            return strconv.AppendInt(buf, e, 10L);
        });

        // fmtP appends the string of x in the format "0x." mantissa "p" exponent
        // with a hexadecimal mantissa and a binary exponent, or "0" if x is zero,
        // and returns the extended buffer.
        // The mantissa is normalized such that 0.5 <= 0.mantissa < 1.0.
        // The sign of x is ignored, and x must not be an Inf.
        private static slice<byte> fmtP(this ref Float _x, slice<byte> buf) => func(_x, (ref Float x, Defer _, Panic panic, Recover __) =>
        {
            if (x.form == zero)
            {
                return append(buf, '0');
            }
            if (debugFloat && x.form != finite)
            {
                panic("non-finite float");
            } 
            // x != 0

            // remove trailing 0 words early
            // (no need to convert to hex 0's and trim later)
            var m = x.mant;
            long i = 0L;
            while (i < len(m) && m[i] == 0L)
            {
                i++;
            }

            m = m[i..];

            buf = append(buf, "0x.");
            buf = append(buf, bytes.TrimRight(m.utoa(16L), "0"));
            buf = append(buf, 'p');
            if (x.exp >= 0L)
            {
                buf = append(buf, '+');
            }
            return strconv.AppendInt(buf, int64(x.exp), 10L);
        });

        private static long min(long x, long y)
        {
            if (x < y)
            {
                return x;
            }
            return y;
        }

        private static fmt.Formatter _ = ref floatZero; // *Float must implement fmt.Formatter

        // Format implements fmt.Formatter. It accepts all the regular
        // formats for floating-point numbers ('b', 'e', 'E', 'f', 'F',
        // 'g', 'G') as well as 'p' and 'v'. See (*Float).Text for the
        // interpretation of 'p'. The 'v' format is handled like 'g'.
        // Format also supports specification of the minimum precision
        // in digits, the output field width, as well as the format flags
        // '+' and ' ' for sign control, '0' for space or zero padding,
        // and '-' for left or right justification. See the fmt package
        // for details.
        private static void Format(this ref Float x, fmt.State s, int format)
        {
            var (prec, hasPrec) = s.Precision();
            if (!hasPrec)
            {
                prec = 6L; // default precision for 'e', 'f'
            }

            if (format == 'e' || format == 'E' || format == 'f' || format == 'b' || format == 'p')
            {
                goto __switch_break0;
            }
            if (format == 'F') 
            {
                // (*Float).Text doesn't support 'F'; handle like 'f'
                format = 'f';
                goto __switch_break0;
            }
            if (format == 'v') 
            {
                // handle like 'g'
                format = 'g';
                fallthrough = true;
            }
            if (fallthrough || format == 'g' || format == 'G')
            {
                if (!hasPrec)
                {
                    prec = -1L; // default precision for 'g', 'G'
                }
                goto __switch_break0;
            }
            // default: 
                fmt.Fprintf(s, "%%!%c(*big.Float=%s)", format, x.String());
                return;

            __switch_break0:;
            slice<byte> buf = default;
            buf = x.Append(buf, byte(format), prec);
            if (len(buf) == 0L)
            {
                buf = (slice<byte>)"?"; // should never happen, but don't crash
            } 
            // len(buf) > 0
            @string sign = default;

            if (buf[0L] == '-') 
                sign = "-";
                buf = buf[1L..];
            else if (buf[0L] == '+') 
                // +Inf
                sign = "+";
                if (s.Flag(' '))
                {
                    sign = " ";
                }
                buf = buf[1L..];
            else if (s.Flag('+')) 
                sign = "+";
            else if (s.Flag(' ')) 
                sign = " ";
                        long padding = default;
            {
                var (width, hasWidth) = s.Width();

                if (hasWidth && width > len(sign) + len(buf))
                {
                    padding = width - len(sign) - len(buf);
                }

            }


            if (s.Flag('0') && !x.IsInf()) 
                // 0-padding on left
                writeMultiple(s, sign, 1L);
                writeMultiple(s, "0", padding);
                s.Write(buf);
            else if (s.Flag('-')) 
                // padding on right
                writeMultiple(s, sign, 1L);
                s.Write(buf);
                writeMultiple(s, " ", padding);
            else 
                // padding on left
                writeMultiple(s, " ", padding);
                writeMultiple(s, sign, 1L);
                s.Write(buf);
                    }
    }
}}