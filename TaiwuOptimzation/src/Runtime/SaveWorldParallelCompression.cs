using System;
using System.IO;
using GameData.ArchiveData;
using NLog;

namespace TaiwuOptimization.Runtime;

internal static class SaveWorldParallelCompression
{
    private const string LocalSaveName = "local.sav";

    public const long OriginalCopyBufferBytes = 4096L;

    private const int MinBlockSizeTier = 1;
    private const int MaxBlockSizeTier = 5;

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    [ThreadStatic]
    private static bool _useParallelDeflateForCurrentSave;

    public static void Initialize(string modId) => NativeZlibNg.Initialize(modId);

    public static bool BeginSave(
        ArchiveFileBase archive,
        string archivePath,
        ref CompressionAlgorithm algorithm)
    {
        _useParallelDeflateForCurrentSave = false;
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled ||
            !TaiwuOptimizationSettings.EnableSaveWorldParallelDeflate ||
            archive is not LocalArchiveFile ||
            !string.Equals(Path.GetFileName(archivePath), LocalSaveName, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        // Keep the archive header and reader on the vanilla-compatible Deflate algorithm.
        algorithm = CompressionAlgorithm.Deflate;
        _useParallelDeflateForCurrentSave = NativeZlibNg.IsAvailable;
        return _useParallelDeflateForCurrentSave;
    }

    public static void EndSave() => _useParallelDeflateForCurrentSave = false;

    public static ParallelDeflateStream? TryCreateStream(Stream destination, CompressionAlgorithm algorithm)
    {
        if (algorithm != CompressionAlgorithm.Deflate || !_useParallelDeflateForCurrentSave)
        {
            return null;
        }

        try
        {
            return new ParallelDeflateStream(
                destination,
                PhysicalProcessorTopology.PhysicalCoreCount,
                GetBlockSizeBytes());
        }
        catch (Exception exception)
        {
            _useParallelDeflateForCurrentSave = false;
            Logger.Warn(exception, "TaiwuOptimization: failed to create the parallel DEFLATE stream; using the original stream.");
            return null;
        }
    }

    public static int NormalizeBlockSizeTier(int tier) =>
        Math.Clamp(tier, MinBlockSizeTier, MaxBlockSizeTier);

    public static int GetBlockSizeBytes() =>
        NormalizeBlockSizeTier(TaiwuOptimizationSettings.SaveWorldBlockSizeTier) switch
        {
            1 => 1 * 1024 * 1024,
            2 => 2 * 1024 * 1024,
            3 => ParallelDeflateStream.DefaultBlockSize,
            4 => 8 * 1024 * 1024,
            5 => 16 * 1024 * 1024,
            _ => ParallelDeflateStream.DefaultBlockSize
        };

    public static long GetDatabaseCopyBufferBytes() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled
            ? GetBlockSizeBytes()
            : OriginalCopyBufferBytes;
}
