//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:06:05 UTC
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
using zlib = go.compress.zlib_package;
using binary = go.encoding.binary_package;
using crc32 = go.hash.crc32_package;
using image = go.image_package;
using color = go.image.color_package;
using io = go.io_package;
using strconv = go.strconv_package;
using go;

#nullable enable
#pragma warning disable CS0660, CS0661

namespace go {
namespace image
{
    public static partial class png_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        private partial interface opaquer
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static opaquer As<T>(in T target) => (opaquer<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static opaquer As<T>(ptr<T> target_ptr) => (opaquer<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static opaquer? As(object target) =>
                typeof(opaquer<>).CreateInterfaceHandler<opaquer>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private class opaquer<T> : opaquer
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

            public opaquer(in T target) => m_target = target;

            public opaquer(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate bool OpaqueByPtr(ptr<T> value);
            private delegate bool OpaqueByVal(T value);

            private static readonly OpaqueByPtr? s_OpaqueByPtr;
            private static readonly OpaqueByVal? s_OpaqueByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Opaque()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_OpaqueByPtr is null || !m_target_is_ptr)
                    return s_OpaqueByVal!(target);

                return s_OpaqueByPtr(m_target_ptr);
            }
            
            public string ToString(string? format, IFormatProvider? formatProvider) => format;

            [DebuggerStepperBoundary]
            static opaquer()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Opaque");

                if (!(extensionMethod is null))
                    s_OpaqueByPtr = extensionMethod.CreateStaticDelegate(typeof(OpaqueByPtr)) as OpaqueByPtr;

                extensionMethod = targetType.GetExtensionMethod("Opaque");

                if (!(extensionMethod is null))
                    s_OpaqueByVal = extensionMethod.CreateStaticDelegate(typeof(OpaqueByVal)) as OpaqueByVal;

                if (s_OpaqueByPtr is null && s_OpaqueByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement opaquer.Opaque method", new Exception("Opaque"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator opaquer<T>(in ptr<T> target_ptr) => new opaquer<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator opaquer<T>(in T target) => new opaquer<T>(target);

            // Enable comparisons between nil and opaquer<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(opaquer<T> value, NilType nil) => Activator.CreateInstance<opaquer<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(opaquer<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, opaquer<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, opaquer<T> value) => value != nil;
        }
    }
}}

namespace go
{
    public static class png_opaquerExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.image.png_package.opaquer target)
        {
            try
            {
                return ((go.image.png_package.opaquer<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.image.png_package.opaquer target, out T result)
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
        public static object? _(this go.image.png_package.opaquer target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.image.png_package.opaquer<>).GetExplicitGenericConversionOperator(type));

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
        public static bool _(this go.image.png_package.opaquer target, Type type, out object? result)
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