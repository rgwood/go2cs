//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:59:31 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using reflect = go.reflect_package;
using sort = go.sort_package;
using go;

#nullable enable

namespace go {
namespace @internal
{
    public static partial class fmtsort_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct SortedMap
        {
            // Constructors
            public SortedMap(NilType _)
            {
                this.Key = default;
                this.Value = default;
            }

            public SortedMap(slice<reflect.Value> Key = default, slice<reflect.Value> Value = default)
            {
                this.Key = Key;
                this.Value = Value;
            }

            // Enable comparisons between nil and SortedMap struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(SortedMap value, NilType nil) => value.Equals(default(SortedMap));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(SortedMap value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, SortedMap value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, SortedMap value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator SortedMap(NilType nil) => default(SortedMap);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static SortedMap SortedMap_cast(dynamic value)
        {
            return new SortedMap(value.Key, value.Value);
        }
    }
}}