//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:29:39 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using io = go.io_package;
using big = go.math.big_package;
using sync = go.sync_package;
using go;

namespace go {
namespace crypto
{
    public static partial class elliptic_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct CurveParams
        {
            // Constructors
            public CurveParams(NilType _)
            {
                this.P = default;
                this.N = default;
                this.B = default;
                this.Gx = default;
                this.Gy = default;
                this.BitSize = default;
                this.Name = default;
            }

            public CurveParams(ref ptr<big.Int> P = default, ref ptr<big.Int> N = default, ref ptr<big.Int> B = default, ref ptr<big.Int> Gx = default, ref ptr<big.Int> Gy = default, long BitSize = default, @string Name = default)
            {
                this.P = P;
                this.N = N;
                this.B = B;
                this.Gx = Gx;
                this.Gy = Gy;
                this.BitSize = BitSize;
                this.Name = Name;
            }

            // Enable comparisons between nil and CurveParams struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(CurveParams value, NilType nil) => value.Equals(default(CurveParams));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(CurveParams value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, CurveParams value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, CurveParams value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator CurveParams(NilType nil) => default(CurveParams);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static CurveParams CurveParams_cast(dynamic value)
        {
            return new CurveParams(ref value.P, ref value.N, ref value.B, ref value.Gx, ref value.Gy, value.BitSize, value.Name);
        }
    }
}}