//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:47 UTC
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
        public partial struct IfData
        {
            // Constructors
            public IfData(NilType _)
            {
                this.Type = default;
                this.Addrlen = default;
                this.Hdrlen = default;
                this.Link_state = default;
                this.Mtu = default;
                this.Metric = default;
                this.Rdomain = default;
                this.Baudrate = default;
                this.Ipackets = default;
                this.Ierrors = default;
                this.Opackets = default;
                this.Oerrors = default;
                this.Collisions = default;
                this.Ibytes = default;
                this.Obytes = default;
                this.Imcasts = default;
                this.Omcasts = default;
                this.Iqdrops = default;
                this.Oqdrops = default;
                this.Noproto = default;
                this.Capabilities = default;
                this.Lastchange = default;
            }

            public IfData(byte Type = default, byte Addrlen = default, byte Hdrlen = default, byte Link_state = default, uint Mtu = default, uint Metric = default, uint Rdomain = default, ulong Baudrate = default, ulong Ipackets = default, ulong Ierrors = default, ulong Opackets = default, ulong Oerrors = default, ulong Collisions = default, ulong Ibytes = default, ulong Obytes = default, ulong Imcasts = default, ulong Omcasts = default, ulong Iqdrops = default, ulong Oqdrops = default, ulong Noproto = default, uint Capabilities = default, Timeval Lastchange = default)
            {
                this.Type = Type;
                this.Addrlen = Addrlen;
                this.Hdrlen = Hdrlen;
                this.Link_state = Link_state;
                this.Mtu = Mtu;
                this.Metric = Metric;
                this.Rdomain = Rdomain;
                this.Baudrate = Baudrate;
                this.Ipackets = Ipackets;
                this.Ierrors = Ierrors;
                this.Opackets = Opackets;
                this.Oerrors = Oerrors;
                this.Collisions = Collisions;
                this.Ibytes = Ibytes;
                this.Obytes = Obytes;
                this.Imcasts = Imcasts;
                this.Omcasts = Omcasts;
                this.Iqdrops = Iqdrops;
                this.Oqdrops = Oqdrops;
                this.Noproto = Noproto;
                this.Capabilities = Capabilities;
                this.Lastchange = Lastchange;
            }

            // Enable comparisons between nil and IfData struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(IfData value, NilType nil) => value.Equals(default(IfData));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(IfData value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, IfData value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, IfData value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator IfData(NilType nil) => default(IfData);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static IfData IfData_cast(dynamic value)
        {
            return new IfData(value.Type, value.Addrlen, value.Hdrlen, value.Link_state, value.Mtu, value.Metric, value.Rdomain, value.Baudrate, value.Ipackets, value.Ierrors, value.Opackets, value.Oerrors, value.Collisions, value.Ibytes, value.Obytes, value.Imcasts, value.Omcasts, value.Iqdrops, value.Oqdrops, value.Noproto, value.Capabilities, value.Lastchange);
        }
    }
}}}}}}