using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class CorpseWormGrowingBad1 : CorpseWormBase
{
	public CorpseWormGrowingBad1()
	{
	}

	public CorpseWormGrowingBad1(int charId)
		: base(charId, 12522, ItemDomain.GetWugTemplateId(4, 2), 473)
	{
	}
}
