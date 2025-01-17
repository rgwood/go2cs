// Copyright 2012 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package runtime -- go2cs converted at 2020 October 09 04:49:11 UTC
// import "runtime" ==> using runtime = go.runtime_package
// Original source: C:\Go\src\runtime\vdso_linux_amd64.go

using static go.builtin;

namespace go
{
    public static partial class runtime_package
    {
 
        // vdsoArrayMax is the byte-size of a maximally sized array on this architecture.
        // See cmd/compile/internal/amd64/galign.go arch.MAXWIDTH initialization.
        private static readonly long vdsoArrayMax = (long)1L << (int)(50L) - 1L;


        private static vdsoVersionKey vdsoLinuxVersion = new vdsoVersionKey("LINUX_2.6",0x3ae75f6);

        private static vdsoSymbolKey vdsoSymbolKeys = new slice<vdsoSymbolKey>(new vdsoSymbolKey[] { {"__vdso_gettimeofday",0x315ca59,0xb01bca00,&vdsoGettimeofdaySym}, {"__vdso_clock_gettime",0xd35ec75,0x6e43a318,&vdsoClockgettimeSym} });

        // initialize with vsyscall fallbacks
        private static System.UIntPtr vdsoGettimeofdaySym = 0xffffffffff600000UL;        private static System.UIntPtr vdsoClockgettimeSym = 0L;
    }
}
