using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class DevilInsideGrown : DevilInsideBase
{
	public DevilInsideGrown()
	{
	}

	public DevilInsideGrown(int charId)
		: base(charId, 12519, ItemDomain.GetWugTemplateId(3, 4), 472)
	{
	}
}
