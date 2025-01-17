//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:00:06 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using encoding = go.encoding_package;
using base64 = go.encoding.base64_package;
using fmt = go.fmt_package;
using math = go.math_package;
using reflect = go.reflect_package;
using sort = go.sort_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using sync = go.sync_package;
using unicode = go.unicode_package;
using utf8 = go.unicode.utf8_package;
using go;

#nullable enable

namespace go {
namespace encoding
{
    public static partial class json_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct structEncoder
        {
            // Constructors
            public structEncoder(NilType _)
            {
                this.fields = default;
            }

            public structEncoder(structFields fields = default)
            {
                this.fields = fields;
            }

            // Enable comparisons between nil and structEncoder struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(structEncoder value, NilType nil) => value.Equals(default(structEncoder));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(structEncoder value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, structEncoder value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, structEncoder value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator structEncoder(NilType nil) => default(structEncoder);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static structEncoder structEncoder_cast(dynamic value)
        {
            return new structEncoder(value.fields);
        }
    }
}}