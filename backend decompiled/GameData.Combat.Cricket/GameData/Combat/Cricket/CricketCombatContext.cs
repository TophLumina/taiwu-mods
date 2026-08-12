using System;
using System.Collections.Generic;

namespace GameData.Combat.Cricket;

public class CricketCombatContext
{
	private readonly ICricketExternalBridge? _independentBridge;

	public readonly CricketCombatData CricketL;

	public readonly CricketCombatData CricketR;

	public readonly CricketCombatSkillBase? CricketSkillL;

	public readonly CricketCombatSkillBase? CricketSkillR;

	public readonly Queue<CricketCombatLog>? Logs;

	public int DamageMultiplier;

	public ICricketExternalBridge Bridge => _independentBridge ?? CricketExternalBridge.Bridge;

	public int Round { get; private set; }

	public bool AnyFail
	{
		get
		{
			if (!CricketL.IsFail)
			{
				return CricketR.IsFail;
			}
			return true;
		}
	}

	public CricketCombatContext(CricketCombatData cricketL, CricketCombatData cricketR, bool enableLog = false, ICricketExternalBridge? independentBridge = null)
	{
		_independentBridge = independentBridge;
		CricketL = new CricketCombatData(cricketL);
		CricketR = new CricketCombatData(cricketR);
		CricketSkillL = CricketCombatSkillFactory.Create(CricketL);
		CricketSkillR = CricketCombatSkillFactory.Create(CricketR);
		Logs = (enableLog ? new Queue<CricketCombatLog>() : null);
		Round = 1;
		DamageMultiplier = 1;
	}

	public bool Simulate()
	{
		Logs?.Enqueue(ECricketCombatLogEventType.CombatStart);
		ECricketWithoutFightType withoutFightType = CheckWithoutFight();
		Logs?.Enqueue(new CricketCombatLogCheckWithoutFight(withoutFightType));
		if (withoutFightType != ECricketWithoutFightType.None)
		{
			return EndCombat(withoutFightType == ECricketWithoutFightType.Win);
		}
		OnSkillEvent(ECricketCombatSkillEvent.CombatStart);
		while (!AnyFail)
		{
			StepRound();
		}
		return EndCombat(CricketR.IsFail);
	}

	private void StepRound()
	{
		Logs?.Enqueue(new CricketCombatLogRoundStart(Round));
		OnSkillEvent(ECricketCombatSkillEvent.RoundStart);
		if (AnyFail)
		{
			return;
		}
		DoVigorAttack();
		if (AnyFail)
		{
			return;
		}
		bool leftFirst = CheckLeftFirst();
		CricketCombatData first = (leftFirst ? CricketL : CricketR);
		CricketCombatData second = (leftFirst ? CricketR : CricketL);
		DoNormalAttack(first, second);
		if (!AnyFail)
		{
			Logs?.Enqueue(new CricketCombatLogInterlude(leftFirst));
			DoNormalAttack(second, first);
			if (!AnyFail)
			{
				OnSkillEvent(ECricketCombatSkillEvent.RoundEnd);
				CricketL.ClearRoundPropertyModify();
				CricketR.ClearRoundPropertyModify();
				Logs?.Enqueue(new CricketCombatLogRoundEnd(Round, leftFirst));
				Round++;
			}
		}
	}

	private bool EndCombat(bool win)
	{
		OnSkillEvent(ECricketCombatSkillEvent.CombatEnd, new CricketCombatSkillContext
		{
			Winner = (win ? CricketL : CricketR)
		});
		Logs?.Enqueue(new CricketCombatLogCombatEnd(win));
		return win;
	}

	public ECricketWithoutFightType CheckWithoutFight()
	{
		if (CricketL.IsTrash && CricketR.IsTrash)
		{
			if (!Bridge.CheckPercentProb(50))
			{
				return ECricketWithoutFightType.Lose;
			}
			return ECricketWithoutFightType.Win;
		}
		if (CricketL.IsTrash != CricketR.IsTrash)
		{
			if (!CricketL.IsTrash)
			{
				return ECricketWithoutFightType.Win;
			}
			return ECricketWithoutFightType.Lose;
		}
		int gradeGap = System.Math.Abs(CricketL.Grade - CricketR.Grade);
		if (gradeGap >= 6 && Bridge.CheckPercentProb(gradeGap * 10))
		{
			if (CricketL.Grade <= CricketR.Grade)
			{
				return ECricketWithoutFightType.Lose;
			}
			return ECricketWithoutFightType.Win;
		}
		return ECricketWithoutFightType.None;
	}

	private bool CheckLeftFirst()
	{
		if (CricketL.Vigor != CricketR.Vigor)
		{
			return Bridge.CheckPercentProb((CricketL.Vigor > CricketR.Vigor) ? 80 : 20);
		}
		return Bridge.CheckPercentProb(50);
	}

	private ECricketCombatAttackStatus CheckStatus(CricketCombatData attacker, CricketCombatData defender, ECricketCombatDamageType type)
	{
		ECricketCombatAttackStatus status = ECricketCombatAttackStatus.None;
		if ((uint)(type - 1) > 1u)
		{
			return status;
		}
		if (CheckStatusBySkillEffect(attacker, defender, ECricketCombatSkillEvent.CheckCritical))
		{
			status |= ECricketCombatAttackStatus.Critical;
		}
		if (CheckStatusBySkillEffect(attacker, defender, ECricketCombatSkillEvent.CheckParry))
		{
			status |= ECricketCombatAttackStatus.Parry;
		}
		return status;
	}

	private bool CheckStatusBySkillEffect(CricketCombatData attacker, CricketCombatData defender, ECricketCombatSkillEvent @event)
	{
		bool checkResult = ((@event == ECricketCombatSkillEvent.CheckCritical) ? Bridge.CheckPercentProb(attacker.Deadliness) : Bridge.CheckPercentProb(defender.Defense));
		CricketCombatSkillContext context = new CricketCombatSkillContext
		{
			Attacker = attacker,
			Defender = defender,
			CheckResult = checkResult
		};
		return SkillModifyCheckResult(context, @event);
	}

	private unsafe CricketInjury RandomNewInjury(CricketCombatData attacker)
	{
		CricketInjury result = default(CricketInjury);
		int odds = attacker.Deadliness + attacker.Cripple;
		if (!Bridge.CheckPercentProb(odds))
		{
			return result;
		}
		if (Bridge.CheckPercentProb(35))
		{
			(*(int*)(Bridge.Next(3) switch
			{
				1 => ref result.Strength, 
				0 => ref result.Vigor, 
				_ => ref result.Bite, 
			}))++;
		}
		else
		{
			Bridge.Next(2) == 0 ? ref result.Hp : ref result.Sp += 5;
		}
		return result;
	}

	public void DoAttack(CricketCombatData attacker, CricketCombatData defender, ECricketCombatDamageType type, int counterTimes = 0)
	{
		int baseDamage = attacker.GetBaseDamage(type);
		ECricketCombatAttackStatus status = CheckStatus(attacker, defender, type);
		baseDamage = ApplyStatus(attacker, defender, status, baseDamage);
		if (counterTimes > 0)
		{
			status |= ECricketCombatAttackStatus.Counter;
		}
		CricketCombatSkillContext context = new CricketCombatSkillContext
		{
			Attacker = attacker,
			Defender = defender,
			DamageType = type,
			Status = status
		};
		CricketCombatDamage damage = CricketCombatDamage.Create(type, baseDamage);
		context.CheckResult = status.Contains(ECricketCombatAttackStatus.Critical) || counterTimes > 0;
		if (SkillModifyCheckResult(context, ECricketCombatSkillEvent.ExtraVigor))
		{
			damage.Sp += attacker.Vigor;
		}
		if (status.Contains(ECricketCombatAttackStatus.Critical) && !status.Contains(ECricketCombatAttackStatus.Parry))
		{
			damage.Durability++;
			damage.Injury = RandomNewInjury(attacker);
		}
		DoDamage(attacker, defender, type, damage, status);
	}

	public void DoDamage(CricketCombatData attacker, CricketCombatData defender, ECricketCombatDamageType type, CricketCombatDamage damage, ECricketCombatAttackStatus status = ECricketCombatAttackStatus.None)
	{
		damage *= DamageMultiplier;
		CricketCombatSkillContext context = new CricketCombatSkillContext
		{
			Attacker = attacker,
			Defender = defender,
			DamageType = type,
			Status = status
		};
		damage = SkillModify(context, ECricketCombatSkillEvent.CheckDamage, damage);
		defender.ApplyDamage(damage);
		Logs?.Enqueue(new CricketCombatLogDamage(attacker, defender, damage, type, status));
		if (!AnyFail)
		{
			OnSkillEvent(ECricketCombatSkillEvent.DoDamage, context);
		}
	}

	private void DoVigorAttack()
	{
		if (CricketL.Vigor != CricketR.Vigor)
		{
			bool num = CricketL.Vigor > CricketR.Vigor;
			CricketCombatData attacker = (num ? CricketL : CricketR);
			CricketCombatData defender = (num ? CricketR : CricketL);
			DoAttack(attacker, defender, ECricketCombatDamageType.Vigor);
		}
	}

	private void DoNormalAttack(CricketCombatData attacker, CricketCombatData defender)
	{
		int counterTimes = -1;
		do
		{
			counterTimes++;
			ECricketCombatDamageType type = ((counterTimes % 2 != 0) ? ECricketCombatDamageType.Strength : ECricketCombatDamageType.Bite);
			DoAttack(attacker, defender, type, counterTimes);
			if (!AnyFail)
			{
				CricketCombatData cricketCombatData = defender;
				defender = attacker;
				attacker = cricketCombatData;
				continue;
			}
			break;
		}
		while (Bridge.CheckPercentProb(attacker.Counter - counterTimes * 5));
	}

	private int ApplyStatus(CricketCombatData attacker, CricketCombatData defender, ECricketCombatAttackStatus status, int baseDamage)
	{
		if (status.Contains(ECricketCombatAttackStatus.Critical))
		{
			baseDamage += attacker.Damage;
		}
		if (status.Contains(ECricketCombatAttackStatus.Parry))
		{
			baseDamage -= defender.DamageReduce;
		}
		return System.Math.Max(baseDamage, 0);
	}

	public CricketCombatData GetOther(CricketCombatData owner)
	{
		if (owner != CricketL)
		{
			return CricketL;
		}
		return CricketR;
	}

	public CricketCombatSkillBase? GetOtherSkill(CricketCombatData owner)
	{
		if (owner != CricketL)
		{
			return CricketSkillL;
		}
		return CricketSkillR;
	}

	private void OnSkillEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext? context = null)
	{
		if (context == null)
		{
			context = new CricketCombatSkillContext();
		}
		context.TopContext = this;
		ECricketCombatSkillPriority num = CricketSkillL?.GetPriority(@event) ?? ECricketCombatSkillPriority.Normal;
		ECricketCombatSkillPriority priorityR = CricketSkillR?.GetPriority(@event) ?? ECricketCombatSkillPriority.Normal;
		CricketCombatSkillBase second;
		CricketCombatSkillBase first;
		if (num > priorityR)
		{
			CricketCombatSkillBase? cricketSkillR = CricketSkillR;
			CricketCombatSkillBase cricketSkillL = CricketSkillL;
			second = cricketSkillL;
			first = cricketSkillR;
		}
		else
		{
			CricketCombatSkillBase? cricketSkillL2 = CricketSkillL;
			CricketCombatSkillBase cricketSkillL = CricketSkillR;
			second = cricketSkillL;
			first = cricketSkillL2;
		}
		context.FirstSkill = first;
		context.SecondSkillPrechecked = second?.PreCheck(@event, context) ?? false;
		if (first != null && first.PreCheck(@event, context))
		{
			first.OnEvent(@event, context);
		}
		if (context.SecondSkillPrechecked)
		{
			second?.OnEvent(@event, context);
		}
	}

	private bool SkillModifyCheckResult(CricketCombatSkillContext context, ECricketCombatSkillEvent @event)
	{
		OnSkillEvent(@event, context);
		return context.CheckResult;
	}

	private CricketCombatDamage SkillModify(CricketCombatSkillContext context, ECricketCombatSkillEvent @event, CricketCombatDamage damage)
	{
		context.Damage = damage;
		OnSkillEvent(@event, context);
		return context.Damage ?? damage;
	}
}
