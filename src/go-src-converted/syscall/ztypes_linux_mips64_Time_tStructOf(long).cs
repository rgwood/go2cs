//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:04:28 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

#nullable enable

namespace go
{
    public static partial class syscall_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Time_t
        {
            // Value of the Time_t struct
            private readonly long m_value;

            public Time_t(long value) => m_value = value;

            // Enable implicit conversions between long and Time_t struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Time_t(long value) => new Time_t(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator long(Time_t value) => value.m_value;
            
            // Enable comparisons between nil and Time_t struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Time_t value, NilType nil) => value.Equals(default(Time_t));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Time_t value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Time_t value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Time_t value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Time_t(NilType nil) => default(Time_t);
        }
    }
}
