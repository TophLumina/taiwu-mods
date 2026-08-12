using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Finger;

public class ShaoLinFuHuZhua : ChangePowerByEquipType
{
	protected override sbyte ChangePowerUnitReverse => 3;

	public ShaoLinFuHuZhua()
	{
	}

	public ShaoLinFuHuZhua(CombatSkillKey skillKey)
		: base(skillKey, 1200)
	{
		AffectEquipType = 3;
	}
}
