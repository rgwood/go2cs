// Code generated by cmd/cgo -godefs; DO NOT EDIT.
// cgo -godefs -- -fsigned-char types_freebsd.go

// +build arm,freebsd

// package syscall -- go2cs converted at 2020 October 09 05:04:24 UTC
// import "syscall" ==> using syscall = go.syscall_package
// Original source: C:\Go\src\syscall\ztypes_freebsd_arm.go

using static go.builtin;

namespace go
{
    public static partial class syscall_package
    {
        private static readonly ulong sizeofPtr = (ulong)0x4UL;
        private static readonly ulong sizeofShort = (ulong)0x2UL;
        private static readonly ulong sizeofInt = (ulong)0x4UL;
        private static readonly ulong sizeofLong = (ulong)0x4UL;
        private static readonly ulong sizeofLongLong = (ulong)0x8UL;


        private partial struct _C_short // : short
        {
        }
        private partial struct _C_int // : int
        {
        }
        private partial struct _C_long // : int
        {
        }
        private partial struct _C_long_long // : long
        {
        }
        public partial struct Timespec
        {
            public long Sec;
            public int Nsec;
            public array<byte> Pad_cgo_0;
        }

        public partial struct Timeval
        {
            public long Sec;
            public int Usec;
            public array<byte> Pad_cgo_0;
        }

        public partial struct Rusage
        {
            public Timeval Utime;
            public Timeval Stime;
            public int Maxrss;
            public int Ixrss;
            public int Idrss;
            public int Isrss;
            public int Minflt;
            public int Majflt;
            public int Nswap;
            public int Inblock;
            public int Oublock;
            public int Msgsnd;
            public int Msgrcv;
            public int Nsignals;
            public int Nvcsw;
            public int Nivcsw;
        }

        public partial struct Rlimit
        {
            public long Cur;
            public long Max;
        }

        private partial struct _Gid_t // : uint
        {
        }

        public static readonly ulong S_IFMT = (ulong)0xf000UL;
        public static readonly ulong S_IFIFO = (ulong)0x1000UL;
        public static readonly ulong S_IFCHR = (ulong)0x2000UL;
        public static readonly ulong S_IFDIR = (ulong)0x4000UL;
        public static readonly ulong S_IFBLK = (ulong)0x6000UL;
        public static readonly ulong S_IFREG = (ulong)0x8000UL;
        public static readonly ulong S_IFLNK = (ulong)0xa000UL;
        public static readonly ulong S_IFSOCK = (ulong)0xc000UL;
        public static readonly ulong S_ISUID = (ulong)0x800UL;
        public static readonly ulong S_ISGID = (ulong)0x400UL;
        public static readonly ulong S_ISVTX = (ulong)0x200UL;
        public static readonly ulong S_IRUSR = (ulong)0x100UL;
        public static readonly ulong S_IWUSR = (ulong)0x80UL;
        public static readonly ulong S_IXUSR = (ulong)0x40UL;
        public static readonly ulong S_IRWXG = (ulong)0x38UL;
        public static readonly ulong S_IRWXO = (ulong)0x7UL;


        private static readonly ulong _statfsVersion = (ulong)0x20140518UL;
        private static readonly ulong _dirblksiz = (ulong)0x400UL;


        public partial struct Stat_t
        {
            public ulong Dev;
            public ulong Ino;
            public ulong Nlink;
            public ushort Mode;
            public short Padding0;
            public uint Uid;
            public uint Gid;
            public int Padding1;
            public ulong Rdev;
            public Timespec Atimespec;
            public Timespec Mtimespec;
            public Timespec Ctimespec;
            public Timespec Birthtimespec;
            public long Size;
            public long Blocks;
            public int Blksize;
            public uint Flags;
            public ulong Gen;
            public array<ulong> Spare;
        }

        private partial struct stat_freebsd11_t
        {
            public uint Dev;
            public uint Ino;
            public ushort Mode;
            public ushort Nlink;
            public uint Uid;
            public uint Gid;
            public uint Rdev;
            public Timespec Atimespec;
            public Timespec Mtimespec;
            public Timespec Ctimespec;
            public long Size;
            public long Blocks;
            public int Blksize;
            public uint Flags;
            public uint Gen;
            public int Lspare;
            public Timespec Birthtimespec;
        }

        public partial struct Statfs_t
        {
            public uint Version;
            public uint Type;
            public ulong Flags;
            public ulong Bsize;
            public ulong Iosize;
            public ulong Blocks;
            public ulong Bfree;
            public long Bavail;
            public ulong Files;
            public long Ffree;
            public ulong Syncwrites;
            public ulong Asyncwrites;
            public ulong Syncreads;
            public ulong Asyncreads;
            public array<ulong> Spare;
            public uint Namemax;
            public uint Owner;
            public Fsid Fsid;
            public array<sbyte> Charspare;
            public array<sbyte> Fstypename;
            public array<sbyte> Mntfromname;
            public array<sbyte> Mntonname;
        }

        private partial struct statfs_freebsd11_t
        {
            public uint Version;
            public uint Type;
            public ulong Flags;
            public ulong Bsize;
            public ulong Iosize;
            public ulong Blocks;
            public ulong Bfree;
            public long Bavail;
            public ulong Files;
            public long Ffree;
            public ulong Syncwrites;
            public ulong Asyncwrites;
            public ulong Syncreads;
            public ulong Asyncreads;
            public array<ulong> Spare;
            public uint Namemax;
            public uint Owner;
            public Fsid Fsid;
            public array<sbyte> Charspare;
            public array<sbyte> Fstypename;
            public array<sbyte> Mntfromname;
            public array<sbyte> Mntonname;
        }

        public partial struct Flock_t
        {
            public long Start;
            public long Len;
            public int Pid;
            public short Type;
            public short Whence;
            public int Sysid;
            public array<byte> Pad_cgo_0;
        }

        public partial struct Dirent
        {
            public ulong Fileno;
            public long Off;
            public ushort Reclen;
            public byte Type;
            public byte Pad0;
            public ushort Namlen;
            public ushort Pad1;
            public array<sbyte> Name;
        }

        private partial struct dirent_freebsd11
        {
            public uint Fileno;
            public ushort Reclen;
            public byte Type;
            public byte Namlen;
            public array<sbyte> Name;
        }

        public partial struct Fsid
        {
            public array<int> Val;
        }

        private static readonly ulong pathMax = (ulong)0x400UL;


        public partial struct RawSockaddrInet4
        {
            public byte Len;
            public byte Family;
            public ushort Port;
            public array<byte> Addr; /* in_addr */
            public array<sbyte> Zero;
        }

        public partial struct RawSockaddrInet6
        {
            public byte Len;
            public byte Family;
            public ushort Port;
            public uint Flowinfo;
            public array<byte> Addr; /* in6_addr */
            public uint Scope_id;
        }

        public partial struct RawSockaddrUnix
        {
            public byte Len;
            public byte Family;
            public array<sbyte> Path;
        }

        public partial struct RawSockaddrDatalink
        {
            public byte Len;
            public byte Family;
            public ushort Index;
            public byte Type;
            public byte Nlen;
            public byte Alen;
            public byte Slen;
            public array<sbyte> Data;
        }

        public partial struct RawSockaddr
        {
            public byte Len;
            public byte Family;
            public array<sbyte> Data;
        }

        public partial struct RawSockaddrAny
        {
            public RawSockaddr Addr;
            public array<sbyte> Pad;
        }

        private partial struct _Socklen // : uint
        {
        }

        public partial struct Linger
        {
            public int Onoff;
            public int Linger;
        }

        public partial struct Iovec
        {
            public ptr<byte> Base;
            public uint Len;
        }

        public partial struct IPMreq
        {
            public array<byte> Multiaddr; /* in_addr */
            public array<byte> Interface; /* in_addr */
        }

        public partial struct IPMreqn
        {
            public array<byte> Multiaddr; /* in_addr */
            public array<byte> Address; /* in_addr */
            public int Ifindex;
        }

        public partial struct IPv6Mreq
        {
            public array<byte> Multiaddr; /* in6_addr */
            public uint Interface;
        }

        public partial struct Msghdr
        {
            public ptr<byte> Name;
            public uint Namelen;
            public ptr<Iovec> Iov;
            public int Iovlen;
            public ptr<byte> Control;
            public uint Controllen;
            public int Flags;
        }

        public partial struct Cmsghdr
        {
            public uint Len;
            public int Level;
            public int Type;
        }

        public partial struct Inet6Pktinfo
        {
            public array<byte> Addr; /* in6_addr */
            public uint Ifindex;
        }

        public partial struct IPv6MTUInfo
        {
            public RawSockaddrInet6 Addr;
            public uint Mtu;
        }

        public partial struct ICMPv6Filter
        {
            public array<uint> Filt;
        }

        public static readonly ulong SizeofSockaddrInet4 = (ulong)0x10UL;
        public static readonly ulong SizeofSockaddrInet6 = (ulong)0x1cUL;
        public static readonly ulong SizeofSockaddrAny = (ulong)0x6cUL;
        public static readonly ulong SizeofSockaddrUnix = (ulong)0x6aUL;
        public static readonly ulong SizeofSockaddrDatalink = (ulong)0x36UL;
        public static readonly ulong SizeofLinger = (ulong)0x8UL;
        public static readonly ulong SizeofIPMreq = (ulong)0x8UL;
        public static readonly ulong SizeofIPMreqn = (ulong)0xcUL;
        public static readonly ulong SizeofIPv6Mreq = (ulong)0x14UL;
        public static readonly ulong SizeofMsghdr = (ulong)0x1cUL;
        public static readonly ulong SizeofCmsghdr = (ulong)0xcUL;
        public static readonly ulong SizeofInet6Pktinfo = (ulong)0x14UL;
        public static readonly ulong SizeofIPv6MTUInfo = (ulong)0x20UL;
        public static readonly ulong SizeofICMPv6Filter = (ulong)0x20UL;


        public static readonly ulong PTRACE_TRACEME = (ulong)0x0UL;
        public static readonly ulong PTRACE_CONT = (ulong)0x7UL;
        public static readonly ulong PTRACE_KILL = (ulong)0x8UL;


        public partial struct Kevent_t
        {
            public uint Ident;
            public short Filter;
            public ushort Flags;
            public uint Fflags;
            public int Data;
            public ptr<byte> Udata;
        }

        public partial struct FdSet
        {
            public array<uint> X__fds_bits;
        }

        private static readonly ulong sizeofIfMsghdr = (ulong)0x70UL;
        public static readonly ulong SizeofIfMsghdr = (ulong)0x70UL;
        private static readonly ulong sizeofIfData = (ulong)0x60UL;
        public static readonly ulong SizeofIfData = (ulong)0x60UL;
        public static readonly ulong SizeofIfaMsghdr = (ulong)0x14UL;
        public static readonly ulong SizeofIfmaMsghdr = (ulong)0x10UL;
        public static readonly ulong SizeofIfAnnounceMsghdr = (ulong)0x18UL;
        public static readonly ulong SizeofRtMsghdr = (ulong)0x5cUL;
        public static readonly ulong SizeofRtMetrics = (ulong)0x38UL;


        private partial struct ifMsghdr
        {
            public ushort Msglen;
            public byte Version;
            public byte Type;
            public int Addrs;
            public int Flags;
            public ushort Index;
            public array<byte> Pad_cgo_0;
            public ifData Data;
        }

        public partial struct IfMsghdr
        {
            public ushort Msglen;
            public byte Version;
            public byte Type;
            public int Addrs;
            public int Flags;
            public ushort Index;
            public array<byte> Pad_cgo_0;
            public IfData Data;
        }

        private partial struct ifData
        {
            public byte Type;
            public byte Physical;
            public byte Addrlen;
            public byte Hdrlen;
            public byte Link_state;
            public byte Vhid;
            public byte Baudrate_pf;
            public byte Datalen;
            public uint Mtu;
            public uint Metric;
            public uint Baudrate;
            public uint Ipackets;
            public uint Ierrors;
            public uint Opackets;
            public uint Oerrors;
            public uint Collisions;
            public uint Ibytes;
            public uint Obytes;
            public uint Imcasts;
            public uint Omcasts;
            public uint Iqdrops;
            public uint Noproto;
            public ulong Hwassist;
            public long Epoch;
            public Timeval Lastchange;
        }

        public partial struct IfData
        {
            public byte Type;
            public byte Physical;
            public byte Addrlen;
            public byte Hdrlen;
            public byte Link_state;
            public byte Spare_char1;
            public byte Spare_char2;
            public byte Datalen;
            public uint Mtu;
            public uint Metric;
            public uint Baudrate;
            public uint Ipackets;
            public uint Ierrors;
            public uint Opackets;
            public uint Oerrors;
            public uint Collisions;
            public uint Ibytes;
            public uint Obytes;
            public uint Imcasts;
            public uint Omcasts;
            public uint Iqdrops;
            public uint Noproto;
            public uint Hwassist;
            public array<byte> Pad_cgo_0;
            public long Epoch;
            public Timeval Lastchange;
        }

        public partial struct IfaMsghdr
        {
            public ushort Msglen;
            public byte Version;
            public byte Type;
            public int Addrs;
            public int Flags;
            public ushort Index;
            public array<byte> Pad_cgo_0;
            public int Metric;
        }

        public partial struct IfmaMsghdr
        {
            public ushort Msglen;
            public byte Version;
            public byte Type;
            public int Addrs;
            public int Flags;
            public ushort Index;
            public array<byte> Pad_cgo_0;
        }

        public partial struct IfAnnounceMsghdr
        {
            public ushort Msglen;
            public byte Version;
            public byte Type;
            public ushort Index;
            public array<sbyte> Name;
            public ushort What;
        }

        public partial struct RtMsghdr
        {
            public ushort Msglen;
            public byte Version;
            public byte Type;
            public ushort Index;
            public array<byte> Pad_cgo_0;
            public int Flags;
            public int Addrs;
            public int Pid;
            public int Seq;
            public int Errno;
            public int Fmask;
            public uint Inits;
            public RtMetrics Rmx;
        }

        public partial struct RtMetrics
        {
            public uint Locks;
            public uint Mtu;
            public uint Hopcount;
            public uint Expire;
            public uint Recvpipe;
            public uint Sendpipe;
            public uint Ssthresh;
            public uint Rtt;
            public uint Rttvar;
            public uint Pksent;
            public uint Weight;
            public array<uint> Filler;
        }

        public static readonly ulong SizeofBpfVersion = (ulong)0x4UL;
        public static readonly ulong SizeofBpfStat = (ulong)0x8UL;
        public static readonly ulong SizeofBpfZbuf = (ulong)0xcUL;
        public static readonly ulong SizeofBpfProgram = (ulong)0x8UL;
        public static readonly ulong SizeofBpfInsn = (ulong)0x8UL;
        public static readonly ulong SizeofBpfHdr = (ulong)0x20UL;
        public static readonly ulong SizeofBpfZbufHeader = (ulong)0x20UL;


        public partial struct BpfVersion
        {
            public ushort Major;
            public ushort Minor;
        }

        public partial struct BpfStat
        {
            public uint Recv;
            public uint Drop;
        }

        public partial struct BpfZbuf
        {
            public ptr<byte> Bufa;
            public ptr<byte> Bufb;
            public uint Buflen;
        }

        public partial struct BpfProgram
        {
            public uint Len;
            public ptr<BpfInsn> Insns;
        }

        public partial struct BpfInsn
        {
            public ushort Code;
            public byte Jt;
            public byte Jf;
            public uint K;
        }

        public partial struct BpfHdr
        {
            public Timeval Tstamp;
            public uint Caplen;
            public uint Datalen;
            public ushort Hdrlen;
            public array<byte> Pad_cgo_0;
        }

        public partial struct BpfZbufHeader
        {
            public uint Kernel_gen;
            public uint Kernel_len;
            public uint User_gen;
            public array<uint> X_bzh_pad;
        }

        private static readonly ulong _AT_FDCWD = (ulong)-0x64UL;
        private static readonly ulong _AT_SYMLINK_FOLLOW = (ulong)0x400UL;
        private static readonly ulong _AT_SYMLINK_NOFOLLOW = (ulong)0x200UL;


        public partial struct Termios
        {
            public uint Iflag;
            public uint Oflag;
            public uint Cflag;
            public uint Lflag;
            public array<byte> Cc;
            public uint Ispeed;
            public uint Ospeed;
        }
    }
}
