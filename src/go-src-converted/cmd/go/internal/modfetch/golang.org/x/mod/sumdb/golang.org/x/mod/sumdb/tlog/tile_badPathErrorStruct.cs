//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:47:31 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using fmt = go.fmt_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace mod {
namespace sumdb
{
    public static partial class tlog_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct badPathError
        {
            // Constructors
            public badPathError(NilType _)
            {
                this.path = default;
            }

            public badPathError(@string path = default)
            {
                this.path = path;
            }

            // Enable comparisons between nil and badPathError struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(badPathError value, NilType nil) => value.Equals(default(badPathError));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(badPathError value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, badPathError value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, badPathError value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator badPathError(NilType nil) => default(badPathError);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static badPathError badPathError_cast(dynamic value)
        {
            return new badPathError(value.path);
        }
    }
}}}}}