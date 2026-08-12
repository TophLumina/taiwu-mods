using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Sword;

public class WenShuDaZhiHuiJian : StrengthenByWrongWeapon
{
	public WenShuDaZhiHuiJian()
	{
	}

	public WenShuDaZhiHuiJian(CombatSkillKey skillKey)
		: base(skillKey, 5204)
	{
		RequireWeaponSubType = 8;
	}
}
