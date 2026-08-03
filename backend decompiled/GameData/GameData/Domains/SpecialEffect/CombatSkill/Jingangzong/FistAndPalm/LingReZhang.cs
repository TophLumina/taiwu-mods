using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.FistAndPalm;

public class LingReZhang : AccumulateNeiliAllocationToStrengthen
{
	public LingReZhang()
	{
	}

	public LingReZhang(CombatSkillKey skillKey)
		: base(skillKey, 11104)
	{
		RequireNeiliAllocationType = 2;
	}
}
