//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:04:29 UTC
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
        public partial struct Statfs_t
        {
            // Constructors
            public Statfs_t(NilType _)
            {
                this.Type = default;
                this.Bsize = default;
                this.Frsize = default;
                this.Blocks = default;
                this.Bfree = default;
                this.Files = default;
                this.Ffree = default;
                this.Bavail = default;
                this.Fsid = default;
                this.Namelen = default;
                this.Flags = default;
                this.Spare = default;
            }

            public Statfs_t(long Type = default, long Bsize = default, long Frsize = default, ulong Blocks = default, ulong Bfree = default, ulong Files = default, ulong Ffree = default, ulong Bavail = default, Fsid Fsid = default, long Namelen = default, long Flags = default, array<long> Spare = default)
            {
                this.Type = Type;
                this.Bsize = Bsize;
                this.Frsize = Frsize;
                this.Blocks = Blocks;
                this.Bfree = Bfree;
                this.Files = Files;
                this.Ffree = Ffree;
                this.Bavail = Bavail;
                this.Fsid = Fsid;
                this.Namelen = Namelen;
                this.Flags = Flags;
                this.Spare = Spare;
            }

            // Enable comparisons between nil and Statfs_t struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Statfs_t value, NilType nil) => value.Equals(default(Statfs_t));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Statfs_t value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Statfs_t value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Statfs_t value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Statfs_t(NilType nil) => default(Statfs_t);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Statfs_t Statfs_t_cast(dynamic value)
        {
            return new Statfs_t(value.Type, value.Bsize, value.Frsize, value.Blocks, value.Bfree, value.Files, value.Ffree, value.Bavail, value.Fsid, value.Namelen, value.Flags, value.Spare);
        }
    }
}