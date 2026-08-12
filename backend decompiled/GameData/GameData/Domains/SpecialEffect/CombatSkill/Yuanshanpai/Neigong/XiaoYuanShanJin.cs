using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Neigong;

public class XiaoYuanShanJin : FiveElementsAddPenetrateAndResist
{
	public XiaoYuanShanJin()
	{
	}

	public XiaoYuanShanJin(CombatSkillKey skillKey)
		: base(skillKey, 5001)
	{
		RequireFiveElementsType = 4;
	}
}
