//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:00:24 UTC
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

#nullable enable

namespace go {
namespace net {
namespace @internal
{
    public static partial class socktest_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Status
        {
            // Constructors
            public Status(NilType _)
            {
                this.Cookie = default;
                this.Err = default;
                this.SocketErr = default;
            }

            public Status(Cookie Cookie = default, error Err = default, error SocketErr = default)
            {
                this.Cookie = Cookie;
                this.Err = Err;
                this.SocketErr = SocketErr;
            }

            // Enable comparisons between nil and Status struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Status value, NilType nil) => value.Equals(default(Status));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Status value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Status value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Status value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Status(NilType nil) => default(Status);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Status Status_cast(dynamic value)
        {
            return new Status(value.Cookie, value.Err, value.SocketErr);
        }
    }
}}}