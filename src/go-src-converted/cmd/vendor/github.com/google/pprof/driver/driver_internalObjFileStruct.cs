//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:53:18 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using io = go.io_package;
using http = go.net.http_package;
using regexp = go.regexp_package;
using time = go.time_package;
using internaldriver = go.github.com.google.pprof.@internal.driver_package;
using plugin = go.github.com.google.pprof.@internal.plugin_package;
using profile = go.github.com.google.pprof.profile_package;
using go;

#nullable enable

namespace go {
namespace cmd {
namespace vendor {
namespace github.com {
namespace google {
namespace pprof
{
    public static partial class driver_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial struct internalObjFile
        {
            // ObjFile.Name function promotion
            private delegate error NameByVal(T value);
            private delegate error NameByRef(ref T value);

            private static readonly NameByVal s_NameByVal;
            private static readonly NameByRef s_NameByRef;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public error Name() => s_NameByRef?.Invoke(ref this) ?? s_NameByVal?.Invoke(this) ?? ObjFile?.Name() ?? throw new PanicException(RuntimeErrorPanic.NilPointerDereference);

            // ObjFile.Base function promotion
            private delegate error BaseByVal(T value);
            private delegate error BaseByRef(ref T value);

            private static readonly BaseByVal s_BaseByVal;
            private static readonly BaseByRef s_BaseByRef;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public error Base() => s_BaseByRef?.Invoke(ref this) ?? s_BaseByVal?.Invoke(this) ?? ObjFile?.Base() ?? throw new PanicException(RuntimeErrorPanic.NilPointerDereference);

            // ObjFile.BuildID function promotion
            private delegate error BuildIDByVal(T value);
            private delegate error BuildIDByRef(ref T value);

            private static readonly BuildIDByVal s_BuildIDByVal;
            private static readonly BuildIDByRef s_BuildIDByRef;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public error BuildID() => s_BuildIDByRef?.Invoke(ref this) ?? s_BuildIDByVal?.Invoke(this) ?? ObjFile?.BuildID() ?? throw new PanicException(RuntimeErrorPanic.NilPointerDereference);

            // ObjFile.SourceLine function promotion
            private delegate error SourceLineByVal(T value, ulong addr);
            private delegate error SourceLineByRef(ref T value, ulong addr);

            private static readonly SourceLineByVal s_SourceLineByVal;
            private static readonly SourceLineByRef s_SourceLineByRef;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public error SourceLine(ulong addr) => s_SourceLineByRef?.Invoke(ref this, addr) ?? s_SourceLineByVal?.Invoke(this, addr) ?? ObjFile?.SourceLine(addr) ?? throw new PanicException(RuntimeErrorPanic.NilPointerDereference);

            // ObjFile.Symbols function promotion
            private delegate error SymbolsByVal(T value, ptr<regexp.Regexp> r, ulong addr);
            private delegate error SymbolsByRef(ref T value, ptr<regexp.Regexp> r, ulong addr);

            private static readonly SymbolsByVal s_SymbolsByVal;
            private static readonly SymbolsByRef s_SymbolsByRef;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public error Symbols(ptr<regexp.Regexp> r, ulong addr) => s_SymbolsByRef?.Invoke(ref this, r, addr) ?? s_SymbolsByVal?.Invoke(this, r, addr) ?? ObjFile?.Symbols(r, addr) ?? throw new PanicException(RuntimeErrorPanic.NilPointerDereference);

            // ObjFile.Close function promotion
            private delegate error CloseByVal(T value);
            private delegate error CloseByRef(ref T value);

            private static readonly CloseByVal s_CloseByVal;
            private static readonly CloseByRef s_CloseByRef;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public error Close() => s_CloseByRef?.Invoke(ref this) ?? s_CloseByVal?.Invoke(this) ?? ObjFile?.Close() ?? throw new PanicException(RuntimeErrorPanic.NilPointerDereference);
            
            [DebuggerStepperBoundary]
            static internalObjFile()
            {
                Type targetType = typeof(internalObjFile);
                MethodInfo extensionMethod;
                
                extensionMethod = targetType.GetExtensionMethodSearchingPromotions("Name");

                if ((object)extensionMethod != null)
                {
                    s_NameByRef = extensionMethod.CreateStaticDelegate(typeof(NameByRef)) as NameByRef;

                    if ((object)s_NameByRef == null)
                        s_NameByVal = extensionMethod.CreateStaticDelegate(typeof(NameByVal)) as NameByVal;
                }
                
                extensionMethod = targetType.GetExtensionMethodSearchingPromotions("Base");

                if ((object)extensionMethod != null)
                {
                    s_BaseByRef = extensionMethod.CreateStaticDelegate(typeof(BaseByRef)) as BaseByRef;

                    if ((object)s_BaseByRef == null)
                        s_BaseByVal = extensionMethod.CreateStaticDelegate(typeof(BaseByVal)) as BaseByVal;
                }
                
                extensionMethod = targetType.GetExtensionMethodSearchingPromotions("BuildID");

                if ((object)extensionMethod != null)
                {
                    s_BuildIDByRef = extensionMethod.CreateStaticDelegate(typeof(BuildIDByRef)) as BuildIDByRef;

                    if ((object)s_BuildIDByRef == null)
                        s_BuildIDByVal = extensionMethod.CreateStaticDelegate(typeof(BuildIDByVal)) as BuildIDByVal;
                }
                
                extensionMethod = targetType.GetExtensionMethodSearchingPromotions("SourceLine");

                if ((object)extensionMethod != null)
                {
                    s_SourceLineByRef = extensionMethod.CreateStaticDelegate(typeof(SourceLineByRef)) as SourceLineByRef;

                    if ((object)s_SourceLineByRef == null)
                        s_SourceLineByVal = extensionMethod.CreateStaticDelegate(typeof(SourceLineByVal)) as SourceLineByVal;
                }
                
                extensionMethod = targetType.GetExtensionMethodSearchingPromotions("Symbols");

                if ((object)extensionMethod != null)
                {
                    s_SymbolsByRef = extensionMethod.CreateStaticDelegate(typeof(SymbolsByRef)) as SymbolsByRef;

                    if ((object)s_SymbolsByRef == null)
                        s_SymbolsByVal = extensionMethod.CreateStaticDelegate(typeof(SymbolsByVal)) as SymbolsByVal;
                }
                
                extensionMethod = targetType.GetExtensionMethodSearchingPromotions("Close");

                if ((object)extensionMethod != null)
                {
                    s_CloseByRef = extensionMethod.CreateStaticDelegate(typeof(CloseByRef)) as CloseByRef;

                    if ((object)s_CloseByRef == null)
                        s_CloseByVal = extensionMethod.CreateStaticDelegate(typeof(CloseByVal)) as CloseByVal;
                }
            }

            // Constructors
            public internalObjFile(NilType _)
            {
                this.ObjFile = default;
            }

            public internalObjFile(ObjFile ObjFile = default)
            {
                this.ObjFile = ObjFile;
            }

            // Enable comparisons between nil and internalObjFile struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(internalObjFile value, NilType nil) => value.Equals(default(internalObjFile));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(internalObjFile value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, internalObjFile value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, internalObjFile value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator internalObjFile(NilType nil) => default(internalObjFile);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static internalObjFile internalObjFile_cast(dynamic value)
        {
            return new internalObjFile(value.ObjFile);
        }
    }
}}}}}}