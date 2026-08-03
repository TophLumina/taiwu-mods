using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AcupointMarkCountMoreOrEqual)]
public class AiConditionAcupointMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	private readonly sbyte _bodyPart;

	public AiConditionAcupointMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
		_bodyPart = (sbyte)ints[2];
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.AcupointMarkList[_bodyPart].Count;
	}
}
