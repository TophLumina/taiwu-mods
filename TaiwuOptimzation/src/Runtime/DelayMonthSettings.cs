using System;
using GameData.Domains;

namespace TaiwuOptimization.Runtime;

internal static class DelayMonthSettings
{
    public static bool Enabled = true;
    public static bool SyncNeighborStates = true;
    public static int FrameBudgetMs = 1;
    public static int MaxJobsPerFrame = 1;
    public static bool DelayEquipment = true;
    public static bool DelayMissionGoal = true;
    public static bool DelayLoseOverloadItems = true;
    public static bool DelayBrokenBlocks = true;
    public static bool DelayAnimalAreaData = true;
    public static bool DelaySkeletonGeneration = true;
    public static bool DelayMapPickups = true;

    public static void Load(string modId)
    {
        TryGet(modId, "Enabled", ref Enabled);
        TryGet(modId, "SyncNeighborStates", ref SyncNeighborStates);
        TryGet(modId, "FrameBudgetMs", ref FrameBudgetMs);
        TryGet(modId, "MaxJobsPerFrame", ref MaxJobsPerFrame);
        TryGet(modId, "DelayEquipment", ref DelayEquipment);
        TryGet(modId, "DelayMissionGoal", ref DelayMissionGoal);
        TryGet(modId, "DelayLoseOverloadItems", ref DelayLoseOverloadItems);
        TryGet(modId, "DelayBrokenBlocks", ref DelayBrokenBlocks);
        TryGet(modId, "DelayAnimalAreaData", ref DelayAnimalAreaData);
        TryGet(modId, "DelaySkeletonGeneration", ref DelaySkeletonGeneration);
        TryGet(modId, "DelayMapPickups", ref DelayMapPickups);

        FrameBudgetMs = Math.Clamp(FrameBudgetMs, 1, 4);
        MaxJobsPerFrame = Math.Clamp(MaxJobsPerFrame, 1, 4);
    }

    private static void TryGet(string modId, string key, ref bool value)
    {
        try
        {
            DomainManager.Mod.GetSetting(modId, key, ref value);
        }
        catch
        {
            // Keep defaults when the settings file is absent or the backend is not ready yet.
        }
    }

    private static void TryGet(string modId, string key, ref int value)
    {
        try
        {
            DomainManager.Mod.GetSetting(modId, key, ref value);
        }
        catch
        {
            // Keep defaults when the settings file is absent or the backend is not ready yet.
        }
    }
}
