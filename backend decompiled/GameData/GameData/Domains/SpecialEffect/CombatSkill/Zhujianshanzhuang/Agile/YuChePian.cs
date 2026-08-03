using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Agile;

public class YuChePian : AttackChangeMobility
{
	public YuChePian()
	{
	}

	public YuChePian(CombatSkillKey skillKey)
		: base(skillKey, 9501)
	{
		RequireWeaponSubType = 12;
	}
}
