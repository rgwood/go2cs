//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:45:47 UTC
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
    public static partial class runtime_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct mcontextt
        {
            // Constructors
            public mcontextt(NilType _)
            {
                this.__gregs = default;
                this._ = default;
                this.__fpu = default;
                this._mc_tlsbase = default;
                this._ = default;
            }

            public mcontextt(array<uint> __gregs = default, array<byte> _ = default, array<byte> __fpu = default, uint _mc_tlsbase = default, array<byte> _ = default)
            {
                this.__gregs = __gregs;
                this._ = _;
                this.__fpu = __fpu;
                this._mc_tlsbase = _mc_tlsbase;
                this._ = _;
            }

            // Enable comparisons between nil and mcontextt struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(mcontextt value, NilType nil) => value.Equals(default(mcontextt));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(mcontextt value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, mcontextt value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, mcontextt value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator mcontextt(NilType nil) => default(mcontextt);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static mcontextt mcontextt_cast(dynamic value)
        {
            return new mcontextt(value.__gregs, value._, value.__fpu, value._mc_tlsbase, value._);
        }
    }
}