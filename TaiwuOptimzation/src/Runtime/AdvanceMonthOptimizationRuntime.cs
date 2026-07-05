using GameData.Common;
using GameData.Domains;

namespace TaiwuOptimization.Runtime;

internal static class AdvanceMonthOptimizationRuntime
{
    private static OfflineUpdateCurrentGoalActionsOptimizationStage _offlineUpdateCurrentGoalActionsStage;

    public static void Initialize() =>
        ResetRuntimeCaches();

    public static void Dispose() =>
        ResetRuntimeCaches();

    /// <summary>过月开始时准备保护快照；NPC 目标索引会在规划前同步冻结。</summary>
    public static void BeginAdvanceMonthOptimizationScope()
    {
        CharacterActionPlanningDiagnostics.BeginAdvanceMonth();
        if (TaiwuOptimizationSettings.RemoteNpcOfflineCurrentGoalActionPointReductionEnabled)
        {
            AdvanceMonthProtectionSnapshotCache.TryFreezeForAdvanceMonth();
        }
    }

    /// <summary>进入原版 `OfflineUpdateCurrentGoalActions` 阶段前冻结只读缓存。</summary>
    public static void BeginOfflineUpdateCurrentGoalActionsOptimizationStage(bool isPrimaryGoalActions)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled)
        {
            return;
        }

        _offlineUpdateCurrentGoalActionsStage = isPrimaryGoalActions
            ? OfflineUpdateCurrentGoalActionsOptimizationStage.PrimaryPlanning
            : OfflineUpdateCurrentGoalActionsOptimizationStage.SecondaryPlanning;
        OfflineUpdateCurrentGoalActionsMatcherCache.BeginOfflineUpdateCurrentGoalActionsStage();
        long targetLookupBuildStartTicks = CharacterActionPlanningDiagnostics.BeginTargetLookupBuild();
        OfflineUpdateCurrentGoalActionsTargetLookupCache.EnsureFrozenBeforeUpdateCurrentGoalActions();
        OfflineUpdateCurrentGoalActionsItemHolderPrefilter.FreezeBeforeUpdateCurrentGoalActions();
        OfflineUpdateCurrentGoalActionsTargetPrefilter.FreezeBeforeAdvanceMonth();
        CharacterActionPlanningDiagnostics.EndTargetLookupBuild(targetLookupBuildStartTicks);
    }

    /// <summary>进入原版串行 `ApplyAll` 前结束 planning 只读阶段，并开始记录写回 delta。</summary>
    public static void EnterOfflineUpdateCurrentGoalActionsApplyAll()
    {
        if (_offlineUpdateCurrentGoalActionsStage == OfflineUpdateCurrentGoalActionsOptimizationStage.PrimaryPlanning)
        {
            EndOfflineUpdateCurrentGoalActionsReadStage();
            OfflineUpdateCurrentGoalActionsTargetLookupCache.BeginSerialApplyAllDeltaRecording(collectDeltas: true);
            OfflineUpdateCurrentGoalActionsItemHolderPrefilter.BeginSerialApplyAllDeltaRecording(collectDeltas: true);
            OfflineUpdateCurrentGoalActionsTargetPrefilter.BeginSerialApplyAllDeltaRecording(collectDeltas: true);
            _offlineUpdateCurrentGoalActionsStage = OfflineUpdateCurrentGoalActionsOptimizationStage.PrimaryApplyAll;
            return;
        }

        if (_offlineUpdateCurrentGoalActionsStage == OfflineUpdateCurrentGoalActionsOptimizationStage.SecondaryPlanning)
        {
            EndOfflineUpdateCurrentGoalActionsReadStage();
            OfflineUpdateCurrentGoalActionsTargetLookupCache.BeginSerialApplyAllDeltaRecording(collectDeltas: false);
            OfflineUpdateCurrentGoalActionsItemHolderPrefilter.BeginSerialApplyAllDeltaRecording(collectDeltas: false);
            OfflineUpdateCurrentGoalActionsTargetPrefilter.BeginSerialApplyAllDeltaRecording(collectDeltas: false);
            _offlineUpdateCurrentGoalActionsStage = OfflineUpdateCurrentGoalActionsOptimizationStage.SecondaryApplyAll;
        }
    }

    public static void FinishOfflineUpdateCurrentGoalActionsOptimizationStage()
    {
        if (_offlineUpdateCurrentGoalActionsStage is
            OfflineUpdateCurrentGoalActionsOptimizationStage.PrimaryPlanning or
            OfflineUpdateCurrentGoalActionsOptimizationStage.SecondaryPlanning)
        {
            EndOfflineUpdateCurrentGoalActionsReadStage();
        }

        if (_offlineUpdateCurrentGoalActionsStage is
            OfflineUpdateCurrentGoalActionsOptimizationStage.PrimaryApplyAll or
            OfflineUpdateCurrentGoalActionsOptimizationStage.SecondaryApplyAll)
        {
            OfflineUpdateCurrentGoalActionsTargetLookupCache.EndSerialApplyAllDeltaRecording();
            OfflineUpdateCurrentGoalActionsItemHolderPrefilter.EndSerialApplyAllDeltaRecording();
            OfflineUpdateCurrentGoalActionsTargetPrefilter.EndSerialApplyAllDeltaRecording();
        }

        _offlineUpdateCurrentGoalActionsStage = OfflineUpdateCurrentGoalActionsOptimizationStage.None;
    }

    public static void EndOfflineUpdateCurrentGoalActionsOptimizationStage() =>
        FinishOfflineUpdateCurrentGoalActionsOptimizationStage();

    private static void EndOfflineUpdateCurrentGoalActionsReadStage()
    {
        OfflineUpdateCurrentGoalActionsTargetLookupCache.EndOfflineUpdateCurrentGoalActionsStage();
        OfflineUpdateCurrentGoalActionsItemHolderPrefilter.EndFrozenReadStage();
        OfflineUpdateCurrentGoalActionsTargetPrefilter.EndFrozenReadStage();
        OfflineUpdateCurrentGoalActionsMatcherCache.EndOfflineUpdateCurrentGoalActionsStage();
    }

    /// <summary>过月结束后释放冻结快照，避免后续帧继续读取旧世界状态。</summary>
    public static void EndAdvanceMonthOptimizationScope()
    {
        EndOfflineUpdateCurrentGoalActionsOptimizationStage();
        AdvanceMonthProtectionSnapshotCache.UnfreezeAfterAdvanceMonth();
        OfflineUpdateCurrentGoalActionsItemHolderPrefilter.Unfreeze();
        OfflineUpdateCurrentGoalActionsTargetPrefilter.UnfreezeAndInvalidate();
        OfflineUpdateCurrentGoalActionsTargetLookupCache.UnfreezeAndInvalidate();
        OfflineUpdateCurrentGoalActionsMatcherCache.EndOfflineUpdateCurrentGoalActionsStage();
        CharacterActionPlanningDiagnostics.EndAdvanceMonth();
    }

    /// <summary>在游玩帧中按预算推进保护快照构建。</summary>
    /// <param name="context">当前后端数据上下文。</param>
    public static void TickAdvanceMonthOptimization(DataContext context)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled ||
            !TaiwuOptimizationSettings.RemoteNpcOfflineCurrentGoalActionPointReductionEnabled ||
            !TaiwuOptimizationSettings.EnableAdvanceMonthOptimizationFrameBudget ||
            !IsWorldDataAvailable() ||
            DomainManager.World.GetAdvancingMonthState() != 0 ||
            DomainManager.Global.GetSavingWorld() ||
            IsCombatActive())
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

    /// <summary>退出世界或切档时丢弃缓存，避免引用旧世界数据。</summary>
    public static void LeaveWorld() =>
        ResetRuntimeCaches();

    private static void ResetRuntimeCaches()
    {
        _offlineUpdateCurrentGoalActionsStage = OfflineUpdateCurrentGoalActionsOptimizationStage.None;
        AdvanceMonthProtectionSnapshotCache.Reset();
        OfflineUpdateCurrentGoalActionsTargetLookupCache.Reset();
        OfflineUpdateCurrentGoalActionsItemHolderPrefilter.Reset();
        OfflineUpdateCurrentGoalActionsTargetPrefilter.UnfreezeAndInvalidate();
        OfflineUpdateCurrentGoalActionsMatcherCache.Reset();
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

    private static bool IsCombatActive()
    {
        try
        {
            return DomainManager.Combat.IsInCombat();
        }
        catch
        {
            return false;
        }
    }

    private enum OfflineUpdateCurrentGoalActionsOptimizationStage
    {
        None,
        PrimaryPlanning,
        PrimaryApplyAll,
        SecondaryPlanning,
        SecondaryApplyAll,
    }
}
