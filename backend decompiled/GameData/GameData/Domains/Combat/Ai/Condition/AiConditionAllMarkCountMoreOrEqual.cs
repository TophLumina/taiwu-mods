using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AllMarkCountMoreOrEqual)]
public class AiConditionAllMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	public AiConditionAllMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.GetTotalCount();
	}
}
