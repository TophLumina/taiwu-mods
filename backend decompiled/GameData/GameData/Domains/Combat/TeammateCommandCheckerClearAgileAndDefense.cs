using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerClearAgileAndDefense : TeammateCommandCheckerBase
{
	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (context.CurrChar.GetAffectingMoveSkillId() < 0 && context.CurrChar.GetAffectingDefendSkillId() < 0)
		{
			yield return ETeammateCommandBanReason.Negative;
		}
	}
}
