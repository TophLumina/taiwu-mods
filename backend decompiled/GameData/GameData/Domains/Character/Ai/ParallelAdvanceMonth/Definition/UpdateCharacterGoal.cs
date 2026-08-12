using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class UpdateCharacterGoal : CharacterParallelAction<UpdateCharacterGoal>, ICharacterParallelAction
{
	public int BeginAreaId => -1;

	public int EndAreaId => 141;

	public void Execute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_UpdateGoals(context);
	}

	public void KidnappedExecute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_UpdateGoals(context);
	}

	public void PrisonerExecute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_UpdateGoals(context);
	}
}
