using System;
using GameData.Domains;

namespace TaiwuOptimization.Runtime;

internal static class TaiwuOptimizationSettings
{
    // 通用配置。
    public static bool AdvanceMonthOptimizationEnabled = true;
    public static bool ProtectNeighborStatesForAdvanceMonthOptimization = true;
    public static int AdvanceMonthOptimizationFrameBudgetMs = 2;
    public static int SaveWorldDatabaseCopyBufferTier = 2;
    public static bool SaveWorldNoCompression = false;

    // 实验性：远区 NPC 月行动点削减。
    public static bool ReduceRemoteNpcOfflineCurrentGoalActionPointGain = false;
    public static int RemoteNpcOfflineCurrentGoalActionPointGainReduction = 10;
    public static bool ProtectTaiwuVillageResidentsFromOfflineActionPointReduction = true;
    public static bool ProtectSectMembersFromOfflineActionPointReduction = false;

    // 过月诊断日志，默认关闭。
    public static bool AdvanceMonthOptimizationDiagnosticsEnabled = false;

    /// <summary>从游戏 mod 设置中读取配置，并限制到有效范围。</summary>
    /// <param name="modId">当前 mod id。</param>
    public static void Load(string modId)
    {
        TryGet(modId, "AdvanceMonthOptimizationEnabled", ref AdvanceMonthOptimizationEnabled);
        TryGet(modId, "ProtectNeighborStatesForAdvanceMonthOptimization", ref ProtectNeighborStatesForAdvanceMonthOptimization);
        TryGet(modId, "AdvanceMonthOptimizationFrameBudgetMs", ref AdvanceMonthOptimizationFrameBudgetMs);
        TryGet(modId, "SaveWorldDatabaseCopyBufferTier", ref SaveWorldDatabaseCopyBufferTier);
        TryGet(modId, "SaveWorldNoCompression", ref SaveWorldNoCompression);
        TryGet(modId, "ReduceRemoteNpcOfflineCurrentGoalActionPointGain", ref ReduceRemoteNpcOfflineCurrentGoalActionPointGain);
        TryGet(modId, "RemoteNpcOfflineCurrentGoalActionPointGainReduction", ref RemoteNpcOfflineCurrentGoalActionPointGainReduction);
        TryGet(modId, "ProtectTaiwuVillageResidentsFromOfflineActionPointReduction", ref ProtectTaiwuVillageResidentsFromOfflineActionPointReduction);
        TryGet(modId, "ProtectSectMembersFromOfflineActionPointReduction", ref ProtectSectMembersFromOfflineActionPointReduction);
        TryGet(modId, "AdvanceMonthOptimizationDiagnosticsEnabled", ref AdvanceMonthOptimizationDiagnosticsEnabled);

        AdvanceMonthOptimizationFrameBudgetMs = Math.Clamp(AdvanceMonthOptimizationFrameBudgetMs, 1, 4);
        SaveWorldDatabaseCopyBufferTier = SaveWorldArchiveOptimization.NormalizeCopyBufferTier(SaveWorldDatabaseCopyBufferTier);
        RemoteNpcOfflineCurrentGoalActionPointGainReduction = Math.Clamp(RemoteNpcOfflineCurrentGoalActionPointGainReduction, 0, 20);
    }

    /// <summary>读取 bool 设置；读取失败时保留默认值。</summary>
    private static void TryGet(string modId, string key, ref bool value)
    {
        try
        {
            DomainManager.Mod.GetSetting(modId, key, ref value);
        }
        catch
        {
            // 设置文件不存在或后端尚未就绪时保留默认值。
        }
    }

    /// <summary>读取 int 设置；读取失败时保留默认值。</summary>
    private static void TryGet(string modId, string key, ref int value)
    {
        try
        {
            DomainManager.Mod.GetSetting(modId, key, ref value);
        }
        catch
        {
            // 设置文件不存在或后端尚未就绪时保留默认值。
        }
    }
}
