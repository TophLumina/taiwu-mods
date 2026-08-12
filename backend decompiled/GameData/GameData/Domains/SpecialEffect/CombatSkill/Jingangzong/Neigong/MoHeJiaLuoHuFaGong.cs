using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Neigong;

public class MoHeJiaLuoHuFaGong : KeepSkillCanCast
{
	public MoHeJiaLuoHuFaGong()
	{
	}

	public MoHeJiaLuoHuFaGong(CombatSkillKey skillKey)
		: base(skillKey, 11007)
	{
		RequireFiveElementsType = 0;
	}
}
