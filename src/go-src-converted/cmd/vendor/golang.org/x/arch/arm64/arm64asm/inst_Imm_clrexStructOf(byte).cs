//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:54:46 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace arch {
namespace arm64
{
    public static partial class arm64asm_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Imm_clrex
        {
            // Value of the Imm_clrex struct
            private readonly byte m_value;

            public Imm_clrex(byte value) => m_value = value;

            // Enable implicit conversions between byte and Imm_clrex struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Imm_clrex(byte value) => new Imm_clrex(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator byte(Imm_clrex value) => value.m_value;
            
            // Enable comparisons between nil and Imm_clrex struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Imm_clrex value, NilType nil) => value.Equals(default(Imm_clrex));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Imm_clrex value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Imm_clrex value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Imm_clrex value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Imm_clrex(NilType nil) => default(Imm_clrex);
        }
    }
}}}}}}}
