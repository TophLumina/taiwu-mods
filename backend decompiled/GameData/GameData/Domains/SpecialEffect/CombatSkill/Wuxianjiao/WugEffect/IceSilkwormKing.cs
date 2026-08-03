using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class IceSilkwormKing : IceSilkwormBase
{
	public IceSilkwormKing()
	{
	}

	public IceSilkwormKing(int charId)
		: base(charId, 12545, ItemDomain.GetWugTemplateId(5, 5), 474)
	{
	}
}
