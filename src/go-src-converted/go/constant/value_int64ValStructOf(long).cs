//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:19:02 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace go
{
    public static partial class constant_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct int64Val
        {
            // Value of the int64Val struct
            private readonly long m_value;

            public int64Val(long value) => m_value = value;

            // Enable implicit conversions between long and int64Val struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator int64Val(long value) => new int64Val(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator long(int64Val value) => value.m_value;
            
            // Enable comparisons between nil and int64Val struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(int64Val value, NilType nil) => value.Equals(default(int64Val));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(int64Val value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, int64Val value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, int64Val value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator int64Val(NilType nil) => default(int64Val);
        }
    }
}}
