//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 10:04:58 UTC
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
using rand = go.math.rand_package;
using os = go.os_package;
using exec = go.os.exec_package;
using filepath = go.path.filepath_package;
using runtime = go.runtime_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using _@unsafe_ = go.@unsafe_package;
using go;

namespace go {
namespace @internal
{
    public static partial class trace_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct ParseResult
        {
            // Constructors
            public ParseResult(NilType _)
            {
                this.Events = default;
                this.Stacks = default;
            }

            public ParseResult(slice<ref Event> Events = default, map<ulong, slice<ref Frame>> Stacks = default)
            {
                this.Events = Events;
                this.Stacks = Stacks;
            }

            // Enable comparisons between nil and ParseResult struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ParseResult value, NilType nil) => value.Equals(default(ParseResult));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ParseResult value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ParseResult value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ParseResult value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ParseResult(NilType nil) => default(ParseResult);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static ParseResult ParseResult_cast(dynamic value)
        {
            return new ParseResult(value.Events, value.Stacks);
        }
    }
}}