using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class CorpseWormGrown : CorpseWormBase
{
	public CorpseWormGrown()
	{
	}

	public CorpseWormGrown(int charId)
		: base(charId, 12524, ItemDomain.GetWugTemplateId(4, 4), 473)
	{
	}
}
