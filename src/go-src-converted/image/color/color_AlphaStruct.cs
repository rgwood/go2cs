//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:05:36 UTC
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
namespace image
{
    public static partial class color_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Alpha
        {
            // Constructors
            public Alpha(NilType _)
            {
                this.A = default;
            }

            public Alpha(byte A = default)
            {
                this.A = A;
            }

            // Enable comparisons between nil and Alpha struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Alpha value, NilType nil) => value.Equals(default(Alpha));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Alpha value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Alpha value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Alpha value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Alpha(NilType nil) => default(Alpha);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Alpha Alpha_cast(dynamic value)
        {
            return new Alpha(value.A);
        }
    }
}}