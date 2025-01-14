// cgo -godefs -- -Wall -Werror -static -I/tmp/include linux/types.go | go run mkpost.go
// Code generated by the command above; see README.md. DO NOT EDIT.

// +build sparc64,linux

// package unix -- go2cs converted at 2020 October 09 06:00:42 UTC
// import "cmd/vendor/golang.org/x/sys/unix" ==> using unix = go.cmd.vendor.golang.org.x.sys.unix_package
// Original source: C:\Go\src\cmd\vendor\golang.org\x\sys\unix\ztypes_linux_sparc64.go

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
        public static readonly ulong SizeofPtr = (ulong)0x8UL;
        public static readonly ulong SizeofLong = (ulong)0x8UL;


        private partial struct _C_long // : long
        {
        }
        public partial struct Timespec
        {
            public long Sec;
            public long Nsec;
        }

        public partial struct Timeval
        {
            public long Sec;
            public int Usec;
            public array<byte> _;
        }

        public partial struct Timex
        {
            public uint Modes;
            public long Offset;
            public long Freq;
            public long Maxerror;
            public long Esterror;
            public int Status;
            public long Constant;
            public long Precision;
            public long Tolerance;
            public Timeval Time;
            public long Tick;
            public long Ppsfreq;
            public long Jitter;
            public int Shift;
            public long Stabil;
            public long Jitcnt;
            public long Calcnt;
            public long Errcnt;
            public long Stbcnt;
            public int Tai;
            public array<byte> _;
        }

        public partial struct Time_t // : long
        {
        }

        public partial struct Tms
        {
            public long Utime;
            public long Stime;
            public long Cutime;
            public long Cstime;
        }

        public partial struct Utimbuf
        {
            public long Actime;
            public long Modtime;
        }

        public partial struct Rusage
        {
            public Timeval Utime;
            public Timeval Stime;
            public long Maxrss;
            public long Ixrss;
            public long Idrss;
            public long Isrss;
            public long Minflt;
            public long Majflt;
            public long Nswap;
            public long Inblock;
            public long Oublock;
            public long Msgsnd;
            public long Msgrcv;
            public long Nsignals;
            public long Nvcsw;
            public long Nivcsw;
        }

        public partial struct Stat_t
        {
            public ulong Dev;
            public ushort _;
            public ulong Ino;
            public uint Mode;
            public uint Nlink;
            public uint Uid;
            public uint Gid;
            public ulong Rdev;
            public ushort _;
            public long Size;
            public long Blksize;
            public long Blocks;
            public Timespec Atim;
            public Timespec Mtim;
            public Timespec Ctim;
            public ulong _;
            public ulong _;
        }

        public partial struct Dirent
        {
            public ulong Ino;
            public long Off;
            public ushort Reclen;
            public byte Type;
            public array<sbyte> Name;
            public array<byte> _;
        }

        public partial struct Flock_t
        {
            public short Type;
            public short Whence;
            public long Start;
            public long Len;
            public int Pid;
            public short _;
            public array<byte> _;
        }

        public static readonly ulong FADV_DONTNEED = (ulong)0x4UL;
        public static readonly ulong FADV_NOREUSE = (ulong)0x5UL;


        public partial struct RawSockaddr
        {
            public ushort Family;
            public array<sbyte> Data;
        }

        public partial struct RawSockaddrAny
        {
            public RawSockaddr Addr;
            public array<sbyte> Pad;
        }

        public partial struct Iovec
        {
            public ptr<byte> Base;
            public ulong Len;
        }

        public partial struct Msghdr
        {
            public ptr<byte> Name;
            public uint Namelen;
            public ptr<Iovec> Iov;
            public ulong Iovlen;
            public ptr<byte> Control;
            public ulong Controllen;
            public int Flags;
            public array<byte> _;
        }

        public partial struct Cmsghdr
        {
            public ulong Len;
            public int Level;
            public int Type;
        }

        public static readonly ulong SizeofIovec = (ulong)0x10UL;
        public static readonly ulong SizeofMsghdr = (ulong)0x38UL;
        public static readonly ulong SizeofCmsghdr = (ulong)0x10UL;


        public static readonly ulong SizeofSockFprog = (ulong)0x10UL;


        public partial struct PtraceRegs
        {
            public array<ulong> Regs;
            public ulong Tstate;
            public ulong Tpc;
            public ulong Tnpc;
            public uint Y;
            public uint Magic;
        }

        public partial struct FdSet
        {
            public array<long> Bits;
        }

        public partial struct Sysinfo_t
        {
            public long Uptime;
            public array<ulong> Loads;
            public ulong Totalram;
            public ulong Freeram;
            public ulong Sharedram;
            public ulong Bufferram;
            public ulong Totalswap;
            public ulong Freeswap;
            public ushort Procs;
            public ushort Pad;
            public ulong Totalhigh;
            public ulong Freehigh;
            public uint Unit;
            public array<sbyte> _;
            public array<byte> _;
        }

        public partial struct Ustat_t
        {
            public int Tfree;
            public ulong Tinode;
            public array<sbyte> Fname;
            public array<sbyte> Fpack;
            public array<byte> _;
        }

        public partial struct EpollEvent
        {
            public uint Events;
            public int _;
            public int Fd;
            public int Pad;
        }

        public static readonly ulong POLLRDHUP = (ulong)0x800UL;


        public partial struct Sigset_t
        {
            public array<ulong> Val;
        }

        private static readonly ulong _C__NSIG = (ulong)0x41UL;



        public partial struct Termios
        {
            public uint Iflag;
            public uint Oflag;
            public uint Cflag;
            public uint Lflag;
            public byte Line;
            public array<byte> Cc;
            public uint Ispeed;
            public uint Ospeed;
        }

        public partial struct Taskstats
        {
            public ushort Version;
            public uint Ac_exitcode;
            public byte Ac_flag;
            public byte Ac_nice;
            public ulong Cpu_count;
            public ulong Cpu_delay_total;
            public ulong Blkio_count;
            public ulong Blkio_delay_total;
            public ulong Swapin_count;
            public ulong Swapin_delay_total;
            public ulong Cpu_run_real_total;
            public ulong Cpu_run_virtual_total;
            public array<sbyte> Ac_comm;
            public byte Ac_sched;
            public array<byte> Ac_pad;
            public array<byte> _;
            public uint Ac_uid;
            public uint Ac_gid;
            public uint Ac_pid;
            public uint Ac_ppid;
            public uint Ac_btime;
            public ulong Ac_etime;
            public ulong Ac_utime;
            public ulong Ac_stime;
            public ulong Ac_minflt;
            public ulong Ac_majflt;
            public ulong Coremem;
            public ulong Virtmem;
            public ulong Hiwater_rss;
            public ulong Hiwater_vm;
            public ulong Read_char;
            public ulong Write_char;
            public ulong Read_syscalls;
            public ulong Write_syscalls;
            public ulong Read_bytes;
            public ulong Write_bytes;
            public ulong Cancelled_write_bytes;
            public ulong Nvcsw;
            public ulong Nivcsw;
            public ulong Ac_utimescaled;
            public ulong Ac_stimescaled;
            public ulong Cpu_scaled_run_real_total;
            public ulong Freepages_count;
            public ulong Freepages_delay_total;
            public ulong Thrashing_count;
            public ulong Thrashing_delay_total;
            public ulong Ac_btime64;
        }

        private partial struct cpuMask // : ulong
        {
        }

        private static readonly ulong _NCPUBITS = (ulong)0x40UL;


        public static readonly ulong CBitFieldMaskBit0 = (ulong)0x8000000000000000UL;
        public static readonly ulong CBitFieldMaskBit1 = (ulong)0x4000000000000000UL;
        public static readonly ulong CBitFieldMaskBit2 = (ulong)0x2000000000000000UL;
        public static readonly ulong CBitFieldMaskBit3 = (ulong)0x1000000000000000UL;
        public static readonly ulong CBitFieldMaskBit4 = (ulong)0x800000000000000UL;
        public static readonly ulong CBitFieldMaskBit5 = (ulong)0x400000000000000UL;
        public static readonly ulong CBitFieldMaskBit6 = (ulong)0x200000000000000UL;
        public static readonly ulong CBitFieldMaskBit7 = (ulong)0x100000000000000UL;
        public static readonly ulong CBitFieldMaskBit8 = (ulong)0x80000000000000UL;
        public static readonly ulong CBitFieldMaskBit9 = (ulong)0x40000000000000UL;
        public static readonly ulong CBitFieldMaskBit10 = (ulong)0x20000000000000UL;
        public static readonly ulong CBitFieldMaskBit11 = (ulong)0x10000000000000UL;
        public static readonly ulong CBitFieldMaskBit12 = (ulong)0x8000000000000UL;
        public static readonly ulong CBitFieldMaskBit13 = (ulong)0x4000000000000UL;
        public static readonly ulong CBitFieldMaskBit14 = (ulong)0x2000000000000UL;
        public static readonly ulong CBitFieldMaskBit15 = (ulong)0x1000000000000UL;
        public static readonly ulong CBitFieldMaskBit16 = (ulong)0x800000000000UL;
        public static readonly ulong CBitFieldMaskBit17 = (ulong)0x400000000000UL;
        public static readonly ulong CBitFieldMaskBit18 = (ulong)0x200000000000UL;
        public static readonly ulong CBitFieldMaskBit19 = (ulong)0x100000000000UL;
        public static readonly ulong CBitFieldMaskBit20 = (ulong)0x80000000000UL;
        public static readonly ulong CBitFieldMaskBit21 = (ulong)0x40000000000UL;
        public static readonly ulong CBitFieldMaskBit22 = (ulong)0x20000000000UL;
        public static readonly ulong CBitFieldMaskBit23 = (ulong)0x10000000000UL;
        public static readonly ulong CBitFieldMaskBit24 = (ulong)0x8000000000UL;
        public static readonly ulong CBitFieldMaskBit25 = (ulong)0x4000000000UL;
        public static readonly ulong CBitFieldMaskBit26 = (ulong)0x2000000000UL;
        public static readonly ulong CBitFieldMaskBit27 = (ulong)0x1000000000UL;
        public static readonly ulong CBitFieldMaskBit28 = (ulong)0x800000000UL;
        public static readonly ulong CBitFieldMaskBit29 = (ulong)0x400000000UL;
        public static readonly ulong CBitFieldMaskBit30 = (ulong)0x200000000UL;
        public static readonly ulong CBitFieldMaskBit31 = (ulong)0x100000000UL;
        public static readonly ulong CBitFieldMaskBit32 = (ulong)0x80000000UL;
        public static readonly ulong CBitFieldMaskBit33 = (ulong)0x40000000UL;
        public static readonly ulong CBitFieldMaskBit34 = (ulong)0x20000000UL;
        public static readonly ulong CBitFieldMaskBit35 = (ulong)0x10000000UL;
        public static readonly ulong CBitFieldMaskBit36 = (ulong)0x8000000UL;
        public static readonly ulong CBitFieldMaskBit37 = (ulong)0x4000000UL;
        public static readonly ulong CBitFieldMaskBit38 = (ulong)0x2000000UL;
        public static readonly ulong CBitFieldMaskBit39 = (ulong)0x1000000UL;
        public static readonly ulong CBitFieldMaskBit40 = (ulong)0x800000UL;
        public static readonly ulong CBitFieldMaskBit41 = (ulong)0x400000UL;
        public static readonly ulong CBitFieldMaskBit42 = (ulong)0x200000UL;
        public static readonly ulong CBitFieldMaskBit43 = (ulong)0x100000UL;
        public static readonly ulong CBitFieldMaskBit44 = (ulong)0x80000UL;
        public static readonly ulong CBitFieldMaskBit45 = (ulong)0x40000UL;
        public static readonly ulong CBitFieldMaskBit46 = (ulong)0x20000UL;
        public static readonly ulong CBitFieldMaskBit47 = (ulong)0x10000UL;
        public static readonly ulong CBitFieldMaskBit48 = (ulong)0x8000UL;
        public static readonly ulong CBitFieldMaskBit49 = (ulong)0x4000UL;
        public static readonly ulong CBitFieldMaskBit50 = (ulong)0x2000UL;
        public static readonly ulong CBitFieldMaskBit51 = (ulong)0x1000UL;
        public static readonly ulong CBitFieldMaskBit52 = (ulong)0x800UL;
        public static readonly ulong CBitFieldMaskBit53 = (ulong)0x400UL;
        public static readonly ulong CBitFieldMaskBit54 = (ulong)0x200UL;
        public static readonly ulong CBitFieldMaskBit55 = (ulong)0x100UL;
        public static readonly ulong CBitFieldMaskBit56 = (ulong)0x80UL;
        public static readonly ulong CBitFieldMaskBit57 = (ulong)0x40UL;
        public static readonly ulong CBitFieldMaskBit58 = (ulong)0x20UL;
        public static readonly ulong CBitFieldMaskBit59 = (ulong)0x10UL;
        public static readonly ulong CBitFieldMaskBit60 = (ulong)0x8UL;
        public static readonly ulong CBitFieldMaskBit61 = (ulong)0x4UL;
        public static readonly ulong CBitFieldMaskBit62 = (ulong)0x2UL;
        public static readonly ulong CBitFieldMaskBit63 = (ulong)0x1UL;


        public partial struct SockaddrStorage
        {
            public ushort Family;
            public array<sbyte> _;
            public ulong _;
        }

        public partial struct HDGeometry
        {
            public byte Heads;
            public byte Sectors;
            public ushort Cylinders;
            public ulong Start;
        }

        public partial struct Statfs_t
        {
            public long Type;
            public long Bsize;
            public ulong Blocks;
            public ulong Bfree;
            public ulong Bavail;
            public ulong Files;
            public ulong Ffree;
            public Fsid Fsid;
            public long Namelen;
            public long Frsize;
            public long Flags;
            public array<long> Spare;
        }

        public partial struct TpacketHdr
        {
            public ulong Status;
            public uint Len;
            public uint Snaplen;
            public ushort Mac;
            public ushort Net;
            public uint Sec;
            public uint Usec;
            public array<byte> _;
        }

        public static readonly ulong SizeofTpacketHdr = (ulong)0x20UL;


        public partial struct RTCPLLInfo
        {
            public int Ctrl;
            public int Value;
            public int Max;
            public int Min;
            public int Posmult;
            public int Negmult;
            public long Clock;
        }

        public partial struct BlkpgPartition
        {
            public long Start;
            public long Length;
            public int Pno;
            public array<byte> Devname;
            public array<byte> Volname;
            public array<byte> _;
        }

        public static readonly ulong BLKPG = (ulong)0x20001269UL;


        public partial struct XDPUmemReg
        {
            public ulong Addr;
            public ulong Len;
            public uint Size;
            public uint Headroom;
            public uint Flags;
            public array<byte> _;
        }

        public partial struct CryptoUserAlg
        {
            public array<sbyte> Name;
            public array<sbyte> Driver_name;
            public array<sbyte> Module_name;
            public uint Type;
            public uint Mask;
            public uint Refcnt;
            public uint Flags;
        }

        public partial struct CryptoStatAEAD
        {
            public array<sbyte> Type;
            public ulong Encrypt_cnt;
            public ulong Encrypt_tlen;
            public ulong Decrypt_cnt;
            public ulong Decrypt_tlen;
            public ulong Err_cnt;
        }

        public partial struct CryptoStatAKCipher
        {
            public array<sbyte> Type;
            public ulong Encrypt_cnt;
            public ulong Encrypt_tlen;
            public ulong Decrypt_cnt;
            public ulong Decrypt_tlen;
            public ulong Verify_cnt;
            public ulong Sign_cnt;
            public ulong Err_cnt;
        }

        public partial struct CryptoStatCipher
        {
            public array<sbyte> Type;
            public ulong Encrypt_cnt;
            public ulong Encrypt_tlen;
            public ulong Decrypt_cnt;
            public ulong Decrypt_tlen;
            public ulong Err_cnt;
        }

        public partial struct CryptoStatCompress
        {
            public array<sbyte> Type;
            public ulong Compress_cnt;
            public ulong Compress_tlen;
            public ulong Decompress_cnt;
            public ulong Decompress_tlen;
            public ulong Err_cnt;
        }

        public partial struct CryptoStatHash
        {
            public array<sbyte> Type;
            public ulong Hash_cnt;
            public ulong Hash_tlen;
            public ulong Err_cnt;
        }

        public partial struct CryptoStatKPP
        {
            public array<sbyte> Type;
            public ulong Setsecret_cnt;
            public ulong Generate_public_key_cnt;
            public ulong Compute_shared_secret_cnt;
            public ulong Err_cnt;
        }

        public partial struct CryptoStatRNG
        {
            public array<sbyte> Type;
            public ulong Generate_cnt;
            public ulong Generate_tlen;
            public ulong Seed_cnt;
            public ulong Err_cnt;
        }

        public partial struct CryptoStatLarval
        {
            public array<sbyte> Type;
        }

        public partial struct CryptoReportLarval
        {
            public array<sbyte> Type;
        }

        public partial struct CryptoReportHash
        {
            public array<sbyte> Type;
            public uint Blocksize;
            public uint Digestsize;
        }

        public partial struct CryptoReportCipher
        {
            public array<sbyte> Type;
            public uint Blocksize;
            public uint Min_keysize;
            public uint Max_keysize;
        }

        public partial struct CryptoReportBlkCipher
        {
            public array<sbyte> Type;
            public array<sbyte> Geniv;
            public uint Blocksize;
            public uint Min_keysize;
            public uint Max_keysize;
            public uint Ivsize;
        }

        public partial struct CryptoReportAEAD
        {
            public array<sbyte> Type;
            public array<sbyte> Geniv;
            public uint Blocksize;
            public uint Maxauthsize;
            public uint Ivsize;
        }

        public partial struct CryptoReportComp
        {
            public array<sbyte> Type;
        }

        public partial struct CryptoReportRNG
        {
            public array<sbyte> Type;
            public uint Seedsize;
        }

        public partial struct CryptoReportAKCipher
        {
            public array<sbyte> Type;
        }

        public partial struct CryptoReportKPP
        {
            public array<sbyte> Type;
        }

        public partial struct CryptoReportAcomp
        {
            public array<sbyte> Type;
        }

        public partial struct LoopInfo
        {
            public int Number;
            public uint Device;
            public ulong Inode;
            public uint Rdevice;
            public int Offset;
            public int Encrypt_type;
            public int Encrypt_key_size;
            public int Flags;
            public array<sbyte> Name;
            public array<byte> Encrypt_key;
            public array<ulong> Init;
            public array<sbyte> Reserved;
            public array<byte> _;
        }

        public partial struct TIPCSubscr
        {
            public TIPCServiceRange Seq;
            public uint Timeout;
            public uint Filter;
            public array<sbyte> Handle;
        }

        public partial struct TIPCSIOCLNReq
        {
            public uint Peer;
            public uint Id;
            public array<sbyte> Linkname;
        }

        public partial struct TIPCSIOCNodeIDReq
        {
            public uint Peer;
            public array<sbyte> Id;
        }
    }
}}}}}}
