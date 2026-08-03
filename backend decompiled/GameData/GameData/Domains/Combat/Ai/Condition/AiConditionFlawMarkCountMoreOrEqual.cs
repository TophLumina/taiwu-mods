using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.FlawMarkCountMoreOrEqual)]
public class AiConditionFlawMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	private readonly sbyte _bodyPart;

	public AiConditionFlawMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
		_bodyPart = (sbyte)ints[2];
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.FlawMarkList[_bodyPart].Count;
	}
}
