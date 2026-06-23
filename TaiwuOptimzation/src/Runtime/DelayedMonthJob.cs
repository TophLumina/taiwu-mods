using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Map;

namespace TaiwuOptimization.Runtime;

internal enum DelayedMonthJobKind
{
    CharacterAreaAction,
    MapBrokenBlockUpdate,
    AnimalAreaData,
    SkeletonGeneration,
    MapPickupCleanup,
}

internal sealed class DelayedMonthJob
{
    public readonly DelayedMonthJobKind Kind;
    public readonly int AreaId;
    public readonly ICharacterParallelAction? CharacterAction;
    public readonly Type? CharacterActionType;
    public readonly IReadOnlyList<Location>? MapPickupLocations;

    private DelayedMonthJob(
        DelayedMonthJobKind kind,
        int areaId,
        ICharacterParallelAction? characterAction,
        IReadOnlyList<Location>? mapPickupLocations = null)
    {
        Kind = kind;
        AreaId = areaId;
        CharacterAction = characterAction;
        CharacterActionType = characterAction?.GetType();
        MapPickupLocations = mapPickupLocations;
    }

    public static DelayedMonthJob CharacterAreaAction(int areaId, ICharacterParallelAction action) =>
        new(DelayedMonthJobKind.CharacterAreaAction, areaId, action);

    public static DelayedMonthJob MapBrokenBlockUpdate(int areaId) =>
        new(DelayedMonthJobKind.MapBrokenBlockUpdate, areaId, null);

    public static DelayedMonthJob AnimalAreaData(int areaId) =>
        new(DelayedMonthJobKind.AnimalAreaData, areaId, null);

    public static DelayedMonthJob SkeletonGeneration(int areaId) =>
        new(DelayedMonthJobKind.SkeletonGeneration, areaId, null);

    public static DelayedMonthJob MapPickupCleanup(int areaId, IReadOnlyList<Location> locations) =>
        new(DelayedMonthJobKind.MapPickupCleanup, areaId, null, locations);

    public bool RequiresParallelApply =>
        Kind is DelayedMonthJobKind.CharacterAreaAction or
            DelayedMonthJobKind.MapBrokenBlockUpdate;

    public void Execute(DataContext context)
    {
        switch (Kind)
        {
            case DelayedMonthJobKind.CharacterAreaAction:
                DelayMonthRuntime.ExecuteOriginalCharacterAreaAction(context, AreaId, CharacterAction!);
                break;
            case DelayedMonthJobKind.MapBrokenBlockUpdate:
                MapDomain.ParallelUpdateBrokenBlockOnMonthChange(context, AreaId);
                break;
            case DelayedMonthJobKind.AnimalAreaData:
                AreaLocalMonthExecutors.ExecuteAnimalAreaData(context, AreaId);
                break;
            case DelayedMonthJobKind.SkeletonGeneration:
                AreaLocalMonthExecutors.ExecuteSkeletonGeneration(context, AreaId);
                break;
            case DelayedMonthJobKind.MapPickupCleanup:
                AreaLocalMonthExecutors.ExecuteMapPickupCleanup(context, AreaId, MapPickupLocations);
                break;
        }
    }

    public bool CanBatchWith(DelayedMonthJob other) =>
        Kind == other.Kind && CharacterActionType == other.CharacterActionType;
}
