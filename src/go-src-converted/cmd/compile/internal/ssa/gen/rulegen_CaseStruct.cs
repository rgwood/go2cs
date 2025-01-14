//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:39:50 UTC
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
using flag = go.flag_package;
using fmt = go.fmt_package;
using ast = go.go.ast_package;
using format = go.go.format_package;
using parser = go.go.parser_package;
using printer = go.go.printer_package;
using token = go.go.token_package;
using io = go.io_package;
using ioutil = go.io.ioutil_package;
using log = go.log_package;
using os = go.os_package;
using path = go.path_package;
using regexp = go.regexp_package;
using sort = go.sort_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using astutil = go.golang.org.x.tools.go.ast.astutil_package;

#nullable enable

namespace go
{
    public static partial class main_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        [PromotedStruct(typeof(BodyBase))]
        public partial struct Case
        {
            // BodyBase structure promotion - sourced from value copy
            private readonly ptr<BodyBase> m_BodyBaseRef;

            private ref BodyBase BodyBase_val => ref m_BodyBaseRef.Value;

            public ref slice<Statement> List => ref m_BodyBaseRef.Value.List;

            public ref bool CanFail => ref m_BodyBaseRef.Value.CanFail;

            // Constructors
            public Case(NilType _)
            {
                this.m_BodyBaseRef = new ptr<BodyBase>(new BodyBase(nil));
                this.Expr = default;
            }

            public Case(BodyBase BodyBase = default, ast.Expr Expr = default)
            {
                this.m_BodyBaseRef = new ptr<BodyBase>(BodyBase);
                this.Expr = Expr;
            }

            // Enable comparisons between nil and Case struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Case value, NilType nil) => value.Equals(default(Case));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Case value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Case value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Case value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Case(NilType nil) => default(Case);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Case Case_cast(dynamic value)
        {
            return new Case(value.BodyBase, value.Expr);
        }
    }
}