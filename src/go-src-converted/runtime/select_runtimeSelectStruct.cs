//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:48:11 UTC
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
        private partial struct runtimeSelect
        {
            // Constructors
            public runtimeSelect(NilType _)
            {
                this.dir = default;
                this.typ = default;
                this.ch = default;
                this.val = default;
            }

            public runtimeSelect(selectDir dir = default, unsafe.Pointer typ = default, ref ptr<hchan> ch = default, unsafe.Pointer val = default)
            {
                this.dir = dir;
                this.typ = typ;
                this.ch = ch;
                this.val = val;
            }

            // Enable comparisons between nil and runtimeSelect struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(runtimeSelect value, NilType nil) => value.Equals(default(runtimeSelect));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(runtimeSelect value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, runtimeSelect value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, runtimeSelect value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator runtimeSelect(NilType nil) => default(runtimeSelect);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static runtimeSelect runtimeSelect_cast(dynamic value)
        {
            return new runtimeSelect(value.dir, value.typ, ref value.ch, value.val);
        }
    }
}