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
        public partial struct BlockEffects
        {
            // Constructors
            public BlockEffects(NilType _)
            {
                this.uevar = default;
                this.varkill = default;
                this.livein = default;
                this.liveout = default;
            }

            public BlockEffects(varRegVec uevar = default, varRegVec varkill = default, varRegVec livein = default, varRegVec liveout = default)
            {
                this.uevar = uevar;
                this.varkill = varkill;
                this.livein = livein;
                this.liveout = liveout;
            }

            // Enable comparisons between nil and BlockEffects struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(BlockEffects value, NilType nil) => value.Equals(default(BlockEffects));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(BlockEffects value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, BlockEffects value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, BlockEffects value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator BlockEffects(NilType nil) => default(BlockEffects);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static BlockEffects BlockEffects_cast(dynamic value)
        {
            return new BlockEffects(value.uevar, value.varkill, value.livein, value.liveout);
        }
    }
}}}}