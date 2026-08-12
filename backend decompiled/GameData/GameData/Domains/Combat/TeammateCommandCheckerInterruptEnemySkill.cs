using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerInterruptEnemySkill : TeammateCommandCheckerBase
{
	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!context.CurrChar.IsAlly);
		if (enemyChar.GetPreparingSkillId() < 0 || enemyChar.GetSkillPreparePercent() >= 100)
		{
			yield return ETeammateCommandBanReason.EnemyNotInPreparing;
		}
	}
}
