//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:42:21 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using ssa = go.cmd.compile.@internal.ssa_package;
using types = go.cmd.compile.@internal.types_package;
using obj = go.cmd.@internal.obj_package;
using objabi = go.cmd.@internal.objabi_package;
using md5 = go.crypto.md5_package;
using fmt = go.fmt_package;
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
        private partial struct progeffectscache
        {
            // Constructors
            public progeffectscache(NilType _)
            {
                this.retuevar = default;
                this.tailuevar = default;
                this.initialized = default;
            }

            public progeffectscache(slice<int> retuevar = default, slice<int> tailuevar = default, bool initialized = default)
            {
                this.retuevar = retuevar;
                this.tailuevar = tailuevar;
                this.initialized = initialized;
            }

            // Enable comparisons between nil and progeffectscache struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(progeffectscache value, NilType nil) => value.Equals(default(progeffectscache));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(progeffectscache value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, progeffectscache value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, progeffectscache value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator progeffectscache(NilType nil) => default(progeffectscache);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static progeffectscache progeffectscache_cast(dynamic value)
        {
            return new progeffectscache(value.retuevar, value.tailuevar, value.initialized);
        }
    }
}}}}