// Copyright 2012 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package error2 -- go2cs converted at 2020 October 09 05:19:11 UTC
// import "go/doc.error2" ==> using error2 = go.go.doc.error2_package
// Original source: C:\Go\src\go\doc\testdata\error2.go

using static go.builtin;

namespace go {
namespace go
{
    public static partial class error2_package
    {
        public partial interface I0 : error
        {
        }

        public partial struct T0
        {
        }

        public partial struct S0 : error
        {
            public error error;
        }

        // This error declaration shadows the predeclared error type.
        private partial interface error
        {
            @string Error();
        }
    }
}}
