using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Blade;

public class QiXingDaoFa : StrengthenByWrongWeapon
{
	public QiXingDaoFa()
	{
	}

	public QiXingDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 5304)
	{
		RequireWeaponSubType = 9;
	}
}
