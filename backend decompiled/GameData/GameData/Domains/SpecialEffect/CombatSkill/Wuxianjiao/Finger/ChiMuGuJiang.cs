using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Finger;

public class ChiMuGuJiang : AddWug
{
	protected override int AddWugCount => 3;

	public ChiMuGuJiang()
	{
	}

	public ChiMuGuJiang(CombatSkillKey skillKey)
		: base(skillKey, 12201)
	{
		WugType = 0;
	}
}
