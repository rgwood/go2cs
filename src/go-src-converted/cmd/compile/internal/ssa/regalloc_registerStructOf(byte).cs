//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:25:44 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class ssa_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct register
        {
            // Value of the register struct
            private readonly byte m_value;

            public register(byte value) => m_value = value;

            // Enable implicit conversions between byte and register struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator register(byte value) => new register(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator byte(register value) => value.m_value;
            
            // Enable comparisons between nil and register struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(register value, NilType nil) => value.Equals(default(register));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(register value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, register value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, register value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator register(NilType nil) => default(register);
        }
    }
}}}}
