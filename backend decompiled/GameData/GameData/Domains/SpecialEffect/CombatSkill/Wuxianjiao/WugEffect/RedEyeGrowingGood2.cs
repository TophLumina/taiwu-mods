using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class RedEyeGrowingGood2 : RedEyeBase
{
	public RedEyeGrowingGood2()
	{
	}

	public RedEyeGrowingGood2(int charId)
		: base(charId, 12501, ItemDomain.GetWugTemplateId(0, 1), 1195)
	{
	}
}
