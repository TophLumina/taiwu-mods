using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AnyAttackRangeEdge)]
public class AiConditionAnyAttackRangeEdge : AiConditionCombatBase
{
	private readonly bool _isAlly;

	public AiConditionAnyAttackRangeEdge(IReadOnlyList<int> ints)
	{
		_isAlly = ints[0] == 1;
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		CombatCharacter checkChar = DomainManager.Combat.GetCombatCharacter(_isAlly == combatChar.IsAlly);
		return DomainManager.Combat.AnyAttackRangeEdge(checkChar);
	}
}
