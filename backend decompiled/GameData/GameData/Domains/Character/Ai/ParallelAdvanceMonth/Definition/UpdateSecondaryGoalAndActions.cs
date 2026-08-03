using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class UpdateSecondaryGoalAndActions : CharacterParallelAction<UpdateSecondaryGoalAndActions>, ICharacterParallelAction
{
	public int BeginAreaId => 0;

	public int EndAreaId => 141;

	public void Execute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_UpdateSecondaryGoalAndActions(context);
	}
}
