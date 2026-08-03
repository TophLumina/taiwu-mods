using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Polearm;

public class ZhuanJie : AddMaxPower
{
	public ZhuanJie()
	{
	}

	public ZhuanJie(CombatSkillKey skillKey)
		: base(skillKey, 40901)
	{
	}
}
