//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:27 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

using go;

#nullable enable

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace sys
{
    public static partial class unix_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct FdSet
        {
            // Constructors
            public FdSet(NilType _)
            {
                this.Bits = default;
            }

            public FdSet(array<long> Bits = default)
            {
                this.Bits = Bits;
            }

            // Enable comparisons between nil and FdSet struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(FdSet value, NilType nil) => value.Equals(default(FdSet));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(FdSet value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, FdSet value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, FdSet value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator FdSet(NilType nil) => default(FdSet);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static FdSet FdSet_cast(dynamic value)
        {
            return new FdSet(value.Bits);
        }
    }
}}}}}}