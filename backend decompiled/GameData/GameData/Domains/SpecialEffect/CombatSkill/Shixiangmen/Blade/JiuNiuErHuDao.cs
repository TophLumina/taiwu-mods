using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Blade;

public class JiuNiuErHuDao : PowerUpByMainAttribute
{
	public JiuNiuErHuDao()
	{
	}

	public JiuNiuErHuDao(CombatSkillKey skillKey)
		: base(skillKey, 6203)
	{
		RequireMainAttributeType = 0;
	}
}
