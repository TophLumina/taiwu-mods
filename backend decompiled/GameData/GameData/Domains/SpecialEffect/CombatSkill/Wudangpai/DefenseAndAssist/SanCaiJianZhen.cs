using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.DefenseAndAssist;

public class SanCaiJianZhen : BuffTeammateCommand
{
	public SanCaiJianZhen()
	{
	}

	public SanCaiJianZhen(CombatSkillKey skillKey)
		: base(skillKey, 4601)
	{
		AffectTeammateCommandType = new ETeammateCommandImplement[2]
		{
			ETeammateCommandImplement.HealFlaw,
			ETeammateCommandImplement.HealAcupoint
		};
		CommandPowerUpPercent = 100;
	}
}
