using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.TargetDistanceNearby)]
public class AiConditionTargetDistanceNearby : AiConditionCombatBase
{
	private readonly bool _isForward;

	public AiConditionTargetDistanceNearby(IReadOnlyList<int> ints)
	{
		_isForward = ints[0] == 1;
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		short targetDistance = combatChar.GetTargetDistance();
		if (targetDistance < 0)
		{
			return false;
		}
		short currentDistance = DomainManager.Combat.GetCurrentDistance();
		if (currentDistance == targetDistance)
		{
			return false;
		}
		return _isForward == currentDistance > targetDistance;
	}
}
