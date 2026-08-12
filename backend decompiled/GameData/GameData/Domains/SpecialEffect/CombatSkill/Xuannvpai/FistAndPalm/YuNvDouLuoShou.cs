using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.FistAndPalm;

public class YuNvDouLuoShou : ReduceEnemyTrick
{
	public YuNvDouLuoShou()
	{
	}

	public YuNvDouLuoShou(CombatSkillKey skillKey)
		: base(skillKey, 8100)
	{
		AffectTrickType = 8;
	}
}
