using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.FistAndPalm;

public class ShouZhi : ReduceGridCost
{
	public ShouZhi()
	{
	}

	public ShouZhi(CombatSkillKey skillKey)
		: base(skillKey, 40305)
	{
	}
}
