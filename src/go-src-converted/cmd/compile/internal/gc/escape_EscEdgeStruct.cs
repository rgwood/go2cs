//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:41:22 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using logopt = go.cmd.compile.@internal.logopt_package;
using types = go.cmd.compile.@internal.types_package;
using src = go.cmd.@internal.src_package;
using fmt = go.fmt_package;
using math = go.math_package;
using strings = go.strings_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class gc_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct EscEdge
        {
            // Constructors
            public EscEdge(NilType _)
            {
                this.src = default;
                this.derefs = default;
                this.notes = default;
            }

            public EscEdge(ref ptr<EscLocation> src = default, long derefs = default, ref ptr<EscNote> notes = default)
            {
                this.src = src;
                this.derefs = derefs;
                this.notes = notes;
            }

            // Enable comparisons between nil and EscEdge struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(EscEdge value, NilType nil) => value.Equals(default(EscEdge));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(EscEdge value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, EscEdge value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, EscEdge value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator EscEdge(NilType nil) => default(EscEdge);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static EscEdge EscEdge_cast(dynamic value)
        {
            return new EscEdge(ref value.src, value.derefs, ref value.notes);
        }
    }
}}}}