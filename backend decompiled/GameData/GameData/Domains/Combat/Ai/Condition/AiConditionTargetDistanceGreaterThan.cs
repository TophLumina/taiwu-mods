using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.TargetDistanceGreaterThan)]
public class AiConditionTargetDistanceGreaterThan : AiConditionCombatBase
{
	private readonly int _targetDistance;

	public AiConditionTargetDistanceGreaterThan(IReadOnlyList<int> ints)
	{
		_targetDistance = ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return combatChar.AiTargetDistance > _targetDistance;
	}
}
