using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Blade;

public class WuJiDaoFa : AutoMoveAndCast
{
	protected override bool MoveForward => !base.IsDirect;

	protected override short RequireWeaponType => 9;

	protected override sbyte RequireSkillType => 7;

	public WuJiDaoFa()
	{
	}

	public WuJiDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 5305)
	{
	}
}
