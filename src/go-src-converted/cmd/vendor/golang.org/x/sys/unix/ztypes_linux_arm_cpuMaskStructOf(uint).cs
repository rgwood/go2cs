//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:00:36 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
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
        private partial struct cpuMask
        {
            // Value of the cpuMask struct
            private readonly uint m_value;

            public cpuMask(uint value) => m_value = value;

            // Enable implicit conversions between uint and cpuMask struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator cpuMask(uint value) => new cpuMask(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator uint(cpuMask value) => value.m_value;
            
            // Enable comparisons between nil and cpuMask struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(cpuMask value, NilType nil) => value.Equals(default(cpuMask));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(cpuMask value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, cpuMask value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, cpuMask value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator cpuMask(NilType nil) => default(cpuMask);
        }
    }
}}}}}}
