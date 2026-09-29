using System;
using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class BuildingBlockData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort BlockIndex = 0;

		public const ushort TemplateId = 1;

		public const ushort Level = 2;

		public const ushort RootBlockIndex = 3;

		public const ushort Durability = 4;

		public const ushort OperationType = 5;

		public const ushort OperationProgress = 6;

		public const ushort OperationStopping = 7;

		public const ushort ShopProgress = 8;

		public const ushort LevelUnlockedFlags = 9;

		public const ushort CumulatedScore = 10;

		public const ushort ArrangementSetting = 11;

		public const ushort SoldItemSetting = 12;

		public const ushort Count = 13;

		public static readonly string[] FieldId2FieldName = new string[13]
		{
			"BlockIndex", "TemplateId", "Level", "RootBlockIndex", "Durability", "OperationType", "OperationProgress", "OperationStopping", "ShopProgress", "LevelUnlockedFlags",
			"CumulatedScore", "ArrangementSetting", "SoldItemSetting"
		};
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short BlockIndex;

	[SerializableGameDataField(FieldIndex = 1)]
	public short TemplateId;

	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte Level;

	[SerializableGameDataField(FieldIndex = 3)]
	public short RootBlockIndex;

	[SerializableGameDataField(FieldIndex = 4)]
	public sbyte Durability;

	[SerializableGameDataField(FieldIndex = 5)]
	public sbyte OperationType;

	[SerializableGameDataField(FieldIndex = 6)]
	public short OperationProgress;

	[SerializableGameDataField(FieldIndex = 7)]
	public bool OperationStopping;

	[SerializableGameDataField(FieldIndex = 9)]
	public ulong LevelUnlockedFlags = 1uL;

	[SerializableGameDataField(FieldIndex = 10)]
	public int CumulatedScore;

	[SerializableGameDataField(FieldIndex = 11)]
	public BuildingOptionAutoGiveMemberPreset ArrangementSetting;

	[SerializableGameDataField(FieldIndex = 12)]
	public BuildingOptionAutoAddSoldItemPreset SoldItemSetting;

	[SerializableGameDataField(FieldIndex = 8)]
	public short ShopProgress { get; private set; }

	public BuildingBlockItem ConfigData => BuildingBlock.Instance[TemplateId];

	public int ShopProgressPercentage => (int)(ShopProgressFill * 100f);

	public float ShopProgressFill
	{
		get
		{
			int needProgress = ConfigData.MaxProduceValue;
			ExternalDataBridge.Context.ChallengeModeData.ApplyChallengeModeBuildingWorkHard(ref needProgress);
			if (needProgress <= 0)
			{
				return 0f;
			}
			return MathUtils.Clamp((float)ShopProgress / (float)needProgress, 0f, 1f);
		}
	}

	public BuildingBlockData(short blockIndex, short templateId, sbyte level, short rootBlockIndex = -1)
	{
		BlockIndex = blockIndex;
		TemplateId = templateId;
		Level = level;
		Durability = (sbyte)((templateId >= 0) ? BuildingBlock.Instance[templateId].MaxDurability : (-1));
		RootBlockIndex = rootBlockIndex;
		OperationType = -1;
		LevelUnlockedFlags = 1uL;
		CumulatedScore = 0;
	}

	public void ResetData(short templateId, sbyte level = 1, short rootBlockIndex = -1)
	{
		TemplateId = templateId;
		Level = level;
		RootBlockIndex = rootBlockIndex;
		Durability = (sbyte)((templateId >= 0) ? BuildingBlock.Instance[templateId].MaxDurability : (-1));
		OperationType = -1;
		OperationProgress = 0;
		OperationStopping = false;
		LevelUnlockedFlags = 1uL;
		CumulatedScore = 0;
	}

	public void OfflineResetShopProgress()
	{
		ShopProgress = 0;
	}

	public void OfflineChangeShopProgress(int delta)
	{
		int needProgress = ConfigData.MaxProduceValue;
		ExternalDataBridge.Context.ChallengeModeData.ApplyChallengeModeBuildingWorkHard(ref needProgress);
		needProgress = MathUtils.Clamp(needProgress, 0, 32767);
		ShopProgress = (short)MathUtils.Clamp(ShopProgress + delta, 0, (needProgress > 0) ? needProgress : 32767);
	}

	public bool CanUse()
	{
		return OperationType != 0;
	}

	public bool NeedMaintenanceCost()
	{
		return OperationType != 0;
	}

	public void CalcInfluences(IEnumerable<BuildingBlockData> neighborBlockDataList, List<int> neighborDistanceList, Action<BuildingBlockData, int> onInfluenceFound)
	{
		int i = 0;
		foreach (BuildingBlockData neighbor in neighborBlockDataList)
		{
			if (CanInfluenceBuildingBlock(neighbor))
			{
				onInfluenceFound(neighbor, neighborDistanceList[i]);
			}
			i++;
		}
	}

	public bool CanInfluenceBuildingBlock(BuildingBlockData other)
	{
		BuildingBlockItem otherCfg = other.ConfigData;
		if (otherCfg != null && otherCfg.DependBuildings != null)
		{
			return otherCfg.DependBuildings.Contains(TemplateId);
		}
		return false;
	}

	public sbyte CalcUnlockedLevelCount()
	{
		sbyte count = 0;
		ulong set = LevelUnlockedFlags;
		while (set != 0L)
		{
			set &= set - 1;
			count++;
		}
		return count;
	}

	public void ResetInitialUnlockedSlot(int index)
	{
		LevelUnlockedFlags = (uint)(1 << index);
	}

	public void UnlockLevelSlot(int index)
	{
		ulong mask = (uint)(1 << index);
		LevelUnlockedFlags |= mask;
	}

	public bool SlotIsUnlocked(int index)
	{
		ulong mask = (uint)(1 << index);
		return (LevelUnlockedFlags & mask) != 0;
	}

	public static bool IsBuilding(EBuildingBlockType type)
	{
		if (type != EBuildingBlockType.Building)
		{
			return type == EBuildingBlockType.MainBuilding;
		}
		return true;
	}

	public static bool CanUpgrade(EBuildingBlockType type)
	{
		if (!IsBuilding(type))
		{
			return type == EBuildingBlockType.NormalResource;
		}
		return true;
	}

	public static bool IsResource(EBuildingBlockType type)
	{
		if (type != EBuildingBlockType.NormalResource && type != EBuildingBlockType.SpecialResource)
		{
			return type == EBuildingBlockType.UselessResource;
		}
		return true;
	}

	public static bool IsUsefulResource(EBuildingBlockType type)
	{
		if (type != EBuildingBlockType.NormalResource)
		{
			return type == EBuildingBlockType.SpecialResource;
		}
		return true;
	}

	public bool PlanEquals(BuildingBlockData other)
	{
		if (other.BlockIndex == BlockIndex && other.TemplateId == TemplateId && other.Level == Level && other.RootBlockIndex == RootBlockIndex && other.Durability == Durability && other.OperationType == OperationType && other.OperationProgress == OperationProgress && other.OperationStopping == OperationStopping && other.ShopProgress == ShopProgress)
		{
			return other.LevelUnlockedFlags == LevelUnlockedFlags;
		}
		return false;
	}

	public BuildingBlockData Clone()
	{
		BuildingBlockData data = new BuildingBlockData
		{
			BlockIndex = BlockIndex,
			TemplateId = TemplateId,
			Level = Level,
			RootBlockIndex = RootBlockIndex,
			Durability = Durability,
			OperationType = OperationType,
			OperationProgress = OperationProgress,
			OperationStopping = OperationStopping,
			ShopProgress = ShopProgress,
			LevelUnlockedFlags = LevelUnlockedFlags,
			CumulatedScore = CumulatedScore
		};
		if (ArrangementSetting != null)
		{
			data.ArrangementSetting = ArrangementSetting;
		}
		if (SoldItemSetting != null)
		{
			data.SoldItemSetting = SoldItemSetting;
		}
		return data;
	}

	public BuildingBlockData()
	{
	}

	public BuildingBlockData(BuildingBlockData other)
	{
		BlockIndex = other.BlockIndex;
		TemplateId = other.TemplateId;
		Level = other.Level;
		RootBlockIndex = other.RootBlockIndex;
		Durability = other.Durability;
		OperationType = other.OperationType;
		OperationProgress = other.OperationProgress;
		OperationStopping = other.OperationStopping;
		ShopProgress = other.ShopProgress;
		LevelUnlockedFlags = other.LevelUnlockedFlags;
		CumulatedScore = other.CumulatedScore;
		ArrangementSetting = new BuildingOptionAutoGiveMemberPreset(other.ArrangementSetting);
		SoldItemSetting = new BuildingOptionAutoAddSoldItemPreset(other.SoldItemSetting);
	}

	public void Assign(BuildingBlockData other)
	{
		BlockIndex = other.BlockIndex;
		TemplateId = other.TemplateId;
		Level = other.Level;
		RootBlockIndex = other.RootBlockIndex;
		Durability = other.Durability;
		OperationType = other.OperationType;
		OperationProgress = other.OperationProgress;
		OperationStopping = other.OperationStopping;
		ShopProgress = other.ShopProgress;
		LevelUnlockedFlags = other.LevelUnlockedFlags;
		CumulatedScore = other.CumulatedScore;
		ArrangementSetting = new BuildingOptionAutoGiveMemberPreset(other.ArrangementSetting);
		SoldItemSetting = new BuildingOptionAutoAddSoldItemPreset(other.SoldItemSetting);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 28;
		totalSize = ((ArrangementSetting == null) ? (totalSize + 2) : (totalSize + (2 + ArrangementSetting.GetSerializedSize())));
		totalSize = ((SoldItemSetting == null) ? (totalSize + 2) : (totalSize + (2 + SoldItemSetting.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 13;
		pCurrData += 2;
		*(short*)pCurrData = BlockIndex;
		pCurrData += 2;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*pCurrData = (byte)Level;
		pCurrData++;
		*(short*)pCurrData = RootBlockIndex;
		pCurrData += 2;
		*pCurrData = (byte)Durability;
		pCurrData++;
		*pCurrData = (byte)OperationType;
		pCurrData++;
		*(short*)pCurrData = OperationProgress;
		pCurrData += 2;
		*pCurrData = (OperationStopping ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = ShopProgress;
		pCurrData += 2;
		*(ulong*)pCurrData = LevelUnlockedFlags;
		pCurrData += 8;
		*(int*)pCurrData = CumulatedScore;
		pCurrData += 4;
		if (ArrangementSetting != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ArrangementSetting.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SoldItemSetting != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = SoldItemSetting.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			BlockIndex = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			TemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 2)
		{
			Level = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			RootBlockIndex = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 4)
		{
			Durability = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 5)
		{
			OperationType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 6)
		{
			OperationProgress = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 7)
		{
			OperationStopping = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 8)
		{
			ShopProgress = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 9)
		{
			LevelUnlockedFlags = *(ulong*)pCurrData;
			pCurrData += 8;
		}
		if (num > 10)
		{
			CumulatedScore = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 11)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				ArrangementSetting = new BuildingOptionAutoGiveMemberPreset();
				pCurrData += ArrangementSetting.Deserialize(pCurrData);
			}
			else
			{
				ArrangementSetting = null;
			}
		}
		if (num > 12)
		{
			ushort num3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num3 > 0)
			{
				SoldItemSetting = new BuildingOptionAutoAddSoldItemPreset();
				pCurrData += SoldItemSetting.Deserialize(pCurrData);
			}
			else
			{
				SoldItemSetting = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
