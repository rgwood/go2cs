//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:46:21 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bufio = go.bufio_package;
using bytes = go.bytes_package;
using fmt = go.fmt_package;
using io = go.io_package;
using ioutil = go.io.ioutil_package;
using log = go.log_package;
using os = go.os_package;
using filepath = go.path.filepath_package;
using runtime = go.runtime_package;
using strings = go.strings_package;
using @base = go.cmd.go.@internal.@base_package;
using cfg = go.cmd.go.@internal.cfg_package;
using load = go.cmd.go.@internal.load_package;
using str = go.cmd.go.@internal.str_package;
using objabi = go.cmd.@internal.objabi_package;
using sys = go.cmd.@internal.sys_package;
using sha1 = go.crypto.sha1_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace go {
namespace @internal
{
    public static partial class work_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct gcToolchain
        {
            // Constructors
            public gcToolchain(NilType _)
            {
            }
            // Enable comparisons between nil and gcToolchain struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(gcToolchain value, NilType nil) => value.Equals(default(gcToolchain));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(gcToolchain value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, gcToolchain value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, gcToolchain value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator gcToolchain(NilType nil) => default(gcToolchain);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static gcToolchain gcToolchain_cast(dynamic value)
        {
            return new gcToolchain();
        }
    }
}}}}