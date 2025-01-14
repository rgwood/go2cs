//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:00:33 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bufio = go.bufio_package;
using gob = go.encoding.gob_package;
using errors = go.errors_package;
using io = go.io_package;
using log = go.log_package;
using net = go.net_package;
using http = go.net.http_package;
using sync = go.sync_package;
using go;

#nullable enable
#pragma warning disable CS0660, CS0661

namespace go {
namespace net
{
    public static partial class rpc_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial interface ClientCodec
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static ClientCodec As<T>(in T target) => (ClientCodec<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static ClientCodec As<T>(ptr<T> target_ptr) => (ClientCodec<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static ClientCodec? As(object target) =>
                typeof(ClientCodec<>).CreateInterfaceHandler<ClientCodec>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public class ClientCodec<T> : ClientCodec
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

            public ClientCodec(in T target) => m_target = target;

            public ClientCodec(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate error WriteRequestByPtr(ptr<T> value, ptr<Request> _p0, object _p0);
            private delegate error WriteRequestByVal(T value, ptr<Request> _p0, object _p0);

            private static readonly WriteRequestByPtr? s_WriteRequestByPtr;
            private static readonly WriteRequestByVal? s_WriteRequestByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public error WriteRequest(ptr<Request> _p0, object _p0)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_WriteRequestByPtr is null || !m_target_is_ptr)
                    return s_WriteRequestByVal!(target, _p0, _p0);

                return s_WriteRequestByPtr(m_target_ptr, _p0, _p0);
            }

            private delegate error ReadResponseHeaderByPtr(ptr<T> value, ptr<Response> _p0);
            private delegate error ReadResponseHeaderByVal(T value, ptr<Response> _p0);

            private static readonly ReadResponseHeaderByPtr? s_ReadResponseHeaderByPtr;
            private static readonly ReadResponseHeaderByVal? s_ReadResponseHeaderByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public error ReadResponseHeader(ptr<Response> _p0)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_ReadResponseHeaderByPtr is null || !m_target_is_ptr)
                    return s_ReadResponseHeaderByVal!(target, _p0);

                return s_ReadResponseHeaderByPtr(m_target_ptr, _p0);
            }

            private delegate error ReadResponseBodyByPtr(ptr<T> value, object _p0);
            private delegate error ReadResponseBodyByVal(T value, object _p0);

            private static readonly ReadResponseBodyByPtr? s_ReadResponseBodyByPtr;
            private static readonly ReadResponseBodyByVal? s_ReadResponseBodyByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public error ReadResponseBody(object _p0)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_ReadResponseBodyByPtr is null || !m_target_is_ptr)
                    return s_ReadResponseBodyByVal!(target, _p0);

                return s_ReadResponseBodyByPtr(m_target_ptr, _p0);
            }

            private delegate error CloseByPtr(ptr<T> value);
            private delegate error CloseByVal(T value);

            private static readonly CloseByPtr? s_CloseByPtr;
            private static readonly CloseByVal? s_CloseByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public error Close()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_CloseByPtr is null || !m_target_is_ptr)
                    return s_CloseByVal!(target);

                return s_CloseByPtr(m_target_ptr);
            }
            
            public string ToString(string? format, IFormatProvider? formatProvider) => format;

            [DebuggerStepperBoundary]
            static ClientCodec()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("WriteRequest");

                if (!(extensionMethod is null))
                    s_WriteRequestByPtr = extensionMethod.CreateStaticDelegate(typeof(WriteRequestByPtr)) as WriteRequestByPtr;

                extensionMethod = targetType.GetExtensionMethod("WriteRequest");

                if (!(extensionMethod is null))
                    s_WriteRequestByVal = extensionMethod.CreateStaticDelegate(typeof(WriteRequestByVal)) as WriteRequestByVal;

                if (s_WriteRequestByPtr is null && s_WriteRequestByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement ClientCodec.WriteRequest method", new Exception("WriteRequest"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("ReadResponseHeader");

                if (!(extensionMethod is null))
                    s_ReadResponseHeaderByPtr = extensionMethod.CreateStaticDelegate(typeof(ReadResponseHeaderByPtr)) as ReadResponseHeaderByPtr;

                extensionMethod = targetType.GetExtensionMethod("ReadResponseHeader");

                if (!(extensionMethod is null))
                    s_ReadResponseHeaderByVal = extensionMethod.CreateStaticDelegate(typeof(ReadResponseHeaderByVal)) as ReadResponseHeaderByVal;

                if (s_ReadResponseHeaderByPtr is null && s_ReadResponseHeaderByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement ClientCodec.ReadResponseHeader method", new Exception("ReadResponseHeader"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("ReadResponseBody");

                if (!(extensionMethod is null))
                    s_ReadResponseBodyByPtr = extensionMethod.CreateStaticDelegate(typeof(ReadResponseBodyByPtr)) as ReadResponseBodyByPtr;

                extensionMethod = targetType.GetExtensionMethod("ReadResponseBody");

                if (!(extensionMethod is null))
                    s_ReadResponseBodyByVal = extensionMethod.CreateStaticDelegate(typeof(ReadResponseBodyByVal)) as ReadResponseBodyByVal;

                if (s_ReadResponseBodyByPtr is null && s_ReadResponseBodyByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement ClientCodec.ReadResponseBody method", new Exception("ReadResponseBody"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Close");

                if (!(extensionMethod is null))
                    s_CloseByPtr = extensionMethod.CreateStaticDelegate(typeof(CloseByPtr)) as CloseByPtr;

                extensionMethod = targetType.GetExtensionMethod("Close");

                if (!(extensionMethod is null))
                    s_CloseByVal = extensionMethod.CreateStaticDelegate(typeof(CloseByVal)) as CloseByVal;

                if (s_CloseByPtr is null && s_CloseByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement ClientCodec.Close method", new Exception("Close"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator ClientCodec<T>(in ptr<T> target_ptr) => new ClientCodec<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator ClientCodec<T>(in T target) => new ClientCodec<T>(target);

            // Enable comparisons between nil and ClientCodec<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ClientCodec<T> value, NilType nil) => Activator.CreateInstance<ClientCodec<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ClientCodec<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ClientCodec<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ClientCodec<T> value) => value != nil;
        }
    }
}}

namespace go
{
    public static class rpc_ClientCodecExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.net.rpc_package.ClientCodec target)
        {
            try
            {
                return ((go.net.rpc_package.ClientCodec<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.net.rpc_package.ClientCodec target, out T result)
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
        public static object? _(this go.net.rpc_package.ClientCodec target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.net.rpc_package.ClientCodec<>).GetExplicitGenericConversionOperator(type));

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
        public static bool _(this go.net.rpc_package.ClientCodec target, Type type, out object? result)
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