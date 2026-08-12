using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Agile;

public class ShaTangTaShui : ChangeLegSkillHit
{
	public ShaTangTaShui()
	{
	}

	public ShaTangTaShui(CombatSkillKey skillKey)
		: base(skillKey, 10502)
	{
		BuffHitType = 1;
	}
}
