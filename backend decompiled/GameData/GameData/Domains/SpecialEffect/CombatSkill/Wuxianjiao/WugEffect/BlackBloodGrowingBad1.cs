using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class BlackBloodGrowingBad1 : BlackBloodBase
{
	public BlackBloodGrowingBad1()
	{
	}

	public BlackBloodGrowingBad1(int charId)
		: base(charId, 12512, ItemDomain.GetWugTemplateId(2, 2), 471)
	{
	}
}
