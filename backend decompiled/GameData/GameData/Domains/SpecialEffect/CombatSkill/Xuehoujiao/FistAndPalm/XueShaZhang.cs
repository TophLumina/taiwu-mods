using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.FistAndPalm;

public class XueShaZhang : AddBreakBodyFeature
{
	public XueShaZhang()
	{
	}

	public XueShaZhang(CombatSkillKey skillKey)
		: base(skillKey, 15104)
	{
		AffectBodyParts = new sbyte[1];
	}
}
