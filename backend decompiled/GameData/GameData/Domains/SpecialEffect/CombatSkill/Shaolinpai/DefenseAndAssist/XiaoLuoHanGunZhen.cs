using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.DefenseAndAssist;

public class XiaoLuoHanGunZhen : BuffTeammateCommand
{
	public XiaoLuoHanGunZhen()
	{
	}

	public XiaoLuoHanGunZhen(CombatSkillKey skillKey)
		: base(skillKey, 1605)
	{
		AffectTeammateCommandType = new ETeammateCommandImplement[1] { ETeammateCommandImplement.Defend };
		CommandPowerUpPercent = 50;
	}
}
