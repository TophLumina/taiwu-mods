using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.TargetDistanceIsNot)]
public class AiConditionTargetDistanceIsNot : AiConditionCombatBase
{
	private readonly int _targetDistance;

	public AiConditionTargetDistanceIsNot(IReadOnlyList<int> ints)
	{
		_targetDistance = ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return combatChar.AiTargetDistance != _targetDistance;
	}
}
