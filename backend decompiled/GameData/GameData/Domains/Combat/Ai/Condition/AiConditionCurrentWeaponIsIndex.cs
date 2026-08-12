using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CurrentWeaponIsIndex)]
public class AiConditionCurrentWeaponIsIndex : AiConditionCheckCharBase
{
	private readonly short _index;

	public AiConditionCurrentWeaponIsIndex(IReadOnlyList<int> ints)
		: base(ints)
	{
		_index = (short)ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		return checkChar.GetUsingWeaponIndex() == _index;
	}
}
