using System;
using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using GameData.Domains;

namespace TaiwuZstdSave;

internal static class NativeZlibNg
{
    private struct ZngStream
    {
        public nint NextIn;

        public uint AvailIn;

        public nuint TotalIn;

        public nint NextOut;

        public uint AvailOut;

        public nuint TotalOut;

        public nint Message;

        public nint State;

        public nint Allocate;

        public nint Free;

        public nint Opaque;

        public int DataType;

        public uint Adler;

        public uint Reserved;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int DeflateInit2Delegate(ref ZngStream stream, int level, int method, int windowBits, int memoryLevel, int strategy);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int DeflateDelegate(ref ZngStream stream, int flush);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int DeflateEndDelegate(ref ZngStream stream);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate nuint DeflateBoundDelegate(ref ZngStream stream, nuint sourceLength);

    private const int ZOk = 0;

    private const int ZStreamEnd = 1;

    private const int ZSyncFlush = 2;

    private const int ZFinish = 4;

    private const int ZDeflated = 8;

    private const int ZDefaultStrategy = 0;

    private static readonly object Sync = new object();

    private static DeflateInit2Delegate? _deflateInit2;

    private static DeflateDelegate? _deflate;

    private static DeflateEndDelegate? _deflateEnd;

    private static DeflateBoundDelegate? _deflateBound;

    private static nint _libraryHandle;

    public static bool IsAvailable { get; private set; }

    public static void Initialize(string modId)
    {
        lock (Sync)
        {
            if (_libraryHandle != IntPtr.Zero)
            {
                return;
            }
            try
            {
                string modDirectory = DomainManager.Mod.GetModDirectory(modId);
                if (string.IsNullOrEmpty(modDirectory))
                {
                    throw new DirectoryNotFoundException("无法获取 Mod 目录。");
                }
                InitializeLibrary(Path.Combine(modDirectory, "Plugins", "zlib-ng2.dll"));
            }
            catch (Exception value)
            {
                IsAvailable = false;
                ModLog.Warning($"zlib-ng 初始化失败，快速模式将回退到原版 DEFLATE：{value}");
            }
        }
    }

    private static void InitializeLibrary(string libraryPath)
    {
        _libraryHandle = NativeLibrary.Load(libraryPath);
        _deflateInit2 = LoadExport<DeflateInit2Delegate>("zng_deflateInit2");
        _deflate = LoadExport<DeflateDelegate>("zng_deflate");
        _deflateEnd = LoadExport<DeflateEndDelegate>("zng_deflateEnd");
        _deflateBound = LoadExport<DeflateBoundDelegate>("zng_deflateBound");
        ParallelDeflateStream.SelfTest();
        IsAvailable = true;
        ModLog.Info("已加载并验证 zlib-ng 2.3.3。快速模式可用。");
    }

    public static CompressedBlock Compress(byte[] input, int inputLength, bool final, int level = 2)
    {
        if (!IsAvailable && _libraryHandle == IntPtr.Zero)
        {
            throw new InvalidOperationException("zlib-ng 尚未初始化。");
        }
        ZngStream stream = default(ZngStream);
        int actual = _deflateInit2(ref stream, level, 8, -15, 8, 0);
        Check(actual, 0, stream, "zng_deflateInit2");
        byte[] array = null;
        GCHandle gCHandle = default(GCHandle);
        GCHandle gCHandle2 = default(GCHandle);
        try
        {
            nuint num = _deflateBound(ref stream, (nuint)inputLength) + 64;
            if (num > int.MaxValue)
            {
                throw new InvalidDataException("zlib-ng 输出缓冲区过大。");
            }
            array = ArrayPool<byte>.Shared.Rent((int)num);
            if (inputLength > 0)
            {
                gCHandle = GCHandle.Alloc(input, GCHandleType.Pinned);
                stream.NextIn = gCHandle.AddrOfPinnedObject();
            }
            gCHandle2 = GCHandle.Alloc(array, GCHandleType.Pinned);
            stream.AvailIn = (uint)inputLength;
            stream.NextOut = gCHandle2.AddrOfPinnedObject();
            stream.AvailOut = (uint)array.Length;
            int flush = (final ? 4 : 2);
            do
            {
                actual = _deflate(ref stream, flush);
                if (stream.AvailOut == 0)
                {
                    throw new InvalidDataException("zlib-ng 输出超出预估上限。");
                }
                if (actual < 0)
                {
                    Check(actual, 0, stream, "zng_deflate");
                }
            }
            while (final ? (actual != 1) : ((byte)stream.AvailIn != 0));
            if (!final && actual != 0)
            {
                Check(actual, 0, stream, "zng_deflate(Z_SYNC_FLUSH)");
            }
            if (stream.AvailIn != 0)
            {
                throw new InvalidDataException("zlib-ng 未消费完整输入块。");
            }
            int num2 = array.Length - checked((int)stream.AvailOut);
            if (!final && (num2 < 4 || array[num2 - 4] != 0 || array[num2 - 3] != 0 || array[num2 - 2] != byte.MaxValue || array[num2 - 1] != byte.MaxValue))
            {
                throw new InvalidDataException("zlib-ng 未生成标准 Z_SYNC_FLUSH 边界。");
            }
            byte[] buffer = array;
            array = null;
            return new CompressedBlock(buffer, num2);
        }
        finally
        {
            if (gCHandle2.IsAllocated)
            {
                gCHandle2.Free();
            }
            if (gCHandle.IsAllocated)
            {
                gCHandle.Free();
            }
            _deflateEnd(ref stream);
            if (array != null)
            {
                ArrayPool<byte>.Shared.Return(array);
            }
        }
    }

    private static T LoadExport<T>(string name) where T : Delegate
    {
        return Marshal.GetDelegateForFunctionPointer<T>(NativeLibrary.GetExport(_libraryHandle, name));
    }

    private static void Check(int actual, int expected, ZngStream stream, string operation)
    {
        if (actual == expected)
        {
            return;
        }
        string value = ((stream.Message == IntPtr.Zero) ? null : Marshal.PtrToStringUTF8(stream.Message));
        throw new InvalidDataException($"{operation} 失败：{actual} {value}");
    }
}
