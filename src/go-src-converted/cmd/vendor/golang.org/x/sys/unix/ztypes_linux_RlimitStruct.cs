//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:33 UTC
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
        public partial struct Rlimit
        {
            // Constructors
            public Rlimit(NilType _)
            {
                this.Cur = default;
                this.Max = default;
            }

            public Rlimit(ulong Cur = default, ulong Max = default)
            {
                this.Cur = Cur;
                this.Max = Max;
            }

            // Enable comparisons between nil and Rlimit struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Rlimit value, NilType nil) => value.Equals(default(Rlimit));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Rlimit value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Rlimit value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Rlimit value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Rlimit(NilType nil) => default(Rlimit);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Rlimit Rlimit_cast(dynamic value)
        {
            return new Rlimit(value.Cur, value.Max);
        }
    }
}}}}}}