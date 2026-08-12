using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.DefenseAndAssist;

public class ShenJiZhen : BuffTeammateCommand
{
	public ShenJiZhen()
	{
	}

	public ShenJiZhen(CombatSkillKey skillKey)
		: base(skillKey, 9703)
	{
		AffectTeammateCommandType = new ETeammateCommandImplement[2]
		{
			ETeammateCommandImplement.AddHit,
			ETeammateCommandImplement.AddAvoid
		};
		CommandPowerUpPercent = 50;
	}
}
