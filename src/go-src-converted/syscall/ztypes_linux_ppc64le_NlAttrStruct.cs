//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:04:31 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;


#nullable enable

namespace go
{
    public static partial class syscall_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct NlAttr
        {
            // Constructors
            public NlAttr(NilType _)
            {
                this.Len = default;
                this.Type = default;
            }

            public NlAttr(ushort Len = default, ushort Type = default)
            {
                this.Len = Len;
                this.Type = Type;
            }

            // Enable comparisons between nil and NlAttr struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NlAttr value, NilType nil) => value.Equals(default(NlAttr));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NlAttr value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, NlAttr value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, NlAttr value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator NlAttr(NilType nil) => default(NlAttr);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static NlAttr NlAttr_cast(dynamic value)
        {
            return new NlAttr(value.Len, value.Type);
        }
    }
}