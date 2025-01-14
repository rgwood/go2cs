//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:56:20 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using errors = go.errors_package;
using fmt = go.fmt_package;
using io = go.io_package;
using mime = go.mime_package;
using multipart = go.mime.multipart_package;
using textproto = go.net.textproto_package;
using url = go.net.url_package;
using os = go.os_package;
using path = go.path_package;
using filepath = go.path.filepath_package;
using sort = go.sort_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using time = go.time_package;
using go;

#nullable enable
#pragma warning disable CS0660, CS0661

namespace go {
namespace net
{
    public static partial class http_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial interface FileSystem
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static FileSystem As<T>(in T target) => (FileSystem<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static FileSystem As<T>(ptr<T> target_ptr) => (FileSystem<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static FileSystem? As(object target) =>
                typeof(FileSystem<>).CreateInterfaceHandler<FileSystem>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public class FileSystem<T> : FileSystem
        {
            private T m_target = default!;
            private readonly ptr<T>? m_target_ptr;
            private readonly bool m_target_is_ptr;

            public ref T Target
            {
                get
                {
                    if (m_target_is_ptr && !(m_target_ptr is null))
                        return ref m_target_ptr.val;

                    return ref m_target;
                }
            }

            public FileSystem(in T target) => m_target = target;

            public FileSystem(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate (File, error) OpenByPtr(ptr<T> value, @string name);
            private delegate (File, error) OpenByVal(T value, @string name);

            private static readonly OpenByPtr? s_OpenByPtr;
            private static readonly OpenByVal? s_OpenByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (File, error) Open(@string name)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_OpenByPtr is null || !m_target_is_ptr)
                    return s_OpenByVal!(target, name);

                return s_OpenByPtr(m_target_ptr, name);
            }
            
            public string ToString(string? format, IFormatProvider? formatProvider) => format;

            [DebuggerStepperBoundary]
            static FileSystem()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Open");

                if (!(extensionMethod is null))
                    s_OpenByPtr = extensionMethod.CreateStaticDelegate(typeof(OpenByPtr)) as OpenByPtr;

                extensionMethod = targetType.GetExtensionMethod("Open");

                if (!(extensionMethod is null))
                    s_OpenByVal = extensionMethod.CreateStaticDelegate(typeof(OpenByVal)) as OpenByVal;

                if (s_OpenByPtr is null && s_OpenByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement FileSystem.Open method", new Exception("Open"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator FileSystem<T>(in ptr<T> target_ptr) => new FileSystem<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator FileSystem<T>(in T target) => new FileSystem<T>(target);

            // Enable comparisons between nil and FileSystem<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(FileSystem<T> value, NilType nil) => Activator.CreateInstance<FileSystem<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(FileSystem<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, FileSystem<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, FileSystem<T> value) => value != nil;
        }
    }
}}

namespace go
{
    public static class http_FileSystemExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.net.http_package.FileSystem target)
        {
            try
            {
                return ((go.net.http_package.FileSystem<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.net.http_package.FileSystem target, out T result)
        {
            try
            {
                result = target._<T>();
                return true;
            }
            catch (PanicException)
            {
                result = default!;
                return false;
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static object? _(this go.net.http_package.FileSystem target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.net.http_package.FileSystem<>).GetExplicitGenericConversionOperator(type));

                if (conversionOperator is null)
                    throw new PanicException($"interface conversion: failed to create converter for {GetGoTypeName(target.GetType())} to {GetGoTypeName(type)}");

                dynamic? result = conversionOperator.Invoke(null, new object[] { target });
                return result?.Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(type)}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _(this go.net.http_package.FileSystem target, Type type, out object? result)
        {
            try
            {
                result = target._(type);
                return true;
            }
            catch (PanicException)
            {
                result = type.IsValueType ? Activator.CreateInstance(type) : null;
                return false;
            }
        }
    }
}