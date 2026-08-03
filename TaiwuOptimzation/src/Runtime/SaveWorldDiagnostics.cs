using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using GameData.ArchiveData;
using GameData.Common;
using HarmonyLib;
using NLog;

namespace TaiwuOptimization.Runtime;

internal static class SaveWorldDiagnostics
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private static readonly FieldInfo? ArchivePathField = AccessTools.Field(typeof(ArchiveFileBase), "Path");
    private static readonly List<DomainMetric> DomainMetrics = new(24);

    // 当前 LocalArchiveFile.Save 的聚合状态；原版保存世界在主线程串行执行。
    private static Session _current;

    /// <summary>开始记录一次本地世界存档写入。</summary>
    /// <param name="archive">原版 ArchiveFileBase 实例。</param>
    /// <returns>诊断开启且目标是 LocalArchiveFile 时返回起始 ticks，否则返回 0。</returns>
    public static long BeginArchiveSave(
        ArchiveFileBase archive,
        CompressionAlgorithm compressionAlgorithm,
        CompressionType compressionType)
    {
        if (!TaiwuOptimizationSettings.DiagnosticsCollectionEnabled ||
            archive is not LocalArchiveFile)
        {
            return 0;
        }

        DomainMetrics.Clear();
        _current = default;
        _current.StartTicks = Stopwatch.GetTimestamp();
        _current.ArchivePath = ArchivePathField?.GetValue(archive) as string ?? string.Empty;
        _current.CompressionAlgorithm = compressionAlgorithm.ToString();
        _current.CompressionType = compressionType.ToString();
        _current.CompressionMode = "Original";
        return _current.StartTicks;
    }

    public static void MarkParallelDeflateStarted(int workerCount, int blockSize)
    {
        if (_current.StartTicks == 0)
        {
            return;
        }

        _current.CompressionMode = "ParallelDeflate";
        _current.ParallelWorkerCount = workerCount;
        _current.ParallelBlockSize = blockSize;
    }

    public static void RecordParallelDeflate(
        bool success,
        int workerCount,
        int blockSize,
        int blockCount,
        int peakPendingBlocks,
        long inputBytes,
        long outputBytes,
        long workerCompressionTicks,
        long workerWaitTicks,
        long destinationWriteTicks)
    {
        if (_current.StartTicks == 0)
        {
            return;
        }

        _current.CompressionMode = "ParallelDeflate";
        _current.ParallelCompressionSucceeded = success;
        _current.ParallelWorkerCount = workerCount;
        _current.ParallelBlockSize = blockSize;
        _current.ParallelBlockCount = blockCount;
        _current.ParallelPeakPendingBlocks = peakPendingBlocks;
        _current.ParallelInputBytes = inputBytes;
        _current.ParallelOutputBytes = outputBytes;
        _current.ParallelWorkerCompressionTicks = workerCompressionTicks;
        _current.ParallelWorkerWaitTicks = workerWaitTicks;
        _current.ParallelDestinationWriteTicks = destinationWriteTicks;
    }

    /// <summary>结束一次本地世界存档写入，并输出聚合日志。</summary>
    /// <param name="archive">原版 ArchiveFileBase 实例。</param>
    /// <param name="startTicks">BeginArchiveSave 返回的起始 ticks。</param>
    /// <param name="exception">原版保存过程中抛出的异常；没有异常时为 null。</param>
    public static void EndArchiveSave(ArchiveFileBase archive, long startTicks, Exception? exception)
    {
        if (startTicks == 0)
        {
            return;
        }

        long totalTicks = Stopwatch.GetTimestamp() - startTicks;
        _current.FinalFileSizeBytes = TryGetFileSize(_current.ArchivePath);
        _current.ExceptionText = exception == null ? string.Empty : exception.GetType().FullName ?? exception.GetType().Name;

        string legacyText = BuildMessage(totalTicks, in _current);
        TaiwuDiagnosticsSnapshotRequest? snapshot = null;
        if (TaiwuOptimizationSettings.DiagnosticsSaveSnapshotOnSave && exception == null)
        {
            snapshot = TaiwuDiagnosticsSnapshotStore.QueueArchiveCopy(
                _current.ArchivePath,
                "TaiwuOptimization.SaveWorld",
                BuildSnapshotMetadata(totalTicks, in _current),
                TaiwuOptimizationSettings.DiagnosticsSnapshotMaxCount);
        }

        TaiwuDiagnosticsExporter.Publish(
            "save_world",
            BuildPayload(totalTicks, in _current, snapshot, legacyText));

        if (TaiwuOptimizationSettings.DiagnosticsLogToGameLog && Logger.IsInfoEnabled)
        {
            Logger.Info(legacyText);
        }

        DomainMetrics.Clear();
        _current = default;
    }

    /// <summary>开始记录存档内部的一个子阶段。</summary>
    /// <returns>处于本地存档诊断作用域时返回起始 ticks，否则返回 0。</returns>
    public static long BeginStep() =>
        _current.StartTicks != 0 ? Stopwatch.GetTimestamp() : 0;

    /// <summary>记录 LocalArchiveFile.WriteHeader 耗时。</summary>
    public static void EndWriteHeader(long startTicks) =>
        AddTicks(ref _current.WriteHeaderTicks, startTicks);

    /// <summary>记录 LocalArchiveFile.WriteContent 总耗时。</summary>
    public static void EndWriteContent(long startTicks) =>
        AddTicks(ref _current.WriteContentTicks, startTicks);

    /// <summary>记录 working.db 复制进存档流的耗时和字节数。</summary>
    /// <param name="startTicks">BeginStep 返回的起始 ticks。</param>
    /// <param name="length">原版 CopyFrom 传入的复制字节数。</param>
    public static void EndCopyFrom(long startTicks, long length)
    {
        if (startTicks == 0)
        {
            return;
        }

        _current.CopyWorkingDbTicks += Stopwatch.GetTimestamp() - startTicks;
        _current.CopyWorkingDbBytes += Math.Max(length, 0);
        _current.CopyWorkingDbCalls++;
    }

    /// <summary>记录 DatabaseBridge.Disconnect 耗时。</summary>
    public static void EndDatabaseDisconnect(long startTicks) =>
        AddTicks(ref _current.DatabaseDisconnectTicks, startTicks);

    /// <summary>记录 DatabaseBridge.Connect 耗时。</summary>
    public static void EndDatabaseConnect(long startTicks) =>
        AddTicks(ref _current.DatabaseConnectTicks, startTicks);

    /// <summary>记录压缩流结束和最终 flush 耗时。</summary>
    public static void EndCompression(long startTicks) =>
        AddTicks(ref _current.EndCompressionTicks, startTicks);

    /// <summary>记录最终 CRC 写入耗时。</summary>
    public static void EndWriteCrc(long startTicks) =>
        AddTicks(ref _current.WriteCrcTicks, startTicks);

    /// <summary>开始记录单个 Domain.OnSaveWorld。</summary>
    /// <param name="domain">正在写入的原版 domain。</param>
    /// <param name="archive">原版传入的 archive。</param>
    /// <returns>处于本地存档写入时返回起始 ticks，否则返回 0。</returns>
    public static long BeginDomainSave(BaseGameDataDomain domain, ArchiveFileBase archive) =>
        _current.StartTicks != 0 && archive is LocalArchiveFile ? Stopwatch.GetTimestamp() : 0;

    /// <summary>结束单个 Domain.OnSaveWorld，并按 domain 类型聚合耗时。</summary>
    /// <param name="domain">正在写入的原版 domain。</param>
    /// <param name="startTicks">BeginDomainSave 返回的起始 ticks。</param>
    public static void EndDomainSave(BaseGameDataDomain domain, long startTicks)
    {
        if (startTicks == 0)
        {
            return;
        }

        AddDomainMetric(domain.GetType().Name, Stopwatch.GetTimestamp() - startTicks);
    }

    private static void AddTicks(ref long target, long startTicks)
    {
        if (startTicks != 0)
        {
            target += Stopwatch.GetTimestamp() - startTicks;
        }
    }

    private static void AddDomainMetric(string name, long ticks)
    {
        for (int i = 0; i < DomainMetrics.Count; i++)
        {
            DomainMetric metric = DomainMetrics[i];
            if (metric.Name != name)
            {
                continue;
            }

            metric.Calls++;
            metric.Ticks += ticks;
            DomainMetrics[i] = metric;
            return;
        }

        DomainMetrics.Add(new DomainMetric(name, ticks));
    }

    private static long TryGetFileSize(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return -1;
        }

        try
        {
            return File.Exists(path) ? new FileInfo(path).Length : -1;
        }
        catch
        {
            return -1;
        }
    }

    private static string BuildMessage(long totalTicks, in Session session)
    {
        long domainTicks = 0;
        foreach (DomainMetric metric in DomainMetrics)
        {
            domainTicks += metric.Ticks;
        }

        long measuredContentTicks =
            domainTicks +
            session.DatabaseDisconnectTicks +
            session.CopyWorkingDbTicks +
            session.DatabaseConnectTicks +
            session.EndCompressionTicks +
            session.WriteCrcTicks;
        long contentResidualTicks = session.WriteContentTicks > measuredContentTicks
            ? session.WriteContentTicks - measuredContentTicks
            : 0;
        long saveMeasuredTicks = session.WriteHeaderTicks + session.WriteContentTicks;
        long saveResidualTicks = totalTicks > saveMeasuredTicks ? totalTicks - saveMeasuredTicks : 0;

        StringBuilder builder = new(1600);
        builder.AppendLine("TaiwuOptimization: SaveWorld breakdown");
        builder.AppendLine("  total:");
        AppendMetric(builder, "elapsed", FormatMilliseconds(totalTicks));
        AppendMetric(builder, "measured", FormatMilliseconds(saveMeasuredTicks));
        AppendMetric(builder, "other", FormatMilliseconds(saveResidualTicks));
        AppendMetric(builder, "archivePath", string.IsNullOrEmpty(session.ArchivePath) ? "unknown" : session.ArchivePath);
        AppendMetric(builder, "fileSize", FormatBytes(session.FinalFileSizeBytes));
        if (!string.IsNullOrEmpty(session.ExceptionText))
        {
            AppendMetric(builder, "exception", session.ExceptionText);
        }

        builder.AppendLine("  archiveFile:");
        AppendMetric(builder, "WriteHeader", FormatMilliseconds(session.WriteHeaderTicks));
        AppendMetric(builder, "WriteContent", FormatMilliseconds(session.WriteContentTicks));
        AppendMetric(builder, "contentMeasured", FormatMilliseconds(measuredContentTicks));
        AppendMetric(builder, "contentOther", FormatMilliseconds(contentResidualTicks));

        builder.AppendLine("  domainOnSaveWorld:");
        foreach (DomainMetric metric in DomainMetrics)
        {
            AppendMetric(builder, metric.Name, FormatMilliseconds(metric.Ticks) + ", calls=" + metric.Calls);
        }

        builder.AppendLine("  database:");
        AppendMetric(builder, "DatabaseBridge.Disconnect", FormatMilliseconds(session.DatabaseDisconnectTicks));
        AppendMetric(builder, "CopyWorkingDb", FormatMilliseconds(session.CopyWorkingDbTicks) +
            ", calls=" + session.CopyWorkingDbCalls +
            ", bytes=" + FormatBytes(session.CopyWorkingDbBytes));
        AppendMetric(builder, "DatabaseBridge.Connect", FormatMilliseconds(session.DatabaseConnectTicks));

        builder.AppendLine("  compression:");
        AppendMetric(builder, "CompressionAlgorithm", string.IsNullOrEmpty(session.CompressionAlgorithm) ? "unknown" : session.CompressionAlgorithm);
        AppendMetric(builder, "CompressionType", string.IsNullOrEmpty(session.CompressionType) ? "unknown" : session.CompressionType);
        AppendMetric(builder, "CompressionMode", string.IsNullOrEmpty(session.CompressionMode) ? "unknown" : session.CompressionMode);
        if (session.CompressionMode == "ParallelDeflate")
        {
            AppendMetric(builder, "ParallelSucceeded", session.ParallelCompressionSucceeded.ToString());
            AppendMetric(builder, "ParallelWorkers", session.ParallelWorkerCount.ToString());
            AppendMetric(builder, "ParallelBlockBytes", session.ParallelBlockSize.ToString());
            AppendMetric(builder, "ParallelBlocks", session.ParallelBlockCount.ToString());
            AppendMetric(builder, "ParallelPeakPending", session.ParallelPeakPendingBlocks.ToString());
            AppendMetric(builder, "ParallelInputBytes", FormatBytes(session.ParallelInputBytes));
            AppendMetric(builder, "ParallelOutputBytes", FormatBytes(session.ParallelOutputBytes));
            AppendMetric(builder, "ParallelCompressionRatio", FormatRatio(session.ParallelOutputBytes, session.ParallelInputBytes));
            AppendMetric(builder, "ParallelWorkerCompressionAggregate", FormatMilliseconds(session.ParallelWorkerCompressionTicks));
            AppendMetric(builder, "ParallelWorkerWait", FormatMilliseconds(session.ParallelWorkerWaitTicks));
            AppendMetric(builder, "ParallelDestinationWrite", FormatMilliseconds(session.ParallelDestinationWriteTicks));
        }
        AppendMetric(builder, "EndCompression", FormatMilliseconds(session.EndCompressionTicks));
        AppendMetric(builder, "WriteCrcToEnd", FormatMilliseconds(session.WriteCrcTicks));
        return builder.ToString();
    }

    private static object BuildPayload(
        long totalTicks,
        in Session session,
        TaiwuDiagnosticsSnapshotRequest? snapshot,
        string legacyText)
    {
        long domainTicks = GetDomainTicks();
        long measuredContentTicks =
            domainTicks +
            session.DatabaseDisconnectTicks +
            session.CopyWorkingDbTicks +
            session.DatabaseConnectTicks +
            session.EndCompressionTicks +
            session.WriteCrcTicks;
        long contentResidualTicks = session.WriteContentTicks > measuredContentTicks
            ? session.WriteContentTicks - measuredContentTicks
            : 0;
        long saveMeasuredTicks = session.WriteHeaderTicks + session.WriteContentTicks;
        long saveResidualTicks = totalTicks > saveMeasuredTicks ? totalTicks - saveMeasuredTicks : 0;

        return new
        {
            elapsedMs = ToMilliseconds(totalTicks),
            total = new
            {
                elapsedMs = ToMilliseconds(totalTicks),
                measuredMs = ToMilliseconds(saveMeasuredTicks),
                otherMs = ToMilliseconds(saveResidualTicks),
                archivePath = string.IsNullOrEmpty(session.ArchivePath) ? null : session.ArchivePath,
                fileSizeBytes = session.FinalFileSizeBytes,
                exception = string.IsNullOrEmpty(session.ExceptionText) ? null : session.ExceptionText,
            },
            archiveFile = new
            {
                writeHeaderMs = ToMilliseconds(session.WriteHeaderTicks),
                writeContentMs = ToMilliseconds(session.WriteContentTicks),
                contentMeasuredMs = ToMilliseconds(measuredContentTicks),
                contentOtherMs = ToMilliseconds(contentResidualTicks),
            },
            domains = BuildDomainPayloads(),
            database = new
            {
                disconnectMs = ToMilliseconds(session.DatabaseDisconnectTicks),
                copyWorkingDbMs = ToMilliseconds(session.CopyWorkingDbTicks),
                copyWorkingDbCalls = session.CopyWorkingDbCalls,
                copyWorkingDbBytes = session.CopyWorkingDbBytes,
                connectMs = ToMilliseconds(session.DatabaseConnectTicks),
            },
            compression = new
            {
                compressionAlgorithm = string.IsNullOrEmpty(session.CompressionAlgorithm) ? null : session.CompressionAlgorithm,
                compressionType = string.IsNullOrEmpty(session.CompressionType) ? null : session.CompressionType,
                compressionMode = string.IsNullOrEmpty(session.CompressionMode) ? null : session.CompressionMode,
                parallelSucceeded = session.ParallelCompressionSucceeded,
                parallelWorkerCount = session.ParallelWorkerCount,
                parallelBlockSize = session.ParallelBlockSize,
                parallelBlockCount = session.ParallelBlockCount,
                parallelPeakPendingBlocks = session.ParallelPeakPendingBlocks,
                parallelInputBytes = session.ParallelInputBytes,
                parallelOutputBytes = session.ParallelOutputBytes,
                parallelCompressionRatio = GetRatio(session.ParallelOutputBytes, session.ParallelInputBytes),
                parallelWorkerCompressionAggregateMs = ToMilliseconds(session.ParallelWorkerCompressionTicks),
                parallelWorkerWaitMs = ToMilliseconds(session.ParallelWorkerWaitTicks),
                parallelDestinationWriteMs = ToMilliseconds(session.ParallelDestinationWriteTicks),
                endCompressionMs = ToMilliseconds(session.EndCompressionTicks),
                writeCrcMs = ToMilliseconds(session.WriteCrcTicks),
            },
            snapshot,
            legacyText,
        };
    }

    private static object BuildSnapshotMetadata(long totalTicks, in Session session) =>
        new
        {
            eventType = "save_world",
            elapsedMs = ToMilliseconds(totalTicks),
            archivePath = session.ArchivePath,
            fileSizeBytes = session.FinalFileSizeBytes,
            compressionAlgorithm = session.CompressionAlgorithm,
            compressionType = session.CompressionType,
            compressionMode = session.CompressionMode,
            domains = BuildDomainPayloads(),
        };

    private static List<object> BuildDomainPayloads()
    {
        List<object> result = new(DomainMetrics.Count);
        foreach (DomainMetric metric in DomainMetrics)
        {
            result.Add(new
            {
                name = metric.Name,
                calls = metric.Calls,
                elapsedMs = ToMilliseconds(metric.Ticks),
            });
        }

        return result;
    }

    private static long GetDomainTicks()
    {
        long domainTicks = 0;
        foreach (DomainMetric metric in DomainMetrics)
        {
            domainTicks += metric.Ticks;
        }

        return domainTicks;
    }

    private static string FormatMilliseconds(long ticks) =>
        (ticks * 1000.0 / Stopwatch.Frequency).ToString("N3") + "ms";

    private static double ToMilliseconds(long ticks) =>
        ticks * 1000.0 / Stopwatch.Frequency;

    private static string FormatBytes(long bytes) =>
        bytes < 0 ? "unknown" : bytes.ToString();

    private static string FormatRatio(long outputBytes, long inputBytes) =>
        inputBytes <= 0 ? "unknown" : GetRatio(outputBytes, inputBytes).ToString("N4");

    private static double GetRatio(long outputBytes, long inputBytes) =>
        inputBytes <= 0 ? 0 : (double)outputBytes / inputBytes;

    private static void AppendMetric(StringBuilder builder, string name, string value)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.Append(": ");
        builder.Append(value);
        builder.AppendLine();
    }

    private struct Session
    {
        public long StartTicks;
        public string ArchivePath;
        public string ExceptionText;
        public long FinalFileSizeBytes;
        public long WriteHeaderTicks;
        public long WriteContentTicks;
        public long DatabaseDisconnectTicks;
        public long CopyWorkingDbTicks;
        public long CopyWorkingDbBytes;
        public int CopyWorkingDbCalls;
        public long DatabaseConnectTicks;
        public long EndCompressionTicks;
        public long WriteCrcTicks;
        public string CompressionAlgorithm;
        public string CompressionType;
        public string CompressionMode;
        public bool ParallelCompressionSucceeded;
        public int ParallelWorkerCount;
        public int ParallelBlockSize;
        public int ParallelBlockCount;
        public int ParallelPeakPendingBlocks;
        public long ParallelInputBytes;
        public long ParallelOutputBytes;
        public long ParallelWorkerCompressionTicks;
        public long ParallelWorkerWaitTicks;
        public long ParallelDestinationWriteTicks;
    }

    private struct DomainMetric
    {
        public readonly string Name;
        public long Ticks;
        public int Calls;

        public DomainMetric(string name, long ticks)
        {
            Name = name;
            Ticks = ticks;
            Calls = 1;
        }
    }
}
