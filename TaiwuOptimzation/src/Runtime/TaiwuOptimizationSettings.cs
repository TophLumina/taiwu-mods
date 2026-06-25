using System;
using GameData.Domains;

namespace TaiwuOptimization.Runtime;

internal static class TaiwuOptimizationSettings
{
    // 通用配置。
    public static bool AdvanceMonthOptimizationEnabled = true;
    public static bool ProtectNeighborStatesForAdvanceMonthOptimization = true;
    public static int AdvanceMonthOptimizationFrameBudgetMs = 1;
    public static int MaxPeriAdvanceMonthDeferredJobsPerFrame = 1;

    // 帧时间延迟结算。
    public static bool DeferPeriAdvanceMonthActivePreparationCombatSkillAndItemEquipping = true;
    public static bool DeferPeriAdvanceMonthLoseOverloadItems = true;
    public static bool DeferParallelUpdateBrokenBlockOnMonthChange = true;
    public static bool DeferUpdateAnimalAreaData = true;
    public static bool DeferGenerateSkeletons = true;
    public static bool DeferMapPickupsPostAdvanceMonth = true;

    // 实验性：远区 NPC 月行动点削减。
    public static bool ReduceRemoteNpcOfflineCurrentGoalActionPointGain = false;
    public static int RemoteNpcOfflineCurrentGoalActionPointGainReduction = 10;
    public static bool ProtectTaiwuVillageResidentsFromOfflineActionPointReduction = true;
    public static bool ProtectSectMembersFromOfflineActionPointReduction = false;

    // 运行时诊断日志，默认关闭。
    public static bool AdvanceMonthOptimizationDiagnosticsEnabled = false;
    public static int AdvanceMonthOptimizationDiagnosticsIntervalSeconds = 5;

    /// <summary>从游戏 mod 设置中读取配置，并限制到有效范围。</summary>
    /// <param name="modId">当前 mod id。</param>
    public static void Load(string modId)
    {
        TryGet(modId, "AdvanceMonthOptimizationEnabled", ref AdvanceMonthOptimizationEnabled);
        TryGet(modId, "ProtectNeighborStatesForAdvanceMonthOptimization", ref ProtectNeighborStatesForAdvanceMonthOptimization);
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
        TryGet(modId, "ProtectTaiwuVillageResidentsFromOfflineActionPointReduction", ref ProtectTaiwuVillageResidentsFromOfflineActionPointReduction);
        TryGet(modId, "ProtectSectMembersFromOfflineActionPointReduction", ref ProtectSectMembersFromOfflineActionPointReduction);
        TryGet(modId, "AdvanceMonthOptimizationDiagnosticsEnabled", ref AdvanceMonthOptimizationDiagnosticsEnabled);
        TryGet(modId, "AdvanceMonthOptimizationDiagnosticsIntervalSeconds", ref AdvanceMonthOptimizationDiagnosticsIntervalSeconds);

        AdvanceMonthOptimizationFrameBudgetMs = Math.Clamp(AdvanceMonthOptimizationFrameBudgetMs, 1, 4);
        MaxPeriAdvanceMonthDeferredJobsPerFrame = Math.Clamp(MaxPeriAdvanceMonthDeferredJobsPerFrame, 1, 16);
        RemoteNpcOfflineCurrentGoalActionPointGainReduction = Math.Clamp(RemoteNpcOfflineCurrentGoalActionPointGainReduction, 0, 20);
        AdvanceMonthOptimizationDiagnosticsIntervalSeconds = Math.Clamp(AdvanceMonthOptimizationDiagnosticsIntervalSeconds, 1, 30);
    }

    /// <summary>读取 bool 设置；读取失败时保留默认值。</summary>
    /// <param name="modId">当前 mod id。</param>
    /// <param name="key">设置 key。</param>
    /// <param name="value">设置值引用。</param>
    private static void TryGet(string modId, string key, ref bool value)
    {
        try
        {
            DomainManager.Mod.GetSetting(modId, key, ref value);
        }
        catch
        {
            // 设置文件不存在或后端未就绪时保留默认值。
        }
    }

    /// <summary>读取 int 设置；读取失败时保留默认值。</summary>
    /// <param name="modId">当前 mod id。</param>
    /// <param name="key">设置 key。</param>
    /// <param name="value">设置值引用。</param>
    private static void TryGet(string modId, string key, ref int value)
    {
        try
        {
            DomainManager.Mod.GetSetting(modId, key, ref value);
        }
        catch
        {
            // 设置文件不存在或后端未就绪时保留默认值。
        }
    }
}
