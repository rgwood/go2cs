//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:45:48 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using @unsafe = go.@unsafe_package;

#nullable enable

namespace go
{
    public static partial class runtime_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct regs32
        {
            // Constructors
            public regs32(NilType _)
            {
                this.eax = default;
                this.ebx = default;
                this.ecx = default;
                this.edx = default;
                this.edi = default;
                this.esi = default;
                this.ebp = default;
                this.esp = default;
                this.ss = default;
                this.eflags = default;
                this.eip = default;
                this.cs = default;
                this.ds = default;
                this.es = default;
                this.fs = default;
                this.gs = default;
            }

            public regs32(uint eax = default, uint ebx = default, uint ecx = default, uint edx = default, uint edi = default, uint esi = default, uint ebp = default, uint esp = default, uint ss = default, uint eflags = default, uint eip = default, uint cs = default, uint ds = default, uint es = default, uint fs = default, uint gs = default)
            {
                this.eax = eax;
                this.ebx = ebx;
                this.ecx = ecx;
                this.edx = edx;
                this.edi = edi;
                this.esi = esi;
                this.ebp = ebp;
                this.esp = esp;
                this.ss = ss;
                this.eflags = eflags;
                this.eip = eip;
                this.cs = cs;
                this.ds = ds;
                this.es = es;
                this.fs = fs;
                this.gs = gs;
            }

            // Enable comparisons between nil and regs32 struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(regs32 value, NilType nil) => value.Equals(default(regs32));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(regs32 value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, regs32 value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, regs32 value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator regs32(NilType nil) => default(regs32);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static regs32 regs32_cast(dynamic value)
        {
            return new regs32(value.eax, value.ebx, value.ecx, value.edx, value.edi, value.esi, value.ebp, value.esp, value.ss, value.eflags, value.eip, value.cs, value.ds, value.es, value.fs, value.gs);
        }
    }
}