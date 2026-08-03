using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Neigong;

public class HunTianXingTu : KeepSkillCanCast
{
	public HunTianXingTu()
	{
	}

	public HunTianXingTu(CombatSkillKey skillKey)
		: base(skillKey, 13006)
	{
		RequireFiveElementsType = 2;
	}
}
