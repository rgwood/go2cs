//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:41:22 UTC
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
    public static partial class gc_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct EscLeaks
        {
            // Value of the EscLeaks struct
            private readonly array<byte> m_value;

            public EscLeaks(array<byte> value) => m_value = value;

            // Enable implicit conversions between array<byte> and EscLeaks struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator EscLeaks(array<byte> value) => new EscLeaks(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator array<byte>(EscLeaks value) => value.m_value;
            
            // Enable comparisons between nil and EscLeaks struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(EscLeaks value, NilType nil) => value.Equals(default(EscLeaks));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(EscLeaks value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, EscLeaks value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, EscLeaks value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator EscLeaks(NilType nil) => default(EscLeaks);
        }
    }
}}}}
