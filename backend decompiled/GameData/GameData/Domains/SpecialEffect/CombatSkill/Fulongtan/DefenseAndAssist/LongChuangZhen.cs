using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.DefenseAndAssist;

public class LongChuangZhen : BuffTeammateCommand
{
	public LongChuangZhen()
	{
	}

	public LongChuangZhen(CombatSkillKey skillKey)
		: base(skillKey, 14603)
	{
		AffectTeammateCommandType = new ETeammateCommandImplement[1] { ETeammateCommandImplement.AttackSkill };
		CommandPowerUpPercent = 50;
	}
}
