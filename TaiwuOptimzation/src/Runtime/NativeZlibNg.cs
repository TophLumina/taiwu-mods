using System;
using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using GameData.Domains;
using NLog;

namespace TaiwuOptimization.Runtime;

internal static class NativeZlibNg
{
    [StructLayout(LayoutKind.Sequential)]
    private struct ZngStream
    {
        public IntPtr NextIn;
        public uint AvailIn;
        public nuint TotalIn;
        public IntPtr NextOut;
        public uint AvailOut;
        public nuint TotalOut;
        public IntPtr Message;
        public IntPtr State;
        public IntPtr Allocate;
        public IntPtr Free;
        public IntPtr Opaque;
        public int DataType;
        public uint Adler;
        public uint Reserved;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int DeflateInit2Delegate(
        ref ZngStream stream,
        int level,
        int method,
        int windowBits,
        int memoryLevel,
        int strategy);

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
    private const int CompressionLevel = 2;

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private static readonly object Sync = new();

    private static DeflateInit2Delegate? _deflateInit2;
    private static DeflateDelegate? _deflate;
    private static DeflateEndDelegate? _deflateEnd;
    private static DeflateBoundDelegate? _deflateBound;
    private static IntPtr _libraryHandle;
    private static bool _initializationAttempted;

    public static bool IsAvailable { get; private set; }

    public static void Initialize(string modId)
    {
        lock (Sync)
        {
            if (_initializationAttempted)
            {
                return;
            }

            _initializationAttempted = true;
            try
            {
                string modDirectory = DomainManager.Mod.GetModDirectory(modId);
                if (string.IsNullOrEmpty(modDirectory))
                {
                    throw new DirectoryNotFoundException("Unable to resolve the mod directory.");
                }

                string libraryPath = Path.Combine(modDirectory, "Plugins", "zlib-ng2.dll");
                InitializeLibrary(libraryPath);
                IsAvailable = true;
                Logger.Info(
                    "TaiwuOptimization: zlib-ng parallel DEFLATE initialized; physicalCoreWorkers={0}",
                    PhysicalProcessorTopology.PhysicalCoreCount);
            }
            catch (Exception exception)
            {
                IsAvailable = false;
                Logger.Warn(exception, "TaiwuOptimization: zlib-ng initialization failed; using the original DEFLATE stream.");
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
    }

    public static CompressedBlock Compress(byte[] input, int inputLength, bool final)
    {
        if (_libraryHandle == IntPtr.Zero ||
            _deflateInit2 == null ||
            _deflate == null ||
            _deflateEnd == null ||
            _deflateBound == null)
        {
            throw new InvalidOperationException("zlib-ng is not initialized.");
        }

        ZngStream stream = default;
        int status = _deflateInit2(
            ref stream,
            CompressionLevel,
            ZDeflated,
            -15,
            8,
            ZDefaultStrategy);
        Check(status, ZOk, stream, "zng_deflateInit2");

        byte[]? output = null;
        GCHandle inputHandle = default;
        GCHandle outputHandle = default;
        try
        {
            nuint outputBound = _deflateBound(ref stream, (nuint)inputLength) + 64;
            if (outputBound > int.MaxValue)
            {
                throw new InvalidDataException("zlib-ng output buffer is too large.");
            }

            output = ArrayPool<byte>.Shared.Rent((int)outputBound);
            if (inputLength > 0)
            {
                inputHandle = GCHandle.Alloc(input, GCHandleType.Pinned);
                stream.NextIn = inputHandle.AddrOfPinnedObject();
            }

            outputHandle = GCHandle.Alloc(output, GCHandleType.Pinned);
            stream.AvailIn = checked((uint)inputLength);
            stream.NextOut = outputHandle.AddrOfPinnedObject();
            stream.AvailOut = checked((uint)output.Length);

            int flush = final ? ZFinish : ZSyncFlush;
            do
            {
                status = _deflate(ref stream, flush);
                if (stream.AvailOut == 0)
                {
                    throw new InvalidDataException("zlib-ng exceeded the estimated output bound.");
                }

                if (status < 0)
                {
                    Check(status, ZOk, stream, "zng_deflate");
                }
            }
            while (final ? status != ZStreamEnd : stream.AvailIn != 0);

            if (!final && status != ZOk)
            {
                Check(status, ZOk, stream, "zng_deflate(Z_SYNC_FLUSH)");
            }

            if (stream.AvailIn != 0)
            {
                throw new InvalidDataException("zlib-ng did not consume the complete input block.");
            }

            int outputLength = output.Length - checked((int)stream.AvailOut);
            if (!final &&
                (outputLength < 4 ||
                 output[outputLength - 4] != 0 ||
                 output[outputLength - 3] != 0 ||
                 output[outputLength - 2] != byte.MaxValue ||
                 output[outputLength - 1] != byte.MaxValue))
            {
                throw new InvalidDataException("zlib-ng did not produce a valid Z_SYNC_FLUSH boundary.");
            }

            byte[] resultBuffer = output;
            output = null;
            return new CompressedBlock(resultBuffer, outputLength);
        }
        finally
        {
            if (outputHandle.IsAllocated)
            {
                outputHandle.Free();
            }

            if (inputHandle.IsAllocated)
            {
                inputHandle.Free();
            }

            _ = _deflateEnd(ref stream);
            if (output != null)
            {
                ArrayPool<byte>.Shared.Return(output);
            }
        }
    }

    private static T LoadExport<T>(string name) where T : Delegate =>
        Marshal.GetDelegateForFunctionPointer<T>(NativeLibrary.GetExport(_libraryHandle, name));

    private static void Check(int actual, int expected, in ZngStream stream, string operation)
    {
        if (actual == expected)
        {
            return;
        }

        string? message = stream.Message == IntPtr.Zero
            ? null
            : Marshal.PtrToStringUTF8(stream.Message);
        throw new InvalidDataException($"{operation} failed: {actual} {message}");
    }
}
