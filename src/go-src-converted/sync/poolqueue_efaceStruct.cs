//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:01:09 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using atomic = go.sync.atomic_package;
using @unsafe = go.@unsafe_package;

#nullable enable

namespace go
{
    public static partial class sync_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct eface
        {
            // Constructors
            public eface(NilType _)
            {
                this.typ = default;
                this.val = default;
            }

            public eface(unsafe.Pointer typ = default, unsafe.Pointer val = default)
            {
                this.typ = typ;
                this.val = val;
            }

            // Enable comparisons between nil and eface struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(eface value, NilType nil) => value.Equals(default(eface));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(eface value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, eface value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, eface value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator eface(NilType nil) => default(eface);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static eface eface_cast(dynamic value)
        {
            return new eface(value.typ, value.val);
        }
    }
}