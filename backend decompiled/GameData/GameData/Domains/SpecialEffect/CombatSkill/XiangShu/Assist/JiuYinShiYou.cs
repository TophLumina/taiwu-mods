using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class JiuYinShiYou : AddDamageByFiveElementsType
{
	public JiuYinShiYou()
	{
	}

	public JiuYinShiYou(CombatSkillKey skillKey)
		: base(skillKey, 16402)
	{
		CounteringType = 3;
		CounteredType = 4;
	}
}
