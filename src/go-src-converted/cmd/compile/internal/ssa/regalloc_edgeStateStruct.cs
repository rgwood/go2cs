//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:25:44 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using types = go.cmd.compile.@internal.types_package;
using objabi = go.cmd.@internal.objabi_package;
using src = go.cmd.@internal.src_package;
using sys = go.cmd.@internal.sys_package;
using fmt = go.fmt_package;
using bits = go.math.bits_package;
using @unsafe = go.@unsafe_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class ssa_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct edgeState
        {
            // Constructors
            public edgeState(NilType _)
            {
                this.s = default;
                this.p = default;
                this.b = default;
                this.cache = default;
                this.cachedVals = default;
                this.contents = default;
                this.destinations = default;
                this.extra = default;
                this.usedRegs = default;
                this.uniqueRegs = default;
                this.finalRegs = default;
                this.rematerializeableRegs = default;
            }

            public edgeState(ref ptr<regAllocState> s = default, ref ptr<Block> p = default, ref ptr<Block> b = default, map<ID, slice<ptr<Value>>> cache = default, slice<ID> cachedVals = default, map<Location, contentRecord> contents = default, slice<dstRecord> destinations = default, slice<dstRecord> extra = default, regMask usedRegs = default, regMask uniqueRegs = default, regMask finalRegs = default, regMask rematerializeableRegs = default)
            {
                this.s = s;
                this.p = p;
                this.b = b;
                this.cache = cache;
                this.cachedVals = cachedVals;
                this.contents = contents;
                this.destinations = destinations;
                this.extra = extra;
                this.usedRegs = usedRegs;
                this.uniqueRegs = uniqueRegs;
                this.finalRegs = finalRegs;
                this.rematerializeableRegs = rematerializeableRegs;
            }

            // Enable comparisons between nil and edgeState struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(edgeState value, NilType nil) => value.Equals(default(edgeState));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(edgeState value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, edgeState value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, edgeState value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator edgeState(NilType nil) => default(edgeState);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static edgeState edgeState_cast(dynamic value)
        {
            return new edgeState(ref value.s, ref value.p, ref value.b, value.cache, value.cachedVals, value.contents, value.destinations, value.extra, value.usedRegs, value.uniqueRegs, value.finalRegs, value.rematerializeableRegs);
        }
    }
}}}}