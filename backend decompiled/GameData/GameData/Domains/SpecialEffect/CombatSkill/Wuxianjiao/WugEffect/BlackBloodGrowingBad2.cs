using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class BlackBloodGrowingBad2 : BlackBloodBase
{
	public BlackBloodGrowingBad2()
	{
	}

	public BlackBloodGrowingBad2(int charId)
		: base(charId, 12513, ItemDomain.GetWugTemplateId(2, 3), 471)
	{
	}
}
