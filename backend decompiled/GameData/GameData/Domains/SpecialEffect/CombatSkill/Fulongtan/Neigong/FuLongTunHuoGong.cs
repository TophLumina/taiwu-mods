using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Neigong;

public class FuLongTunHuoGong : FiveElementsAddPenetrateAndResist
{
	public FuLongTunHuoGong()
	{
	}

	public FuLongTunHuoGong(CombatSkillKey skillKey)
		: base(skillKey, 14001)
	{
		RequireFiveElementsType = 3;
	}
}
