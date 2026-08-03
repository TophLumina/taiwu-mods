using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class IceSilkwormGrowingBad2 : IceSilkwormBase
{
	public IceSilkwormGrowingBad2()
	{
	}

	public IceSilkwormGrowingBad2(int charId)
		: base(charId, 12528, ItemDomain.GetWugTemplateId(5, 3), 474)
	{
	}
}
