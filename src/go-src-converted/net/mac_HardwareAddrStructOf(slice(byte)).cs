//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:52:04 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

#nullable enable

namespace go
{
    public static partial class net_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct HardwareAddr
        {
            // Value of the HardwareAddr struct
            private readonly slice<byte> m_value;

            public HardwareAddr(slice<byte> value) => m_value = value;

            // Enable implicit conversions between slice<byte> and HardwareAddr struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator HardwareAddr(slice<byte> value) => new HardwareAddr(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator slice<byte>(HardwareAddr value) => value.m_value;
            
            // Enable comparisons between nil and HardwareAddr struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(HardwareAddr value, NilType nil) => value.Equals(default(HardwareAddr));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(HardwareAddr value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, HardwareAddr value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, HardwareAddr value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator HardwareAddr(NilType nil) => default(HardwareAddr);
        }
    }
}
