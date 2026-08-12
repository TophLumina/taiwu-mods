using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CurrentDistanceBelow)]
public class AiConditionCurrentDistanceBelow : AiConditionCombatBase
{
	private readonly int _target;

	public AiConditionCurrentDistanceBelow(IReadOnlyList<int> ints)
	{
		_target = ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return DomainManager.Combat.GetCurrentDistance() < _target;
	}
}
