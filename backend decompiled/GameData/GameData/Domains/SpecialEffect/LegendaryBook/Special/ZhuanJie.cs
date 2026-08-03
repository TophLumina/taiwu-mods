using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Special;

public class ZhuanJie : AddMaxPower
{
	public ZhuanJie()
	{
	}

	public ZhuanJie(CombatSkillKey skillKey)
		: base(skillKey, 41001)
	{
	}
}
