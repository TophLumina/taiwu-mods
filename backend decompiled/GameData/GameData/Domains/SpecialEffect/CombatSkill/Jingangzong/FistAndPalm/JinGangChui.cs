using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.FistAndPalm;

public class JinGangChui : ReduceEnemyTrick
{
	public JinGangChui()
	{
	}

	public JinGangChui(CombatSkillKey skillKey)
		: base(skillKey, 11100)
	{
		AffectTrickType = 6;
	}
}
