using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionChangeWeaponType)]
public class AiConditionOptionChangeWeaponType : AiConditionCombatBase
{
	private readonly short _itemSubType;

	private bool IsTarget(ItemKey itemKey)
	{
		return ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == _itemSubType;
	}

	public AiConditionOptionChangeWeaponType(IReadOnlyList<int> ints)
	{
		_itemSubType = (short)ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoAttack))
		{
			return false;
		}
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoChangeWeapon))
		{
			return false;
		}
		return (from x in combatChar.AiCanChangeToWeapons()
			select x.weaponKey).Where(IsTarget).Any();
	}
}
