using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Map;

namespace TaiwuOptimization.Runtime;

internal enum PeriAdvanceMonthDeferredJobKind
{
    // NPC 月结行动前的并行任务块。
    CharacterParallelActionChunk,

    // 破损地块倒计时更新任务块。
    MapBrokenBlockUpdate,

    // 野生动物生态 area 更新。
    AnimalAreaData,

    // 坟墓骷髅生成任务块。
    SkeletonGeneration,

    // 地图拾取物状态清理任务块。
    MapPickupCleanup,
}

internal sealed class PeriAdvanceMonthDeferredJob
{
    // 延迟任务类型，用于执行分派和诊断统计。
    public readonly PeriAdvanceMonthDeferredJobKind Kind;

    // 任务所属 area，用于当前/相邻区域强制同步。
    public readonly int AreaId;

    // 原版 ICharacterParallelAction 实例，仅 NPC 并行任务使用。
    public readonly ICharacterParallelAction? CharacterParallelAction;

    // 缓存 action 类型，便于判断哪些 job 可以合批 ApplyAll。
    public readonly Type? CharacterParallelActionType;

    // 本 job 处理的角色快照。
    public readonly IReadOnlyList<int>? CharacterIds;

    // 本 job 处理的 block 起点和数量。
    public readonly int BlockStart;
    public readonly int BlockCount;

    // 本 job 处理的拾取物位置快照。
    public readonly IReadOnlyList<Location>? MapPickupLocations;

    private PeriAdvanceMonthDeferredJob(
        PeriAdvanceMonthDeferredJobKind kind,
        int areaId,
        ICharacterParallelAction? characterParallelAction,
        IReadOnlyList<int>? characterIds = null,
        int blockStart = 0,
        int blockCount = 0,
        IReadOnlyList<Location>? mapPickupLocations = null)
    {
        Kind = kind;
        AreaId = areaId;
        CharacterParallelAction = characterParallelAction;
        CharacterParallelActionType = characterParallelAction?.GetType();
        CharacterIds = characterIds;
        BlockStart = blockStart;
        BlockCount = blockCount;
        MapPickupLocations = mapPickupLocations;
    }

    public static PeriAdvanceMonthDeferredJob CharacterParallelActionChunk(
        int areaId,
        ICharacterParallelAction action,
        IReadOnlyList<int> characterIds) =>
        new(PeriAdvanceMonthDeferredJobKind.CharacterParallelActionChunk, areaId, action, characterIds);

    public static PeriAdvanceMonthDeferredJob MapBrokenBlockUpdate(int areaId, int blockStart, int blockCount) =>
        new(PeriAdvanceMonthDeferredJobKind.MapBrokenBlockUpdate, areaId, null, blockStart: blockStart, blockCount: blockCount);

    public static PeriAdvanceMonthDeferredJob AnimalAreaData(int areaId) =>
        new(PeriAdvanceMonthDeferredJobKind.AnimalAreaData, areaId, null);

    public static PeriAdvanceMonthDeferredJob SkeletonGeneration(int areaId, int blockStart, int blockCount) =>
        new(PeriAdvanceMonthDeferredJobKind.SkeletonGeneration, areaId, null, blockStart: blockStart, blockCount: blockCount);

    public static PeriAdvanceMonthDeferredJob MapPickupCleanup(int areaId, IReadOnlyList<Location> locations) =>
        new(PeriAdvanceMonthDeferredJobKind.MapPickupCleanup, areaId, null, mapPickupLocations: locations);

    // 这些任务写入 ParallelModificationsRecorder，需要在合适的边界调用 ApplyAll。
    public bool RequiresParallelApply =>
        Kind is PeriAdvanceMonthDeferredJobKind.CharacterParallelActionChunk or
            PeriAdvanceMonthDeferredJobKind.MapBrokenBlockUpdate;

    /// <summary>回放一个延迟月结任务。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    public void Execute(DataContext context)
    {
        switch (Kind)
        {
            case PeriAdvanceMonthDeferredJobKind.CharacterParallelActionChunk:
                AreaLocalPeriAdvanceMonthExecutor.ExecuteCharacterParallelActionChunk(context, CharacterParallelAction!, CharacterIds);
                break;
            case PeriAdvanceMonthDeferredJobKind.MapBrokenBlockUpdate:
                AreaLocalPeriAdvanceMonthExecutor.ExecuteMapBrokenBlockUpdate(context, AreaId, BlockStart, BlockCount);
                break;
            case PeriAdvanceMonthDeferredJobKind.AnimalAreaData:
                AreaLocalPeriAdvanceMonthExecutor.ExecuteAnimalAreaData(context, AreaId);
                break;
            case PeriAdvanceMonthDeferredJobKind.SkeletonGeneration:
                AreaLocalPeriAdvanceMonthExecutor.ExecuteSkeletonGeneration(context, AreaId, BlockStart, BlockCount);
                break;
            case PeriAdvanceMonthDeferredJobKind.MapPickupCleanup:
                AreaLocalPeriAdvanceMonthExecutor.ExecuteMapPickupCleanup(context, AreaId, MapPickupLocations);
                break;
        }
    }

    /// <summary>判断两个 job 是否可以共享一次 ApplyAll。</summary>
    /// <param name="other">待比较的另一个 job。</param>
    public bool CanBatchWith(PeriAdvanceMonthDeferredJob other) =>
        Kind == other.Kind && CharacterParallelActionType == other.CharacterParallelActionType;
}
