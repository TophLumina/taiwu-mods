using System.Collections.Generic;
using GameData.Domains.Character;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.PenetrationResist)]
public class AiConditionPenetrationResist : AiConditionCheckCharBase
{
	private readonly int _targetValue;

	public AiConditionPenetrationResist(IReadOnlyList<int> ints)
		: base(ints)
	{
		_targetValue = ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		OuterAndInnerInts penetrationResists = checkChar.GetCharacter().GetPenetrationResists();
		int value = penetrationResists.Outer * 100 / penetrationResists.Inner;
		return value > _targetValue;
	}
}
