using System;
using System.Reflection;
using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Secret;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(InformationDomain), nameof(InformationDomain.ProcessSecretInformationAdvanceMonth))]
internal static class SecretInformationHolderCountCacheLifecyclePatch
{
    // 秘闻月结开始时进入短生命周期索引作用域。
    private static void Prefix() =>
        SecretInformationHolderCountCache.BeginSecretInformationAdvanceMonth();

    // 无论原版是否异常退出，都要清理本月临时索引。
    private static Exception? Finalizer(Exception? __exception)
    {
        SecretInformationHolderCountCache.EndSecretInformationAdvanceMonth();
        return __exception;
    }
}

[HarmonyPatch(typeof(InformationDomain), nameof(InformationDomain.MakeSettlementsInformation))]
internal static class SecretInformationHolderCountCacheBuildPatch
{
    // 普通见闻生成不会修改秘闻；在它之后建立秘闻 holder count 反查表。
    private static void Postfix(InformationDomain __instance) =>
        SecretInformationHolderCountCache.BuildAfterMakeSettlementsInformation(__instance);
}

[HarmonyPatch]
internal static class SecretInformationHolderCountCacheBeforeMetabolismPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(InformationDomain),
            "MetabolismSecretInformation",
            new[] { typeof(DataContext) });

    // 秘闻代谢会广播、删除、批量丢弃秘闻；第一版在这里回退原版。
    [HarmonyPriority(Priority.First)]
    private static void Prefix() =>
        SecretInformationHolderCountCache.DeactivateBeforeMetabolismSecretInformation();
}

[HarmonyPatch]
internal static class SecretInformationMetabolismOptimizerPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(InformationDomain),
            "MetabolismSecretInformation",
            new[] { typeof(DataContext) });

    // 用反查表替换原版秘闻代谢内的反复全表扫描；失败时放行原版。
    [HarmonyPriority(Priority.Last)]
    private static bool Prefix(InformationDomain __instance, DataContext context) =>
        !SecretInformationMetabolismOptimizer.TryProcessMetabolismSecretInformation(__instance, context);
}

[HarmonyPatch]
internal static class SecretInformationHolderCountCacheLookupPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(typeof(InformationDomain), "CalcSecretOccurenceHolderCount");

    [HarmonyPriority(Priority.Last)]
    private static bool Prefix(SecretOccurenceId occurenceId, ref int __result)
    {
        if (!SecretInformationHolderCountCache.TryGetHolderCount(occurenceId, out int holderCount))
        {
            return true;
        }

        __result = holderCount;
        return false;
    }
}

[HarmonyPatch]
internal static class SecretInformationHolderCountCacheReceivePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(InformationDomain),
            "ReceiveSecretInformation",
            new[]
            {
                typeof(DataContext),
                typeof(SecretInformation),
                typeof(int),
                typeof(int),
                typeof(SecretInformationId).MakeByRefType(),
            });

    // 传播成功后，原版已经写入 KnownSecrets；此时同步 holder count +1。
    private static void Postfix(bool __result, ref SecretInformationId realReceivedSecretId) =>
        SecretInformationHolderCountCache.OnReceiveSecretInformationFinished(__result, realReceivedSecretId);
}

[HarmonyPatch]
internal static class SecretInformationHolderCountCacheAddSecretInformationPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(InformationDomain),
            "AddElement_SecretInformation",
            new[] { typeof(SecretInformationId), typeof(SecretInformation), typeof(DataContext) });

    // ReceiveSecretInformation 可能复制出新的 SecretInformationId，需要补充映射。
    private static void Postfix(SecretInformationId elementId, SecretInformation value) =>
        SecretInformationHolderCountCache.OnSecretInformationAdded(elementId, value);
}

[HarmonyPatch]
internal static class SecretInformationHolderCountCacheRemoveSecretInformationPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(InformationDomain),
            "RemoveElement_SecretInformation",
            new[] { typeof(SecretInformationId), typeof(DataContext) });

    // 传播阶段不应删除秘闻；如果发生，停用索引以保证正确性。
    private static void Postfix() =>
        SecretInformationHolderCountCache.OnSecretInformationRemoved();
}
