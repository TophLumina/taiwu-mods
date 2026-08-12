using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Blade;

public class BaGuaWuXingDao : WeaponAddAttackPrepareValue
{
	protected override int RequireWeaponSubType => 8;

	protected override int DirectSrcWeaponSubType => 9;

	public BaGuaWuXingDao()
	{
	}

	public BaGuaWuXingDao(CombatSkillKey skillKey)
		: base(skillKey, 5300)
	{
	}
}
