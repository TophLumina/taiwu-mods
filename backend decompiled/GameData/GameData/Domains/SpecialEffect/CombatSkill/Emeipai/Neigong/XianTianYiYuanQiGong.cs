using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Neigong;

public class XianTianYiYuanQiGong : AddFiveElementsDamage
{
	public XianTianYiYuanQiGong()
	{
	}

	public XianTianYiYuanQiGong(CombatSkillKey skillKey)
		: base(skillKey, 2002)
	{
		RequireSelfFiveElementsType = 1;
		AffectFiveElementsType = (sbyte)(base.IsDirect ? 4 : 0);
	}
}
