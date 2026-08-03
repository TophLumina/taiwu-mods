using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.DefenseAndAssist;

public class TianNvSanHuaZhen : BuffTeammateCommand
{
	public TianNvSanHuaZhen()
	{
	}

	public TianNvSanHuaZhen(CombatSkillKey skillKey)
		: base(skillKey, 8603)
	{
		AffectTeammateCommandType = new ETeammateCommandImplement[2]
		{
			ETeammateCommandImplement.Push,
			ETeammateCommandImplement.Pull
		};
		CommandPowerUpPercent = 100;
	}
}
