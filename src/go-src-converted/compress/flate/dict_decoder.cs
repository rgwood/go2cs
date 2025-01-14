// Copyright 2016 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package flate -- go2cs converted at 2020 October 09 04:50:14 UTC
// import "compress/flate" ==> using flate = go.compress.flate_package
// Original source: C:\Go\src\compress\flate\dict_decoder.go

using static go.builtin;

namespace go {
namespace compress
{
    public static partial class flate_package
    {
        // dictDecoder implements the LZ77 sliding dictionary as used in decompression.
        // LZ77 decompresses data through sequences of two forms of commands:
        //
        //    * Literal insertions: Runs of one or more symbols are inserted into the data
        //    stream as is. This is accomplished through the writeByte method for a
        //    single symbol, or combinations of writeSlice/writeMark for multiple symbols.
        //    Any valid stream must start with a literal insertion if no preset dictionary
        //    is used.
        //
        //    * Backward copies: Runs of one or more symbols are copied from previously
        //    emitted data. Backward copies come as the tuple (dist, length) where dist
        //    determines how far back in the stream to copy from and length determines how
        //    many bytes to copy. Note that it is valid for the length to be greater than
        //    the distance. Since LZ77 uses forward copies, that situation is used to
        //    perform a form of run-length encoding on repeated runs of symbols.
        //    The writeCopy and tryWriteCopy are used to implement this command.
        //
        // For performance reasons, this implementation performs little to no sanity
        // checks about the arguments. As such, the invariants documented for each
        // method call must be respected.
        private partial struct dictDecoder
        {
            public slice<byte> hist; // Sliding window history

// Invariant: 0 <= rdPos <= wrPos <= len(hist)
            public long wrPos; // Current output position in buffer
            public long rdPos; // Have emitted hist[:rdPos] already
            public bool full; // Has a full window length been written yet?
        }

        // init initializes dictDecoder to have a sliding window dictionary of the given
        // size. If a preset dict is provided, it will initialize the dictionary with
        // the contents of dict.
        private static void init(this ptr<dictDecoder> _addr_dd, long size, slice<byte> dict)
        {
            ref dictDecoder dd = ref _addr_dd.val;

            dd.val = new dictDecoder(hist:dd.hist);

            if (cap(dd.hist) < size)
            {
                dd.hist = make_slice<byte>(size);
            }

            dd.hist = dd.hist[..size];

            if (len(dict) > len(dd.hist))
            {
                dict = dict[len(dict) - len(dd.hist)..];
            }

            dd.wrPos = copy(dd.hist, dict);
            if (dd.wrPos == len(dd.hist))
            {
                dd.wrPos = 0L;
                dd.full = true;
            }

            dd.rdPos = dd.wrPos;

        }

        // histSize reports the total amount of historical data in the dictionary.
        private static long histSize(this ptr<dictDecoder> _addr_dd)
        {
            ref dictDecoder dd = ref _addr_dd.val;

            if (dd.full)
            {
                return len(dd.hist);
            }

            return dd.wrPos;

        }

        // availRead reports the number of bytes that can be flushed by readFlush.
        private static long availRead(this ptr<dictDecoder> _addr_dd)
        {
            ref dictDecoder dd = ref _addr_dd.val;

            return dd.wrPos - dd.rdPos;
        }

        // availWrite reports the available amount of output buffer space.
        private static long availWrite(this ptr<dictDecoder> _addr_dd)
        {
            ref dictDecoder dd = ref _addr_dd.val;

            return len(dd.hist) - dd.wrPos;
        }

        // writeSlice returns a slice of the available buffer to write data to.
        //
        // This invariant will be kept: len(s) <= availWrite()
        private static slice<byte> writeSlice(this ptr<dictDecoder> _addr_dd)
        {
            ref dictDecoder dd = ref _addr_dd.val;

            return dd.hist[dd.wrPos..];
        }

        // writeMark advances the writer pointer by cnt.
        //
        // This invariant must be kept: 0 <= cnt <= availWrite()
        private static void writeMark(this ptr<dictDecoder> _addr_dd, long cnt)
        {
            ref dictDecoder dd = ref _addr_dd.val;

            dd.wrPos += cnt;
        }

        // writeByte writes a single byte to the dictionary.
        //
        // This invariant must be kept: 0 < availWrite()
        private static void writeByte(this ptr<dictDecoder> _addr_dd, byte c)
        {
            ref dictDecoder dd = ref _addr_dd.val;

            dd.hist[dd.wrPos] = c;
            dd.wrPos++;
        }

        // writeCopy copies a string at a given (dist, length) to the output.
        // This returns the number of bytes copied and may be less than the requested
        // length if the available space in the output buffer is too small.
        //
        // This invariant must be kept: 0 < dist <= histSize()
        private static long writeCopy(this ptr<dictDecoder> _addr_dd, long dist, long length)
        {
            ref dictDecoder dd = ref _addr_dd.val;

            var dstBase = dd.wrPos;
            var dstPos = dstBase;
            var srcPos = dstPos - dist;
            var endPos = dstPos + length;
            if (endPos > len(dd.hist))
            {
                endPos = len(dd.hist);
            } 

            // Copy non-overlapping section after destination position.
            //
            // This section is non-overlapping in that the copy length for this section
            // is always less than or equal to the backwards distance. This can occur
            // if a distance refers to data that wraps-around in the buffer.
            // Thus, a backwards copy is performed here; that is, the exact bytes in
            // the source prior to the copy is placed in the destination.
            if (srcPos < 0L)
            {
                srcPos += len(dd.hist);
                dstPos += copy(dd.hist[dstPos..endPos], dd.hist[srcPos..]);
                srcPos = 0L;
            } 

            // Copy possibly overlapping section before destination position.
            //
            // This section can overlap if the copy length for this section is larger
            // than the backwards distance. This is allowed by LZ77 so that repeated
            // strings can be succinctly represented using (dist, length) pairs.
            // Thus, a forwards copy is performed here; that is, the bytes copied is
            // possibly dependent on the resulting bytes in the destination as the copy
            // progresses along. This is functionally equivalent to the following:
            //
            //    for i := 0; i < endPos-dstPos; i++ {
            //        dd.hist[dstPos+i] = dd.hist[srcPos+i]
            //    }
            //    dstPos = endPos
            //
            while (dstPos < endPos)
            {
                dstPos += copy(dd.hist[dstPos..endPos], dd.hist[srcPos..dstPos]);
            }


            dd.wrPos = dstPos;
            return dstPos - dstBase;

        }

        // tryWriteCopy tries to copy a string at a given (distance, length) to the
        // output. This specialized version is optimized for short distances.
        //
        // This method is designed to be inlined for performance reasons.
        //
        // This invariant must be kept: 0 < dist <= histSize()
        private static long tryWriteCopy(this ptr<dictDecoder> _addr_dd, long dist, long length)
        {
            ref dictDecoder dd = ref _addr_dd.val;

            var dstPos = dd.wrPos;
            var endPos = dstPos + length;
            if (dstPos < dist || endPos > len(dd.hist))
            {
                return 0L;
            }

            var dstBase = dstPos;
            var srcPos = dstPos - dist; 

            // Copy possibly overlapping section before destination position.
loop:
            dstPos += copy(dd.hist[dstPos..endPos], dd.hist[srcPos..dstPos]);
            if (dstPos < endPos)
            {
                goto loop; // Avoid for-loop so that this function can be inlined
            }

            dd.wrPos = dstPos;
            return dstPos - dstBase;

        }

        // readFlush returns a slice of the historical buffer that is ready to be
        // emitted to the user. The data returned by readFlush must be fully consumed
        // before calling any other dictDecoder methods.
        private static slice<byte> readFlush(this ptr<dictDecoder> _addr_dd)
        {
            ref dictDecoder dd = ref _addr_dd.val;

            var toRead = dd.hist[dd.rdPos..dd.wrPos];
            dd.rdPos = dd.wrPos;
            if (dd.wrPos == len(dd.hist))
            {
                dd.wrPos = 0L;
                dd.rdPos = 0L;
                dd.full = true;

            }

            return toRead;

        }
    }
}}
