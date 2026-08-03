using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Finger;

public class BiYuBingCanGu : AddWug
{
	protected override int AddWugCount => 8;

	public BiYuBingCanGu()
	{
	}

	public BiYuBingCanGu(CombatSkillKey skillKey)
		: base(skillKey, 12206)
	{
		WugType = 5;
	}
}
