using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UnlockAttackWeapon)]
public class AiActionUnlockAttackWeapon : AiActionCombatBase
{
	private readonly short _weaponTemplateId;

	public AiActionUnlockAttackWeapon(IReadOnlyList<int> ints)
	{
		_weaponTemplateId = (short)ints[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		ItemKey[] weapons = combatChar.GetWeapons();
		List<bool> canUnlockAttack = combatChar.GetCanUnlockAttack();
		for (int i = 0; i < 3; i++)
		{
			if (weapons[i].TemplateId == _weaponTemplateId && canUnlockAttack[i])
			{
				DomainManager.Combat.UnlockAttack(context, i, combatChar.IsAlly);
				break;
			}
		}
	}
}
