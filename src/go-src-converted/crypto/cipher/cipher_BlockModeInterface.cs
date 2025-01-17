//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:53:42 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

using go;

#nullable enable
#pragma warning disable CS0660, CS0661

namespace go {
namespace crypto
{
    public static partial class cipher_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial interface BlockMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static BlockMode As<T>(in T target) => (BlockMode<T>)target!;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static BlockMode As<T>(ptr<T> target_ptr) => (BlockMode<T>)target_ptr;

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static BlockMode? As(object target) =>
                typeof(BlockMode<>).CreateInterfaceHandler<BlockMode>(target);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public class BlockMode<T> : BlockMode
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

            public BlockMode(in T target) => m_target = target;

            public BlockMode(ptr<T> target_ptr)
            {
                m_target_ptr = target_ptr;
                m_target_is_ptr = true;
            }

            private delegate long BlockSizeByPtr(ptr<T> value);
            private delegate long BlockSizeByVal(T value);

            private static readonly BlockSizeByPtr? s_BlockSizeByPtr;
            private static readonly BlockSizeByVal? s_BlockSizeByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long BlockSize()
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_BlockSizeByPtr is null || !m_target_is_ptr)
                    return s_BlockSizeByVal!(target);

                return s_BlockSizeByPtr(m_target_ptr);
            }

            private delegate long CryptBlocksByPtr(ptr<T> value, slice<byte> dst, slice<byte> src);
            private delegate long CryptBlocksByVal(T value, slice<byte> dst, slice<byte> src);

            private static readonly CryptBlocksByPtr? s_CryptBlocksByPtr;
            private static readonly CryptBlocksByVal? s_CryptBlocksByVal;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long CryptBlocks(slice<byte> dst, slice<byte> src)
            {
                T target = m_target;

                if (m_target_is_ptr && !(m_target_ptr is null))
                    target = m_target_ptr.val;

                if (s_CryptBlocksByPtr is null || !m_target_is_ptr)
                    return s_CryptBlocksByVal!(target, dst, src);

                return s_CryptBlocksByPtr(m_target_ptr, dst, src);
            }
            
            public string ToString(string? format, IFormatProvider? formatProvider) => format;

            [DebuggerStepperBoundary]
            static BlockMode()
            {
                Type targetType = typeof(T);
                Type targetTypeByPtr = typeof(ptr<T>);
                MethodInfo extensionMethod;

               extensionMethod = targetTypeByPtr.GetExtensionMethod("BlockSize");

                if (!(extensionMethod is null))
                    s_BlockSizeByPtr = extensionMethod.CreateStaticDelegate(typeof(BlockSizeByPtr)) as BlockSizeByPtr;

                extensionMethod = targetType.GetExtensionMethod("BlockSize");

                if (!(extensionMethod is null))
                    s_BlockSizeByVal = extensionMethod.CreateStaticDelegate(typeof(BlockSizeByVal)) as BlockSizeByVal;

                if (s_BlockSizeByPtr is null && s_BlockSizeByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement BlockMode.BlockSize method", new Exception("BlockSize"));

               extensionMethod = targetTypeByPtr.GetExtensionMethod("CryptBlocks");

                if (!(extensionMethod is null))
                    s_CryptBlocksByPtr = extensionMethod.CreateStaticDelegate(typeof(CryptBlocksByPtr)) as CryptBlocksByPtr;

                extensionMethod = targetType.GetExtensionMethod("CryptBlocks");

                if (!(extensionMethod is null))
                    s_CryptBlocksByVal = extensionMethod.CreateStaticDelegate(typeof(CryptBlocksByVal)) as CryptBlocksByVal;

                if (s_CryptBlocksByPtr is null && s_CryptBlocksByVal is null)
                    throw new NotImplementedException($"{targetType.FullName} does not implement BlockMode.CryptBlocks method", new Exception("CryptBlocks"));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator BlockMode<T>(in ptr<T> target_ptr) => new BlockMode<T>(target_ptr);

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator BlockMode<T>(in T target) => new BlockMode<T>(target);

            // Enable comparisons between nil and BlockMode<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(BlockMode<T> value, NilType nil) => Activator.CreateInstance<BlockMode<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(BlockMode<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, BlockMode<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, BlockMode<T> value) => value != nil;
        }
    }
}}

namespace go
{
    public static class cipher_BlockModeExtensions
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo> s_conversionOperators = new ConcurrentDictionary<Type, MethodInfo>();

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static T _<T>(this go.crypto.cipher_package.BlockMode target)
        {
            try
            {
                return ((go.crypto.cipher_package.BlockMode<T>)target).Target;
            }
            catch (NotImplementedException ex)
            {
                throw new PanicException($"interface conversion: {GetGoTypeName(target.GetType())} is not {GetGoTypeName(typeof(T))}: missing method {ex.InnerException?.Message}");
            }
        }

        [GeneratedCode("go2cs", "0.1.0.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static bool _<T>(this go.crypto.cipher_package.BlockMode target, out T result)
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
        public static object? _(this go.crypto.cipher_package.BlockMode target, Type type)
        {
            try
            {
                MethodInfo? conversionOperator = s_conversionOperators.GetOrAdd(type, _ => typeof(go.crypto.cipher_package.BlockMode<>).GetExplicitGenericConversionOperator(type));

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
        public static bool _(this go.crypto.cipher_package.BlockMode target, Type type, out object? result)
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