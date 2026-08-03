using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class XiTuShiLing : DefenseSkillBase
{
	private const sbyte NeiliAllocationValue = 3;

	public XiTuShiLing()
	{
	}

	public XiTuShiLing(CombatSkillKey skillKey)
		: base(skillKey, 16306)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (hit && pursueIndex == 0 && defender == base.CombatChar && base.CanAffect)
		{
			StealEnemyNeiliAllocation(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (hit && index <= 2 && context.Defender == base.CombatChar && base.CanAffect)
		{
			StealEnemyNeiliAllocation(context);
		}
	}

	private void StealEnemyNeiliAllocation(DataContext context)
	{
		if (base.CombatChar.AbsorbNeiliAllocationRandom(context, base.CurrEnemyChar, 3))
		{
			ShowSpecialEffectTips(0);
		}
	}
}
