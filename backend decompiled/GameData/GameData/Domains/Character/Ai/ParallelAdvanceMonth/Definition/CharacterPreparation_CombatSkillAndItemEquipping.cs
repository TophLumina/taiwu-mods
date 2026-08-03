using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class CharacterPreparation_CombatSkillAndItemEquipping : CharacterParallelAction<CharacterPreparation_CombatSkillAndItemEquipping>, ICharacterParallelAction
{
	public int BeginAreaId => -1;

	public int EndAreaId => 141;

	public void Execute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_ActivePreparation_CombatSkillAndItemEquipping(context);
	}

	public void PrisonerExecute(DataContext context, Character character)
	{
		Execute(context, character);
	}
}
