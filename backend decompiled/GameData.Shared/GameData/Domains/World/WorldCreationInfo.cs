using System;
using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.World;

[Serializable]
public struct WorldCreationInfo : ISerializableGameData
{
	public enum EDifficultyLevel
	{
		Level1,
		Level2,
		Level3,
		Level4,
		Custom
	}

	[SerializableGameDataField]
	public byte WorldPopulationType;

	[SerializableGameDataField]
	public byte CharacterLifespanType;

	[SerializableGameDataField]
	public byte CombatDifficulty;

	[SerializableGameDataField]
	public byte ReadingDifficulty;

	[SerializableGameDataField]
	public byte BreakoutDifficulty;

	[SerializableGameDataField]
	public byte LoopingDifficulty;

	[SerializableGameDataField]
	public byte EnemyPracticeLevel;

	[SerializableGameDataField]
	public byte FavorabilityChange;

	[SerializableGameDataField]
	public byte HereticsAmountType;

	[SerializableGameDataField]
	public byte BossInvasionSpeedType;

	[SerializableGameDataField]
	public byte WorldResourceAmountType;

	[SerializableGameDataField]
	public byte ProfessionUpgrade;

	[SerializableGameDataField]
	public short LootYield;

	[SerializableGameDataField]
	public bool AllowRandomTaiwuHeir;

	[SerializableGameDataField]
	public bool RestrictOptionsBehaviorType;

	[SerializableGameDataField]
	public sbyte TaiwuVillageStateTemplateId;

	[SerializableGameDataField]
	public sbyte TaiwuVillageLandFormType;

	public int Get(byte templateId)
	{
		return templateId switch
		{
			0 => CharacterLifespanType, 
			1 => CombatDifficulty, 
			2 => ReadingDifficulty, 
			3 => BreakoutDifficulty, 
			4 => LoopingDifficulty, 
			5 => HereticsAmountType, 
			6 => BossInvasionSpeedType, 
			7 => WorldResourceAmountType, 
			8 => WorldPopulationType, 
			9 => (!RestrictOptionsBehaviorType) ? 1 : 0, 
			10 => (!AllowRandomTaiwuHeir) ? 1 : 0, 
			11 => EnemyPracticeLevel, 
			12 => FavorabilityChange, 
			13 => ProfessionUpgrade, 
			14 => LootYield, 
			_ => throw new ArgumentOutOfRangeException("templateId", templateId, null), 
		};
	}

	public void Set(byte templateId, byte value)
	{
		switch (templateId)
		{
		case 0:
			CharacterLifespanType = value;
			break;
		case 1:
			CombatDifficulty = value;
			break;
		case 2:
			ReadingDifficulty = value;
			break;
		case 3:
			BreakoutDifficulty = value;
			break;
		case 4:
			LoopingDifficulty = value;
			break;
		case 5:
			HereticsAmountType = value;
			break;
		case 6:
			BossInvasionSpeedType = value;
			break;
		case 7:
			WorldResourceAmountType = value;
			break;
		case 8:
			WorldPopulationType = value;
			break;
		case 9:
			RestrictOptionsBehaviorType = value == 0;
			break;
		case 10:
			AllowRandomTaiwuHeir = value == 0;
			break;
		case 11:
			EnemyPracticeLevel = value;
			break;
		case 12:
			FavorabilityChange = value;
			break;
		case 13:
			ProfessionUpgrade = value;
			break;
		case 14:
			LootYield = value;
			break;
		default:
			throw new ArgumentOutOfRangeException("templateId", templateId, null);
		}
	}

	public static WorldCreationInfo CreateByDifficultyPreset(sbyte difficulty)
	{
		WorldCreationInfo creationInfo = default(WorldCreationInfo);
		foreach (WorldCreationItem worldCreationCfg in (IEnumerable<WorldCreationItem>)WorldCreation.Instance)
		{
			creationInfo.Set(worldCreationCfg.TemplateId, (byte)worldCreationCfg.DifficultyPreset[difficulty]);
		}
		return creationInfo;
	}

	public static sbyte GetMinDifficulty(WorldCreationInfo worldCreationInfo)
	{
		sbyte difficulty = 3;
		foreach (WorldCreationGroupItem worldCreationGroupItem in (IEnumerable<WorldCreationGroupItem>)WorldCreationGroup.Instance)
		{
			if (worldCreationGroupItem.TemplateId == 3)
			{
				continue;
			}
			byte[] worldCreations = worldCreationGroupItem.WorldCreations;
			if (worldCreations != null && worldCreations.Length > 0)
			{
				worldCreations = worldCreationGroupItem.WorldCreations;
				foreach (byte worldCreation in worldCreations)
				{
					sbyte value = (sbyte)worldCreationInfo.Get(worldCreation);
					int itemDifficulty = WorldCreation.Instance[worldCreation].DifficultyPreset.IndexOf(value);
					difficulty = (sbyte)Math.Min(difficulty, itemDifficulty);
				}
			}
		}
		return Math.Max(difficulty, 0);
	}

	public int GetGroupLevel(sbyte groupId)
	{
		int legacyBonusSum = GetGroupLegacyBonusSum(groupId);
		for (sbyte i = (sbyte)(GlobalConfig.Instance.LegacyGroupLevelThresholds.Length - 1); i >= 0; i--)
		{
			if (legacyBonusSum >= GlobalConfig.Instance.LegacyGroupLevelThresholds[i])
			{
				return i;
			}
		}
		throw new Exception($"Invalid legacy bonus sum {legacyBonusSum} for group {groupId}.");
	}

	public int GetGroupLegacyBonusSum(sbyte groupId)
	{
		WorldCreationGroupItem worldCreationGroupItem = WorldCreationGroup.Instance[groupId];
		int legacyBonusSum = 0;
		byte[] worldCreations = worldCreationGroupItem.WorldCreations;
		foreach (byte templateId in worldCreations)
		{
			WorldCreationItem creationCfg = WorldCreation.Instance[templateId];
			int value = Get(templateId);
			if (creationCfg.LegacyPointBonus.CheckIndex(value))
			{
				legacyBonusSum += creationCfg.LegacyPointBonus[value];
			}
		}
		return legacyBonusSum;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 18;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = WorldPopulationType;
		byte* num = pData + 1;
		*num = CharacterLifespanType;
		byte* num2 = num + 1;
		*num2 = CombatDifficulty;
		byte* num3 = num2 + 1;
		*num3 = ReadingDifficulty;
		byte* num4 = num3 + 1;
		*num4 = BreakoutDifficulty;
		byte* num5 = num4 + 1;
		*num5 = LoopingDifficulty;
		byte* num6 = num5 + 1;
		*num6 = EnemyPracticeLevel;
		byte* num7 = num6 + 1;
		*num7 = FavorabilityChange;
		byte* num8 = num7 + 1;
		*num8 = HereticsAmountType;
		byte* num9 = num8 + 1;
		*num9 = BossInvasionSpeedType;
		byte* num10 = num9 + 1;
		*num10 = WorldResourceAmountType;
		byte* num11 = num10 + 1;
		*num11 = ProfessionUpgrade;
		byte* num12 = num11 + 1;
		*(short*)num12 = LootYield;
		byte* num13 = num12 + 2;
		*num13 = (AllowRandomTaiwuHeir ? ((byte)1) : ((byte)0));
		byte* num14 = num13 + 1;
		*num14 = (RestrictOptionsBehaviorType ? ((byte)1) : ((byte)0));
		byte* num15 = num14 + 1;
		*num15 = (byte)TaiwuVillageStateTemplateId;
		byte* num16 = num15 + 1;
		*num16 = (byte)TaiwuVillageLandFormType;
		int totalSize = (int)(num16 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		WorldPopulationType = *pCurrData;
		pCurrData++;
		CharacterLifespanType = *pCurrData;
		pCurrData++;
		CombatDifficulty = *pCurrData;
		pCurrData++;
		ReadingDifficulty = *pCurrData;
		pCurrData++;
		BreakoutDifficulty = *pCurrData;
		pCurrData++;
		LoopingDifficulty = *pCurrData;
		pCurrData++;
		EnemyPracticeLevel = *pCurrData;
		pCurrData++;
		FavorabilityChange = *pCurrData;
		pCurrData++;
		HereticsAmountType = *pCurrData;
		pCurrData++;
		BossInvasionSpeedType = *pCurrData;
		pCurrData++;
		WorldResourceAmountType = *pCurrData;
		pCurrData++;
		ProfessionUpgrade = *pCurrData;
		pCurrData++;
		LootYield = *(short*)pCurrData;
		pCurrData += 2;
		AllowRandomTaiwuHeir = *pCurrData != 0;
		pCurrData++;
		RestrictOptionsBehaviorType = *pCurrData != 0;
		pCurrData++;
		TaiwuVillageStateTemplateId = (sbyte)(*pCurrData);
		pCurrData++;
		TaiwuVillageLandFormType = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
