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
using bytes = go.bytes_package;
using errors = go.errors_package;
using io = go.io_package;
using sync = go.sync_package;
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
        private partial struct node
        {
            // Constructors
            public node(NilType _)
            {
                this._ = default;
                this.children = default;
                this.codeLen = default;
                this.sym = default;
            }

            public node(incomparable _ = default, ref ptr<array<ptr<node>>> children = default, byte codeLen = default, byte sym = default)
            {
                this._ = _;
                this.children = children;
                this.codeLen = codeLen;
                this.sym = sym;
            }

            // Enable comparisons between nil and node struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(node value, NilType nil) => value.Equals(default(node));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(node value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, node value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, node value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator node(NilType nil) => default(node);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static node node_cast(dynamic value)
        {
            return new node(value._, ref value.children, value.codeLen, value.sym);
        }
    }
}}}}}}