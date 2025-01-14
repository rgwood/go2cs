//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:06:22 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using io = go.io_package;
using sync = go.sync_package;

#nullable enable

namespace go
{
    public static partial class strings_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct byteStringReplacer
        {
            // Constructors
            public byteStringReplacer(NilType _)
            {
                this.replacements = default;
                this.toReplace = default;
            }

            public byteStringReplacer(array<slice<byte>> replacements = default, slice<@string> toReplace = default)
            {
                this.replacements = replacements;
                this.toReplace = toReplace;
            }

            // Enable comparisons between nil and byteStringReplacer struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(byteStringReplacer value, NilType nil) => value.Equals(default(byteStringReplacer));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(byteStringReplacer value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, byteStringReplacer value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, byteStringReplacer value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator byteStringReplacer(NilType nil) => default(byteStringReplacer);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static byteStringReplacer byteStringReplacer_cast(dynamic value)
        {
            return new byteStringReplacer(value.replacements, value.toReplace);
        }
    }
}