using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Neigong;

public class ALuoHanShenGong : LifeSkillAddHealCount
{
	public ALuoHanShenGong()
	{
	}

	public ALuoHanShenGong(CombatSkillKey skillKey)
		: base(skillKey, 1006)
	{
		RequireLifeSkillType = 13;
	}
}
