using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Agile;

public class BieLiBu : AgileSkillBase
{
	private int _hitAccumulator;

	private int RequireHitCount => base.IsDirect ? 3 : 6;

	public BieLiBu()
	{
	}

	public BieLiBu(CombatSkillKey skillKey)
		: base(skillKey, 8402)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_hitAccumulator = 0;
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
		if (attacker == base.CombatChar && hit)
		{
			AddHitCount(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.Attacker == base.CombatChar && hit)
		{
			AddHitCount(context);
		}
	}

	private void AddHitCount(DataContext context)
	{
		_hitAccumulator++;
		if (_hitAccumulator < RequireHitCount)
		{
			return;
		}
		_hitAccumulator -= RequireHitCount;
		if (base.CanAffect)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			if (base.IsDirect)
			{
				DomainManager.Combat.AddTrick(context, enemyChar, 20, addedByAlly: false);
			}
			else
			{
				AddPowerDamageMind(context, enemyChar);
			}
			ShowSpecialEffectTips(0);
		}
	}
}
