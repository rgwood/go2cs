//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:04:30 UTC
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
        public partial struct Msghdr
        {
            // Constructors
            public Msghdr(NilType _)
            {
                this.Name = default;
                this.Namelen = default;
                this.Pad_cgo_0 = default;
                this.Iov = default;
                this.Iovlen = default;
                this.Control = default;
                this.Controllen = default;
                this.Flags = default;
                this.Pad_cgo_1 = default;
            }

            public Msghdr(ref ptr<byte> Name = default, uint Namelen = default, array<byte> Pad_cgo_0 = default, ref ptr<Iovec> Iov = default, ulong Iovlen = default, ref ptr<byte> Control = default, ulong Controllen = default, int Flags = default, array<byte> Pad_cgo_1 = default)
            {
                this.Name = Name;
                this.Namelen = Namelen;
                this.Pad_cgo_0 = Pad_cgo_0;
                this.Iov = Iov;
                this.Iovlen = Iovlen;
                this.Control = Control;
                this.Controllen = Controllen;
                this.Flags = Flags;
                this.Pad_cgo_1 = Pad_cgo_1;
            }

            // Enable comparisons between nil and Msghdr struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Msghdr value, NilType nil) => value.Equals(default(Msghdr));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Msghdr value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Msghdr value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Msghdr value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Msghdr(NilType nil) => default(Msghdr);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Msghdr Msghdr_cast(dynamic value)
        {
            return new Msghdr(ref value.Name, value.Namelen, value.Pad_cgo_0, ref value.Iov, value.Iovlen, ref value.Control, value.Controllen, value.Flags, value.Pad_cgo_1);
        }
    }
}