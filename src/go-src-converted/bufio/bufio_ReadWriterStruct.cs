//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:49:57 UTC
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
using io = go.io_package;
using strings = go.strings_package;
using utf8 = go.unicode.utf8_package;

#nullable enable

namespace go
{
    public static partial class bufio_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct ReadWriter
        {
            // Constructors
            public ReadWriter(NilType _)
            {
                this.ptr<Reader> = default;
                this.ptr<Writer> = default;
            }

            public ReadWriter(ref ptr<Reader> ptr<Reader> = default, ref ptr<Writer> ptr<Writer> = default)
            {
                this.ptr<Reader> = ptr<Reader>;
                this.ptr<Writer> = ptr<Writer>;
            }

            // Enable comparisons between nil and ReadWriter struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ReadWriter value, NilType nil) => value.Equals(default(ReadWriter));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ReadWriter value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ReadWriter value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ReadWriter value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ReadWriter(NilType nil) => default(ReadWriter);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static ReadWriter ReadWriter_cast(dynamic value)
        {
            return new ReadWriter(ref value.ptr<Reader>, ref value.ptr<Writer>);
        }
    }
}