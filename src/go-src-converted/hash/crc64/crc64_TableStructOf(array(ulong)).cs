//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:50:09 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace hash
{
    public static partial class crc64_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Table
        {
            // Value of the Table struct
            private readonly array<ulong> m_value;

            public Table(array<ulong> value) => m_value = value;

            // Enable implicit conversions between array<ulong> and Table struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Table(array<ulong> value) => new Table(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator array<ulong>(Table value) => value.m_value;
            
            // Enable comparisons between nil and Table struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Table value, NilType nil) => value.Equals(default(Table));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Table value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Table value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Table value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Table(NilType nil) => default(Table);
        }
    }
}}
