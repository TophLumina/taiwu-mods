using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AllFlawMarkCountMoreOrEqual)]
public class AiConditionAllFlawMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	public AiConditionAllFlawMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.GetTotalFlawCount();
	}
}
