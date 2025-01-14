//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 05:55:53 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using bytes = go.bytes_package;
using errors = go.errors_package;
using fmt = go.fmt_package;
using os = go.os_package;
using strconv = go.strconv_package;
using strings = go.strings_package;
using unicode = go.unicode_package;
using utf8 = go.unicode.utf8_package;
using go;

#nullable enable
#pragma warning disable CS0660, CS0661

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace mod
{
    public static partial class modfile_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial interface Expr
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static Expr As<T>(in T target) => (Expr<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static Expr As<T>(ptr<T> target_ptr) => (Expr<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static Expr? As(object target) =>
                typeof(Expr<>).CreateInterfaceHandler<Expr>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public class Expr<T> : Expr
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

            public Expr(in T target) => m_target = target;

            public Expr(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate ptr<Comments> SpanByPtr(ptr<T> value);
            private delegate ptr<Comments> SpanByVal(T value);

            private static readonly SpanByPtr? s_SpanByPtr;
            private static readonly SpanByVal? s_SpanByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ptr<Comments> Span()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_SpanByPtr is null || !m_target_is_ptr)
                    return s_SpanByVal!(target);

                return s_SpanByPtr(m_target_ptr);
            }

            private delegate ptr<Comments> CommentByPtr(ptr<T> value);
            private delegate ptr<Comments> CommentByVal(T value);

            private static readonly CommentByPtr? s_CommentByPtr;
            private static readonly CommentByVal? s_CommentByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ptr<Comments> Comment()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_CommentByPtr is null || !m_target_is_ptr)
                    return s_CommentByVal!(target);

                return s_CommentByPtr(m_target_ptr);
            }
            
            public string ToString(string? format, IFormatProvider? formatProvider) => format;

            [DebuggerStepperBoundary]
            static Expr()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Span");

                if (!(extensionMethod is null))
                    s_SpanByPtr = extensionMethod.CreateStaticDelegate(typeof(SpanByPtr)) as SpanByPtr;

                extensionMethod = targetType.GetExtensionMethod("Span");

                if (!(extensionMethod is null))
                    s_SpanByVal = extensionMethod.CreateStaticDelegate(typeof(SpanByVal)) as SpanByVal;

                if (s_SpanByPtr is null && s_SpanByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement Expr.Span method", new Exception("Span"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Comment");

                if (!(extensionMethod is null))
                    s_CommentByPtr = extensionMethod.CreateStaticDelegate(typeof(CommentByPtr)) as CommentByPtr;

                extensionMethod = targetType.GetExtensionMethod("Comment");

                if (!(extensionMethod is null))
                    s_CommentByVal = extensionMethod.CreateStaticDelegate(typeof(CommentByVal)) as CommentByVal;

                if (s_CommentByPtr is null && s_CommentByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement Expr.Comment method", new Exception("Comment"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator Expr<T>(in ptr<T> target_ptr) => new Expr<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator Expr<T>(in T target) => new Expr<T>(target);

            // Enable comparisons between nil and Expr<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Expr<T> value, NilType nil) => Activator.CreateInstance<Expr<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Expr<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Expr<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Expr<T> value) => value != nil;
        }
    }
}}}}}}

namespace go
{
    public static class modfile_ExprExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.cmd.vendor.golang.org.x.mod.modfile_package.Expr target)
        {
            try
            {
                return ((go.cmd.vendor.golang.org.x.mod.modfile_package.Expr<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.cmd.vendor.golang.org.x.mod.modfile_package.Expr target, out T result)
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
        public static object? _(this go.cmd.vendor.golang.org.x.mod.modfile_package.Expr target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.cmd.vendor.golang.org.x.mod.modfile_package.Expr<>).GetExplicitGenericConversionOperator(type));

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
        public static bool _(this go.cmd.vendor.golang.org.x.mod.modfile_package.Expr target, Type type, out object? result)
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