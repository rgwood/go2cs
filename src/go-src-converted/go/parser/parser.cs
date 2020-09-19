// Copyright 2009 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// Package parser implements a parser for Go source files. Input may be
// provided in a variety of forms (see the various Parse* functions); the
// output is an abstract syntax tree (AST) representing the Go source. The
// parser is invoked through one of the Parse* functions.
//
// The parser accepts a larger language than is syntactically permitted by
// the Go spec, for simplicity, and for improved robustness in the presence
// of syntax errors. For instance, in method declarations, the receiver is
// treated like an ordinary parameter list and thus may contain multiple
// entries where the spec permits exactly one. Consequently, the corresponding
// field in the AST (ast.FuncDecl.Recv) field is not restricted to one entry.
//
// package parser -- go2cs converted at 2020 August 29 08:48:22 UTC
// import "go/parser" ==> using parser = go.go.parser_package
// Original source: C:\Go\src\go\parser\parser.go
using fmt = go.fmt_package;
using ast = go.go.ast_package;
using scanner = go.go.scanner_package;
using token = go.go.token_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using unicode = go.unicode_package;
using static go.builtin;
using System;

namespace go {
namespace go
{
    public static partial class parser_package
    {
        // The parser structure holds the parser's internal state.
        private partial struct parser
        {
            public ptr<token.File> file;
            public scanner.ErrorList errors;
            public scanner.Scanner scanner; // Tracing/debugging
            public Mode mode; // parsing mode
            public bool trace; // == (mode & Trace != 0)
            public long indent; // indentation used for tracing output

// Comments
            public slice<ref ast.CommentGroup> comments;
            public ptr<ast.CommentGroup> leadComment; // last lead comment
            public ptr<ast.CommentGroup> lineComment; // last line comment

// Next token
            public token.Pos pos; // token position
            public token.Token tok; // one token look-ahead
            public @string lit; // token literal

// Error recovery
// (used to limit the number of calls to syncXXX functions
// w/o making scanning progress - avoids potential endless
// loops across multiple parser functions during error recovery)
            public token.Pos syncPos; // last synchronization position
            public long syncCnt; // number of calls to syncXXX without progress

// Non-syntactic parser control
            public long exprLev; // < 0: in control clause, >= 0: in expression
            public bool inRhs; // if set, the parser is parsing a rhs expression

// Ordinary identifier scopes
            public ptr<ast.Scope> pkgScope; // pkgScope.Outer == nil
            public ptr<ast.Scope> topScope; // top-most scope; may be pkgScope
            public slice<ref ast.Ident> unresolved; // unresolved identifiers
            public slice<ref ast.ImportSpec> imports; // list of imports

// Label scopes
// (maintained by open/close LabelScope)
            public ptr<ast.Scope> labelScope; // label scope for current function
            public slice<slice<ref ast.Ident>> targetStack; // stack of unresolved labels
        }

        private static void init(this ref parser p, ref token.FileSet fset, @string filename, slice<byte> src, Mode mode)
        {
            p.file = fset.AddFile(filename, -1L, len(src));
            scanner.Mode m = default;
            if (mode & ParseComments != 0L)
            {
                m = scanner.ScanComments;
            }
            Action<token.Position, @string> eh = (pos, msg) =>
            {
                p.errors.Add(pos, msg);

            }
;
            p.scanner.Init(p.file, src, eh, m);

            p.mode = mode;
            p.trace = mode & Trace != 0L; // for convenience (p.trace is used frequently)

            p.next();
        }

        // ----------------------------------------------------------------------------
        // Scoping support

        private static void openScope(this ref parser p)
        {
            p.topScope = ast.NewScope(p.topScope);
        }

        private static void closeScope(this ref parser p)
        {
            p.topScope = p.topScope.Outer;
        }

        private static void openLabelScope(this ref parser p)
        {
            p.labelScope = ast.NewScope(p.labelScope);
            p.targetStack = append(p.targetStack, null);
        }

        private static void closeLabelScope(this ref parser p)
        { 
            // resolve labels
            var n = len(p.targetStack) - 1L;
            var scope = p.labelScope;
            foreach (var (_, ident) in p.targetStack[n])
            {
                ident.Obj = scope.Lookup(ident.Name);
                if (ident.Obj == null && p.mode & DeclarationErrors != 0L)
                {
                    p.error(ident.Pos(), fmt.Sprintf("label %s undefined", ident.Name));
                }
            } 
            // pop label scope
            p.targetStack = p.targetStack[0L..n];
            p.labelScope = p.labelScope.Outer;
        }

        private static void declare(this ref parser p, object decl, object data, ref ast.Scope scope, ast.ObjKind kind, params ptr<ast.Ident>[] idents)
        {
            foreach (var (_, ident) in idents)
            {
                assert(ident.Obj == null, "identifier already declared or resolved");
                var obj = ast.NewObj(kind, ident.Name); 
                // remember the corresponding declaration for redeclaration
                // errors and global variable resolution/typechecking phase
                obj.Decl = decl;
                obj.Data = data;
                ident.Obj = obj;
                if (ident.Name != "_")
                {
                    {
                        var alt = scope.Insert(obj);

                        if (alt != null && p.mode & DeclarationErrors != 0L)
                        {
                            @string prevDecl = "";
                            {
                                var pos = alt.Pos();

                                if (pos.IsValid())
                                {
                                    prevDecl = fmt.Sprintf("\n\tprevious declaration at %s", p.file.Position(pos));
                                }

                            }
                            p.error(ident.Pos(), fmt.Sprintf("%s redeclared in this block%s", ident.Name, prevDecl));
                        }

                    }
                }
            }
        }

        private static void shortVarDecl(this ref parser p, ref ast.AssignStmt decl, slice<ast.Expr> list)
        { 
            // Go spec: A short variable declaration may redeclare variables
            // provided they were originally declared in the same block with
            // the same type, and at least one of the non-blank variables is new.
            long n = 0L; // number of new variables
            foreach (var (_, x) in list)
            {
                {
                    ref ast.Ident (ident, isIdent) = x._<ref ast.Ident>();

                    if (isIdent)
                    {
                        assert(ident.Obj == null, "identifier already declared or resolved");
                        var obj = ast.NewObj(ast.Var, ident.Name); 
                        // remember corresponding assignment for other tools
                        obj.Decl = decl;
                        ident.Obj = obj;
                        if (ident.Name != "_")
                        {
                            {
                                var alt = p.topScope.Insert(obj);

                                if (alt != null)
                                {
                                    ident.Obj = alt; // redeclaration
                                }
                                else
                                {
                                    n++; // new declaration
                                }

                            }
                        }
                    }
                    else
                    {
                        p.errorExpected(x.Pos(), "identifier on left side of :=");
                    }

                }
            }
            if (n == 0L && p.mode & DeclarationErrors != 0L)
            {
                p.error(list[0L].Pos(), "no new variables on left side of :=");
            }
        }

        // The unresolved object is a sentinel to mark identifiers that have been added
        // to the list of unresolved identifiers. The sentinel is only used for verifying
        // internal consistency.
        private static ptr<object> unresolved = @new<ast.Object>();

        // If x is an identifier, tryResolve attempts to resolve x by looking up
        // the object it denotes. If no object is found and collectUnresolved is
        // set, x is marked as unresolved and collected in the list of unresolved
        // identifiers.
        //
        private static void tryResolve(this ref parser p, ast.Expr x, bool collectUnresolved)
        { 
            // nothing to do if x is not an identifier or the blank identifier
            ref ast.Ident (ident, _) = x._<ref ast.Ident>();
            if (ident == null)
            {
                return;
            }
            assert(ident.Obj == null, "identifier already declared or resolved");
            if (ident.Name == "_")
            {
                return;
            } 
            // try to resolve the identifier
            {
                var s = p.topScope;

                while (s != null)
                {
                    {
                        var obj = s.Lookup(ident.Name);

                        if (obj != null)
                        {
                            ident.Obj = obj;
                            return;
                    s = s.Outer;
                        }

                    }
                } 
                // all local scopes are known, so any unresolved identifier
                // must be found either in the file scope, package scope
                // (perhaps in another file), or universe scope --- collect
                // them so that they can be resolved later

            } 
            // all local scopes are known, so any unresolved identifier
            // must be found either in the file scope, package scope
            // (perhaps in another file), or universe scope --- collect
            // them so that they can be resolved later
            if (collectUnresolved)
            {
                ident.Obj = unresolved;
                p.unresolved = append(p.unresolved, ident);
            }
        }

        private static void resolve(this ref parser p, ast.Expr x)
        {
            p.tryResolve(x, true);
        }

        // ----------------------------------------------------------------------------
        // Parsing support

        private static void printTrace(this ref parser p, params object[] a)
        {
            const @string dots = ". . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . ";

            const var n = len(dots);

            var pos = p.file.Position(p.pos);
            fmt.Printf("%5d:%3d: ", pos.Line, pos.Column);
            long i = 2L * p.indent;
            while (i > n)
            {
                fmt.Print(dots);
                i -= n;
            } 
            // i <= n
 
            // i <= n
            fmt.Print(dots[0L..i]);
            fmt.Println(a);
        }

        private static ref parser trace(ref parser p, @string msg)
        {
            p.printTrace(msg, "(");
            p.indent++;
            return p;
        }

        // Usage pattern: defer un(trace(p, "..."))
        private static void un(ref parser p)
        {
            p.indent--;
            p.printTrace(")");
        }

        // Advance to the next token.
        private static void next0(this ref parser p)
        { 
            // Because of one-token look-ahead, print the previous token
            // when tracing as it provides a more readable output. The
            // very first token (!p.pos.IsValid()) is not initialized
            // (it is token.ILLEGAL), so don't print it .
            if (p.trace && p.pos.IsValid())
            {
                var s = p.tok.String();

                if (p.tok.IsLiteral()) 
                    p.printTrace(s, p.lit);
                else if (p.tok.IsOperator() || p.tok.IsKeyword()) 
                    p.printTrace("\"" + s + "\"");
                else 
                    p.printTrace(s);
                            }
            p.pos, p.tok, p.lit = p.scanner.Scan();
        }

        // Consume a comment and return it and the line on which it ends.
        private static (ref ast.Comment, long) consumeComment(this ref parser p)
        { 
            // /*-style comments may end on a different line than where they start.
            // Scan the comment for '\n' chars and adjust endline accordingly.
            endline = p.file.Line(p.pos);
            if (p.lit[1L] == '*')
            { 
                // don't use range here - no need to decode Unicode code points
                for (long i = 0L; i < len(p.lit); i++)
                {
                    if (p.lit[i] == '\n')
                    {
                        endline++;
                    }
                }

            }
            comment = ref new ast.Comment(Slash:p.pos,Text:p.lit);
            p.next0();

            return;
        }

        // Consume a group of adjacent comments, add it to the parser's
        // comments list, and return it together with the line at which
        // the last comment in the group ends. A non-comment token or n
        // empty lines terminate a comment group.
        //
        private static (ref ast.CommentGroup, long) consumeCommentGroup(this ref parser p, long n)
        {
            slice<ref ast.Comment> list = default;
            endline = p.file.Line(p.pos);
            while (p.tok == token.COMMENT && p.file.Line(p.pos) <= endline + n)
            {
                ref ast.Comment comment = default;
                comment, endline = p.consumeComment();
                list = append(list, comment);
            } 

            // add comment group to the comments list
 

            // add comment group to the comments list
            comments = ref new ast.CommentGroup(List:list);
            p.comments = append(p.comments, comments);

            return;
        }

        // Advance to the next non-comment token. In the process, collect
        // any comment groups encountered, and remember the last lead and
        // and line comments.
        //
        // A lead comment is a comment group that starts and ends in a
        // line without any other tokens and that is followed by a non-comment
        // token on the line immediately after the comment group.
        //
        // A line comment is a comment group that follows a non-comment
        // token on the same line, and that has no tokens after it on the line
        // where it ends.
        //
        // Lead and line comments may be considered documentation that is
        // stored in the AST.
        //
        private static void next(this ref parser p)
        {
            p.leadComment = null;
            p.lineComment = null;
            var prev = p.pos;
            p.next0();

            if (p.tok == token.COMMENT)
            {
                ref ast.CommentGroup comment = default;
                long endline = default;

                if (p.file.Line(p.pos) == p.file.Line(prev))
                { 
                    // The comment is on same line as the previous token; it
                    // cannot be a lead comment but may be a line comment.
                    comment, endline = p.consumeCommentGroup(0L);
                    if (p.file.Line(p.pos) != endline || p.tok == token.EOF)
                    { 
                        // The next token is on a different line, thus
                        // the last comment group is a line comment.
                        p.lineComment = comment;
                    }
                } 

                // consume successor comments, if any
                endline = -1L;
                while (p.tok == token.COMMENT)
                {
                    comment, endline = p.consumeCommentGroup(1L);
                }


                if (endline + 1L == p.file.Line(p.pos))
                { 
                    // The next token is following on the line immediately after the
                    // comment group, thus the last comment group is a lead comment.
                    p.leadComment = comment;
                }
            }
        }

        // A bailout panic is raised to indicate early termination.
        private partial struct bailout
        {
        }

        private static void error(this ref parser _p, token.Pos pos, @string msg) => func(_p, (ref parser p, Defer _, Panic panic, Recover __) =>
        {
            var epos = p.file.Position(pos); 

            // If AllErrors is not set, discard errors reported on the same line
            // as the last recorded error and stop parsing if there are more than
            // 10 errors.
            if (p.mode & AllErrors == 0L)
            {
                var n = len(p.errors);
                if (n > 0L && p.errors[n - 1L].Pos.Line == epos.Line)
                {
                    return; // discard - likely a spurious error
                }
                if (n > 10L)
                {
                    panic(new bailout());
                }
            }
            p.errors.Add(epos, msg);
        });

        private static void errorExpected(this ref parser p, token.Pos pos, @string msg)
        {
            msg = "expected " + msg;
            if (pos == p.pos)
            { 
                // the error happened at the current position;
                // make the error message more specific
                if (p.tok == token.SEMICOLON && p.lit == "\n")
                {
                    msg += ", found newline";
                }
                else
                {
                    msg += ", found '" + p.tok.String() + "'";
                    if (p.tok.IsLiteral())
                    {
                        msg += " " + p.lit;
                    }
                }
            }
            p.error(pos, msg);
        }

        private static token.Pos expect(this ref parser p, token.Token tok)
        {
            var pos = p.pos;
            if (p.tok != tok)
            {
                p.errorExpected(pos, "'" + tok.String() + "'");
            }
            p.next(); // make progress
            return pos;
        }

        // expectClosing is like expect but provides a better error message
        // for the common case of a missing comma before a newline.
        //
        private static token.Pos expectClosing(this ref parser p, token.Token tok, @string context)
        {
            if (p.tok != tok && p.tok == token.SEMICOLON && p.lit == "\n")
            {
                p.error(p.pos, "missing ',' before newline in " + context);
                p.next();
            }
            return p.expect(tok);
        }

        private static void expectSemi(this ref parser p)
        { 
            // semicolon is optional before a closing ')' or '}'
            if (p.tok != token.RPAREN && p.tok != token.RBRACE)
            {

                if (p.tok == token.COMMA) 
                {
                    // permit a ',' instead of a ';' but complain
                    p.errorExpected(p.pos, "';'");
                    fallthrough = true;
                }
                if (fallthrough || p.tok == token.SEMICOLON)
                {
                    p.next();
                    goto __switch_break0;
                }
                // default: 
                    p.errorExpected(p.pos, "';'");
                    syncStmt(p);

                __switch_break0:;
            }
        }

        private static bool atComma(this ref parser p, @string context, token.Token follow)
        {
            if (p.tok == token.COMMA)
            {
                return true;
            }
            if (p.tok != follow)
            {
                @string msg = "missing ','";
                if (p.tok == token.SEMICOLON && p.lit == "\n")
                {
                    msg += " before newline";
                }
                p.error(p.pos, msg + " in " + context);
                return true; // "insert" comma and continue
            }
            return false;
        }

        private static void assert(bool cond, @string msg) => func((_, panic, __) =>
        {
            if (!cond)
            {
                panic("go/parser internal error: " + msg);
            }
        });

        // syncStmt advances to the next statement.
        // Used for synchronization after an error.
        //
        private static void syncStmt(ref parser p)
        {
            while (true)
            {

                if (p.tok == token.BREAK || p.tok == token.CONST || p.tok == token.CONTINUE || p.tok == token.DEFER || p.tok == token.FALLTHROUGH || p.tok == token.FOR || p.tok == token.GO || p.tok == token.GOTO || p.tok == token.IF || p.tok == token.RETURN || p.tok == token.SELECT || p.tok == token.SWITCH || p.tok == token.TYPE || p.tok == token.VAR) 
                    // Return only if parser made some progress since last
                    // sync or if it has not reached 10 sync calls without
                    // progress. Otherwise consume at least one token to
                    // avoid an endless parser loop (it is possible that
                    // both parseOperand and parseStmt call syncStmt and
                    // correctly do not advance, thus the need for the
                    // invocation limit p.syncCnt).
                    if (p.pos == p.syncPos && p.syncCnt < 10L)
                    {
                        p.syncCnt++;
                        return;
                    }
                    if (p.pos > p.syncPos)
                    {
                        p.syncPos = p.pos;
                        p.syncCnt = 0L;
                        return;
                    } 
                    // Reaching here indicates a parser bug, likely an
                    // incorrect token list in this function, but it only
                    // leads to skipping of possibly correct code if a
                    // previous error is present, and thus is preferred
                    // over a non-terminating parse.
                else if (p.tok == token.EOF) 
                    return;
                                p.next();
            }

        }

        // syncDecl advances to the next declaration.
        // Used for synchronization after an error.
        //
        private static void syncDecl(ref parser p)
        {
            while (true)
            {

                if (p.tok == token.CONST || p.tok == token.TYPE || p.tok == token.VAR) 
                    // see comments in syncStmt
                    if (p.pos == p.syncPos && p.syncCnt < 10L)
                    {
                        p.syncCnt++;
                        return;
                    }
                    if (p.pos > p.syncPos)
                    {
                        p.syncPos = p.pos;
                        p.syncCnt = 0L;
                        return;
                    }
                else if (p.tok == token.EOF) 
                    return;
                                p.next();
            }

        }

        // safePos returns a valid file position for a given position: If pos
        // is valid to begin with, safePos returns pos. If pos is out-of-range,
        // safePos returns the EOF position.
        //
        // This is hack to work around "artificial" end positions in the AST which
        // are computed by adding 1 to (presumably valid) token positions. If the
        // token positions are invalid due to parse errors, the resulting end position
        // may be past the file's EOF position, which would lead to panics if used
        // later on.
        //
        private static token.Pos safePos(this ref parser _p, token.Pos pos) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            defer(() =>
            {
                if (recover() != null)
                {
                    res = token.Pos(p.file.Base() + p.file.Size()); // EOF position
                }
            }());
            _ = p.file.Offset(pos); // trigger a panic if position is out-of-range
            return pos;
        });

        // ----------------------------------------------------------------------------
        // Identifiers

        private static ref ast.Ident parseIdent(this ref parser p)
        {
            var pos = p.pos;
            @string name = "_";
            if (p.tok == token.IDENT)
            {
                name = p.lit;
                p.next();
            }
            else
            {
                p.expect(token.IDENT); // use expect() error handling
            }
            return ref new ast.Ident(NamePos:pos,Name:name);
        }

        private static slice<ref ast.Ident> parseIdentList(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "IdentList")));
            }
            list = append(list, p.parseIdent());
            while (p.tok == token.COMMA)
            {
                p.next();
                list = append(list, p.parseIdent());
            }


            return;
        });

        // ----------------------------------------------------------------------------
        // Common productions

        // If lhs is set, result list elements which are identifiers are not resolved.
        private static slice<ast.Expr> parseExprList(this ref parser _p, bool lhs) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "ExpressionList")));
            }
            list = append(list, p.checkExpr(p.parseExpr(lhs)));
            while (p.tok == token.COMMA)
            {
                p.next();
                list = append(list, p.checkExpr(p.parseExpr(lhs)));
            }


            return;
        });

        private static slice<ast.Expr> parseLhsList(this ref parser p)
        {
            var old = p.inRhs;
            p.inRhs = false;
            var list = p.parseExprList(true);

            if (p.tok == token.DEFINE)             else if (p.tok == token.COLON)             else 
                // identifiers must be declared elsewhere
                foreach (var (_, x) in list)
                {
                    p.resolve(x);
                }
                        p.inRhs = old;
            return list;
        }

        private static slice<ast.Expr> parseRhsList(this ref parser p)
        {
            var old = p.inRhs;
            p.inRhs = true;
            var list = p.parseExprList(false);
            p.inRhs = old;
            return list;
        }

        // ----------------------------------------------------------------------------
        // Types

        private static ast.Expr parseType(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Type")));
            }
            var typ = p.tryType();

            if (typ == null)
            {
                var pos = p.pos;
                p.errorExpected(pos, "type");
                p.next(); // make progress
                return ref new ast.BadExpr(From:pos,To:p.pos);
            }
            return typ;
        });

        // If the result is an identifier, it is not resolved.
        private static ast.Expr parseTypeName(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "TypeName")));
            }
            var ident = p.parseIdent(); 
            // don't resolve ident yet - it may be a parameter or field name

            if (p.tok == token.PERIOD)
            { 
                // ident is a package name
                p.next();
                p.resolve(ident);
                var sel = p.parseIdent();
                return ref new ast.SelectorExpr(X:ident,Sel:sel);
            }
            return ident;
        });

        private static ast.Expr parseArrayType(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "ArrayType")));
            }
            var lbrack = p.expect(token.LBRACK);
            p.exprLev++;
            ast.Expr len = default; 
            // always permit ellipsis for more fault-tolerant parsing
            if (p.tok == token.ELLIPSIS)
            {
                len = ref new ast.Ellipsis(Ellipsis:p.pos);
                p.next();
            }
            else if (p.tok != token.RBRACK)
            {
                len = p.parseRhs();
            }
            p.exprLev--;
            p.expect(token.RBRACK);
            var elt = p.parseType();

            return ref new ast.ArrayType(Lbrack:lbrack,Len:len,Elt:elt);
        });

        private static slice<ref ast.Ident> makeIdentList(this ref parser p, slice<ast.Expr> list)
        {
            var idents = make_slice<ref ast.Ident>(len(list));
            foreach (var (i, x) in list)
            {
                ref ast.Ident (ident, isIdent) = x._<ref ast.Ident>();
                if (!isIdent)
                {
                    {
                        ref ast.BadExpr (_, isBad) = x._<ref ast.BadExpr>();

                        if (!isBad)
                        { 
                            // only report error if it's a new one
                            p.errorExpected(x.Pos(), "identifier");
                        }

                    }
                    ident = ref new ast.Ident(NamePos:x.Pos(),Name:"_");
                }
                idents[i] = ident;
            }
            return idents;
        }

        private static ref ast.Field parseFieldDecl(this ref parser _p, ref ast.Scope _scope) => func(_p, _scope, (ref parser p, ref ast.Scope scope, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "FieldDecl")));
            }
            var doc = p.leadComment; 

            // 1st FieldDecl
            // A type name used as an anonymous field looks like a field identifier.
            slice<ast.Expr> list = default;
            while (true)
            {
                list = append(list, p.parseVarType(false));
                if (p.tok != token.COMMA)
                {
                    break;
                }
                p.next();
            }


            var typ = p.tryVarType(false); 

            // analyze case
            slice<ref ast.Ident> idents = default;
            if (typ != null)
            { 
                // IdentifierList Type
                idents = p.makeIdentList(list);
            }
            else
            { 
                // ["*"] TypeName (AnonymousField)
                typ = list[0L]; // we always have at least one element
                {
                    var n = len(list);

                    if (n > 1L)
                    {
                        p.errorExpected(p.pos, "type");
                        typ = ref new ast.BadExpr(From:p.pos,To:p.pos);
                    }
                    else if (!isTypeName(deref(typ)))
                    {
                        p.errorExpected(typ.Pos(), "anonymous field");
                        typ = ref new ast.BadExpr(From:typ.Pos(),To:p.safePos(typ.End()));
                    }

                }
            } 

            // Tag
            ref ast.BasicLit tag = default;
            if (p.tok == token.STRING)
            {
                tag = ref new ast.BasicLit(ValuePos:p.pos,Kind:p.tok,Value:p.lit);
                p.next();
            }
            p.expectSemi(); // call before accessing p.linecomment

            ast.Field field = ref new ast.Field(Doc:doc,Names:idents,Type:typ,Tag:tag,Comment:p.lineComment);
            p.declare(field, null, scope, ast.Var, idents);
            p.resolve(typ);

            return field;
        });

        private static ref ast.StructType parseStructType(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "StructType")));
            }
            var pos = p.expect(token.STRUCT);
            var lbrace = p.expect(token.LBRACE);
            var scope = ast.NewScope(null); // struct scope
            slice<ref ast.Field> list = default;
            while (p.tok == token.IDENT || p.tok == token.MUL || p.tok == token.LPAREN)
            { 
                // a field declaration cannot start with a '(' but we accept
                // it here for more robust parsing and better error messages
                // (parseFieldDecl will check and complain if necessary)
                list = append(list, p.parseFieldDecl(scope));
            }

            var rbrace = p.expect(token.RBRACE);

            return ref new ast.StructType(Struct:pos,Fields:&ast.FieldList{Opening:lbrace,List:list,Closing:rbrace,},);
        });

        private static ref ast.StarExpr parsePointerType(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "PointerType")));
            }
            var star = p.expect(token.MUL);
            var @base = p.parseType();

            return ref new ast.StarExpr(Star:star,X:base);
        });

        // If the result is an identifier, it is not resolved.
        private static ast.Expr tryVarType(this ref parser p, bool isParam)
        {
            if (isParam && p.tok == token.ELLIPSIS)
            {
                var pos = p.pos;
                p.next();
                var typ = p.tryIdentOrType(); // don't use parseType so we can provide better error message
                if (typ != null)
                {
                    p.resolve(typ);
                }
                else
                {
                    p.error(pos, "'...' parameter is missing type");
                    typ = ref new ast.BadExpr(From:pos,To:p.pos);
                }
                return ref new ast.Ellipsis(Ellipsis:pos,Elt:typ);
            }
            return p.tryIdentOrType();
        }

        // If the result is an identifier, it is not resolved.
        private static ast.Expr parseVarType(this ref parser p, bool isParam)
        {
            var typ = p.tryVarType(isParam);
            if (typ == null)
            {
                var pos = p.pos;
                p.errorExpected(pos, "type");
                p.next(); // make progress
                typ = ref new ast.BadExpr(From:pos,To:p.pos);
            }
            return typ;
        }

        private static slice<ref ast.Field> parseParameterList(this ref parser _p, ref ast.Scope _scope, bool ellipsisOk) => func(_p, _scope, (ref parser p, ref ast.Scope scope, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "ParameterList")));
            } 

            // 1st ParameterDecl
            // A list of identifiers looks like a list of type names.
            slice<ast.Expr> list = default;
            while (true)
            {
                list = append(list, p.parseVarType(ellipsisOk));
                if (p.tok != token.COMMA)
                {
                    break;
                }
                p.next();
                if (p.tok == token.RPAREN)
                {
                    break;
                }
            } 

            // analyze case
 

            // analyze case
            {
                var typ__prev1 = typ;

                var typ = p.tryVarType(ellipsisOk);

                if (typ != null)
                { 
                    // IdentifierList Type
                    var idents = p.makeIdentList(list);
                    ast.Field field = ref new ast.Field(Names:idents,Type:typ);
                    params = append(params, field); 
                    // Go spec: The scope of an identifier denoting a function
                    // parameter or result variable is the function body.
                    p.declare(field, null, scope, ast.Var, idents);
                    p.resolve(typ);
                    if (!p.atComma("parameter list", token.RPAREN))
                    {
                        return;
                    }
                    p.next();
                    while (p.tok != token.RPAREN && p.tok != token.EOF)
                    {
                        idents = p.parseIdentList();
                        typ = p.parseVarType(ellipsisOk);
                        field = ref new ast.Field(Names:idents,Type:typ);
                        params = append(params, field); 
                        // Go spec: The scope of an identifier denoting a function
                        // parameter or result variable is the function body.
                        p.declare(field, null, scope, ast.Var, idents);
                        p.resolve(typ);
                        if (!p.atComma("parameter list", token.RPAREN))
                        {
                            break;
                        }
                        p.next();
                    }

                    return;
                } 

                // Type { "," Type } (anonymous parameters)

                typ = typ__prev1;

            } 

            // Type { "," Type } (anonymous parameters)
            params = make_slice<ref ast.Field>(len(list));
            {
                var typ__prev1 = typ;

                foreach (var (__i, __typ) in list)
                {
                    i = __i;
                    typ = __typ;
                    p.resolve(typ);
                    params[i] = ref new ast.Field(Type:typ);
                }

                typ = typ__prev1;
            }

            return;
        });

        private static ref ast.FieldList parseParameters(this ref parser _p, ref ast.Scope _scope, bool ellipsisOk) => func(_p, _scope, (ref parser p, ref ast.Scope scope, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Parameters")));
            }
            slice<ref ast.Field> @params = default;
            var lparen = p.expect(token.LPAREN);
            if (p.tok != token.RPAREN)
            {
                params = p.parseParameterList(scope, ellipsisOk);
            }
            var rparen = p.expect(token.RPAREN);

            return ref new ast.FieldList(Opening:lparen,List:params,Closing:rparen);
        });

        private static ref ast.FieldList parseResult(this ref parser _p, ref ast.Scope _scope) => func(_p, _scope, (ref parser p, ref ast.Scope scope, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Result")));
            }
            if (p.tok == token.LPAREN)
            {
                return p.parseParameters(scope, false);
            }
            var typ = p.tryType();
            if (typ != null)
            {
                var list = make_slice<ref ast.Field>(1L);
                list[0L] = ref new ast.Field(Type:typ);
                return ref new ast.FieldList(List:list);
            }
            return null;
        });

        private static (ref ast.FieldList, ref ast.FieldList) parseSignature(this ref parser _p, ref ast.Scope _scope) => func(_p, _scope, (ref parser p, ref ast.Scope scope, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Signature")));
            }
            params = p.parseParameters(scope, true);
            results = p.parseResult(scope);

            return;
        });

        private static (ref ast.FuncType, ref ast.Scope) parseFuncType(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "FuncType")));
            }
            var pos = p.expect(token.FUNC);
            var scope = ast.NewScope(p.topScope); // function scope
            var (params, results) = p.parseSignature(scope);

            return (ref new ast.FuncType(Func:pos,Params:params,Results:results), scope);
        });

        private static ref ast.Field parseMethodSpec(this ref parser _p, ref ast.Scope _scope) => func(_p, _scope, (ref parser p, ref ast.Scope scope, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "MethodSpec")));
            }
            var doc = p.leadComment;
            slice<ref ast.Ident> idents = default;
            ast.Expr typ = default;
            var x = p.parseTypeName();
            {
                ref ast.Ident (ident, isIdent) = x._<ref ast.Ident>();

                if (isIdent && p.tok == token.LPAREN)
                { 
                    // method
                    idents = new slice<ref ast.Ident>(new ref ast.Ident[] { ident });
                    var scope = ast.NewScope(null); // method scope
                    var (params, results) = p.parseSignature(scope);
                    typ = ref new ast.FuncType(Func:token.NoPos,Params:params,Results:results);
                }
                else
                { 
                    // embedded interface
                    typ = x;
                    p.resolve(typ);
                }

            }
            p.expectSemi(); // call before accessing p.linecomment

            ast.Field spec = ref new ast.Field(Doc:doc,Names:idents,Type:typ,Comment:p.lineComment);
            p.declare(spec, null, scope, ast.Fun, idents);

            return spec;
        });

        private static ref ast.InterfaceType parseInterfaceType(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "InterfaceType")));
            }
            var pos = p.expect(token.INTERFACE);
            var lbrace = p.expect(token.LBRACE);
            var scope = ast.NewScope(null); // interface scope
            slice<ref ast.Field> list = default;
            while (p.tok == token.IDENT)
            {
                list = append(list, p.parseMethodSpec(scope));
            }

            var rbrace = p.expect(token.RBRACE);

            return ref new ast.InterfaceType(Interface:pos,Methods:&ast.FieldList{Opening:lbrace,List:list,Closing:rbrace,},);
        });

        private static ref ast.MapType parseMapType(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "MapType")));
            }
            var pos = p.expect(token.MAP);
            p.expect(token.LBRACK);
            var key = p.parseType();
            p.expect(token.RBRACK);
            var value = p.parseType();

            return ref new ast.MapType(Map:pos,Key:key,Value:value);
        });

        private static ref ast.ChanType parseChanType(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "ChanType")));
            }
            var pos = p.pos;
            var dir = ast.SEND | ast.RECV;
            token.Pos arrow = default;
            if (p.tok == token.CHAN)
            {
                p.next();
                if (p.tok == token.ARROW)
                {
                    arrow = p.pos;
                    p.next();
                    dir = ast.SEND;
                }
            }
            else
            {
                arrow = p.expect(token.ARROW);
                p.expect(token.CHAN);
                dir = ast.RECV;
            }
            var value = p.parseType();

            return ref new ast.ChanType(Begin:pos,Arrow:arrow,Dir:dir,Value:value);
        });

        // If the result is an identifier, it is not resolved.
        private static ast.Expr tryIdentOrType(this ref parser p)
        {

            if (p.tok == token.IDENT) 
                return p.parseTypeName();
            else if (p.tok == token.LBRACK) 
                return p.parseArrayType();
            else if (p.tok == token.STRUCT) 
                return p.parseStructType();
            else if (p.tok == token.MUL) 
                return p.parsePointerType();
            else if (p.tok == token.FUNC) 
                var (typ, _) = p.parseFuncType();
                return typ;
            else if (p.tok == token.INTERFACE) 
                return p.parseInterfaceType();
            else if (p.tok == token.MAP) 
                return p.parseMapType();
            else if (p.tok == token.CHAN || p.tok == token.ARROW) 
                return p.parseChanType();
            else if (p.tok == token.LPAREN) 
                var lparen = p.pos;
                p.next();
                var typ = p.parseType();
                var rparen = p.expect(token.RPAREN);
                return ref new ast.ParenExpr(Lparen:lparen,X:typ,Rparen:rparen);
            // no type found
            return null;
        }

        private static ast.Expr tryType(this ref parser p)
        {
            var typ = p.tryIdentOrType();
            if (typ != null)
            {
                p.resolve(typ);
            }
            return typ;
        }

        // ----------------------------------------------------------------------------
        // Blocks

        private static slice<ast.Stmt> parseStmtList(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "StatementList")));
            }
            while (p.tok != token.CASE && p.tok != token.DEFAULT && p.tok != token.RBRACE && p.tok != token.EOF)
            {
                list = append(list, p.parseStmt());
            }


            return;
        });

        private static ref ast.BlockStmt parseBody(this ref parser _p, ref ast.Scope _scope) => func(_p, _scope, (ref parser p, ref ast.Scope scope, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Body")));
            }
            var lbrace = p.expect(token.LBRACE);
            p.topScope = scope; // open function scope
            p.openLabelScope();
            var list = p.parseStmtList();
            p.closeLabelScope();
            p.closeScope();
            var rbrace = p.expect(token.RBRACE);

            return ref new ast.BlockStmt(Lbrace:lbrace,List:list,Rbrace:rbrace);
        });

        private static ref ast.BlockStmt parseBlockStmt(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "BlockStmt")));
            }
            var lbrace = p.expect(token.LBRACE);
            p.openScope();
            var list = p.parseStmtList();
            p.closeScope();
            var rbrace = p.expect(token.RBRACE);

            return ref new ast.BlockStmt(Lbrace:lbrace,List:list,Rbrace:rbrace);
        });

        // ----------------------------------------------------------------------------
        // Expressions

        private static ast.Expr parseFuncTypeOrLit(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "FuncTypeOrLit")));
            }
            var (typ, scope) = p.parseFuncType();
            if (p.tok != token.LBRACE)
            { 
                // function type only
                return typ;
            }
            p.exprLev++;
            var body = p.parseBody(scope);
            p.exprLev--;

            return ref new ast.FuncLit(Type:typ,Body:body);
        });

        // parseOperand may return an expression or a raw type (incl. array
        // types of the form [...]T. Callers must verify the result.
        // If lhs is set and the result is an identifier, it is not resolved.
        //
        private static ast.Expr parseOperand(this ref parser _p, bool lhs) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Operand")));
            }

            if (p.tok == token.IDENT) 
                var x = p.parseIdent();
                if (!lhs)
                {
                    p.resolve(x);
                }
                return x;
            else if (p.tok == token.INT || p.tok == token.FLOAT || p.tok == token.IMAG || p.tok == token.CHAR || p.tok == token.STRING) 
                x = ref new ast.BasicLit(ValuePos:p.pos,Kind:p.tok,Value:p.lit);
                p.next();
                return x;
            else if (p.tok == token.LPAREN) 
                var lparen = p.pos;
                p.next();
                p.exprLev++;
                x = p.parseRhsOrType(); // types may be parenthesized: (some type)
                p.exprLev--;
                var rparen = p.expect(token.RPAREN);
                return ref new ast.ParenExpr(Lparen:lparen,X:x,Rparen:rparen);
            else if (p.tok == token.FUNC) 
                return p.parseFuncTypeOrLit();
                        {
                var typ = p.tryIdentOrType();

                if (typ != null)
                { 
                    // could be type for composite literal or conversion
                    ref ast.Ident (_, isIdent) = typ._<ref ast.Ident>();
                    assert(!isIdent, "type cannot be identifier");
                    return typ;
                } 

                // we have an error

            } 

            // we have an error
            var pos = p.pos;
            p.errorExpected(pos, "operand");
            syncStmt(p);
            return ref new ast.BadExpr(From:pos,To:p.pos);
        });

        private static ast.Expr parseSelector(this ref parser _p, ast.Expr x) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Selector")));
            }
            var sel = p.parseIdent();

            return ref new ast.SelectorExpr(X:x,Sel:sel);
        });

        private static ast.Expr parseTypeAssertion(this ref parser _p, ast.Expr x) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "TypeAssertion")));
            }
            var lparen = p.expect(token.LPAREN);
            ast.Expr typ = default;
            if (p.tok == token.TYPE)
            { 
                // type switch: typ == nil
                p.next();
            }
            else
            {
                typ = p.parseType();
            }
            var rparen = p.expect(token.RPAREN);

            return ref new ast.TypeAssertExpr(X:x,Type:typ,Lparen:lparen,Rparen:rparen);
        });

        private static ast.Expr parseIndexOrSlice(this ref parser _p, ast.Expr x) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "IndexOrSlice")));
            }
            const long N = 3L; // change the 3 to 2 to disable 3-index slices
 // change the 3 to 2 to disable 3-index slices
            var lbrack = p.expect(token.LBRACK);
            p.exprLev++;
            array<ast.Expr> index = new array<ast.Expr>(N);
            array<token.Pos> colons = new array<token.Pos>(N - 1L);
            if (p.tok != token.COLON)
            {
                index[0L] = p.parseRhs();
            }
            long ncolons = 0L;
            while (p.tok == token.COLON && ncolons < len(colons))
            {
                colons[ncolons] = p.pos;
                ncolons++;
                p.next();
                if (p.tok != token.COLON && p.tok != token.RBRACK && p.tok != token.EOF)
                {
                    index[ncolons] = p.parseRhs();
                }
            }

            p.exprLev--;
            var rbrack = p.expect(token.RBRACK);

            if (ncolons > 0L)
            { 
                // slice expression
                var slice3 = false;
                if (ncolons == 2L)
                {
                    slice3 = true; 
                    // Check presence of 2nd and 3rd index here rather than during type-checking
                    // to prevent erroneous programs from passing through gofmt (was issue 7305).
                    if (index[1L] == null)
                    {
                        p.error(colons[0L], "2nd index required in 3-index slice");
                        index[1L] = ref new ast.BadExpr(From:colons[0]+1,To:colons[1]);
                    }
                    if (index[2L] == null)
                    {
                        p.error(colons[1L], "3rd index required in 3-index slice");
                        index[2L] = ref new ast.BadExpr(From:colons[1]+1,To:rbrack);
                    }
                }
                return ref new ast.SliceExpr(X:x,Lbrack:lbrack,Low:index[0],High:index[1],Max:index[2],Slice3:slice3,Rbrack:rbrack);
            }
            return ref new ast.IndexExpr(X:x,Lbrack:lbrack,Index:index[0],Rbrack:rbrack);
        });

        private static ref ast.CallExpr parseCallOrConversion(this ref parser _p, ast.Expr fun) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "CallOrConversion")));
            }
            var lparen = p.expect(token.LPAREN);
            p.exprLev++;
            slice<ast.Expr> list = default;
            token.Pos ellipsis = default;
            while (p.tok != token.RPAREN && p.tok != token.EOF && !ellipsis.IsValid())
            {
                list = append(list, p.parseRhsOrType()); // builtins may expect a type: make(some type, ...)
                if (p.tok == token.ELLIPSIS)
                {
                    ellipsis = p.pos;
                    p.next();
                }
                if (!p.atComma("argument list", token.RPAREN))
                {
                    break;
                }
                p.next();
            }

            p.exprLev--;
            var rparen = p.expectClosing(token.RPAREN, "argument list");

            return ref new ast.CallExpr(Fun:fun,Lparen:lparen,Args:list,Ellipsis:ellipsis,Rparen:rparen);
        });

        private static ast.Expr parseValue(this ref parser _p, bool keyOk) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Element")));
            }
            if (p.tok == token.LBRACE)
            {
                return p.parseLiteralValue(null);
            } 

            // Because the parser doesn't know the composite literal type, it cannot
            // know if a key that's an identifier is a struct field name or a name
            // denoting a value. The former is not resolved by the parser or the
            // resolver.
            //
            // Instead, _try_ to resolve such a key if possible. If it resolves,
            // it a) has correctly resolved, or b) incorrectly resolved because
            // the key is a struct field with a name matching another identifier.
            // In the former case we are done, and in the latter case we don't
            // care because the type checker will do a separate field lookup.
            //
            // If the key does not resolve, it a) must be defined at the top
            // level in another file of the same package, the universe scope, or be
            // undeclared; or b) it is a struct field. In the former case, the type
            // checker can do a top-level lookup, and in the latter case it will do
            // a separate field lookup.
            var x = p.checkExpr(p.parseExpr(keyOk));
            if (keyOk)
            {
                if (p.tok == token.COLON)
                { 
                    // Try to resolve the key but don't collect it
                    // as unresolved identifier if it fails so that
                    // we don't get (possibly false) errors about
                    // undeclared names.
                    p.tryResolve(x, false);
                }
                else
                { 
                    // not a key
                    p.resolve(x);
                }
            }
            return x;
        });

        private static ast.Expr parseElement(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Element")));
            }
            var x = p.parseValue(true);
            if (p.tok == token.COLON)
            {
                var colon = p.pos;
                p.next();
                x = ref new ast.KeyValueExpr(Key:x,Colon:colon,Value:p.parseValue(false));
            }
            return x;
        });

        private static slice<ast.Expr> parseElementList(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "ElementList")));
            }
            while (p.tok != token.RBRACE && p.tok != token.EOF)
            {
                list = append(list, p.parseElement());
                if (!p.atComma("composite literal", token.RBRACE))
                {
                    break;
                }
                p.next();
            }


            return;
        });

        private static ast.Expr parseLiteralValue(this ref parser _p, ast.Expr typ) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "LiteralValue")));
            }
            var lbrace = p.expect(token.LBRACE);
            slice<ast.Expr> elts = default;
            p.exprLev++;
            if (p.tok != token.RBRACE)
            {
                elts = p.parseElementList();
            }
            p.exprLev--;
            var rbrace = p.expectClosing(token.RBRACE, "composite literal");
            return ref new ast.CompositeLit(Type:typ,Lbrace:lbrace,Elts:elts,Rbrace:rbrace);
        });

        // checkExpr checks that x is an expression (and not a type).
        private static ast.Expr checkExpr(this ref parser _p, ast.Expr x) => func(_p, (ref parser p, Defer _, Panic panic, Recover __) =>
        {
            switch (unparen(x).type())
            {
                case ref ast.BadExpr _:
                    break;
                case ref ast.Ident _:
                    break;
                case ref ast.BasicLit _:
                    break;
                case ref ast.FuncLit _:
                    break;
                case ref ast.CompositeLit _:
                    break;
                case ref ast.ParenExpr _:
                    panic("unreachable");
                    break;
                case ref ast.SelectorExpr _:
                    break;
                case ref ast.IndexExpr _:
                    break;
                case ref ast.SliceExpr _:
                    break;
                case ref ast.TypeAssertExpr _:
                    break;
                case ref ast.CallExpr _:
                    break;
                case ref ast.StarExpr _:
                    break;
                case ref ast.UnaryExpr _:
                    break;
                case ref ast.BinaryExpr _:
                    break;
                default:
                {
                    p.errorExpected(x.Pos(), "expression");
                    x = ref new ast.BadExpr(From:x.Pos(),To:p.safePos(x.End()));
                    break;
                }
            }
            return x;
        });

        // isTypeName reports whether x is a (qualified) TypeName.
        private static bool isTypeName(ast.Expr x)
        {
            switch (x.type())
            {
                case ref ast.BadExpr t:
                    break;
                case ref ast.Ident t:
                    break;
                case ref ast.SelectorExpr t:
                    ref ast.Ident (_, isIdent) = t.X._<ref ast.Ident>();
                    return isIdent;
                    break;
                default:
                {
                    var t = x.type();
                    return false; // all other nodes are not type names
                    break;
                }
            }
            return true;
        }

        // isLiteralType reports whether x is a legal composite literal type.
        private static bool isLiteralType(ast.Expr x)
        {
            switch (x.type())
            {
                case ref ast.BadExpr t:
                    break;
                case ref ast.Ident t:
                    break;
                case ref ast.SelectorExpr t:
                    ref ast.Ident (_, isIdent) = t.X._<ref ast.Ident>();
                    return isIdent;
                    break;
                case ref ast.ArrayType t:
                    break;
                case ref ast.StructType t:
                    break;
                case ref ast.MapType t:
                    break;
                default:
                {
                    var t = x.type();
                    return false; // all other nodes are not legal composite literal types
                    break;
                }
            }
            return true;
        }

        // If x is of the form *T, deref returns T, otherwise it returns x.
        private static ast.Expr deref(ast.Expr x)
        {
            {
                ref ast.StarExpr (p, isPtr) = x._<ref ast.StarExpr>();

                if (isPtr)
                {
                    x = p.X;
                }

            }
            return x;
        }

        // If x is of the form (T), unparen returns unparen(T), otherwise it returns x.
        private static ast.Expr unparen(ast.Expr x)
        {
            {
                ref ast.ParenExpr (p, isParen) = x._<ref ast.ParenExpr>();

                if (isParen)
                {
                    x = unparen(p.X);
                }

            }
            return x;
        }

        // checkExprOrType checks that x is an expression or a type
        // (and not a raw type such as [...]T).
        //
        private static ast.Expr checkExprOrType(this ref parser _p, ast.Expr x) => func(_p, (ref parser p, Defer _, Panic panic, Recover __) =>
        {
            switch (unparen(x).type())
            {
                case ref ast.ParenExpr t:
                    panic("unreachable");
                    break;
                case ref ast.UnaryExpr t:
                    break;
                case ref ast.ArrayType t:
                    {
                        ref ast.Ellipsis (len, isEllipsis) = t.Len._<ref ast.Ellipsis>();

                        if (isEllipsis)
                        {
                            p.error(len.Pos(), "expected array length, found '...'");
                            x = ref new ast.BadExpr(From:x.Pos(),To:p.safePos(x.End()));
                        }

                    }
                    break; 

                // all other nodes are expressions or types
            } 

            // all other nodes are expressions or types
            return x;
        });

        // If lhs is set and the result is an identifier, it is not resolved.
        private static ast.Expr parsePrimaryExpr(this ref parser _p, bool lhs) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "PrimaryExpr")));
            }
            var x = p.parseOperand(lhs);
L:

            while (true)
            {

                if (p.tok == token.PERIOD) 
                    p.next();
                    if (lhs)
                    {
                        p.resolve(x);
                    }

                    if (p.tok == token.IDENT) 
                        x = p.parseSelector(p.checkExprOrType(x));
                    else if (p.tok == token.LPAREN) 
                        x = p.parseTypeAssertion(p.checkExpr(x));
                    else 
                        var pos = p.pos;
                        p.errorExpected(pos, "selector or type assertion");
                        p.next(); // make progress
                        ast.Ident sel = ref new ast.Ident(NamePos:pos,Name:"_");
                        x = ref new ast.SelectorExpr(X:x,Sel:sel);
                                    else if (p.tok == token.LBRACK) 
                    if (lhs)
                    {
                        p.resolve(x);
                    }
                    x = p.parseIndexOrSlice(p.checkExpr(x));
                else if (p.tok == token.LPAREN) 
                    if (lhs)
                    {
                        p.resolve(x);
                    }
                    x = p.parseCallOrConversion(p.checkExprOrType(x));
                else if (p.tok == token.LBRACE) 
                    if (isLiteralType(x) && (p.exprLev >= 0L || !isTypeName(x)))
                    {
                        if (lhs)
                        {
                            p.resolve(x);
                        }
                        x = p.parseLiteralValue(x);
                    }
                    else
                    {
                        _breakL = true;
                        break;
                    }
                else 
                    _breakL = true;
                    break;
                                lhs = false; // no need to try to resolve again
            }

            return x;
        });

        // If lhs is set and the result is an identifier, it is not resolved.
        private static ast.Expr parseUnaryExpr(this ref parser _p, bool lhs) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "UnaryExpr")));
            }

            if (p.tok == token.ADD || p.tok == token.SUB || p.tok == token.NOT || p.tok == token.XOR || p.tok == token.AND) 
                var pos = p.pos;
                var op = p.tok;
                p.next();
                var x = p.parseUnaryExpr(false);
                return ref new ast.UnaryExpr(OpPos:pos,Op:op,X:p.checkExpr(x));
            else if (p.tok == token.ARROW) 
                // channel type or receive expression
                var arrow = p.pos;
                p.next(); 

                // If the next token is token.CHAN we still don't know if it
                // is a channel type or a receive operation - we only know
                // once we have found the end of the unary expression. There
                // are two cases:
                //
                //   <- type  => (<-type) must be channel type
                //   <- expr  => <-(expr) is a receive from an expression
                //
                // In the first case, the arrow must be re-associated with
                // the channel type parsed already:
                //
                //   <- (chan type)    =>  (<-chan type)
                //   <- (chan<- type)  =>  (<-chan (<-type))

                x = p.parseUnaryExpr(false); 

                // determine which case we have
                {
                    ref ast.ChanType (typ, ok) = x._<ref ast.ChanType>();

                    if (ok)
                    { 
                        // (<-type)

                        // re-associate position info and <-
                        var dir = ast.SEND;
                        while (ok && dir == ast.SEND)
                        {
                            if (typ.Dir == ast.RECV)
                            { 
                                // error: (<-type) is (<-(<-chan T))
                                p.errorExpected(typ.Arrow, "'chan'");
                            }
                            arrow = typ.Arrow;
                            typ.Begin = arrow;
                            typ.Arrow = arrow;
                            dir = typ.Dir;
                            typ.Dir = ast.RECV;
                            typ, ok = typ.Value._<ref ast.ChanType>();
                        }

                        if (dir == ast.SEND)
                        {
                            p.errorExpected(arrow, "channel type");
                        }
                        return x;
                    } 

                    // <-(expr)

                } 

                // <-(expr)
                return ref new ast.UnaryExpr(OpPos:arrow,Op:token.ARROW,X:p.checkExpr(x));
            else if (p.tok == token.MUL) 
                // pointer type or unary "*" expression
                pos = p.pos;
                p.next();
                x = p.parseUnaryExpr(false);
                return ref new ast.StarExpr(Star:pos,X:p.checkExprOrType(x));
                        return p.parsePrimaryExpr(lhs);
        });

        private static (token.Token, long) tokPrec(this ref parser p)
        {
            var tok = p.tok;
            if (p.inRhs && tok == token.ASSIGN)
            {
                tok = token.EQL;
            }
            return (tok, tok.Precedence());
        }

        // If lhs is set and the result is an identifier, it is not resolved.
        private static ast.Expr parseBinaryExpr(this ref parser _p, bool lhs, long prec1) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "BinaryExpr")));
            }
            var x = p.parseUnaryExpr(lhs);
            while (true)
            {
                var (op, oprec) = p.tokPrec();
                if (oprec < prec1)
                {
                    return x;
                }
                var pos = p.expect(op);
                if (lhs)
                {
                    p.resolve(x);
                    lhs = false;
                }
                var y = p.parseBinaryExpr(false, oprec + 1L);
                x = ref new ast.BinaryExpr(X:p.checkExpr(x),OpPos:pos,Op:op,Y:p.checkExpr(y));
            }

        });

        // If lhs is set and the result is an identifier, it is not resolved.
        // The result may be a type or even a raw type ([...]int). Callers must
        // check the result (using checkExpr or checkExprOrType), depending on
        // context.
        private static ast.Expr parseExpr(this ref parser _p, bool lhs) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Expression")));
            }
            return p.parseBinaryExpr(lhs, token.LowestPrec + 1L);
        });

        private static ast.Expr parseRhs(this ref parser p)
        {
            var old = p.inRhs;
            p.inRhs = true;
            var x = p.checkExpr(p.parseExpr(false));
            p.inRhs = old;
            return x;
        }

        private static ast.Expr parseRhsOrType(this ref parser p)
        {
            var old = p.inRhs;
            p.inRhs = true;
            var x = p.checkExprOrType(p.parseExpr(false));
            p.inRhs = old;
            return x;
        }

        // ----------------------------------------------------------------------------
        // Statements

        // Parsing modes for parseSimpleStmt.
        private static readonly var basic = iota;
        private static readonly var labelOk = 0;
        private static readonly var rangeOk = 1;

        // parseSimpleStmt returns true as 2nd result if it parsed the assignment
        // of a range clause (with mode == rangeOk). The returned statement is an
        // assignment with a right-hand side that is a single unary expression of
        // the form "range x". No guarantees are given for the left-hand side.
        private static (ast.Stmt, bool) parseSimpleStmt(this ref parser _p, long mode) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "SimpleStmt")));
            }
            var x = p.parseLhsList();


            if (p.tok == token.DEFINE || p.tok == token.ASSIGN || p.tok == token.ADD_ASSIGN || p.tok == token.SUB_ASSIGN || p.tok == token.MUL_ASSIGN || p.tok == token.QUO_ASSIGN || p.tok == token.REM_ASSIGN || p.tok == token.AND_ASSIGN || p.tok == token.OR_ASSIGN || p.tok == token.XOR_ASSIGN || p.tok == token.SHL_ASSIGN || p.tok == token.SHR_ASSIGN || p.tok == token.AND_NOT_ASSIGN) 
                // assignment statement, possibly part of a range clause
                var pos = p.pos;
                var tok = p.tok;
                p.next();
                slice<ast.Expr> y = default;
                var isRange = false;
                if (mode == rangeOk && p.tok == token.RANGE && (tok == token.DEFINE || tok == token.ASSIGN))
                {
                    pos = p.pos;
                    p.next();
                    y = new slice<ast.Expr>(new ast.Expr[] { &ast.UnaryExpr{OpPos:pos,Op:token.RANGE,X:p.parseRhs()} });
                    isRange = true;
                }
                else
                {
                    y = p.parseRhsList();
                }
                ast.AssignStmt @as = ref new ast.AssignStmt(Lhs:x,TokPos:pos,Tok:tok,Rhs:y);
                if (tok == token.DEFINE)
                {
                    p.shortVarDecl(as, x);
                }
                return (as, isRange);
                        if (len(x) > 1L)
            {
                p.errorExpected(x[0L].Pos(), "1 expression"); 
                // continue with first expression
            }

            if (p.tok == token.COLON) 
                // labeled statement
                var colon = p.pos;
                p.next();
                {
                    ref ast.Ident (label, isIdent) = x[0L]._<ref ast.Ident>();

                    if (mode == labelOk && isIdent)
                    { 
                        // Go spec: The scope of a label is the body of the function
                        // in which it is declared and excludes the body of any nested
                        // function.
                        ast.LabeledStmt stmt = ref new ast.LabeledStmt(Label:label,Colon:colon,Stmt:p.parseStmt());
                        p.declare(stmt, null, p.labelScope, ast.Lbl, label);
                        return (stmt, false);
                    } 
                    // The label declaration typically starts at x[0].Pos(), but the label
                    // declaration may be erroneous due to a token after that position (and
                    // before the ':'). If SpuriousErrors is not set, the (only) error
                    // reported for the line is the illegal label error instead of the token
                    // before the ':' that caused the problem. Thus, use the (latest) colon
                    // position for error reporting.

                } 
                // The label declaration typically starts at x[0].Pos(), but the label
                // declaration may be erroneous due to a token after that position (and
                // before the ':'). If SpuriousErrors is not set, the (only) error
                // reported for the line is the illegal label error instead of the token
                // before the ':' that caused the problem. Thus, use the (latest) colon
                // position for error reporting.
                p.error(colon, "illegal label declaration");
                return (ref new ast.BadStmt(From:x[0].Pos(),To:colon+1), false);
            else if (p.tok == token.ARROW) 
                // send statement
                var arrow = p.pos;
                p.next();
                y = p.parseRhs();
                return (ref new ast.SendStmt(Chan:x[0],Arrow:arrow,Value:y), false);
            else if (p.tok == token.INC || p.tok == token.DEC) 
                // increment or decrement
                ast.IncDecStmt s = ref new ast.IncDecStmt(X:x[0],TokPos:p.pos,Tok:p.tok);
                p.next();
                return (s, false);
            // expression
            return (ref new ast.ExprStmt(X:x[0]), false);
        });

        private static ref ast.CallExpr parseCallExpr(this ref parser p, @string callType)
        {
            var x = p.parseRhsOrType(); // could be a conversion: (some type)(x)
            {
                ref ast.CallExpr (call, isCall) = x._<ref ast.CallExpr>();

                if (isCall)
                {
                    return call;
                }

            }
            {
                ref ast.BadExpr (_, isBad) = x._<ref ast.BadExpr>();

                if (!isBad)
                { 
                    // only report error if it's a new one
                    p.error(p.safePos(x.End()), fmt.Sprintf("function must be invoked in %s statement", callType));
                }

            }
            return null;
        }

        private static ast.Stmt parseGoStmt(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "GoStmt")));
            }
            var pos = p.expect(token.GO);
            var call = p.parseCallExpr("go");
            p.expectSemi();
            if (call == null)
            {
                return ref new ast.BadStmt(From:pos,To:pos+2); // len("go")
            }
            return ref new ast.GoStmt(Go:pos,Call:call);
        });

        private static ast.Stmt parseDeferStmt(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "DeferStmt")));
            }
            var pos = p.expect(token.DEFER);
            var call = p.parseCallExpr("defer");
            p.expectSemi();
            if (call == null)
            {
                return ref new ast.BadStmt(From:pos,To:pos+5); // len("defer")
            }
            return ref new ast.DeferStmt(Defer:pos,Call:call);
        });

        private static ref ast.ReturnStmt parseReturnStmt(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "ReturnStmt")));
            }
            var pos = p.pos;
            p.expect(token.RETURN);
            slice<ast.Expr> x = default;
            if (p.tok != token.SEMICOLON && p.tok != token.RBRACE)
            {
                x = p.parseRhsList();
            }
            p.expectSemi();

            return ref new ast.ReturnStmt(Return:pos,Results:x);
        });

        private static ref ast.BranchStmt parseBranchStmt(this ref parser _p, token.Token tok) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "BranchStmt")));
            }
            var pos = p.expect(tok);
            ref ast.Ident label = default;
            if (tok != token.FALLTHROUGH && p.tok == token.IDENT)
            {
                label = p.parseIdent(); 
                // add to list of unresolved targets
                var n = len(p.targetStack) - 1L;
                p.targetStack[n] = append(p.targetStack[n], label);
            }
            p.expectSemi();

            return ref new ast.BranchStmt(TokPos:pos,Tok:tok,Label:label);
        });

        private static ast.Expr makeExpr(this ref parser p, ast.Stmt s, @string kind)
        {
            if (s == null)
            {
                return null;
            }
            {
                ref ast.ExprStmt (es, isExpr) = s._<ref ast.ExprStmt>();

                if (isExpr)
                {
                    return p.checkExpr(es.X);
                }

            }
            p.error(s.Pos(), fmt.Sprintf("expected %s, found simple statement (missing parentheses around composite literal?)", kind));
            return ref new ast.BadExpr(From:s.Pos(),To:p.safePos(s.End()));
        }

        private static ref ast.IfStmt parseIfStmt(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "IfStmt")));
            }
            var pos = p.expect(token.IF);
            p.openScope();
            defer(p.closeScope());

            ast.Stmt s = default;
            ast.Expr x = default;
            {
                var prevLev = p.exprLev;
                p.exprLev = -1L;
                if (p.tok == token.SEMICOLON)
                {
                    p.next();
                    x = p.parseRhs();
                }
                else
                {
                    s, _ = p.parseSimpleStmt(basic);
                    if (p.tok == token.SEMICOLON)
                    {
                        p.next();
                        x = p.parseRhs();
                    }
                    else
                    {
                        x = p.makeExpr(s, "boolean expression");
                        s = null;
                    }
                }
                p.exprLev = prevLev;
            }
            var body = p.parseBlockStmt();
            ast.Stmt else_ = default;
            if (p.tok == token.ELSE)
            {
                p.next();

                if (p.tok == token.IF) 
                    else_ = p.parseIfStmt();
                else if (p.tok == token.LBRACE) 
                    else_ = p.parseBlockStmt();
                    p.expectSemi();
                else 
                    p.errorExpected(p.pos, "if statement or block");
                    else_ = ref new ast.BadStmt(From:p.pos,To:p.pos);
                            }
            else
            {
                p.expectSemi();
            }
            return ref new ast.IfStmt(If:pos,Init:s,Cond:x,Body:body,Else:else_);
        });

        private static slice<ast.Expr> parseTypeList(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "TypeList")));
            }
            list = append(list, p.parseType());
            while (p.tok == token.COMMA)
            {
                p.next();
                list = append(list, p.parseType());
            }


            return;
        });

        private static ref ast.CaseClause parseCaseClause(this ref parser _p, bool typeSwitch) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "CaseClause")));
            }
            var pos = p.pos;
            slice<ast.Expr> list = default;
            if (p.tok == token.CASE)
            {
                p.next();
                if (typeSwitch)
                {
                    list = p.parseTypeList();
                }
                else
                {
                    list = p.parseRhsList();
                }
            }
            else
            {
                p.expect(token.DEFAULT);
            }
            var colon = p.expect(token.COLON);
            p.openScope();
            var body = p.parseStmtList();
            p.closeScope();

            return ref new ast.CaseClause(Case:pos,List:list,Colon:colon,Body:body);
        });

        private static bool isTypeSwitchAssert(ast.Expr x)
        {
            ref ast.TypeAssertExpr (a, ok) = x._<ref ast.TypeAssertExpr>();
            return ok && a.Type == null;
        }

        private static bool isTypeSwitchGuard(this ref parser p, ast.Stmt s)
        {
            switch (s.type())
            {
                case ref ast.ExprStmt t:
                    return isTypeSwitchAssert(t.X);
                    break;
                case ref ast.AssignStmt t:
                    if (len(t.Lhs) == 1L && len(t.Rhs) == 1L && isTypeSwitchAssert(t.Rhs[0L]))
                    {

                        if (t.Tok == token.ASSIGN) 
                        {
                            // permit v = x.(type) but complain
                            p.error(t.TokPos, "expected ':=', found '='");
                            fallthrough = true;
                        }
                        if (fallthrough || t.Tok == token.DEFINE)
                        {
                            return true;
                            goto __switch_break1;
                        }

                        __switch_break1:;
                    }
                    break;
            }
            return false;
        }

        private static ast.Stmt parseSwitchStmt(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "SwitchStmt")));
            }
            var pos = p.expect(token.SWITCH);
            p.openScope();
            defer(p.closeScope());

            ast.Stmt s1 = default;            ast.Stmt s2 = default;

            if (p.tok != token.LBRACE)
            {
                var prevLev = p.exprLev;
                p.exprLev = -1L;
                if (p.tok != token.SEMICOLON)
                {
                    s2, _ = p.parseSimpleStmt(basic);
                }
                if (p.tok == token.SEMICOLON)
                {
                    p.next();
                    s1 = s2;
                    s2 = null;
                    if (p.tok != token.LBRACE)
                    { 
                        // A TypeSwitchGuard may declare a variable in addition
                        // to the variable declared in the initial SimpleStmt.
                        // Introduce extra scope to avoid redeclaration errors:
                        //
                        //    switch t := 0; t := x.(T) { ... }
                        //
                        // (this code is not valid Go because the first t
                        // cannot be accessed and thus is never used, the extra
                        // scope is needed for the correct error message).
                        //
                        // If we don't have a type switch, s2 must be an expression.
                        // Having the extra nested but empty scope won't affect it.
                        p.openScope();
                        defer(p.closeScope());
                        s2, _ = p.parseSimpleStmt(basic);
                    }
                }
                p.exprLev = prevLev;
            }
            var typeSwitch = p.isTypeSwitchGuard(s2);
            var lbrace = p.expect(token.LBRACE);
            slice<ast.Stmt> list = default;
            while (p.tok == token.CASE || p.tok == token.DEFAULT)
            {
                list = append(list, p.parseCaseClause(typeSwitch));
            }

            var rbrace = p.expect(token.RBRACE);
            p.expectSemi();
            ast.BlockStmt body = ref new ast.BlockStmt(Lbrace:lbrace,List:list,Rbrace:rbrace);

            if (typeSwitch)
            {
                return ref new ast.TypeSwitchStmt(Switch:pos,Init:s1,Assign:s2,Body:body);
            }
            return ref new ast.SwitchStmt(Switch:pos,Init:s1,Tag:p.makeExpr(s2,"switch expression"),Body:body);
        });

        private static ref ast.CommClause parseCommClause(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "CommClause")));
            }
            p.openScope();
            var pos = p.pos;
            ast.Stmt comm = default;
            if (p.tok == token.CASE)
            {
                p.next();
                var lhs = p.parseLhsList();
                if (p.tok == token.ARROW)
                { 
                    // SendStmt
                    if (len(lhs) > 1L)
                    {
                        p.errorExpected(lhs[0L].Pos(), "1 expression"); 
                        // continue with first expression
                    }
                    var arrow = p.pos;
                    p.next();
                    var rhs = p.parseRhs();
                    comm = ref new ast.SendStmt(Chan:lhs[0],Arrow:arrow,Value:rhs);
                }
                else
                { 
                    // RecvStmt
                    {
                        var tok = p.tok;

                        if (tok == token.ASSIGN || tok == token.DEFINE)
                        { 
                            // RecvStmt with assignment
                            if (len(lhs) > 2L)
                            {
                                p.errorExpected(lhs[0L].Pos(), "1 or 2 expressions"); 
                                // continue with first two expressions
                                lhs = lhs[0L..2L];
                            }
                            pos = p.pos;
                            p.next();
                            rhs = p.parseRhs();
                            ast.AssignStmt @as = ref new ast.AssignStmt(Lhs:lhs,TokPos:pos,Tok:tok,Rhs:[]ast.Expr{rhs});
                            if (tok == token.DEFINE)
                            {
                                p.shortVarDecl(as, lhs);
                            }
                            comm = as;
                        }
                        else
                        { 
                            // lhs must be single receive operation
                            if (len(lhs) > 1L)
                            {
                                p.errorExpected(lhs[0L].Pos(), "1 expression"); 
                                // continue with first expression
                            }
                            comm = ref new ast.ExprStmt(X:lhs[0]);
                        }

                    }
                }
            }
            else
            {
                p.expect(token.DEFAULT);
            }
            var colon = p.expect(token.COLON);
            var body = p.parseStmtList();
            p.closeScope();

            return ref new ast.CommClause(Case:pos,Comm:comm,Colon:colon,Body:body);
        });

        private static ref ast.SelectStmt parseSelectStmt(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "SelectStmt")));
            }
            var pos = p.expect(token.SELECT);
            var lbrace = p.expect(token.LBRACE);
            slice<ast.Stmt> list = default;
            while (p.tok == token.CASE || p.tok == token.DEFAULT)
            {
                list = append(list, p.parseCommClause());
            }

            var rbrace = p.expect(token.RBRACE);
            p.expectSemi();
            ast.BlockStmt body = ref new ast.BlockStmt(Lbrace:lbrace,List:list,Rbrace:rbrace);

            return ref new ast.SelectStmt(Select:pos,Body:body);
        });

        private static ast.Stmt parseForStmt(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "ForStmt")));
            }
            var pos = p.expect(token.FOR);
            p.openScope();
            defer(p.closeScope());

            ast.Stmt s1 = default;            ast.Stmt s2 = default;            ast.Stmt s3 = default;

            bool isRange = default;
            if (p.tok != token.LBRACE)
            {
                var prevLev = p.exprLev;
                p.exprLev = -1L;
                if (p.tok != token.SEMICOLON)
                {
                    if (p.tok == token.RANGE)
                    { 
                        // "for range x" (nil lhs in assignment)
                        pos = p.pos;
                        p.next();
                        ast.Expr y = new slice<ast.Expr>(new ast.Expr[] { &ast.UnaryExpr{OpPos:pos,Op:token.RANGE,X:p.parseRhs()} });
                        s2 = ref new ast.AssignStmt(Rhs:y);
                        isRange = true;
                    }
                    else
                    {
                        s2, isRange = p.parseSimpleStmt(rangeOk);
                    }
                }
                if (!isRange && p.tok == token.SEMICOLON)
                {
                    p.next();
                    s1 = s2;
                    s2 = null;
                    if (p.tok != token.SEMICOLON)
                    {
                        s2, _ = p.parseSimpleStmt(basic);
                    }
                    p.expectSemi();
                    if (p.tok != token.LBRACE)
                    {
                        s3, _ = p.parseSimpleStmt(basic);
                    }
                }
                p.exprLev = prevLev;
            }
            var body = p.parseBlockStmt();
            p.expectSemi();

            if (isRange)
            {
                ref ast.AssignStmt @as = s2._<ref ast.AssignStmt>(); 
                // check lhs
                ast.Expr key = default;                ast.Expr value = default;

                switch (len(@as.Lhs))
                {
                    case 0L: 
                        break;
                    case 1L: 
                        key = @as.Lhs[0L];
                        break;
                    case 2L: 
                        key = @as.Lhs[0L];
                        value = @as.Lhs[1L];
                        break;
                    default: 
                        p.errorExpected(@as.Lhs[len(@as.Lhs) - 1L].Pos(), "at most 2 expressions");
                        return ref new ast.BadStmt(From:pos,To:p.safePos(body.End()));
                        break;
                } 
                // parseSimpleStmt returned a right-hand side that
                // is a single unary expression of the form "range x"
                ref ast.UnaryExpr x = @as.Rhs[0L]._<ref ast.UnaryExpr>().X;
                return ref new ast.RangeStmt(For:pos,Key:key,Value:value,TokPos:as.TokPos,Tok:as.Tok,X:x,Body:body,);
            } 

            // regular for statement
            return ref new ast.ForStmt(For:pos,Init:s1,Cond:p.makeExpr(s2,"boolean or range expression"),Post:s3,Body:body,);
        });

        private static ast.Stmt parseStmt(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Statement")));
            }

            if (p.tok == token.CONST || p.tok == token.TYPE || p.tok == token.VAR) 
                s = ref new ast.DeclStmt(Decl:p.parseDecl(syncStmt));
            else if (p.tok == token.IDENT || p.tok == token.INT || p.tok == token.FLOAT || p.tok == token.IMAG || p.tok == token.CHAR || p.tok == token.STRING || p.tok == token.FUNC || p.tok == token.LPAREN || p.tok == token.LBRACK || p.tok == token.STRUCT || p.tok == token.MAP || p.tok == token.CHAN || p.tok == token.INTERFACE || p.tok == token.ADD || p.tok == token.SUB || p.tok == token.MUL || p.tok == token.AND || p.tok == token.XOR || p.tok == token.ARROW || p.tok == token.NOT) // unary operators
                s, _ = p.parseSimpleStmt(labelOk); 
                // because of the required look-ahead, labeled statements are
                // parsed by parseSimpleStmt - don't expect a semicolon after
                // them
                {
                    ref ast.LabeledStmt (_, isLabeledStmt) = s._<ref ast.LabeledStmt>();

                    if (!isLabeledStmt)
                    {
                        p.expectSemi();
                    }

                }
            else if (p.tok == token.GO) 
                s = p.parseGoStmt();
            else if (p.tok == token.DEFER) 
                s = p.parseDeferStmt();
            else if (p.tok == token.RETURN) 
                s = p.parseReturnStmt();
            else if (p.tok == token.BREAK || p.tok == token.CONTINUE || p.tok == token.GOTO || p.tok == token.FALLTHROUGH) 
                s = p.parseBranchStmt(p.tok);
            else if (p.tok == token.LBRACE) 
                s = p.parseBlockStmt();
                p.expectSemi();
            else if (p.tok == token.IF) 
                s = p.parseIfStmt();
            else if (p.tok == token.SWITCH) 
                s = p.parseSwitchStmt();
            else if (p.tok == token.SELECT) 
                s = p.parseSelectStmt();
            else if (p.tok == token.FOR) 
                s = p.parseForStmt();
            else if (p.tok == token.SEMICOLON) 
                // Is it ever possible to have an implicit semicolon
                // producing an empty statement in a valid program?
                // (handle correctly anyway)
                s = ref new ast.EmptyStmt(Semicolon:p.pos,Implicit:p.lit=="\n");
                p.next();
            else if (p.tok == token.RBRACE) 
                // a semicolon may be omitted before a closing "}"
                s = ref new ast.EmptyStmt(Semicolon:p.pos,Implicit:true);
            else 
                // no statement found
                var pos = p.pos;
                p.errorExpected(pos, "statement");
                syncStmt(p);
                s = ref new ast.BadStmt(From:pos,To:p.pos);
                        return;
        });

        // ----------------------------------------------------------------------------
        // Declarations

        public delegate  ast.Spec parseSpecFunction(ref ast.CommentGroup,  token.Token,  long);

        private static bool isValidImport(@string lit)
        {
            const @string illegalChars = "!\"#$%&\'()*,:;<=>?[\\]^{|}" + "`\uFFFD";

            var (s, _) = strconv.Unquote(lit); // go/scanner returns a legal string literal
            foreach (var (_, r) in s)
            {
                if (!unicode.IsGraphic(r) || unicode.IsSpace(r) || strings.ContainsRune(illegalChars, r))
                {
                    return false;
                }
            }
            return s != "";
        }

        private static ast.Spec parseImportSpec(this ref parser _p, ref ast.CommentGroup _doc, token.Token _, long _) => func(_p, _doc, (ref parser p, ref ast.CommentGroup doc, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "ImportSpec")));
            }
            ref ast.Ident ident = default;

            if (p.tok == token.PERIOD) 
                ident = ref new ast.Ident(NamePos:p.pos,Name:".");
                p.next();
            else if (p.tok == token.IDENT) 
                ident = p.parseIdent();
                        var pos = p.pos;
            @string path = default;
            if (p.tok == token.STRING)
            {
                path = p.lit;
                if (!isValidImport(path))
                {
                    p.error(pos, "invalid import path: " + path);
                }
                p.next();
            }
            else
            {
                p.expect(token.STRING); // use expect() error handling
            }
            p.expectSemi(); // call before accessing p.linecomment

            // collect imports
            ast.ImportSpec spec = ref new ast.ImportSpec(Doc:doc,Name:ident,Path:&ast.BasicLit{ValuePos:pos,Kind:token.STRING,Value:path},Comment:p.lineComment,);
            p.imports = append(p.imports, spec);

            return spec;
        });

        private static ast.Spec parseValueSpec(this ref parser _p, ref ast.CommentGroup _doc, token.Token keyword, long iota) => func(_p, _doc, (ref parser p, ref ast.CommentGroup doc, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, keyword.String() + "Spec")));
            }
            var pos = p.pos;
            var idents = p.parseIdentList();
            var typ = p.tryType();
            slice<ast.Expr> values = default; 
            // always permit optional initialization for more tolerant parsing
            if (p.tok == token.ASSIGN)
            {
                p.next();
                values = p.parseRhsList();
            }
            p.expectSemi(); // call before accessing p.linecomment


            if (keyword == token.VAR) 
                if (typ == null && values == null)
                {
                    p.error(pos, "missing variable type or initialization");
                }
            else if (keyword == token.CONST) 
                if (values == null && (iota == 0L || typ != null))
                {
                    p.error(pos, "missing constant value");
                }
            // Go spec: The scope of a constant or variable identifier declared inside
            // a function begins at the end of the ConstSpec or VarSpec and ends at
            // the end of the innermost containing block.
            // (Global identifiers are resolved in a separate phase after parsing.)
            ast.ValueSpec spec = ref new ast.ValueSpec(Doc:doc,Names:idents,Type:typ,Values:values,Comment:p.lineComment,);
            var kind = ast.Con;
            if (keyword == token.VAR)
            {
                kind = ast.Var;
            }
            p.declare(spec, iota, p.topScope, kind, idents);

            return spec;
        });

        private static ast.Spec parseTypeSpec(this ref parser _p, ref ast.CommentGroup _doc, token.Token _, long _) => func(_p, _doc, (ref parser p, ref ast.CommentGroup doc, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "TypeSpec")));
            }
            var ident = p.parseIdent(); 

            // Go spec: The scope of a type identifier declared inside a function begins
            // at the identifier in the TypeSpec and ends at the end of the innermost
            // containing block.
            // (Global identifiers are resolved in a separate phase after parsing.)
            ast.TypeSpec spec = ref new ast.TypeSpec(Doc:doc,Name:ident);
            p.declare(spec, null, p.topScope, ast.Typ, ident);
            if (p.tok == token.ASSIGN)
            {
                spec.Assign = p.pos;
                p.next();
            }
            spec.Type = p.parseType();
            p.expectSemi(); // call before accessing p.linecomment
            spec.Comment = p.lineComment;

            return spec;
        });

        private static ref ast.GenDecl parseGenDecl(this ref parser _p, token.Token keyword, parseSpecFunction f) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "GenDecl(" + keyword.String() + ")")));
            }
            var doc = p.leadComment;
            var pos = p.expect(keyword);
            token.Pos lparen = default;            token.Pos rparen = default;

            slice<ast.Spec> list = default;
            if (p.tok == token.LPAREN)
            {
                lparen = p.pos;
                p.next();
                for (long iota = 0L; p.tok != token.RPAREN && p.tok != token.EOF; iota++)
                {
                    list = append(list, f(p.leadComment, keyword, iota));
                }
            else

                rparen = p.expect(token.RPAREN);
                p.expectSemi();
            }            {
                list = append(list, f(null, keyword, 0L));
            }
            return ref new ast.GenDecl(Doc:doc,TokPos:pos,Tok:keyword,Lparen:lparen,Specs:list,Rparen:rparen,);
        });

        private static ref ast.FuncDecl parseFuncDecl(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "FunctionDecl")));
            }
            var doc = p.leadComment;
            var pos = p.expect(token.FUNC);
            var scope = ast.NewScope(p.topScope); // function scope

            ref ast.FieldList recv = default;
            if (p.tok == token.LPAREN)
            {
                recv = p.parseParameters(scope, false);
            }
            var ident = p.parseIdent();

            var (params, results) = p.parseSignature(scope);

            ref ast.BlockStmt body = default;
            if (p.tok == token.LBRACE)
            {
                body = p.parseBody(scope);
            }
            p.expectSemi();

            ast.FuncDecl decl = ref new ast.FuncDecl(Doc:doc,Recv:recv,Name:ident,Type:&ast.FuncType{Func:pos,Params:params,Results:results,},Body:body,);
            if (recv == null)
            { 
                // Go spec: The scope of an identifier denoting a constant, type,
                // variable, or function (but not method) declared at top level
                // (outside any function) is the package block.
                //
                // init() functions cannot be referred to and there may
                // be more than one - don't put them in the pkgScope
                if (ident.Name != "init")
                {
                    p.declare(decl, null, p.pkgScope, ast.Fun, ident);
                }
            }
            return decl;
        });

        private static ast.Decl parseDecl(this ref parser _p, Action<ref parser> sync) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "Declaration")));
            }
            parseSpecFunction f = default;

            if (p.tok == token.CONST || p.tok == token.VAR) 
                f = p.parseValueSpec;
            else if (p.tok == token.TYPE) 
                f = p.parseTypeSpec;
            else if (p.tok == token.FUNC) 
                return p.parseFuncDecl();
            else 
                var pos = p.pos;
                p.errorExpected(pos, "declaration");
                sync(p);
                return ref new ast.BadDecl(From:pos,To:p.pos);
                        return p.parseGenDecl(p.tok, f);
        });

        // ----------------------------------------------------------------------------
        // Source files

        private static ref ast.File parseFile(this ref parser _p) => func(_p, (ref parser p, Defer defer, Panic _, Recover __) =>
        {
            if (p.trace)
            {
                defer(un(trace(p, "File")));
            } 

            // Don't bother parsing the rest if we had errors scanning the first token.
            // Likely not a Go source file at all.
            if (p.errors.Len() != 0L)
            {
                return null;
            } 

            // package clause
            var doc = p.leadComment;
            var pos = p.expect(token.PACKAGE); 
            // Go spec: The package clause is not a declaration;
            // the package name does not appear in any scope.
            var ident = p.parseIdent();
            if (ident.Name == "_" && p.mode & DeclarationErrors != 0L)
            {
                p.error(p.pos, "invalid package name _");
            }
            p.expectSemi(); 

            // Don't bother parsing the rest if we had errors parsing the package clause.
            // Likely not a Go source file at all.
            if (p.errors.Len() != 0L)
            {
                return null;
            }
            p.openScope();
            p.pkgScope = p.topScope;
            slice<ast.Decl> decls = default;
            if (p.mode & PackageClauseOnly == 0L)
            { 
                // import decls
                while (p.tok == token.IMPORT)
                {
                    decls = append(decls, p.parseGenDecl(token.IMPORT, p.parseImportSpec));
                }


                if (p.mode & ImportsOnly == 0L)
                { 
                    // rest of package body
                    while (p.tok != token.EOF)
                    {
                        decls = append(decls, p.parseDecl(syncDecl));
                    }

                }
            }
            p.closeScope();
            assert(p.topScope == null, "unbalanced scopes");
            assert(p.labelScope == null, "unbalanced label scopes"); 

            // resolve global identifiers within the same file
            long i = 0L;
            {
                var ident__prev1 = ident;

                foreach (var (_, __ident) in p.unresolved)
                {
                    ident = __ident; 
                    // i <= index for current ident
                    assert(ident.Obj == unresolved, "object already resolved");
                    ident.Obj = p.pkgScope.Lookup(ident.Name); // also removes unresolved sentinel
                    if (ident.Obj == null)
                    {
                        p.unresolved[i] = ident;
                        i++;
                    }
                }

                ident = ident__prev1;
            }

            return ref new ast.File(Doc:doc,Package:pos,Name:ident,Decls:decls,Scope:p.pkgScope,Imports:p.imports,Unresolved:p.unresolved[0:i],Comments:p.comments,);
        });
    }
}}