using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using GameData.ArchiveData;
using GameData.Common;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(ArchiveFileBase), nameof(ArchiveFileBase.Save))]
internal static class SaveWorldDiagnosticsArchiveFileSavePatch
{
    // 以 ArchiveFileBase.Save 作为本地存档写盘诊断的总边界。
    private static void Prefix(ArchiveFileBase __instance, ref CompressionType compressionType, out long __state)
    {
        compressionType = SaveWorldArchiveOptimization.GetCompressionType(__instance, compressionType);
        __state = SaveWorldDiagnostics.BeginArchiveSave(__instance, compressionType);
    }

    private static Exception? Finalizer(ArchiveFileBase __instance, long __state, Exception? __exception)
    {
        SaveWorldDiagnostics.EndArchiveSave(__instance, __state, __exception);
        return __exception;
    }
}

[HarmonyPatch(typeof(LocalArchiveFile), "WriteHeader")]
internal static class SaveWorldDiagnosticsWriteHeaderPatch
{
    // 记录存档头写入耗时，通常很小，用来和正文写入分开。
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long __state) =>
        SaveWorldDiagnostics.EndWriteHeader(__state);
}

[HarmonyPatch(typeof(LocalArchiveFile), "WriteContent")]
internal static class SaveWorldDiagnosticsWriteContentPatch
{
    // 记录世界正文写入总耗时，正文中还会继续拆分 domain、working.db 与压缩收尾。
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        SaveWorldDiagnostics.EndWriteContent(__state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class SaveWorldDiagnosticsDomainSavePatch
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

    // 每个 archive attached domain 在 LocalArchiveFile.WriteContent 内串行写入。
    private static void Prefix(BaseGameDataDomain __instance, ArchiveFileBase archive, out long __state) =>
        __state = SaveWorldDiagnostics.BeginDomainSave(__instance, archive);

    private static Exception? Finalizer(BaseGameDataDomain __instance, long __state, Exception? __exception)
    {
        SaveWorldDiagnostics.EndDomainSave(__instance, __state);
        return __exception;
    }
}

[HarmonyPatch(typeof(DatabaseBridge), nameof(DatabaseBridge.Disconnect))]
internal static class SaveWorldDiagnosticsDatabaseDisconnectPatch
{
    // LocalArchiveFile 会先断开 working.db，再把数据库文件复制进存档。
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long __state) =>
        SaveWorldDiagnostics.EndDatabaseDisconnect(__state);
}

[HarmonyPatch(typeof(DatabaseBridge), nameof(DatabaseBridge.Connect))]
internal static class SaveWorldDiagnosticsDatabaseConnectPatch
{
    // working.db 复制完后原版会重新连接数据库。
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long __state) =>
        SaveWorldDiagnostics.EndDatabaseConnect(__state);
}

[HarmonyPatch(typeof(ArchiveFileBase), nameof(ArchiveFileBase.CopyFrom))]
internal static class SaveWorldDiagnosticsCopyFromPatch
{
    private static readonly MethodInfo CopyBufferGetter =
        AccessTools.Method(typeof(SaveWorldArchiveOptimization), nameof(SaveWorldArchiveOptimization.GetDatabaseCopyBufferBytes));

    // LocalArchiveFile.WriteContent 中此调用对应 working.db 复制。
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long length, long __state) =>
        SaveWorldDiagnostics.EndCopyFrom(__state, length);

    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) =>
        SaveWorldCopyBufferTranspiler.ReplaceOriginalCopyBuffer(instructions, CopyBufferGetter);
}

[HarmonyPatch(typeof(ArchiveFileBase), nameof(ArchiveFileBase.CopyTo))]
internal static class SaveWorldCopyToBufferPatch
{
    private static readonly MethodInfo CopyBufferGetter =
        AccessTools.Method(typeof(SaveWorldArchiveOptimization), nameof(SaveWorldArchiveOptimization.GetDatabaseCopyBufferBytes));

    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) =>
        SaveWorldCopyBufferTranspiler.ReplaceOriginalCopyBuffer(instructions, CopyBufferGetter);
}

internal static class SaveWorldCopyBufferTranspiler
{
    /// <summary>把原版 CopyFrom/CopyTo 中的 4KB 常量替换为配置的安全块大小。</summary>
    public static IEnumerable<CodeInstruction> ReplaceOriginalCopyBuffer(
        IEnumerable<CodeInstruction> instructions,
        MethodInfo copyBufferGetter)
    {
        foreach (CodeInstruction instruction in instructions)
        {
            if (IsOriginalCopyBufferConstant(instruction))
            {
                instruction.opcode = OpCodes.Call;
                instruction.operand = copyBufferGetter;
            }

            yield return instruction;
        }
    }

    private static bool IsOriginalCopyBufferConstant(CodeInstruction instruction)
    {
        if (instruction.opcode == OpCodes.Ldc_I8 &&
            instruction.operand is long longValue &&
            longValue == SaveWorldArchiveOptimization.OriginalCopyBufferBytes)
        {
            return true;
        }

        return instruction.opcode == OpCodes.Ldc_I4 &&
            instruction.operand is int intValue &&
            intValue == SaveWorldArchiveOptimization.OriginalCopyBufferBytes;
    }
}

[HarmonyPatch(typeof(CompressionStreamFactory), nameof(CompressionStreamFactory.EndCompression))]
internal static class SaveWorldDiagnosticsEndCompressionPatch
{
    // DeflateStream.Dispose 会完成最后的压缩 flush，这一步可能有可见耗时。
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long __state) =>
        SaveWorldDiagnostics.EndCompression(__state);
}

[HarmonyPatch]
internal static class SaveWorldDiagnosticsWriteCrcToEndPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(typeof(ArchiveFileBase), "WriteCrcToEnd");

    // 记录最终 CRC 写入，通常很小，用于确认剩余耗时是否来自别处。
    private static void Prefix(out long __state) =>
        __state = SaveWorldDiagnostics.BeginStep();

    private static void Postfix(long __state) =>
        SaveWorldDiagnostics.EndWriteCrc(__state);
}
