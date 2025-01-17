//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:05:47 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using image = go.image_package;
using color = go.image.color_package;
using imageutil = go.image.@internal.imageutil_package;
using go;

#nullable enable
#pragma warning disable CS0660, CS0661

namespace go {
namespace image
{
    public static partial class draw_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial interface Image
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static Image As<T>(in T target) => (Image<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static Image As<T>(ptr<T> target_ptr) => (Image<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static Image? As(object target) =>
                typeof(Image<>).CreateInterfaceHandler<Image>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public class Image<T> : Image
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

            public Image(in T target) => m_target = target;

            public Image(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate void SetByPtr(ptr<T> value, long x, long y, color.Color c);
            private delegate void SetByVal(T value, long x, long y, color.Color c);

            private static readonly SetByPtr? s_SetByPtr;
            private static readonly SetByVal? s_SetByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Set(long x, long y, color.Color c)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_SetByPtr is null || !m_target_is_ptr)
                {
                    s_SetByVal!(target, x, y, c);
                    return;
                }

                s_SetByPtr(m_target_ptr, x, y, c);
                return;
                
            }

            private delegate color.Color ColorModelByPtr(ptr<T> value);
            private delegate color.Color ColorModelByVal(T value);

            private static readonly ColorModelByPtr? s_ColorModelByPtr;
            private static readonly ColorModelByVal? s_ColorModelByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public color.Color ColorModel()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_ColorModelByPtr is null || !m_target_is_ptr)
                    return s_ColorModelByVal!(target);

                return s_ColorModelByPtr(m_target_ptr);
            }

            private delegate color.Color BoundsByPtr(ptr<T> value);
            private delegate color.Color BoundsByVal(T value);

            private static readonly BoundsByPtr? s_BoundsByPtr;
            private static readonly BoundsByVal? s_BoundsByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public color.Color Bounds()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_BoundsByPtr is null || !m_target_is_ptr)
                    return s_BoundsByVal!(target);

                return s_BoundsByPtr(m_target_ptr);
            }

            private delegate color.Color AtByPtr(ptr<T> value, long x, long y);
            private delegate color.Color AtByVal(T value, long x, long y);

            private static readonly AtByPtr? s_AtByPtr;
            private static readonly AtByVal? s_AtByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public color.Color At(long x, long y)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_AtByPtr is null || !m_target_is_ptr)
                    return s_AtByVal!(target, x, y);

                return s_AtByPtr(m_target_ptr, x, y);
            }
            
            public string ToString(string? format, IFormatProvider? formatProvider) => format;

            [DebuggerStepperBoundary]
            static Image()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Set");

                if (!(extensionMethod is null))
                    s_SetByPtr = extensionMethod.CreateStaticDelegate(typeof(SetByPtr)) as SetByPtr;

                extensionMethod = targetType.GetExtensionMethod("Set");

                if (!(extensionMethod is null))
                    s_SetByVal = extensionMethod.CreateStaticDelegate(typeof(SetByVal)) as SetByVal;

                if (s_SetByPtr is null && s_SetByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement Image.Set method", new Exception("Set"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("ColorModel");

                if (!(extensionMethod is null))
                    s_ColorModelByPtr = extensionMethod.CreateStaticDelegate(typeof(ColorModelByPtr)) as ColorModelByPtr;

                extensionMethod = targetType.GetExtensionMethod("ColorModel");

                if (!(extensionMethod is null))
                    s_ColorModelByVal = extensionMethod.CreateStaticDelegate(typeof(ColorModelByVal)) as ColorModelByVal;

                if (s_ColorModelByPtr is null && s_ColorModelByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement Image.ColorModel method", new Exception("ColorModel"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("Bounds");

                if (!(extensionMethod is null))
                    s_BoundsByPtr = extensionMethod.CreateStaticDelegate(typeof(BoundsByPtr)) as BoundsByPtr;

                extensionMethod = targetType.GetExtensionMethod("Bounds");

                if (!(extensionMethod is null))
                    s_BoundsByVal = extensionMethod.CreateStaticDelegate(typeof(BoundsByVal)) as BoundsByVal;

                if (s_BoundsByPtr is null && s_BoundsByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement Image.Bounds method", new Exception("Bounds"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("At");

                if (!(extensionMethod is null))
                    s_AtByPtr = extensionMethod.CreateStaticDelegate(typeof(AtByPtr)) as AtByPtr;

                extensionMethod = targetType.GetExtensionMethod("At");

                if (!(extensionMethod is null))
                    s_AtByVal = extensionMethod.CreateStaticDelegate(typeof(AtByVal)) as AtByVal;

                if (s_AtByPtr is null && s_AtByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement Image.At method", new Exception("At"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator Image<T>(in ptr<T> target_ptr) => new Image<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator Image<T>(in T target) => new Image<T>(target);

            // Enable comparisons between nil and Image<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Image<T> value, NilType nil) => Activator.CreateInstance<Image<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Image<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Image<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Image<T> value) => value != nil;
        }
    }
}}

namespace go
{
    public static class draw_ImageExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.image.draw_package.Image target)
        {
            try
            {
                return ((go.image.draw_package.Image<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.image.draw_package.Image target, out T result)
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
        public static object? _(this go.image.draw_package.Image target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.image.draw_package.Image<>).GetExplicitGenericConversionOperator(type));

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
        public static bool _(this go.image.draw_package.Image target, Type type, out object? result)
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