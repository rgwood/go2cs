// Copyright 2019 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package robustio -- go2cs converted at 2020 October 09 05:45:43 UTC
// import "cmd/go/internal/robustio" ==> using robustio = go.cmd.go.@internal.robustio_package
// Original source: C:\Go\src\cmd\go\internal\robustio\robustio_windows.go
using errors = go.errors_package;
using windows = go.@internal.syscall.windows_package;
using syscall = go.syscall_package;
using static go.builtin;

namespace go {
namespace cmd {
namespace go {
namespace @internal
{
    public static partial class robustio_package
    {
        private static readonly var errFileNotFound = syscall.ERROR_FILE_NOT_FOUND;

        // isEphemeralError returns true if err may be resolved by waiting.


        // isEphemeralError returns true if err may be resolved by waiting.
        private static bool isEphemeralError(error err)
        {
            ref syscall.Errno errno = ref heap(out ptr<syscall.Errno> _addr_errno);
            if (errors.As(err, _addr_errno))
            {

                if (errno == syscall.ERROR_ACCESS_DENIED || errno == syscall.ERROR_FILE_NOT_FOUND || errno == windows.ERROR_SHARING_VIOLATION) 
                    return true;
                
            }

            return false;

        }
    }
}}}}
