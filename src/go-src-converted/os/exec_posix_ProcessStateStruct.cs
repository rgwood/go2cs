//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:07:07 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using execenv = go.@internal.syscall.execenv_package;
using runtime = go.runtime_package;
using syscall = go.syscall_package;

#nullable enable

namespace go
{
    public static partial class os_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct ProcessState
        {
            // Constructors
            public ProcessState(NilType _)
            {
                this.pid = default;
                this.status = default;
                this.rusage = default;
            }

            public ProcessState(long pid = default, syscall.WaitStatus status = default, ref ptr<syscall.Rusage> rusage = default)
            {
                this.pid = pid;
                this.status = status;
                this.rusage = rusage;
            }

            // Enable comparisons between nil and ProcessState struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ProcessState value, NilType nil) => value.Equals(default(ProcessState));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ProcessState value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ProcessState value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ProcessState value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ProcessState(NilType nil) => default(ProcessState);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static ProcessState ProcessState_cast(dynamic value)
        {
            return new ProcessState(value.pid, value.status, ref value.rusage);
        }
    }
}