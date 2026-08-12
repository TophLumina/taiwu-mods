using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Blade;

public class TaiXuanShenDao : ExtraBreathOrStance
{
	protected override bool IsBreath => false;

	public TaiXuanShenDao()
	{
	}

	public TaiXuanShenDao(CombatSkillKey skillKey)
		: base(skillKey, 5207)
	{
	}
}
