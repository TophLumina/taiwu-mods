using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CurrentDistanceEqual)]
public class AiConditionCurrentDistanceEqual : AiConditionCombatBase
{
	private readonly int _target;

	public AiConditionCurrentDistanceEqual(IReadOnlyList<int> ints)
	{
		_target = ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return DomainManager.Combat.GetCurrentDistance() == _target;
	}
}
