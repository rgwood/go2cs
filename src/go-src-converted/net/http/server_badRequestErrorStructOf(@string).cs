//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:58:02 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace net
{
    public static partial class http_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct badRequestError
        {
            // Value of the badRequestError struct
            private readonly @string m_value;

            public badRequestError(@string value) => m_value = value;

            // Enable implicit conversions between @string and badRequestError struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator badRequestError(@string value) => new badRequestError(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator @string(badRequestError value) => value.m_value;
            
            // Enable comparisons between nil and badRequestError struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(badRequestError value, NilType nil) => value.Equals(default(badRequestError));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(badRequestError value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, badRequestError value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, badRequestError value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator badRequestError(NilType nil) => default(badRequestError);
        }
    }
}}
