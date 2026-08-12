using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class ForestSpiritGrowingGood2 : ForestSpiritBase
{
	public ForestSpiritGrowingGood2()
	{
	}

	public ForestSpiritGrowingGood2(int charId)
		: base(charId, 12506, ItemDomain.GetWugTemplateId(1, 1), 1196)
	{
	}
}
