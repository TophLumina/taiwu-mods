using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Neigong;

public class XieGuiGong : ReduceFiveElementsDamage
{
	public XieGuiGong()
	{
	}

	public XieGuiGong(CombatSkillKey skillKey)
		: base(skillKey, 15002)
	{
		RequireSelfFiveElementsType = 4;
		AffectFiveElementsType = (sbyte)((!base.IsDirect) ? 1 : 2);
	}
}
