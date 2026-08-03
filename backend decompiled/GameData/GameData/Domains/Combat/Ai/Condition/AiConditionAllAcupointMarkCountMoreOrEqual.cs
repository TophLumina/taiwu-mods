using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AllAcupointMarkCountMoreOrEqual)]
public class AiConditionAllAcupointMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	public AiConditionAllAcupointMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.GetTotalAcupointCount();
	}
}
