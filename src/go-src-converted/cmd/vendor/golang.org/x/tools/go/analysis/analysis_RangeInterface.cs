//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:01:15 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using flag = go.flag_package;
using fmt = go.fmt_package;
using ast = go.go.ast_package;
using token = go.go.token_package;
using types = go.go.types_package;
using reflect = go.reflect_package;
using analysisinternal = go.golang.org.x.tools.@internal.analysisinternal_package;
using go;

#nullable enable
#pragma warning disable CS0660, CS0661

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace tools {
namespace go
{
    public static partial class analysis_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial interface Range
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static Range As<T>(in T target) => (Range<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static Range As<T>(ptr<T> target_ptr) => (Range<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static Range? As(object target) =>
                typeof(Range<>).CreateInterfaceHandler<Range>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public class Range<T> : Range
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

            public Range(in T target) => m_target = target;

            public Range(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate token.Pos PosByPtr(ptr<T> value);
            private delegate token.Pos PosByVal(T value);

            private static readonly PosByPtr? s_PosByPtr;
            private static readonly PosByVal? s_PosByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public token.Pos Pos()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_PosByPtr is null || !m_target_is_ptr)
                    return s_PosByVal!(target);

                return s_PosByPtr(m_target_ptr);
            }

            private delegate token.Pos EndByPtr(ptr<T> value);
            private delegate token.Pos EndByVal(T value);

            private static readonly EndByPtr? s_EndByPtr;
            private static readonly EndByVal? s_EndByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public token.Pos End()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_EndByPtr is null || !m_target_is_ptr)
                    return s_EndByVal!(target);

                return s_EndByPtr(m_target_ptr);
            }
            
            public string ToString(string? format, IFormatProvider? formatProvider) => format;

            [DebuggerStepperBoundary]
            static Range()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Pos");

                if (!(extensionMethod is null))
                    s_PosByPtr = extensionMethod.CreateStaticDelegate(typeof(PosByPtr)) as PosByPtr;

                extensionMethod = targetType.GetExtensionMethod("Pos");

                if (!(extensionMethod is null))
                    s_PosByVal = extensionMethod.CreateStaticDelegate(typeof(PosByVal)) as PosByVal;

                if (s_PosByPtr is null && s_PosByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement Range.Pos method", new Exception("Pos"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("End");

                if (!(extensionMethod is null))
                    s_EndByPtr = extensionMethod.CreateStaticDelegate(typeof(EndByPtr)) as EndByPtr;

                extensionMethod = targetType.GetExtensionMethod("End");

                if (!(extensionMethod is null))
                    s_EndByVal = extensionMethod.CreateStaticDelegate(typeof(EndByVal)) as EndByVal;

                if (s_EndByPtr is null && s_EndByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement Range.End method", new Exception("End"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator Range<T>(in ptr<T> target_ptr) => new Range<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator Range<T>(in T target) => new Range<T>(target);

            // Enable comparisons between nil and Range<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Range<T> value, NilType nil) => Activator.CreateInstance<Range<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Range<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Range<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Range<T> value) => value != nil;
        }
    }
}}}}}}}

namespace go
{
    public static class analysis_RangeExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.cmd.vendor.golang.org.x.tools.go.analysis_package.Range target)
        {
            try
            {
                return ((go.cmd.vendor.golang.org.x.tools.go.analysis_package.Range<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.cmd.vendor.golang.org.x.tools.go.analysis_package.Range target, out T result)
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
        public static object? _(this go.cmd.vendor.golang.org.x.tools.go.analysis_package.Range target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.cmd.vendor.golang.org.x.tools.go.analysis_package.Range<>).GetExplicitGenericConversionOperator(type));

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
        public static bool _(this go.cmd.vendor.golang.org.x.tools.go.analysis_package.Range target, Type type, out object? result)
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