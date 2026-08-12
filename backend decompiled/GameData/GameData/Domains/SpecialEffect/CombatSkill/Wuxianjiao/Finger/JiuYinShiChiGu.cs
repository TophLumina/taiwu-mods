using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Finger;

public class JiuYinShiChiGu : AddWug
{
	protected override int AddWugCount => 12;

	public JiuYinShiChiGu()
	{
	}

	public JiuYinShiChiGu(CombatSkillKey skillKey)
		: base(skillKey, 12205)
	{
		WugType = 4;
	}
}
