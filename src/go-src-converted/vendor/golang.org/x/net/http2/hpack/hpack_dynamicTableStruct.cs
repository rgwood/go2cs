//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:06:51 UTC
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
        private partial struct dynamicTable
        {
            // Constructors
            public dynamicTable(NilType _)
            {
                this.table = default;
                this.size = default;
                this.maxSize = default;
                this.allowedMaxSize = default;
            }

            public dynamicTable(headerFieldTable table = default, uint size = default, uint maxSize = default, uint allowedMaxSize = default)
            {
                this.table = table;
                this.size = size;
                this.maxSize = maxSize;
                this.allowedMaxSize = allowedMaxSize;
            }

            // Enable comparisons between nil and dynamicTable struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(dynamicTable value, NilType nil) => value.Equals(default(dynamicTable));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(dynamicTable value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, dynamicTable value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, dynamicTable value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator dynamicTable(NilType nil) => default(dynamicTable);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static dynamicTable dynamicTable_cast(dynamic value)
        {
            return new dynamicTable(value.table, value.size, value.maxSize, value.allowedMaxSize);
        }
    }
}}}}}}