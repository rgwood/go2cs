//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:51:36 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using runtime = go.runtime_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace net
{
    public static partial class route_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct DefaultAddr
        {
            // Constructors
            public DefaultAddr(NilType _)
            {
                this.af = default;
                this.Raw = default;
            }

            public DefaultAddr(long af = default, slice<byte> Raw = default)
            {
                this.af = af;
                this.Raw = Raw;
            }

            // Enable comparisons between nil and DefaultAddr struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(DefaultAddr value, NilType nil) => value.Equals(default(DefaultAddr));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(DefaultAddr value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, DefaultAddr value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, DefaultAddr value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator DefaultAddr(NilType nil) => default(DefaultAddr);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static DefaultAddr DefaultAddr_cast(dynamic value)
        {
            return new DefaultAddr(value.af, value.Raw);
        }
    }
}}}}