using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class ForestSpiritGrowingGood1 : ForestSpiritBase
{
	public ForestSpiritGrowingGood1()
	{
	}

	public ForestSpiritGrowingGood1(int charId)
		: base(charId, 12505, ItemDomain.GetWugTemplateId(1, 0), 1196)
	{
	}
}
