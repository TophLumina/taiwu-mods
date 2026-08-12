using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerPush : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateBoth => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		(byte min, byte max) distanceRange = DomainManager.Combat.GetDistanceRange();
		if (DomainManager.Combat.GetCurrentDistance() <= distanceRange.min)
		{
			yield return ETeammateCommandBanReason.PushInEdge;
		}
	}
}
