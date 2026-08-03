using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Special;

public class WuXingCi : AddMaxPowerOrUseRequirement
{
	public WuXingCi()
	{
	}

	public WuXingCi(CombatSkillKey skillKey)
		: base(skillKey, 2400)
	{
		AffectEquipType = 2;
	}
}
