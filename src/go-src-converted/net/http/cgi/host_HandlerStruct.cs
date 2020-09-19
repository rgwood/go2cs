//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:34:04 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bufio = go.bufio_package;
using fmt = go.fmt_package;
using io = go.io_package;
using log = go.log_package;
using net = go.net_package;
using http = go.net.http_package;
using os = go.os_package;
using exec = go.os.exec_package;
using filepath = go.path.filepath_package;
using regexp = go.regexp_package;
using runtime = go.runtime_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using go;

namespace go {
namespace net {
namespace http
{
    public static partial class cgi_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Handler
        {
            // Constructors
            public Handler(NilType _)
            {
                this.Path = default;
                this.Root = default;
                this.Dir = default;
                this.Env = default;
                this.InheritEnv = default;
                this.Logger = default;
                this.Args = default;
                this.Stderr = default;
                this.PathLocationHandler = default;
            }

            public Handler(@string Path = default, @string Root = default, @string Dir = default, slice<@string> Env = default, slice<@string> InheritEnv = default, ref ptr<log.Logger> Logger = default, slice<@string> Args = default, io.Writer Stderr = default, http.Handler PathLocationHandler = default)
            {
                this.Path = Path;
                this.Root = Root;
                this.Dir = Dir;
                this.Env = Env;
                this.InheritEnv = InheritEnv;
                this.Logger = Logger;
                this.Args = Args;
                this.Stderr = Stderr;
                this.PathLocationHandler = PathLocationHandler;
            }

            // Enable comparisons between nil and Handler struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Handler value, NilType nil) => value.Equals(default(Handler));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Handler value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Handler value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Handler value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Handler(NilType nil) => default(Handler);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Handler Handler_cast(dynamic value)
        {
            return new Handler(value.Path, value.Root, value.Dir, value.Env, value.InheritEnv, ref value.Logger, value.Args, value.Stderr, value.PathLocationHandler);
        }
    }
}}}