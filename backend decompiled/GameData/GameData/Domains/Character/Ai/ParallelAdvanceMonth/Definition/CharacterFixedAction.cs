using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class CharacterFixedAction : CharacterParallelActionWithTarget<CharacterFixedAction>, ICharacterParallelActionWithTarget
{
	public int BeginAreaId => 0;

	public int EndAreaId => 141;

	public bool IsEnabled => !DomainManager.TaiwuEvent.GetHideAllMapBlockCharacters();

	public void Execute(DataContext context, Character character, HashSet<int> targetCharIds)
	{
		character.PeriAdvanceMonth_ExecuteFixedActions(context, targetCharIds);
	}
}
