using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using GameData.ArchiveData;
using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.World;
using HarmonyLib;
using TaiwuDiagnostics.Runtime;

namespace TaiwuDiagnostics.Patches;

[HarmonyPatch(typeof(WorldDomain), nameof(WorldDomain.AdvanceMonth))]
internal static class TaiwuDiagnosticsAdvanceMonthPatch
{
    private static void Prefix(out long __state)
    {
        CharacterActionPlanningDiagnostics.BeginAdvanceMonth();
        __state = Stopwatch.GetTimestamp();
    }

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndAdvanceMonth();
        PublishElapsed("diagnostics.advance_month", __state, __exception);
        return __exception;
    }

    internal static double GetElapsedMilliseconds(long startTimestamp) =>
        (Stopwatch.GetTimestamp() - startTimestamp) * 1000.0 / Stopwatch.Frequency;

    internal static object BuildExceptionPayload(Exception? exception) =>
        exception == null
            ? new { hasException = false }
            : new
            {
                hasException = true,
                exception = exception.GetType().FullName,
                message = exception.Message,
            };

    internal static void PublishElapsed(string eventType, long startTimestamp, Exception? exception)
    {
        TaiwuDiagnosticsExporter.Publish(
            eventType,
            new
            {
                elapsedMs = GetElapsedMilliseconds(startTimestamp),
                exception = BuildExceptionPayload(exception),
            });
    }
}

[HarmonyPatch(typeof(InformationDomain), nameof(InformationDomain.ProcessAdvanceMonth))]
internal static class TaiwuDiagnosticsUpdateInformationPatch
{
    private static void Prefix(out long __state) =>
        __state = Stopwatch.GetTimestamp();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        TaiwuDiagnosticsAdvanceMonthPatch.PublishElapsed(
            "diagnostics.update_information",
            __state,
            __exception);
        return __exception;
    }
}

[HarmonyPatch(typeof(ArchiveFileBase), nameof(ArchiveFileBase.Save))]
internal static class TaiwuDiagnosticsArchiveSavePatch
{
    private static void Prefix(
        ArchiveFileBase __instance,
        ref CompressionType compressionType,
        out long __state) =>
        __state = SaveWorldDiagnostics.BeginArchiveSave(__instance, compressionType);

    private static Exception? Finalizer(
        ArchiveFileBase __instance,
        ref CompressionType compressionType,
        long __state,
        Exception? __exception)
    {
        SaveWorldDiagnostics.EndArchiveSave(__instance, __state, __exception);
        return __exception;
    }
}

[HarmonyPatch(typeof(LocalArchiveFile), "WriteHeader")]
internal static class TaiwuDiagnosticsWriteHeaderPatch
{
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long __state) =>
        SaveWorldDiagnostics.EndWriteHeader(__state);
}

[HarmonyPatch(typeof(LocalArchiveFile), "WriteContent")]
internal static class TaiwuDiagnosticsWriteContentPatch
{
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        SaveWorldDiagnostics.EndWriteContent(__state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class TaiwuDiagnosticsDomainSavePatch
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        Type baseType = typeof(BaseGameDataDomain);
        foreach (Type type in baseType.Assembly.GetTypes())
        {
            if (type.IsAbstract || !baseType.IsAssignableFrom(type))
            {
                continue;
            }

            MethodInfo? method = type.GetMethod(
                nameof(BaseGameDataDomain.OnSaveWorld),
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (method?.DeclaringType == type)
            {
                yield return method;
            }
        }
    }

    private static void Prefix(BaseGameDataDomain __instance, ArchiveFileBase archive, out long __state) =>
        __state = SaveWorldDiagnostics.BeginDomainSave(__instance, archive);

    private static Exception? Finalizer(BaseGameDataDomain __instance, long __state, Exception? __exception)
    {
        SaveWorldDiagnostics.EndDomainSave(__instance, __state);
        return __exception;
    }
}

[HarmonyPatch(typeof(DatabaseBridge), nameof(DatabaseBridge.Disconnect))]
internal static class TaiwuDiagnosticsDatabaseDisconnectPatch
{
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long __state) =>
        SaveWorldDiagnostics.EndDatabaseDisconnect(__state);
}

[HarmonyPatch(typeof(DatabaseBridge), nameof(DatabaseBridge.Connect))]
internal static class TaiwuDiagnosticsDatabaseConnectPatch
{
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long __state) =>
        SaveWorldDiagnostics.EndDatabaseConnect(__state);
}

[HarmonyPatch(typeof(ArchiveFileBase), nameof(ArchiveFileBase.CopyFrom))]
internal static class TaiwuDiagnosticsCopyFromPatch
{
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long length, long __state) =>
        SaveWorldDiagnostics.EndCopyFrom(__state, length);
}

[HarmonyPatch(typeof(CompressionStreamFactory), nameof(CompressionStreamFactory.EndCompression))]
internal static class TaiwuDiagnosticsEndCompressionPatch
{
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long __state) =>
        SaveWorldDiagnostics.EndCompression(__state);
}

[HarmonyPatch]
internal static class TaiwuDiagnosticsWriteCrcToEndPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(typeof(ArchiveFileBase), "WriteCrcToEnd");

    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long __state) =>
        SaveWorldDiagnostics.EndWriteCrc(__state);
}
