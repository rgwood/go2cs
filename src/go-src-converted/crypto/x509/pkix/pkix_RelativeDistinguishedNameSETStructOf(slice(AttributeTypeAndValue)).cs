//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:54:52 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace crypto {
namespace x509
{
    public static partial class pkix_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct RelativeDistinguishedNameSET
        {
            // Value of the RelativeDistinguishedNameSET struct
            private readonly slice<AttributeTypeAndValue> m_value;

            public RelativeDistinguishedNameSET(slice<AttributeTypeAndValue> value) => m_value = value;

            // Enable implicit conversions between slice<AttributeTypeAndValue> and RelativeDistinguishedNameSET struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator RelativeDistinguishedNameSET(slice<AttributeTypeAndValue> value) => new RelativeDistinguishedNameSET(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator slice<AttributeTypeAndValue>(RelativeDistinguishedNameSET value) => value.m_value;
            
            // Enable comparisons between nil and RelativeDistinguishedNameSET struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(RelativeDistinguishedNameSET value, NilType nil) => value.Equals(default(RelativeDistinguishedNameSET));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(RelativeDistinguishedNameSET value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, RelativeDistinguishedNameSET value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, RelativeDistinguishedNameSET value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator RelativeDistinguishedNameSET(NilType nil) => default(RelativeDistinguishedNameSET);
        }
    }
}}}
