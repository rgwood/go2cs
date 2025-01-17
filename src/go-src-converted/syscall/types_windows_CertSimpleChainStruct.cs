//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:02:04 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;


#nullable enable

namespace go
{
    public static partial class syscall_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct CertSimpleChain
        {
            // Constructors
            public CertSimpleChain(NilType _)
            {
                this.Size = default;
                this.TrustStatus = default;
                this.NumElements = default;
                this.Elements = default;
                this.TrustListInfo = default;
                this.HasRevocationFreshnessTime = default;
                this.RevocationFreshnessTime = default;
            }

            public CertSimpleChain(uint Size = default, CertTrustStatus TrustStatus = default, uint NumElements = default, ref ptr<ptr<CertChainElement>> Elements = default, ref ptr<CertTrustListInfo> TrustListInfo = default, uint HasRevocationFreshnessTime = default, uint RevocationFreshnessTime = default)
            {
                this.Size = Size;
                this.TrustStatus = TrustStatus;
                this.NumElements = NumElements;
                this.Elements = Elements;
                this.TrustListInfo = TrustListInfo;
                this.HasRevocationFreshnessTime = HasRevocationFreshnessTime;
                this.RevocationFreshnessTime = RevocationFreshnessTime;
            }

            // Enable comparisons between nil and CertSimpleChain struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(CertSimpleChain value, NilType nil) => value.Equals(default(CertSimpleChain));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(CertSimpleChain value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, CertSimpleChain value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, CertSimpleChain value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator CertSimpleChain(NilType nil) => default(CertSimpleChain);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static CertSimpleChain CertSimpleChain_cast(dynamic value)
        {
            return new CertSimpleChain(value.Size, value.TrustStatus, value.NumElements, ref value.Elements, ref value.TrustListInfo, value.HasRevocationFreshnessTime, value.RevocationFreshnessTime);
        }
    }
}