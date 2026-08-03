using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Sword;

public class WeiTuoFuMoJian : AutoMoveAndCast
{
	protected override bool MoveForward => base.IsDirect;

	protected override short RequireWeaponType => 8;

	protected override sbyte RequireSkillType => 8;

	public WeiTuoFuMoJian()
	{
	}

	public WeiTuoFuMoJian(CombatSkillKey skillKey)
		: base(skillKey, 5205)
	{
	}
}
