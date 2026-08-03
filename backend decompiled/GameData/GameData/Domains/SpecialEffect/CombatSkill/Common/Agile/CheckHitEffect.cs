using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

public class CheckHitEffect : AgileSkillBase
{
	private const sbyte ReducePercentUnit = 30;

	protected sbyte CheckHitType;

	private int _hitPercent;

	protected CheckHitEffect()
	{
	}

	protected CheckHitEffect(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_hitPercent = 100;
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (base.CombatChar == (base.IsDirect ? attacker : defender) && pursueIndex <= 0 && _hitPercent > 0)
		{
			CheckHit(context);
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (base.CombatChar == (base.IsDirect ? attacker : defender) && _hitPercent > 0)
		{
			CheckHit(context);
		}
	}

	private void CheckHit(DataContext context)
	{
		if (base.CanAffect && DomainManager.Combat.CheckHit(context, base.CombatChar, CheckHitType, _hitPercent) && HitEffect(context))
		{
			ShowSpecialEffectTips(0);
		}
		_hitPercent -= 30;
	}

	protected virtual bool HitEffect(DataContext context)
	{
		return false;
	}
}
