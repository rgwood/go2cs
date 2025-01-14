//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:00:00 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using encoding = go.encoding_package;
using errors = go.errors_package;
using fmt = go.fmt_package;
using os = go.os_package;
using reflect = go.reflect_package;
using sync = go.sync_package;
using atomic = go.sync.atomic_package;
using unicode = go.unicode_package;
using utf8 = go.unicode.utf8_package;
using go;

#nullable enable

namespace go {
namespace encoding
{
    public static partial class gob_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct userTypeInfo
        {
            // Constructors
            public userTypeInfo(NilType _)
            {
                this.user = default;
                this.@base = default;
                this.indir = default;
                this.externalEnc = default;
                this.externalDec = default;
                this.encIndir = default;
                this.decIndir = default;
            }

            public userTypeInfo(reflect.Type user = default, reflect.Type @base = default, long indir = default, long externalEnc = default, long externalDec = default, sbyte encIndir = default, sbyte decIndir = default)
            {
                this.user = user;
                this.@base = @base;
                this.indir = indir;
                this.externalEnc = externalEnc;
                this.externalDec = externalDec;
                this.encIndir = encIndir;
                this.decIndir = decIndir;
            }

            // Enable comparisons between nil and userTypeInfo struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(userTypeInfo value, NilType nil) => value.Equals(default(userTypeInfo));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(userTypeInfo value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, userTypeInfo value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, userTypeInfo value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator userTypeInfo(NilType nil) => default(userTypeInfo);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static userTypeInfo userTypeInfo_cast(dynamic value)
        {
            return new userTypeInfo(value.user, value.@base, value.indir, value.externalEnc, value.externalDec, value.encIndir, value.decIndir);
        }
    }
}}