//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 08:31:04 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using list = go.container.list_package;
using crypto = go.crypto_package;
using cipherhw = go.crypto.@internal.cipherhw_package;
using rand = go.crypto.rand_package;
using sha512 = go.crypto.sha512_package;
using x509 = go.crypto.x509_package;
using errors = go.errors_package;
using fmt = go.fmt_package;
using io = go.io_package;
using big = go.math.big_package;
using net = go.net_package;
using strings = go.strings_package;
using sync = go.sync_package;
using time = go.time_package;
using go;

namespace go {
namespace crypto
{
    public static partial class tls_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        public partial struct Config
        {
            // Constructors
            public Config(NilType _)
            {
                this.Rand = default;
                this.Time = default;
                this.Certificates = default;
                this.NameToCertificate = default;
                this.GetCertificate = default;
                this.GetClientCertificate = default;
                this.GetConfigForClient = default;
                this.VerifyPeerCertificate = default;
                this.RootCAs = default;
                this.NextProtos = default;
                this.ServerName = default;
                this.ClientAuth = default;
                this.ClientCAs = default;
                this.InsecureSkipVerify = default;
                this.CipherSuites = default;
                this.PreferServerCipherSuites = default;
                this.SessionTicketsDisabled = default;
                this.SessionTicketKey = default;
                this.ClientSessionCache = default;
                this.MinVersion = default;
                this.MaxVersion = default;
                this.CurvePreferences = default;
                this.DynamicRecordSizingDisabled = default;
                this.Renegotiation = default;
                this.KeyLogWriter = default;
                this.serverInitOnce = default;
                this.mutex = default;
                this.sessionTicketKeys = default;
            }

            public Config(io.Reader Rand = default, Func<time.Time> Time = default, slice<Certificate> Certificates = default, map<@string, ref Certificate> NameToCertificate = default, Func<ref ClientHelloInfo, (ref Certificate, error)> GetCertificate = default, Func<ref CertificateRequestInfo, (ref Certificate, error)> GetClientCertificate = default, Func<ref ClientHelloInfo, (ref Config, error)> GetConfigForClient = default, Func<slice<slice<byte>>, slice<slice<ref x509.Certificate>>, error> VerifyPeerCertificate = default, ref ptr<x509.CertPool> RootCAs = default, slice<@string> NextProtos = default, @string ServerName = default, ClientAuthType ClientAuth = default, ref ptr<x509.CertPool> ClientCAs = default, bool InsecureSkipVerify = default, slice<ushort> CipherSuites = default, bool PreferServerCipherSuites = default, bool SessionTicketsDisabled = default, array<byte> SessionTicketKey = default, ClientSessionCache ClientSessionCache = default, ushort MinVersion = default, ushort MaxVersion = default, slice<CurveID> CurvePreferences = default, bool DynamicRecordSizingDisabled = default, RenegotiationSupport Renegotiation = default, io.Writer KeyLogWriter = default, sync.Once serverInitOnce = default, sync.RWMutex mutex = default, slice<ticketKey> sessionTicketKeys = default)
            {
                this.Rand = Rand;
                this.Time = Time;
                this.Certificates = Certificates;
                this.NameToCertificate = NameToCertificate;
                this.GetCertificate = GetCertificate;
                this.GetClientCertificate = GetClientCertificate;
                this.GetConfigForClient = GetConfigForClient;
                this.VerifyPeerCertificate = VerifyPeerCertificate;
                this.RootCAs = RootCAs;
                this.NextProtos = NextProtos;
                this.ServerName = ServerName;
                this.ClientAuth = ClientAuth;
                this.ClientCAs = ClientCAs;
                this.InsecureSkipVerify = InsecureSkipVerify;
                this.CipherSuites = CipherSuites;
                this.PreferServerCipherSuites = PreferServerCipherSuites;
                this.SessionTicketsDisabled = SessionTicketsDisabled;
                this.SessionTicketKey = SessionTicketKey;
                this.ClientSessionCache = ClientSessionCache;
                this.MinVersion = MinVersion;
                this.MaxVersion = MaxVersion;
                this.CurvePreferences = CurvePreferences;
                this.DynamicRecordSizingDisabled = DynamicRecordSizingDisabled;
                this.Renegotiation = Renegotiation;
                this.KeyLogWriter = KeyLogWriter;
                this.serverInitOnce = serverInitOnce;
                this.mutex = mutex;
                this.sessionTicketKeys = sessionTicketKeys;
            }

            // Enable comparisons between nil and Config struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Config value, NilType nil) => value.Equals(default(Config));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Config value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Config value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Config value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Config(NilType nil) => default(Config);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        public static Config Config_cast(dynamic value)
        {
            return new Config(value.Rand, value.Time, value.Certificates, value.NameToCertificate, value.GetCertificate, value.GetClientCertificate, value.GetConfigForClient, value.VerifyPeerCertificate, ref value.RootCAs, value.NextProtos, value.ServerName, value.ClientAuth, ref value.ClientCAs, value.InsecureSkipVerify, value.CipherSuites, value.PreferServerCipherSuites, value.SessionTicketsDisabled, value.SessionTicketKey, value.ClientSessionCache, value.MinVersion, value.MaxVersion, value.CurvePreferences, value.DynamicRecordSizingDisabled, value.Renegotiation, value.KeyLogWriter, value.serverInitOnce, value.mutex, value.sessionTicketKeys);
        }
    }
}}