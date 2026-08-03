using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class DevilInsideGrowingBad2 : DevilInsideBase
{
	public DevilInsideGrowingBad2()
	{
	}

	public DevilInsideGrowingBad2(int charId)
		: base(charId, 12518, ItemDomain.GetWugTemplateId(3, 3), 472)
	{
	}
}
