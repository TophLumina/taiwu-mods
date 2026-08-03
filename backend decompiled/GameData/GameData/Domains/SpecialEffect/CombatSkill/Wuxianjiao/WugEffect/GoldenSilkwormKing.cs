using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class GoldenSilkwormKing : GoldenSilkwormBase
{
	public GoldenSilkwormKing()
	{
	}

	public GoldenSilkwormKing(int charId)
		: base(charId, 12546, ItemDomain.GetWugTemplateId(6, 5), 475)
	{
	}
}
