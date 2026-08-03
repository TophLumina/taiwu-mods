using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Neigong;

public class SanShiFa : KeepSkillCanCast
{
	public SanShiFa()
	{
	}

	public SanShiFa(CombatSkillKey skillKey)
		: base(skillKey, 7006)
	{
		RequireFiveElementsType = 1;
	}
}
