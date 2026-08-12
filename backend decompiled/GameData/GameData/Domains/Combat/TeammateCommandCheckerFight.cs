using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerFight : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateBoth => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		yield break;
	}
}
