//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:16:24 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using race = go.@internal.race_package;
using atomic = go.sync.atomic_package;
using @unsafe = go.@unsafe_package;

namespace go
{
    public static partial class sync_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Mutex
        {
            // Constructors
            public Mutex(NilType _)
            {
                this.state = default;
                this.sema = default;
            }

            public Mutex(int state = default, uint sema = default)
            {
                this.state = state;
                this.sema = sema;
            }

            // Enable comparisons between nil and Mutex struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Mutex value, NilType nil) => value.Equals(default(Mutex));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Mutex value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Mutex value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Mutex value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Mutex(NilType nil) => default(Mutex);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Mutex Mutex_cast(dynamic value)
        {
            return new Mutex(value.state, value.sema);
        }
    }
}