using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class GoldenSilkwormGrowingGood2 : GoldenSilkwormBase
{
	public GoldenSilkwormGrowingGood2()
	{
	}

	public GoldenSilkwormGrowingGood2(int charId)
		: base(charId, 12531, ItemDomain.GetWugTemplateId(6, 1), 1201)
	{
	}
}
