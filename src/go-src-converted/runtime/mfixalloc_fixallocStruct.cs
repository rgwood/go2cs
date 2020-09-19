//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:17:53 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using @unsafe = go.@unsafe_package;

namespace go
{
    public static partial class runtime_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct fixalloc
        {
            // Constructors
            public fixalloc(NilType _)
            {
                this.size = default;
                this.first = default;
                this.arg = default;
                this.list = default;
                this.chunk = default;
                this.nchunk = default;
                this.inuse = default;
                this.stat = default;
                this.zero = default;
            }

            public fixalloc(System.UIntPtr size = default, Action<unsafe.Pointer, unsafe.Pointer> first = default, unsafe.Pointer arg = default, ref ptr<mlink> list = default, System.UIntPtr chunk = default, uint nchunk = default, System.UIntPtr inuse = default, ref ptr<ulong> stat = default, bool zero = default)
            {
                this.size = size;
                this.first = first;
                this.arg = arg;
                this.list = list;
                this.chunk = chunk;
                this.nchunk = nchunk;
                this.inuse = inuse;
                this.stat = stat;
                this.zero = zero;
            }

            // Enable comparisons between nil and fixalloc struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(fixalloc value, NilType nil) => value.Equals(default(fixalloc));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(fixalloc value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, fixalloc value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, fixalloc value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator fixalloc(NilType nil) => default(fixalloc);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static fixalloc fixalloc_cast(dynamic value)
        {
            return new fixalloc(value.size, value.first, value.arg, ref value.list, value.chunk, value.nchunk, value.inuse, ref value.stat, value.zero);
        }
    }
}