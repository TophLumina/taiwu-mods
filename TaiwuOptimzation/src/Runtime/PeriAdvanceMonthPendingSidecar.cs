using System;
using System.Collections.Generic;
using System.IO;
using GameData.Domains;
using GameData.Domains.Map;
using NLog;

namespace TaiwuOptimization.Runtime;

internal static class PeriAdvanceMonthPendingSidecar
{
    private const string Magic = "TWOPT_PENDING";
    private const int SchemaVersion = 1;
    private const int MaxJobCount = 100_000;
    private const int MaxCharacterIdsPerJob = 512;
    private const int MaxLocationsPerJob = 4096;

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    // 同一世界会话只从 sidecar 恢复一次，避免普通保存后再次读回并复制 pending。
    private static sbyte? _loadedArchiveId;

    public static void ResetLoadState()
    {
        _loadedArchiveId = null;
    }

    /// <summary>读档后首次世界可用时，尝试从 sidecar 恢复 pending。</summary>
    /// <param name="jobs">恢复出的 pending job 列表。</param>
    /// <returns>返回 true 表示本次读取到了有效 sidecar。</returns>
    public static bool TryLoadOnce(out List<PeriAdvanceMonthDeferredJob> jobs)
    {
        jobs = new List<PeriAdvanceMonthDeferredJob>();
        if (!TryGetSidecarPaths(out sbyte archiveId, out long savingTimestamp, out string primaryPath, out string backupPath) ||
            _loadedArchiveId == archiveId)
        {
            return false;
        }

        _loadedArchiveId = archiveId;
        if (TryRead(primaryPath, archiveId, savingTimestamp, out jobs))
        {
            return true;
        }

        if (TryRead(backupPath, archiveId, savingTimestamp, out jobs))
        {
            Logger.Info("TaiwuOptimization: restored pending jobs from sidecar backup.");
            return true;
        }

        jobs.Clear();
        return false;
    }

    /// <summary>普通保存时写出当前 pending；为空时写出空 sidecar 作为删除标记。</summary>
    /// <param name="jobs">当前内存中的 pending 快照。</param>
    /// <returns>写出成功返回 true；失败时调用方应回退同步 flush。</returns>
    public static bool TrySave(IReadOnlyList<PeriAdvanceMonthDeferredJob> jobs)
    {
        if (!TryGetSidecarPaths(out sbyte archiveId, out long savingTimestamp, out string primaryPath, out string backupPath))
        {
            return true;
        }

        if (jobs.Count == 0 && !File.Exists(primaryPath) && !File.Exists(backupPath))
        {
            return true;
        }

        string? directory = Path.GetDirectoryName(primaryPath);
        if (directory == null)
        {
            return false;
        }

        try
        {
            Directory.CreateDirectory(directory);
            string tempPath = primaryPath + ".tmp";
            WriteFile(tempPath, archiveId, savingTimestamp, jobs);
            if (File.Exists(primaryPath))
            {
                File.Copy(primaryPath, backupPath, overwrite: true);
            }

            File.Move(tempPath, primaryPath, overwrite: true);
            return true;
        }
        catch (Exception ex)
        {
            Logger.Warn(ex, "TaiwuOptimization: failed to save pending sidecar.");
            return false;
        }
    }

    private static bool TryGetSidecarPaths(
        out sbyte archiveId,
        out long savingTimestamp,
        out string primaryPath,
        out string backupPath)
    {
        archiveId = -1;
        savingTimestamp = 0;
        primaryPath = string.Empty;
        backupPath = string.Empty;
        if (!GameData.ArchiveData.Common.IsInWorld() || !DomainManager.Global.IsInNormalWorld())
        {
            return false;
        }

        archiveId = GameData.ArchiveData.Common.GetCurrArchiveId();
        savingTimestamp = DomainManager.World.GetWorldVersionInfo()?.TimestampLastSaving ?? 0;
        string archiveDirectory = GameData.ArchiveData.Common.GetArchiveDataDirectory(archiveId);
        string sidecarDirectory = Path.Combine(archiveDirectory, "TaiwuOptimization");
        primaryPath = Path.Combine(sidecarDirectory, "peri_advance_month_pending.v1.bin");
        backupPath = primaryPath + ".bak";
        return true;
    }

    private static void WriteFile(
        string path,
        sbyte archiveId,
        long savingTimestamp,
        IReadOnlyList<PeriAdvanceMonthDeferredJob> jobs)
    {
        using FileStream stream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None);
        using BinaryWriter writer = new(stream);
        writer.Write(Magic);
        writer.Write(SchemaVersion);
        writer.Write((int)archiveId);
        writer.Write(DomainManager.World.GetCurrDate());
        writer.Write(savingTimestamp);
        writer.Write(jobs.Count);
        foreach (PeriAdvanceMonthDeferredJob job in jobs)
        {
            WriteJob(writer, job);
        }
    }

    private static void WriteJob(BinaryWriter writer, PeriAdvanceMonthDeferredJob job)
    {
        writer.Write((byte)job.Kind);
        writer.Write(job.AreaId);
        switch (job.Kind)
        {
            case PeriAdvanceMonthDeferredJobKind.CharacterParallelActionChunk:
                writer.Write((byte)job.CharacterParallelActionKind);
                WriteIntList(writer, job.CharacterIds);
                break;
            case PeriAdvanceMonthDeferredJobKind.MapBrokenBlockUpdate:
            case PeriAdvanceMonthDeferredJobKind.SkeletonGeneration:
                writer.Write(job.BlockStart);
                writer.Write(job.BlockCount);
                break;
            case PeriAdvanceMonthDeferredJobKind.AnimalAreaData:
                break;
            case PeriAdvanceMonthDeferredJobKind.MapPickupCleanup:
                WriteLocations(writer, job.MapPickupLocations);
                break;
        }
    }

    private static void WriteIntList(BinaryWriter writer, IReadOnlyList<int>? values)
    {
        int count = values?.Count ?? 0;
        writer.Write(count);
        for (int i = 0; i < count; i++)
        {
            writer.Write(values![i]);
        }
    }

    private static void WriteLocations(BinaryWriter writer, IReadOnlyList<Location>? locations)
    {
        int count = locations?.Count ?? 0;
        writer.Write(count);
        for (int i = 0; i < count; i++)
        {
            Location location = locations![i];
            writer.Write(location.AreaId);
            writer.Write(location.BlockId);
        }
    }

    private static bool TryRead(
        string path,
        sbyte expectedArchiveId,
        long expectedSavingTimestamp,
        out List<PeriAdvanceMonthDeferredJob> jobs)
    {
        jobs = new List<PeriAdvanceMonthDeferredJob>();
        if (!File.Exists(path))
        {
            return false;
        }

        try
        {
            using FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using BinaryReader reader = new(stream);
            if (reader.ReadString() != Magic)
            {
                return false;
            }

            int schemaVersion = reader.ReadInt32();
            if (schemaVersion != SchemaVersion)
            {
                return TryReadDifferentSchemaSidecar(
                    schemaVersion,
                    reader,
                    expectedArchiveId,
                    expectedSavingTimestamp,
                    out jobs);
            }

            sbyte archiveId = (sbyte)reader.ReadInt32();
            _ = reader.ReadInt32();
            long savingTimestamp = reader.ReadInt64();
            if (archiveId != expectedArchiveId || savingTimestamp != expectedSavingTimestamp)
            {
                return false;
            }

            int count = ReadBoundedCount(reader, MaxJobCount);
            for (int i = 0; i < count; i++)
            {
                jobs.Add(ReadJob(reader));
            }

            Logger.Info($"TaiwuOptimization: restored {jobs.Count} pending jobs from sidecar.");
            return true;
        }
        catch (Exception ex)
        {
            Logger.Warn(ex, "TaiwuOptimization: failed to read pending sidecar.");
            jobs.Clear();
            return false;
        }
    }

    private static bool TryReadDifferentSchemaSidecar(
        int schemaVersion,
        BinaryReader reader,
        sbyte expectedArchiveId,
        long expectedSavingTimestamp,
        out List<PeriAdvanceMonthDeferredJob> jobs)
    {
        jobs = new List<PeriAdvanceMonthDeferredJob>();
        // 兼容入口：当前没有旧版格式需要迁移，先把不同 schema 当作没有 pending。
        _ = reader;
        _ = expectedArchiveId;
        _ = expectedSavingTimestamp;
        Logger.Info($"TaiwuOptimization: ignored pending sidecar schema {schemaVersion}.");
        return false;
    }

    private static PeriAdvanceMonthDeferredJob ReadJob(BinaryReader reader)
    {
        PeriAdvanceMonthDeferredJobKind kind = (PeriAdvanceMonthDeferredJobKind)reader.ReadByte();
        int areaId = reader.ReadInt32();
        return kind switch
        {
            PeriAdvanceMonthDeferredJobKind.CharacterParallelActionChunk =>
                PeriAdvanceMonthDeferredJob.CharacterParallelActionChunk(
                    areaId,
                    (PeriAdvanceMonthCharacterParallelActionKind)reader.ReadByte(),
                    ReadIntArray(reader, MaxCharacterIdsPerJob)),
            PeriAdvanceMonthDeferredJobKind.MapBrokenBlockUpdate =>
                PeriAdvanceMonthDeferredJob.MapBrokenBlockUpdate(areaId, reader.ReadInt32(), reader.ReadInt32()),
            PeriAdvanceMonthDeferredJobKind.AnimalAreaData =>
                PeriAdvanceMonthDeferredJob.AnimalAreaData(areaId),
            PeriAdvanceMonthDeferredJobKind.SkeletonGeneration =>
                PeriAdvanceMonthDeferredJob.SkeletonGeneration(areaId, reader.ReadInt32(), reader.ReadInt32()),
            PeriAdvanceMonthDeferredJobKind.MapPickupCleanup =>
                PeriAdvanceMonthDeferredJob.MapPickupCleanup(areaId, ReadLocations(reader, MaxLocationsPerJob)),
            _ => throw new InvalidDataException($"Unsupported pending job kind: {kind}."),
        };
    }

    private static int[] ReadIntArray(BinaryReader reader, int maxCount)
    {
        int count = ReadBoundedCount(reader, maxCount);
        int[] values = new int[count];
        for (int i = 0; i < count; i++)
        {
            values[i] = reader.ReadInt32();
        }

        return values;
    }

    private static Location[] ReadLocations(BinaryReader reader, int maxCount)
    {
        int count = ReadBoundedCount(reader, maxCount);
        Location[] locations = new Location[count];
        for (int i = 0; i < count; i++)
        {
            locations[i] = new Location(reader.ReadInt16(), reader.ReadInt16());
        }

        return locations;
    }

    private static int ReadBoundedCount(BinaryReader reader, int maxCount)
    {
        int count = reader.ReadInt32();
        if (count < 0 || count > maxCount)
        {
            throw new InvalidDataException($"Invalid pending sidecar count: {count}.");
        }

        return count;
    }
}
