//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:59 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using net = go.net_package;
using syscall = go.syscall_package;
using @unsafe = go.@unsafe_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace sys
{
    public static partial class windows_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct IO_COUNTERS
        {
            // Constructors
            public IO_COUNTERS(NilType _)
            {
                this.ReadOperationCount = default;
                this.WriteOperationCount = default;
                this.OtherOperationCount = default;
                this.ReadTransferCount = default;
                this.WriteTransferCount = default;
                this.OtherTransferCount = default;
            }

            public IO_COUNTERS(ulong ReadOperationCount = default, ulong WriteOperationCount = default, ulong OtherOperationCount = default, ulong ReadTransferCount = default, ulong WriteTransferCount = default, ulong OtherTransferCount = default)
            {
                this.ReadOperationCount = ReadOperationCount;
                this.WriteOperationCount = WriteOperationCount;
                this.OtherOperationCount = OtherOperationCount;
                this.ReadTransferCount = ReadTransferCount;
                this.WriteTransferCount = WriteTransferCount;
                this.OtherTransferCount = OtherTransferCount;
            }

            // Enable comparisons between nil and IO_COUNTERS struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(IO_COUNTERS value, NilType nil) => value.Equals(default(IO_COUNTERS));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(IO_COUNTERS value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, IO_COUNTERS value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, IO_COUNTERS value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator IO_COUNTERS(NilType nil) => default(IO_COUNTERS);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static IO_COUNTERS IO_COUNTERS_cast(dynamic value)
        {
            return new IO_COUNTERS(value.ReadOperationCount, value.WriteOperationCount, value.OtherOperationCount, value.ReadTransferCount, value.WriteTransferCount, value.OtherTransferCount);
        }
    }
}}}}}}