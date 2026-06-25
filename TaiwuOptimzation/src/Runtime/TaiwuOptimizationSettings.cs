using System;
using GameData.Domains;

namespace TaiwuOptimization.Runtime;

internal static class TaiwuOptimizationSettings
{
    public static bool AdvanceMonthOptimizationEnabled = true;
    public static bool SyncNeighborStatesForAdvanceMonth = true;
    public static int AdvanceMonthOptimizationFrameBudgetMs = 1;
    public static int MaxPeriAdvanceMonthDeferredJobsPerFrame = 1;
    public static bool DeferPeriAdvanceMonthActivePreparationCombatSkillAndItemEquipping = true;
    public static bool DeferPeriAdvanceMonthLoseOverloadItems = true;
    public static bool DeferParallelUpdateBrokenBlockOnMonthChange = true;
    public static bool DeferUpdateAnimalAreaData = true;
    public static bool DeferGenerateSkeletons = true;
    public static bool DeferMapPickupsPostAdvanceMonth = true;
    public static bool ReduceRemoteNpcOfflineCurrentGoalActionPointGain = false;
    public static int RemoteNpcOfflineCurrentGoalActionPointGainReduction = 10;
    public static bool ProtectNeighborStatesFromOfflineActionPointReduction = true;
    public static bool ProtectTaiwuVillageResidentsFromOfflineActionPointReduction = true;
    public static bool ProtectSectMembersFromOfflineActionPointReduction = false;

    public static void Load(string modId)
    {
        TryGet(modId, "AdvanceMonthOptimizationEnabled", ref AdvanceMonthOptimizationEnabled);
        TryGet(modId, "SyncNeighborStatesForAdvanceMonth", ref SyncNeighborStatesForAdvanceMonth);
        TryGet(modId, "AdvanceMonthOptimizationFrameBudgetMs", ref AdvanceMonthOptimizationFrameBudgetMs);
        TryGet(modId, "MaxPeriAdvanceMonthDeferredJobsPerFrame", ref MaxPeriAdvanceMonthDeferredJobsPerFrame);
        TryGet(modId, "DeferPeriAdvanceMonthActivePreparationCombatSkillAndItemEquipping", ref DeferPeriAdvanceMonthActivePreparationCombatSkillAndItemEquipping);
        TryGet(modId, "DeferPeriAdvanceMonthLoseOverloadItems", ref DeferPeriAdvanceMonthLoseOverloadItems);
        TryGet(modId, "DeferParallelUpdateBrokenBlockOnMonthChange", ref DeferParallelUpdateBrokenBlockOnMonthChange);
        TryGet(modId, "DeferUpdateAnimalAreaData", ref DeferUpdateAnimalAreaData);
        TryGet(modId, "DeferGenerateSkeletons", ref DeferGenerateSkeletons);
        TryGet(modId, "DeferMapPickupsPostAdvanceMonth", ref DeferMapPickupsPostAdvanceMonth);
        TryGet(modId, "ReduceRemoteNpcOfflineCurrentGoalActionPointGain", ref ReduceRemoteNpcOfflineCurrentGoalActionPointGain);
        TryGet(modId, "RemoteNpcOfflineCurrentGoalActionPointGainReduction", ref RemoteNpcOfflineCurrentGoalActionPointGainReduction);
        TryGet(modId, "ProtectNeighborStatesFromOfflineActionPointReduction", ref ProtectNeighborStatesFromOfflineActionPointReduction);
        TryGet(modId, "ProtectTaiwuVillageResidentsFromOfflineActionPointReduction", ref ProtectTaiwuVillageResidentsFromOfflineActionPointReduction);
        TryGet(modId, "ProtectSectMembersFromOfflineActionPointReduction", ref ProtectSectMembersFromOfflineActionPointReduction);

        AdvanceMonthOptimizationFrameBudgetMs = Math.Clamp(AdvanceMonthOptimizationFrameBudgetMs, 1, 4);
        MaxPeriAdvanceMonthDeferredJobsPerFrame = Math.Clamp(MaxPeriAdvanceMonthDeferredJobsPerFrame, 1, 16);
        RemoteNpcOfflineCurrentGoalActionPointGainReduction = Math.Clamp(RemoteNpcOfflineCurrentGoalActionPointGainReduction, 0, 20);
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
