//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:52:57 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using heap = go.container.heap_package;
using math = go.math_package;
using sort = go.sort_package;
using strings = go.strings_package;
using time = go.time_package;
using go;

#nullable enable

namespace go {
namespace @internal
{
    public static partial class trace_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct mmuBand
        {
            // Constructors
            public mmuBand(NilType _)
            {
                this.minUtil = default;
                this.cumUtil = default;
                this.integrator = default;
            }

            public mmuBand(double minUtil = default, totalUtil cumUtil = default, integrator integrator = default)
            {
                this.minUtil = minUtil;
                this.cumUtil = cumUtil;
                this.integrator = integrator;
            }

            // Enable comparisons between nil and mmuBand struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(mmuBand value, NilType nil) => value.Equals(default(mmuBand));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(mmuBand value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, mmuBand value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, mmuBand value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator mmuBand(NilType nil) => default(mmuBand);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static mmuBand mmuBand_cast(dynamic value)
        {
            return new mmuBand(value.minUtil, value.cumUtil, value.integrator);
        }
    }
}}