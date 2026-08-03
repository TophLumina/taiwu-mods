namespace GameData.Combat.Cricket.SkillsImplement;

public class HalfFallenCritical : CricketCombatSkillBase
{
	private bool _hpInvoked;

	private bool _spInvoked;

	private bool _durabilityInvoked;

	private bool _criticalAttacking;

	public override ECricketCombatSkillType Type => ECricketCombatSkillType.HalfFallenCritical;

	public HalfFallenCritical(CricketCombatData owner)
		: base(owner)
	{
	}

	public override ECricketCombatSkillPriority GetPriority(ECricketCombatSkillEvent @event)
	{
		if (@event != ECricketCombatSkillEvent.CheckCritical)
		{
			return base.GetPriority(@event);
		}
		return ECricketCombatSkillPriority.HalfFallenCriticalCheckCritical;
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		return @event switch
		{
			ECricketCombatSkillEvent.DoDamage => PreCheckDoDamage(context), 
			ECricketCombatSkillEvent.CheckCritical => PreCheckCheckCritical(context), 
			_ => false, 
		};
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		switch (@event)
		{
		case ECricketCombatSkillEvent.DoDamage:
			OnEventDoDamage(context);
			break;
		case ECricketCombatSkillEvent.CheckCritical:
			OnEventCheckCritical(context);
			break;
		}
	}

	private bool PreCheckDoDamage(CricketCombatSkillContext context)
	{
		if (context.TopContext == null)
		{
			return false;
		}
		bool num = (!_hpInvoked && Owner.IsHalfFailHp) || (!_spInvoked && Owner.IsHalfFailSp) || (!_durabilityInvoked && Owner.IsHalfFailDurability);
		_hpInvoked = _hpInvoked || Owner.IsHalfFailHp;
		_spInvoked = _spInvoked || Owner.IsHalfFailSp;
		_durabilityInvoked = _durabilityInvoked || Owner.IsHalfFailDurability;
		if (num)
		{
			ShowEffectTips(context);
		}
		return num;
	}

	private void OnEventDoDamage(CricketCombatSkillContext context)
	{
		if (context.TopContext != null)
		{
			_criticalAttacking = true;
			context.TopContext.DoAttack(Owner, context.TopContext.GetOther(Owner), ECricketCombatDamageType.Bite);
			_criticalAttacking = false;
		}
	}

	private bool PreCheckCheckCritical(CricketCombatSkillContext context)
	{
		if (context.Attacker == Owner)
		{
			return _criticalAttacking;
		}
		return false;
	}

	private void OnEventCheckCritical(CricketCombatSkillContext context)
	{
		context.CheckResult = true;
	}
}
