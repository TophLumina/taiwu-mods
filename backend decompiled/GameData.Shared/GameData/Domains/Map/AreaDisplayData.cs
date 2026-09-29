using System.Collections.Generic;
using GameData.Domains.Adventure;
using GameData.Domains.Character.Display;
using GameData.Domains.Organization.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Map;

[AutoGenerateSerializableGameData(NotForArchive = true)]
public struct AreaDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public bool IsUnlocked;

	[SerializableGameDataField]
	public bool IsBroken;

	[SerializableGameDataField]
	public bool AnyFleeBeast;

	[SerializableGameDataField]
	public bool HasSectExam;

	[SerializableGameDataField]
	public int BrokenLevel;

	[SerializableGameDataField]
	public List<int> States;

	[SerializableGameDataField]
	public NameAndAvatarWithFavor[] PurpleBamboos;

	[SerializableGameDataField]
	public NameAndAvatar[] SpecialNpc;

	[SerializableGameDataField]
	public byte _loongStatusInternal;

	[SerializableGameDataField]
	public bool HasSectZhujianSpecialMerchant;

	[SerializableGameDataField]
	public bool HasBuiltExtraLegacyPointBuilding;

	[SerializableGameDataField]
	public int ExtraLegacyPointCharacterCount;

	[SerializableGameDataField]
	public List<int> AllActivatedAdventureOrMajorEventCoreIds;

	[SerializableGameDataField]
	public SettlementDisplayData[] SettlementDisplayData;

	[SerializableGameDataField]
	public int[] MigratableBlocks;

	[SerializableGameDataField]
	public NameAndAvatar TwelveImmortal;

	[SerializableGameDataField]
	public NameAndAvatar TaiwuAsXiangshuLongYufu;

	[SerializableGameDataField]
	public NameAndAvatar TaiwuAsXiangshuZiWuxiao;

	[SerializableGameDataField]
	public NameAndAvatar TaiwuAsXiangshuRanchenzi;

	[SerializableGameDataField]
	public AdventureNameAndDurationDisplayData[] AdventureNameAndDuration;

	public bool AnyLoong => LoongStatus.Any();

	public BoolArray8 LoongStatus => _loongStatusInternal;

	public int AdventureCount => GetAdventureCount();

	public bool AnyFleeLoongson => GetBoolState(7);

	public bool AnyPurpleBamboo => GetBoolState(4);

	public int InfectedCount => GetState(5);

	public int PastLifeRelationCount => GetState(6);

	public int LegendaryCount => GetState(2);

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
		if (PurpleBamboos != null)
		{
			totalSize += 2;
			for (int i = 0; i < PurpleBamboos.Length; i++)
			{
				totalSize += PurpleBamboos[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (SpecialNpc != null)
		{
			totalSize += 2;
			for (int j = 0; j < SpecialNpc.Length; j++)
			{
				totalSize += SpecialNpc[j].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((AllActivatedAdventureOrMajorEventCoreIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * AllActivatedAdventureOrMajorEventCoreIds.Count)));
		if (SettlementDisplayData != null)
		{
			totalSize += 2;
			for (int k = 0; k < SettlementDisplayData.Length; k++)
			{
				totalSize += SettlementDisplayData[k].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((MigratableBlocks == null) ? (totalSize + 2) : (totalSize + (2 + 4 * MigratableBlocks.Length)));
		totalSize += TwelveImmortal.GetSerializedSize();
		totalSize += TaiwuAsXiangshuLongYufu.GetSerializedSize();
		totalSize += TaiwuAsXiangshuZiWuxiao.GetSerializedSize();
		totalSize += TaiwuAsXiangshuRanchenzi.GetSerializedSize();
		if (AdventureNameAndDuration != null)
		{
			totalSize += 2;
			for (int l = 0; l < AdventureNameAndDuration.Length; l++)
			{
				totalSize = ((AdventureNameAndDuration[l] == null) ? (totalSize + 2) : (totalSize + (2 + AdventureNameAndDuration[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
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
		if (PurpleBamboos != null)
		{
			int elementsCount2 = PurpleBamboos.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				int fieldSize = PurpleBamboos[j].Serialize(pCurrData);
				pCurrData += fieldSize;
				Tester.Assert(fieldSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SpecialNpc != null)
		{
			int elementsCount3 = SpecialNpc.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				int fieldSize2 = SpecialNpc[k].Serialize(pCurrData);
				pCurrData += fieldSize2;
				Tester.Assert(fieldSize2 <= 65535);
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
			int elementsCount4 = AllActivatedAdventureOrMajorEventCoreIds.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				*(int*)pCurrData = AllActivatedAdventureOrMajorEventCoreIds[l];
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
			int elementsCount5 = SettlementDisplayData.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				int fieldSize3 = SettlementDisplayData[m].Serialize(pCurrData);
				pCurrData += fieldSize3;
				Tester.Assert(fieldSize3 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (MigratableBlocks != null)
		{
			int elementsCount6 = MigratableBlocks.Length;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				*(int*)pCurrData = MigratableBlocks[n];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int fieldSize4 = TwelveImmortal.Serialize(pCurrData);
		pCurrData += fieldSize4;
		Tester.Assert(fieldSize4 <= 65535);
		int fieldSize5 = TaiwuAsXiangshuLongYufu.Serialize(pCurrData);
		pCurrData += fieldSize5;
		Tester.Assert(fieldSize5 <= 65535);
		int fieldSize6 = TaiwuAsXiangshuZiWuxiao.Serialize(pCurrData);
		pCurrData += fieldSize6;
		Tester.Assert(fieldSize6 <= 65535);
		int fieldSize7 = TaiwuAsXiangshuRanchenzi.Serialize(pCurrData);
		pCurrData += fieldSize7;
		Tester.Assert(fieldSize7 <= 65535);
		if (AdventureNameAndDuration != null)
		{
			int elementsCount7 = AdventureNameAndDuration.Length;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				if (AdventureNameAndDuration[num] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize8 = AdventureNameAndDuration[num].Serialize(pCurrData);
					pCurrData += fieldSize8;
					Tester.Assert(fieldSize8 <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize8;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
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
			if (PurpleBamboos == null || PurpleBamboos.Length != elementsCount2)
			{
				PurpleBamboos = new NameAndAvatarWithFavor[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				PurpleBamboos[j] = default(NameAndAvatarWithFavor);
				pCurrData += PurpleBamboos[j].Deserialize(pCurrData);
			}
		}
		else
		{
			PurpleBamboos = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (SpecialNpc == null || SpecialNpc.Length != elementsCount3)
			{
				SpecialNpc = new NameAndAvatar[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				SpecialNpc[k] = default(NameAndAvatar);
				pCurrData += SpecialNpc[k].Deserialize(pCurrData);
			}
		}
		else
		{
			SpecialNpc = null;
		}
		_loongStatusInternal = *pCurrData;
		pCurrData++;
		HasSectZhujianSpecialMerchant = *pCurrData != 0;
		pCurrData++;
		HasBuiltExtraLegacyPointBuilding = *pCurrData != 0;
		pCurrData++;
		ExtraLegacyPointCharacterCount = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (AllActivatedAdventureOrMajorEventCoreIds == null)
			{
				AllActivatedAdventureOrMajorEventCoreIds = new List<int>();
			}
			else
			{
				AllActivatedAdventureOrMajorEventCoreIds.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				int element2 = *(int*)pCurrData;
				pCurrData += 4;
				AllActivatedAdventureOrMajorEventCoreIds.Add(element2);
			}
		}
		else
		{
			AllActivatedAdventureOrMajorEventCoreIds?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (SettlementDisplayData == null || SettlementDisplayData.Length != elementsCount5)
			{
				SettlementDisplayData = new SettlementDisplayData[elementsCount5];
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				SettlementDisplayData[m] = default(SettlementDisplayData);
				pCurrData += SettlementDisplayData[m].Deserialize(pCurrData);
			}
		}
		else
		{
			SettlementDisplayData = null;
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (MigratableBlocks == null || MigratableBlocks.Length != elementsCount6)
			{
				MigratableBlocks = new int[elementsCount6];
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				MigratableBlocks[n] = *(int*)pCurrData;
				pCurrData += 4;
			}
		}
		else
		{
			MigratableBlocks = null;
		}
		pCurrData += TwelveImmortal.Deserialize(pCurrData);
		pCurrData += TaiwuAsXiangshuLongYufu.Deserialize(pCurrData);
		pCurrData += TaiwuAsXiangshuZiWuxiao.Deserialize(pCurrData);
		pCurrData += TaiwuAsXiangshuRanchenzi.Deserialize(pCurrData);
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (AdventureNameAndDuration == null || AdventureNameAndDuration.Length != elementsCount7)
			{
				AdventureNameAndDuration = new AdventureNameAndDurationDisplayData[elementsCount7];
			}
			for (int num = 0; num < elementsCount7; num++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num2 > 0)
				{
					AdventureNameAndDuration[num] = new AdventureNameAndDurationDisplayData();
					pCurrData += AdventureNameAndDuration[num].Deserialize(pCurrData);
				}
				else
				{
					AdventureNameAndDuration[num] = null;
				}
			}
		}
		else
		{
			AdventureNameAndDuration = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
