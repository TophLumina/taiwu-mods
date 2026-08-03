using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class ShuangTaiBingPo : DefenseSkillBase
{
	private const sbyte ReduceBreathStance = 10;

	public ShuangTaiBingPo()
	{
	}

	public ShuangTaiBingPo(CombatSkillKey skillKey)
		: base(skillKey, 16302)
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
			ReduceEnemyBreathStance(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (hit && index <= 2 && context.Defender == base.CombatChar && base.CanAffect)
		{
			ReduceEnemyBreathStance(context);
		}
	}

	private void ReduceEnemyBreathStance(DataContext context)
	{
		ChangeStanceValue(context, base.CurrEnemyChar, -400);
		ChangeBreathValue(context, base.CurrEnemyChar, -3000);
		ShowSpecialEffectTips(0);
	}
}
