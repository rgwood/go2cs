//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:07:58 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace vendor {
namespace golang.org {
namespace x {
namespace text {
namespace unicode
{
    public static partial class bidi_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct bracketPairs
        {
            // Value of the bracketPairs struct
            private readonly slice<bracketPair> m_value;

            public bracketPairs(slice<bracketPair> value) => m_value = value;

            // Enable implicit conversions between slice<bracketPair> and bracketPairs struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator bracketPairs(slice<bracketPair> value) => new bracketPairs(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator slice<bracketPair>(bracketPairs value) => value.m_value;
            
            // Enable comparisons between nil and bracketPairs struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(bracketPairs value, NilType nil) => value.Equals(default(bracketPairs));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(bracketPairs value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, bracketPairs value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, bracketPairs value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator bracketPairs(NilType nil) => default(bracketPairs);
        }
    }
}}}}}}