// Code generated by cmd/cgo -godefs; DO NOT EDIT.
// cgo -godefs defs_solaris.go

// package lif -- go2cs converted at 2020 October 09 04:51:49 UTC
// import "golang.org/x/net/lif" ==> using lif = go.golang.org.x.net.lif_package
// Original source: C:\Users\ritchie\go\src\golang.org\x\net\lif\zsys_solaris_amd64.go

using static go.builtin;

namespace go {
namespace golang.org {
namespace x {
namespace net
{
    public static partial class lif_package
    {
        private static readonly ulong sysAF_UNSPEC = (ulong)0x0UL;
        private static readonly ulong sysAF_INET = (ulong)0x2UL;
        private static readonly ulong sysAF_INET6 = (ulong)0x1aUL;

        private static readonly ulong sysSOCK_DGRAM = (ulong)0x1UL;


        private partial struct sockaddrStorage
        {
            public ushort Family;
            public array<sbyte> X_ss_pad1;
            public double X_ss_align;
            public array<sbyte> X_ss_pad2;
        }

        private static readonly ulong sysLIFC_NOXMIT = (ulong)0x1UL;
        private static readonly ulong sysLIFC_EXTERNAL_SOURCE = (ulong)0x2UL;
        private static readonly ulong sysLIFC_TEMPORARY = (ulong)0x4UL;
        private static readonly ulong sysLIFC_ALLZONES = (ulong)0x8UL;
        private static readonly ulong sysLIFC_UNDER_IPMP = (ulong)0x10UL;
        private static readonly ulong sysLIFC_ENABLED = (ulong)0x20UL;

        private static readonly ulong sysSIOCGLIFADDR = (ulong)-0x3f87968fUL;
        private static readonly ulong sysSIOCGLIFDSTADDR = (ulong)-0x3f87968dUL;
        private static readonly ulong sysSIOCGLIFFLAGS = (ulong)-0x3f87968bUL;
        private static readonly ulong sysSIOCGLIFMTU = (ulong)-0x3f879686UL;
        private static readonly ulong sysSIOCGLIFNETMASK = (ulong)-0x3f879683UL;
        private static readonly ulong sysSIOCGLIFMETRIC = (ulong)-0x3f879681UL;
        private static readonly ulong sysSIOCGLIFNUM = (ulong)-0x3ff3967eUL;
        private static readonly ulong sysSIOCGLIFINDEX = (ulong)-0x3f87967bUL;
        private static readonly ulong sysSIOCGLIFSUBNET = (ulong)-0x3f879676UL;
        private static readonly ulong sysSIOCGLIFLNKINFO = (ulong)-0x3f879674UL;
        private static readonly ulong sysSIOCGLIFCONF = (ulong)-0x3fef965bUL;
        private static readonly ulong sysSIOCGLIFHWADDR = (ulong)-0x3f879640UL;


        private static readonly ulong sysIFF_UP = (ulong)0x1UL;
        private static readonly ulong sysIFF_BROADCAST = (ulong)0x2UL;
        private static readonly ulong sysIFF_DEBUG = (ulong)0x4UL;
        private static readonly ulong sysIFF_LOOPBACK = (ulong)0x8UL;
        private static readonly ulong sysIFF_POINTOPOINT = (ulong)0x10UL;
        private static readonly ulong sysIFF_NOTRAILERS = (ulong)0x20UL;
        private static readonly ulong sysIFF_RUNNING = (ulong)0x40UL;
        private static readonly ulong sysIFF_NOARP = (ulong)0x80UL;
        private static readonly ulong sysIFF_PROMISC = (ulong)0x100UL;
        private static readonly ulong sysIFF_ALLMULTI = (ulong)0x200UL;
        private static readonly ulong sysIFF_INTELLIGENT = (ulong)0x400UL;
        private static readonly ulong sysIFF_MULTICAST = (ulong)0x800UL;
        private static readonly ulong sysIFF_MULTI_BCAST = (ulong)0x1000UL;
        private static readonly ulong sysIFF_UNNUMBERED = (ulong)0x2000UL;
        private static readonly ulong sysIFF_PRIVATE = (ulong)0x8000UL;


        private static readonly ulong sizeofLifnum = (ulong)0xcUL;
        private static readonly ulong sizeofLifreq = (ulong)0x178UL;
        private static readonly ulong sizeofLifconf = (ulong)0x18UL;
        private static readonly ulong sizeofLifIfinfoReq = (ulong)0x10UL;


        private partial struct lifnum
        {
            public ushort Family;
            public array<byte> Pad_cgo_0;
            public int Flags;
            public int Count;
        }

        private partial struct lifreq
        {
            public array<sbyte> Name;
            public array<byte> Lifru1;
            public uint Type;
            public array<byte> Lifru;
        }

        private partial struct lifconf
        {
            public ushort Family;
            public array<byte> Pad_cgo_0;
            public int Flags;
            public int Len;
            public array<byte> Pad_cgo_1;
            public array<byte> Lifcu;
        }

        private partial struct lifIfinfoReq
        {
            public byte Maxhops;
            public array<byte> Pad_cgo_0;
            public uint Reachtime;
            public uint Reachretrans;
            public uint Maxmtu;
        }

        private static readonly ulong sysIFT_IPV4 = (ulong)0xc8UL;
        private static readonly ulong sysIFT_IPV6 = (ulong)0xc9UL;
        private static readonly ulong sysIFT_6TO4 = (ulong)0xcaUL;

    }
}}}}
