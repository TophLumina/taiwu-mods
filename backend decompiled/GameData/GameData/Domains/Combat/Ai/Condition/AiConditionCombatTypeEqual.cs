using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CombatTypeEqual)]
public class AiConditionCombatTypeEqual : AiConditionCombatBase
{
	private readonly sbyte _combatType;

	public AiConditionCombatTypeEqual(IReadOnlyList<int> ints)
	{
		_combatType = (sbyte)ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return DomainManager.Combat.GetCombatType() == _combatType;
	}
}
