//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:49:17 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace @internal
{
    public static partial class reflectlite_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct typeOff
        {
            // Value of the typeOff struct
            private readonly int m_value;

            public typeOff(int value) => m_value = value;

            // Enable implicit conversions between int and typeOff struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator typeOff(int value) => new typeOff(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator int(typeOff value) => value.m_value;
            
            // Enable comparisons between nil and typeOff struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(typeOff value, NilType nil) => value.Equals(default(typeOff));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(typeOff value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, typeOff value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, typeOff value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator typeOff(NilType nil) => default(typeOff);
        }
    }
}}
