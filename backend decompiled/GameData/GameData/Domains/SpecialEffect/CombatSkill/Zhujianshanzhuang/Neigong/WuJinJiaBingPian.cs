using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Neigong;

public class WuJinJiaBingPian : ReduceFiveElementsDamage
{
	public WuJinJiaBingPian()
	{
	}

	public WuJinJiaBingPian(CombatSkillKey skillKey)
		: base(skillKey, 9002)
	{
		RequireSelfFiveElementsType = 3;
		AffectFiveElementsType = (sbyte)((!base.IsDirect) ? 2 : 0);
	}
}
