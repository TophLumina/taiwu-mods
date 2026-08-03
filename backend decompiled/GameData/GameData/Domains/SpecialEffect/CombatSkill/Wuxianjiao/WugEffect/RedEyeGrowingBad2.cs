using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class RedEyeGrowingBad2 : RedEyeBase
{
	public RedEyeGrowingBad2()
	{
	}

	public RedEyeGrowingBad2(int charId)
		: base(charId, 12503, ItemDomain.GetWugTemplateId(0, 3), 469)
	{
	}
}
