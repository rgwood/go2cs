//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:54:54 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using binary = go.encoding.binary_package;
using fmt = go.fmt_package;
using log = go.log_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace arch {
namespace ppc64
{
    public static partial class ppc64asm_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct instFormat
        {
            // Constructors
            public instFormat(NilType _)
            {
                this.Op = default;
                this.Mask = default;
                this.Value = default;
                this.DontCare = default;
                this.Args = default;
            }

            public instFormat(Op Op = default, uint Mask = default, uint Value = default, uint DontCare = default, array<ptr<argField>> Args = default)
            {
                this.Op = Op;
                this.Mask = Mask;
                this.Value = Value;
                this.DontCare = DontCare;
                this.Args = Args;
            }

            // Enable comparisons between nil and instFormat struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(instFormat value, NilType nil) => value.Equals(default(instFormat));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(instFormat value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, instFormat value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, instFormat value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator instFormat(NilType nil) => default(instFormat);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static instFormat instFormat_cast(dynamic value)
        {
            return new instFormat(value.Op, value.Mask, value.Value, value.DontCare, value.Args);
        }
    }
}}}}}}}