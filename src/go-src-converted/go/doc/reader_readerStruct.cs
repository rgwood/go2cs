//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:19:08 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using ast = go.go.ast_package;
using token = go.go.token_package;
using lazyregexp = go.@internal.lazyregexp_package;
using sort = go.sort_package;
using strconv = go.strconv_package;
using go;

#nullable enable

namespace go {
namespace go
{
    public static partial class doc_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct reader
        {
            // Constructors
            public reader(NilType _)
            {
                this.mode = default;
                this.doc = default;
                this.filenames = default;
                this.notes = default;
                this.imports = default;
                this.hasDotImp = default;
                this.values = default;
                this.order = default;
                this.types = default;
                this.funcs = default;
                this.errorDecl = default;
                this.fixlist = default;
            }

            public reader(Mode mode = default, @string doc = default, slice<@string> filenames = default, map<@string, slice<ptr<Note>>> notes = default, map<@string, long> imports = default, bool hasDotImp = default, slice<ptr<Value>> values = default, long order = default, map<@string, ptr<namedType>> types = default, methodSet funcs = default, bool errorDecl = default, slice<ptr<ast.InterfaceType>> fixlist = default)
            {
                this.mode = mode;
                this.doc = doc;
                this.filenames = filenames;
                this.notes = notes;
                this.imports = imports;
                this.hasDotImp = hasDotImp;
                this.values = values;
                this.order = order;
                this.types = types;
                this.funcs = funcs;
                this.errorDecl = errorDecl;
                this.fixlist = fixlist;
            }

            // Enable comparisons between nil and reader struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(reader value, NilType nil) => value.Equals(default(reader));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(reader value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, reader value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, reader value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator reader(NilType nil) => default(reader);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static reader reader_cast(dynamic value)
        {
            return new reader(value.mode, value.doc, value.filenames, value.notes, value.imports, value.hasDotImp, value.values, value.order, value.types, value.funcs, value.errorDecl, value.fixlist);
        }
    }
}}