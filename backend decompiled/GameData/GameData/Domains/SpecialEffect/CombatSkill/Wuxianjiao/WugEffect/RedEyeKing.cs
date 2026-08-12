using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class RedEyeKing : RedEyeBase
{
	public RedEyeKing()
	{
	}

	public RedEyeKing(int charId)
		: base(charId, 12540, ItemDomain.GetWugTemplateId(0, 5), 469)
	{
	}
}
