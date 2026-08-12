using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Agile;

public class MeiDianTou : AttackChangeMobility
{
	public MeiDianTou()
	{
	}

	public MeiDianTou(CombatSkillKey skillKey)
		: base(skillKey, 8400)
	{
		RequireWeaponSubType = 11;
	}
}
