//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:41 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

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
        public partial struct CryptoStatHash
        {
            // Constructors
            public CryptoStatHash(NilType _)
            {
                this.Type = default;
                this.Hash_cnt = default;
                this.Hash_tlen = default;
                this.Err_cnt = default;
            }

            public CryptoStatHash(array<byte> Type = default, ulong Hash_cnt = default, ulong Hash_tlen = default, ulong Err_cnt = default)
            {
                this.Type = Type;
                this.Hash_cnt = Hash_cnt;
                this.Hash_tlen = Hash_tlen;
                this.Err_cnt = Err_cnt;
            }

            // Enable comparisons between nil and CryptoStatHash struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(CryptoStatHash value, NilType nil) => value.Equals(default(CryptoStatHash));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(CryptoStatHash value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, CryptoStatHash value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, CryptoStatHash value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator CryptoStatHash(NilType nil) => default(CryptoStatHash);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static CryptoStatHash CryptoStatHash_cast(dynamic value)
        {
            return new CryptoStatHash(value.Type, value.Hash_cnt, value.Hash_tlen, value.Err_cnt);
        }
    }
}}}}}}