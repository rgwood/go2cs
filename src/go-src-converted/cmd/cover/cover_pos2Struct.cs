//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:44:21 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using flag = go.flag_package;
using fmt = go.fmt_package;
using ast = go.go.ast_package;
using parser = go.go.parser_package;
using token = go.go.token_package;
using io = go.io_package;
using ioutil = go.io.ioutil_package;
using log = go.log_package;
using os = go.os_package;
using sort = go.sort_package;
using edit = go.cmd.@internal.edit_package;
using objabi = go.cmd.@internal.objabi_package;

#nullable enable

namespace go
{
    public static partial class main_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct pos2
        {
            // Constructors
            public pos2(NilType _)
            {
                this.p1 = default;
                this.p2 = default;
            }

            public pos2(token.Position p1 = default, token.Position p2 = default)
            {
                this.p1 = p1;
                this.p2 = p2;
            }

            // Enable comparisons between nil and pos2 struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(pos2 value, NilType nil) => value.Equals(default(pos2));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(pos2 value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, pos2 value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, pos2 value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator pos2(NilType nil) => default(pos2);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static pos2 pos2_cast(dynamic value)
        {
            return new pos2(value.p1, value.p2);
        }
    }
}