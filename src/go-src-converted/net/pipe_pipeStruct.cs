//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:52:11 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using io = go.io_package;
using os = go.os_package;
using sync = go.sync_package;
using time = go.time_package;

#nullable enable

namespace go
{
    public static partial class net_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct pipe
        {
            // Constructors
            public pipe(NilType _)
            {
                this.wrMu = default;
                this.rdRx = default;
                this.rdTx = default;
                this.wrTx = default;
                this.wrRx = default;
                this.once = default;
                this.localDone = default;
                this.remoteDone = default;
                this.readDeadline = default;
                this.writeDeadline = default;
            }

            public pipe(sync.Mutex wrMu = default, channel<slice<byte>> rdRx = default, channel<long> rdTx = default, channel<slice<byte>> wrTx = default, channel<long> wrRx = default, sync.Once once = default, channel<object> localDone = default, channel<object> remoteDone = default, pipeDeadline readDeadline = default, pipeDeadline writeDeadline = default)
            {
                this.wrMu = wrMu;
                this.rdRx = rdRx;
                this.rdTx = rdTx;
                this.wrTx = wrTx;
                this.wrRx = wrRx;
                this.once = once;
                this.localDone = localDone;
                this.remoteDone = remoteDone;
                this.readDeadline = readDeadline;
                this.writeDeadline = writeDeadline;
            }

            // Enable comparisons between nil and pipe struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(pipe value, NilType nil) => value.Equals(default(pipe));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(pipe value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, pipe value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, pipe value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator pipe(NilType nil) => default(pipe);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static pipe pipe_cast(dynamic value)
        {
            return new pipe(value.wrMu, value.rdRx, value.rdTx, value.wrTx, value.wrRx, value.once, value.localDone, value.remoteDone, value.readDeadline, value.writeDeadline);
        }
    }
}