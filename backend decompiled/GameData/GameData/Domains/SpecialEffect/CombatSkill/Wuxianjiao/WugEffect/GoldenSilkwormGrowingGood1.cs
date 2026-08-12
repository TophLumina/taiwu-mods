using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class GoldenSilkwormGrowingGood1 : GoldenSilkwormBase
{
	public GoldenSilkwormGrowingGood1()
	{
	}

	public GoldenSilkwormGrowingGood1(int charId)
		: base(charId, 12530, ItemDomain.GetWugTemplateId(6, 0), 1201)
	{
	}
}
