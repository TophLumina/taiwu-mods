using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class DevilInsideGrowingBad1 : DevilInsideBase
{
	public DevilInsideGrowingBad1()
	{
	}

	public DevilInsideGrowingBad1(int charId)
		: base(charId, 12517, ItemDomain.GetWugTemplateId(3, 2), 472)
	{
	}
}
