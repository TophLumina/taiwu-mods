using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class GoldenSilkwormGrowingBad2 : GoldenSilkwormBase
{
	public GoldenSilkwormGrowingBad2()
	{
	}

	public GoldenSilkwormGrowingBad2(int charId)
		: base(charId, 12533, ItemDomain.GetWugTemplateId(6, 3), 475)
	{
	}
}
