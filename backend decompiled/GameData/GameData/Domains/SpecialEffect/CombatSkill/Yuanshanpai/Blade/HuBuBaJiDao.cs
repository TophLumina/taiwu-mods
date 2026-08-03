using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Blade;

public class HuBuBaJiDao : StrengthenOnSwitchWeapon
{
	public HuBuBaJiDao()
	{
	}

	public HuBuBaJiDao(CombatSkillKey skillKey)
		: base(skillKey, 5302)
	{
		RequireWeaponSubType = 9;
	}
}
