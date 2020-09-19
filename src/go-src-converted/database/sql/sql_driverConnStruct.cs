//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2020 August 29 10:11:00 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static go.builtin;
using context = go.context_package;
using driver = go.database.sql.driver_package;
using errors = go.errors_package;
using fmt = go.fmt_package;
using io = go.io_package;
using reflect = go.reflect_package;
using runtime = go.runtime_package;
using sort = go.sort_package;
using sync = go.sync_package;
using atomic = go.sync.atomic_package;
using time = go.time_package;
using go;

namespace go {
namespace database
{
    public static partial class sql_package
    {
        [GeneratedCode("go2cs", "0.1.0.0")]
        [PromotedStruct(typeof(sync.Mutex))]
        private partial struct driverConn
        {
            // Mutex structure promotion - sourced from value copy
            private readonly ptr<Mutex> m_MutexRef;

            private ref Mutex Mutex_val => ref m_MutexRef.Value;

            public ref int state => ref m_MutexRef.Value.state;

            public ref uint sema => ref m_MutexRef.Value.sema;

            // Constructors
            public driverConn(NilType _)
            {
                this.db = default;
                this.createdAt = default;
                this.m_MutexRef = new ptr<sync.Mutex>(new sync.Mutex(nil));
                this.ci = default;
                this.closed = default;
                this.finalClosed = default;
                this.openStmt = default;
                this.lastErr = default;
                this.inUse = default;
                this.onPut = default;
                this.dbmuClosed = default;
            }

            public driverConn(ref ptr<DB> db = default, time.Time createdAt = default, sync.Mutex Mutex = default, driver.Conn ci = default, bool closed = default, bool finalClosed = default, map<ref driverStmt, bool> openStmt = default, error lastErr = default, bool inUse = default, slice<Action> onPut = default, bool dbmuClosed = default)
            {
                this.db = db;
                this.createdAt = createdAt;
                this.m_MutexRef = new ptr<sync.Mutex>(Mutex);
                this.ci = ci;
                this.closed = closed;
                this.finalClosed = finalClosed;
                this.openStmt = openStmt;
                this.lastErr = lastErr;
                this.inUse = inUse;
                this.onPut = onPut;
                this.dbmuClosed = dbmuClosed;
            }

            // Enable comparisons between nil and driverConn struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(driverConn value, NilType nil) => value.Equals(default(driverConn));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(driverConn value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, driverConn value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, driverConn value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator driverConn(NilType nil) => default(driverConn);
        }

        [GeneratedCode("go2cs", "0.1.0.0")]
        private static driverConn driverConn_cast(dynamic value)
        {
            return new driverConn(ref value.db, value.createdAt, value.Mutex, value.ci, value.closed, value.finalClosed, value.openStmt, value.lastErr, value.inUse, value.onPut, value.dbmuClosed);
        }
    }
}}