//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:05:04 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using fmt = go.fmt_package;
using types = go.go.types_package;
using reflect = go.reflect_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace tools {
namespace go {
namespace types
{
    public static partial class typeutil_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Hasher
        {
            // Constructors
            public Hasher(NilType _)
            {
                this.memo = default;
            }

            public Hasher(map<types.Type, uint> memo = default)
            {
                this.memo = memo;
            }

            // Enable comparisons between nil and Hasher struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Hasher value, NilType nil) => value.Equals(default(Hasher));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Hasher value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Hasher value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Hasher value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Hasher(NilType nil) => default(Hasher);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Hasher Hasher_cast(dynamic value)
        {
            return new Hasher(value.memo);
        }
    }
}}}}}}}}