using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetLastPrepareCombatSkill)]
public class AiActionMemorySetLastPrepareCombatSkill : AiActionMemorySetCharValueBase
{
	public AiActionMemorySetLastPrepareCombatSkill(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override int GetCharValue(CombatCharacter checkChar)
	{
		return checkChar.AiController.Environment.LastPrepareSkill;
	}
}
