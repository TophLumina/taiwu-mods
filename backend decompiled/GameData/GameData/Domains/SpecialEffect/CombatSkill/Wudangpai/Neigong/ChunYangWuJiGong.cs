using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Neigong;

public class ChunYangWuJiGong : KeepSkillCanCast
{
	public ChunYangWuJiGong()
	{
	}

	public ChunYangWuJiGong(CombatSkillKey skillKey)
		: base(skillKey, 4007)
	{
		RequireFiveElementsType = 3;
	}
}
