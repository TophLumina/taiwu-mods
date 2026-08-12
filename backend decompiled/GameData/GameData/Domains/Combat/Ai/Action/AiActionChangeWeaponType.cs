using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.ChangeWeaponType)]
public class AiActionChangeWeaponType : AiActionCombatBase
{
	private readonly short _itemSubType;

	private bool IsTarget(ItemKey itemKey)
	{
		return ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == _itemSubType;
	}

	public AiActionChangeWeaponType(IReadOnlyList<int> ints)
	{
		_itemSubType = (short)ints[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		int index = combatChar.AiCanChangeToWeapons().First(((ItemKey weaponKey, int index) x) => IsTarget(x.weaponKey)).index;
		DomainManager.Combat.ChangeWeapon(context, index, combatChar.IsAlly);
	}
}
