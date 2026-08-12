using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class IceSilkwormGrown : IceSilkwormBase
{
	public IceSilkwormGrown()
	{
	}

	public IceSilkwormGrown(int charId)
		: base(charId, 12529, ItemDomain.GetWugTemplateId(5, 4), 474)
	{
	}
}
