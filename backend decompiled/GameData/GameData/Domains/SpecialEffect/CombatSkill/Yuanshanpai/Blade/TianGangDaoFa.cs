using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Blade;

public class TianGangDaoFa : AttackNeiliFiveElementsType
{
	public TianGangDaoFa()
	{
	}

	public TianGangDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 5306)
	{
		AffectFiveElementsType = 2;
	}
}
