using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OuterOrInnerInjuryMarkCountMoreOrEqual)]
public class AiConditionOuterOrInnerInjuryMarkCountMoreOrEqual : AiConditionMarkCountMoreOrEqualBase
{
	private readonly bool _isInner;

	public AiConditionOuterOrInnerInjuryMarkCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
		_isInner = ints[0] == 1;
	}

	protected override int CalcMarkCount(DefeatMarkCollection marks)
	{
		return (_isInner ? marks.InnerInjuryMarkList : marks.OuterInjuryMarkList).Sum();
	}
}
