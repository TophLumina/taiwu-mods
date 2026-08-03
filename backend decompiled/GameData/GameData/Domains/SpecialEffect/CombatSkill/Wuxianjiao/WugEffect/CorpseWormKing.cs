using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class CorpseWormKing : CorpseWormBase
{
	public CorpseWormKing()
	{
	}

	public CorpseWormKing(int charId)
		: base(charId, 12544, ItemDomain.GetWugTemplateId(4, 5), 473)
	{
	}
}
