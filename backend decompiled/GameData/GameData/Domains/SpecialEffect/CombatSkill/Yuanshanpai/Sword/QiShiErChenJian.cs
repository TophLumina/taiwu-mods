using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Sword;

public class QiShiErChenJian : StrengthenOnSwitchWeapon
{
	public QiShiErChenJian()
	{
	}

	public QiShiErChenJian(CombatSkillKey skillKey)
		: base(skillKey, 5202)
	{
		RequireWeaponSubType = 8;
	}
}
