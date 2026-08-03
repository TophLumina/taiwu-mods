using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Neigong;

public class XinYiQiHunYuanGong : ReduceFiveElementsDamage
{
	public XinYiQiHunYuanGong()
	{
	}

	public XinYiQiHunYuanGong(CombatSkillKey skillKey)
		: base(skillKey, 1002)
	{
		RequireSelfFiveElementsType = 0;
		AffectFiveElementsType = (sbyte)(base.IsDirect ? 1 : 3);
	}
}
