//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:34 UTC
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
        public partial struct Timex
        {
            // Constructors
            public Timex(NilType _)
            {
                this.Modes = default;
                this.Offset = default;
                this.Freq = default;
                this.Maxerror = default;
                this.Esterror = default;
                this.Status = default;
                this.Constant = default;
                this.Precision = default;
                this.Tolerance = default;
                this.Time = default;
                this.Tick = default;
                this.Ppsfreq = default;
                this.Jitter = default;
                this.Shift = default;
                this.Stabil = default;
                this.Jitcnt = default;
                this.Calcnt = default;
                this.Errcnt = default;
                this.Stbcnt = default;
                this.Tai = default;
                this._ = default;
            }

            public Timex(uint Modes = default, int Offset = default, int Freq = default, int Maxerror = default, int Esterror = default, int Status = default, int Constant = default, int Precision = default, int Tolerance = default, Timeval Time = default, int Tick = default, int Ppsfreq = default, int Jitter = default, int Shift = default, int Stabil = default, int Jitcnt = default, int Calcnt = default, int Errcnt = default, int Stbcnt = default, int Tai = default, array<byte> _ = default)
            {
                this.Modes = Modes;
                this.Offset = Offset;
                this.Freq = Freq;
                this.Maxerror = Maxerror;
                this.Esterror = Esterror;
                this.Status = Status;
                this.Constant = Constant;
                this.Precision = Precision;
                this.Tolerance = Tolerance;
                this.Time = Time;
                this.Tick = Tick;
                this.Ppsfreq = Ppsfreq;
                this.Jitter = Jitter;
                this.Shift = Shift;
                this.Stabil = Stabil;
                this.Jitcnt = Jitcnt;
                this.Calcnt = Calcnt;
                this.Errcnt = Errcnt;
                this.Stbcnt = Stbcnt;
                this.Tai = Tai;
                this._ = _;
            }

            // Enable comparisons between nil and Timex struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Timex value, NilType nil) => value.Equals(default(Timex));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Timex value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Timex value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Timex value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Timex(NilType nil) => default(Timex);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Timex Timex_cast(dynamic value)
        {
            return new Timex(value.Modes, value.Offset, value.Freq, value.Maxerror, value.Esterror, value.Status, value.Constant, value.Precision, value.Tolerance, value.Time, value.Tick, value.Ppsfreq, value.Jitter, value.Shift, value.Stabil, value.Jitcnt, value.Calcnt, value.Errcnt, value.Stbcnt, value.Tai, value._);
        }
    }
}}}}}}