using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Agile;

public class FenTouDun : AttackChangeMobility
{
	public FenTouDun()
	{
	}

	public FenTouDun(CombatSkillKey skillKey)
		: base(skillKey, 15601)
	{
		RequireWeaponSubType = 15;
	}
}
