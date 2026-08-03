using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Neigong;

public class XueHouXieJing : KeepSkillCanCast
{
	public XueHouXieJing()
	{
	}

	public XueHouXieJing(CombatSkillKey skillKey)
		: base(skillKey, 15007)
	{
		RequireFiveElementsType = 4;
	}
}
