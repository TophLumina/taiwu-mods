using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Polearm;

public class HuanHouShiLiuQiang : PowerUpByMainAttribute
{
	public HuanHouShiLiuQiang()
	{
	}

	public HuanHouShiLiuQiang(CombatSkillKey skillKey)
		: base(skillKey, 6303)
	{
		RequireMainAttributeType = 3;
	}
}
