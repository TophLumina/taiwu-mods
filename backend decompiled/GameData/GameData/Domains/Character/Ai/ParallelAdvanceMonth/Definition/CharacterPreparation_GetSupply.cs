using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class CharacterPreparation_GetSupply : CharacterParallelAction<CharacterPreparation_GetSupply>, ICharacterParallelAction
{
	public int BeginAreaId => -1;

	public int EndAreaId => 141;

	public void Execute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_ActivePreparation_GetSupply(context);
	}
}
