using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.DieMarkCountMoreOrEqual)]
public class AiConditionDieMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	public AiConditionDieMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.DieMarkList.Count;
	}
}
