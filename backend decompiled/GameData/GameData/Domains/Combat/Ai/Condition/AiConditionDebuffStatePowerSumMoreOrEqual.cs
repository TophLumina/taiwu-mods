using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.DebuffStatePowerSumMoreOrEqual)]
public class AiConditionDebuffStatePowerSumMoreOrEqual : AiConditionCheckCharStatePowerSumMoreOrEqualBase
{
	protected override sbyte StateType => 2;

	public AiConditionDebuffStatePowerSumMoreOrEqual(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}
}
