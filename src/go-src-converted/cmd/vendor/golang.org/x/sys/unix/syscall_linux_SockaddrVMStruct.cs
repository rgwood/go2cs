//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:56:43 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using binary = go.encoding.binary_package;
using runtime = go.runtime_package;
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
    public static partial class unix_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct SockaddrVM
        {
            // Constructors
            public SockaddrVM(NilType _)
            {
                this.CID = default;
                this.Port = default;
                this.raw = default;
            }

            public SockaddrVM(uint CID = default, uint Port = default, RawSockaddrVM raw = default)
            {
                this.CID = CID;
                this.Port = Port;
                this.raw = raw;
            }

            // Enable comparisons between nil and SockaddrVM struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(SockaddrVM value, NilType nil) => value.Equals(default(SockaddrVM));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(SockaddrVM value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, SockaddrVM value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, SockaddrVM value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator SockaddrVM(NilType nil) => default(SockaddrVM);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static SockaddrVM SockaddrVM_cast(dynamic value)
        {
            return new SockaddrVM(value.CID, value.Port, value.raw);
        }
    }
}}}}}}