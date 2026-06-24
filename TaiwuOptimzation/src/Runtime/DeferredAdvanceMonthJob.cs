using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Map;

namespace TaiwuOptimization.Runtime;

internal enum DeferredAdvanceMonthJobKind
{
    CharacterParallelActionChunk,
    MapBrokenBlockUpdate,
    AnimalAreaData,
    SkeletonGeneration,
    MapPickupCleanup,
}

internal sealed class DeferredAdvanceMonthJob
{
    public readonly DeferredAdvanceMonthJobKind Kind;
    public readonly int AreaId;
    public readonly ICharacterParallelAction? CharacterParallelAction;
    public readonly Type? CharacterParallelActionType;
    public readonly IReadOnlyList<int>? CharacterIds;
    public readonly int BlockStart;
    public readonly int BlockCount;
    public readonly IReadOnlyList<Location>? MapPickupLocations;

    private DeferredAdvanceMonthJob(
        DeferredAdvanceMonthJobKind kind,
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

    public static DeferredAdvanceMonthJob CharacterParallelActionChunk(
        int areaId,
        ICharacterParallelAction action,
        IReadOnlyList<int> characterIds) =>
        new(DeferredAdvanceMonthJobKind.CharacterParallelActionChunk, areaId, action, characterIds);

    public static DeferredAdvanceMonthJob MapBrokenBlockUpdate(int areaId, int blockStart, int blockCount) =>
        new(DeferredAdvanceMonthJobKind.MapBrokenBlockUpdate, areaId, null, blockStart: blockStart, blockCount: blockCount);

    public static DeferredAdvanceMonthJob AnimalAreaData(int areaId) =>
        new(DeferredAdvanceMonthJobKind.AnimalAreaData, areaId, null);

    public static DeferredAdvanceMonthJob SkeletonGeneration(int areaId, int blockStart, int blockCount) =>
        new(DeferredAdvanceMonthJobKind.SkeletonGeneration, areaId, null, blockStart: blockStart, blockCount: blockCount);

    public static DeferredAdvanceMonthJob MapPickupCleanup(int areaId, IReadOnlyList<Location> locations) =>
        new(DeferredAdvanceMonthJobKind.MapPickupCleanup, areaId, null, mapPickupLocations: locations);

    public bool RequiresParallelApply =>
        Kind is DeferredAdvanceMonthJobKind.CharacterParallelActionChunk or
            DeferredAdvanceMonthJobKind.MapBrokenBlockUpdate;

    public void Execute(DataContext context)
    {
        switch (Kind)
        {
            case DeferredAdvanceMonthJobKind.CharacterParallelActionChunk:
                AreaLocalMonthExecutors.ExecuteCharacterParallelActionChunk(context, CharacterParallelAction!, CharacterIds);
                break;
            case DeferredAdvanceMonthJobKind.MapBrokenBlockUpdate:
                AreaLocalMonthExecutors.ExecuteMapBrokenBlockUpdate(context, AreaId, BlockStart, BlockCount);
                break;
            case DeferredAdvanceMonthJobKind.AnimalAreaData:
                AreaLocalMonthExecutors.ExecuteAnimalAreaData(context, AreaId);
                break;
            case DeferredAdvanceMonthJobKind.SkeletonGeneration:
                AreaLocalMonthExecutors.ExecuteSkeletonGeneration(context, AreaId, BlockStart, BlockCount);
                break;
            case DeferredAdvanceMonthJobKind.MapPickupCleanup:
                AreaLocalMonthExecutors.ExecuteMapPickupCleanup(context, AreaId, MapPickupLocations);
                break;
        }
    }

    public bool CanBatchWith(DeferredAdvanceMonthJob other) =>
        Kind == other.Kind && CharacterParallelActionType == other.CharacterParallelActionType;
}
