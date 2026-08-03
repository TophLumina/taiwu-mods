using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.DefenseAndAssist;

public class YuanShanQiShaZhen : BuffTeammateCommand
{
	public YuanShanQiShaZhen()
	{
	}

	public YuanShanQiShaZhen(CombatSkillKey skillKey)
		: base(skillKey, 5602)
	{
		AffectTeammateCommandType = new ETeammateCommandImplement[1] { ETeammateCommandImplement.Attack };
		CommandPowerUpPercent = 40;
	}
}
