//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:09:00 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using dwarf = go.debug.dwarf_package;
using gosym = go.debug.gosym_package;
using fmt = go.fmt_package;
using io = go.io_package;
using os = go.os_package;
using sort = go.sort_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace @internal
{
    public static partial class objfile_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Reloc
        {
            // Constructors
            public Reloc(NilType _)
            {
                this.Addr = default;
                this.Size = default;
                this.Stringer = default;
            }

            public Reloc(ulong Addr = default, ulong Size = default, RelocStringer Stringer = default)
            {
                this.Addr = Addr;
                this.Size = Size;
                this.Stringer = Stringer;
            }

            // Enable comparisons between nil and Reloc struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Reloc value, NilType nil) => value.Equals(default(Reloc));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Reloc value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Reloc value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Reloc value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Reloc(NilType nil) => default(Reloc);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Reloc Reloc_cast(dynamic value)
        {
            return new Reloc(value.Addr, value.Size, value.Stringer);
        }
    }
}}}