using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class BlackBloodGrown : BlackBloodBase
{
	public BlackBloodGrown()
	{
	}

	public BlackBloodGrown(int charId)
		: base(charId, 12514, ItemDomain.GetWugTemplateId(2, 4), 471)
	{
	}
}
