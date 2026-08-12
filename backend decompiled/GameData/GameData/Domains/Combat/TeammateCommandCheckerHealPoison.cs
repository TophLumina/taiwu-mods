using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerHealPoison : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateAfter => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (!context.CurrChar.GetPoison().IsNonZero())
		{
			yield return ETeammateCommandBanReason.HealPoisonNonPoison;
			yield break;
		}
		if (context.TeammateChar.GetHealPoisonCount() <= 0)
		{
			yield return ETeammateCommandBanReason.HealPoisonCountLack;
		}
		if (context.TeammateChar.GetCharacter().GetResource(5) < CombatDomain.GetHealPoisonCostHerb(context.CurrChar.GetPoison()))
		{
			yield return ETeammateCommandBanReason.HealPoisonHerbLack;
		}
		int attainmentLackIndex = 3;
		if (DomainManager.Combat.GetHealPoisonBanReason(context.TeammateChar, context.CurrChar)[attainmentLackIndex])
		{
			yield return ETeammateCommandBanReason.HealPoisonAttainmentLack;
		}
	}
}
