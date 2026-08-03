using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.MindMarkCountMoreOrEqual)]
public class AiConditionMindMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	public AiConditionMindMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.MindMarkList.Count;
	}
}
