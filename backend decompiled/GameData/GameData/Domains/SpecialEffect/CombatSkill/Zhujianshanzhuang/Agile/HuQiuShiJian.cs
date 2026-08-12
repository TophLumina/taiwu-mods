using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Agile;

public class HuQiuShiJian : AttackChangeMobility
{
	public HuQiuShiJian()
	{
	}

	public HuQiuShiJian(CombatSkillKey skillKey)
		: base(skillKey, 9503)
	{
		RequireWeaponSubType = 8;
	}
}
