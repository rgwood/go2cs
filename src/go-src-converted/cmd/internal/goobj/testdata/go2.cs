// Copyright 2017 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package mypkg -- go2cs converted at 2020 October 09 05:08:55 UTC
// import "cmd/internal/goobj.mypkg" ==> using mypkg = go.cmd.@internal.goobj.mypkg_package
// Original source: C:\Go\src\cmd\internal\goobj\testdata\go2.go
using fmt = go.fmt_package;
using static go.builtin;

namespace go {
namespace cmd {
namespace @internal
{
    public static partial class mypkg_package
    {
        private static void go2()
        {
            fmt.Println("go2");
        }
    }
}}}
