using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Sword;

public class DaMoJianFa : ExtraBreathOrStance
{
	protected override bool IsBreath => true;

	public DaMoJianFa()
	{
	}

	public DaMoJianFa(CombatSkillKey skillKey)
		: base(skillKey, 5207)
	{
	}
}
