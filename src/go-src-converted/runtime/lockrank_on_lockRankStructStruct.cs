//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:46:07 UTC
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
        private partial struct lockRankStruct
        {
            // Constructors
            public lockRankStruct(NilType _)
            {
                this.rank = default;
                this.pad = default;
            }

            public lockRankStruct(lockRank rank = default, long pad = default)
            {
                this.rank = rank;
                this.pad = pad;
            }

            // Enable comparisons between nil and lockRankStruct struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(lockRankStruct value, NilType nil) => value.Equals(default(lockRankStruct));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(lockRankStruct value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, lockRankStruct value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, lockRankStruct value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator lockRankStruct(NilType nil) => default(lockRankStruct);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static lockRankStruct lockRankStruct_cast(dynamic value)
        {
            return new lockRankStruct(value.rank, value.pad);
        }
    }
}