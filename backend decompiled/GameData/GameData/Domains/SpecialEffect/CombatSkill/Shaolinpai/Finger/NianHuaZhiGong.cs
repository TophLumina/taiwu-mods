using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Finger;

public class NianHuaZhiGong : GameData.Domains.SpecialEffect.CombatSkill.Common.Attack.AttackHitType
{
	public NianHuaZhiGong()
	{
	}

	public NianHuaZhiGong(CombatSkillKey skillKey)
		: base(skillKey, 1202)
	{
		AffectHitType = 1;
	}
}
