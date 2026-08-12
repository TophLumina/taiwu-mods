using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.FistAndPalm;

public class HanBingShenZhang : StrengthenPoison
{
	public HanBingShenZhang()
	{
	}

	public HanBingShenZhang(CombatSkillKey skillKey)
		: base(skillKey, 8106)
	{
		AffectPoisonType = 2;
	}
}
