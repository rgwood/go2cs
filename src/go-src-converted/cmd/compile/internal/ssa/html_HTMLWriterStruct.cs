//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:24:46 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using src = go.cmd.@internal.src_package;
using fmt = go.fmt_package;
using html = go.html_package;
using io = go.io_package;
using os = go.os_package;
using exec = go.os.exec_package;
using filepath = go.path.filepath_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class ssa_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct HTMLWriter
        {
            // Constructors
            public HTMLWriter(NilType _)
            {
                this.w = default;
                this.Func = default;
                this.path = default;
                this.dot = default;
                this.prevHash = default;
                this.pendingPhases = default;
                this.pendingTitles = default;
            }

            public HTMLWriter(io.WriteCloser w = default, ref ptr<Func> Func = default, @string path = default, ref ptr<dotWriter> dot = default, slice<byte> prevHash = default, slice<@string> pendingPhases = default, slice<@string> pendingTitles = default)
            {
                this.w = w;
                this.Func = Func;
                this.path = path;
                this.dot = dot;
                this.prevHash = prevHash;
                this.pendingPhases = pendingPhases;
                this.pendingTitles = pendingTitles;
            }

            // Enable comparisons between nil and HTMLWriter struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(HTMLWriter value, NilType nil) => value.Equals(default(HTMLWriter));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(HTMLWriter value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, HTMLWriter value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, HTMLWriter value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator HTMLWriter(NilType nil) => default(HTMLWriter);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static HTMLWriter HTMLWriter_cast(dynamic value)
        {
            return new HTMLWriter(value.w, ref value.Func, value.path, ref value.dot, value.prevHash, value.pendingPhases, value.pendingTitles);
        }
    }
}}}}