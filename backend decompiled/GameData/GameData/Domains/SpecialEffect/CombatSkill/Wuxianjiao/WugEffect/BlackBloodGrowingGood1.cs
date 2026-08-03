using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class BlackBloodGrowingGood1 : BlackBloodBase
{
	public BlackBloodGrowingGood1()
	{
	}

	public BlackBloodGrowingGood1(int charId)
		: base(charId, 12510, ItemDomain.GetWugTemplateId(2, 0), 1197)
	{
	}
}
