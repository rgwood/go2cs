//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:02:02 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using errorspkg = go.errors_package;
using oserror = go.@internal.oserror_package;
using race = go.@internal.race_package;
using unsafeheader = go.@internal.unsafeheader_package;
using runtime = go.runtime_package;
using sync = go.sync_package;
using utf16 = go.unicode.utf16_package;
using @unsafe = go.@unsafe_package;

#nullable enable

namespace go
{
    public static partial class syscall_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Linger
        {
            // Constructors
            public Linger(NilType _)
            {
                this.Onoff = default;
                this.Linger = default;
            }

            public Linger(int Onoff = default, int Linger = default)
            {
                this.Onoff = Onoff;
                this.Linger = Linger;
            }

            // Enable comparisons between nil and Linger struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Linger value, NilType nil) => value.Equals(default(Linger));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Linger value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Linger value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Linger value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Linger(NilType nil) => default(Linger);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Linger Linger_cast(dynamic value)
        {
            return new Linger(value.Onoff, value.Linger);
        }
    }
}