// Copyright 2011 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package net -- go2cs converted at 2020 October 09 04:52:16 UTC
// import "net" ==> using net = go.net_package
// Original source: C:\Go\src\net\sockoptip_windows.go
using os = go.os_package;
using runtime = go.runtime_package;
using syscall = go.syscall_package;
using @unsafe = go.@unsafe_package;
using static go.builtin;

namespace go
{
    public static partial class net_package
    {
        private static error setIPv4MulticastInterface(ptr<netFD> _addr_fd, ptr<Interface> _addr_ifi)
        {
            ref netFD fd = ref _addr_fd.val;
            ref Interface ifi = ref _addr_ifi.val;

            var (ip, err) = interfaceToIPv4Addr(ifi);
            if (err != null)
            {
                return error.As(os.NewSyscallError("setsockopt", err))!;
            }
            array<byte> a = new array<byte>(4L);
            copy(a[..], ip.To4());
            err = fd.pfd.Setsockopt(syscall.IPPROTO_IP, syscall.IP_MULTICAST_IF, (byte.val)(@unsafe.Pointer(_addr_a[0L])), 4L);
            runtime.KeepAlive(fd);
            return error.As(wrapSyscallError("setsockopt", err))!;

        }

        private static error setIPv4MulticastLoopback(ptr<netFD> _addr_fd, bool v)
        {
            ref netFD fd = ref _addr_fd.val;

            var err = fd.pfd.SetsockoptInt(syscall.IPPROTO_IP, syscall.IP_MULTICAST_LOOP, boolint(v));
            runtime.KeepAlive(fd);
            return error.As(wrapSyscallError("setsockopt", err))!;
        }
    }
}
