using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionChangeWeapon)]
public class AiConditionOptionChangeWeapon : AiConditionCombatBase
{
	private readonly int _minIndex;

	private readonly int _maxIndex;

	public AiConditionOptionChangeWeapon(IReadOnlyList<int> ints)
	{
		_minIndex = ints[0];
		_maxIndex = ints[1];
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
		if (DomainManager.Combat.InAttackRange(combatChar))
		{
			return false;
		}
		return combatChar.AiGetFirstChangeableWeaponIndex(_minIndex, _maxIndex) >= 0;
	}
}
