using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Finger;

public class HeiXueGuJiang : AddWug
{
	protected override int AddWugCount => 6;

	public HeiXueGuJiang()
	{
	}

	public HeiXueGuJiang(CombatSkillKey skillKey)
		: base(skillKey, 12203)
	{
		WugType = 2;
	}
}
