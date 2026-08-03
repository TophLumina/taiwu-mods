using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Agile;

public class ShiZiFenXun : AttackChangeMobility
{
	public ShiZiFenXun()
	{
	}

	public ShiZiFenXun(CombatSkillKey skillKey)
		: base(skillKey, 6403)
	{
		RequireWeaponSubType = 4;
	}
}
