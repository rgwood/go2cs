//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:45 UTC
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
        public partial struct IfAnnounceMsghdr
        {
            // Constructors
            public IfAnnounceMsghdr(NilType _)
            {
                this.Msglen = default;
                this.Version = default;
                this.Type = default;
                this.Index = default;
                this.Name = default;
                this.What = default;
            }

            public IfAnnounceMsghdr(ushort Msglen = default, byte Version = default, byte Type = default, ushort Index = default, array<sbyte> Name = default, ushort What = default)
            {
                this.Msglen = Msglen;
                this.Version = Version;
                this.Type = Type;
                this.Index = Index;
                this.Name = Name;
                this.What = What;
            }

            // Enable comparisons between nil and IfAnnounceMsghdr struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(IfAnnounceMsghdr value, NilType nil) => value.Equals(default(IfAnnounceMsghdr));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(IfAnnounceMsghdr value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, IfAnnounceMsghdr value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, IfAnnounceMsghdr value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator IfAnnounceMsghdr(NilType nil) => default(IfAnnounceMsghdr);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static IfAnnounceMsghdr IfAnnounceMsghdr_cast(dynamic value)
        {
            return new IfAnnounceMsghdr(value.Msglen, value.Version, value.Type, value.Index, value.Name, value.What);
        }
    }
}}}}}}