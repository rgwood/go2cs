//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:02:46 UTC
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
namespace go {
namespace @internal {
namespace gcimporter
{
    public static partial class test_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct BlankField
        {
            // Constructors
            public BlankField(NilType _)
            {
                this._ = default;
            }

            public BlankField(long _ = default)
            {
                this._ = _;
            }

            // Enable comparisons between nil and BlankField struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(BlankField value, NilType nil) => value.Equals(default(BlankField));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(BlankField value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, BlankField value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, BlankField value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator BlankField(NilType nil) => default(BlankField);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static BlankField BlankField_cast(dynamic value)
        {
            return new BlankField(value._);
        }
    }
}}}}