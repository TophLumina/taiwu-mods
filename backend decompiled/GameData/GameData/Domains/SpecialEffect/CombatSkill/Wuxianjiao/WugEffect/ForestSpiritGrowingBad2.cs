using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class ForestSpiritGrowingBad2 : ForestSpiritBase
{
	public ForestSpiritGrowingBad2()
	{
	}

	public ForestSpiritGrowingBad2(int charId)
		: base(charId, 12508, ItemDomain.GetWugTemplateId(1, 3), 470)
	{
	}
}
