// Copyright 2017 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// Functions to access/create device major and minor numbers matching the
// encoding used in OpenBSD's sys/types.h header.

// package unix -- go2cs converted at 2020 October 09 05:56:12 UTC
// import "cmd/vendor/golang.org/x/sys/unix" ==> using unix = go.cmd.vendor.golang.org.x.sys.unix_package
// Original source: C:\Go\src\cmd\vendor\golang.org\x\sys\unix\dev_openbsd.go

using static go.builtin;

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace sys
{
    public static partial class unix_package
    {
        // Major returns the major component of an OpenBSD device number.
        public static uint Major(ulong dev)
        {
            return uint32((dev & 0x0000ff00UL) >> (int)(8L));
        }

        // Minor returns the minor component of an OpenBSD device number.
        public static uint Minor(ulong dev)
        {
            var minor = uint32((dev & 0x000000ffUL) >> (int)(0L));
            minor |= uint32((dev & 0xffff0000UL) >> (int)(8L));
            return minor;
        }

        // Mkdev returns an OpenBSD device number generated from the given major and minor
        // components.
        public static ulong Mkdev(uint major, uint minor)
        {
            var dev = (uint64(major) << (int)(8L)) & 0x0000ff00UL;
            dev |= (uint64(minor) << (int)(8L)) & 0xffff0000UL;
            dev |= (uint64(minor) << (int)(0L)) & 0x000000ffUL;
            return dev;
        }
    }
}}}}}}
