using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.UnlockAttackValuePercentMoreOrEqual)]
public class AiConditionUnlockAttackValuePercentMoreOrEqual : AiConditionCheckCharExpressionBase
{
	private readonly short _weaponTemplateId;

	public AiConditionUnlockAttackValuePercentMoreOrEqual(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
		_weaponTemplateId = (short)ints[1];
	}

	protected override bool Check(CombatCharacter checkChar, int expressionResult)
	{
		int maxPercent = 0;
		ItemKey[] weapons = checkChar.GetWeapons();
		List<int> unlockPrepareValue = checkChar.GetUnlockPrepareValue();
		for (int i = 0; i < 3; i++)
		{
			if (weapons[i].TemplateId == _weaponTemplateId && unlockPrepareValue.CheckIndex(i))
			{
				maxPercent = Math.Max(maxPercent, CValuePercent.ParseInt(unlockPrepareValue[i], GlobalConfig.Instance.UnlockAttackUnit));
			}
		}
		return maxPercent >= expressionResult;
	}
}
