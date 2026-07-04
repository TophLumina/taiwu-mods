using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using GameData.ArchiveData;
using GameData.Common;
using HarmonyLib;

namespace TaiwuDiagnostics.Runtime;

internal static class SaveWorldDiagnostics
{
    private static readonly FieldInfo? ArchivePathField = AccessTools.Field(typeof(ArchiveFileBase), "Path");
    private static readonly List<DomainMetric> DomainMetrics = new(32);
    private static Session _current;

    public static long BeginArchiveSave(ArchiveFileBase archive, CompressionType compressionType)
    {
        if (!TaiwuDiagnosticsSettings.CaptureSaveWorldDiagnostics || archive is not LocalArchiveFile)
        {
            return 0;
        }

        DomainMetrics.Clear();
        _current = default;
        _current.StartTicks = Stopwatch.GetTimestamp();
        _current.ArchiveType = archive.GetType().FullName ?? archive.GetType().Name;
        _current.ArchivePath = ArchivePathField?.GetValue(archive) as string ?? string.Empty;
        _current.CompressionType = compressionType.ToString();
        return _current.StartTicks;
    }

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
        if (TaiwuDiagnosticsSettings.CopySaveArchiveSnapshot && exception == null)
        {
            snapshot = TaiwuDiagnosticsSnapshotStore.QueueArchiveCopy(
                _current.ArchivePath,
                "TaiwuDiagnostics.SaveWorld",
                BuildSnapshotMetadata(totalTicks, in _current),
                TaiwuDiagnosticsSettings.SaveArchiveSnapshotMaxCount);
        }

        TaiwuDiagnosticsExporter.Publish(
            "diagnostics.save_world",
            BuildPayload(totalTicks, in _current, snapshot, legacyText));

        DomainMetrics.Clear();
        _current = default;
    }

    public static long BeginStep() =>
        _current.StartTicks != 0 ? Stopwatch.GetTimestamp() : 0;

    public static void EndWriteHeader(long startTicks) =>
        AddTicks(ref _current.WriteHeaderTicks, startTicks);

    public static void EndWriteContent(long startTicks) =>
        AddTicks(ref _current.WriteContentTicks, startTicks);

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

    public static void EndDatabaseDisconnect(long startTicks) =>
        AddTicks(ref _current.DatabaseDisconnectTicks, startTicks);

    public static void EndDatabaseConnect(long startTicks) =>
        AddTicks(ref _current.DatabaseConnectTicks, startTicks);

    public static void EndCompression(long startTicks) =>
        AddTicks(ref _current.EndCompressionTicks, startTicks);

    public static void EndWriteCrc(long startTicks) =>
        AddTicks(ref _current.WriteCrcTicks, startTicks);

    public static long BeginDomainSave(BaseGameDataDomain domain, ArchiveFileBase archive) =>
        _current.StartTicks != 0 && archive is LocalArchiveFile ? Stopwatch.GetTimestamp() : 0;

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
        long domainTicks = GetDomainTicks();
        long measuredContentTicks = GetMeasuredContentTicks(session, domainTicks);
        long contentResidualTicks = session.WriteContentTicks > measuredContentTicks
            ? session.WriteContentTicks - measuredContentTicks
            : 0;
        long saveMeasuredTicks = session.WriteHeaderTicks + session.WriteContentTicks;
        long saveResidualTicks = totalTicks > saveMeasuredTicks ? totalTicks - saveMeasuredTicks : 0;

        StringBuilder builder = new(1600);
        builder.AppendLine("TaiwuDiagnostics: 存档写入耗时拆解");
        AppendMetric(builder, "总耗时", FormatMilliseconds(totalTicks));
        AppendMetric(builder, "已拆分耗时", FormatMilliseconds(saveMeasuredTicks));
        AppendMetric(builder, "其他耗时", FormatMilliseconds(saveResidualTicks));
        AppendMetric(builder, "存档路径", string.IsNullOrEmpty(session.ArchivePath) ? "未知" : session.ArchivePath);
        AppendMetric(builder, "文件大小", FormatBytes(session.FinalFileSizeBytes));
        if (!string.IsNullOrEmpty(session.ExceptionText))
        {
            AppendMetric(builder, "异常", session.ExceptionText);
        }

        builder.AppendLine("  ArchiveFile:");
        AppendMetric(builder, "WriteHeader", FormatMilliseconds(session.WriteHeaderTicks));
        AppendMetric(builder, "WriteContent", FormatMilliseconds(session.WriteContentTicks));
        AppendMetric(builder, "Content 已拆分", FormatMilliseconds(measuredContentTicks));
        AppendMetric(builder, "Content 其他", FormatMilliseconds(contentResidualTicks));

        builder.AppendLine("  Domain.OnSaveWorld:");
        foreach (DomainMetric metric in DomainMetrics)
        {
            AppendMetric(builder, metric.Name, FormatMilliseconds(metric.Ticks) + ", calls=" + metric.Calls);
        }

        builder.AppendLine("  Database:");
        AppendMetric(builder, "DatabaseBridge.Disconnect", FormatMilliseconds(session.DatabaseDisconnectTicks));
        AppendMetric(builder, "CopyWorkingDb", FormatMilliseconds(session.CopyWorkingDbTicks) +
            ", calls=" + session.CopyWorkingDbCalls +
            ", bytes=" + FormatBytes(session.CopyWorkingDbBytes));
        AppendMetric(builder, "DatabaseBridge.Connect", FormatMilliseconds(session.DatabaseConnectTicks));

        builder.AppendLine("  Compression:");
        AppendMetric(builder, "CompressionType", string.IsNullOrEmpty(session.CompressionType) ? "未知" : session.CompressionType);
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
        long measuredContentTicks = GetMeasuredContentTicks(session, domainTicks);
        long contentResidualTicks = session.WriteContentTicks > measuredContentTicks
            ? session.WriteContentTicks - measuredContentTicks
            : 0;
        long saveMeasuredTicks = session.WriteHeaderTicks + session.WriteContentTicks;
        long saveResidualTicks = totalTicks > saveMeasuredTicks ? totalTicks - saveMeasuredTicks : 0;

        return new
        {
            probe = "save_world",
            probeVersion = 2,
            elapsedMs = ToMilliseconds(totalTicks),
            archiveType = string.IsNullOrEmpty(session.ArchiveType) ? null : session.ArchiveType,
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
                compressionType = string.IsNullOrEmpty(session.CompressionType) ? null : session.CompressionType,
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
            eventType = "diagnostics.save_world",
            elapsedMs = ToMilliseconds(totalTicks),
            archivePath = session.ArchivePath,
            fileSizeBytes = session.FinalFileSizeBytes,
            compressionType = session.CompressionType,
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

        result.Sort(static (left, right) =>
        {
            double leftMs = (double)left.GetType().GetProperty("elapsedMs")!.GetValue(left)!;
            double rightMs = (double)right.GetType().GetProperty("elapsedMs")!.GetValue(right)!;
            return rightMs.CompareTo(leftMs);
        });
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

    private static long GetMeasuredContentTicks(in Session session, long domainTicks) =>
        domainTicks +
        session.DatabaseDisconnectTicks +
        session.CopyWorkingDbTicks +
        session.DatabaseConnectTicks +
        session.EndCompressionTicks +
        session.WriteCrcTicks;

    private static string FormatMilliseconds(long ticks) =>
        (ticks * 1000.0 / Stopwatch.Frequency).ToString("N3") + "ms";

    private static double ToMilliseconds(long ticks) =>
        ticks * 1000.0 / Stopwatch.Frequency;

    private static string FormatBytes(long bytes) =>
        bytes < 0 ? "未知" : bytes.ToString();

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
        public string ArchiveType;
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
        public string CompressionType;
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
