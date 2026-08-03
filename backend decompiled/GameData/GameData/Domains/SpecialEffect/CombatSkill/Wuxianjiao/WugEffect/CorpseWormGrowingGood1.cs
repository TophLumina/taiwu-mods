using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class CorpseWormGrowingGood1 : CorpseWormBase
{
	public CorpseWormGrowingGood1()
	{
	}

	public CorpseWormGrowingGood1(int charId)
		: base(charId, 12520, ItemDomain.GetWugTemplateId(4, 0), 1199)
	{
	}
}
