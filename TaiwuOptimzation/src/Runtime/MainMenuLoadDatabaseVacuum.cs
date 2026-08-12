using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using GameData.ArchiveData;
using HarmonyLib;
using NLog;
using SQLite;
using ArchiveCommon = GameData.ArchiveData.Common;

namespace TaiwuOptimization.Runtime;

/// <summary>
/// Compacts working.db exactly once after a world load requested through
/// GlobalDomain.LoadWorld. Other archive reads and every save are excluded.
/// </summary>
internal static class MainMenuLoadDatabaseVacuum
{
    private const long VacuumDiskSpaceMarginBytes = 64L * 1024L * 1024L;

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private static readonly object Sync = new();
    private static readonly FieldInfo? LiteConnectionField =
        AccessTools.Field(typeof(DatabaseBridge), "_liteConnection");

    private static PendingLoad _pendingLoad;
    private static long _nextRequestId;

    /// <summary>
    /// Arms the one archive read scheduled by GlobalDomain.LoadWorld.
    /// Returns a request id so a synchronous failure can cancel only its own request.
    /// </summary>
    public static long Arm(sbyte archiveId, long backupTimestamp)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled ||
            ArchiveCommon.IsInWorld() ||
            !ArchiveCommon.CheckArchiveId(archiveId))
        {
            return 0;
        }

        string archivePath = backupTimestamp < 0
            ? ArchiveCommon.GetArchiveDataPath(archiveId)
            : ArchiveCommon.GetArchiveDataPath(archiveId, backupTimestamp);
        string normalizedPath = NormalizePath(archivePath);
        if (normalizedPath.Length == 0)
        {
            return 0;
        }

        lock (Sync)
        {
            long requestId = ++_nextRequestId;
            if (requestId == 0)
            {
                requestId = ++_nextRequestId;
            }

            _pendingLoad = new PendingLoad(requestId, normalizedPath);
            return requestId;
        }
    }

    /// <summary>Clears an armed request if GlobalDomain.LoadWorld failed before scheduling it.</summary>
    public static void Cancel(long requestId)
    {
        if (requestId == 0)
        {
            return;
        }

        lock (Sync)
        {
            if (_pendingLoad.RequestId == requestId)
            {
                _pendingLoad = default;
            }
        }
    }

    /// <summary>
    /// Consumes a matching main-menu load request. A failed archive read consumes the
    /// request without compacting, so it cannot leak into a later unrelated read.
    /// </summary>
    public static void CompleteArchiveLoad(
        ArchiveFileBase archive,
        string archivePath,
        Exception? loadException)
    {
        if (archive is not LocalArchiveFile || !TryConsume(archivePath))
        {
            return;
        }

        if (loadException != null || !TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled)
        {
            return;
        }

        VacuumWorkingDatabase();
    }

    public static void Reset()
    {
        lock (Sync)
        {
            _pendingLoad = default;
        }
    }

    private static bool TryConsume(string archivePath)
    {
        string normalizedPath = NormalizePath(archivePath);
        if (normalizedPath.Length == 0)
        {
            return false;
        }

        lock (Sync)
        {
            if (_pendingLoad.RequestId == 0 ||
                !string.Equals(
                    _pendingLoad.ArchivePath,
                    normalizedPath,
                    StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            _pendingLoad = default;
            return true;
        }
    }

    private static void VacuumWorkingDatabase()
    {
        try
        {
            if (LiteConnectionField?.GetValue(null) is not SQLiteConnection connection)
            {
                Logger.Warn("TaiwuOptimization: main-menu world load completed, but the SQLite connection was unavailable; skipped VACUUM.");
                return;
            }

            if (connection.IsInTransaction)
            {
                Logger.Warn("TaiwuOptimization: main-menu world load left SQLite in a transaction; skipped VACUUM.");
                return;
            }

            string databasePath = connection.DatabasePath;
            if (!File.Exists(databasePath))
            {
                Logger.Warn("TaiwuOptimization: main-menu world load completed, but working.db was unavailable; skipped VACUUM.");
                return;
            }

            long lengthBefore = new FileInfo(databasePath).Length;
            if (!HasEnoughDiskSpace(databasePath, lengthBefore))
            {
                Logger.Warn("TaiwuOptimization: insufficient free disk space for the main-menu-load VACUUM; skipped compaction.");
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            connection.Execute("VACUUM", Array.Empty<object>());
            stopwatch.Stop();

            long lengthAfter = new FileInfo(databasePath).Length;
            Logger.Info(
                "TaiwuOptimization: main-menu-load SQLite VACUUM completed in {0:F2}s; working.db {1:F2} MiB -> {2:F2} MiB, reclaimed {3:F2} MiB.",
                stopwatch.Elapsed.TotalSeconds,
                BytesToMiB(lengthBefore),
                BytesToMiB(lengthAfter),
                BytesToMiB(Math.Max(0L, lengthBefore - lengthAfter)));
        }
        catch (Exception exception)
        {
            // A maintenance failure must never turn a successful world load into a failure.
            Logger.Warn(exception, "TaiwuOptimization: main-menu-load SQLite VACUUM failed; continuing with the loaded world.");
        }
    }

    private static bool HasEnoughDiskSpace(string databasePath, long databaseLength)
    {
        string? root = Path.GetPathRoot(Path.GetFullPath(databasePath));
        if (string.IsNullOrEmpty(root))
        {
            return false;
        }

        long requiredBytes;
        try
        {
            requiredBytes = checked(databaseLength * 2L + VacuumDiskSpaceMarginBytes);
        }
        catch (OverflowException)
        {
            return false;
        }

        return new DriveInfo(root).AvailableFreeSpace >= requiredBytes;
    }

    private static string NormalizePath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return string.Empty;
        }

        try
        {
            return Path.GetFullPath(path);
        }
        catch
        {
            return string.Empty;
        }
    }

    private static double BytesToMiB(long bytes) => bytes / (1024.0 * 1024.0);

    private readonly record struct PendingLoad(long RequestId, string ArchivePath);
}
