using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Finger;

public class XinMoGuJiang : AddWug
{
	public XinMoGuJiang()
	{
	}

	public XinMoGuJiang(CombatSkillKey skillKey)
		: base(skillKey, 12204)
	{
		WugType = 3;
	}
}
