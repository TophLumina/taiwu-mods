using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.MoNv;

public class YouTanQiShui : AddPoison
{
	public YouTanQiShui()
	{
	}

	public YouTanQiShui(CombatSkillKey skillKey)
		: base(skillKey, 17001)
	{
		PoisonTypeCount = 3;
	}
}
