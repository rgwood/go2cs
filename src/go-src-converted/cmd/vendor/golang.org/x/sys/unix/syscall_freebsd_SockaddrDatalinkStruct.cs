//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:56:34 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using sync = go.sync_package;
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
        public partial struct SockaddrDatalink
        {
            // Constructors
            public SockaddrDatalink(NilType _)
            {
                this.Len = default;
                this.Family = default;
                this.Index = default;
                this.Type = default;
                this.Nlen = default;
                this.Alen = default;
                this.Slen = default;
                this.Data = default;
                this.raw = default;
            }

            public SockaddrDatalink(byte Len = default, byte Family = default, ushort Index = default, byte Type = default, byte Nlen = default, byte Alen = default, byte Slen = default, array<sbyte> Data = default, RawSockaddrDatalink raw = default)
            {
                this.Len = Len;
                this.Family = Family;
                this.Index = Index;
                this.Type = Type;
                this.Nlen = Nlen;
                this.Alen = Alen;
                this.Slen = Slen;
                this.Data = Data;
                this.raw = raw;
            }

            // Enable comparisons between nil and SockaddrDatalink struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(SockaddrDatalink value, NilType nil) => value.Equals(default(SockaddrDatalink));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(SockaddrDatalink value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, SockaddrDatalink value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, SockaddrDatalink value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator SockaddrDatalink(NilType nil) => default(SockaddrDatalink);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static SockaddrDatalink SockaddrDatalink_cast(dynamic value)
        {
            return new SockaddrDatalink(value.Len, value.Family, value.Index, value.Type, value.Nlen, value.Alen, value.Slen, value.Data, value.raw);
        }
    }
}}}}}}