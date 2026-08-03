using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Special;

public class JinDingXianZhen : CastAgainOrPowerUp
{
	public JinDingXianZhen()
	{
	}

	public JinDingXianZhen(CombatSkillKey skillKey)
		: base(skillKey, 2407)
	{
		RequireTrickType = 4;
	}
}
