using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class DevilInsideKing : DevilInsideBase
{
	public DevilInsideKing()
	{
	}

	public DevilInsideKing(int charId)
		: base(charId, 12543, ItemDomain.GetWugTemplateId(3, 5), 472)
	{
	}
}
