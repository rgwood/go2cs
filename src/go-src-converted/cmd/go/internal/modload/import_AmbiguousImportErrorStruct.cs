//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:46:36 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using errors = go.errors_package;
using fmt = go.fmt_package;
using build = go.go.build_package;
using goroot = go.@internal.goroot_package;
using os = go.os_package;
using filepath = go.path.filepath_package;
using sort = go.sort_package;
using strings = go.strings_package;
using time = go.time_package;
using cfg = go.cmd.go.@internal.cfg_package;
using load = go.cmd.go.@internal.load_package;
using modfetch = go.cmd.go.@internal.modfetch_package;
using par = go.cmd.go.@internal.par_package;
using search = go.cmd.go.@internal.search_package;
using module = go.golang.org.x.mod.module_package;
using semver = go.golang.org.x.mod.semver_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace go {
namespace @internal
{
    public static partial class modload_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct AmbiguousImportError
        {
            // Constructors
            public AmbiguousImportError(NilType _)
            {
                this.importPath = default;
                this.Dirs = default;
                this.Modules = default;
            }

            public AmbiguousImportError(@string importPath = default, slice<@string> Dirs = default, slice<module.Version> Modules = default)
            {
                this.importPath = importPath;
                this.Dirs = Dirs;
                this.Modules = Modules;
            }

            // Enable comparisons between nil and AmbiguousImportError struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(AmbiguousImportError value, NilType nil) => value.Equals(default(AmbiguousImportError));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(AmbiguousImportError value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, AmbiguousImportError value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, AmbiguousImportError value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator AmbiguousImportError(NilType nil) => default(AmbiguousImportError);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static AmbiguousImportError AmbiguousImportError_cast(dynamic value)
        {
            return new AmbiguousImportError(value.importPath, value.Dirs, value.Modules);
        }
    }
}}}}