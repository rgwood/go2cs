//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:02:17 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using binary = go.encoding.binary_package;
using ast = go.go.ast_package;
using constant = go.go.constant_package;
using token = go.go.token_package;
using types = go.go.types_package;
using io = go.io_package;
using big = go.math.big_package;
using reflect = go.reflect_package;
using sort = go.sort_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace tools {
namespace go {
namespace @internal
{
    public static partial class gcimporter_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct objQueue
        {
            // Constructors
            public objQueue(NilType _)
            {
                this.ring = default;
                this.head = default;
                this.tail = default;
            }

            public objQueue(slice<types.Object> ring = default, long head = default, long tail = default)
            {
                this.ring = ring;
                this.head = head;
                this.tail = tail;
            }

            // Enable comparisons between nil and objQueue struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(objQueue value, NilType nil) => value.Equals(default(objQueue));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(objQueue value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, objQueue value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, objQueue value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator objQueue(NilType nil) => default(objQueue);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static objQueue objQueue_cast(dynamic value)
        {
            return new objQueue(value.ring, value.head, value.tail);
        }
    }
}}}}}}