using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerTransferNeiliAllocation : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateAfter => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (context.TeammateChar.GetNeiliAllocation().GetTotal() <= 0)
		{
			yield return ETeammateCommandBanReason.TransferNeiliAllocationLack;
		}
	}
}
