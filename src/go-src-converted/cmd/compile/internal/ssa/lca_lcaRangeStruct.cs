//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:24:47 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

using go;

#nullable enable

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class ssa_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct lcaRange
        {
            // Constructors
            public lcaRange(NilType _)
            {
                this.blocks = default;
                this.rangeMin = default;
            }

            public lcaRange(slice<lcaRangeBlock> blocks = default, slice<slice<ID>> rangeMin = default)
            {
                this.blocks = blocks;
                this.rangeMin = rangeMin;
            }

            // Enable comparisons between nil and lcaRange struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(lcaRange value, NilType nil) => value.Equals(default(lcaRange));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(lcaRange value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, lcaRange value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, lcaRange value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator lcaRange(NilType nil) => default(lcaRange);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static lcaRange lcaRange_cast(dynamic value)
        {
            return new lcaRange(value.blocks, value.rangeMin);
        }
    }
}}}}