using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class GoldenSilkwormGrowingBad1 : GoldenSilkwormBase
{
	public GoldenSilkwormGrowingBad1()
	{
	}

	public GoldenSilkwormGrowingBad1(int charId)
		: base(charId, 12532, ItemDomain.GetWugTemplateId(6, 2), 475)
	{
	}
}
