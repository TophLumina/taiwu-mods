using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerDefendSkill : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateBefore => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		short skillId = context.TeammateChar.GetDefendCommandSkillId();
		if (skillId < 0)
		{
			yield return ETeammateCommandBanReason.DefendSkillNonSkill;
		}
		else if (!DomainManager.Combat.SkillDirectionCanCast(context.TeammateChar, skillId))
		{
			yield return ETeammateCommandBanReason.DefendSkillBanned;
		}
	}
}
