using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.DefenseAndAssist;

public class JingWeiTianHaiShi : DefenseSkillBase
{
	public JingWeiTianHaiShi()
	{
	}

	public JingWeiTianHaiShi(CombatSkillKey skillKey)
		: base(skillKey, 8501)
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
		if (!(defender != base.CombatChar || hit) && pursueIndex <= 0 && base.CanAffect && attacker.NormalAttackHitType == 2)
		{
			DoAvoidEffect(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.Defender != base.CombatChar || hit) && base.CanAffect && index <= 2 && DomainManager.Combat.GetDamageCompareData().HitType[index] == 2)
		{
			DoAvoidEffect(context);
		}
	}

	private void DoAvoidEffect(DataContext context)
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
