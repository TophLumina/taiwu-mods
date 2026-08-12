using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Finger;

public class SanQingZhi : ReduceEnemyTrick
{
	public SanQingZhi()
	{
	}

	public SanQingZhi(CombatSkillKey skillKey)
		: base(skillKey, 7100)
	{
		AffectTrickType = 7;
	}
}
