using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class CorpseWormGrowingBad2 : CorpseWormBase
{
	public CorpseWormGrowingBad2()
	{
	}

	public CorpseWormGrowingBad2(int charId)
		: base(charId, 12523, ItemDomain.GetWugTemplateId(4, 3), 473)
	{
	}
}
