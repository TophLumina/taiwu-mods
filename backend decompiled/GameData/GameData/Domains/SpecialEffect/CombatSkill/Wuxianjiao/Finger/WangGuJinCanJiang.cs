using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Finger;

public class WangGuJinCanJiang : AddWug
{
	protected override int AddWugCount => 16;

	public WangGuJinCanJiang()
	{
	}

	public WangGuJinCanJiang(CombatSkillKey skillKey)
		: base(skillKey, 12207)
	{
		WugType = 6;
	}
}
