//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:52:57 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace @internal
{
    public static partial class trace_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct UtilFlags
        {
            // Value of the UtilFlags struct
            private readonly long m_value;

            public UtilFlags(long value) => m_value = value;

            // Enable implicit conversions between long and UtilFlags struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator UtilFlags(long value) => new UtilFlags(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator long(UtilFlags value) => value.m_value;
            
            // Enable comparisons between nil and UtilFlags struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(UtilFlags value, NilType nil) => value.Equals(default(UtilFlags));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(UtilFlags value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, UtilFlags value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, UtilFlags value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator UtilFlags(NilType nil) => default(UtilFlags);
        }
    }
}}