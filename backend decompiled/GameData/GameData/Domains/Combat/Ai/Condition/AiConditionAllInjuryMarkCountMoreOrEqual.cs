using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AllInjuryMarkCountMoreOrEqual)]
public class AiConditionAllInjuryMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	public AiConditionAllInjuryMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.GetTotalInjuryCount();
	}
}
