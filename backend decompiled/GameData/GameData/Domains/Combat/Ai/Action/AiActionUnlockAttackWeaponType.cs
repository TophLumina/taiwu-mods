using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UnlockAttackWeaponType)]
public class AiActionUnlockAttackWeaponType : AiActionCombatBase
{
	private readonly short _weaponSubType;

	public AiActionUnlockAttackWeaponType(IReadOnlyList<int> ints)
	{
		_weaponSubType = (short)ints[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		ItemKey[] weapons = combatChar.GetWeapons();
		List<bool> canUnlockAttack = combatChar.GetCanUnlockAttack();
		for (int i = 0; i < 3; i++)
		{
			if (weapons[i].IsValid() && ItemTemplateHelper.GetItemSubType(weapons[i].ItemType, weapons[i].TemplateId) == _weaponSubType && canUnlockAttack[i])
			{
				DomainManager.Combat.UnlockAttack(context, i, combatChar.IsAlly);
				break;
			}
		}
	}
}
