using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Agile;

public class JinGangZuoFa : AttackChangeMobility
{
	public JinGangZuoFa()
	{
	}

	public JinGangZuoFa(CombatSkillKey skillKey)
		: base(skillKey, 11502)
	{
		RequireWeaponSubType = 5;
	}
}
