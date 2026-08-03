using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Neigong;

public class TuMuGong : FiveElementsAddPenetrateAndResist
{
	public TuMuGong()
	{
	}

	public TuMuGong(CombatSkillKey skillKey)
		: base(skillKey, 11001)
	{
		RequireFiveElementsType = 0;
	}
}
