//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:00:24 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace net {
namespace @internal
{
    public static partial class socktest_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct stats
        {
            // Value of the stats struct
            private readonly map<Cookie, ptr<Stat>> m_value;

            public stats(map<Cookie, ptr<Stat>> value) => m_value = value;

            // Enable implicit conversions between map<Cookie, ptr<Stat>> and stats struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator stats(map<Cookie, ptr<Stat>> value) => new stats(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator map<Cookie, ptr<Stat>>(stats value) => value.m_value;
            
            // Enable comparisons between nil and stats struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(stats value, NilType nil) => value.Equals(default(stats));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(stats value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, stats value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, stats value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator stats(NilType nil) => default(stats);
        }
    }
}}}