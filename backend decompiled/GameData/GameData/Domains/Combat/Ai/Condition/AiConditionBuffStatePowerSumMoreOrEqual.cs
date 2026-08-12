using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.BuffStatePowerSumMoreOrEqual)]
public class AiConditionBuffStatePowerSumMoreOrEqual : AiConditionCheckCharStatePowerSumMoreOrEqualBase
{
	protected override sbyte StateType => 1;

	public AiConditionBuffStatePowerSumMoreOrEqual(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}
}
