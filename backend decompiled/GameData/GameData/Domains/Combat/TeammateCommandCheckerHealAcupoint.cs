using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerHealAcupoint : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateAfter => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (context.CurrChar.GetAcupointCollection().GetTotalCount() <= 0)
		{
			yield return ETeammateCommandBanReason.HealAcupointNonAcupoint;
		}
	}
}
