// Copyright 2017 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// This implements the write barrier buffer. The write barrier itself
// is gcWriteBarrier and is implemented in assembly.
//
// See mbarrier.go for algorithmic details on the write barrier. This
// file deals only with the buffer.
//
// The write barrier has a fast path and a slow path. The fast path
// simply enqueues to a per-P write barrier buffer. It's written in
// assembly and doesn't clobber any general purpose registers, so it
// doesn't have the usual overheads of a Go call.
//
// When the buffer fills up, the write barrier invokes the slow path
// (wbBufFlush) to flush the buffer to the GC work queues. In this
// path, since the compiler didn't spill registers, we spill *all*
// registers and disallow any GC safe points that could observe the
// stack frame (since we don't know the types of the spilled
// registers).

// package runtime -- go2cs converted at 2020 October 09 04:47:12 UTC
// import "runtime" ==> using runtime = go.runtime_package
// Original source: C:\Go\src\runtime\mwbbuf.go
using atomic = go.runtime.@internal.atomic_package;
using sys = go.runtime.@internal.sys_package;
using @unsafe = go.@unsafe_package;
using static go.builtin;
using System;

namespace go
{
    public static partial class runtime_package
    {
        // testSmallBuf forces a small write barrier buffer to stress write
        // barrier flushing.
        private static readonly var testSmallBuf = false;

        // wbBuf is a per-P buffer of pointers queued by the write barrier.
        // This buffer is flushed to the GC workbufs when it fills up and on
        // various GC transitions.
        //
        // This is closely related to a "sequential store buffer" (SSB),
        // except that SSBs are usually used for maintaining remembered sets,
        // while this is used for marking.


        // wbBuf is a per-P buffer of pointers queued by the write barrier.
        // This buffer is flushed to the GC workbufs when it fills up and on
        // various GC transitions.
        //
        // This is closely related to a "sequential store buffer" (SSB),
        // except that SSBs are usually used for maintaining remembered sets,
        // while this is used for marking.
        private partial struct wbBuf
        {
            public System.UIntPtr next; // end points to just past the end of buf. It must not be a
// pointer type because it points past the end of buf and must
// be updated without write barriers.
            public System.UIntPtr end; // buf stores a series of pointers to execute write barriers
// on. This must be a multiple of wbBufEntryPointers because
// the write barrier only checks for overflow once per entry.
            public array<System.UIntPtr> buf; // debugGen causes the write barrier buffer to flush after
// every write barrier if equal to gcWorkPauseGen. This is for
// debugging #27993. This is only set if debugCachedWork is
// set.
            public uint debugGen;
        }

 
        // wbBufEntries is the number of write barriers between
        // flushes of the write barrier buffer.
        //
        // This trades latency for throughput amortization. Higher
        // values amortize flushing overhead more, but increase the
        // latency of flushing. Higher values also increase the cache
        // footprint of the buffer.
        //
        // TODO: What is the latency cost of this? Tune this value.
        private static readonly long wbBufEntries = (long)256L; 

        // wbBufEntryPointers is the number of pointers added to the
        // buffer by each write barrier.
        private static readonly long wbBufEntryPointers = (long)2L;


        // reset empties b by resetting its next and end pointers.
        private static void reset(this ptr<wbBuf> _addr_b)
        {
            ref wbBuf b = ref _addr_b.val;

            var start = uintptr(@unsafe.Pointer(_addr_b.buf[0L]));
            b.next = start;
            if (writeBarrier.cgo || (debugCachedWork && (throwOnGCWork || b.debugGen == atomic.Load(_addr_gcWorkPauseGen))))
            { 
                // Effectively disable the buffer by forcing a flush
                // on every barrier.
                b.end = uintptr(@unsafe.Pointer(_addr_b.buf[wbBufEntryPointers]));

            }
            else if (testSmallBuf)
            { 
                // For testing, allow two barriers in the buffer. If
                // we only did one, then barriers of non-heap pointers
                // would be no-ops. This lets us combine a buffered
                // barrier with a flush at a later time.
                b.end = uintptr(@unsafe.Pointer(_addr_b.buf[2L * wbBufEntryPointers]));

            }
            else
            {
                b.end = start + uintptr(len(b.buf)) * @unsafe.Sizeof(b.buf[0L]);
            }

            if ((b.end - b.next) % (wbBufEntryPointers * @unsafe.Sizeof(b.buf[0L])) != 0L)
            {
                throw("bad write barrier buffer bounds");
            }

        }

        // discard resets b's next pointer, but not its end pointer.
        //
        // This must be nosplit because it's called by wbBufFlush.
        //
        //go:nosplit
        private static void discard(this ptr<wbBuf> _addr_b)
        {
            ref wbBuf b = ref _addr_b.val;

            b.next = uintptr(@unsafe.Pointer(_addr_b.buf[0L]));
        }

        // empty reports whether b contains no pointers.
        private static bool empty(this ptr<wbBuf> _addr_b)
        {
            ref wbBuf b = ref _addr_b.val;

            return b.next == uintptr(@unsafe.Pointer(_addr_b.buf[0L]));
        }

        // putFast adds old and new to the write barrier buffer and returns
        // false if a flush is necessary. Callers should use this as:
        //
        //     buf := &getg().m.p.ptr().wbBuf
        //     if !buf.putFast(old, new) {
        //         wbBufFlush(...)
        //     }
        //     ... actual memory write ...
        //
        // The arguments to wbBufFlush depend on whether the caller is doing
        // its own cgo pointer checks. If it is, then this can be
        // wbBufFlush(nil, 0). Otherwise, it must pass the slot address and
        // new.
        //
        // The caller must ensure there are no preemption points during the
        // above sequence. There must be no preemption points while buf is in
        // use because it is a per-P resource. There must be no preemption
        // points between the buffer put and the write to memory because this
        // could allow a GC phase change, which could result in missed write
        // barriers.
        //
        // putFast must be nowritebarrierrec to because write barriers here would
        // corrupt the write barrier buffer. It (and everything it calls, if
        // it called anything) has to be nosplit to avoid scheduling on to a
        // different P and a different buffer.
        //
        //go:nowritebarrierrec
        //go:nosplit
        private static bool putFast(this ptr<wbBuf> _addr_b, System.UIntPtr old, System.UIntPtr @new)
        {
            ref wbBuf b = ref _addr_b.val;

            ptr<array<System.UIntPtr>> p = new ptr<ptr<array<System.UIntPtr>>>(@unsafe.Pointer(b.next));
            p[0L] = old;
            p[1L] = new;
            b.next += 2L * sys.PtrSize;
            return b.next != b.end;
        }

        // wbBufFlush flushes the current P's write barrier buffer to the GC
        // workbufs. It is passed the slot and value of the write barrier that
        // caused the flush so that it can implement cgocheck.
        //
        // This must not have write barriers because it is part of the write
        // barrier implementation.
        //
        // This and everything it calls must be nosplit because 1) the stack
        // contains untyped slots from gcWriteBarrier and 2) there must not be
        // a GC safe point between the write barrier test in the caller and
        // flushing the buffer.
        //
        // TODO: A "go:nosplitrec" annotation would be perfect for this.
        //
        //go:nowritebarrierrec
        //go:nosplit
        private static void wbBufFlush(ptr<System.UIntPtr> _addr_dst, System.UIntPtr src)
        {
            ref System.UIntPtr dst = ref _addr_dst.val;
 
            // Note: Every possible return from this function must reset
            // the buffer's next pointer to prevent buffer overflow.

            // This *must not* modify its arguments because this
            // function's argument slots do double duty in gcWriteBarrier
            // as register spill slots. Currently, not modifying the
            // arguments is sufficient to keep the spill slots unmodified
            // (which seems unlikely to change since it costs little and
            // helps with debugging).

            if (getg().m.dying > 0L)
            { 
                // We're going down. Not much point in write barriers
                // and this way we can allow write barriers in the
                // panic path.
                getg().m.p.ptr().wbBuf.discard();
                return ;

            }

            if (writeBarrier.cgo && dst != null)
            { 
                // This must be called from the stack that did the
                // write. It's nosplit all the way down.
                cgoCheckWriteBarrier(dst, src);
                if (!writeBarrier.needed)
                { 
                    // We were only called for cgocheck.
                    getg().m.p.ptr().wbBuf.discard();
                    return ;

                }

            } 

            // Switch to the system stack so we don't have to worry about
            // the untyped stack slots or safe points.
            systemstack(() =>
            {
                if (debugCachedWork)
                { 
                    // For debugging, include the old value of the
                    // slot and some other data in the traceback.
                    var wbBuf = _addr_getg().m.p.ptr().wbBuf;
                    System.UIntPtr old = default;
                    if (dst != null)
                    { 
                        // dst may be nil in direct calls to wbBufFlush.
                        old = dst;

                    }

                    wbBufFlush1Debug(old, wbBuf.buf[0L], wbBuf.buf[1L], _addr_wbBuf.buf[0L], wbBuf.next);

                }
                else
                {
                    wbBufFlush1(_addr_getg().m.p.ptr());
                }

            });

        }

        // wbBufFlush1Debug is a temporary function for debugging issue
        // #27993. It exists solely to add some context to the traceback.
        //
        //go:nowritebarrierrec
        //go:systemstack
        //go:noinline
        private static void wbBufFlush1Debug(System.UIntPtr old, System.UIntPtr buf1, System.UIntPtr buf2, ptr<System.UIntPtr> _addr_start, System.UIntPtr next)
        {
            ref System.UIntPtr start = ref _addr_start.val;

            wbBufFlush1(_addr_getg().m.p.ptr());
        }

        // wbBufFlush1 flushes p's write barrier buffer to the GC work queue.
        //
        // This must not have write barriers because it is part of the write
        // barrier implementation, so this may lead to infinite loops or
        // buffer corruption.
        //
        // This must be non-preemptible because it uses the P's workbuf.
        //
        //go:nowritebarrierrec
        //go:systemstack
        private static void wbBufFlush1(ptr<p> _addr__p_)
        {
            ref p _p_ = ref _addr__p_.val;
 
            // Get the buffered pointers.
            var start = uintptr(@unsafe.Pointer(_addr__p_.wbBuf.buf[0L]));
            var n = (_p_.wbBuf.next - start) / @unsafe.Sizeof(_p_.wbBuf.buf[0L]);
            var ptrs = _p_.wbBuf.buf[..n]; 

            // Poison the buffer to make extra sure nothing is enqueued
            // while we're processing the buffer.
            _p_.wbBuf.next = 0L;

            if (useCheckmark)
            { 
                // Slow path for checkmark mode.
                {
                    var ptr__prev1 = ptr;

                    foreach (var (_, __ptr) in ptrs)
                    {
                        ptr = __ptr;
                        shade(ptr);
                    }

                    ptr = ptr__prev1;
                }

                _p_.wbBuf.reset();
                return ;

            } 

            // Mark all of the pointers in the buffer and record only the
            // pointers we greyed. We use the buffer itself to temporarily
            // record greyed pointers.
            //
            // TODO: Should scanobject/scanblock just stuff pointers into
            // the wbBuf? Then this would become the sole greying path.
            //
            // TODO: We could avoid shading any of the "new" pointers in
            // the buffer if the stack has been shaded, or even avoid
            // putting them in the buffer at all (which would double its
            // capacity). This is slightly complicated with the buffer; we
            // could track whether any un-shaded goroutine has used the
            // buffer, or just track globally whether there are any
            // un-shaded stacks and flush after each stack scan.
            var gcw = _addr__p_.gcw;
            long pos = 0L;
            {
                var ptr__prev1 = ptr;

                foreach (var (_, __ptr) in ptrs)
                {
                    ptr = __ptr;
                    if (ptr < minLegalPointer)
                    { 
                        // nil pointers are very common, especially
                        // for the "old" values. Filter out these and
                        // other "obvious" non-heap pointers ASAP.
                        //
                        // TODO: Should we filter out nils in the fast
                        // path to reduce the rate of flushes?
                        continue;

                    }

                    var (obj, span, objIndex) = findObject(ptr, 0L, 0L);
                    if (obj == 0L)
                    {
                        continue;
                    } 
                    // TODO: Consider making two passes where the first
                    // just prefetches the mark bits.
                    var mbits = span.markBitsForIndex(objIndex);
                    if (mbits.isMarked())
                    {
                        continue;
                    }

                    mbits.setMarked(); 

                    // Mark span.
                    var (arena, pageIdx, pageMask) = pageIndexOf(span.@base());
                    if (arena.pageMarks[pageIdx] & pageMask == 0L)
                    {
                        atomic.Or8(_addr_arena.pageMarks[pageIdx], pageMask);
                    }

                    if (span.spanclass.noscan())
                    {
                        gcw.bytesMarked += uint64(span.elemsize);
                        continue;
                    }

                    ptrs[pos] = obj;
                    pos++;

                } 

                // Enqueue the greyed objects.

                ptr = ptr__prev1;
            }

            gcw.putBatch(ptrs[..pos]);

            _p_.wbBuf.reset();

        }
    }
}
