using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class IceSilkwormGrowingBad1 : IceSilkwormBase
{
	public IceSilkwormGrowingBad1()
	{
	}

	public IceSilkwormGrowingBad1(int charId)
		: base(charId, 12527, ItemDomain.GetWugTemplateId(5, 2), 474)
	{
	}
}
