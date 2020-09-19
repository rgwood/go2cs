//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:25:54 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using sync = go.sync_package;
using go;

namespace go {
namespace math
{
    public static partial class rand_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct lockedSource
        {
            // Constructors
            public lockedSource(NilType _)
            {
                this.lk = default;
                this.src = default;
            }

            public lockedSource(sync.Mutex lk = default, Source64 src = default)
            {
                this.lk = lk;
                this.src = src;
            }

            // Enable comparisons between nil and lockedSource struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(lockedSource value, NilType nil) => value.Equals(default(lockedSource));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(lockedSource value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, lockedSource value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, lockedSource value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator lockedSource(NilType nil) => default(lockedSource);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static lockedSource lockedSource_cast(dynamic value)
        {
            return new lockedSource(value.lk, value.src);
        }
    }
}}