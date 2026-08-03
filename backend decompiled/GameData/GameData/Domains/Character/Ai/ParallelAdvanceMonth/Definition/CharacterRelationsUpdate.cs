using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class CharacterRelationsUpdate : CharacterParallelActionWithTarget<CharacterRelationsUpdate>, ICharacterParallelActionWithTarget
{
	public int BeginAreaId => 0;

	public int EndAreaId => 141;

	public void Execute(DataContext context, Character character, HashSet<int> targetCharIds)
	{
		character.PeriAdvanceMonth_RelationsUpdate(context, targetCharIds);
	}
}
