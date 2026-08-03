using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Finger;

public class ChiMeiGuJiang : AddWug
{
	protected override int AddWugCount => 4;

	public ChiMeiGuJiang()
	{
	}

	public ChiMeiGuJiang(CombatSkillKey skillKey)
		: base(skillKey, 12202)
	{
		WugType = 1;
	}
}
