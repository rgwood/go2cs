//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:51:33 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace oldlink {
namespace @internal
{
    public static partial class ld_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct methodsig
        {
            // Value of the methodsig struct
            private readonly @string m_value;

            public methodsig(@string value) => m_value = value;

            // Enable implicit conversions between @string and methodsig struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator methodsig(@string value) => new methodsig(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator @string(methodsig value) => value.m_value;
            
            // Enable comparisons between nil and methodsig struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(methodsig value, NilType nil) => value.Equals(default(methodsig));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(methodsig value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, methodsig value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, methodsig value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator methodsig(NilType nil) => default(methodsig);
        }
    }
}}}}
