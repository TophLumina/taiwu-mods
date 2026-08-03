using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Agile;

public class FengHuoZhenXingJue : AttackChangeMobility
{
	public FengHuoZhenXingJue()
	{
	}

	public FengHuoZhenXingJue(CombatSkillKey skillKey)
		: base(skillKey, 14404)
	{
		RequireWeaponSubType = 9;
	}
}
