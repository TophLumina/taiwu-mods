using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerAttack : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateBefore => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (context.TeammateChar.GetAttackCommandTrickType() < 0)
		{
			yield return ETeammateCommandBanReason.AttackNonTrick;
		}
	}
}
