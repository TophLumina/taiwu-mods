using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerAttackSkill : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateBefore => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		short skillId = context.TeammateChar.GetAttackCommandSkillId();
		if (skillId < 0)
		{
			yield return ETeammateCommandBanReason.AttackSkillNonSkill;
		}
		else if (!DomainManager.Combat.SkillDirectionCanCast(context.TeammateChar, skillId))
		{
			yield return ETeammateCommandBanReason.AttackSkillBanned;
		}
	}
}
