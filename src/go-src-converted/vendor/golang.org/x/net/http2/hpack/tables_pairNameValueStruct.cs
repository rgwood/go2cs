//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:06:52 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using fmt = go.fmt_package;
using go;

#nullable enable

namespace go {
namespace vendor {
namespace golang.org {
namespace x {
namespace net {
namespace http2
{
    public static partial class hpack_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct pairNameValue
        {
            // Constructors
            public pairNameValue(NilType _)
            {
                this.name = default;
                this.value = default;
            }

            public pairNameValue(@string name = default, @string value = default)
            {
                this.name = name;
                this.value = value;
            }

            // Enable comparisons between nil and pairNameValue struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(pairNameValue value, NilType nil) => value.Equals(default(pairNameValue));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(pairNameValue value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, pairNameValue value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, pairNameValue value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator pairNameValue(NilType nil) => default(pairNameValue);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static pairNameValue pairNameValue_cast(dynamic value)
        {
            return new pairNameValue(value.name, value.value);
        }
    }
}}}}}}