using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Neigong;

public class WangShuYuYueGong : AddFiveElementsDamage
{
	public WangShuYuYueGong()
	{
	}

	public WangShuYuYueGong(CombatSkillKey skillKey)
		: base(skillKey, 8002)
	{
		RequireSelfFiveElementsType = 2;
		AffectFiveElementsType = (sbyte)(base.IsDirect ? 3 : 4);
	}
}
