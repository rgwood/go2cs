//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:01:29 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using sha256 = go.crypto.sha256_package;
using gob = go.encoding.gob_package;
using json = go.encoding.json_package;
using flag = go.flag_package;
using fmt = go.fmt_package;
using token = go.go.token_package;
using io = go.io_package;
using ioutil = go.io.ioutil_package;
using log = go.log_package;
using os = go.os_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using analysis = go.golang.org.x.tools.go.analysis_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace tools {
namespace go {
namespace analysis {
namespace @internal
{
    public static partial class analysisflags_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct jsonFlag
        {
            // Constructors
            public jsonFlag(NilType _)
            {
                this.Name = default;
                this.Bool = default;
                this.Usage = default;
            }

            public jsonFlag(@string Name = default, bool Bool = default, @string Usage = default)
            {
                this.Name = Name;
                this.Bool = Bool;
                this.Usage = Usage;
            }

            // Enable comparisons between nil and jsonFlag struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(jsonFlag value, NilType nil) => value.Equals(default(jsonFlag));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(jsonFlag value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, jsonFlag value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, jsonFlag value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator jsonFlag(NilType nil) => default(jsonFlag);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static jsonFlag jsonFlag_cast(dynamic value)
        {
            return new jsonFlag(value.Name, value.Bool, value.Usage);
        }
    }
}}}}}}}