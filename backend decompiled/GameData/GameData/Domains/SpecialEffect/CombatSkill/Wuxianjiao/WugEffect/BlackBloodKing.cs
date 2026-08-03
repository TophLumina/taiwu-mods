using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class BlackBloodKing : BlackBloodBase
{
	public BlackBloodKing()
	{
	}

	public BlackBloodKing(int charId)
		: base(charId, 12542, ItemDomain.GetWugTemplateId(2, 5), 471)
	{
	}
}
