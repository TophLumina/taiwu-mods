using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class ForestSpiritGrown : ForestSpiritBase
{
	public ForestSpiritGrown()
	{
	}

	public ForestSpiritGrown(int charId)
		: base(charId, 12509, ItemDomain.GetWugTemplateId(1, 4), 470)
	{
	}
}
