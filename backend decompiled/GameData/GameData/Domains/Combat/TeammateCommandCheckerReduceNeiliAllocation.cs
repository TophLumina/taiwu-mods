using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerReduceNeiliAllocation : TeammateCommandCheckerBase
{
	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (context.CurrChar.GetNeiliAllocation().GetTotal() <= 0)
		{
			yield return ETeammateCommandBanReason.Negative;
		}
	}
}
