using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUnlockAttackWeaponType)]
public class AiConditionOptionUnlockAttackWeaponType : AiConditionCombatBase
{
	private readonly short _weaponSubType;

	public AiConditionOptionUnlockAttackWeaponType(IReadOnlyList<int> ints)
	{
		_weaponSubType = (short)ints[0];
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
			if (weapons[i].IsValid() && ItemTemplateHelper.GetItemSubType(weapons[i].ItemType, weapons[i].TemplateId) == _weaponSubType && canUnlockAttack[i])
			{
				return true;
			}
		}
		return false;
	}
}
