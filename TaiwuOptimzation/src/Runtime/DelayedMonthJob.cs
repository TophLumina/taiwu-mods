using System;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Map;

namespace TaiwuOptimization.Runtime;

internal enum DelayedMonthJobKind
{
    CharacterAreaAction,
    BrokenBlockArea,
    MapMonthlyArea,
    RandomEnemiesArea,
    NpcTamingArea,
    AnimalAreaData,
    SkeletonArea,
    MapPickupsArea,
}

internal sealed class DelayedMonthJob
{
    public readonly DelayedMonthJobKind Kind;
    public readonly int AreaId;
    public readonly ICharacterParallelAction? CharacterAction;
    public readonly Type? CharacterActionType;

    private DelayedMonthJob(DelayedMonthJobKind kind, int areaId, ICharacterParallelAction? characterAction)
    {
        Kind = kind;
        AreaId = areaId;
        CharacterAction = characterAction;
        CharacterActionType = characterAction?.GetType();
    }

    public static DelayedMonthJob CharacterArea(int areaId, ICharacterParallelAction action)
    {
        return new DelayedMonthJob(DelayedMonthJobKind.CharacterAreaAction, areaId, action);
    }

    public static DelayedMonthJob BrokenBlockArea(int areaId)
    {
        return new DelayedMonthJob(DelayedMonthJobKind.BrokenBlockArea, areaId, null);
    }

    public static DelayedMonthJob MapMonthlyArea(int areaId)
    {
        return new DelayedMonthJob(DelayedMonthJobKind.MapMonthlyArea, areaId, null);
    }

    public static DelayedMonthJob RandomEnemiesArea(int areaId)
    {
        return new DelayedMonthJob(DelayedMonthJobKind.RandomEnemiesArea, areaId, null);
    }

    public static DelayedMonthJob NpcTamingArea(int areaId)
    {
        return new DelayedMonthJob(DelayedMonthJobKind.NpcTamingArea, areaId, null);
    }

    public static DelayedMonthJob AnimalAreaData(int areaId)
    {
        return new DelayedMonthJob(DelayedMonthJobKind.AnimalAreaData, areaId, null);
    }

    public static DelayedMonthJob SkeletonArea(int areaId)
    {
        return new DelayedMonthJob(DelayedMonthJobKind.SkeletonArea, areaId, null);
    }

    public static DelayedMonthJob MapPickupsArea(int areaId)
    {
        return new DelayedMonthJob(DelayedMonthJobKind.MapPickupsArea, areaId, null);
    }

    public bool RequiresParallelApply
    {
        get
        {
            return Kind == DelayedMonthJobKind.CharacterAreaAction ||
                Kind == DelayedMonthJobKind.BrokenBlockArea ||
                Kind == DelayedMonthJobKind.MapMonthlyArea ||
                Kind == DelayedMonthJobKind.RandomEnemiesArea ||
                Kind == DelayedMonthJobKind.NpcTamingArea;
        }
    }

    public void Execute(DataContext context)
    {
        switch (Kind)
        {
            case DelayedMonthJobKind.CharacterAreaAction:
                DelayMonthRuntime.ExecuteOriginalCharacterAreaAction(context, AreaId, CharacterAction!);
                break;
            case DelayedMonthJobKind.BrokenBlockArea:
                MapDomain.ParallelUpdateBrokenBlockOnMonthChange(context, AreaId);
                break;
            case DelayedMonthJobKind.MapMonthlyArea:
                MapDomain.ParallelUpdateOnMonthChange(context, AreaId);
                break;
            case DelayedMonthJobKind.RandomEnemiesArea:
                DomainManager.Adventure.PreAdvanceMonth_UpdateRandomEnemies(context, AreaId);
                break;
            case DelayedMonthJobKind.NpcTamingArea:
                DomainManager.Extra.PostAdvanceMonth_UpdateNpcTaming(context, AreaId);
                break;
            case DelayedMonthJobKind.AnimalAreaData:
                AreaLocalMonthExecutors.ExecuteAnimalAreaData(context, AreaId);
                break;
            case DelayedMonthJobKind.SkeletonArea:
                AreaLocalMonthExecutors.ExecuteSkeletonGeneration(context, AreaId);
                break;
            case DelayedMonthJobKind.MapPickupsArea:
                AreaLocalMonthExecutors.ExecuteMapPickupsPostAdvanceMonth(context, AreaId);
                break;
        }
    }

    public bool CanBatchWith(DelayedMonthJob other)
    {
        return Kind == other.Kind && CharacterActionType == other.CharacterActionType;
    }
}
