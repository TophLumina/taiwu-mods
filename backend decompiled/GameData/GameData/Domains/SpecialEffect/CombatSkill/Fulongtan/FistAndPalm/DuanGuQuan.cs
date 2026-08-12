using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.FistAndPalm;

public class DuanGuQuan : AddMaxPowerOrUseRequirement
{
	public DuanGuQuan()
	{
	}

	public DuanGuQuan(CombatSkillKey skillKey)
		: base(skillKey, 14100)
	{
		AffectEquipType = 1;
	}
}
