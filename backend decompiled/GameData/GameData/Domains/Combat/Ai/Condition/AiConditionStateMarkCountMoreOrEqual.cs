using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.StateMarkCountMoreOrEqual)]
public class AiConditionStateMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	public AiConditionStateMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.StateMarkCount;
	}
}
