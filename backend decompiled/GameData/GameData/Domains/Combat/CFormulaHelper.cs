using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat;

public static class CFormulaHelper
{
	public static int CalcAttackStartupOrRecoveryFrame(this Weapon weapon, int attackSpeed, int baseFrame)
	{
		int weaponFrame = CFormula.CalcAttackStartupOrRecoveryWeaponFrame(weapon.GetWeight(), weapon.GetBaseWeight(), baseFrame);
		return CFormula.CalcAttackStartupOrRecoveryFrame(attackSpeed, weaponFrame);
	}

	public static CValuePercentBonus CalcConsummateChangeDamagePercent(CombatCharacter attacker, CombatCharacter defender)
	{
		GameData.Domains.Character.Character attackerChar = attacker.GetCharacter();
		sbyte attackerConsummate = attackerChar.GetEffectiveConsummateLevel();
		GameData.Domains.Character.Character defenderChar = defender.GetCharacter();
		sbyte defenderConsummate = defenderChar.GetEffectiveConsummateLevel();
		CValuePercentBonus bonus = CFormula.CalcConsummateChangeDamagePercent(attackerConsummate, defenderConsummate);
		int charId = ((attackerConsummate == defenderConsummate) ? (-1) : ((attackerConsummate > defenderConsummate) ? attacker.GetId() : defender.GetId()));
		return (charId < 0) ? bonus : ((CValuePercentBonus)DomainManager.SpecialEffect.ModifyValue(charId, 296, (int)bonus));
	}

	public static int CalcCostChangeTrickCount(CombatCharacter combatChar, EFlawOrAcupointType flawOrAcupointType)
	{
		Weapon weapon = DomainManager.Item.GetElement_Weapons(DomainManager.Combat.GetUsingWeaponKey(combatChar).Id);
		int costChangeTrickCount = weapon.GetAttackPreparePointCost() + 1;
		int num = costChangeTrickCount;
		if (1 == 0)
		{
		}
		int num2 = flawOrAcupointType switch
		{
			EFlawOrAcupointType.None => 1, 
			EFlawOrAcupointType.Flaw => GlobalConfig.Instance.ChangeTrickMultiplierFlaw, 
			EFlawOrAcupointType.Acupoint => GlobalConfig.Instance.ChangeTrickMultiplierAcupoint, 
			_ => throw new ArgumentOutOfRangeException("flawOrAcupointType", flawOrAcupointType, null), 
		};
		if (1 == 0)
		{
		}
		return num * num2;
	}

	public static int CalcTeamWisdomCount(IReadOnlyList<int> teamCharIds)
	{
		if (teamCharIds == null || teamCharIds.Count <= 0)
		{
			return 0;
		}
		int mainValue = DomainManager.Character.GetCharacterWisdomCount(teamCharIds[0]);
		int teammateValue = 0;
		int teammateCharCount = 0;
		for (int i = 1; i < teamCharIds.Count; i++)
		{
			if (teamCharIds[i] >= 0)
			{
				teammateValue += DomainManager.Character.GetCharacterWisdomCount(teamCharIds[i]);
				teammateCharCount++;
			}
		}
		mainValue *= CFormula.CalcMainCharacterWisdomMultiplier(teammateCharCount);
		return mainValue + teammateValue;
	}

	public static int CalcTeamLucky(IReadOnlyList<int> teamCharIds)
	{
		if (teamCharIds == null || teamCharIds.Count <= 0)
		{
			return 0;
		}
		int total = 0;
		foreach (int charId in teamCharIds)
		{
			if (charId >= 0)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				total += character.GetPersonality(5);
			}
		}
		return total;
	}

	public static EPrepareCombatResult RandomPrepareResult(int selfCharId, int enemyCharId, IRandomSource random = null)
	{
		List<int> selfTeam = ObjectPool<List<int>>.Instance.Get();
		List<int> enemyTeam = ObjectPool<List<int>>.Instance.Get();
		selfTeam.Add(selfCharId);
		enemyTeam.Add(enemyCharId);
		EPrepareCombatResult type = RandomPrepareResult(selfTeam, enemyTeam, random);
		ObjectPool<List<int>>.Instance.Return(selfTeam);
		ObjectPool<List<int>>.Instance.Return(enemyTeam);
		return type;
	}

	public static EPrepareCombatResult RandomPrepareResult(IReadOnlyList<int> selfTeam, IReadOnlyList<int> enemyTeam, IRandomSource random = null)
	{
		if (selfTeam == null || selfTeam.Count <= 0 || enemyTeam == null || enemyTeam.Count <= 0)
		{
			return EPrepareCombatResult.Invalid;
		}
		int selfWisdom = Math.Abs(CalcTeamWisdomCount(selfTeam));
		int enemyWisdom = Math.Abs(CalcTeamWisdomCount(enemyTeam));
		if (selfWisdom < enemyWisdom)
		{
			return EPrepareCombatResult.EnemyFirst;
		}
		if (selfWisdom > enemyWisdom)
		{
			return EPrepareCombatResult.SelfFirst;
		}
		if (random == null)
		{
			return EPrepareCombatResult.EqualsRandom;
		}
		int selfLuck = CalcTeamLucky(selfTeam);
		int enemyLuck = CalcTeamLucky(enemyTeam);
		int selfProb = 50 + selfLuck - enemyLuck;
		return (!random.CheckPercentProb(selfProb)) ? EPrepareCombatResult.EnemyFirst : EPrepareCombatResult.SelfFirst;
	}
}
