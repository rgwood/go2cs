//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:23:25 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using dwarf = go.debug.dwarf_package;
using elf = go.debug.elf_package;
using macho = go.debug.macho_package;
using pe = go.debug.pe_package;
using binary = go.encoding.binary_package;
using errors = go.errors_package;
using flag = go.flag_package;
using fmt = go.fmt_package;
using ast = go.go.ast_package;
using parser = go.go.parser_package;
using token = go.go.token_package;
using xcoff = go.@internal.xcoff_package;
using math = go.math_package;
using os = go.os_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using unicode = go.unicode_package;
using utf8 = go.unicode.utf8_package;

#nullable enable

namespace go
{
    public static partial class main_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct typeConv
        {
            // Constructors
            public typeConv(NilType _)
            {
                this.m = default;
                this.ptrs = default;
                this.ptrKeys = default;
                this.getTypeIDs = default;
                this.@bool = default;
                this.@byte = default;
                this.int8 = default;
                this.int16 = default;
                this.int32 = default;
                this.int64 = default;
                this.uint8 = default;
                this.uint16 = default;
                this.uint32 = default;
                this.uint64 = default;
                this.uintptr = default;
                this.float32 = default;
                this.float64 = default;
                this.complex64 = default;
                this.complex128 = default;
                this.@void = default;
                this.@string = default;
                this.goVoid = default;
                this.goVoidPtr = default;
                this.ptrSize = default;
                this.intSize = default;
            }

            public typeConv(map<@string, ptr<Type>> m = default, map<@string, slice<ptr<Type>>> ptrs = default, slice<dwarf.Type> ptrKeys = default, map<@string, bool> getTypeIDs = default, ast.Expr @bool = default, ast.Expr @byte = default, ast.Expr int8 = default, ast.Expr int16 = default, ast.Expr int32 = default, ast.Expr int64 = default, ast.Expr uint8 = default, ast.Expr uint16 = default, ast.Expr uint32 = default, ast.Expr uint64 = default, ast.Expr uintptr = default, ast.Expr float32 = default, ast.Expr float64 = default, ast.Expr complex64 = default, ast.Expr complex128 = default, ast.Expr @void = default, ast.Expr @string = default, ast.Expr goVoid = default, ast.Expr goVoidPtr = default, long ptrSize = default, long intSize = default)
            {
                this.m = m;
                this.ptrs = ptrs;
                this.ptrKeys = ptrKeys;
                this.getTypeIDs = getTypeIDs;
                this.@bool = @bool;
                this.@byte = @byte;
                this.int8 = int8;
                this.int16 = int16;
                this.int32 = int32;
                this.int64 = int64;
                this.uint8 = uint8;
                this.uint16 = uint16;
                this.uint32 = uint32;
                this.uint64 = uint64;
                this.uintptr = uintptr;
                this.float32 = float32;
                this.float64 = float64;
                this.complex64 = complex64;
                this.complex128 = complex128;
                this.@void = @void;
                this.@string = @string;
                this.goVoid = goVoid;
                this.goVoidPtr = goVoidPtr;
                this.ptrSize = ptrSize;
                this.intSize = intSize;
            }

            // Enable comparisons between nil and typeConv struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(typeConv value, NilType nil) => value.Equals(default(typeConv));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(typeConv value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, typeConv value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, typeConv value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator typeConv(NilType nil) => default(typeConv);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static typeConv typeConv_cast(dynamic value)
        {
            return new typeConv(value.m, value.ptrs, value.ptrKeys, value.getTypeIDs, value.@bool, value.@byte, value.int8, value.int16, value.int32, value.int64, value.uint8, value.uint16, value.uint32, value.uint64, value.uintptr, value.float32, value.float64, value.complex64, value.complex128, value.@void, value.@string, value.goVoid, value.goVoidPtr, value.ptrSize, value.intSize);
        }
    }
}