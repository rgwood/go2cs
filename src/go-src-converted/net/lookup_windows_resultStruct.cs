//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:52:04 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using context = go.context_package;
using windows = go.@internal.syscall.windows_package;
using os = go.os_package;
using runtime = go.runtime_package;
using syscall = go.syscall_package;
using @unsafe = go.@unsafe_package;

#nullable enable

namespace go
{
    public static partial class net_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct result
        {
            // Constructors
            public result(NilType _)
            {
                this.proto = default;
                this.err = default;
            }

            public result(long proto = default, error err = default)
            {
                this.proto = proto;
                this.err = err;
            }

            // Enable comparisons between nil and result struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(result value, NilType nil) => value.Equals(default(result));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(result value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, result value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, result value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator result(NilType nil) => default(result);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static result result_cast(dynamic value)
        {
            return new result(value.proto, value.err);
        }
    }
}