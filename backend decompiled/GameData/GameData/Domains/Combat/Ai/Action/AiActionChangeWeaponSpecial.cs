using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.ChangeWeaponSpecial)]
public class AiActionChangeWeaponSpecial : AiActionCombatBase
{
	private readonly short _weaponTemplateId;

	private bool IsTarget(ItemKey weaponKey)
	{
		return weaponKey.TemplateId == _weaponTemplateId;
	}

	public AiActionChangeWeaponSpecial(IReadOnlyList<int> ints)
	{
		_weaponTemplateId = (short)ints[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		int index = combatChar.AiCanChangeToWeapons().First(((ItemKey weaponKey, int index) x) => IsTarget(x.weaponKey)).index;
		DomainManager.Combat.ChangeWeapon(context, index, combatChar.IsAlly);
	}
}
