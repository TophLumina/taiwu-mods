using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.FistAndPalm;

public class JinGangZhuMieShou : CastAgainOrPowerUp
{
	public JinGangZhuMieShou()
	{
	}

	public JinGangZhuMieShou(CombatSkillKey skillKey)
		: base(skillKey, 11105)
	{
		RequireTrickType = 6;
	}
}
