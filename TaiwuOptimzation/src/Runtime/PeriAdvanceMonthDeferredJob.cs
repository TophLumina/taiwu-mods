using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Map;

namespace TaiwuOptimization.Runtime;

internal enum PeriAdvanceMonthDeferredJobKind
{
    CharacterParallelActionChunk,
    MapBrokenBlockUpdate,
    AnimalAreaData,
    SkeletonGeneration,
    MapPickupCleanup,
}

internal sealed class PeriAdvanceMonthDeferredJob
{
    public readonly PeriAdvanceMonthDeferredJobKind Kind;
    public readonly int AreaId;
    public readonly ICharacterParallelAction? CharacterParallelAction;
    public readonly Type? CharacterParallelActionType;
    public readonly IReadOnlyList<int>? CharacterIds;
    public readonly int BlockStart;
    public readonly int BlockCount;
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

    public bool RequiresParallelApply =>
        Kind is PeriAdvanceMonthDeferredJobKind.CharacterParallelActionChunk or
            PeriAdvanceMonthDeferredJobKind.MapBrokenBlockUpdate;

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

    public bool CanBatchWith(PeriAdvanceMonthDeferredJob other) =>
        Kind == other.Kind && CharacterParallelActionType == other.CharacterParallelActionType;
}
