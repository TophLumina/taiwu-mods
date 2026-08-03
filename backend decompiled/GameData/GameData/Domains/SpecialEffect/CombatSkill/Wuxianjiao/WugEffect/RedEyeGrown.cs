using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class RedEyeGrown : RedEyeBase
{
	public RedEyeGrown()
	{
	}

	public RedEyeGrown(int charId)
		: base(charId, 12504, ItemDomain.GetWugTemplateId(0, 4), 469)
	{
	}
}
