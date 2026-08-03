using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.DefenseAndAssist;

public class SiXiangLianHuaZhen : BuffTeammateCommand
{
	public SiXiangLianHuaZhen()
	{
	}

	public SiXiangLianHuaZhen(CombatSkillKey skillKey)
		: base(skillKey, 2705)
	{
		AffectTeammateCommandType = new ETeammateCommandImplement[2]
		{
			ETeammateCommandImplement.HealInjury,
			ETeammateCommandImplement.HealPoison
		};
		CommandPowerUpPercent = 50;
	}
}
