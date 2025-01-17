//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:19:13 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using flag = go.flag_package;
using fmt = go.fmt_package;
using os = go.os_package;
using runtime = go.runtime_package;
using pprof = go.runtime.pprof_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using time = go.time_package;
using go;

#nullable enable

namespace go {
namespace go
{
    public static partial class testing_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        [PromotedStruct(typeof(common))]
        public partial struct T
        {
            // common structure promotion - sourced from value copy
            private readonly ptr<common> m_commonRef;

            private ref common common_val => ref m_commonRef.Value;

            public ref slice<byte> output => ref m_commonRef.Value.output;

            public ref bool failed => ref m_commonRef.Value.failed;

            public ref time.Time start => ref m_commonRef.Value.start;

            public ref time.Duration duration => ref m_commonRef.Value.duration;

            public ref channel<object> signal => ref m_commonRef.Value.signal;

            // Constructors
            public T(NilType _)
            {
                this.m_commonRef = new ptr<common>(new common(nil));
                this.name = default;
                this.startParallel = default;
            }

            public T(common common = default, @string name = default, channel<bool> startParallel = default)
            {
                this.m_commonRef = new ptr<common>(common);
                this.name = name;
                this.startParallel = startParallel;
            }

            // Enable comparisons between nil and T struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(T value, NilType nil) => value.Equals(default(T));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(T value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, T value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, T value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator T(NilType nil) => default(T);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static T T_cast(dynamic value)
        {
            return new T(value.common, value.name, value.startParallel);
        }
    }
}}