using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class RedEyeGrowingGood1 : RedEyeBase
{
	public RedEyeGrowingGood1()
	{
	}

	public RedEyeGrowingGood1(int charId)
		: base(charId, 12500, ItemDomain.GetWugTemplateId(0, 0), 1195)
	{
	}
}
