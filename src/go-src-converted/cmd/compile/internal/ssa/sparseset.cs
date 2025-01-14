// Copyright 2015 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package ssa -- go2cs converted at 2020 October 09 05:39:33 UTC
// import "cmd/compile/internal/ssa" ==> using ssa = go.cmd.compile.@internal.ssa_package
// Original source: C:\Go\src\cmd\compile\internal\ssa\sparseset.go

using static go.builtin;

namespace go {
namespace cmd {
namespace compile {
namespace @internal
{
    public static partial class ssa_package
    {
        // from https://research.swtch.com/sparse
        // in turn, from Briggs and Torczon
        private partial struct sparseSet
        {
            public slice<ID> dense;
            public slice<int> sparse;
        }

        // newSparseSet returns a sparseSet that can represent
        // integers between 0 and n-1
        private static ptr<sparseSet> newSparseSet(long n)
        {
            return addr(new sparseSet(dense:nil,sparse:make([]int32,n)));
        }

        private static long cap(this ptr<sparseSet> _addr_s)
        {
            ref sparseSet s = ref _addr_s.val;

            return len(s.sparse);
        }

        private static long size(this ptr<sparseSet> _addr_s)
        {
            ref sparseSet s = ref _addr_s.val;

            return len(s.dense);
        }

        private static bool contains(this ptr<sparseSet> _addr_s, ID x)
        {
            ref sparseSet s = ref _addr_s.val;

            var i = s.sparse[x];
            return i < int32(len(s.dense)) && s.dense[i] == x;
        }

        private static void add(this ptr<sparseSet> _addr_s, ID x)
        {
            ref sparseSet s = ref _addr_s.val;

            var i = s.sparse[x];
            if (i < int32(len(s.dense)) && s.dense[i] == x)
            {
                return ;
            }

            s.dense = append(s.dense, x);
            s.sparse[x] = int32(len(s.dense)) - 1L;

        }

        private static void addAll(this ptr<sparseSet> _addr_s, slice<ID> a)
        {
            ref sparseSet s = ref _addr_s.val;

            foreach (var (_, x) in a)
            {
                s.add(x);
            }

        }

        private static void addAllValues(this ptr<sparseSet> _addr_s, slice<ptr<Value>> a)
        {
            ref sparseSet s = ref _addr_s.val;

            foreach (var (_, v) in a)
            {
                s.add(v.ID);
            }

        }

        private static void remove(this ptr<sparseSet> _addr_s, ID x)
        {
            ref sparseSet s = ref _addr_s.val;

            var i = s.sparse[x];
            if (i < int32(len(s.dense)) && s.dense[i] == x)
            {
                var y = s.dense[len(s.dense) - 1L];
                s.dense[i] = y;
                s.sparse[y] = i;
                s.dense = s.dense[..len(s.dense) - 1L];
            }

        }

        // pop removes an arbitrary element from the set.
        // The set must be nonempty.
        private static ID pop(this ptr<sparseSet> _addr_s)
        {
            ref sparseSet s = ref _addr_s.val;

            var x = s.dense[len(s.dense) - 1L];
            s.dense = s.dense[..len(s.dense) - 1L];
            return x;
        }

        private static void clear(this ptr<sparseSet> _addr_s)
        {
            ref sparseSet s = ref _addr_s.val;

            s.dense = s.dense[..0L];
        }

        private static slice<ID> contents(this ptr<sparseSet> _addr_s)
        {
            ref sparseSet s = ref _addr_s.val;

            return s.dense;
        }
    }
}}}}
