using System;
using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.World;

/// <summary>
/// 进入新世界时的世界创建信息
/// </summary>
[Serializable]
public struct WorldCreationInfo : ISerializableGameData
{
	/// <summary>
	/// 难度等级的枚举
	/// </summary>
	public enum EDifficultyLevel
	{
		Level1,
		Level2,
		Level3,
		Level4,
		Custom
	}

	/// <summary>
	/// 世界人口类型.
	/// <see cref="T:GameData.Domains.World.WorldPopulationType" />
	/// </summary>
	[SerializableGameDataField]
	public byte WorldPopulationType;

	/// <summary>
	/// 角色寿命类型.
	/// <see cref="T:GameData.Domains.World.CharacterLifespanType" />
	/// </summary>
	[SerializableGameDataField]
	public byte CharacterLifespanType;

	/// <summary>
	/// 战斗难度.
	/// <see cref="T:GameData.Domains.World.Difficulty" />
	/// </summary>
	[SerializableGameDataField]
	public byte CombatDifficulty;

	/// <summary>
	/// 研读难度
	/// <see cref="T:GameData.Domains.World.Difficulty" />
	/// </summary>
	[SerializableGameDataField]
	public byte ReadingDifficulty;

	/// <summary>
	/// 突破难度
	/// <see cref="T:GameData.Domains.World.Difficulty" />
	/// </summary>
	[SerializableGameDataField]
	public byte BreakoutDifficulty;

	/// <summary>
	/// 周天难度
	/// <see cref="T:GameData.Domains.World.Difficulty" />
	/// </summary>
	[SerializableGameDataField]
	public byte LoopingDifficulty;

	/// <summary>
	/// 敌人的修习
	/// <see cref="F:Config.WorldCreation.DefKey.EnemyPracticeLevel" />
	/// </summary>
	[SerializableGameDataField]
	public byte EnemyPracticeLevel;

	/// <summary>
	/// 人情的变化
	/// <see cref="F:Config.WorldCreation.DefKey.FavorabilityChange" />
	/// </summary>
	[SerializableGameDataField]
	public byte FavorabilityChange;

	/// <summary>
	/// 地图上的外道数量的类型.
	/// <see cref="T:GameData.Domains.World.HereticsAmountType" />
	/// </summary>
	[SerializableGameDataField]
	public byte HereticsAmountType;

	/// <summary>
	/// 侵袭的速度类型.
	/// <see cref="T:GameData.Domains.World.BossInvasionSpeedType" />
	/// </summary>
	[SerializableGameDataField]
	public byte BossInvasionSpeedType;

	/// <summary>
	/// 世界的资源数量类型.
	/// <see cref="T:GameData.Domains.World.WorldResourceAmountType" />
	/// </summary>
	[SerializableGameDataField]
	public byte WorldResourceAmountType;

	/// <summary>
	/// 志向的成长类型
	/// <see cref="T:GameData.Domains.World.Difficulty" />
	/// </summary>
	[SerializableGameDataField]
	public byte ProfessionUpgrade;

	/// <summary>
	/// 战利品收获率类型
	/// </summary>
	[SerializableGameDataField]
	public short LootYield;

	/// <summary>
	/// 是否允许随机太吾继承人
	/// </summary>
	[SerializableGameDataField]
	public bool AllowRandomTaiwuHeir;

	/// <summary>
	/// 是否只允许选择符合立场的选项
	/// </summary>
	[SerializableGameDataField]
	public bool RestrictOptionsBehaviorType;

	/// <summary>
	/// 太吾村所在洲
	/// </summary>
	[SerializableGameDataField]
	public sbyte TaiwuVillageStateTemplateId;

	/// <summary>
	/// 太吾村地貌类型.
	/// <see cref="T:GameData.Domains.World.LandFormType" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte TaiwuVillageLandFormType;

	/// <summary>
	/// 获取单个设置
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
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

	/// <summary>
	/// 修改单个设置
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="value"></param>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
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

	/// <summary>
	/// 根据难度预设创建世界细节
	/// </summary>
	/// <param name="difficulty"></param>
	/// <returns></returns>
	public static WorldCreationInfo CreateByDifficultyPreset(sbyte difficulty)
	{
		WorldCreationInfo creationInfo = default(WorldCreationInfo);
		foreach (WorldCreationItem worldCreationCfg in (IEnumerable<WorldCreationItem>)WorldCreation.Instance)
		{
			creationInfo.Set(worldCreationCfg.TemplateId, (byte)worldCreationCfg.DifficultyPreset[difficulty]);
		}
		return creationInfo;
	}

	/// <summary>
	/// 根据难度设置获取最小难度，结果不会是自定义，略过了常规分组
	/// </summary>
	/// <param name="worldCreationInfo"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取指定分组的综合难度等级
	/// </summary>
	/// <param name="groupId"></param>
	/// <returns></returns>
	/// <exception cref="T:System.Exception"></exception>
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

	/// <summary>
	/// 获取指定分组的遗惠得分
	/// </summary>
	/// <param name="groupId"></param>
	/// <returns></returns>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 18;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
