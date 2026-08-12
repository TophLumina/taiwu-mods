using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerPull : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateBoth => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		(byte min, byte max) distanceRange = DomainManager.Combat.GetDistanceRange();
		if (DomainManager.Combat.GetCurrentDistance() >= distanceRange.max)
		{
			yield return ETeammateCommandBanReason.PullInEdge;
		}
	}
}
