using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.DefenseAndAssist;

public class NanDouLiuXingZhen : BuffTeammateCommand
{
	public NanDouLiuXingZhen()
	{
	}

	public NanDouLiuXingZhen(CombatSkillKey skillKey)
		: base(skillKey, 13604)
	{
		AffectTeammateCommandType = new ETeammateCommandImplement[1] { ETeammateCommandImplement.AccelerateCast };
		CommandPowerUpPercent = 50;
	}
}
