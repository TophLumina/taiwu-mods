using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Neigong;

public class HeiShiSiJue : StrengthenFiveElementsTypeSimple
{
	protected override sbyte FiveElementsType => 4;

	public HeiShiSiJue()
	{
	}

	public HeiShiSiJue(CombatSkillKey skillKey)
		: base(skillKey, 15001)
	{
	}
}
