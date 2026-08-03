using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class RedEyeGrowingBad1 : RedEyeBase
{
	public RedEyeGrowingBad1()
	{
	}

	public RedEyeGrowingBad1(int charId)
		: base(charId, 12502, ItemDomain.GetWugTemplateId(0, 2), 469)
	{
	}
}
