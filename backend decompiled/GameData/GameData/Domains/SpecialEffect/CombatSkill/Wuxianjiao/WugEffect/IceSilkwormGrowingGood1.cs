using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class IceSilkwormGrowingGood1 : IceSilkwormBase
{
	public IceSilkwormGrowingGood1()
	{
	}

	public IceSilkwormGrowingGood1(int charId)
		: base(charId, 12525, ItemDomain.GetWugTemplateId(5, 0), 1200)
	{
	}
}
