//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:08:23 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using fmt = go.fmt_package;
using utf8 = go.unicode.utf8_package;
using go;

#nullable enable

namespace go {
namespace vendor {
namespace golang.org {
namespace x {
namespace text {
namespace unicode
{
    public static partial class norm_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Iter
        {
            // Constructors
            public Iter(NilType _)
            {
                this.rb = default;
                this.buf = default;
                this.info = default;
                this.next = default;
                this.asciiF = default;
                this.p = default;
                this.multiSeg = default;
            }

            public Iter(reorderBuffer rb = default, array<byte> buf = default, Properties info = default, iterFunc next = default, iterFunc asciiF = default, long p = default, slice<byte> multiSeg = default)
            {
                this.rb = rb;
                this.buf = buf;
                this.info = info;
                this.next = next;
                this.asciiF = asciiF;
                this.p = p;
                this.multiSeg = multiSeg;
            }

            // Enable comparisons between nil and Iter struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Iter value, NilType nil) => value.Equals(default(Iter));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Iter value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Iter value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Iter value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Iter(NilType nil) => default(Iter);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Iter Iter_cast(dynamic value)
        {
            return new Iter(value.rb, value.buf, value.info, value.next, value.asciiF, value.p, value.multiSeg);
        }
    }
}}}}}}