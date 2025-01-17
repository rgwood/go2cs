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
        public partial struct Stat_t
        {
            // Constructors
            public Stat_t(NilType _)
            {
                this.Dev = default;
                this.Pad1 = default;
                this.Ino = default;
                this.Mode = default;
                this.Nlink = default;
                this.Uid = default;
                this.Gid = default;
                this.Rdev = default;
                this.Pad2 = default;
                this.Size = default;
                this.Atim = default;
                this.Mtim = default;
                this.Ctim = default;
                this.Blksize = default;
                this.Pad4 = default;
                this.Blocks = default;
            }

            public Stat_t(uint Dev = default, array<int> Pad1 = default, ulong Ino = default, uint Mode = default, uint Nlink = default, uint Uid = default, uint Gid = default, uint Rdev = default, array<uint> Pad2 = default, long Size = default, Timespec Atim = default, Timespec Mtim = default, Timespec Ctim = default, uint Blksize = default, uint Pad4 = default, long Blocks = default)
            {
                this.Dev = Dev;
                this.Pad1 = Pad1;
                this.Ino = Ino;
                this.Mode = Mode;
                this.Nlink = Nlink;
                this.Uid = Uid;
                this.Gid = Gid;
                this.Rdev = Rdev;
                this.Pad2 = Pad2;
                this.Size = Size;
                this.Atim = Atim;
                this.Mtim = Mtim;
                this.Ctim = Ctim;
                this.Blksize = Blksize;
                this.Pad4 = Pad4;
                this.Blocks = Blocks;
            }

            // Enable comparisons between nil and Stat_t struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Stat_t value, NilType nil) => value.Equals(default(Stat_t));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Stat_t value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Stat_t value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Stat_t value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Stat_t(NilType nil) => default(Stat_t);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Stat_t Stat_t_cast(dynamic value)
        {
            return new Stat_t(value.Dev, value.Pad1, value.Ino, value.Mode, value.Nlink, value.Uid, value.Gid, value.Rdev, value.Pad2, value.Size, value.Atim, value.Mtim, value.Ctim, value.Blksize, value.Pad4, value.Blocks);
        }
    }
}