//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:41 UTC
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
        public partial struct PtraceFpregs
        {
            // Constructors
            public PtraceFpregs(NilType _)
            {
                this.Fpc = default;
                this.Fprs = default;
            }

            public PtraceFpregs(uint Fpc = default, array<double> Fprs = default)
            {
                this.Fpc = Fpc;
                this.Fprs = Fprs;
            }

            // Enable comparisons between nil and PtraceFpregs struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(PtraceFpregs value, NilType nil) => value.Equals(default(PtraceFpregs));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(PtraceFpregs value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, PtraceFpregs value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, PtraceFpregs value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator PtraceFpregs(NilType nil) => default(PtraceFpregs);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static PtraceFpregs PtraceFpregs_cast(dynamic value)
        {
            return new PtraceFpregs(value.Fpc, value.Fprs);
        }
    }
}}}}}}