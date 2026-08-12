using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Agile;

public class WuYouBu : AttackChangeMobility
{
	public WuYouBu()
	{
	}

	public WuYouBu(CombatSkillKey skillKey)
		: base(skillKey, 13402)
	{
		RequireWeaponSubType = 2;
	}
}
