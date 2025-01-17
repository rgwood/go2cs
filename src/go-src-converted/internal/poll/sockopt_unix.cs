// Copyright 2017 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// +build aix darwin dragonfly freebsd linux netbsd openbsd solaris

// package poll -- go2cs converted at 2020 October 09 04:51:22 UTC
// import "internal/poll" ==> using poll = go.@internal.poll_package
// Original source: C:\Go\src\internal\poll\sockopt_unix.go
using syscall = go.syscall_package;
using static go.builtin;

namespace go {
namespace @internal
{
    public static partial class poll_package
    {
        // SetsockoptByte wraps the setsockopt network call with a byte argument.
        private static error SetsockoptByte(this ptr<FD> _addr_fd, long level, long name, byte arg) => func((defer, _, __) =>
        {
            ref FD fd = ref _addr_fd.val;

            {
                var err = fd.incref();

                if (err != null)
                {
                    return error.As(err)!;
                }
            }

            defer(fd.decref());
            return error.As(syscall.SetsockoptByte(fd.Sysfd, level, name, arg))!;

        });
    }
}}
