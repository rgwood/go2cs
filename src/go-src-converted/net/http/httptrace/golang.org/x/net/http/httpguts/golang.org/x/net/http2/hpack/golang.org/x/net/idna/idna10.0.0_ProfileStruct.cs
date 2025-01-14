//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 October 09 04:56:59 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using fmt = go.fmt_package;
using strings = go.strings_package;
using utf8 = go.unicode.utf8_package;
using bidirule = go.golang.org.x.text.secure.bidirule_package;
using bidi = go.golang.org.x.text.unicode.bidi_package;
using norm = go.golang.org.x.text.unicode.norm_package;
using go;

#nullable enable

namespace go {
namespace golang.org {
namespace x {
namespace net
{
    public static partial class idna_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        [PromotedStruct(typeof(options))]
        public partial struct Profile
        {
            // options structure promotion - sourced from value copy
            private readonly ptr<options> m_optionsRef;

            private ref options options_val => ref m_optionsRef.Value;

            public ref bool transitional => ref m_optionsRef.Value.transitional;

            public ref bool useSTD3Rules => ref m_optionsRef.Value.useSTD3Rules;

            public ref bool validateLabels => ref m_optionsRef.Value.validateLabels;

            public ref bool verifyDNSLength => ref m_optionsRef.Value.verifyDNSLength;

            public ref bool removeLeadingDots => ref m_optionsRef.Value.removeLeadingDots;

            public ref ptr<idnaTrie> trie => ref m_optionsRef.Value.trie;

            public ref Func<ptr<Profile>, @string, error> fromPuny => ref m_optionsRef.Value.fromPuny;

            public ref Func<ptr<Profile>, @string, (@string, bool, error)> mapping => ref m_optionsRef.Value.mapping;

            public ref Func<@string, bool> bidirule => ref m_optionsRef.Value.bidirule;

            // Constructors
            public Profile(NilType _)
            {
                this.m_optionsRef = new ptr<options>(new options(nil));
            }

            public Profile(options options = default)
            {
                this.m_optionsRef = new ptr<options>(options);
            }

            // Enable comparisons between nil and Profile struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Profile value, NilType nil) => value.Equals(default(Profile));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Profile value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Profile value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Profile value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Profile(NilType nil) => default(Profile);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Profile Profile_cast(dynamic value)
        {
            return new Profile(value.options);
        }
    }
}}}}