//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:02:24 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace tools {
namespace @internal
{
    public static partial class tool_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct commandLineError
        {
            // Value of the commandLineError struct
            private readonly @string m_value;

            public commandLineError(@string value) => m_value = value;

            // Enable implicit conversions between @string and commandLineError struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator commandLineError(@string value) => new commandLineError(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator @string(commandLineError value) => value.m_value;
            
            // Enable comparisons between nil and commandLineError struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(commandLineError value, NilType nil) => value.Equals(default(commandLineError));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(commandLineError value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, commandLineError value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, commandLineError value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator commandLineError(NilType nil) => default(commandLineError);
        }
    }
}}}}}
