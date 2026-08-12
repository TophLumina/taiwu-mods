using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Neigong;

public class TaiYiShenGong : LifeSkillAddHealCount
{
	public TaiYiShenGong()
	{
	}

	public TaiYiShenGong(CombatSkillKey skillKey)
		: base(skillKey, 4006)
	{
		RequireLifeSkillType = 12;
	}
}
