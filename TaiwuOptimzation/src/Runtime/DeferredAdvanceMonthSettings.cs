using System;
using GameData.Domains;

namespace TaiwuOptimization.Runtime;

internal static class DeferredAdvanceMonthSettings
{
    public static bool Enabled = true;
    public static bool SyncNeighborStates = true;
    public static int FrameBudgetMs = 1;
    public static int MaxJobsPerFrame = 1;
    public static bool DelayCharacterPreparationCombatSkillAndItemEquipping = true;
    public static bool DelayCharacterPreparationLoseOverloadItems = true;
    public static bool DelayMapBrokenBlockCountdown = true;
    public static bool DelayAnimalAreaData = true;
    public static bool DelayGraveSkeletonGeneration = true;
    public static bool DelayMapPickupsPostAdvanceMonth = true;

    public static void Load(string modId)
    {
        TryGet(modId, "Enabled", ref Enabled);
        TryGet(modId, "SyncNeighborStates", ref SyncNeighborStates);
        TryGet(modId, "FrameBudgetMs", ref FrameBudgetMs);
        TryGet(modId, "MaxJobsPerFrame", ref MaxJobsPerFrame);
        TryGet(modId, "DelayCharacterPreparationCombatSkillAndItemEquipping", ref DelayCharacterPreparationCombatSkillAndItemEquipping);
        TryGet(modId, "DelayCharacterPreparationLoseOverloadItems", ref DelayCharacterPreparationLoseOverloadItems);
        TryGet(modId, "DelayMapBrokenBlockCountdown", ref DelayMapBrokenBlockCountdown);
        TryGet(modId, "DelayAnimalAreaData", ref DelayAnimalAreaData);
        TryGet(modId, "DelayGraveSkeletonGeneration", ref DelayGraveSkeletonGeneration);
        TryGet(modId, "DelayMapPickupsPostAdvanceMonth", ref DelayMapPickupsPostAdvanceMonth);

        FrameBudgetMs = Math.Clamp(FrameBudgetMs, 1, 4);
        MaxJobsPerFrame = Math.Clamp(MaxJobsPerFrame, 1, 16);
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
