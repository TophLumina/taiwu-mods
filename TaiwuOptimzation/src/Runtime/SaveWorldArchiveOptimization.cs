using GameData.ArchiveData;

namespace TaiwuOptimization.Runtime;

internal static class SaveWorldArchiveOptimization
{
    public const long OriginalCopyBufferBytes = 4096L;

    private const int DefaultCopyBufferTier = 2;
    private const int BytesPerMb = 1024 * 1024;

    /// <summary>将配置值限制到 1/2/3/4 档。</summary>
    /// <param name="tier">用户配置的档位。</param>
    /// <returns>合法档位；读取失败时使用默认 2 档。</returns>
    public static int NormalizeCopyBufferTier(int tier) =>
        tier is >= 1 and <= 4 ? tier : DefaultCopyBufferTier;

    /// <summary>ArchiveFileBase.CopyFrom/CopyTo 使用的复制块大小，单位为字节。</summary>
    public static long GetDatabaseCopyBufferBytes() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled
            ? (long)GetDatabaseCopyBufferMb() * BytesPerMb
            : OriginalCopyBufferBytes;

    /// <summary>按档位返回复制块大小，单位为 MB。</summary>
    public static int GetDatabaseCopyBufferMb() =>
        TaiwuOptimizationSettings.SaveWorldDatabaseCopyBufferTier switch
        {
            1 => 1,
            2 => 4,
            3 => 8,
            4 => 16,
            _ => 4,
        };

    /// <summary>根据设置决定本次本地存档使用的压缩模式。</summary>
    /// <param name="archive">原版 archive 实例。</param>
    /// <param name="original">原版传入的压缩模式。</param>
    /// <returns>优化后的压缩模式。</returns>
    public static CompressionType GetCompressionType(ArchiveFileBase archive, CompressionType original)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled ||
            !TaiwuOptimizationSettings.SaveWorldNoCompression ||
            archive is not LocalArchiveFile)
        {
            return original;
        }

        return CompressionType.NoCompression;
    }
}
