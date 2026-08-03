using System;
using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

/// <summary>
/// 产业格数据
/// </summary>
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

	/// <summary>
	/// 在产业地图中的索引
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public short BlockIndex;

	/// <summary>
	/// 模板ID
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public short TemplateId;

	/// <summary>
	/// 规模
	/// (非太吾村、无用资源继续使用，其他移步 BuildingBlockData.CalcUnlockedLevelCount())
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte Level;

	/// <summary>
	/// 从属的产业格，用于占多格的建筑
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public short RootBlockIndex;

	/// <summary>
	/// 耐久度
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public sbyte Durability;

	/// <summary>
	/// 正在进行的操作
	/// </summary>
	[SerializableGameDataField(FieldIndex = 5)]
	public sbyte OperationType;

	/// <summary>
	/// 操作进度值
	/// </summary>
	[SerializableGameDataField(FieldIndex = 6)]
	public short OperationProgress;

	/// <summary>
	/// 是否正在中断操作
	/// </summary>
	[SerializableGameDataField(FieldIndex = 7)]
	public bool OperationStopping;

	/// <summary>
	/// 已经解锁的位数据
	/// <para>每个位，表示一个已经解锁的状态；初始自动解锁一个状态</para>
	/// <para>因此，所有位上解锁过的状态个数就是建筑的规模值</para>
	/// </summary>
	[SerializableGameDataField(FieldIndex = 9)]
	public ulong LevelUnlockedFlags = 1uL;

	/// <summary>
	/// 累计得分, 用于需要持续计分的建筑 (招人)
	/// </summary>
	[SerializableGameDataField(FieldIndex = 10)]
	public int CumulatedScore;

	/// <summary>
	/// 自动指派的设置
	/// </summary>
	[SerializableGameDataField(FieldIndex = 11)]
	public BuildingOptionAutoGiveMemberPreset ArrangementSetting;

	/// <summary>
	/// 自动上货的设置
	/// </summary>
	[SerializableGameDataField(FieldIndex = 12)]
	public BuildingOptionAutoAddSoldItemPreset SoldItemSetting;

	/// <summary>
	/// 经营工作进度
	/// </summary>
	[SerializableGameDataField(FieldIndex = 8)]
	public short ShopProgress { get; private set; }

	public BuildingBlockItem ConfigData => BuildingBlock.Instance[TemplateId];

	/// <summary>
	/// 获取block工作进度百分比
	/// </summary>
	/// <returns></returns>
	public int ShopProgressPercentage => (int)(ShopProgressFill * 100f);

	/// <summary>
	/// 获取block工作进度比例
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 重置产业格数据
	/// </summary>
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

	/// <summary>
	///
	/// </summary>
	/// <param name="delta"></param>
	public void OfflineChangeShopProgress(int delta)
	{
		int needProgress = ConfigData.MaxProduceValue;
		ExternalDataBridge.Context.ChallengeModeData.ApplyChallengeModeBuildingWorkHard(ref needProgress);
		needProgress = MathUtils.Clamp(needProgress, 0, 32767);
		ShopProgress = (short)MathUtils.Clamp(ShopProgress + delta, 0, (needProgress > 0) ? needProgress : 32767);
	}

	/// <summary>
	/// 能否正常使用
	/// </summary>
	public bool CanUse()
	{
		return OperationType != 0;
	}

	/// <summary>
	/// 是否需要维护费用
	/// </summary>
	public bool NeedMaintenanceCost()
	{
		return OperationType != 0;
	}

	/// <summary>
	/// 计算依赖此资源格的依赖项
	/// </summary>
	/// <param name="neighborBlockDataList">待判断的临近资源格列表</param>
	/// <param name="neighborDistanceList">待判断的临近资源格距离列表</param>
	/// <param name="onInfluenceFound">查找到的回调</param>
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

	/// <summary>
	/// 是否可以被指定地格依赖
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public bool CanInfluenceBuildingBlock(BuildingBlockData other)
	{
		BuildingBlockItem otherCfg = other.ConfigData;
		if (otherCfg != null && otherCfg.DependBuildings != null)
		{
			return otherCfg.DependBuildings.Contains(TemplateId);
		}
		return false;
	}

	/// <summary>
	/// 计算已解锁的等级数
	/// </summary>
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

	/// <summary>
	/// 重设初始解锁位
	/// </summary>
	/// <param name="index"></param>
	public void ResetInitialUnlockedSlot(int index)
	{
		LevelUnlockedFlags = (uint)(1 << index);
	}

	/// <summary>
	/// 解锁指定位
	/// </summary>
	/// <param name="index"></param>
	public void UnlockLevelSlot(int index)
	{
		ulong mask = (uint)(1 << index);
		LevelUnlockedFlags |= mask;
	}

	/// <summary>
	/// 某栏位是否已解锁
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public bool SlotIsUnlocked(int index)
	{
		ulong mask = (uint)(1 << index);
		return (LevelUnlockedFlags & mask) != 0;
	}

	/// <summary>
	/// 指定产业格类型是否建筑
	/// </summary>
	public static bool IsBuilding(EBuildingBlockType type)
	{
		if (type != EBuildingBlockType.Building)
		{
			return type == EBuildingBlockType.MainBuilding;
		}
		return true;
	}

	/// <summary>
	/// 指定产业格类型是否可以扩建
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	public static bool CanUpgrade(EBuildingBlockType type)
	{
		if (!IsBuilding(type))
		{
			return type == EBuildingBlockType.NormalResource;
		}
		return true;
	}

	/// <summary>
	/// 指定产业格类型是否资源
	/// </summary>
	public static bool IsResource(EBuildingBlockType type)
	{
		if (type != EBuildingBlockType.NormalResource && type != EBuildingBlockType.SpecialResource)
		{
			return type == EBuildingBlockType.UselessResource;
		}
		return true;
	}

	/// <summary>
	/// 指定产业格类型是否资源
	/// </summary>
	public static bool IsUsefulResource(EBuildingBlockType type)
	{
		if (type != EBuildingBlockType.NormalResource)
		{
			return type == EBuildingBlockType.SpecialResource;
		}
		return true;
	}

	/// <summary>
	/// 建筑规划中认为相同
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public BuildingBlockData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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
