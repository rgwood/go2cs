//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:52:07 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using bio = go.cmd.@internal.bio_package;
using objabi = go.cmd.@internal.objabi_package;
using sys = go.cmd.@internal.sys_package;
using loader = go.cmd.oldlink.@internal.loader_package;
using sym = go.cmd.oldlink.@internal.sym_package;
using binary = go.encoding.binary_package;
using fmt = go.fmt_package;
using io = go.io_package;
using sort = go.sort_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace oldlink {
namespace @internal
{
    public static partial class loadmacho_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct ldMachoObj
        {
            // Constructors
            public ldMachoObj(NilType _)
            {
                this.f = default;
                this.@base = default;
                this.length = default;
                this.is64 = default;
                this.name = default;
                this.e = default;
                this.cputype = default;
                this.subcputype = default;
                this.filetype = default;
                this.flags = default;
                this.cmd = default;
                this.ncmd = default;
            }

            public ldMachoObj(ref ptr<bio.Reader> f = default, long @base = default, long length = default, bool is64 = default, @string name = default, binary.ByteOrder e = default, ulong cputype = default, ulong subcputype = default, uint filetype = default, uint flags = default, slice<ldMachoCmd> cmd = default, ulong ncmd = default)
            {
                this.f = f;
                this.@base = @base;
                this.length = length;
                this.is64 = is64;
                this.name = name;
                this.e = e;
                this.cputype = cputype;
                this.subcputype = subcputype;
                this.filetype = filetype;
                this.flags = flags;
                this.cmd = cmd;
                this.ncmd = ncmd;
            }

            // Enable comparisons between nil and ldMachoObj struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ldMachoObj value, NilType nil) => value.Equals(default(ldMachoObj));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ldMachoObj value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ldMachoObj value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ldMachoObj value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ldMachoObj(NilType nil) => default(ldMachoObj);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static ldMachoObj ldMachoObj_cast(dynamic value)
        {
            return new ldMachoObj(ref value.f, value.@base, value.length, value.is64, value.name, value.e, value.cputype, value.subcputype, value.filetype, value.flags, value.cmd, value.ncmd);
        }
    }
}}}}