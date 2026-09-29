using System.Collections.Generic;
using GameData.Combat.Chicken;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerAddChickenPoint : TeammateCommandCheckerBase
{
	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		ChickenPointZones zones = DomainManager.Combat.GetChickenPointZones();
		if (zones.NoDrawable)
		{
			yield return ETeammateCommandBanReason.AddChickenPointNotAllowed;
		}
	}
}
