//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 10:11:44 UTC
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

namespace go {
namespace vendor {
namespace golang_org {
namespace x {
namespace net {
namespace http2
{
    public static partial class hpack_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct headerFieldTable
        {
            // Constructors
            public headerFieldTable(NilType _)
            {
                this.ents = default;
                this.evictCount = default;
                this.byName = default;
                this.byNameValue = default;
            }

            public headerFieldTable(slice<HeaderField> ents = default, ulong evictCount = default, map<@string, ulong> byName = default, map<pairNameValue, ulong> byNameValue = default)
            {
                this.ents = ents;
                this.evictCount = evictCount;
                this.byName = byName;
                this.byNameValue = byNameValue;
            }

            // Enable comparisons between nil and headerFieldTable struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(headerFieldTable value, NilType nil) => value.Equals(default(headerFieldTable));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(headerFieldTable value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, headerFieldTable value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, headerFieldTable value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator headerFieldTable(NilType nil) => default(headerFieldTable);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static headerFieldTable headerFieldTable_cast(dynamic value)
        {
            return new headerFieldTable(value.ents, value.evictCount, value.byName, value.byNameValue);
        }
    }
}}}}}}