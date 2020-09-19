//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:36:18 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using fmt = go.fmt_package;
using sync = go.sync_package;
using go;

namespace go {
namespace net {
namespace @internal
{
    public static partial class socktest_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Stat
        {
            // Constructors
            public Stat(NilType _)
            {
                this.Family = default;
                this.Type = default;
                this.Protocol = default;
                this.Opened = default;
                this.Connected = default;
                this.Listened = default;
                this.Accepted = default;
                this.Closed = default;
                this.OpenFailed = default;
                this.ConnectFailed = default;
                this.ListenFailed = default;
                this.AcceptFailed = default;
                this.CloseFailed = default;
            }

            public Stat(long Family = default, long Type = default, long Protocol = default, ulong Opened = default, ulong Connected = default, ulong Listened = default, ulong Accepted = default, ulong Closed = default, ulong OpenFailed = default, ulong ConnectFailed = default, ulong ListenFailed = default, ulong AcceptFailed = default, ulong CloseFailed = default)
            {
                this.Family = Family;
                this.Type = Type;
                this.Protocol = Protocol;
                this.Opened = Opened;
                this.Connected = Connected;
                this.Listened = Listened;
                this.Accepted = Accepted;
                this.Closed = Closed;
                this.OpenFailed = OpenFailed;
                this.ConnectFailed = ConnectFailed;
                this.ListenFailed = ListenFailed;
                this.AcceptFailed = AcceptFailed;
                this.CloseFailed = CloseFailed;
            }

            // Enable comparisons between nil and Stat struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Stat value, NilType nil) => value.Equals(default(Stat));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Stat value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Stat value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Stat value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Stat(NilType nil) => default(Stat);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Stat Stat_cast(dynamic value)
        {
            return new Stat(value.Family, value.Type, value.Protocol, value.Opened, value.Connected, value.Listened, value.Accepted, value.Closed, value.OpenFailed, value.ConnectFailed, value.ListenFailed, value.AcceptFailed, value.CloseFailed);
        }
    }
}}}