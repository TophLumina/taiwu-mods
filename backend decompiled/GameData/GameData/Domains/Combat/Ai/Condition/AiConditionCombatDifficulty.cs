using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CombatDifficulty)]
public class AiConditionCombatDifficulty : AiConditionCombatBase
{
	private readonly byte _combatDifficulty;

	public AiConditionCombatDifficulty(IReadOnlyList<int> ints)
	{
		_combatDifficulty = (byte)ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return combatChar.IsAlly || DomainManager.World.GetCombatDifficulty() >= _combatDifficulty;
	}
}
