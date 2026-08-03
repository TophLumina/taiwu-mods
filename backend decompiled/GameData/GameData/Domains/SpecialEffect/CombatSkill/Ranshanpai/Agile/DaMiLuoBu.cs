using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Agile;

public class DaMiLuoBu : AttackChangeMobility
{
	public DaMiLuoBu()
	{
	}

	public DaMiLuoBu(CombatSkillKey skillKey)
		: base(skillKey, 7402)
	{
		RequireWeaponSubType = 13;
	}
}
