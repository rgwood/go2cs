// Copyright 2015 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package lex -- go2cs converted at 2020 October 09 05:23:03 UTC
// import "cmd/asm/internal/lex" ==> using lex = go.cmd.asm.@internal.lex_package
// Original source: C:\Go\src\cmd\asm\internal\lex\tokenizer.go
using io = go.io_package;
using os = go.os_package;
using strings = go.strings_package;
using scanner = go.text.scanner_package;
using unicode = go.unicode_package;

using flags = go.cmd.asm.@internal.flags_package;
using objabi = go.cmd.@internal.objabi_package;
using src = go.cmd.@internal.src_package;
using static go.builtin;

namespace go {
namespace cmd {
namespace asm {
namespace @internal
{
    public static partial class lex_package
    {
        // A Tokenizer is a simple wrapping of text/scanner.Scanner, configured
        // for our purposes and made a TokenReader. It forms the lowest level,
        // turning text from readers into tokens.
        public partial struct Tokenizer
        {
            public ScanToken tok;
            public ptr<scanner.Scanner> s;
            public ptr<src.PosBase> @base;
            public long line;
            public ptr<os.File> file; // If non-nil, file descriptor to close.
        }

        public static ptr<Tokenizer> NewTokenizer(@string name, io.Reader r, ptr<os.File> _addr_file)
        {
            ref os.File file = ref _addr_file.val;

            ref scanner.Scanner s = ref heap(out ptr<scanner.Scanner> _addr_s);
            s.Init(r); 
            // Newline is like a semicolon; other space characters are fine.
            s.Whitespace = 1L << (int)('\t') | 1L << (int)('\r') | 1L << (int)(' '); 
            // Don't skip comments: we need to count newlines.
            s.Mode = scanner.ScanChars | scanner.ScanFloats | scanner.ScanIdents | scanner.ScanInts | scanner.ScanStrings | scanner.ScanComments;
            s.Position.Filename = name;
            s.IsIdentRune = isIdentRune;
            return addr(new Tokenizer(s:&s,base:src.NewFileBase(name,objabi.AbsFile(objabi.WorkingDir(),name,*flags.TrimPath)),line:1,file:file,));

        }

        // We want center dot (·) and division slash (∕) to work as identifier characters.
        private static bool isIdentRune(int ch, long i)
        {
            if (unicode.IsLetter(ch))
            {
                return true;
            }

            switch (ch)
            {
                case '_': // Underscore; traditional.
                    return true;
                    break;
                case '\u00B7': // Represents the period in runtime.exit. U+00B7 '·' middle dot
                    return true;
                    break;
                case '\u2215': // Represents the slash in runtime/debug.setGCPercent. U+2215 '∕' division slash
                    return true;
                    break;
            } 
            // Digits are OK only after the first character.
            return i > 0L && unicode.IsDigit(ch);

        }

        private static @string Text(this ptr<Tokenizer> _addr_t)
        {
            ref Tokenizer t = ref _addr_t.val;


            if (t.tok == LSH) 
                return "<<";
            else if (t.tok == RSH) 
                return ">>";
            else if (t.tok == ARR) 
                return "->";
            else if (t.tok == ROT) 
                return "@>";
                        return t.s.TokenText();

        }

        private static @string File(this ptr<Tokenizer> _addr_t)
        {
            ref Tokenizer t = ref _addr_t.val;

            return t.@base.Filename();
        }

        private static ptr<src.PosBase> Base(this ptr<Tokenizer> _addr_t)
        {
            ref Tokenizer t = ref _addr_t.val;

            return _addr_t.@base!;
        }

        private static void SetBase(this ptr<Tokenizer> _addr_t, ptr<src.PosBase> _addr_@base)
        {
            ref Tokenizer t = ref _addr_t.val;
            ref src.PosBase @base = ref _addr_@base.val;

            t.@base = base;
        }

        private static long Line(this ptr<Tokenizer> _addr_t)
        {
            ref Tokenizer t = ref _addr_t.val;

            return t.line;
        }

        private static long Col(this ptr<Tokenizer> _addr_t)
        {
            ref Tokenizer t = ref _addr_t.val;

            return t.s.Pos().Column;
        }

        private static ScanToken Next(this ptr<Tokenizer> _addr_t)
        {
            ref Tokenizer t = ref _addr_t.val;

            var s = t.s;
            while (true)
            {
                t.tok = ScanToken(s.Scan());
                if (t.tok != scanner.Comment)
                {
                    break;
                }

                var length = strings.Count(s.TokenText(), "\n");
                t.line += length; 
                // TODO: If we ever have //go: comments in assembly, will need to keep them here.
                // For now, just discard all comments.
            }

            switch (t.tok)
            {
                case '\n': 
                    t.line++;
                    break;
                case '-': 
                    if (s.Peek() == '>')
                    {
                        s.Next();
                        t.tok = ARR;
                        return ARR;
                    }

                    break;
                case '@': 
                    if (s.Peek() == '>')
                    {
                        s.Next();
                        t.tok = ROT;
                        return ROT;
                    }

                    break;
                case '<': 
                    if (s.Peek() == '<')
                    {
                        s.Next();
                        t.tok = LSH;
                        return LSH;
                    }

                    break;
                case '>': 
                    if (s.Peek() == '>')
                    {
                        s.Next();
                        t.tok = RSH;
                        return RSH;
                    }

                    break;
            }
            return t.tok;

        }

        private static void Close(this ptr<Tokenizer> _addr_t)
        {
            ref Tokenizer t = ref _addr_t.val;

            if (t.file != null)
            {
                t.file.Close();
            }

        }
    }
}}}}
