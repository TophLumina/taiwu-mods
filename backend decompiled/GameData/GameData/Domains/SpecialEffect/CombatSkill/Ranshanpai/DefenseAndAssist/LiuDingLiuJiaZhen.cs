using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.DefenseAndAssist;

public class LiuDingLiuJiaZhen : BuffTeammateCommand
{
	public LiuDingLiuJiaZhen()
	{
	}

	public LiuDingLiuJiaZhen(CombatSkillKey skillKey)
		: base(skillKey, 7604)
	{
		AffectTeammateCommandType = new ETeammateCommandImplement[2]
		{
			ETeammateCommandImplement.Fight,
			ETeammateCommandImplement.StopEnemy
		};
		CommandPowerUpPercent = 50;
	}
}
