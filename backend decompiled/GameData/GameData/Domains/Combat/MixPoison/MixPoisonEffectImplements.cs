using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Combat.MixPoison;

public static class MixPoisonEffectImplements
{
	[MixPoisonEffect(12)]
	public static bool MixPoisonEffect012(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		int changeValue = 300 * (poisonMarkList[0] + poisonMarkList[1] + poisonMarkList[2]);
		DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, combatChar, changeValue);
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1654, 0);
		return true;
	}

	[MixPoisonEffect(8)]
	public static bool MixPoisonEffect013(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		int reducePercent = (poisonMarkList[0] + poisonMarkList[1] + poisonMarkList[3]) * 5 - 5;
		DomainManager.Combat.ChangeMobilityValue(context, combatChar, -MoveSpecialConstants.MaxMobility * reducePercent / 100, changedByEffect: true, combatChar);
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1650, 0);
		return true;
	}

	[MixPoisonEffect(2)]
	public static bool MixPoisonEffect014(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		int affectOdds = poisonMarkList[4] * 20;
		if (!context.Random.CheckPercentProb(affectOdds))
		{
			return false;
		}
		if (!combatChar.ChangeToEmptyHandOrOther(context))
		{
			return false;
		}
		ItemKey[] weapons = combatChar.GetWeapons();
		for (int i = 0; i < 7; i++)
		{
			if (i != combatChar.GetUsingWeaponIndex() && weapons[i].IsValid())
			{
				combatChar.GetWeaponData(i).SetCdFrame(30000, context);
			}
		}
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1644, 0);
		return true;
	}

	[MixPoisonEffect(18)]
	public static bool MixPoisonEffect015(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		NeiliAllocation neiliAllocation = combatChar.GetNeiliAllocation();
		int changeValue = -10 * poisonMarkList[5];
		List<byte> neiliAllocationTypeRandomPool = ObjectPool<List<byte>>.Instance.Get();
		bool affected = false;
		neiliAllocationTypeRandomPool.Clear();
		for (byte type = 0; type < 4; type++)
		{
			if (neiliAllocation[type] > 0)
			{
				neiliAllocationTypeRandomPool.Add(type);
			}
		}
		if (neiliAllocationTypeRandomPool.Count > 0)
		{
			combatChar.ChangeNeiliAllocation(context, neiliAllocationTypeRandomPool[context.Random.Next(0, neiliAllocationTypeRandomPool.Count)], changeValue);
			DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1660, 0);
			affected = true;
		}
		ObjectPool<List<byte>>.Instance.Return(neiliAllocationTypeRandomPool);
		return affected;
	}

	[MixPoisonEffect(9)]
	public static bool MixPoisonEffect023(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		Injuries injuries = combatChar.GetInjuries();
		int markCount = poisonMarkList[0] + poisonMarkList[2] + poisonMarkList[3];
		int addInjuryOdds = 20 * markCount;
		List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		bodyPartRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			if (injuries.Get(part, isInnerInjury: false) < 6)
			{
				bodyPartRandomPool.Add(part);
			}
		}
		if (bodyPartRandomPool.Count == 0)
		{
			for (sbyte part2 = 0; part2 < 7; part2++)
			{
				bodyPartRandomPool.Add(part2);
			}
		}
		sbyte affectPart = bodyPartRandomPool.GetRandom(context.Random);
		if (context.Random.CheckPercentProb(addInjuryOdds) && injuries.Get(affectPart, isInnerInjury: false) < 6)
		{
			combatChar.AddInjury(context, affectPart, isInner: false, 1, updateDefeatMark: true, changeToOld: true);
			DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1651, 0);
		}
		else
		{
			DomainManager.Combat.AddFlaw(context, combatChar, (sbyte)Math.Max(markCount / 3 - 1, 0), new CombatSkillKey(-1, -1), affectPart);
			DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1651, 1);
		}
		ObjectPool<List<sbyte>>.Instance.Return(bodyPartRandomPool);
		return true;
	}

	[MixPoisonEffect(3)]
	public static bool MixPoisonEffect024(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		int markCount = poisonMarkList[4];
		DomainManager.Combat.PoisonProduce(context, combatChar, 0, markCount);
		combatChar.AddPoisonAffectValue(3, (short)(20 * markCount), needLessThanThreshold: true);
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1645, 0);
		return true;
	}

	[MixPoisonEffect(15)]
	public static bool MixPoisonEffect025(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		int markCount = poisonMarkList[5];
		DomainManager.Combat.PoisonProduce(context, combatChar, 5, markCount);
		combatChar.AddPoisonAffectValue(1, (short)(markCount * 5 + 5), needLessThanThreshold: true);
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1657, 0);
		return true;
	}

	[MixPoisonEffect(0)]
	public static bool MixPoisonEffect034(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		combatChar.AddFatalMark(context, poisonMarkList[4], -1, -1);
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1642, 0);
		return true;
	}

	[MixPoisonEffect(7)]
	public static bool MixPoisonEffect035(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		for (int i = 0; i < poisonMarkList[5]; i++)
		{
			DomainManager.Combat.AddWeaponAttackSelfInjury(context, combatChar, combatChar.GetUsingWeaponIndex());
		}
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1649, 0);
		return true;
	}

	[MixPoisonEffect(1)]
	public static bool MixPoisonEffect045(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		short skillId = combatChar.GetRandomBanableSkillId(context.Random, null, 2);
		if (skillId < 0)
		{
			return false;
		}
		DomainManager.Combat.ClearAffectingAgileSkillByEffect(context, combatChar);
		DomainManager.Combat.SilenceSkill(context, combatChar, skillId, (short)(600 * (poisonMarkList[4] + poisonMarkList[5])));
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1643, 0);
		return true;
	}

	[MixPoisonEffect(13)]
	public static bool MixPoisonEffect123(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		Injuries injuries = combatChar.GetInjuries();
		int markCount = poisonMarkList[1] + poisonMarkList[2] + poisonMarkList[3];
		int addInjuryOdds = 20 * markCount;
		List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		bodyPartRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			if (injuries.Get(part, isInnerInjury: true) < 6)
			{
				bodyPartRandomPool.Add(part);
			}
		}
		if (bodyPartRandomPool.Count == 0)
		{
			for (sbyte part2 = 0; part2 < 7; part2++)
			{
				bodyPartRandomPool.Add(part2);
			}
		}
		sbyte affectPart = bodyPartRandomPool.GetRandom(context.Random);
		if (context.Random.CheckPercentProb(addInjuryOdds) && injuries.Get(affectPart, isInnerInjury: false) < 6)
		{
			combatChar.AddInjury(context, affectPart, isInner: true, 1, updateDefeatMark: true, changeToOld: true);
			DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1655, 0);
		}
		else
		{
			DomainManager.Combat.AddAcupoint(context, combatChar, (sbyte)Math.Max(markCount / 3 - 1, 0), new CombatSkillKey(-1, -1), affectPart);
			DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1655, 1);
		}
		ObjectPool<List<sbyte>>.Instance.Return(bodyPartRandomPool);
		return true;
	}

	[MixPoisonEffect(11)]
	public static bool MixPoisonEffect124(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		List<short> skillIdList = ObjectPool<List<short>>.Instance.Get();
		skillIdList.Clear();
		skillIdList.AddRange(combatChar.GetAttackSkillList());
		skillIdList.RemoveAll((short id) => id < 0);
		if (skillIdList.Count > 0)
		{
			for (int i = 0; i < poisonMarkList[4]; i++)
			{
				DomainManager.Combat.AddGoneMadInjury(context, combatChar, skillIdList.GetRandom(context.Random));
			}
			DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1653, 0);
		}
		ObjectPool<List<short>>.Instance.Return(skillIdList);
		return true;
	}

	[MixPoisonEffect(10)]
	public static bool MixPoisonEffect125(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		combatChar.AddMindMark(context, poisonMarkList[5] * 2, -1);
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1652, 0);
		return true;
	}

	[MixPoisonEffect(5)]
	public static bool MixPoisonEffect134(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		int markCount = poisonMarkList[4];
		DomainManager.Combat.PoisonProduce(context, combatChar, 4, markCount);
		combatChar.AddPoisonAffectValue(0, (short)(markCount + 1), needLessThanThreshold: true);
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1647, 0);
		return true;
	}

	[MixPoisonEffect(19)]
	public static bool MixPoisonEffect135(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		int markCount = poisonMarkList[5];
		DomainManager.Combat.PoisonProduce(context, combatChar, 1, markCount);
		combatChar.AddPoisonAffectValue(2, (short)(20 * markCount), needLessThanThreshold: true);
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1661, 0);
		return true;
	}

	[MixPoisonEffect(17)]
	public static bool MixPoisonEffect145(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		short skillId = combatChar.GetRandomBanableSkillId(context.Random, null, 3);
		if (skillId < 0)
		{
			return false;
		}
		DomainManager.Combat.ClearAffectingDefenseSkill(context, combatChar);
		DomainManager.Combat.SilenceSkill(context, combatChar, skillId, (short)(600 * (poisonMarkList[4] + poisonMarkList[5])));
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1659, 0);
		return true;
	}

	[MixPoisonEffect(6)]
	public static bool MixPoisonEffect234(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		int poisonValue = combatChar.GetPoison()[4];
		sbyte currLevel = PoisonsAndLevels.CalcPoisonedLevel(poisonValue);
		int spreadValue = poisonValue * 10 * poisonMarkList[4] / 100;
		int[] charIdList = (combatChar.IsAlly ? DomainManager.Combat.GetSelfTeam() : DomainManager.Combat.GetEnemyTeam());
		DomainManager.Combat.AddCombatState(context, combatChar, 2, 146, 100 * poisonMarkList[4]);
		foreach (int charId in charIdList)
		{
			if (charId >= 0 && charId != combatChar.GetId())
			{
				DomainManager.Combat.AddPoison(context, combatChar, DomainManager.Combat.GetElement_CombatCharacterDict(charId), 4, currLevel, spreadValue, -1, applySpecialEffect: true, canBounce: false);
			}
		}
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1648, 0);
		return true;
	}

	[MixPoisonEffect(16)]
	public static bool MixPoisonEffect235(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		int poisonValue = combatChar.GetPoison()[5];
		sbyte currLevel = PoisonsAndLevels.CalcPoisonedLevel(poisonValue);
		int spreadValue = poisonValue * 10 * poisonMarkList[5] / 100;
		int[] charIdList = (combatChar.IsAlly ? DomainManager.Combat.GetSelfTeam() : DomainManager.Combat.GetEnemyTeam());
		DomainManager.Combat.AddCombatState(context, combatChar, 2, 147, 100 * poisonMarkList[5]);
		foreach (int charId in charIdList)
		{
			if (charId >= 0 && charId != combatChar.GetId())
			{
				DomainManager.Combat.AddPoison(context, combatChar, DomainManager.Combat.GetElement_CombatCharacterDict(charId), 5, currLevel, spreadValue, -1, applySpecialEffect: true, canBounce: false);
			}
		}
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1658, 0);
		return true;
	}

	[MixPoisonEffect(14)]
	public static bool MixPoisonEffect245(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		short skillId = combatChar.GetRandomBanableSkillId(context.Random, null, 4);
		if (skillId < 0)
		{
			return false;
		}
		DomainManager.Combat.ClearAffectingDefenseSkill(context, combatChar);
		DomainManager.Combat.SilenceSkill(context, combatChar, skillId, (short)(600 * (poisonMarkList[4] + poisonMarkList[5])));
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1656, 0);
		return true;
	}

	[MixPoisonEffect(4)]
	public static bool MixPoisonEffect345(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList)
	{
		short skillId = combatChar.GetRandomBanableSkillId(context.Random, null, 1);
		if (skillId < 0)
		{
			return false;
		}
		DomainManager.Combat.ClearAffectingDefenseSkill(context, combatChar);
		DomainManager.Combat.SilenceSkill(context, combatChar, skillId, (short)(600 * (poisonMarkList[4] + poisonMarkList[5])));
		DomainManager.Combat.ShowSpecialEffectTips(combatChar.GetId(), 1646, 0);
		return true;
	}
}
