using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Shot;

public class LiuXianJiuZhenShu : StrengthenPoison
{
	protected override bool Variant1 => false;

	public LiuXianJiuZhenShu()
	{
	}

	public LiuXianJiuZhenShu(CombatSkillKey skillKey)
		: base(skillKey, 3206)
	{
		AffectPoisonType = 5;
	}
}
