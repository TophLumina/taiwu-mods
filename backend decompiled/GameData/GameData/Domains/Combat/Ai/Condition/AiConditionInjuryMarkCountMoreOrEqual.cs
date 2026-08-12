using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.InjuryMarkCountMoreOrEqual)]
public class AiConditionInjuryMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	private readonly sbyte _bodyPart;

	private readonly bool _isInner;

	public AiConditionInjuryMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
		_bodyPart = (sbyte)ints[2];
		_isInner = ints[3] == 1;
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return (_isInner ? marks.InnerInjuryMarkList : marks.OuterInjuryMarkList)[_bodyPart];
	}
}
