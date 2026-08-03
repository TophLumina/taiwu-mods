using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Blade;

public class FuLongDaoFa : ChangePowerByEquipType
{
	protected override sbyte ChangePowerUnitReverse => 3;

	public FuLongDaoFa()
	{
	}

	public FuLongDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 14200)
	{
		AffectEquipType = 1;
	}
}
