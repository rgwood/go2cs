//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:58 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using net = go.net_package;
using syscall = go.syscall_package;
using @unsafe = go.@unsafe_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace sys
{
    public static partial class windows_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct FileNotifyInformation
        {
            // Constructors
            public FileNotifyInformation(NilType _)
            {
                this.NextEntryOffset = default;
                this.Action = default;
                this.FileNameLength = default;
                this.FileName = default;
            }

            public FileNotifyInformation(uint NextEntryOffset = default, uint Action = default, uint FileNameLength = default, ushort FileName = default)
            {
                this.NextEntryOffset = NextEntryOffset;
                this.Action = Action;
                this.FileNameLength = FileNameLength;
                this.FileName = FileName;
            }

            // Enable comparisons between nil and FileNotifyInformation struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(FileNotifyInformation value, NilType nil) => value.Equals(default(FileNotifyInformation));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(FileNotifyInformation value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, FileNotifyInformation value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, FileNotifyInformation value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator FileNotifyInformation(NilType nil) => default(FileNotifyInformation);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static FileNotifyInformation FileNotifyInformation_cast(dynamic value)
        {
            return new FileNotifyInformation(value.NextEntryOffset, value.Action, value.FileNameLength, value.FileName);
        }
    }
}}}}}}