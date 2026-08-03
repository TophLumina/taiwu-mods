using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.DefenseAndAssist;

public class MingWangZhuoHuoDing : DefenseSkillBase
{
	private const int AddPoison = 180;

	public MingWangZhuoHuoDing()
	{
	}

	public MingWangZhuoHuoDing(CombatSkillKey skillKey)
		: base(skillKey, 11605)
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
		if (!hit && defender == base.CombatChar && base.CanAffect && attacker.NormalAttackHitType == 0)
		{
			DoEffect(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.Defender != base.CombatChar || hit) && base.CanAffect && index <= 2 && hitType == 0)
		{
			DoEffect(context);
		}
	}

	private void DoEffect(DataContext context)
	{
		DamageCompareData damageCompareData = DomainManager.Combat.GetDamageCompareData();
		int index = damageCompareData.HitType.IndexOf(0);
		int poisonValue = 180 * damageCompareData.AvoidValue[index] / Math.Max(damageCompareData.HitValue[index], 1);
		if (poisonValue > 0)
		{
			DomainManager.Combat.AddPoison(context, base.CombatChar, base.CurrEnemyChar, (!base.IsDirect) ? ((sbyte)1) : ((sbyte)0), 2, poisonValue, -1);
			ShowSpecialEffectTips(0);
		}
	}
}
