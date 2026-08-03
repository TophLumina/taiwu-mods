using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Agile;

public class DaFanTengShu : AttackChangeMobility
{
	public DaFanTengShu()
	{
	}

	public DaFanTengShu(CombatSkillKey skillKey)
		: base(skillKey, 1403)
	{
		RequireWeaponSubType = 10;
	}
}
