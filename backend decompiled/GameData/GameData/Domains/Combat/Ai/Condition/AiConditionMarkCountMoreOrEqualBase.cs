using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

public abstract class AiConditionMarkCountMoreOrEqualBase : AiConditionCheckCharBase
{
	protected readonly int MarkCount;

	protected AiConditionMarkCountMoreOrEqualBase(IReadOnlyList<int> ints)
		: base(ints)
	{
		MarkCount = ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		return CalcMarkCount(checkChar.GetDefeatMarkCollection()) >= MarkCount;
	}

	protected abstract int CalcMarkCount(DefeatMarkCollection marks);
}
