using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class UpdatePrimaryGoalAndActions : CharacterParallelAction<UpdatePrimaryGoalAndActions>, ICharacterParallelAction
{
	public int BeginAreaId => -1;

	public int EndAreaId => 141;

	public bool IsEnabled => !DomainManager.TaiwuEvent.GetHideAllMapBlockCharacters();

	public void Execute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_UpdatePrimaryGoalAndActions(context);
	}
}
