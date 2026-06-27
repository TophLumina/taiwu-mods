using GameData.Common;
using GameData.Domains;

namespace TaiwuOptimization.Runtime;

internal static class AdvanceMonthOptimizationRuntime
{
    public static void Initialize() =>
        ResetRuntimeCaches();

    public static void Dispose() =>
        ResetRuntimeCaches();

    /// <summary>过月开始时准备并冻结快照；目标索引会在 NPC 规划前同步全量刷新。</summary>
    public static void BeginAdvanceMonthOptimizationScope()
    {
        CharacterActionPlanningDiagnostics.BeginAdvanceMonth();
        if (TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled)
        {
            long targetLookupBuildStartTicks = CharacterActionPlanningDiagnostics.BeginTargetLookupBuild();
            CharacterActionTargetLookupCache.RebuildAndFreezeBeforeAdvanceMonth();
            CharacterActionPlanningDiagnostics.EndTargetLookupBuild(targetLookupBuildStartTicks);
            AdvanceMonthProtectionSnapshotCache.TryFreezeForAdvanceMonth();
        }
    }

    /// <summary>在原版主/副目标行动阶段前冻结关系候选快照，确保晚于 `CharacterRelationsUpdate`。</summary>
    public static void BeginUpdateCurrentGoalActionsOptimizationStage()
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled)
        {
            return;
        }

        CharacterActionTargetMatcherStageCache.BeginUpdateCurrentGoalActionsStage();
        long targetLookupBuildStartTicks = CharacterActionPlanningDiagnostics.BeginTargetLookupBuild();
        CharacterInventoryTargetPrefilter.FreezeBeforeUpdateCurrentGoalActions();
        CharacterGoalTargetConditionPrefilter.FreezeBeforeAdvanceMonth();
        CharacterActionPlanningDiagnostics.EndTargetLookupBuild(targetLookupBuildStartTicks);
    }

    /// <summary>主/副目标行动阶段结束后释放只服务于该阶段的热路径缓存。</summary>
    public static void EndUpdateCurrentGoalActionsOptimizationStage()
    {
        CharacterInventoryTargetPrefilter.Unfreeze();
        CharacterActionTargetMatcherStageCache.EndUpdateCurrentGoalActionsStage();
    }

    /// <summary>过月结束后释放冻结快照，后续帧继续构建最新快照。</summary>
    public static void EndAdvanceMonthOptimizationScope()
    {
        AdvanceMonthProtectionSnapshotCache.UnfreezeAfterAdvanceMonth();
        CharacterInventoryTargetPrefilter.Unfreeze();
        CharacterGoalTargetConditionPrefilter.UnfreezeAndInvalidate();
        CharacterActionTargetLookupCache.UnfreezeAndInvalidate();
        CharacterActionTargetMatcherStageCache.EndUpdateCurrentGoalActionsStage();
        CharacterActionPlanningDiagnostics.EndAdvanceMonth();
    }

    /// <summary>在游玩帧中按预算推进保护快照构建。</summary>
    /// <param name="context">当前后端数据上下文。</param>
    public static void TickAdvanceMonthOptimization(DataContext context)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled ||
            !IsWorldDataAvailable() ||
            DomainManager.World.GetAdvancingMonthState() != 0 ||
            DomainManager.Global.GetSavingWorld())
        {
            return;
        }

        if (!AdvanceMonthProtectionSnapshotCache.NeedsFrameBuild())
        {
            return;
        }

        AdvanceMonthOptimizationFrameBudget frameBudget = AdvanceMonthOptimizationFrameBudget.Start();
        AdvanceMonthProtectionSnapshotCache.TickBuildProtectionSnapshot(in frameBudget);
    }

    /// <summary>退出世界/切档时丢弃缓存，避免引用旧世界数据。</summary>
    public static void LeaveWorld() =>
        ResetRuntimeCaches();

    private static void ResetRuntimeCaches()
    {
        AdvanceMonthProtectionSnapshotCache.Reset();
        CharacterActionTargetLookupCache.Reset();
        CharacterInventoryTargetPrefilter.Reset();
        CharacterGoalTargetConditionPrefilter.UnfreezeAndInvalidate();
        CharacterActionTargetMatcherStageCache.Reset();
    }

    private static bool IsWorldDataAvailable()
    {
        try
        {
            return DomainManager.Taiwu.GetTaiwu() != null;
        }
        catch
        {
            return false;
        }
    }
}
