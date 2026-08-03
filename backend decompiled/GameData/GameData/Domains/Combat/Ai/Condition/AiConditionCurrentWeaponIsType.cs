using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CurrentWeaponIsType)]
public class AiConditionCurrentWeaponIsType : AiConditionCheckCharBase
{
	private readonly short _itemSubType;

	public AiConditionCurrentWeaponIsType(IReadOnlyList<int> ints)
		: base(ints)
	{
		_itemSubType = (short)ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		ItemKey weaponKey = checkChar.GetWeapons()[checkChar.GetUsingWeaponIndex()];
		return ItemTemplateHelper.GetItemSubType(weaponKey.ItemType, weaponKey.TemplateId) == _itemSubType;
	}
}
