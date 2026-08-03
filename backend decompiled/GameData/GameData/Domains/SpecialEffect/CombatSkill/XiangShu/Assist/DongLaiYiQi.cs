using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class DongLaiYiQi : AddDamageByFiveElementsType
{
	public DongLaiYiQi()
	{
	}

	public DongLaiYiQi(CombatSkillKey skillKey)
		: base(skillKey, 16400)
	{
		CounteringType = 4;
		CounteredType = 0;
	}
}
