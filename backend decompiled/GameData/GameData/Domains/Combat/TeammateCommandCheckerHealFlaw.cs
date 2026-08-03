using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerHealFlaw : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateAfter => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (context.CurrChar.GetFlawCollection().GetTotalCount() <= 0)
		{
			yield return ETeammateCommandBanReason.HealFlawNonFlaw;
		}
	}
}
