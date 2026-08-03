using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Finger;

public class FenJinCuoGuShou : AddBreakBodyFeature
{
	public FenJinCuoGuShou()
	{
	}

	public FenJinCuoGuShou(CombatSkillKey skillKey)
		: base(skillKey, 15202)
	{
		AffectBodyParts = new sbyte[2] { 3, 4 };
	}
}
