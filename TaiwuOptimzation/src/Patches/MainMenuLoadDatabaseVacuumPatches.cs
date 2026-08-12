using System;
using GameData.ArchiveData;
using GameData.Domains.Global;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

/// <summary>
/// GlobalDomain.LoadWorld is the normal out-of-world load entry used by the main
/// menu. It schedules the actual LocalArchiveFile.Load for the next backend frame.
/// </summary>
[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.LoadWorld))]
internal static class MainMenuLoadDatabaseVacuumRequestPatch
{
    private static void Prefix(sbyte archiveId, long backupTimestamp, out long __state) =>
        __state = MainMenuLoadDatabaseVacuum.Arm(archiveId, backupTimestamp);

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        if (__exception != null)
        {
            MainMenuLoadDatabaseVacuum.Cancel(__state);
        }

        return __exception;
    }
}

/// <summary>
/// The exact path armed above is consumed here. This excludes LoadEnding,
/// LoadWorldAt, tutorial/temp archives, archive-info reads, and every save.
/// </summary>
[HarmonyPatch(typeof(ArchiveFileBase), nameof(ArchiveFileBase.Load))]
internal static class MainMenuLoadDatabaseVacuumArchiveLoadPatch
{
    private static Exception? Finalizer(
        ArchiveFileBase __instance,
        string ___Path,
        Exception? __exception)
    {
        MainMenuLoadDatabaseVacuum.CompleteArchiveLoad(
            __instance,
            ___Path,
            __exception);
        return __exception;
    }
}
