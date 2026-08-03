using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerInterruptOtherAction : TeammateCommandCheckerAccelerateCast
{
	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (context.CurrChar.GetPreparingOtherAction() < 0 && !context.CurrChar.GetPreparingItem().IsValid())
		{
			yield return ETeammateCommandBanReason.Negative;
		}
	}
}
