//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:45:48 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using @unsafe = go.@unsafe_package;

#nullable enable

namespace go
{
    public static partial class runtime_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct mcontext64
        {
            // Constructors
            public mcontext64(NilType _)
            {
                this.es = default;
                this.ss = default;
                this.fs = default;
                this.pad_cgo_0 = default;
            }

            public mcontext64(exceptionstate64 es = default, regs64 ss = default, floatstate64 fs = default, array<byte> pad_cgo_0 = default)
            {
                this.es = es;
                this.ss = ss;
                this.fs = fs;
                this.pad_cgo_0 = pad_cgo_0;
            }

            // Enable comparisons between nil and mcontext64 struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(mcontext64 value, NilType nil) => value.Equals(default(mcontext64));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(mcontext64 value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, mcontext64 value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, mcontext64 value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator mcontext64(NilType nil) => default(mcontext64);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static mcontext64 mcontext64_cast(dynamic value)
        {
            return new mcontext64(value.es, value.ss, value.fs, value.pad_cgo_0);
        }
    }
}