//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:02:36 UTC
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
namespace golang.org {
namespace x {
namespace tools {
namespace go {
namespace types
{
    public static partial class objectpath_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial interface hasElem
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static hasElem As<T>(in T target) => (hasElem<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static hasElem As<T>(ptr<T> target_ptr) => (hasElem<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static hasElem? As(object target) =>
                typeof(hasElem<>).CreateInterfaceHandler<hasElem>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private class hasElem<T> : hasElem
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

            public hasElem(in T target) => m_target = target;

            public hasElem(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate types.Type ElemByPtr(ptr<T> value);
            private delegate types.Type ElemByVal(T value);

            private static readonly ElemByPtr? s_ElemByPtr;
            private static readonly ElemByVal? s_ElemByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public types.Type Elem()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_ElemByPtr is null || !m_target_is_ptr)
                    return s_ElemByVal!(target);

                return s_ElemByPtr(m_target_ptr);
            }
            
            public string ToString(string? format, IFormatProvider? formatProvider) => format;

            [DebuggerStepperBoundary]
            static hasElem()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Elem");

                if (!(extensionMethod is null))
                    s_ElemByPtr = extensionMethod.CreateStaticDelegate(typeof(ElemByPtr)) as ElemByPtr;

                extensionMethod = targetType.GetExtensionMethod("Elem");

                if (!(extensionMethod is null))
                    s_ElemByVal = extensionMethod.CreateStaticDelegate(typeof(ElemByVal)) as ElemByVal;

                if (s_ElemByPtr is null && s_ElemByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement hasElem.Elem method", new Exception("Elem"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator hasElem<T>(in ptr<T> target_ptr) => new hasElem<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator hasElem<T>(in T target) => new hasElem<T>(target);

            // Enable comparisons between nil and hasElem<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(hasElem<T> value, NilType nil) => Activator.CreateInstance<hasElem<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(hasElem<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, hasElem<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, hasElem<T> value) => value != nil;
        }
    }
}}}}}}

namespace go
{
    public static class objectpath_hasElemExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.golang.org.x.tools.go.types.objectpath_package.hasElem target)
        {
            try
            {
                return ((go.golang.org.x.tools.go.types.objectpath_package.hasElem<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.golang.org.x.tools.go.types.objectpath_package.hasElem target, out T result)
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
        public static object? _(this go.golang.org.x.tools.go.types.objectpath_package.hasElem target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.golang.org.x.tools.go.types.objectpath_package.hasElem<>).GetExplicitGenericConversionOperator(type));

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
        public static bool _(this go.golang.org.x.tools.go.types.objectpath_package.hasElem target, Type type, out object? result)
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