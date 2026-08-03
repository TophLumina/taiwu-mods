using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Sword;

public class LuoHanJianFa : WeaponAddAttackPrepareValue
{
	protected override int RequireWeaponSubType => 9;

	protected override int DirectSrcWeaponSubType => 8;

	public LuoHanJianFa()
	{
	}

	public LuoHanJianFa(CombatSkillKey skillKey)
		: base(skillKey, 5200)
	{
	}
}
