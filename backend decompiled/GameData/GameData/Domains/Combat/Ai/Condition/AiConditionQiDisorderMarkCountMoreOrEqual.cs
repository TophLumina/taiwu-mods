using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.QiDisorderMarkCountMoreOrEqual)]
public class AiConditionQiDisorderMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	public AiConditionQiDisorderMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.QiDisorderMarkCount;
	}
}
