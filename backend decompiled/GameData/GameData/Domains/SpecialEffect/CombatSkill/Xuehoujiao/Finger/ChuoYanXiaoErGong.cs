using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Finger;

public class ChuoYanXiaoErGong : AddBreakBodyFeature
{
	public ChuoYanXiaoErGong()
	{
	}

	public ChuoYanXiaoErGong(CombatSkillKey skillKey)
		: base(skillKey, 15200)
	{
		AffectBodyParts = new sbyte[1] { 2 };
	}
}
