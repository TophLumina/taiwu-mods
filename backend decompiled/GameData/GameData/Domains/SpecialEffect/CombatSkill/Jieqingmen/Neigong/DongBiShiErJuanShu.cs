using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Neigong;

public class DongBiShiErJuanShu : ReduceFiveElementsDamage
{
	public DongBiShiErJuanShu()
	{
	}

	public DongBiShiErJuanShu(CombatSkillKey skillKey)
		: base(skillKey, 13002)
	{
		RequireSelfFiveElementsType = 2;
		AffectFiveElementsType = (sbyte)(base.IsDirect ? 3 : 4);
	}
}
