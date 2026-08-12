using System.Collections.Generic;
using GameData.Domains.Character;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerAbsorbNeiliAllocation : TeammateCommandCheckerBase
{
	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!context.CurrChar.IsAlly);
		NeiliAllocation neiliAllocation = enemyChar.GetNeiliAllocation();
		NeiliAllocation originNeiliAllocation = enemyChar.GetOriginNeiliAllocation();
		for (int i = 0; i < 4; i++)
		{
			if (neiliAllocation[i] > originNeiliAllocation[i])
			{
				yield break;
			}
		}
		yield return ETeammateCommandBanReason.AbsorbNeiliAllocationNoTarget;
	}
}
