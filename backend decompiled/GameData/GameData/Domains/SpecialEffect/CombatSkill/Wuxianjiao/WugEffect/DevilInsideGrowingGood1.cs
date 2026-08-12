using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class DevilInsideGrowingGood1 : DevilInsideBase
{
	public DevilInsideGrowingGood1()
	{
	}

	public DevilInsideGrowingGood1(int charId)
		: base(charId, 12515, ItemDomain.GetWugTemplateId(3, 0), 1198)
	{
	}
}
