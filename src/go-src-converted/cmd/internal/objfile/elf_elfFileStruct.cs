//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:08:23 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using dwarf = go.debug.dwarf_package;
using elf = go.debug.elf_package;
using binary = go.encoding.binary_package;
using fmt = go.fmt_package;
using io = go.io_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace @internal
{
    public static partial class objfile_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct elfFile
        {
            // Constructors
            public elfFile(NilType _)
            {
                this.elf = default;
            }

            public elfFile(ref ptr<elf.File> elf = default)
            {
                this.elf = elf;
            }

            // Enable comparisons between nil and elfFile struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(elfFile value, NilType nil) => value.Equals(default(elfFile));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(elfFile value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, elfFile value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, elfFile value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator elfFile(NilType nil) => default(elfFile);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static elfFile elfFile_cast(dynamic value)
        {
            return new elfFile(ref value.elf);
        }
    }
}}}