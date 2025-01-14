// Copyright 2015 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// +build linux
// +build mips64 mips64le

// package unix -- go2cs converted at 2020 October 09 05:56:50 UTC
// import "cmd/vendor/golang.org/x/sys/unix" ==> using unix = go.cmd.vendor.golang.org.x.sys.unix_package
// Original source: C:\Go\src\cmd\vendor\golang.org\x\sys\unix\syscall_linux_mips64x.go

using static go.builtin;

namespace go {
namespace cmd {
namespace vendor {
namespace golang.org {
namespace x {
namespace sys
{
    public static partial class unix_package
    {
        //sys    dup2(oldfd int, newfd int) (err error)
        //sysnb    EpollCreate(size int) (fd int, err error)
        //sys    EpollWait(epfd int, events []EpollEvent, msec int) (n int, err error)
        //sys    Fadvise(fd int, offset int64, length int64, advice int) (err error) = SYS_FADVISE64
        //sys    Fchown(fd int, uid int, gid int) (err error)
        //sys    Fstatfs(fd int, buf *Statfs_t) (err error)
        //sys    Ftruncate(fd int, length int64) (err error)
        //sysnb    Getegid() (egid int)
        //sysnb    Geteuid() (euid int)
        //sysnb    Getgid() (gid int)
        //sysnb    Getrlimit(resource int, rlim *Rlimit) (err error)
        //sysnb    Getuid() (uid int)
        //sys    Lchown(path string, uid int, gid int) (err error)
        //sys    Listen(s int, n int) (err error)
        //sys    Pause() (err error)
        //sys    Pread(fd int, p []byte, offset int64) (n int, err error) = SYS_PREAD64
        //sys    Pwrite(fd int, p []byte, offset int64) (n int, err error) = SYS_PWRITE64
        //sys    Renameat(olddirfd int, oldpath string, newdirfd int, newpath string) (err error)
        //sys    Seek(fd int, offset int64, whence int) (off int64, err error) = SYS_LSEEK
        public static (long, error) Select(long nfd, ptr<FdSet> _addr_r, ptr<FdSet> _addr_w, ptr<FdSet> _addr_e, ptr<Timeval> _addr_timeout)
        {
            long n = default;
            error err = default!;
            ref FdSet r = ref _addr_r.val;
            ref FdSet w = ref _addr_w.val;
            ref FdSet e = ref _addr_e.val;
            ref Timeval timeout = ref _addr_timeout.val;

            ptr<Timespec> ts;
            if (timeout != null)
            {
                ts = addr(new Timespec(Sec:timeout.Sec,Nsec:timeout.Usec*1000));
            }
            return Pselect(nfd, r, w, e, ts, null);

        }

        //sys    sendfile(outfd int, infd int, offset *int64, count int) (written int, err error)
        //sys    setfsgid(gid int) (prev int, err error)
        //sys    setfsuid(uid int) (prev int, err error)
        //sysnb    Setregid(rgid int, egid int) (err error)
        //sysnb    Setresgid(rgid int, egid int, sgid int) (err error)
        //sysnb    Setresuid(ruid int, euid int, suid int) (err error)
        //sysnb    Setrlimit(resource int, rlim *Rlimit) (err error)
        //sysnb    Setreuid(ruid int, euid int) (err error)
        //sys    Shutdown(fd int, how int) (err error)
        //sys    Splice(rfd int, roff *int64, wfd int, woff *int64, len int, flags int) (n int64, err error)
        //sys    Statfs(path string, buf *Statfs_t) (err error)
        //sys    SyncFileRange(fd int, off int64, n int64, flags int) (err error)
        //sys    Truncate(path string, length int64) (err error)
        //sys    Ustat(dev int, ubuf *Ustat_t) (err error)
        //sys    accept(s int, rsa *RawSockaddrAny, addrlen *_Socklen) (fd int, err error)
        //sys    accept4(s int, rsa *RawSockaddrAny, addrlen *_Socklen, flags int) (fd int, err error)
        //sys    bind(s int, addr unsafe.Pointer, addrlen _Socklen) (err error)
        //sys    connect(s int, addr unsafe.Pointer, addrlen _Socklen) (err error)
        //sysnb    getgroups(n int, list *_Gid_t) (nn int, err error)
        //sysnb    setgroups(n int, list *_Gid_t) (err error)
        //sys    getsockopt(s int, level int, name int, val unsafe.Pointer, vallen *_Socklen) (err error)
        //sys    setsockopt(s int, level int, name int, val unsafe.Pointer, vallen uintptr) (err error)
        //sysnb    socket(domain int, typ int, proto int) (fd int, err error)
        //sysnb    socketpair(domain int, typ int, proto int, fd *[2]int32) (err error)
        //sysnb    getpeername(fd int, rsa *RawSockaddrAny, addrlen *_Socklen) (err error)
        //sysnb    getsockname(fd int, rsa *RawSockaddrAny, addrlen *_Socklen) (err error)
        //sys    recvfrom(fd int, p []byte, flags int, from *RawSockaddrAny, fromlen *_Socklen) (n int, err error)
        //sys    sendto(s int, buf []byte, flags int, to unsafe.Pointer, addrlen _Socklen) (err error)
        //sys    recvmsg(s int, msg *Msghdr, flags int) (n int, err error)
        //sys    sendmsg(s int, msg *Msghdr, flags int) (n int, err error)
        //sys    mmap(addr uintptr, length uintptr, prot int, flags int, fd int, offset int64) (xaddr uintptr, err error)

        //sys    futimesat(dirfd int, path string, times *[2]Timeval) (err error)
        //sysnb    Gettimeofday(tv *Timeval) (err error)

        public static (Time_t, error) Time(ptr<Time_t> _addr_t)
        {
            Time_t tt = default;
            error err = default!;
            ref Time_t t = ref _addr_t.val;

            ref Timeval tv = ref heap(out ptr<Timeval> _addr_tv);
            err = Gettimeofday(_addr_tv);
            if (err != null)
            {
                return (0L, error.As(err)!);
            }

            if (t != null)
            {
                t = Time_t(tv.Sec);
            }

            return (Time_t(tv.Sec), error.As(null!)!);

        }

        //sys    Utime(path string, buf *Utimbuf) (err error)
        //sys    utimes(path string, times *[2]Timeval) (err error)

        private static Timespec setTimespec(long sec, long nsec)
        {
            return new Timespec(Sec:sec,Nsec:nsec);
        }

        private static Timeval setTimeval(long sec, long usec)
        {
            return new Timeval(Sec:sec,Usec:usec);
        }

        public static error Pipe(slice<long> p)
        {
            error err = default!;

            if (len(p) != 2L)
            {
                return error.As(EINVAL)!;
            }

            ref array<_C_int> pp = ref heap(new array<_C_int>(2L), out ptr<array<_C_int>> _addr_pp);
            err = pipe2(_addr_pp, 0L);
            p[0L] = int(pp[0L]);
            p[1L] = int(pp[1L]);
            return ;

        }

        //sysnb pipe2(p *[2]_C_int, flags int) (err error)

        public static error Pipe2(slice<long> p, long flags)
        {
            error err = default!;

            if (len(p) != 2L)
            {
                return error.As(EINVAL)!;
            }

            ref array<_C_int> pp = ref heap(new array<_C_int>(2L), out ptr<array<_C_int>> _addr_pp);
            err = pipe2(_addr_pp, flags);
            p[0L] = int(pp[0L]);
            p[1L] = int(pp[1L]);
            return ;

        }

        public static error Ioperm(long from, long num, long on)
        {
            error err = default!;

            return error.As(ENOSYS)!;
        }

        public static error Iopl(long level)
        {
            error err = default!;

            return error.As(ENOSYS)!;
        }

        private partial struct stat_t
        {
            public uint Dev;
            public array<int> Pad0;
            public ulong Ino;
            public uint Mode;
            public uint Nlink;
            public uint Uid;
            public uint Gid;
            public uint Rdev;
            public array<uint> Pad1;
            public long Size;
            public uint Atime;
            public uint Atime_nsec;
            public uint Mtime;
            public uint Mtime_nsec;
            public uint Ctime;
            public uint Ctime_nsec;
            public uint Blksize;
            public uint Pad2;
            public long Blocks;
        }

        //sys    fstat(fd int, st *stat_t) (err error)
        //sys    fstatat(dirfd int, path string, st *stat_t, flags int) (err error) = SYS_NEWFSTATAT
        //sys    lstat(path string, st *stat_t) (err error)
        //sys    stat(path string, st *stat_t) (err error)

        public static error Fstat(long fd, ptr<Stat_t> _addr_s)
        {
            error err = default!;
            ref Stat_t s = ref _addr_s.val;

            ptr<stat_t> st = addr(new stat_t());
            err = fstat(fd, st);
            fillStat_t(_addr_s, st);
            return ;
        }

        public static error Fstatat(long dirfd, @string path, ptr<Stat_t> _addr_s, long flags)
        {
            error err = default!;
            ref Stat_t s = ref _addr_s.val;

            ptr<stat_t> st = addr(new stat_t());
            err = fstatat(dirfd, path, st, flags);
            fillStat_t(_addr_s, st);
            return ;
        }

        public static error Lstat(@string path, ptr<Stat_t> _addr_s)
        {
            error err = default!;
            ref Stat_t s = ref _addr_s.val;

            ptr<stat_t> st = addr(new stat_t());
            err = lstat(path, st);
            fillStat_t(_addr_s, st);
            return ;
        }

        public static error Stat(@string path, ptr<Stat_t> _addr_s)
        {
            error err = default!;
            ref Stat_t s = ref _addr_s.val;

            ptr<stat_t> st = addr(new stat_t());
            err = stat(path, st);
            fillStat_t(_addr_s, st);
            return ;
        }

        private static void fillStat_t(ptr<Stat_t> _addr_s, ptr<stat_t> _addr_st)
        {
            ref Stat_t s = ref _addr_s.val;
            ref stat_t st = ref _addr_st.val;

            s.Dev = st.Dev;
            s.Ino = st.Ino;
            s.Mode = st.Mode;
            s.Nlink = st.Nlink;
            s.Uid = st.Uid;
            s.Gid = st.Gid;
            s.Rdev = st.Rdev;
            s.Size = st.Size;
            s.Atim = new Timespec(int64(st.Atime),int64(st.Atime_nsec));
            s.Mtim = new Timespec(int64(st.Mtime),int64(st.Mtime_nsec));
            s.Ctim = new Timespec(int64(st.Ctime),int64(st.Ctime_nsec));
            s.Blksize = st.Blksize;
            s.Blocks = st.Blocks;
        }

        private static ulong PC(this ptr<PtraceRegs> _addr_r)
        {
            ref PtraceRegs r = ref _addr_r.val;

            return r.Epc;
        }

        private static void SetPC(this ptr<PtraceRegs> _addr_r, ulong pc)
        {
            ref PtraceRegs r = ref _addr_r.val;

            r.Epc = pc;
        }

        private static void SetLen(this ptr<Iovec> _addr_iov, long length)
        {
            ref Iovec iov = ref _addr_iov.val;

            iov.Len = uint64(length);
        }

        private static void SetControllen(this ptr<Msghdr> _addr_msghdr, long length)
        {
            ref Msghdr msghdr = ref _addr_msghdr.val;

            msghdr.Controllen = uint64(length);
        }

        private static void SetIovlen(this ptr<Msghdr> _addr_msghdr, long length)
        {
            ref Msghdr msghdr = ref _addr_msghdr.val;

            msghdr.Iovlen = uint64(length);
        }

        private static void SetLen(this ptr<Cmsghdr> _addr_cmsg, long length)
        {
            ref Cmsghdr cmsg = ref _addr_cmsg.val;

            cmsg.Len = uint64(length);
        }

        public static (long, error) InotifyInit()
        {
            long fd = default;
            error err = default!;

            return InotifyInit1(0L);
        }

        //sys    poll(fds *PollFd, nfds int, timeout int) (n int, err error)

        public static (long, error) Poll(slice<PollFd> fds, long timeout)
        {
            long n = default;
            error err = default!;

            if (len(fds) == 0L)
            {
                return poll(null, 0L, timeout);
            }

            return poll(_addr_fds[0L], len(fds), timeout);

        }
    }
}}}}}}
