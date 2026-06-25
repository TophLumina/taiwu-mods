using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using GameData.Domains.Information;
using HarmonyLib;
using NLog;

namespace TaiwuOptimization.Runtime;

internal enum UpdateInformationDiagnosticsPhase
{
    MakeSettlementsInformation,
    PlanDisseminateSecretInformation,
    MetabolismSecretInformation,
}

internal enum UpdateInformationDiagnosticsLookup
{
    CalcSecretOccurenceHolderCount,
    CalcSecretInformationKnownCharacterCount,
}

internal enum UpdateInformationDiagnosticsMetabolismDetail
{
    MakeSecretBroadcast,
    DiscardSecretInformation,
    RecordSecretInformationRemove,
    RecordSecretOccurenceRemove,
    RemoveElementSecretInformation,
    RemoveElementSecretOccurence,
}

internal static class UpdateInformationDiagnostics
{
    private static readonly long SlowPlanDisseminateThresholdTicks = Stopwatch.Frequency / 200;

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private static readonly FieldInfo? SecretInformationField = AccessTools.Field(typeof(InformationDomain), "_secretInformation");
    private static readonly FieldInfo? SecretOccurenceField = AccessTools.Field(typeof(InformationDomain), "_secretOccurence");
    private static readonly FieldInfo? CharacterKnownSecretsField = AccessTools.Field(typeof(InformationDomain), "_characterKnownSecrets");
    private static readonly FieldInfo? KnownSecretsField = GetKnownSecretsField();

    // 当前 UpdateInformation 调用的聚合状态；原版过月阶段是串行调用。
    private static Session _current;
    private static bool _isInMetabolismSecretInformation;

    /// <summary>开始记录一次 InformationDomain.ProcessAdvanceMonth。</summary>
    /// <param name="domain">原版 InformationDomain 实例。</param>
    /// <returns>诊断开启时返回起始 ticks，否则返回 0。</returns>
    public static long BeginUpdateInformation(InformationDomain domain)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled)
        {
            return 0;
        }

        _current = default;
        _isInMetabolismSecretInformation = false;
        _current.StartTicks = Stopwatch.GetTimestamp();
        _current.InitialSecretInformationCount = GetDictionaryCount(SecretInformationField, domain);
        _current.InitialSecretOccurenceCount = GetDictionaryCount(SecretOccurenceField, domain);
        _current.InitialCharacterKnownSecretsCount = GetDictionaryCount(CharacterKnownSecretsField, domain);
        _current.InitialKnownSecretLinkCount = CountKnownSecretLinks(domain);
        return _current.StartTicks;
    }

    /// <summary>结束并写出一次 UpdateInformation 聚合诊断。</summary>
    /// <param name="domain">原版 InformationDomain 实例。</param>
    /// <param name="startTicks">BeginUpdateInformation 返回的起始 ticks。</param>
    public static void EndUpdateInformation(InformationDomain domain, long startTicks)
    {
        if (startTicks == 0)
        {
            return;
        }

        long totalTicks = Stopwatch.GetTimestamp() - startTicks;
        _current.FinalSecretInformationCount = GetDictionaryCount(SecretInformationField, domain);
        _current.FinalSecretOccurenceCount = GetDictionaryCount(SecretOccurenceField, domain);
        _current.FinalCharacterKnownSecretsCount = GetDictionaryCount(CharacterKnownSecretsField, domain);
        _current.FinalKnownSecretLinkCount = CountKnownSecretLinks(domain);

        if (Logger.IsInfoEnabled)
        {
            Logger.Info(BuildMessage(totalTicks, in _current));
        }

        _current = default;
        _isInMetabolismSecretInformation = false;
    }

    /// <summary>开始记录 UpdateInformation 内的一个子阶段。</summary>
    /// <returns>诊断开启时返回起始 ticks，否则返回 0。</returns>
    public static long BeginPhase()
    {
        return TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled && _current.StartTicks != 0
            ? Stopwatch.GetTimestamp()
            : 0;
    }

    /// <summary>结束一个非 NPC 粒度的子阶段。</summary>
    /// <param name="phase">子阶段类型。</param>
    /// <param name="startTicks">BeginPhase 返回的起始 ticks。</param>
    public static void EndPhase(UpdateInformationDiagnosticsPhase phase, long startTicks)
    {
        if (startTicks == 0)
        {
            return;
        }

        long elapsedTicks = Stopwatch.GetTimestamp() - startTicks;
        switch (phase)
        {
            case UpdateInformationDiagnosticsPhase.MakeSettlementsInformation:
                _current.MakeSettlementsInformationTicks += elapsedTicks;
                _current.MakeSettlementsInformationCalls++;
                break;
            case UpdateInformationDiagnosticsPhase.MetabolismSecretInformation:
                _current.MetabolismSecretInformationTicks += elapsedTicks;
                _current.MetabolismSecretInformationCalls++;
                break;
        }
    }

    /// <summary>结束一次 NPC 秘闻传播计划阶段。</summary>
    /// <param name="charId">正在执行传播计划的角色 id。</param>
    /// <param name="startTicks">BeginPhase 返回的起始 ticks。</param>
    /// <summary>开始记录秘闻代谢阶段，并允许记录其内部子步骤。</summary>
    /// <returns>诊断开启时返回起始 ticks，否则返回 0。</returns>
    public static long BeginMetabolismSecretInformation()
    {
        long startTicks = BeginPhase();
        if (startTicks != 0)
        {
            _isInMetabolismSecretInformation = true;
        }

        return startTicks;
    }

    /// <summary>结束秘闻代谢阶段。</summary>
    /// <param name="startTicks">BeginMetabolismSecretInformation 返回的起始 ticks。</param>
    public static void EndMetabolismSecretInformation(long startTicks)
    {
        if (startTicks != 0)
        {
            EndPhase(UpdateInformationDiagnosticsPhase.MetabolismSecretInformation, startTicks);
        }

        _isInMetabolismSecretInformation = false;
    }

    /// <summary>开始记录秘闻代谢内部的一个子步骤。</summary>
    /// <returns>处于秘闻代谢阶段且诊断开启时返回起始 ticks，否则返回 0。</returns>
    public static long BeginMetabolismDetail()
    {
        return _isInMetabolismSecretInformation ? Stopwatch.GetTimestamp() : 0;
    }

    /// <summary>结束秘闻代谢内部的一个子步骤。</summary>
    /// <param name="detail">子步骤类型。</param>
    /// <param name="startTicks">BeginMetabolismDetail 返回的起始 ticks。</param>
    public static void EndMetabolismDetail(UpdateInformationDiagnosticsMetabolismDetail detail, long startTicks)
    {
        if (startTicks == 0)
        {
            return;
        }

        long elapsedTicks = Stopwatch.GetTimestamp() - startTicks;
        switch (detail)
        {
            case UpdateInformationDiagnosticsMetabolismDetail.MakeSecretBroadcast:
                _current.MetabolismMakeSecretBroadcastCalls++;
                _current.MetabolismMakeSecretBroadcastTicks += elapsedTicks;
                break;
            case UpdateInformationDiagnosticsMetabolismDetail.DiscardSecretInformation:
                _current.MetabolismDiscardSecretInformationCalls++;
                _current.MetabolismDiscardSecretInformationTicks += elapsedTicks;
                break;
            case UpdateInformationDiagnosticsMetabolismDetail.RecordSecretInformationRemove:
                _current.MetabolismRecordSecretInformationRemoveCalls++;
                _current.MetabolismRecordSecretInformationRemoveTicks += elapsedTicks;
                break;
            case UpdateInformationDiagnosticsMetabolismDetail.RecordSecretOccurenceRemove:
                _current.MetabolismRecordSecretOccurenceRemoveCalls++;
                _current.MetabolismRecordSecretOccurenceRemoveTicks += elapsedTicks;
                break;
            case UpdateInformationDiagnosticsMetabolismDetail.RemoveElementSecretInformation:
                _current.MetabolismRemoveElementSecretInformationCalls++;
                _current.MetabolismRemoveElementSecretInformationTicks += elapsedTicks;
                break;
            case UpdateInformationDiagnosticsMetabolismDetail.RemoveElementSecretOccurence:
                _current.MetabolismRemoveElementSecretOccurenceCalls++;
                _current.MetabolismRemoveElementSecretOccurenceTicks += elapsedTicks;
                break;
        }
    }

    public static void EndPlanDisseminateSecretInformation(int charId, long startTicks)
    {
        if (startTicks == 0)
        {
            return;
        }

        long elapsedTicks = Stopwatch.GetTimestamp() - startTicks;
        _current.PlanDisseminateSecretInformationTicks += elapsedTicks;
        _current.PlanDisseminateSecretInformationCalls++;
        if (elapsedTicks > _current.MaxPlanDisseminateSecretInformationTicks)
        {
            _current.MaxPlanDisseminateSecretInformationTicks = elapsedTicks;
            _current.MaxPlanDisseminateSecretInformationCharId = charId;
        }

        if (elapsedTicks >= SlowPlanDisseminateThresholdTicks)
        {
            _current.SlowPlanDisseminateSecretInformationCalls++;
        }
    }

    /// <summary>结束一次秘闻 holder 数量反查。</summary>
    /// <param name="lookup">反查函数类型。</param>
    /// <param name="startTicks">BeginPhase 返回的起始 ticks。</param>
    public static void EndLookup(UpdateInformationDiagnosticsLookup lookup, long startTicks)
    {
        if (startTicks == 0)
        {
            return;
        }

        long elapsedTicks = Stopwatch.GetTimestamp() - startTicks;
        switch (lookup)
        {
            case UpdateInformationDiagnosticsLookup.CalcSecretOccurenceHolderCount:
                _current.CalcSecretOccurenceHolderCountCalls++;
                _current.CalcSecretOccurenceHolderCountTicks += elapsedTicks;
                if (elapsedTicks > _current.CalcSecretOccurenceHolderCountMaxTicks)
                {
                    _current.CalcSecretOccurenceHolderCountMaxTicks = elapsedTicks;
                }
                break;
            case UpdateInformationDiagnosticsLookup.CalcSecretInformationKnownCharacterCount:
                _current.CalcSecretInformationKnownCharacterCountCalls++;
                _current.CalcSecretInformationKnownCharacterCountTicks += elapsedTicks;
                if (elapsedTicks > _current.CalcSecretInformationKnownCharacterCountMaxTicks)
                {
                    _current.CalcSecretInformationKnownCharacterCountMaxTicks = elapsedTicks;
                }
                break;
        }
    }

    private static int GetDictionaryCount(FieldInfo? field, InformationDomain domain)
    {
        object? value = field?.GetValue(domain);
        return value is ICollection collection ? collection.Count : -1;
    }

    private static FieldInfo? GetKnownSecretsField()
    {
        Type? type = AccessTools.TypeByName("GameData.Domains.Information.Secret.CharacterKnownSecret");
        return type == null ? null : AccessTools.Field(type, "KnownSecrets");
    }

    private static int CountKnownSecretLinks(InformationDomain domain)
    {
        object? value = CharacterKnownSecretsField?.GetValue(domain);
        if (value is not IDictionary dictionary || KnownSecretsField == null)
        {
            return -1;
        }

        int count = 0;
        foreach (DictionaryEntry entry in dictionary)
        {
            if (KnownSecretsField.GetValue(entry.Value) is ICollection knownSecrets)
            {
                count += knownSecrets.Count;
            }
        }

        return count;
    }

    private static string BuildMessage(long totalTicks, in Session session)
    {
        long measuredTicks =
            session.MakeSettlementsInformationTicks +
            session.PlanDisseminateSecretInformationTicks +
            session.MetabolismSecretInformationTicks;
        long otherTicks = totalTicks > measuredTicks ? totalTicks - measuredTicks : 0;
        long holderScanUpperBound = session.InitialSecretInformationCount > 0 &&
            session.InitialCharacterKnownSecretsCount > 0
                ? (long)session.InitialSecretInformationCount * session.InitialCharacterKnownSecretsCount
                : 0;

        StringBuilder builder = new(1200);
        builder.AppendLine("TaiwuOptimization: UpdateInformation breakdown");
        builder.AppendLine("  total:");
        AppendMetric(builder, "elapsed", FormatMilliseconds(totalTicks));
        AppendMetric(builder, "measured", FormatMilliseconds(measuredTicks));
        AppendMetric(builder, "other", FormatMilliseconds(otherTicks));

        builder.AppendLine("  secretInformationData:");
        AppendMetric(builder, "secretInformation", FormatCountDelta(session.InitialSecretInformationCount, session.FinalSecretInformationCount));
        AppendMetric(builder, "secretOccurence", FormatCountDelta(session.InitialSecretOccurenceCount, session.FinalSecretOccurenceCount));
        AppendMetric(builder, "characterKnownSecrets", FormatCountDelta(session.InitialCharacterKnownSecretsCount, session.FinalCharacterKnownSecretsCount));
        AppendMetric(builder, "knownSecretLinks", FormatCountDelta(session.InitialKnownSecretLinkCount, session.FinalKnownSecretLinkCount));
        AppendMetric(builder, "holderScanUpperBound", holderScanUpperBound);

        builder.AppendLine("  phases:");
        AppendPhase(builder, "MakeSettlementsInformation", session.MakeSettlementsInformationCalls, session.MakeSettlementsInformationTicks);
        AppendPhase(builder, "PlanDisseminateSecretInformation", session.PlanDisseminateSecretInformationCalls, session.PlanDisseminateSecretInformationTicks);
        AppendMetric(builder, "  planMax", FormatMilliseconds(session.MaxPlanDisseminateSecretInformationTicks));
        AppendMetric(builder, "  planMaxCharId", session.MaxPlanDisseminateSecretInformationCharId);
        AppendMetric(builder, "  planSlowCalls(>=5ms)", session.SlowPlanDisseminateSecretInformationCalls);
        AppendPhase(builder, "MetabolismSecretInformation", session.MetabolismSecretInformationCalls, session.MetabolismSecretInformationTicks);

        builder.AppendLine("  metabolismDetails:");
        long metabolismMeasuredTicks =
            session.MetabolismMakeSecretBroadcastTicks +
            session.MetabolismDiscardSecretInformationTicks +
            session.MetabolismRecordSecretInformationRemoveTicks +
            session.MetabolismRecordSecretOccurenceRemoveTicks;
        long metabolismResidualTicks = session.MetabolismSecretInformationTicks > metabolismMeasuredTicks
            ? session.MetabolismSecretInformationTicks - metabolismMeasuredTicks
            : 0;
        AppendPhase(builder, "MakeSecretBroadcast", session.MetabolismMakeSecretBroadcastCalls, session.MetabolismMakeSecretBroadcastTicks);
        AppendPhase(builder, "DiscardSecretInformation", session.MetabolismDiscardSecretInformationCalls, session.MetabolismDiscardSecretInformationTicks);
        AppendPhase(builder, "RecordSecretInformationRemove", session.MetabolismRecordSecretInformationRemoveCalls, session.MetabolismRecordSecretInformationRemoveTicks);
        AppendPhase(builder, "RecordSecretOccurenceRemove", session.MetabolismRecordSecretOccurenceRemoveCalls, session.MetabolismRecordSecretOccurenceRemoveTicks);
        AppendPhase(builder, "RemoveElementSecretInformation", session.MetabolismRemoveElementSecretInformationCalls, session.MetabolismRemoveElementSecretInformationTicks);
        AppendPhase(builder, "RemoveElementSecretOccurence", session.MetabolismRemoveElementSecretOccurenceCalls, session.MetabolismRemoveElementSecretOccurenceTicks);
        AppendMetric(builder, "  residual", FormatMilliseconds(metabolismResidualTicks));

        builder.AppendLine("  lookups:");
        AppendLookup(
            builder,
            "CalcSecretOccurenceHolderCount",
            session.CalcSecretOccurenceHolderCountCalls,
            session.CalcSecretOccurenceHolderCountTicks,
            session.CalcSecretOccurenceHolderCountMaxTicks);
        AppendLookup(
            builder,
            "CalcSecretInformationKnownCharacterCount",
            session.CalcSecretInformationKnownCharacterCountCalls,
            session.CalcSecretInformationKnownCharacterCountTicks,
            session.CalcSecretInformationKnownCharacterCountMaxTicks);
        return builder.ToString();
    }

    private static void AppendPhase(StringBuilder builder, string name, int calls, long ticks)
    {
        AppendMetric(builder, name, FormatMilliseconds(ticks) + ", calls=" + calls);
    }

    private static void AppendLookup(StringBuilder builder, string name, int calls, long ticks, long maxTicks)
    {
        AppendMetric(builder, name, FormatMilliseconds(ticks) + ", calls=" + calls + ", max=" + FormatMilliseconds(maxTicks));
    }

    private static string FormatMilliseconds(long ticks) =>
        (ticks * 1000.0 / Stopwatch.Frequency).ToString("N3") + "ms";

    private static string FormatCountDelta(int before, int after)
    {
        return before < 0 || after < 0
            ? "unknown"
            : before + " -> " + after;
    }

    private static void AppendMetric(StringBuilder builder, string name, string value)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.Append(": ");
        builder.Append(value);
        builder.AppendLine();
    }

    private static void AppendMetric(StringBuilder builder, string name, int value)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.Append(": ");
        builder.Append(value);
        builder.AppendLine();
    }

    private static void AppendMetric(StringBuilder builder, string name, long value)
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
        public int InitialSecretInformationCount;
        public int FinalSecretInformationCount;
        public int InitialSecretOccurenceCount;
        public int FinalSecretOccurenceCount;
        public int InitialCharacterKnownSecretsCount;
        public int FinalCharacterKnownSecretsCount;
        public int InitialKnownSecretLinkCount;
        public int FinalKnownSecretLinkCount;
        public int MakeSettlementsInformationCalls;
        public long MakeSettlementsInformationTicks;
        public int PlanDisseminateSecretInformationCalls;
        public int SlowPlanDisseminateSecretInformationCalls;
        public long PlanDisseminateSecretInformationTicks;
        public long MaxPlanDisseminateSecretInformationTicks;
        public int MaxPlanDisseminateSecretInformationCharId;
        public int MetabolismSecretInformationCalls;
        public long MetabolismSecretInformationTicks;
        public int MetabolismMakeSecretBroadcastCalls;
        public long MetabolismMakeSecretBroadcastTicks;
        public int MetabolismDiscardSecretInformationCalls;
        public long MetabolismDiscardSecretInformationTicks;
        public int MetabolismRecordSecretInformationRemoveCalls;
        public long MetabolismRecordSecretInformationRemoveTicks;
        public int MetabolismRecordSecretOccurenceRemoveCalls;
        public long MetabolismRecordSecretOccurenceRemoveTicks;
        public int MetabolismRemoveElementSecretInformationCalls;
        public long MetabolismRemoveElementSecretInformationTicks;
        public int MetabolismRemoveElementSecretOccurenceCalls;
        public long MetabolismRemoveElementSecretOccurenceTicks;
        public int CalcSecretOccurenceHolderCountCalls;
        public long CalcSecretOccurenceHolderCountTicks;
        public long CalcSecretOccurenceHolderCountMaxTicks;
        public int CalcSecretInformationKnownCharacterCountCalls;
        public long CalcSecretInformationKnownCharacterCountTicks;
        public long CalcSecretInformationKnownCharacterCountMaxTicks;
    }
}
