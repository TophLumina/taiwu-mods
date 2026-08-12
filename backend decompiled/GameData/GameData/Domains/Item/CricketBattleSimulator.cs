using System;
using GameData.Common;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Utilities;

namespace GameData.Domains.Item;

public static class CricketBattleSimulator
{
	private static CricketBattler _cricketBattlerA;

	private static CricketBattler _cricketBattlerB;

	private static DataContext _dataContext;

	public static void SetBattlers(ItemKey battlerAItemKey, ItemKey battlerBItemKey, DataContext context)
	{
		_dataContext = context;
		_cricketBattlerA = new CricketBattler(battlerAItemKey);
		_cricketBattlerB = new CricketBattler(battlerBItemKey);
	}

	private static bool CheckPercentProb(int percentProb)
	{
		return _dataContext.Random.CheckPercentProb(percentProb);
	}

	public static int GetBattleResult()
	{
		int resultCode = CheckWinBeforeFight();
		if (resultCode >= 0)
		{
			return resultCode;
		}
		while (!_cricketBattlerA.IsFail && !_cricketBattlerB.IsFail)
		{
			int vigorDiff = _cricketBattlerA.Vigor - _cricketBattlerB.Vigor;
			bool battlerAFirstAttack;
			if (vigorDiff > 0)
			{
				_cricketBattlerB.SP -= _cricketBattlerA.Vigor;
				battlerAFirstAttack = CheckPercentProb(80);
			}
			else if (vigorDiff < 0)
			{
				_cricketBattlerA.SP -= _cricketBattlerB.Vigor;
				battlerAFirstAttack = CheckPercentProb(20);
			}
			else
			{
				battlerAFirstAttack = CheckPercentProb(50);
			}
			if (vigorDiff == 0 || ((vigorDiff > 0) ? (!_cricketBattlerB.IsFail) : (!_cricketBattlerA.IsFail)))
			{
				DoNormalAttack(battlerAFirstAttack);
			}
		}
		resultCode = (_cricketBattlerA.IsFail ? 1 : 0);
		_cricketBattlerA = null;
		_cricketBattlerB = null;
		_dataContext = null;
		return resultCode;
	}

	private static int CheckWinBeforeFight()
	{
		int selfLevel = _cricketBattlerA.Level;
		int enemyLevel = _cricketBattlerB.Level;
		if ((!_cricketBattlerA.IsTrash && _cricketBattlerB.IsTrash) || (selfLevel - enemyLevel >= 6 && CheckPercentProb((selfLevel - enemyLevel) * 10)))
		{
			return 0;
		}
		if ((!_cricketBattlerB.IsTrash && _cricketBattlerA.IsTrash) || (enemyLevel - selfLevel >= 6 && CheckPercentProb((enemyLevel - selfLevel) * 10)))
		{
			return 1;
		}
		if (_cricketBattlerA.IsTrash && _cricketBattlerB.IsTrash)
		{
			return (!CheckPercentProb(50)) ? 1 : 0;
		}
		return -1;
	}

	private static void DoNormalAttack(bool battlerAFirstAttack, bool firstAttack = true)
	{
		CricketBattler attacker = (battlerAFirstAttack ? _cricketBattlerA : _cricketBattlerB);
		CricketBattler defender = (battlerAFirstAttack ? _cricketBattlerB : _cricketBattlerA);
		bool critical = CheckPercentProb(attacker.Deadliness);
		bool defend = CheckPercentProb(defender.Defence);
		bool counter = CheckPercentProb(defender.Counter);
		int damage = attacker.Bite + (critical ? attacker.Damage : 0);
		if (defend)
		{
			damage = (int)MathF.Max(damage - defender.DamageReduce, 0f);
		}
		SettleNormalAttackDamage(attacker, defender, battlerAFirstAttack, damage, critical, defend, counter, isCounterAttack: false, firstAttack, 0);
	}

	private static void SettleNormalAttackDamage(CricketBattler attacker, CricketBattler defender, bool battlerAFirstAttack, int damage, bool critical, bool defend, bool canCounter, bool isCounterAttack, bool firstAttack, int counterTimes)
	{
		int spDamage = ((critical || isCounterAttack) ? attacker.Vigor : 0);
		if (defend)
		{
			spDamage = (int)MathF.Max(spDamage - defender.DamageReduce, 0f);
		}
		else if (critical)
		{
			defender.Durability--;
			int injuryOdds = attacker.Deadliness + attacker.Cripple;
			if (CheckPercentProb(injuryOdds))
			{
				int index;
				short value;
				if (CheckPercentProb(35))
				{
					index = EventHelper.GetRandom(2, 5);
					value = 1;
				}
				else
				{
					index = EventHelper.GetRandom(0, 2);
					value = 5;
				}
				defender.CricketData.Injuries[index] += value;
			}
		}
		defender.HP = (int)MathF.Min((int)MathF.Max(defender.HP - damage, 0f), defender.MaxHP);
		defender.SP = (int)MathF.Min((int)MathF.Max(defender.SP - spDamage, 0f), defender.MaxSP);
		if (defender.IsFail)
		{
			return;
		}
		if (canCounter)
		{
			bool counterCritical = CheckPercentProb(defender.Deadliness);
			bool counterDefend = CheckPercentProb(attacker.Defence);
			int counterDamage = ((counterTimes % 2 == 0) ? defender.Strength : defender.Bite) + (critical ? defender.Damage : 0);
			canCounter = CheckPercentProb(attacker.Counter - counterTimes * 5);
			if (counterDefend)
			{
				counterDamage = (int)MathF.Max(counterDamage - attacker.DamageReduce, 0f);
			}
			SettleNormalAttackDamage(defender, attacker, !battlerAFirstAttack, counterDamage, counterCritical, counterDefend, canCounter, isCounterAttack: true, firstAttack, ++counterTimes);
		}
		else
		{
			bool originSelfAttack = ((counterTimes % 2 == 0) ? battlerAFirstAttack : (!battlerAFirstAttack));
			if (firstAttack)
			{
				DoNormalAttack(!originSelfAttack, firstAttack: false);
			}
		}
	}
}
