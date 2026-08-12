using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class CharacterSelfImprovement : CharacterParallelAction<CharacterSelfImprovement>, ICharacterParallelAction
{
	public int BeginAreaId => -1;

	public int EndAreaId => 141;

	public void Execute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_SelfImprovement(context);
	}

	public void TaiwuExecute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_SelfImprovement_Taiwu(context);
	}
}
