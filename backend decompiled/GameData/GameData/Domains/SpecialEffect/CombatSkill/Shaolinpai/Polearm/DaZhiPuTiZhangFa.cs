using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Polearm;

public class DaZhiPuTiZhangFa : CastAgainOrPowerUp
{
	public DaZhiPuTiZhangFa()
	{
	}

	public DaZhiPuTiZhangFa(CombatSkillKey skillKey)
		: base(skillKey, 1307)
	{
		RequireTrickType = 5;
	}
}
