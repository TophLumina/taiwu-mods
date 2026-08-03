using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class ForestSpiritGrowingBad1 : ForestSpiritBase
{
	public ForestSpiritGrowingBad1()
	{
	}

	public ForestSpiritGrowingBad1(int charId)
		: base(charId, 12507, ItemDomain.GetWugTemplateId(1, 2), 470)
	{
	}
}
