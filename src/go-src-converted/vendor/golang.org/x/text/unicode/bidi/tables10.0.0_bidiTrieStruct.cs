//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:08:05 UTC
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
namespace vendor {
namespace golang.org {
namespace x {
namespace text {
namespace unicode
{
    public static partial class bidi_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct bidiTrie
        {
            // Constructors
            public bidiTrie(NilType _)
            {
            }
            // Enable comparisons between nil and bidiTrie struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(bidiTrie value, NilType nil) => value.Equals(default(bidiTrie));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(bidiTrie value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, bidiTrie value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, bidiTrie value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator bidiTrie(NilType nil) => default(bidiTrie);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static bidiTrie bidiTrie_cast(dynamic value)
        {
            return new bidiTrie();
        }
    }
}}}}}}