//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 08 00:10:52 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using fmt = go.fmt_package;

namespace go
{
    public static partial class main_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct T2
        {
            // Constructors
            public T2(NilType _)
            {
                this.name = default;
            }

            public T2(@string name = default)
            {
                this.name = name;
            }

            // Enable comparisons between nil and T2 struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(T2 value, NilType nil) => value.Equals(default(T2));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(T2 value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, T2 value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, T2 value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator T2(NilType nil) => default(T2);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static T2 T2_cast(dynamic value)
        {
            return new T2(value.name);
        }
    }
}