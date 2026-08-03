using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerAddUnlockAttackValue : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateAfter => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		bool anyCanAddUnlockValue = false;
		ItemKey[] weapons = context.CurrChar.GetWeapons();
		List<int> unlockValues = context.CurrChar.GetUnlockPrepareValue();
		for (int i = 0; i < weapons.Length; i++)
		{
			if (context.CurrChar.CanUnlockAttackByConfig(i) && unlockValues[i] < GlobalConfig.Instance.UnlockAttackUnit)
			{
				anyCanAddUnlockValue = true;
			}
		}
		if (!anyCanAddUnlockValue)
		{
			yield return ETeammateCommandBanReason.AddUnlockAttackValueFull;
		}
	}
}
