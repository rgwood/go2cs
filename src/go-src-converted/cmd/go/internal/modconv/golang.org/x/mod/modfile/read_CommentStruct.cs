//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:46:43 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using errors = go.errors_package;
using fmt = go.fmt_package;
using os = go.os_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using unicode = go.unicode_package;
using utf8 = go.unicode.utf8_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace mod
{
    public static partial class modfile_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Comment
        {
            // Constructors
            public Comment(NilType _)
            {
                this.Start = default;
                this.Token = default;
                this.Suffix = default;
            }

            public Comment(Position Start = default, @string Token = default, bool Suffix = default)
            {
                this.Start = Start;
                this.Token = Token;
                this.Suffix = Suffix;
            }

            // Enable comparisons between nil and Comment struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Comment value, NilType nil) => value.Equals(default(Comment));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Comment value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Comment value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Comment value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Comment(NilType nil) => default(Comment);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Comment Comment_cast(dynamic value)
        {
            return new Comment(value.Start, value.Token, value.Suffix);
        }
    }
}}}}