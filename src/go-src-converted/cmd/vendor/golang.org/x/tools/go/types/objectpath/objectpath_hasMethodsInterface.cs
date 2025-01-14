//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:05:03 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using fmt = go.fmt_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using types = go.go.types_package;
using go;

#nullable enable
#pragma warning disable CS0660, CS0661

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace tools {
namespace go {
namespace types
{
    public static partial class objectpath_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial interface hasMethods
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static hasMethods As<T>(in T target) => (hasMethods<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static hasMethods As<T>(ptr<T> target_ptr) => (hasMethods<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static hasMethods? As(object target) =>
                typeof(hasMethods<>).CreateInterfaceHandler<hasMethods>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private class hasMethods<T> : hasMethods
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

            public hasMethods(in T target) => m_target = target;

            public hasMethods(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate long MethodByPtr(ptr<T> value, long _p0);
            private delegate long MethodByVal(T value, long _p0);

            private static readonly MethodByPtr? s_MethodByPtr;
            private static readonly MethodByVal? s_MethodByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long Method(long _p0)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_MethodByPtr is null || !m_target_is_ptr)
                    return s_MethodByVal!(target, _p0);

                return s_MethodByPtr(m_target_ptr, _p0);
            }

            private delegate long NumMethodsByPtr(ptr<T> value);
            private delegate long NumMethodsByVal(T value);

            private static readonly NumMethodsByPtr? s_NumMethodsByPtr;
            private static readonly NumMethodsByVal? s_NumMethodsByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long NumMethods()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_NumMethodsByPtr is null || !m_target_is_ptr)
                    return s_NumMethodsByVal!(target);

                return s_NumMethodsByPtr(m_target_ptr);
            }
            
            public string ToString(string? format, IFormatProvider? formatProvider) => format;

            [DebuggerStepperBoundary]
            static hasMethods()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Method");

                if (!(extensionMethod is null))
                    s_MethodByPtr = extensionMethod.CreateStaticDelegate(typeof(MethodByPtr)) as MethodByPtr;

                extensionMethod = targetType.GetExtensionMethod("Method");

                if (!(extensionMethod is null))
                    s_MethodByVal = extensionMethod.CreateStaticDelegate(typeof(MethodByVal)) as MethodByVal;

                if (s_MethodByPtr is null && s_MethodByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement hasMethods.Method method", new Exception("Method"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("NumMethods");

                if (!(extensionMethod is null))
                    s_NumMethodsByPtr = extensionMethod.CreateStaticDelegate(typeof(NumMethodsByPtr)) as NumMethodsByPtr;

                extensionMethod = targetType.GetExtensionMethod("NumMethods");

                if (!(extensionMethod is null))
                    s_NumMethodsByVal = extensionMethod.CreateStaticDelegate(typeof(NumMethodsByVal)) as NumMethodsByVal;

                if (s_NumMethodsByPtr is null && s_NumMethodsByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement hasMethods.NumMethods method", new Exception("NumMethods"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator hasMethods<T>(in ptr<T> target_ptr) => new hasMethods<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator hasMethods<T>(in T target) => new hasMethods<T>(target);

            // Enable comparisons between nil and hasMethods<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(hasMethods<T> value, NilType nil) => Activator.CreateInstance<hasMethods<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(hasMethods<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, hasMethods<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, hasMethods<T> value) => value != nil;
        }
    }
}}}}}}}}

namespace go
{
    public static class objectpath_hasMethodsExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.cmd.vendor.golang.org.x.tools.go.types.objectpath_package.hasMethods target)
        {
            try
            {
                return ((go.cmd.vendor.golang.org.x.tools.go.types.objectpath_package.hasMethods<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.cmd.vendor.golang.org.x.tools.go.types.objectpath_package.hasMethods target, out T result)
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
        public static object? _(this go.cmd.vendor.golang.org.x.tools.go.types.objectpath_package.hasMethods target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.cmd.vendor.golang.org.x.tools.go.types.objectpath_package.hasMethods<>).GetExplicitGenericConversionOperator(type));

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
        public static bool _(this go.cmd.vendor.golang.org.x.tools.go.types.objectpath_package.hasMethods target, Type type, out object? result)
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