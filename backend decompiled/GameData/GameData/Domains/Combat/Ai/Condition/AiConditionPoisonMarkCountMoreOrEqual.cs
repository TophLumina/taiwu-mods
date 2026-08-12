using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.PoisonMarkCountMoreOrEqual)]
public class AiConditionPoisonMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	private readonly sbyte _poisonType;

	public AiConditionPoisonMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
		_poisonType = (sbyte)ints[2];
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return marks.PoisonMarkList[_poisonType];
	}
}
