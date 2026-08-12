using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class GoldenSilkwormGrown : GoldenSilkwormBase
{
	public GoldenSilkwormGrown()
	{
	}

	public GoldenSilkwormGrown(int charId)
		: base(charId, 12534, ItemDomain.GetWugTemplateId(6, 4), 475)
	{
	}
}
