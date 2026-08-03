using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Finger;

public class TianDiYuanYiZhi : AttackNeiliFiveElementsType
{
	public TianDiYuanYiZhi()
	{
	}

	public TianDiYuanYiZhi(CombatSkillKey skillKey)
		: base(skillKey, 7106)
	{
		AffectFiveElementsType = 4;
	}
}
