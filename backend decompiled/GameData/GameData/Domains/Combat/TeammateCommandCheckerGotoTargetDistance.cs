using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerGotoTargetDistance : TeammateCommandCheckerBase
{
	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (context.CurrChar.GetTargetDistance() < 0)
		{
			yield return ETeammateCommandBanReason.GotoTargetDistanceNoTarget;
		}
	}
}
