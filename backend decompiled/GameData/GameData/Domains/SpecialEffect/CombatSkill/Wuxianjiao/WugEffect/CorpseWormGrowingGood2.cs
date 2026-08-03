using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class CorpseWormGrowingGood2 : CorpseWormBase
{
	public CorpseWormGrowingGood2()
	{
	}

	public CorpseWormGrowingGood2(int charId)
		: base(charId, 12521, ItemDomain.GetWugTemplateId(4, 1), 1199)
	{
	}
}
