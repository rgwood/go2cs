//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:49:26 UTC
// </auto-generated>
//---------------------------------------------------------
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace link {
namespace @internal
{
    public static partial class ld_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct dwSym
        {
            // Value of the dwSym struct
            private readonly loader.Sym m_value;

            public dwSym(loader.Sym value) => m_value = value;

            // Enable implicit conversions between loader.Sym and dwSym struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator dwSym(loader.Sym value) => new dwSym(value);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator loader.Sym(dwSym value) => value.m_value;
            
            // Enable comparisons between nil and dwSym struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(dwSym value, NilType nil) => value.Equals(default(dwSym));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(dwSym value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, dwSym value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, dwSym value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator dwSym(NilType nil) => default(dwSym);
        }
    }
}}}}
