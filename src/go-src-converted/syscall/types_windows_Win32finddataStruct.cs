//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:02:03 UTC
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
        public partial struct Win32finddata
        {
            // Constructors
            public Win32finddata(NilType _)
            {
                this.FileAttributes = default;
                this.CreationTime = default;
                this.LastAccessTime = default;
                this.LastWriteTime = default;
                this.FileSizeHigh = default;
                this.FileSizeLow = default;
                this.Reserved0 = default;
                this.Reserved1 = default;
                this.FileName = default;
                this.AlternateFileName = default;
            }

            public Win32finddata(uint FileAttributes = default, Filetime CreationTime = default, Filetime LastAccessTime = default, Filetime LastWriteTime = default, uint FileSizeHigh = default, uint FileSizeLow = default, uint Reserved0 = default, uint Reserved1 = default, array<ushort> FileName = default, array<ushort> AlternateFileName = default)
            {
                this.FileAttributes = FileAttributes;
                this.CreationTime = CreationTime;
                this.LastAccessTime = LastAccessTime;
                this.LastWriteTime = LastWriteTime;
                this.FileSizeHigh = FileSizeHigh;
                this.FileSizeLow = FileSizeLow;
                this.Reserved0 = Reserved0;
                this.Reserved1 = Reserved1;
                this.FileName = FileName;
                this.AlternateFileName = AlternateFileName;
            }

            // Enable comparisons between nil and Win32finddata struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Win32finddata value, NilType nil) => value.Equals(default(Win32finddata));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Win32finddata value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Win32finddata value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Win32finddata value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Win32finddata(NilType nil) => default(Win32finddata);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Win32finddata Win32finddata_cast(dynamic value)
        {
            return new Win32finddata(value.FileAttributes, value.CreationTime, value.LastAccessTime, value.LastWriteTime, value.FileSizeHigh, value.FileSizeLow, value.Reserved0, value.Reserved1, value.FileName, value.AlternateFileName);
        }
    }
}