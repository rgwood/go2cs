//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:47:55 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using fmt = go.fmt_package;
using io = go.io_package;
using ioutil = go.io.ioutil_package;
using os = go.os_package;
using filepath = go.path.filepath_package;
using sort = go.sort_package;
using strings = go.strings_package;
using @base = go.cmd.go.@internal.@base_package;
using cfg = go.cmd.go.@internal.cfg_package;
using imports = go.cmd.go.@internal.imports_package;
using modload = go.cmd.go.@internal.modload_package;
using work = go.cmd.go.@internal.work_package;
using module = go.golang.org.x.mod.module_package;
using semver = go.golang.org.x.mod.semver_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace go {
namespace @internal
{
    public static partial class modcmd_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct metakey
        {
            // Constructors
            public metakey(NilType _)
            {
                this.modPath = default;
                this.dst = default;
            }

            public metakey(@string modPath = default, @string dst = default)
            {
                this.modPath = modPath;
                this.dst = dst;
            }

            // Enable comparisons between nil and metakey struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(metakey value, NilType nil) => value.Equals(default(metakey));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(metakey value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, metakey value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, metakey value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator metakey(NilType nil) => default(metakey);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static metakey metakey_cast(dynamic value)
        {
            return new metakey(value.modPath, value.dst);
        }
    }
}}}}