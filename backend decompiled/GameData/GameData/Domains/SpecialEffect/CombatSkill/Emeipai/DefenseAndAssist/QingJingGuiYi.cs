using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.DefenseAndAssist;

public class QingJingGuiYi : AssistSkillBase
{
	private const sbyte ReduceBreathStancePercent = 10;

	public QingJingGuiYi()
	{
	}

	public QingJingGuiYi(CombatSkillKey skillKey)
		: base(skillKey, 2704)
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
		if (!(defender != base.CombatChar || hit) && pursueIndex <= 0 && base.CanAffect)
		{
			DoEffect(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.Defender != base.CombatChar || hit) && base.CanAffect)
		{
			DoEffect(context);
		}
	}

	private void DoEffect(DataContext context)
	{
		if (base.IsDirect)
		{
			ChangeStanceValue(context, base.CurrEnemyChar, -400);
		}
		else
		{
			ChangeBreathValue(context, base.CurrEnemyChar, -3000);
		}
		sbyte[] weaponTricks = base.CombatChar.GetWeaponTricks();
		DomainManager.Combat.AddTrick(context, base.CombatChar, weaponTricks[context.Random.Next(0, weaponTricks.Length)]);
		ShowEffectTips(context);
		ShowSpecialEffectTips(0);
	}
}
