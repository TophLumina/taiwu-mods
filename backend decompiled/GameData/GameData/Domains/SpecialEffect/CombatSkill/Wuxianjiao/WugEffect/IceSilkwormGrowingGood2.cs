using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class IceSilkwormGrowingGood2 : IceSilkwormBase
{
	public IceSilkwormGrowingGood2()
	{
	}

	public IceSilkwormGrowingGood2(int charId)
		: base(charId, 12526, ItemDomain.GetWugTemplateId(5, 1), 1200)
	{
	}
}
