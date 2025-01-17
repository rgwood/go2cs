//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 06:06:47 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using errors = go.errors_package;
using go;

#nullable enable

namespace go {
namespace vendor {
namespace golang.org {
namespace x {
namespace net {
namespace dns
{
    public static partial class dnsmessage_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        [PromotedStruct(typeof(Header))]
        public partial struct Message
        {
            // Header structure promotion - sourced from value copy
            private readonly ptr<Header> m_HeaderRef;

            private ref Header Header_val => ref m_HeaderRef.Value;

            public ref ushort ID => ref m_HeaderRef.Value.ID;

            public ref bool Response => ref m_HeaderRef.Value.Response;

            public ref OpCode OpCode => ref m_HeaderRef.Value.OpCode;

            public ref bool Authoritative => ref m_HeaderRef.Value.Authoritative;

            public ref bool Truncated => ref m_HeaderRef.Value.Truncated;

            public ref bool RecursionDesired => ref m_HeaderRef.Value.RecursionDesired;

            public ref bool RecursionAvailable => ref m_HeaderRef.Value.RecursionAvailable;

            public ref RCode RCode => ref m_HeaderRef.Value.RCode;

            // Constructors
            public Message(NilType _)
            {
                this.m_HeaderRef = new ptr<Header>(new Header(nil));
                this.Questions = default;
                this.Answers = default;
                this.Authorities = default;
                this.Additionals = default;
            }

            public Message(Header Header = default, slice<Question> Questions = default, slice<Resource> Answers = default, slice<Resource> Authorities = default, slice<Resource> Additionals = default)
            {
                this.m_HeaderRef = new ptr<Header>(Header);
                this.Questions = Questions;
                this.Answers = Answers;
                this.Authorities = Authorities;
                this.Additionals = Additionals;
            }

            // Enable comparisons between nil and Message struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Message value, NilType nil) => value.Equals(default(Message));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Message value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Message value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Message value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Message(NilType nil) => default(Message);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Message Message_cast(dynamic value)
        {
            return new Message(value.Header, value.Questions, value.Answers, value.Authorities, value.Additionals);
        }
    }
}}}}}}