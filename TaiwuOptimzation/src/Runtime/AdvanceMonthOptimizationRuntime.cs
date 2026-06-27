using GameData.Common;
using GameData.Domains;

namespace TaiwuOptimization.Runtime;

internal static class AdvanceMonthOptimizationRuntime
{
    private static UpdateCurrentGoalActionsOptimizationStage _updateCurrentGoalActionsStage;

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
            AdvanceMonthProtectionSnapshotCache.TryFreezeForAdvanceMonth();
        }
    }

    /// <summary>在原版主/副目标行动阶段前冻结关系候选快照，确保晚于 `CharacterRelationsUpdate`。</summary>
    public static void BeginUpdateCurrentGoalActionsOptimizationStage(bool isPrimaryGoalActions)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled)
        {
            return;
        }

        _updateCurrentGoalActionsStage = isPrimaryGoalActions
            ? UpdateCurrentGoalActionsOptimizationStage.PrimaryPlanning
            : UpdateCurrentGoalActionsOptimizationStage.SecondaryPlanning;
        OfflineCurrentGoalActionMatcherCache.BeginUpdateCurrentGoalActionsStage();
        long targetLookupBuildStartTicks = CharacterActionPlanningDiagnostics.BeginTargetLookupBuild();
        OfflineCurrentGoalActionTargetLookupCache.EnsureFrozenBeforeUpdateCurrentGoalActions();
        OfflineCurrentGoalActionItemHolderPrefilter.FreezeBeforeUpdateCurrentGoalActions();
        OfflineCurrentGoalActionTargetPrefilter.FreezeBeforeAdvanceMonth();
        CharacterActionPlanningDiagnostics.EndTargetLookupBuild(targetLookupBuildStartTicks);
    }

    /// <summary>主/副目标行动阶段结束后释放只服务于该阶段的热路径缓存。</summary>
    public static void EnterUpdateCurrentGoalActionsApplyAll()
    {
        if (_updateCurrentGoalActionsStage == UpdateCurrentGoalActionsOptimizationStage.PrimaryPlanning)
        {
            EndUpdateCurrentGoalActionsReadStage();
            OfflineCurrentGoalActionTargetLookupCache.BeginSerialApplyAllDeltaRecording(collectDeltas: true);
            OfflineCurrentGoalActionItemHolderPrefilter.BeginSerialApplyAllDeltaRecording(collectDeltas: true);
            OfflineCurrentGoalActionTargetPrefilter.BeginSerialApplyAllDeltaRecording(collectDeltas: true);
            _updateCurrentGoalActionsStage = UpdateCurrentGoalActionsOptimizationStage.PrimaryApplyAll;
            return;
        }

        if (_updateCurrentGoalActionsStage == UpdateCurrentGoalActionsOptimizationStage.SecondaryPlanning)
        {
            EndUpdateCurrentGoalActionsReadStage();
            OfflineCurrentGoalActionTargetLookupCache.BeginSerialApplyAllDeltaRecording(collectDeltas: false);
            OfflineCurrentGoalActionItemHolderPrefilter.BeginSerialApplyAllDeltaRecording(collectDeltas: false);
            OfflineCurrentGoalActionTargetPrefilter.BeginSerialApplyAllDeltaRecording(collectDeltas: false);
            _updateCurrentGoalActionsStage = UpdateCurrentGoalActionsOptimizationStage.SecondaryApplyAll;
        }
    }

    public static void FinishUpdateCurrentGoalActionsOptimizationStage()
    {
        if (_updateCurrentGoalActionsStage is
            UpdateCurrentGoalActionsOptimizationStage.PrimaryPlanning or
            UpdateCurrentGoalActionsOptimizationStage.SecondaryPlanning)
        {
            EndUpdateCurrentGoalActionsReadStage();
        }

        if (_updateCurrentGoalActionsStage is
            UpdateCurrentGoalActionsOptimizationStage.PrimaryApplyAll or
            UpdateCurrentGoalActionsOptimizationStage.SecondaryApplyAll)
        {
            OfflineCurrentGoalActionTargetLookupCache.EndSerialApplyAllDeltaRecording();
            OfflineCurrentGoalActionItemHolderPrefilter.EndSerialApplyAllDeltaRecording();
            OfflineCurrentGoalActionTargetPrefilter.EndSerialApplyAllDeltaRecording();
        }

        _updateCurrentGoalActionsStage = UpdateCurrentGoalActionsOptimizationStage.None;
    }

    public static void EndUpdateCurrentGoalActionsOptimizationStage() =>
        FinishUpdateCurrentGoalActionsOptimizationStage();

    private static void EndUpdateCurrentGoalActionsReadStage()
    {
        OfflineCurrentGoalActionTargetLookupCache.EndUpdateCurrentGoalActionsStage();
        OfflineCurrentGoalActionItemHolderPrefilter.EndFrozenReadStage();
        OfflineCurrentGoalActionTargetPrefilter.EndFrozenReadStage();
        OfflineCurrentGoalActionMatcherCache.EndUpdateCurrentGoalActionsStage();
    }

    /// <summary>过月结束后释放冻结快照，后续帧继续构建最新快照。</summary>
    public static void EndAdvanceMonthOptimizationScope()
    {
        EndUpdateCurrentGoalActionsOptimizationStage();
        AdvanceMonthProtectionSnapshotCache.UnfreezeAfterAdvanceMonth();
        OfflineCurrentGoalActionItemHolderPrefilter.Unfreeze();
        OfflineCurrentGoalActionTargetPrefilter.UnfreezeAndInvalidate();
        OfflineCurrentGoalActionTargetLookupCache.UnfreezeAndInvalidate();
        OfflineCurrentGoalActionMatcherCache.EndUpdateCurrentGoalActionsStage();
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
        _updateCurrentGoalActionsStage = UpdateCurrentGoalActionsOptimizationStage.None;
        AdvanceMonthProtectionSnapshotCache.Reset();
        OfflineCurrentGoalActionTargetLookupCache.Reset();
        OfflineCurrentGoalActionItemHolderPrefilter.Reset();
        OfflineCurrentGoalActionTargetPrefilter.UnfreezeAndInvalidate();
        OfflineCurrentGoalActionMatcherCache.Reset();
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

    private enum UpdateCurrentGoalActionsOptimizationStage
    {
        None,
        PrimaryPlanning,
        PrimaryApplyAll,
        SecondaryPlanning,
        SecondaryApplyAll,
    }
}
