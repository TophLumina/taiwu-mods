using System.Collections.Generic;
using GameData.Domains.Character;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerPushOrPullIntoDanger : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateBoth => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!context.CurrChar.IsAlly);
		if (enemyChar != null)
		{
			if (DomainManager.Combat.InAttackRange(enemyChar))
			{
				yield return ETeammateCommandBanReason.Negative;
			}
			(byte min, byte max) distanceRange = DomainManager.Combat.GetDistanceRange();
			short distance = DomainManager.Combat.GetCurrentDistance();
			if (distance <= distanceRange.min || distance >= distanceRange.max)
			{
				yield return ETeammateCommandBanReason.Negative;
			}
			OuterAndInnerShorts attackRange = enemyChar.GetAttackRange();
			if (distance - attackRange.Inner > 10)
			{
				yield return ETeammateCommandBanReason.Negative;
			}
			if (attackRange.Outer - distance > 10)
			{
				yield return ETeammateCommandBanReason.Negative;
			}
		}
	}
}
