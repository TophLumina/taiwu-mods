using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Neigong;

public class TongZiXueLianFa : StrengthenFiveElementsTypeWithBoost
{
	protected override sbyte FiveElementsType => 4;

	protected override byte CostNeiliAllocationType => 0;

	public TongZiXueLianFa()
	{
	}

	public TongZiXueLianFa(CombatSkillKey skillKey)
		: base(skillKey, 15006)
	{
	}
}
