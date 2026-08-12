using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Neigong;

public class DaYuanShanJin : AddFiveElementsDamage
{
	public DaYuanShanJin()
	{
	}

	public DaYuanShanJin(CombatSkillKey skillKey)
		: base(skillKey, 5002)
	{
		RequireSelfFiveElementsType = 4;
		AffectFiveElementsType = (sbyte)((!base.IsDirect) ? 1 : 2);
	}
}
