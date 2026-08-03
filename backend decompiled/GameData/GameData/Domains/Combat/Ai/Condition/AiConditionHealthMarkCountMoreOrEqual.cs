using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.HealthMarkCountMoreOrEqual)]
public class AiConditionHealthMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	public AiConditionHealthMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.HealthMarkCount;
	}
}
