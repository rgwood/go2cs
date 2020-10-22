//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:05:11 UTC
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
using logpkg = go.log_package;
using math = go.math_package;
using os = go.os_package;
using testing = go.testing_package;
using @unsafe = go.@unsafe_package;
using go;

#nullable enable
#pragma warning disable CS0660, CS0661

namespace go {
namespace cmd {
namespace vet {
namespace testdata
{
    public static partial class print_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial interface errorInterface
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static errorInterface As<T>(in T target) => (errorInterface<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static errorInterface As<T>(ptr<T> target_ptr) => (errorInterface<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static errorInterface? As(object target) =>
                typeof(errorInterface<>).CreateInterfaceHandler<errorInterface>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private class errorInterface<T> : errorInterface
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

            public errorInterface(in T target) => m_target = target;

            public errorInterface(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate void ExtraMethodByPtr(ptr<T> value);
            private delegate void ExtraMethodByVal(T value);

            private static readonly ExtraMethodByPtr? s_ExtraMethodByPtr;
            private static readonly ExtraMethodByVal? s_ExtraMethodByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ExtraMethod()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_ExtraMethodByPtr is null || !m_target_is_ptr)
                {
                    s_ExtraMethodByVal!(target);
                    return;
                }

                s_ExtraMethodByPtr(m_target_ptr);
                return;
                
            }

            private delegate @string ErrorByPtr(ptr<T> value);
            private delegate @string ErrorByVal(T value);

            private static readonly ErrorByPtr? s_ErrorByPtr;
            private static readonly ErrorByVal? s_ErrorByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public @string Error()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_ErrorByPtr is null || !m_target_is_ptr)
                    return s_ErrorByVal!(target);

                return s_ErrorByPtr(m_target_ptr);
            }
            
            public string ToString(string? format, IFormatProvider? formatProvider) => format;

            [DebuggerStepperBoundary]
            static errorInterface()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("ExtraMethod");

                if (!(extensionMethod is null))
                    s_ExtraMethodByPtr = extensionMethod.CreateStaticDelegate(typeof(ExtraMethodByPtr)) as ExtraMethodByPtr;

                extensionMethod = targetType.GetExtensionMethod("ExtraMethod");

                if (!(extensionMethod is null))
                    s_ExtraMethodByVal = extensionMethod.CreateStaticDelegate(typeof(ExtraMethodByVal)) as ExtraMethodByVal;

                if (s_ExtraMethodByPtr is null && s_ExtraMethodByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement errorInterface.ExtraMethod method", new Exception("ExtraMethod"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Error");

                if (!(extensionMethod is null))
                    s_ErrorByPtr = extensionMethod.CreateStaticDelegate(typeof(ErrorByPtr)) as ErrorByPtr;

                extensionMethod = targetType.GetExtensionMethod("Error");

                if (!(extensionMethod is null))
                    s_ErrorByVal = extensionMethod.CreateStaticDelegate(typeof(ErrorByVal)) as ErrorByVal;

                if (s_ErrorByPtr is null && s_ErrorByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement errorInterface.Error method", new Exception("Error"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator errorInterface<T>(in ptr<T> target_ptr) => new errorInterface<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator errorInterface<T>(in T target) => new errorInterface<T>(target);

            // Enable comparisons between nil and errorInterface<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(errorInterface<T> value, NilType nil) => Activator.CreateInstance<errorInterface<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(errorInterface<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, errorInterface<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, errorInterface<T> value) => value != nil;
        }
    }
}}}}

namespace go
{
    public static class print_errorInterfaceExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.cmd.vet.testdata.print_package.errorInterface target)
        {
            try
            {
                return ((go.cmd.vet.testdata.print_package.errorInterface<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.cmd.vet.testdata.print_package.errorInterface target, out T result)
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
        public static object? _(this go.cmd.vet.testdata.print_package.errorInterface target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.cmd.vet.testdata.print_package.errorInterface<>).GetExplicitGenericConversionOperator(type));

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
        public static bool _(this go.cmd.vet.testdata.print_package.errorInterface target, Type type, out object? result)
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