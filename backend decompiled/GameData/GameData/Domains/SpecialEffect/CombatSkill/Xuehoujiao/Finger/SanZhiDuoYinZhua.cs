using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Finger;

public class SanZhiDuoYinZhua : AddBreakBodyFeature
{
	public SanZhiDuoYinZhua()
	{
	}

	public SanZhiDuoYinZhua(CombatSkillKey skillKey)
		: base(skillKey, 15203)
	{
		AffectBodyParts = new sbyte[1] { 1 };
	}
}
