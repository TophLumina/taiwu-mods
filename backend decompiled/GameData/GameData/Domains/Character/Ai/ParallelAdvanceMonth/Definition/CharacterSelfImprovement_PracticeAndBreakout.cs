using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class CharacterSelfImprovement_PracticeAndBreakout : CharacterParallelAction<CharacterSelfImprovement_PracticeAndBreakout>, ICharacterParallelAction
{
	public int BeginAreaId => -1;

	public int EndAreaId => 141;

	public void Execute(DataContext context, Character character)
	{
		context.Equipping.ParallelPracticeAndBreakoutCombatSkills(context, character);
		context.Equipping.ParallelUpdateBreakPlateBonuses(context, character);
	}
}
