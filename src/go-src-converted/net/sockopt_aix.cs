// Copyright 2018 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package net -- go2cs converted at 2020 October 09 04:52:16 UTC
// import "net" ==> using net = go.net_package
// Original source: C:\Go\src\net\sockopt_aix.go
using os = go.os_package;
using syscall = go.syscall_package;
using static go.builtin;

namespace go
{
    public static partial class net_package
    {
        private static error setDefaultSockopts(long s, long family, long sotype, bool ipv6only)
        {
            if (family == syscall.AF_INET6 && sotype != syscall.SOCK_RAW)
            { 
                // Allow both IP versions even if the OS default
                // is otherwise. Note that some operating systems
                // never admit this option.
                syscall.SetsockoptInt(s, syscall.IPPROTO_IPV6, syscall.IPV6_V6ONLY, boolint(ipv6only));

            }
            if ((sotype == syscall.SOCK_DGRAM || sotype == syscall.SOCK_RAW) && family != syscall.AF_UNIX)
            { 
                // Allow broadcast.
                return error.As(os.NewSyscallError("setsockopt", syscall.SetsockoptInt(s, syscall.SOL_SOCKET, syscall.SO_BROADCAST, 1L)))!;

            }
            return error.As(null!)!;

        }

        private static error setDefaultListenerSockopts(long s)
        { 
            // Allow reuse of recently-used addresses.
            return error.As(os.NewSyscallError("setsockopt", syscall.SetsockoptInt(s, syscall.SOL_SOCKET, syscall.SO_REUSEADDR, 1L)))!;

        }

        private static error setDefaultMulticastSockopts(long s)
        { 
            // Allow multicast UDP and raw IP datagram sockets to listen
            // concurrently across multiple listeners.
            {
                var err = syscall.SetsockoptInt(s, syscall.SOL_SOCKET, syscall.SO_REUSEADDR, 1L);

                if (err != null)
                {
                    return error.As(os.NewSyscallError("setsockopt", err))!;
                } 
                // Allow reuse of recently-used ports.

            } 
            // Allow reuse of recently-used ports.
            return error.As(os.NewSyscallError("setsockopt", syscall.SetsockoptInt(s, syscall.SOL_SOCKET, syscall.SO_REUSEPORT, 1L)))!;

        }
    }
}
