//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:54:51 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using errors = go.errors_package;
using fmt = go.fmt_package;
using big = go.math.big_package;
using reflect = go.reflect_package;
using sort = go.sort_package;
using time = go.time_package;
using utf8 = go.unicode.utf8_package;
using go;

#nullable enable

namespace go {
namespace encoding
{
    public static partial class asn1_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct taggedEncoder
        {
            // Constructors
            public taggedEncoder(NilType _)
            {
                this.scratch = default;
                this.tag = default;
                this.body = default;
            }

            public taggedEncoder(array<byte> scratch = default, encoder tag = default, encoder body = default)
            {
                this.scratch = scratch;
                this.tag = tag;
                this.body = body;
            }

            // Enable comparisons between nil and taggedEncoder struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(taggedEncoder value, NilType nil) => value.Equals(default(taggedEncoder));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(taggedEncoder value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, taggedEncoder value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, taggedEncoder value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator taggedEncoder(NilType nil) => default(taggedEncoder);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static taggedEncoder taggedEncoder_cast(dynamic value)
        {
            return new taggedEncoder(value.scratch, value.tag, value.body);
        }
    }
}}