//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:51:48 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using syscall = go.syscall_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace net
{
    public static partial class lif_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct endpoint
        {
            // Constructors
            public endpoint(NilType _)
            {
                this.af = default;
                this.s = default;
            }

            public endpoint(long af = default, System.UIntPtr s = default)
            {
                this.af = af;
                this.s = s;
            }

            // Enable comparisons between nil and endpoint struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(endpoint value, NilType nil) => value.Equals(default(endpoint));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(endpoint value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, endpoint value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, endpoint value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator endpoint(NilType nil) => default(endpoint);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static endpoint endpoint_cast(dynamic value)
        {
            return new endpoint(value.af, value.s);
        }
    }
}}}}