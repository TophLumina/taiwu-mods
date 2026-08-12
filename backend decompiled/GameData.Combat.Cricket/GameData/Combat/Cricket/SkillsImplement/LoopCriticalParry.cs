namespace GameData.Combat.Cricket.SkillsImplement;

public class LoopCriticalParry : CricketCombatSkillBase
{
	private bool _nextCritical;

	private bool _nextParry;

	private bool _isNextCritical;

	private bool _isNextParry;

	public override ECricketCombatSkillType Type => ECricketCombatSkillType.LoopCriticalParry;

	public LoopCriticalParry(CricketCombatData owner)
		: base(owner)
	{
	}

	public override ECricketCombatSkillPriority GetPriority(ECricketCombatSkillEvent @event)
	{
		if ((uint)(@event - 2) > 1u)
		{
			return base.GetPriority(@event);
		}
		return ECricketCombatSkillPriority.LoopCriticalParryCheckCriticalOrParry;
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		int num = @event switch
		{
			ECricketCombatSkillEvent.CheckCritical => (_nextCritical && context.Attacker == Owner) ? 1 : 0, 
			ECricketCombatSkillEvent.CheckParry => (_nextParry && context.Defender == Owner) ? 1 : 0, 
			ECricketCombatSkillEvent.CheckDamage => PreCheckCheckDamage(context) ? 1 : 0, 
			_ => 0, 
		};
		if (num != 0 && @event == ECricketCombatSkillEvent.CheckDamage)
		{
			ShowEffectTips(context);
		}
		return (byte)num != 0;
	}

	private bool PreCheckCheckDamage(CricketCombatSkillContext context)
	{
		if (!context.Status.HasValue)
		{
			return false;
		}
		if (_isNextCritical && context.Attacker == Owner)
		{
			_isNextCritical = false;
		}
		else if (_isNextParry && context.Defender == Owner)
		{
			_isNextParry = false;
		}
		else
		{
			if (context.Status.Value.Contains(ECricketCombatAttackStatus.Critical) && context.Attacker == Owner)
			{
				return true;
			}
			if (context.Status.Value.Contains(ECricketCombatAttackStatus.Parry) && context.Defender == Owner)
			{
				return true;
			}
		}
		return false;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		switch (@event)
		{
		case ECricketCombatSkillEvent.CheckCritical:
			OnEventCheckCritical(context);
			break;
		case ECricketCombatSkillEvent.CheckParry:
			OnEventCheckParry(context);
			break;
		case ECricketCombatSkillEvent.CheckDamage:
			OnEventCheckDamage(context);
			break;
		}
	}

	private void OnEventCheckCritical(CricketCombatSkillContext context)
	{
		context.CheckResult = true;
		_nextCritical = false;
		_isNextCritical = true;
	}

	private void OnEventCheckParry(CricketCombatSkillContext context)
	{
		context.CheckResult = true;
		_nextParry = false;
		_isNextParry = true;
	}

	private void OnEventCheckDamage(CricketCombatSkillContext context)
	{
		if (context.Status.HasValue)
		{
			if (context.Status.Value.Contains(ECricketCombatAttackStatus.Critical) && context.Attacker == Owner)
			{
				_nextParry = true;
			}
			else if (context.Status.Value.Contains(ECricketCombatAttackStatus.Parry) && context.Defender == Owner)
			{
				_nextCritical = true;
			}
		}
	}
}
