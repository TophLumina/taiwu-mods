using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class BlackBloodGrowingGood2 : BlackBloodBase
{
	public BlackBloodGrowingGood2()
	{
	}

	public BlackBloodGrowingGood2(int charId)
		: base(charId, 12511, ItemDomain.GetWugTemplateId(2, 1), 1197)
	{
	}
}
