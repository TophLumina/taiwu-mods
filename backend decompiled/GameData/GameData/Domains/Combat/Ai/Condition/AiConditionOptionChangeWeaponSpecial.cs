using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionChangeWeaponSpecial)]
public class AiConditionOptionChangeWeaponSpecial : AiConditionCombatBase
{
	private readonly short _weaponTemplateId;

	private bool IsTarget(ItemKey itemKey)
	{
		return itemKey.TemplateId == _weaponTemplateId;
	}

	public AiConditionOptionChangeWeaponSpecial(IReadOnlyList<int> ints)
	{
		_weaponTemplateId = (short)ints[0];
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
