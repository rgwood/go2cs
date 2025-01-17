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
        [PromotedStruct(typeof(fmtFlags))]
        private partial struct fmt
        {
            // fmtFlags structure promotion - sourced from value copy
            private readonly ptr<fmtFlags> m_fmtFlagsRef;

            private ref fmtFlags fmtFlags_val => ref m_fmtFlagsRef.Value;

            public ref bool widPresent => ref m_fmtFlagsRef.Value.widPresent;

            public ref bool precPresent => ref m_fmtFlagsRef.Value.precPresent;

            public ref bool minus => ref m_fmtFlagsRef.Value.minus;

            public ref bool plus => ref m_fmtFlagsRef.Value.plus;

            public ref bool sharp => ref m_fmtFlagsRef.Value.sharp;

            public ref bool space => ref m_fmtFlagsRef.Value.space;

            public ref bool zero => ref m_fmtFlagsRef.Value.zero;

            public ref bool plusV => ref m_fmtFlagsRef.Value.plusV;

            public ref bool sharpV => ref m_fmtFlagsRef.Value.sharpV;

            // Constructors
            public fmt(NilType _)
            {
                this.buf = default;
                this.m_fmtFlagsRef = new ptr<fmtFlags>(new fmtFlags(nil));
                this.wid = default;
                this.prec = default;
                this.intbuf = default;
            }

            public fmt(ref ptr<buffer> buf = default, fmtFlags fmtFlags = default, long wid = default, long prec = default, array<byte> intbuf = default)
            {
                this.buf = buf;
                this.m_fmtFlagsRef = new ptr<fmtFlags>(fmtFlags);
                this.wid = wid;
                this.prec = prec;
                this.intbuf = intbuf;
            }

            // Enable comparisons between nil and fmt struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(fmt value, NilType nil) => value.Equals(default(fmt));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(fmt value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, fmt value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, fmt value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator fmt(NilType nil) => default(fmt);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static fmt fmt_cast(dynamic value)
        {
            return new fmt(ref value.buf, value.fmtFlags, value.wid, value.prec, value.intbuf);
        }
    }
}