//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:19:42 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using sort = go.sort_package;
using go;

#nullable enable

namespace go {
namespace go
{
    public static partial class types_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Struct
        {
            // Constructors
            public Struct(NilType _)
            {
                this.fields = default;
                this.tags = default;
            }

            public Struct(slice<ptr<Var>> fields = default, slice<@string> tags = default)
            {
                this.fields = fields;
                this.tags = tags;
            }

            // Enable comparisons between nil and Struct struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Struct value, NilType nil) => value.Equals(default(Struct));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Struct value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Struct value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Struct value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Struct(NilType nil) => default(Struct);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Struct Struct_cast(dynamic value)
        {
            return new Struct(value.fields, value.tags);
        }
    }
}}