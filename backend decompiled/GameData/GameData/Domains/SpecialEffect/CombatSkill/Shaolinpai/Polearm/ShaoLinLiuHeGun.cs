using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Polearm;

public class ShaoLinLiuHeGun : AddMaxPowerOrUseRequirement
{
	public ShaoLinLiuHeGun()
	{
	}

	public ShaoLinLiuHeGun(CombatSkillKey skillKey)
		: base(skillKey, 1300)
	{
		AffectEquipType = 3;
	}
}
