using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class JinGangDuanE : AddDamageByFiveElementsType
{
	public JinGangDuanE()
	{
	}

	public JinGangDuanE(CombatSkillKey skillKey)
		: base(skillKey, 16401)
	{
		CounteringType = 1;
		CounteredType = 3;
	}
}
