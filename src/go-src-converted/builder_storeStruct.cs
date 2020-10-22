//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:03:12 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using fmt = go.fmt_package;
using ast = go.go.ast_package;
using constant = go.go.constant_package;
using token = go.go.token_package;
using types = go.go.types_package;
using os = go.os_package;
using sync = go.sync_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace tools {
namespace go
{
    public static partial class ssa_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct store
        {
            // Constructors
            public store(NilType _)
            {
                this.lhs = default;
                this.rhs = default;
            }

            public store(lvalue lhs = default, Value rhs = default)
            {
                this.lhs = lhs;
                this.rhs = rhs;
            }

            // Enable comparisons between nil and store struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(store value, NilType nil) => value.Equals(default(store));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(store value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, store value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, store value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator store(NilType nil) => default(store);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static store store_cast(dynamic value)
        {
            return new store(value.lhs, value.rhs);
        }
    }
}}}}}