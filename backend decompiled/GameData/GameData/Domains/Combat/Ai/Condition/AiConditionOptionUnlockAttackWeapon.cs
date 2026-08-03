using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUnlockAttackWeapon)]
public class AiConditionOptionUnlockAttackWeapon : AiConditionCombatBase
{
	private readonly short _weaponTemplateId;

	public AiConditionOptionUnlockAttackWeapon(IReadOnlyList<int> ints)
	{
		_weaponTemplateId = (short)ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoUnlock))
		{
			return false;
		}
		ItemKey[] weapons = combatChar.GetWeapons();
		List<bool> canUnlockAttack = combatChar.GetCanUnlockAttack();
		for (int i = 0; i < 3; i++)
		{
			if (weapons[i].TemplateId == _weaponTemplateId && canUnlockAttack[i])
			{
				return true;
			}
		}
		return false;
	}
}
