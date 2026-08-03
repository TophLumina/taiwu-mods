using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.FistAndPalm;

public class WuDangChangQuan : AddMaxPowerOrUseRequirement
{
	public WuDangChangQuan()
	{
	}

	public WuDangChangQuan(CombatSkillKey skillKey)
		: base(skillKey, 4100)
	{
		AffectEquipType = 4;
	}
}
