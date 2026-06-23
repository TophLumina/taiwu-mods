using GameData.Common;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Map;

namespace TaiwuOptimization.Runtime;

internal enum DelayedMonthJobKind
{
    CharacterAreaAction,
    BrokenBlockArea,
}

internal sealed class DelayedMonthJob
{
    public readonly DelayedMonthJobKind Kind;
    public readonly int AreaId;
    public readonly ICharacterParallelAction? CharacterAction;

    private DelayedMonthJob(DelayedMonthJobKind kind, int areaId, ICharacterParallelAction? characterAction)
    {
        Kind = kind;
        AreaId = areaId;
        CharacterAction = characterAction;
    }

    public static DelayedMonthJob CharacterArea(int areaId, ICharacterParallelAction action)
    {
        return new DelayedMonthJob(DelayedMonthJobKind.CharacterAreaAction, areaId, action);
    }

    public static DelayedMonthJob BrokenBlockArea(int areaId)
    {
        return new DelayedMonthJob(DelayedMonthJobKind.BrokenBlockArea, areaId, null);
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
        }
    }
}
