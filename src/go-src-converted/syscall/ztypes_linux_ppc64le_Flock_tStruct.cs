//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:04:31 UTC
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
        public partial struct Flock_t
        {
            // Constructors
            public Flock_t(NilType _)
            {
                this.Type = default;
                this.Whence = default;
                this.Pad_cgo_0 = default;
                this.Start = default;
                this.Len = default;
                this.Pid = default;
                this.Pad_cgo_1 = default;
            }

            public Flock_t(short Type = default, short Whence = default, array<byte> Pad_cgo_0 = default, long Start = default, long Len = default, int Pid = default, array<byte> Pad_cgo_1 = default)
            {
                this.Type = Type;
                this.Whence = Whence;
                this.Pad_cgo_0 = Pad_cgo_0;
                this.Start = Start;
                this.Len = Len;
                this.Pid = Pid;
                this.Pad_cgo_1 = Pad_cgo_1;
            }

            // Enable comparisons between nil and Flock_t struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Flock_t value, NilType nil) => value.Equals(default(Flock_t));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Flock_t value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Flock_t value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Flock_t value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Flock_t(NilType nil) => default(Flock_t);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Flock_t Flock_t_cast(dynamic value)
        {
            return new Flock_t(value.Type, value.Whence, value.Pad_cgo_0, value.Start, value.Len, value.Pid, value.Pad_cgo_1);
        }
    }
}