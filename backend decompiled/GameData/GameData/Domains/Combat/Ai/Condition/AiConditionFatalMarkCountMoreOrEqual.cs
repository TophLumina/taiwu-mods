using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.FatalMarkCountMoreOrEqual)]
public class AiConditionFatalMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	public AiConditionFatalMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.FatalDamageMarkCount;
	}
}
