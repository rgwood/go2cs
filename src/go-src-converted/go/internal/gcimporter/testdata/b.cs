// Copyright 2016 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// Input for TestIssue13566

// package b -- go2cs converted at 2020 October 09 06:02:45 UTC
// import "go/internal/gcimporter.b" ==> using b = go.go.@internal.gcimporter.b_package
// Original source: C:\Go\src\go\internal\gcimporter\testdata\b.go
using a = go...a_package;
using static go.builtin;

namespace go {
namespace go {
namespace @internal
{
    public static partial class b_package
    {
        public partial struct A // : a.A
        {
        }
    }
}}}
