//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:53:03 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using js = go.syscall.js_package;
using go;

#nullable enable

namespace go {
namespace crypto
{
    public static partial class rand_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct reader
        {
            // Constructors
            public reader(NilType _)
            {
            }
            // Enable comparisons between nil and reader struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(reader value, NilType nil) => value.Equals(default(reader));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(reader value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, reader value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, reader value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator reader(NilType nil) => default(reader);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static reader reader_cast(dynamic value)
        {
            return new reader();
        }
    }
}}