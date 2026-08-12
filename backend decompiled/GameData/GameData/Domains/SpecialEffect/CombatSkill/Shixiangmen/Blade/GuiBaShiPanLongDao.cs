using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Blade;

public class GuiBaShiPanLongDao : CastAgainOrPowerUp
{
	public GuiBaShiPanLongDao()
	{
	}

	public GuiBaShiPanLongDao(CombatSkillKey skillKey)
		: base(skillKey, 6207)
	{
		RequireTrickType = 3;
	}
}
