//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:01:20 UTC
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
using format = go.go.format_package;
using token = go.go.token_package;
using types = go.go.types_package;
using ioutil = go.io.ioutil_package;
using log = go.log_package;
using os = go.os_package;
using filepath = go.path.filepath_package;
using regexp = go.regexp_package;
using sort = go.sort_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using scanner = go.text.scanner_package;
using analysis = go.golang.org.x.tools.go.analysis_package;
using checker = go.golang.org.x.tools.go.analysis.@internal.checker_package;
using packages = go.golang.org.x.tools.go.packages_package;
using diff = go.golang.org.x.tools.@internal.lsp.diff_package;
using myers = go.golang.org.x.tools.@internal.lsp.diff.myers_package;
using span = go.golang.org.x.tools.@internal.span_package;
using testenv = go.golang.org.x.tools.@internal.testenv_package;
using txtar = go.golang.org.x.tools.txtar_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace tools {
namespace go {
namespace analysis
{
    public static partial class analysistest_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct key
        {
            // Constructors
            public key(NilType _)
            {
                this.file = default;
                this.line = default;
            }

            public key(@string file = default, long line = default)
            {
                this.file = file;
                this.line = line;
            }

            // Enable comparisons between nil and key struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(key value, NilType nil) => value.Equals(default(key));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(key value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, key value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, key value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator key(NilType nil) => default(key);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static key key_cast(dynamic value)
        {
            return new key(value.file, value.line);
        }
    }
}}}}}}