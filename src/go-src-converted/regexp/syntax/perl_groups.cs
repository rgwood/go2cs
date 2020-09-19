// Copyright 2013 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// GENERATED BY make_perl_groups.pl; DO NOT EDIT.
// make_perl_groups.pl >perl_groups.go

// package syntax -- go2cs converted at 2020 August 29 08:23:56 UTC
// import "regexp/syntax" ==> using syntax = go.regexp.syntax_package
// Original source: C:\Go\src\regexp\syntax\perl_groups.go

using static go.builtin;

namespace go {
namespace regexp
{
    public static partial class syntax_package
    {
        private static int code1 = new slice<int>(new int[] { 0x30, 0x39 });

        private static int code2 = new slice<int>(new int[] { 0x9, 0xa, 0xc, 0xd, 0x20, 0x20 });

        private static int code3 = new slice<int>(new int[] { 0x30, 0x39, 0x41, 0x5a, 0x5f, 0x5f, 0x61, 0x7a });

        private static map perlGroup = /* TODO: Fix this in ScannerBase_Expression::ExitCompositeLit */ new map<@string, charGroup>{`\d`:{+1,code1},`\D`:{-1,code1},`\s`:{+1,code2},`\S`:{-1,code2},`\w`:{+1,code3},`\W`:{-1,code3},};
        private static int code4 = new slice<int>(new int[] { 0x30, 0x39, 0x41, 0x5a, 0x61, 0x7a });

        private static int code5 = new slice<int>(new int[] { 0x41, 0x5a, 0x61, 0x7a });

        private static int code6 = new slice<int>(new int[] { 0x0, 0x7f });

        private static int code7 = new slice<int>(new int[] { 0x9, 0x9, 0x20, 0x20 });

        private static int code8 = new slice<int>(new int[] { 0x0, 0x1f, 0x7f, 0x7f });

        private static int code9 = new slice<int>(new int[] { 0x30, 0x39 });

        private static int code10 = new slice<int>(new int[] { 0x21, 0x7e });

        private static int code11 = new slice<int>(new int[] { 0x61, 0x7a });

        private static int code12 = new slice<int>(new int[] { 0x20, 0x7e });

        private static int code13 = new slice<int>(new int[] { 0x21, 0x2f, 0x3a, 0x40, 0x5b, 0x60, 0x7b, 0x7e });

        private static int code14 = new slice<int>(new int[] { 0x9, 0xd, 0x20, 0x20 });

        private static int code15 = new slice<int>(new int[] { 0x41, 0x5a });

        private static int code16 = new slice<int>(new int[] { 0x30, 0x39, 0x41, 0x5a, 0x5f, 0x5f, 0x61, 0x7a });

        private static int code17 = new slice<int>(new int[] { 0x30, 0x39, 0x41, 0x46, 0x61, 0x66 });

        private static map posixGroup = /* TODO: Fix this in ScannerBase_Expression::ExitCompositeLit */ new map<@string, charGroup>{`[:alnum:]`:{+1,code4},`[:^alnum:]`:{-1,code4},`[:alpha:]`:{+1,code5},`[:^alpha:]`:{-1,code5},`[:ascii:]`:{+1,code6},`[:^ascii:]`:{-1,code6},`[:blank:]`:{+1,code7},`[:^blank:]`:{-1,code7},`[:cntrl:]`:{+1,code8},`[:^cntrl:]`:{-1,code8},`[:digit:]`:{+1,code9},`[:^digit:]`:{-1,code9},`[:graph:]`:{+1,code10},`[:^graph:]`:{-1,code10},`[:lower:]`:{+1,code11},`[:^lower:]`:{-1,code11},`[:print:]`:{+1,code12},`[:^print:]`:{-1,code12},`[:punct:]`:{+1,code13},`[:^punct:]`:{-1,code13},`[:space:]`:{+1,code14},`[:^space:]`:{-1,code14},`[:upper:]`:{+1,code15},`[:^upper:]`:{-1,code15},`[:word:]`:{+1,code16},`[:^word:]`:{-1,code16},`[:xdigit:]`:{+1,code17},`[:^xdigit:]`:{-1,code17},};
    }
}}