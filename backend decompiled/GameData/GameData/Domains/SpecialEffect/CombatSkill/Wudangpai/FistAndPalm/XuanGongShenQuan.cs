using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.FistAndPalm;

public class XuanGongShenQuan : AttackSkillFiveElementsType
{
	public XuanGongShenQuan()
	{
	}

	public XuanGongShenQuan(CombatSkillKey skillKey)
		: base(skillKey, 4105)
	{
		AffectFiveElementsType = 0;
	}
}
