using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Finger;

public class ChangXiShiErShi : CastAgainOrPowerUp
{
	public ChangXiShiErShi()
	{
	}

	public ChangXiShiErShi(CombatSkillKey skillKey)
		: base(skillKey, 8205)
	{
		RequireTrickType = 7;
	}
}
