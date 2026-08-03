using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.Organization.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Map;

/// <summary>
/// 区域显示数据
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true)]
public struct AreaDisplayData : ISerializableGameData
{
	/// <summary>
	/// 区域是否被解锁
	/// </summary>
	[SerializableGameDataField]
	public bool IsUnlocked;

	/// <summary>
	/// 区域已毁坏
	/// </summary>
	[SerializableGameDataField]
	public bool IsBroken;

	/// <summary>
	/// 是否有流窜的野兽
	/// </summary>
	[SerializableGameDataField]
	public bool AnyFleeBeast;

	/// <summary>
	/// 门派校武
	/// </summary>
	[SerializableGameDataField]
	public bool HasSectExam;

	/// <summary>
	/// 相枢爪牙等级, 仅毁坏区域有效
	/// </summary>
	[SerializableGameDataField]
	public int BrokenLevel;

	/// <summary>
	/// 地区状态数值 <see cref="T:Config.MapLegend" />
	/// 负数 = 只显示图标
	/// 0 = 不显示图标
	/// 正数 = 显示图标与数值
	/// </summary>
	[SerializableGameDataField]
	public List<int> States;

	/// <summary>
	/// 活跃的紫竹化身模板 ID
	/// </summary>
	[SerializableGameDataField]
	public List<short> PurpleBambooTemplateIds;

	/// <summary>
	/// 神龙状态（序列化使用的字段）
	/// </summary>
	[SerializableGameDataField]
	public byte _loongStatusInternal;

	/// <summary>
	/// 是否含有铸剑地主的特色商会分部
	/// </summary>
	[SerializableGameDataField]
	public bool HasSectZhujianSpecialMerchant;

	/// <summary>
	/// 是否建造了星台
	/// </summary>
	[SerializableGameDataField]
	public bool HasBuiltExtraLegacyPointBuilding;

	/// <summary>
	/// 可获取星运的角色数量
	/// </summary>
	[SerializableGameDataField]
	public int ExtraLegacyPointCharacterCount;

	/// <summary>
	/// 所有激活的奇遇或大事件 ID
	/// </summary>
	[SerializableGameDataField]
	public List<int> AllActivatedAdventureOrMajorEventCoreIds;

	/// <summary>
	/// 定居点信息
	/// </summary>
	[SerializableGameDataField]
	public SettlementDisplayData[] SettlementDisplayData;

	/// <summary>
	/// 可迁移地格数量
	/// </summary>
	[SerializableGameDataField]
	public int[] MigratableBlocks;

	/// <summary>
	/// 十二邪仙id
	/// </summary>
	[SerializableGameDataField]
	public NameAndAvatar TwelveImmortal;

	/// <summary>
	/// 是否有活跃的神龙
	/// </summary>
	public bool AnyLoong => LoongStatus.Any();

	/// <summary>
	/// 神龙状态
	/// 通过 <see cref="T:GameData.Domains.CombatSkill.FiveElementsType" /> 作为索引访问，真值标识该地区存在对应五行神龙
	/// </summary>
	public BoolArray8 LoongStatus => _loongStatusInternal;

	/// <summary>
	/// 奇遇数量
	/// </summary>
	public int AdventureCount => GetAdventureCount();

	public bool AnyFleeLoongson => GetBoolState(7);

	public bool AnyPurpleBamboo => GetBoolState(4);

	public int InfectedCount => GetState(5);

	public int PastLifeRelationCount => GetState(6);

	public int LegendaryCount => GetState(2);

	/// <summary>
	/// 获取奇遇与大事件数量
	/// </summary>
	public int GetAdventureCount()
	{
		return AllActivatedAdventureOrMajorEventCoreIds?.Count ?? 0;
	}

	public bool GetBoolState(sbyte defKey)
	{
		return GetState(defKey) != 0;
	}

	public int GetState(sbyte defKey)
	{
		if (!States.CheckIndex(defKey))
		{
			return 0;
		}
		return States[defKey];
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 15;
		totalSize = ((States == null) ? (totalSize + 2) : (totalSize + (2 + 4 * States.Count)));
		totalSize = ((PurpleBambooTemplateIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * PurpleBambooTemplateIds.Count)));
		totalSize = ((AllActivatedAdventureOrMajorEventCoreIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * AllActivatedAdventureOrMajorEventCoreIds.Count)));
		if (SettlementDisplayData != null)
		{
			totalSize += 2;
			for (int i = 0; i < SettlementDisplayData.Length; i++)
			{
				totalSize += SettlementDisplayData[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((MigratableBlocks == null) ? (totalSize + 2) : (totalSize + (2 + 4 * MigratableBlocks.Length)));
		totalSize += TwelveImmortal.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (IsUnlocked ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsBroken ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AnyFleeBeast ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (HasSectExam ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = BrokenLevel;
		pCurrData += 4;
		if (States != null)
		{
			int elementsCount = States.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(int*)pCurrData = States[i];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (PurpleBambooTemplateIds != null)
		{
			int elementsCount2 = PurpleBambooTemplateIds.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(short*)pCurrData = PurpleBambooTemplateIds[j];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = _loongStatusInternal;
		pCurrData++;
		*pCurrData = (HasSectZhujianSpecialMerchant ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (HasBuiltExtraLegacyPointBuilding ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = ExtraLegacyPointCharacterCount;
		pCurrData += 4;
		if (AllActivatedAdventureOrMajorEventCoreIds != null)
		{
			int elementsCount3 = AllActivatedAdventureOrMajorEventCoreIds.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				*(int*)pCurrData = AllActivatedAdventureOrMajorEventCoreIds[k];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SettlementDisplayData != null)
		{
			int elementsCount4 = SettlementDisplayData.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				int fieldSize = SettlementDisplayData[l].Serialize(pCurrData);
				pCurrData += fieldSize;
				Tester.Assert(fieldSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (MigratableBlocks != null)
		{
			int elementsCount5 = MigratableBlocks.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				*(int*)pCurrData = MigratableBlocks[m];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int fieldSize2 = TwelveImmortal.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
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
		IsUnlocked = *pCurrData != 0;
		pCurrData++;
		IsBroken = *pCurrData != 0;
		pCurrData++;
		AnyFleeBeast = *pCurrData != 0;
		pCurrData++;
		HasSectExam = *pCurrData != 0;
		pCurrData++;
		BrokenLevel = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (States == null)
			{
				States = new List<int>();
			}
			else
			{
				States.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int element = *(int*)pCurrData;
				pCurrData += 4;
				States.Add(element);
			}
		}
		else
		{
			States?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (PurpleBambooTemplateIds == null)
			{
				PurpleBambooTemplateIds = new List<short>();
			}
			else
			{
				PurpleBambooTemplateIds.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				short element2 = *(short*)pCurrData;
				pCurrData += 2;
				PurpleBambooTemplateIds.Add(element2);
			}
		}
		else
		{
			PurpleBambooTemplateIds?.Clear();
		}
		_loongStatusInternal = *pCurrData;
		pCurrData++;
		HasSectZhujianSpecialMerchant = *pCurrData != 0;
		pCurrData++;
		HasBuiltExtraLegacyPointBuilding = *pCurrData != 0;
		pCurrData++;
		ExtraLegacyPointCharacterCount = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (AllActivatedAdventureOrMajorEventCoreIds == null)
			{
				AllActivatedAdventureOrMajorEventCoreIds = new List<int>();
			}
			else
			{
				AllActivatedAdventureOrMajorEventCoreIds.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				int element3 = *(int*)pCurrData;
				pCurrData += 4;
				AllActivatedAdventureOrMajorEventCoreIds.Add(element3);
			}
		}
		else
		{
			AllActivatedAdventureOrMajorEventCoreIds?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (SettlementDisplayData == null || SettlementDisplayData.Length != elementsCount4)
			{
				SettlementDisplayData = new SettlementDisplayData[elementsCount4];
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				SettlementDisplayData[l] = default(SettlementDisplayData);
				pCurrData += SettlementDisplayData[l].Deserialize(pCurrData);
			}
		}
		else
		{
			SettlementDisplayData = null;
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (MigratableBlocks == null || MigratableBlocks.Length != elementsCount5)
			{
				MigratableBlocks = new int[elementsCount5];
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				MigratableBlocks[m] = *(int*)pCurrData;
				pCurrData += 4;
			}
		}
		else
		{
			MigratableBlocks = null;
		}
		pCurrData += TwelveImmortal.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
