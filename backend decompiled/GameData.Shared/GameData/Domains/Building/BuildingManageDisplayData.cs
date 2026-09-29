using System.Collections.Generic;
using System.Text;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Domains.LifeRecord;
using GameData.Domains.Taiwu.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class BuildingManageDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public BuildingBlockData BlockData;

	[SerializableGameDataField]
	public BuildingAreaData AreaData;

	[SerializableGameDataField]
	public List<BuildingBlockData> BlockList;

	[SerializableGameDataField]
	public List<short> LearnedCombatSkillItems;

	[SerializableGameDataField]
	public List<LifeSkillItem> LearnedLifeSkillItems;

	[SerializableGameDataField]
	public BuildingFormulaContextBridge BuildingFormulaContextBridge;

	[SerializableGameDataField]
	public bool CanTransferItemToWarehouse;

	[SerializableGameDataField]
	public int ResourceBlockRanking;

	[SerializableGameDataField]
	public List<ItemDisplayData> CanUseBuildingCore;

	[SerializableGameDataField]
	public List<ItemDisplayData> CannotUseInventoryBuildingCore;

	[SerializableGameDataField]
	public int BuildingSpaceCurr;

	[SerializableGameDataField]
	public int BuildingSpaceLimit;

	[SerializableGameDataField]
	public bool IsTaiwuVillageBuilding;

	[SerializableGameDataField]
	public int BuildingAttainment;

	[SerializableGameDataField]
	public List<int> AvailableWorker;

	[SerializableGameDataField]
	public List<int> AvailableChildren;

	[SerializableGameDataField]
	public BuildingManageYieldTipsData TipsData;

	[SerializableGameDataField]
	public ItemDisplayData FixingBookItemData;

	[SerializableGameDataField]
	public SkillBookPageDisplayData SkillBookPageDisplayData;

	[SerializableGameDataField]
	public int TaiwuVillageResourceBlockEffect;

	[SerializableGameDataField]
	public List<ItemDisplayData> InventoryCanSoldItemList;

	[SerializableGameDataField]
	public List<ItemDisplayData> WarehouseCanSoldItemList;

	[SerializableGameDataField]
	public List<ItemDisplayData> TreasuryCanSoldItemList;

	[SerializableGameDataField]
	public List<ItemDisplayData> StockCanSoldItemList;

	[SerializableGameDataField]
	public int[] SuccessRates;

	[SerializableGameDataField]
	public BuildingEarningsData EarningsData;

	[SerializableGameDataField]
	public List<VillagerRoleCharacterDisplayData> VillagerRoleDataList;

	[SerializableGameDataField]
	public List<CharacterDisplayData> CharacterDataList;

	[SerializableGameDataField]
	public List<int> VillagerEfficiencyList;

	[SerializableGameDataField]
	public List<ShopBuildingTeachBookData> TeachBookDataList;

	[SerializableGameDataField]
	public List<int> UnlockedWorkingVillagerList;

	[SerializableGameDataField]
	public Dictionary<int, int> ShopManagerUpgradeQualificationDict;

	[SerializableGameDataField]
	public List<int> ShopManagerList;

	[SerializableGameDataField]
	public Dictionary<sbyte, int> ResourceOutputValue;

	[SerializableGameDataField]
	public TransferableRecordDataBase ShopEventRecordData;

	[SerializableGameDataField]
	public bool AutoSoldItem;

	[SerializableGameDataField]
	public List<Chicken> Chickens;

	[SerializableGameDataField]
	public List<string> ChickenNickNames;

	[SerializableGameDataField]
	public bool AutoCheckIn;

	[SerializableGameDataField]
	public bool AutoCheckInType;

	[SerializableGameDataField]
	public List<CharacterDisplayData> Residences;

	[SerializableGameDataField]
	public List<CharacterDisplayData> ComfortableHouses;

	[SerializableGameDataField]
	public List<int> LockedResidences;

	[SerializableGameDataField]
	public List<int> LockedComfortableHouses;

	[SerializableGameDataField]
	public Feast Feast;

	[SerializableGameDataField]
	public List<sbyte> XiangshuIdInKungfuRoom;

	[SerializableGameDataField]
	public short CurrLocationOrganizationTemplateId;

	[SerializableGameDataField]
	public List<short> CanPracticeSkills;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 29;
		totalSize = ((BlockData == null) ? (totalSize + 2) : (totalSize + (2 + BlockData.GetSerializedSize())));
		if (BlockList != null)
		{
			totalSize += 2;
			for (int i = 0; i < BlockList.Count; i++)
			{
				totalSize = ((BlockList[i] == null) ? (totalSize + 2) : (totalSize + (2 + BlockList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((LearnedCombatSkillItems == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedCombatSkillItems.Count)));
		totalSize = ((LearnedLifeSkillItems == null) ? (totalSize + 2) : (totalSize + (2 + 4 * LearnedLifeSkillItems.Count)));
		totalSize = ((BuildingFormulaContextBridge == null) ? (totalSize + 2) : (totalSize + (2 + BuildingFormulaContextBridge.GetSerializedSize())));
		if (CanUseBuildingCore != null)
		{
			totalSize += 2;
			for (int j = 0; j < CanUseBuildingCore.Count; j++)
			{
				totalSize = ((CanUseBuildingCore[j] == null) ? (totalSize + 2) : (totalSize + (2 + CanUseBuildingCore[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CannotUseInventoryBuildingCore != null)
		{
			totalSize += 2;
			for (int k = 0; k < CannotUseInventoryBuildingCore.Count; k++)
			{
				totalSize = ((CannotUseInventoryBuildingCore[k] == null) ? (totalSize + 2) : (totalSize + (2 + CannotUseInventoryBuildingCore[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((AvailableWorker == null) ? (totalSize + 2) : (totalSize + (2 + 4 * AvailableWorker.Count)));
		totalSize = ((AvailableChildren == null) ? (totalSize + 2) : (totalSize + (2 + 4 * AvailableChildren.Count)));
		totalSize += TipsData.GetSerializedSize();
		totalSize = ((FixingBookItemData == null) ? (totalSize + 2) : (totalSize + (2 + FixingBookItemData.GetSerializedSize())));
		totalSize = ((SkillBookPageDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + SkillBookPageDisplayData.GetSerializedSize())));
		if (InventoryCanSoldItemList != null)
		{
			totalSize += 2;
			for (int l = 0; l < InventoryCanSoldItemList.Count; l++)
			{
				totalSize = ((InventoryCanSoldItemList[l] == null) ? (totalSize + 2) : (totalSize + (2 + InventoryCanSoldItemList[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (WarehouseCanSoldItemList != null)
		{
			totalSize += 2;
			for (int m = 0; m < WarehouseCanSoldItemList.Count; m++)
			{
				totalSize = ((WarehouseCanSoldItemList[m] == null) ? (totalSize + 2) : (totalSize + (2 + WarehouseCanSoldItemList[m].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TreasuryCanSoldItemList != null)
		{
			totalSize += 2;
			for (int n = 0; n < TreasuryCanSoldItemList.Count; n++)
			{
				totalSize = ((TreasuryCanSoldItemList[n] == null) ? (totalSize + 2) : (totalSize + (2 + TreasuryCanSoldItemList[n].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (StockCanSoldItemList != null)
		{
			totalSize += 2;
			for (int num = 0; num < StockCanSoldItemList.Count; num++)
			{
				totalSize = ((StockCanSoldItemList[num] == null) ? (totalSize + 2) : (totalSize + (2 + StockCanSoldItemList[num].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((SuccessRates == null) ? (totalSize + 2) : (totalSize + (2 + 4 * SuccessRates.Length)));
		totalSize = ((EarningsData == null) ? (totalSize + 2) : (totalSize + (2 + EarningsData.GetSerializedSize())));
		if (VillagerRoleDataList != null)
		{
			totalSize += 2;
			for (int num2 = 0; num2 < VillagerRoleDataList.Count; num2++)
			{
				totalSize = ((VillagerRoleDataList[num2] == null) ? (totalSize + 2) : (totalSize + (2 + VillagerRoleDataList[num2].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CharacterDataList != null)
		{
			totalSize += 2;
			for (int num3 = 0; num3 < CharacterDataList.Count; num3++)
			{
				totalSize = ((CharacterDataList[num3] == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDataList[num3].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((VillagerEfficiencyList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * VillagerEfficiencyList.Count)));
		if (TeachBookDataList != null)
		{
			totalSize += 2;
			for (int num4 = 0; num4 < TeachBookDataList.Count; num4++)
			{
				totalSize = ((TeachBookDataList[num4] == null) ? (totalSize + 2) : (totalSize + (2 + TeachBookDataList[num4].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((UnlockedWorkingVillagerList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * UnlockedWorkingVillagerList.Count)));
		totalSize += 4;
		if (ShopManagerUpgradeQualificationDict != null)
		{
			foreach (KeyValuePair<int, int> item in ShopManagerUpgradeQualificationDict)
			{
				_ = item;
				totalSize += 4;
				totalSize += 4;
			}
		}
		totalSize = ((ShopManagerList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ShopManagerList.Count)));
		totalSize += 4;
		if (ResourceOutputValue != null)
		{
			foreach (KeyValuePair<sbyte, int> item2 in ResourceOutputValue)
			{
				_ = item2;
				totalSize++;
				totalSize += 4;
			}
		}
		totalSize = ((ShopEventRecordData == null) ? (totalSize + 2) : (totalSize + (2 + ShopEventRecordData.GetSerializedSize())));
		totalSize = ((Chickens == null) ? (totalSize + 2) : (totalSize + (2 + 12 * Chickens.Count)));
		if (ChickenNickNames != null)
		{
			totalSize += 2;
			for (int num5 = 0; num5 < ChickenNickNames.Count; num5++)
			{
				totalSize = ((ChickenNickNames[num5] == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ChickenNickNames[num5].Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (Residences != null)
		{
			totalSize += 2;
			for (int num6 = 0; num6 < Residences.Count; num6++)
			{
				totalSize = ((Residences[num6] == null) ? (totalSize + 2) : (totalSize + (2 + Residences[num6].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (ComfortableHouses != null)
		{
			totalSize += 2;
			for (int num7 = 0; num7 < ComfortableHouses.Count; num7++)
			{
				totalSize = ((ComfortableHouses[num7] == null) ? (totalSize + 2) : (totalSize + (2 + ComfortableHouses[num7].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((LockedResidences == null) ? (totalSize + 2) : (totalSize + (2 + 4 * LockedResidences.Count)));
		totalSize = ((LockedComfortableHouses == null) ? (totalSize + 2) : (totalSize + (2 + 4 * LockedComfortableHouses.Count)));
		totalSize = ((Feast == null) ? (totalSize + 2) : (totalSize + (2 + Feast.GetSerializedSize())));
		totalSize = ((XiangshuIdInKungfuRoom == null) ? (totalSize + 2) : (totalSize + (2 + XiangshuIdInKungfuRoom.Count)));
		totalSize = ((CanPracticeSkills == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CanPracticeSkills.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (BlockData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = BlockData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += AreaData.Serialize(pCurrData);
		if (BlockList != null)
		{
			int elementsCount = BlockList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (BlockList[i] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = BlockList[i].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		if (LearnedCombatSkillItems != null)
		{
			int elementsCount2 = LearnedCombatSkillItems.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(short*)pCurrData = LearnedCombatSkillItems[j];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LearnedLifeSkillItems != null)
		{
			int elementsCount3 = LearnedLifeSkillItems.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData += LearnedLifeSkillItems[k].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BuildingFormulaContextBridge != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = BuildingFormulaContextBridge.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (CanTransferItemToWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = ResourceBlockRanking;
		pCurrData += 4;
		if (CanUseBuildingCore != null)
		{
			int elementsCount4 = CanUseBuildingCore.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (CanUseBuildingCore[l] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int fieldSize4 = CanUseBuildingCore[l].Serialize(pCurrData);
					pCurrData += fieldSize4;
					Tester.Assert(fieldSize4 <= 65535);
					*(ushort*)intPtr4 = (ushort)fieldSize4;
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
		if (CannotUseInventoryBuildingCore != null)
		{
			int elementsCount5 = CannotUseInventoryBuildingCore.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				if (CannotUseInventoryBuildingCore[m] != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int fieldSize5 = CannotUseInventoryBuildingCore[m].Serialize(pCurrData);
					pCurrData += fieldSize5;
					Tester.Assert(fieldSize5 <= 65535);
					*(ushort*)intPtr5 = (ushort)fieldSize5;
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
		*(int*)pCurrData = BuildingSpaceCurr;
		pCurrData += 4;
		*(int*)pCurrData = BuildingSpaceLimit;
		pCurrData += 4;
		*pCurrData = (IsTaiwuVillageBuilding ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = BuildingAttainment;
		pCurrData += 4;
		if (AvailableWorker != null)
		{
			int elementsCount6 = AvailableWorker.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				*(int*)pCurrData = AvailableWorker[n];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AvailableChildren != null)
		{
			int elementsCount7 = AvailableChildren.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				*(int*)pCurrData = AvailableChildren[num];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int fieldSize6 = TipsData.Serialize(pCurrData);
		pCurrData += fieldSize6;
		Tester.Assert(fieldSize6 <= 65535);
		if (FixingBookItemData != null)
		{
			byte* intPtr6 = pCurrData;
			pCurrData += 2;
			int fieldSize7 = FixingBookItemData.Serialize(pCurrData);
			pCurrData += fieldSize7;
			Tester.Assert(fieldSize7 <= 65535);
			*(ushort*)intPtr6 = (ushort)fieldSize7;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SkillBookPageDisplayData != null)
		{
			byte* intPtr7 = pCurrData;
			pCurrData += 2;
			int fieldSize8 = SkillBookPageDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize8;
			Tester.Assert(fieldSize8 <= 65535);
			*(ushort*)intPtr7 = (ushort)fieldSize8;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = TaiwuVillageResourceBlockEffect;
		pCurrData += 4;
		if (InventoryCanSoldItemList != null)
		{
			int elementsCount8 = InventoryCanSoldItemList.Count;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				if (InventoryCanSoldItemList[num2] != null)
				{
					byte* intPtr8 = pCurrData;
					pCurrData += 2;
					int fieldSize9 = InventoryCanSoldItemList[num2].Serialize(pCurrData);
					pCurrData += fieldSize9;
					Tester.Assert(fieldSize9 <= 65535);
					*(ushort*)intPtr8 = (ushort)fieldSize9;
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
		if (WarehouseCanSoldItemList != null)
		{
			int elementsCount9 = WarehouseCanSoldItemList.Count;
			Tester.Assert(elementsCount9 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount9;
			pCurrData += 2;
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				if (WarehouseCanSoldItemList[num3] != null)
				{
					byte* intPtr9 = pCurrData;
					pCurrData += 2;
					int fieldSize10 = WarehouseCanSoldItemList[num3].Serialize(pCurrData);
					pCurrData += fieldSize10;
					Tester.Assert(fieldSize10 <= 65535);
					*(ushort*)intPtr9 = (ushort)fieldSize10;
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
		if (TreasuryCanSoldItemList != null)
		{
			int elementsCount10 = TreasuryCanSoldItemList.Count;
			Tester.Assert(elementsCount10 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount10;
			pCurrData += 2;
			for (int num4 = 0; num4 < elementsCount10; num4++)
			{
				if (TreasuryCanSoldItemList[num4] != null)
				{
					byte* intPtr10 = pCurrData;
					pCurrData += 2;
					int fieldSize11 = TreasuryCanSoldItemList[num4].Serialize(pCurrData);
					pCurrData += fieldSize11;
					Tester.Assert(fieldSize11 <= 65535);
					*(ushort*)intPtr10 = (ushort)fieldSize11;
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
		if (StockCanSoldItemList != null)
		{
			int elementsCount11 = StockCanSoldItemList.Count;
			Tester.Assert(elementsCount11 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount11;
			pCurrData += 2;
			for (int num5 = 0; num5 < elementsCount11; num5++)
			{
				if (StockCanSoldItemList[num5] != null)
				{
					byte* intPtr11 = pCurrData;
					pCurrData += 2;
					int fieldSize12 = StockCanSoldItemList[num5].Serialize(pCurrData);
					pCurrData += fieldSize12;
					Tester.Assert(fieldSize12 <= 65535);
					*(ushort*)intPtr11 = (ushort)fieldSize12;
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
		if (SuccessRates != null)
		{
			int elementsCount12 = SuccessRates.Length;
			Tester.Assert(elementsCount12 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount12;
			pCurrData += 2;
			for (int num6 = 0; num6 < elementsCount12; num6++)
			{
				*(int*)pCurrData = SuccessRates[num6];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (EarningsData != null)
		{
			byte* intPtr12 = pCurrData;
			pCurrData += 2;
			int fieldSize13 = EarningsData.Serialize(pCurrData);
			pCurrData += fieldSize13;
			Tester.Assert(fieldSize13 <= 65535);
			*(ushort*)intPtr12 = (ushort)fieldSize13;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (VillagerRoleDataList != null)
		{
			int elementsCount13 = VillagerRoleDataList.Count;
			Tester.Assert(elementsCount13 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount13;
			pCurrData += 2;
			for (int num7 = 0; num7 < elementsCount13; num7++)
			{
				if (VillagerRoleDataList[num7] != null)
				{
					byte* intPtr13 = pCurrData;
					pCurrData += 2;
					int fieldSize14 = VillagerRoleDataList[num7].Serialize(pCurrData);
					pCurrData += fieldSize14;
					Tester.Assert(fieldSize14 <= 65535);
					*(ushort*)intPtr13 = (ushort)fieldSize14;
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
		if (CharacterDataList != null)
		{
			int elementsCount14 = CharacterDataList.Count;
			Tester.Assert(elementsCount14 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount14;
			pCurrData += 2;
			for (int num8 = 0; num8 < elementsCount14; num8++)
			{
				if (CharacterDataList[num8] != null)
				{
					byte* intPtr14 = pCurrData;
					pCurrData += 2;
					int fieldSize15 = CharacterDataList[num8].Serialize(pCurrData);
					pCurrData += fieldSize15;
					Tester.Assert(fieldSize15 <= 65535);
					*(ushort*)intPtr14 = (ushort)fieldSize15;
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
		if (VillagerEfficiencyList != null)
		{
			int elementsCount15 = VillagerEfficiencyList.Count;
			Tester.Assert(elementsCount15 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount15;
			pCurrData += 2;
			for (int num9 = 0; num9 < elementsCount15; num9++)
			{
				*(int*)pCurrData = VillagerEfficiencyList[num9];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TeachBookDataList != null)
		{
			int elementsCount16 = TeachBookDataList.Count;
			Tester.Assert(elementsCount16 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount16;
			pCurrData += 2;
			for (int num10 = 0; num10 < elementsCount16; num10++)
			{
				if (TeachBookDataList[num10] != null)
				{
					byte* intPtr15 = pCurrData;
					pCurrData += 2;
					int fieldSize16 = TeachBookDataList[num10].Serialize(pCurrData);
					pCurrData += fieldSize16;
					Tester.Assert(fieldSize16 <= 65535);
					*(ushort*)intPtr15 = (ushort)fieldSize16;
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
		if (UnlockedWorkingVillagerList != null)
		{
			int elementsCount17 = UnlockedWorkingVillagerList.Count;
			Tester.Assert(elementsCount17 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount17;
			pCurrData += 2;
			for (int num11 = 0; num11 < elementsCount17; num11++)
			{
				*(int*)pCurrData = UnlockedWorkingVillagerList[num11];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ShopManagerUpgradeQualificationDict != null)
		{
			*(int*)pCurrData = ShopManagerUpgradeQualificationDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, int> pair in ShopManagerUpgradeQualificationDict)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (ShopManagerList != null)
		{
			int elementsCount18 = ShopManagerList.Count;
			Tester.Assert(elementsCount18 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount18;
			pCurrData += 2;
			for (int num12 = 0; num12 < elementsCount18; num12++)
			{
				*(int*)pCurrData = ShopManagerList[num12];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ResourceOutputValue != null)
		{
			*(int*)pCurrData = ResourceOutputValue.Count;
			pCurrData += 4;
			foreach (KeyValuePair<sbyte, int> pair2 in ResourceOutputValue)
			{
				*pCurrData = (byte)pair2.Key;
				pCurrData++;
				*(int*)pCurrData = pair2.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (ShopEventRecordData != null)
		{
			byte* intPtr16 = pCurrData;
			pCurrData += 2;
			int fieldSize17 = ShopEventRecordData.Serialize(pCurrData);
			pCurrData += fieldSize17;
			Tester.Assert(fieldSize17 <= 65535);
			*(ushort*)intPtr16 = (ushort)fieldSize17;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (AutoSoldItem ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (Chickens != null)
		{
			int elementsCount19 = Chickens.Count;
			Tester.Assert(elementsCount19 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount19;
			pCurrData += 2;
			for (int num13 = 0; num13 < elementsCount19; num13++)
			{
				pCurrData += Chickens[num13].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ChickenNickNames != null)
		{
			int elementsCount20 = ChickenNickNames.Count;
			Tester.Assert(elementsCount20 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount20;
			pCurrData += 2;
			for (int num14 = 0; num14 < elementsCount20; num14++)
			{
				if (ChickenNickNames[num14] != null)
				{
					int stringCount = ChickenNickNames[num14].Length;
					Tester.Assert(stringCount <= 65535);
					*(ushort*)pCurrData = (ushort)stringCount;
					pCurrData += 2;
					fixed (char* pChar = ChickenNickNames[num14])
					{
						for (int stringIndex = 0; stringIndex < stringCount; stringIndex++)
						{
							((short*)pCurrData)[stringIndex] = (short)pChar[stringIndex];
						}
					}
					pCurrData += 2 * stringCount;
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
		*pCurrData = (AutoCheckIn ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoCheckInType ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (Residences != null)
		{
			int elementsCount21 = Residences.Count;
			Tester.Assert(elementsCount21 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount21;
			pCurrData += 2;
			for (int num15 = 0; num15 < elementsCount21; num15++)
			{
				if (Residences[num15] != null)
				{
					byte* intPtr17 = pCurrData;
					pCurrData += 2;
					int fieldSize18 = Residences[num15].Serialize(pCurrData);
					pCurrData += fieldSize18;
					Tester.Assert(fieldSize18 <= 65535);
					*(ushort*)intPtr17 = (ushort)fieldSize18;
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
		if (ComfortableHouses != null)
		{
			int elementsCount22 = ComfortableHouses.Count;
			Tester.Assert(elementsCount22 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount22;
			pCurrData += 2;
			for (int num16 = 0; num16 < elementsCount22; num16++)
			{
				if (ComfortableHouses[num16] != null)
				{
					byte* intPtr18 = pCurrData;
					pCurrData += 2;
					int fieldSize19 = ComfortableHouses[num16].Serialize(pCurrData);
					pCurrData += fieldSize19;
					Tester.Assert(fieldSize19 <= 65535);
					*(ushort*)intPtr18 = (ushort)fieldSize19;
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
		if (LockedResidences != null)
		{
			int elementsCount23 = LockedResidences.Count;
			Tester.Assert(elementsCount23 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount23;
			pCurrData += 2;
			for (int num17 = 0; num17 < elementsCount23; num17++)
			{
				*(int*)pCurrData = LockedResidences[num17];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LockedComfortableHouses != null)
		{
			int elementsCount24 = LockedComfortableHouses.Count;
			Tester.Assert(elementsCount24 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount24;
			pCurrData += 2;
			for (int num18 = 0; num18 < elementsCount24; num18++)
			{
				*(int*)pCurrData = LockedComfortableHouses[num18];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Feast != null)
		{
			byte* intPtr19 = pCurrData;
			pCurrData += 2;
			int fieldSize20 = Feast.Serialize(pCurrData);
			pCurrData += fieldSize20;
			Tester.Assert(fieldSize20 <= 65535);
			*(ushort*)intPtr19 = (ushort)fieldSize20;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (XiangshuIdInKungfuRoom != null)
		{
			int elementsCount25 = XiangshuIdInKungfuRoom.Count;
			Tester.Assert(elementsCount25 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount25;
			pCurrData += 2;
			for (int num19 = 0; num19 < elementsCount25; num19++)
			{
				*pCurrData = (byte)XiangshuIdInKungfuRoom[num19];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = CurrLocationOrganizationTemplateId;
		pCurrData += 2;
		if (CanPracticeSkills != null)
		{
			int elementsCount26 = CanPracticeSkills.Count;
			Tester.Assert(elementsCount26 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount26;
			pCurrData += 2;
			for (int num20 = 0; num20 < elementsCount26; num20++)
			{
				*(short*)pCurrData = CanPracticeSkills[num20];
				pCurrData += 2;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			BlockData = new BuildingBlockData();
			pCurrData += BlockData.Deserialize(pCurrData);
		}
		else
		{
			BlockData = null;
		}
		AreaData = new BuildingAreaData();
		pCurrData += AreaData.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (BlockList == null)
			{
				BlockList = new List<BuildingBlockData>();
			}
			else
			{
				BlockList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				BuildingBlockData element;
				if (num2 > 0)
				{
					element = new BuildingBlockData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				BlockList.Add(element);
			}
		}
		else
		{
			BlockList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (LearnedCombatSkillItems == null)
			{
				LearnedCombatSkillItems = new List<short>();
			}
			else
			{
				LearnedCombatSkillItems.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				short element2 = *(short*)pCurrData;
				pCurrData += 2;
				LearnedCombatSkillItems.Add(element2);
			}
		}
		else
		{
			LearnedCombatSkillItems?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (LearnedLifeSkillItems == null)
			{
				LearnedLifeSkillItems = new List<LifeSkillItem>();
			}
			else
			{
				LearnedLifeSkillItems.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				LifeSkillItem element3 = default(LifeSkillItem);
				pCurrData += element3.Deserialize(pCurrData);
				LearnedLifeSkillItems.Add(element3);
			}
		}
		else
		{
			LearnedLifeSkillItems?.Clear();
		}
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			BuildingFormulaContextBridge = new BuildingFormulaContextBridge();
			pCurrData += BuildingFormulaContextBridge.Deserialize(pCurrData);
		}
		else
		{
			BuildingFormulaContextBridge = null;
		}
		CanTransferItemToWarehouse = *pCurrData != 0;
		pCurrData++;
		ResourceBlockRanking = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (CanUseBuildingCore == null)
			{
				CanUseBuildingCore = new List<ItemDisplayData>();
			}
			else
			{
				CanUseBuildingCore.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ushort num4 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element4;
				if (num4 > 0)
				{
					element4 = new ItemDisplayData();
					pCurrData += element4.Deserialize(pCurrData);
				}
				else
				{
					element4 = null;
				}
				CanUseBuildingCore.Add(element4);
			}
		}
		else
		{
			CanUseBuildingCore?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (CannotUseInventoryBuildingCore == null)
			{
				CannotUseInventoryBuildingCore = new List<ItemDisplayData>();
			}
			else
			{
				CannotUseInventoryBuildingCore.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				ushort num5 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element5;
				if (num5 > 0)
				{
					element5 = new ItemDisplayData();
					pCurrData += element5.Deserialize(pCurrData);
				}
				else
				{
					element5 = null;
				}
				CannotUseInventoryBuildingCore.Add(element5);
			}
		}
		else
		{
			CannotUseInventoryBuildingCore?.Clear();
		}
		BuildingSpaceCurr = *(int*)pCurrData;
		pCurrData += 4;
		BuildingSpaceLimit = *(int*)pCurrData;
		pCurrData += 4;
		IsTaiwuVillageBuilding = *pCurrData != 0;
		pCurrData++;
		BuildingAttainment = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (AvailableWorker == null)
			{
				AvailableWorker = new List<int>();
			}
			else
			{
				AvailableWorker.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				int element6 = *(int*)pCurrData;
				pCurrData += 4;
				AvailableWorker.Add(element6);
			}
		}
		else
		{
			AvailableWorker?.Clear();
		}
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (AvailableChildren == null)
			{
				AvailableChildren = new List<int>();
			}
			else
			{
				AvailableChildren.Clear();
			}
			for (int num6 = 0; num6 < elementsCount7; num6++)
			{
				int element7 = *(int*)pCurrData;
				pCurrData += 4;
				AvailableChildren.Add(element7);
			}
		}
		else
		{
			AvailableChildren?.Clear();
		}
		pCurrData += TipsData.Deserialize(pCurrData);
		ushort num7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num7 > 0)
		{
			FixingBookItemData = new ItemDisplayData();
			pCurrData += FixingBookItemData.Deserialize(pCurrData);
		}
		else
		{
			FixingBookItemData = null;
		}
		ushort num8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num8 > 0)
		{
			SkillBookPageDisplayData = new SkillBookPageDisplayData();
			pCurrData += SkillBookPageDisplayData.Deserialize(pCurrData);
		}
		else
		{
			SkillBookPageDisplayData = null;
		}
		TaiwuVillageResourceBlockEffect = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount8 > 0)
		{
			if (InventoryCanSoldItemList == null)
			{
				InventoryCanSoldItemList = new List<ItemDisplayData>();
			}
			else
			{
				InventoryCanSoldItemList.Clear();
			}
			for (int num9 = 0; num9 < elementsCount8; num9++)
			{
				ushort num10 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element8;
				if (num10 > 0)
				{
					element8 = new ItemDisplayData();
					pCurrData += element8.Deserialize(pCurrData);
				}
				else
				{
					element8 = null;
				}
				InventoryCanSoldItemList.Add(element8);
			}
		}
		else
		{
			InventoryCanSoldItemList?.Clear();
		}
		ushort elementsCount9 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount9 > 0)
		{
			if (WarehouseCanSoldItemList == null)
			{
				WarehouseCanSoldItemList = new List<ItemDisplayData>();
			}
			else
			{
				WarehouseCanSoldItemList.Clear();
			}
			for (int num11 = 0; num11 < elementsCount9; num11++)
			{
				ushort num12 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element9;
				if (num12 > 0)
				{
					element9 = new ItemDisplayData();
					pCurrData += element9.Deserialize(pCurrData);
				}
				else
				{
					element9 = null;
				}
				WarehouseCanSoldItemList.Add(element9);
			}
		}
		else
		{
			WarehouseCanSoldItemList?.Clear();
		}
		ushort elementsCount10 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount10 > 0)
		{
			if (TreasuryCanSoldItemList == null)
			{
				TreasuryCanSoldItemList = new List<ItemDisplayData>();
			}
			else
			{
				TreasuryCanSoldItemList.Clear();
			}
			for (int num13 = 0; num13 < elementsCount10; num13++)
			{
				ushort num14 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element10;
				if (num14 > 0)
				{
					element10 = new ItemDisplayData();
					pCurrData += element10.Deserialize(pCurrData);
				}
				else
				{
					element10 = null;
				}
				TreasuryCanSoldItemList.Add(element10);
			}
		}
		else
		{
			TreasuryCanSoldItemList?.Clear();
		}
		ushort elementsCount11 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount11 > 0)
		{
			if (StockCanSoldItemList == null)
			{
				StockCanSoldItemList = new List<ItemDisplayData>();
			}
			else
			{
				StockCanSoldItemList.Clear();
			}
			for (int num15 = 0; num15 < elementsCount11; num15++)
			{
				ushort num16 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element11;
				if (num16 > 0)
				{
					element11 = new ItemDisplayData();
					pCurrData += element11.Deserialize(pCurrData);
				}
				else
				{
					element11 = null;
				}
				StockCanSoldItemList.Add(element11);
			}
		}
		else
		{
			StockCanSoldItemList?.Clear();
		}
		ushort elementsCount12 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount12 > 0)
		{
			if (SuccessRates == null || SuccessRates.Length != elementsCount12)
			{
				SuccessRates = new int[elementsCount12];
			}
			for (int num17 = 0; num17 < elementsCount12; num17++)
			{
				SuccessRates[num17] = *(int*)pCurrData;
				pCurrData += 4;
			}
		}
		else
		{
			SuccessRates = null;
		}
		ushort num18 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num18 > 0)
		{
			EarningsData = new BuildingEarningsData();
			pCurrData += EarningsData.Deserialize(pCurrData);
		}
		else
		{
			EarningsData = null;
		}
		ushort elementsCount13 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount13 > 0)
		{
			if (VillagerRoleDataList == null)
			{
				VillagerRoleDataList = new List<VillagerRoleCharacterDisplayData>();
			}
			else
			{
				VillagerRoleDataList.Clear();
			}
			for (int num19 = 0; num19 < elementsCount13; num19++)
			{
				ushort num20 = *(ushort*)pCurrData;
				pCurrData += 2;
				VillagerRoleCharacterDisplayData element12;
				if (num20 > 0)
				{
					element12 = new VillagerRoleCharacterDisplayData();
					pCurrData += element12.Deserialize(pCurrData);
				}
				else
				{
					element12 = null;
				}
				VillagerRoleDataList.Add(element12);
			}
		}
		else
		{
			VillagerRoleDataList?.Clear();
		}
		ushort elementsCount14 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount14 > 0)
		{
			if (CharacterDataList == null)
			{
				CharacterDataList = new List<CharacterDisplayData>();
			}
			else
			{
				CharacterDataList.Clear();
			}
			for (int num21 = 0; num21 < elementsCount14; num21++)
			{
				ushort num22 = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element13;
				if (num22 > 0)
				{
					element13 = new CharacterDisplayData();
					pCurrData += element13.Deserialize(pCurrData);
				}
				else
				{
					element13 = null;
				}
				CharacterDataList.Add(element13);
			}
		}
		else
		{
			CharacterDataList?.Clear();
		}
		ushort elementsCount15 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount15 > 0)
		{
			if (VillagerEfficiencyList == null)
			{
				VillagerEfficiencyList = new List<int>();
			}
			else
			{
				VillagerEfficiencyList.Clear();
			}
			for (int num23 = 0; num23 < elementsCount15; num23++)
			{
				int element14 = *(int*)pCurrData;
				pCurrData += 4;
				VillagerEfficiencyList.Add(element14);
			}
		}
		else
		{
			VillagerEfficiencyList?.Clear();
		}
		ushort elementsCount16 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount16 > 0)
		{
			if (TeachBookDataList == null)
			{
				TeachBookDataList = new List<ShopBuildingTeachBookData>();
			}
			else
			{
				TeachBookDataList.Clear();
			}
			for (int num24 = 0; num24 < elementsCount16; num24++)
			{
				ushort num25 = *(ushort*)pCurrData;
				pCurrData += 2;
				ShopBuildingTeachBookData element15;
				if (num25 > 0)
				{
					element15 = new ShopBuildingTeachBookData();
					pCurrData += element15.Deserialize(pCurrData);
				}
				else
				{
					element15 = null;
				}
				TeachBookDataList.Add(element15);
			}
		}
		else
		{
			TeachBookDataList?.Clear();
		}
		ushort elementsCount17 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount17 > 0)
		{
			if (UnlockedWorkingVillagerList == null)
			{
				UnlockedWorkingVillagerList = new List<int>();
			}
			else
			{
				UnlockedWorkingVillagerList.Clear();
			}
			for (int num26 = 0; num26 < elementsCount17; num26++)
			{
				int element16 = *(int*)pCurrData;
				pCurrData += 4;
				UnlockedWorkingVillagerList.Add(element16);
			}
		}
		else
		{
			UnlockedWorkingVillagerList?.Clear();
		}
		int ShopManagerUpgradeQualificationDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ShopManagerUpgradeQualificationDictElementsCount > 0)
		{
			if (ShopManagerUpgradeQualificationDict == null)
			{
				ShopManagerUpgradeQualificationDict = new Dictionary<int, int>();
			}
			else
			{
				ShopManagerUpgradeQualificationDict.Clear();
			}
			for (int num27 = 0; num27 < ShopManagerUpgradeQualificationDictElementsCount; num27++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				int value = *(int*)pCurrData;
				pCurrData += 4;
				ShopManagerUpgradeQualificationDict.Add(key, value);
			}
		}
		else
		{
			ShopManagerUpgradeQualificationDict?.Clear();
		}
		ushort elementsCount18 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount18 > 0)
		{
			if (ShopManagerList == null)
			{
				ShopManagerList = new List<int>();
			}
			else
			{
				ShopManagerList.Clear();
			}
			for (int num28 = 0; num28 < elementsCount18; num28++)
			{
				int element17 = *(int*)pCurrData;
				pCurrData += 4;
				ShopManagerList.Add(element17);
			}
		}
		else
		{
			ShopManagerList?.Clear();
		}
		int ResourceOutputValueElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ResourceOutputValueElementsCount > 0)
		{
			if (ResourceOutputValue == null)
			{
				ResourceOutputValue = new Dictionary<sbyte, int>();
			}
			else
			{
				ResourceOutputValue.Clear();
			}
			for (int num29 = 0; num29 < ResourceOutputValueElementsCount; num29++)
			{
				sbyte key2 = (sbyte)(*pCurrData);
				pCurrData++;
				int value2 = *(int*)pCurrData;
				pCurrData += 4;
				ResourceOutputValue.Add(key2, value2);
			}
		}
		else
		{
			ResourceOutputValue?.Clear();
		}
		ushort num30 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num30 > 0)
		{
			ShopEventRecordData = new TransferableRecordDataBase();
			pCurrData += ShopEventRecordData.Deserialize(pCurrData);
		}
		else
		{
			ShopEventRecordData = null;
		}
		AutoSoldItem = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount19 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount19 > 0)
		{
			if (Chickens == null)
			{
				Chickens = new List<Chicken>();
			}
			else
			{
				Chickens.Clear();
			}
			for (int num31 = 0; num31 < elementsCount19; num31++)
			{
				Chicken element18 = default(Chicken);
				pCurrData += element18.Deserialize(pCurrData);
				Chickens.Add(element18);
			}
		}
		else
		{
			Chickens?.Clear();
		}
		ushort elementsCount20 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount20 > 0)
		{
			if (ChickenNickNames == null)
			{
				ChickenNickNames = new List<string>();
			}
			else
			{
				ChickenNickNames.Clear();
			}
			for (int num32 = 0; num32 < elementsCount20; num32++)
			{
				ushort stringCount = *(ushort*)pCurrData;
				pCurrData += 2;
				string element19;
				if (stringCount > 0)
				{
					int fieldSize = 2 * stringCount;
					element19 = Encoding.Unicode.GetString(pCurrData, fieldSize);
					pCurrData += fieldSize;
				}
				else
				{
					element19 = null;
				}
				ChickenNickNames.Add(element19);
			}
		}
		else
		{
			ChickenNickNames?.Clear();
		}
		AutoCheckIn = *pCurrData != 0;
		pCurrData++;
		AutoCheckInType = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount21 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount21 > 0)
		{
			if (Residences == null)
			{
				Residences = new List<CharacterDisplayData>();
			}
			else
			{
				Residences.Clear();
			}
			for (int num33 = 0; num33 < elementsCount21; num33++)
			{
				ushort num34 = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element20;
				if (num34 > 0)
				{
					element20 = new CharacterDisplayData();
					pCurrData += element20.Deserialize(pCurrData);
				}
				else
				{
					element20 = null;
				}
				Residences.Add(element20);
			}
		}
		else
		{
			Residences?.Clear();
		}
		ushort elementsCount22 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount22 > 0)
		{
			if (ComfortableHouses == null)
			{
				ComfortableHouses = new List<CharacterDisplayData>();
			}
			else
			{
				ComfortableHouses.Clear();
			}
			for (int num35 = 0; num35 < elementsCount22; num35++)
			{
				ushort num36 = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element21;
				if (num36 > 0)
				{
					element21 = new CharacterDisplayData();
					pCurrData += element21.Deserialize(pCurrData);
				}
				else
				{
					element21 = null;
				}
				ComfortableHouses.Add(element21);
			}
		}
		else
		{
			ComfortableHouses?.Clear();
		}
		ushort elementsCount23 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount23 > 0)
		{
			if (LockedResidences == null)
			{
				LockedResidences = new List<int>();
			}
			else
			{
				LockedResidences.Clear();
			}
			for (int num37 = 0; num37 < elementsCount23; num37++)
			{
				int element22 = *(int*)pCurrData;
				pCurrData += 4;
				LockedResidences.Add(element22);
			}
		}
		else
		{
			LockedResidences?.Clear();
		}
		ushort elementsCount24 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount24 > 0)
		{
			if (LockedComfortableHouses == null)
			{
				LockedComfortableHouses = new List<int>();
			}
			else
			{
				LockedComfortableHouses.Clear();
			}
			for (int num38 = 0; num38 < elementsCount24; num38++)
			{
				int element23 = *(int*)pCurrData;
				pCurrData += 4;
				LockedComfortableHouses.Add(element23);
			}
		}
		else
		{
			LockedComfortableHouses?.Clear();
		}
		ushort num39 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num39 > 0)
		{
			Feast = new Feast();
			pCurrData += Feast.Deserialize(pCurrData);
		}
		else
		{
			Feast = null;
		}
		ushort elementsCount25 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount25 > 0)
		{
			if (XiangshuIdInKungfuRoom == null)
			{
				XiangshuIdInKungfuRoom = new List<sbyte>();
			}
			else
			{
				XiangshuIdInKungfuRoom.Clear();
			}
			for (int num40 = 0; num40 < elementsCount25; num40++)
			{
				sbyte element24 = (sbyte)(*pCurrData);
				pCurrData++;
				XiangshuIdInKungfuRoom.Add(element24);
			}
		}
		else
		{
			XiangshuIdInKungfuRoom?.Clear();
		}
		CurrLocationOrganizationTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount26 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount26 > 0)
		{
			if (CanPracticeSkills == null)
			{
				CanPracticeSkills = new List<short>();
			}
			else
			{
				CanPracticeSkills.Clear();
			}
			for (int num41 = 0; num41 < elementsCount26; num41++)
			{
				short element25 = *(short*)pCurrData;
				pCurrData += 2;
				CanPracticeSkills.Add(element25);
			}
		}
		else
		{
			CanPracticeSkills?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
