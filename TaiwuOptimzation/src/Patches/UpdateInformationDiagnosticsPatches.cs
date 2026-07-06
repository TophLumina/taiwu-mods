using System;
using System.Collections.Generic;
using System.Reflection;
using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Secret;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(InformationDomain), nameof(InformationDomain.ProcessAdvanceMonth))]
internal static class UpdateInformationDiagnosticsProcessAdvanceMonthPatch
{
    // 以原版 UpdateInformation 入口作为诊断总边界。
    private static void Prefix(InformationDomain __instance, out long __state) =>
        __state = UpdateInformationDiagnostics.BeginUpdateInformation(__instance);

    // 原版逻辑结束后写出一次聚合日志。
    private static void Postfix(InformationDomain __instance, long __state) =>
        UpdateInformationDiagnostics.EndUpdateInformation(__instance, __state);
}

[HarmonyPatch(typeof(InformationDomain), nameof(InformationDomain.MakeSettlementsInformation))]
internal static class UpdateInformationDiagnosticsMakeSettlementsInformationPatch
{
    // 记录据点信息生成阶段耗时。
    private static void Prefix(out long __state) =>
        __state = UpdateInformationDiagnostics.BeginPhase();

    private static void Postfix(long __state) =>
        UpdateInformationDiagnostics.EndPhase(
            UpdateInformationDiagnosticsPhase.MakeSettlementsInformation,
            __state);
}

[HarmonyPatch]
internal static class UpdateInformationDiagnosticsPlanDisseminateSecretInformationPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(InformationDomain),
            "PlanDisseminateSecretInformation",
            new[] { typeof(DataContext), typeof(int) });

    // 记录单个 NPC 的秘闻传播计划耗时，只聚合不逐条打印。
    private static void Prefix(out long __state) =>
        __state = UpdateInformationDiagnostics.BeginPhase();

    private static void Postfix(int charId, long __state) =>
        UpdateInformationDiagnostics.EndPlanDisseminateSecretInformation(charId, __state);
}

[HarmonyPatch]
internal static class UpdateInformationDiagnosticsMetabolismSecretInformationPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(InformationDomain),
            "MetabolismSecretInformation",
            new[] { typeof(DataContext) });

    // 记录秘闻过期、广播和清理阶段耗时。
    private static void Prefix(out long __state) =>
        __state = UpdateInformationDiagnostics.BeginMetabolismSecretInformation();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        UpdateInformationDiagnostics.EndMetabolismSecretInformation(__state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class UpdateInformationDiagnosticsMakeSecretBroadcastPatch
{
    private static MethodBase TargetMethod()
    {
        foreach (MethodInfo method in AccessTools.GetDeclaredMethods(typeof(InformationDomain)))
        {
            if (method.Name == "MakeSecretBroadcast" && method.GetParameters().Length == 6)
            {
                return method;
            }
        }

        return null!;
    }

    // 记录秘闻广播效果与广播前清理的总耗时。
    private static void Prefix(out long __state) =>
        __state = UpdateInformationDiagnostics.BeginMetabolismDetail();

    private static void Postfix(long __state) =>
        UpdateInformationDiagnostics.EndMetabolismDetail(
            UpdateInformationDiagnosticsMetabolismDetail.MakeSecretBroadcast,
            __state);
}

[HarmonyPatch(typeof(InformationDomain), nameof(InformationDomain.DiscardSecretInformation), new[] { typeof(DataContext), typeof(int), typeof(SecretInformationId) })]
internal static class UpdateInformationDiagnosticsDiscardSecretInformationPatch
{
    // 记录代谢阶段丢弃角色持有秘闻的耗时。
    private static void Prefix(out long __state) =>
        __state = UpdateInformationDiagnostics.BeginMetabolismDetail();

    private static void Postfix(long __state) =>
        UpdateInformationDiagnostics.EndMetabolismDetail(
            UpdateInformationDiagnosticsMetabolismDetail.DiscardSecretInformation,
            __state);
}

[HarmonyPatch]
internal static class UpdateInformationDiagnosticsRecordSecretInformationRemovePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(InformationDomain),
            "RecordSecretInformationRemove",
            new[] { typeof(DataContext), typeof(IEnumerable<SecretInformationId>) });

    // 记录最终批量移除 SecretInformation 的外层耗时。
    private static void Prefix(out long __state) =>
        __state = UpdateInformationDiagnostics.BeginMetabolismDetail();

    private static void Postfix(long __state) =>
        UpdateInformationDiagnostics.EndMetabolismDetail(
            UpdateInformationDiagnosticsMetabolismDetail.RecordSecretInformationRemove,
            __state);
}

[HarmonyPatch]
internal static class UpdateInformationDiagnosticsRecordSecretOccurenceRemovePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(InformationDomain),
            "RecordSecretOccurenceRemove",
            new[] { typeof(DataContext), typeof(IEnumerable<SecretOccurenceId>) });

    // 记录最终批量移除 SecretOccurence 的外层耗时。
    private static void Prefix(out long __state) =>
        __state = UpdateInformationDiagnostics.BeginMetabolismDetail();

    private static void Postfix(long __state) =>
        UpdateInformationDiagnostics.EndMetabolismDetail(
            UpdateInformationDiagnosticsMetabolismDetail.RecordSecretOccurenceRemove,
            __state);
}

[HarmonyPatch]
internal static class UpdateInformationDiagnosticsRemoveElementSecretInformationPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(InformationDomain),
            "RemoveElement_SecretInformation",
            new[] { typeof(SecretInformationId), typeof(DataContext) });

    // 记录单条 SecretInformation 移除和数据脏标记耗时。
    private static void Prefix(out long __state) =>
        __state = UpdateInformationDiagnostics.BeginMetabolismDetail();

    private static void Postfix(long __state) =>
        UpdateInformationDiagnostics.EndMetabolismDetail(
            UpdateInformationDiagnosticsMetabolismDetail.RemoveElementSecretInformation,
            __state);
}

[HarmonyPatch]
internal static class UpdateInformationDiagnosticsRemoveElementSecretOccurencePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(InformationDomain),
            "RemoveElement_SecretOccurence",
            new[] { typeof(SecretOccurenceId), typeof(DataContext) });

    // 记录单条 SecretOccurence 移除和数据脏标记耗时。
    private static void Prefix(out long __state) =>
        __state = UpdateInformationDiagnostics.BeginMetabolismDetail();

    private static void Postfix(long __state) =>
        UpdateInformationDiagnostics.EndMetabolismDetail(
            UpdateInformationDiagnosticsMetabolismDetail.RemoveElementSecretOccurence,
            __state);
}

[HarmonyPatch]
internal static class UpdateInformationDiagnosticsCalcSecretOccurenceHolderCountPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(typeof(InformationDomain), "CalcSecretOccurenceHolderCount");

    // 记录秘闻事件 holder 数量反查的真实热度。
    private static void Prefix(out long __state) =>
        __state = UpdateInformationDiagnostics.BeginPhase();

    private static void Postfix(long __state) =>
        UpdateInformationDiagnostics.EndLookup(
            UpdateInformationDiagnosticsLookup.CalcSecretOccurenceHolderCount,
            __state);
}

[HarmonyPatch]
internal static class UpdateInformationDiagnosticsCalcSecretInformationKnownCharacterCountPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(typeof(InformationDomain), "CalcSecretInformationKnownCharacterCount");

    // 记录按 secretId 反查持有人数量的真实热度。
    private static void Prefix(out long __state) =>
        __state = UpdateInformationDiagnostics.BeginPhase();

    private static void Postfix(long __state) =>
        UpdateInformationDiagnostics.EndLookup(
            UpdateInformationDiagnosticsLookup.CalcSecretInformationKnownCharacterCount,
            __state);
}
