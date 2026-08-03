using System;
using GameData.Domains;

namespace TaiwuOptimization.Runtime;

internal static class TaiwuOptimizationSettings
{
    // 通用配置。
    public static bool AdvanceMonthOptimizationEnabled = true;

    // 过月热路径缓存。
    public static bool EnableCharacterActionPlanningOptimization = true;

    // 存档优化。
    public static bool EnableSaveWorldParallelDeflate = true;
    public static int SaveWorldBlockSizeTier = 3;

    // 可选非等价：远区 NPC 月行动点削减。
    public static bool ReduceRemoteNpcOfflineCurrentGoalActionPointGain = false;
    public static int RemoteNpcOfflineCurrentGoalActionPointGainReduction = 10;
    public static bool ProtectNeighborStatesForAdvanceMonthOptimization = true;
    public static bool EnableAdvanceMonthOptimizationFrameBudget = true;
    public static int AdvanceMonthOptimizationFrameBudgetMs = 2;
    public static bool ProtectTaiwuVillageResidentsFromOfflineActionPointReduction = true;
    public static bool ProtectSectMembersFromOfflineActionPointReduction = false;

    // 过月诊断日志，默认关闭。
    public static bool AdvanceMonthOptimizationDiagnosticsEnabled = false;
    public static bool EnableTaiwuDiagnosticsServer = true;
    public static bool AutoOpenTaiwuDiagnosticsDashboard = false;
    public static int TaiwuDiagnosticsPort = 18580;
    public static bool DiagnosticsLogToGameLog = false;
    public static bool DiagnosticsSaveSnapshotOnSave = true;
    public static int DiagnosticsSnapshotMaxCount = 5;

    public static bool DiagnosticsCollectionEnabled =>
        AdvanceMonthOptimizationDiagnosticsEnabled;

    public static bool RemoteNpcOfflineCurrentGoalActionPointReductionEnabled =>
        AdvanceMonthOptimizationEnabled &&
        ReduceRemoteNpcOfflineCurrentGoalActionPointGain &&
        RemoteNpcOfflineCurrentGoalActionPointGainReduction > 0;

    /// <summary>从游戏 mod 设置中读取配置，并限制到有效范围。</summary>
    /// <param name="modId">当前 mod id。</param>
    public static void Load(string modId)
    {
        TryGet(modId, "AdvanceMonthOptimizationEnabled", ref AdvanceMonthOptimizationEnabled);
        TryGet(modId, "EnableCharacterActionPlanningOptimization", ref EnableCharacterActionPlanningOptimization);
        TryGet(modId, "EnableSaveWorldParallelDeflate", ref EnableSaveWorldParallelDeflate);
        TryGet(modId, "SaveWorldBlockSizeTier", ref SaveWorldBlockSizeTier);
        TryGet(modId, "ReduceRemoteNpcOfflineCurrentGoalActionPointGain", ref ReduceRemoteNpcOfflineCurrentGoalActionPointGain);
        TryGet(modId, "RemoteNpcOfflineCurrentGoalActionPointGainReduction", ref RemoteNpcOfflineCurrentGoalActionPointGainReduction);
        TryGet(modId, "ProtectNeighborStatesForAdvanceMonthOptimization", ref ProtectNeighborStatesForAdvanceMonthOptimization);
        TryGet(modId, "EnableAdvanceMonthOptimizationFrameBudget", ref EnableAdvanceMonthOptimizationFrameBudget);
        TryGet(modId, "AdvanceMonthOptimizationFrameBudgetMs", ref AdvanceMonthOptimizationFrameBudgetMs);
        TryGet(modId, "ProtectTaiwuVillageResidentsFromOfflineActionPointReduction", ref ProtectTaiwuVillageResidentsFromOfflineActionPointReduction);
        TryGet(modId, "ProtectSectMembersFromOfflineActionPointReduction", ref ProtectSectMembersFromOfflineActionPointReduction);
        TryGet(modId, "AdvanceMonthOptimizationDiagnosticsEnabled", ref AdvanceMonthOptimizationDiagnosticsEnabled);
        TryGet(modId, "EnableTaiwuDiagnosticsServer", ref EnableTaiwuDiagnosticsServer);
        TryGet(modId, "AutoOpenTaiwuDiagnosticsDashboard", ref AutoOpenTaiwuDiagnosticsDashboard);
        TryGet(modId, "TaiwuDiagnosticsPort", ref TaiwuDiagnosticsPort);
        TryGet(modId, "DiagnosticsLogToGameLog", ref DiagnosticsLogToGameLog);
        TryGet(modId, "DiagnosticsSaveSnapshotOnSave", ref DiagnosticsSaveSnapshotOnSave);
        TryGet(modId, "DiagnosticsSnapshotMaxCount", ref DiagnosticsSnapshotMaxCount);

        AdvanceMonthOptimizationFrameBudgetMs = Math.Clamp(AdvanceMonthOptimizationFrameBudgetMs, 1, 4);
        SaveWorldBlockSizeTier =
            SaveWorldParallelCompression.NormalizeBlockSizeTier(SaveWorldBlockSizeTier);
        RemoteNpcOfflineCurrentGoalActionPointGainReduction = Math.Clamp(RemoteNpcOfflineCurrentGoalActionPointGainReduction, 0, 20);
        TaiwuDiagnosticsPort = Math.Clamp(TaiwuDiagnosticsPort, 18580, 18595);
        DiagnosticsSnapshotMaxCount = Math.Clamp(DiagnosticsSnapshotMaxCount, 1, 20);
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
