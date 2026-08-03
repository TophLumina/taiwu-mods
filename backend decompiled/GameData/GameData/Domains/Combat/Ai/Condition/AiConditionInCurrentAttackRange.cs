using System.Collections.Generic;
using GameData.Domains.Character;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.InCurrentAttackRange)]
public class AiConditionInCurrentAttackRange : AiConditionCheckCharBase
{
	private readonly int _offset;

	public AiConditionInCurrentAttackRange(IReadOnlyList<int> ints)
		: base(ints)
	{
		_offset = ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		if (checkChar.GetCanAttackOutRange())
		{
			return true;
		}
		short distance = DomainManager.Combat.GetMoveRangeOffsetCurrentDistance(_offset);
		var (min, max) = (OuterAndInnerShorts)(ref checkChar.GetAttackRange());
		return min <= distance && distance <= max;
	}
}
