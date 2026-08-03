using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class ForestSpiritKing : ForestSpiritBase
{
	public ForestSpiritKing()
	{
	}

	public ForestSpiritKing(int charId)
		: base(charId, 12541, ItemDomain.GetWugTemplateId(1, 5), 470)
	{
	}
}
