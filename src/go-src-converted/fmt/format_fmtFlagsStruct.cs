//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:07:52 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using strconv = go.strconv_package;
using utf8 = go.unicode.utf8_package;

#nullable enable

namespace go
{
    public static partial class fmt_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct fmtFlags
        {
            // Constructors
            public fmtFlags(NilType _)
            {
                this.widPresent = default;
                this.precPresent = default;
                this.minus = default;
                this.plus = default;
                this.sharp = default;
                this.space = default;
                this.zero = default;
                this.plusV = default;
                this.sharpV = default;
            }

            public fmtFlags(bool widPresent = default, bool precPresent = default, bool minus = default, bool plus = default, bool sharp = default, bool space = default, bool zero = default, bool plusV = default, bool sharpV = default)
            {
                this.widPresent = widPresent;
                this.precPresent = precPresent;
                this.minus = minus;
                this.plus = plus;
                this.sharp = sharp;
                this.space = space;
                this.zero = zero;
                this.plusV = plusV;
                this.sharpV = sharpV;
            }

            // Enable comparisons between nil and fmtFlags struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(fmtFlags value, NilType nil) => value.Equals(default(fmtFlags));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(fmtFlags value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, fmtFlags value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, fmtFlags value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator fmtFlags(NilType nil) => default(fmtFlags);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static fmtFlags fmtFlags_cast(dynamic value)
        {
            return new fmtFlags(value.widPresent, value.precPresent, value.minus, value.plus, value.sharp, value.space, value.zero, value.plusV, value.sharpV);
        }
    }
}