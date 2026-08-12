using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.SpecialStatePowerSumMoreOrEqual)]
public class AiConditionSpecialStatePowerSumMoreOrEqual : AiConditionCheckCharStatePowerSumMoreOrEqualBase
{
	protected override sbyte StateType => 0;

	public AiConditionSpecialStatePowerSumMoreOrEqual(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}
}
