//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:51:31 UTC
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
using dwarf = go.cmd.@internal.dwarf_package;
using objabi = go.cmd.@internal.objabi_package;
using sys = go.cmd.@internal.sys_package;
using sym = go.cmd.oldlink.@internal.sym_package;
using fmt = go.fmt_package;
using log = go.log_package;
using sort = go.sort_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace oldlink {
namespace @internal
{
    public static partial class loader_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct oReader
        {
            // Constructors
            public oReader(NilType _)
            {
                this.unit = default;
                this.version = default;
                this.flags = default;
                this.pkgprefix = default;
                this.rcache = default;
            }

            public oReader(ref ptr<sym.CompilationUnit> unit = default, long version = default, uint flags = default, @string pkgprefix = default, slice<Sym> rcache = default)
            {
                this.unit = unit;
                this.version = version;
                this.flags = flags;
                this.pkgprefix = pkgprefix;
                this.rcache = rcache;
            }

            // Enable comparisons between nil and oReader struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(oReader value, NilType nil) => value.Equals(default(oReader));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(oReader value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, oReader value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, oReader value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator oReader(NilType nil) => default(oReader);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static oReader oReader_cast(dynamic value)
        {
            return new oReader(ref value.unit, value.version, value.flags, value.pkgprefix, value.rcache);
        }
    }
}}}}