//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:08:01 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace archive
{
    public static partial class tar_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct headerSTAR
        {
            // Value of the headerSTAR struct
            private readonly array<byte> m_value;

            public headerSTAR(array<byte> value) => m_value = value;

            // Enable implicit conversions between array<byte> and headerSTAR struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator headerSTAR(array<byte> value) => new headerSTAR(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator array<byte>(headerSTAR value) => value.m_value;
            
            // Enable comparisons between nil and headerSTAR struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(headerSTAR value, NilType nil) => value.Equals(default(headerSTAR));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(headerSTAR value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, headerSTAR value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, headerSTAR value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator headerSTAR(NilType nil) => default(headerSTAR);
        }
    }
}}
