//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:41:11 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using types = go.cmd.compile.@internal.types_package;
using src = go.cmd.@internal.src_package;
using fmt = go.fmt_package;
using big = go.math.big_package;
using strings = go.strings_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class gc_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct constSet
        {
            // Constructors
            public constSet(NilType _)
            {
                this.m = default;
            }

            public constSet(map<constSetKey, src.XPos> m = default)
            {
                this.m = m;
            }

            // Enable comparisons between nil and constSet struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(constSet value, NilType nil) => value.Equals(default(constSet));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(constSet value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, constSet value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, constSet value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator constSet(NilType nil) => default(constSet);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static constSet constSet_cast(dynamic value)
        {
            return new constSet(value.m);
        }
    }
}}}}