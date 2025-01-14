//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:45:53 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;


#nullable enable

namespace go
{
    public static partial class runtime_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct ureg
        {
            // Constructors
            public ureg(NilType _)
            {
                this.r0 = default;
                this.r1 = default;
                this.r2 = default;
                this.r3 = default;
                this.r4 = default;
                this.r5 = default;
                this.r6 = default;
                this.r7 = default;
                this.r8 = default;
                this.r9 = default;
                this.r10 = default;
                this.r11 = default;
                this.r12 = default;
                this.sp = default;
                this.link = default;
                this.trap = default;
                this.psr = default;
                this.pc = default;
            }

            public ureg(uint r0 = default, uint r1 = default, uint r2 = default, uint r3 = default, uint r4 = default, uint r5 = default, uint r6 = default, uint r7 = default, uint r8 = default, uint r9 = default, uint r10 = default, uint r11 = default, uint r12 = default, uint sp = default, uint link = default, uint trap = default, uint psr = default, uint pc = default)
            {
                this.r0 = r0;
                this.r1 = r1;
                this.r2 = r2;
                this.r3 = r3;
                this.r4 = r4;
                this.r5 = r5;
                this.r6 = r6;
                this.r7 = r7;
                this.r8 = r8;
                this.r9 = r9;
                this.r10 = r10;
                this.r11 = r11;
                this.r12 = r12;
                this.sp = sp;
                this.link = link;
                this.trap = trap;
                this.psr = psr;
                this.pc = pc;
            }

            // Enable comparisons between nil and ureg struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ureg value, NilType nil) => value.Equals(default(ureg));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ureg value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ureg value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ureg value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ureg(NilType nil) => default(ureg);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static ureg ureg_cast(dynamic value)
        {
            return new ureg(value.r0, value.r1, value.r2, value.r3, value.r4, value.r5, value.r6, value.r7, value.r8, value.r9, value.r10, value.r11, value.r12, value.sp, value.link, value.trap, value.psr, value.pc);
        }
    }
}