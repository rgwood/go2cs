//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:39:52 UTC
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
using token = go.go.token_package;
using sort = go.sort_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace tools {
namespace go {
namespace ast
{
    public static partial class astutil_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct tokenNode
        {
            // Constructors
            public tokenNode(NilType _)
            {
                this.pos = default;
                this.end = default;
            }

            public tokenNode(token.Pos pos = default, token.Pos end = default)
            {
                this.pos = pos;
                this.end = end;
            }

            // Enable comparisons between nil and tokenNode struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(tokenNode value, NilType nil) => value.Equals(default(tokenNode));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(tokenNode value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, tokenNode value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, tokenNode value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator tokenNode(NilType nil) => default(tokenNode);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static tokenNode tokenNode_cast(dynamic value)
        {
            return new tokenNode(value.pos, value.end);
        }
    }
}}}}}}