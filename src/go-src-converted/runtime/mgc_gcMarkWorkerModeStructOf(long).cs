//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:46:41 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

#nullable enable

namespace go
{
    public static partial class runtime_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct gcMarkWorkerMode
        {
            // Value of the gcMarkWorkerMode struct
            private readonly long m_value;

            public gcMarkWorkerMode(long value) => m_value = value;

            // Enable implicit conversions between long and gcMarkWorkerMode struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator gcMarkWorkerMode(long value) => new gcMarkWorkerMode(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator long(gcMarkWorkerMode value) => value.m_value;
            
            // Enable comparisons between nil and gcMarkWorkerMode struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(gcMarkWorkerMode value, NilType nil) => value.Equals(default(gcMarkWorkerMode));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(gcMarkWorkerMode value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, gcMarkWorkerMode value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, gcMarkWorkerMode value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator gcMarkWorkerMode(NilType nil) => default(gcMarkWorkerMode);
        }
    }
}
