//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:53:34 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using fmt = go.fmt_package;
using template = go.html.template_package;
using net = go.net_package;
using http = go.net.http_package;
using gourl = go.net.url_package;
using os = go.os_package;
using exec = go.os.exec_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using time = go.time_package;
using graph = go.github.com.google.pprof.@internal.graph_package;
using plugin = go.github.com.google.pprof.@internal.plugin_package;
using report = go.github.com.google.pprof.@internal.report_package;
using profile = go.github.com.google.pprof.profile_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace vendor {
namespace github.com {
namespace google {
namespace pprof {
namespace @internal
{
    public static partial class driver_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct webArgs
        {
            // Constructors
            public webArgs(NilType _)
            {
                this.Title = default;
                this.Errors = default;
                this.Total = default;
                this.SampleTypes = default;
                this.Legend = default;
                this.Help = default;
                this.Nodes = default;
                this.HTMLBody = default;
                this.TextBody = default;
                this.Top = default;
                this.FlameGraph = default;
            }

            public webArgs(@string Title = default, slice<@string> Errors = default, long Total = default, slice<@string> SampleTypes = default, slice<@string> Legend = default, map<@string, @string> Help = default, slice<@string> Nodes = default, template.HTML HTMLBody = default, @string TextBody = default, slice<report.TextItem> Top = default, template.JS FlameGraph = default)
            {
                this.Title = Title;
                this.Errors = Errors;
                this.Total = Total;
                this.SampleTypes = SampleTypes;
                this.Legend = Legend;
                this.Help = Help;
                this.Nodes = Nodes;
                this.HTMLBody = HTMLBody;
                this.TextBody = TextBody;
                this.Top = Top;
                this.FlameGraph = FlameGraph;
            }

            // Enable comparisons between nil and webArgs struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(webArgs value, NilType nil) => value.Equals(default(webArgs));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(webArgs value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, webArgs value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, webArgs value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator webArgs(NilType nil) => default(webArgs);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static webArgs webArgs_cast(dynamic value)
        {
            return new webArgs(value.Title, value.Errors, value.Total, value.SampleTypes, value.Legend, value.Help, value.Nodes, value.HTMLBody, value.TextBody, value.Top, value.FlameGraph);
        }
    }
}}}}}}}