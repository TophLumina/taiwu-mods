using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CurrentWeaponIsSpecial)]
public class AiConditionCurrentWeaponIsSpecial : AiConditionCheckCharBase
{
	private readonly short _templateId;

	public AiConditionCurrentWeaponIsSpecial(IReadOnlyList<int> ints)
		: base(ints)
	{
		_templateId = (short)ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		ItemKey weaponKey = checkChar.GetWeapons()[checkChar.GetUsingWeaponIndex()];
		return weaponKey.TemplateId == _templateId;
	}
}
