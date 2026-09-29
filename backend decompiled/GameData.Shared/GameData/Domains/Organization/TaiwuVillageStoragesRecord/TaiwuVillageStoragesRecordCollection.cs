using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu;
using GameData.Utilities;

namespace GameData.Domains.Organization.TaiwuVillageStoragesRecord;

public class TaiwuVillageStoragesRecordCollection : WriteableRecordCollection
{
	public void GetRenderInfos(List<TaiwuVillageStoragesRecordRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			TaiwuVillageStoragesRecordRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	public unsafe short GetRecordType(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return ((short*)(pRawData + offset + 1))[2];
		}
	}

	private unsafe int GetDate(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return *(int*)(pRawData + offset + 1);
		}
	}

	public new unsafe TaiwuVillageStoragesRecordRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			sbyte storageType = (sbyte)(*pCurrData);
			pCurrData++;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			TaiwuVillageStoragesRecordItem config = Config.TaiwuVillageStoragesRecord.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			TaiwuVillageStoragesRecordRenderInfo info = new TaiwuVillageStoragesRecordRenderInfo(recordType, config.Desc, date, storageType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadonlyRecordCollection.ReadArgumentAndGetIndex(paramType, &pCurrData, argumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			return info;
		}
	}

	private unsafe int BeginAddingRecord(int date, TaiwuVillageStorageType storageType, short recordType)
	{
		int offset = Size;
		sbyte type = (sbyte)storageType;
		int newSize = Size + 1 + 4 + 1 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = date;
			(num + 1)[4] = (byte)type;
			*(short*)(num + 1 + 4 + 1) = recordType;
		}
		return offset;
	}

	public int AddTakeItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 0);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStorageItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 1);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddStorageResources(int date, TaiwuVillageStorageType storageType, int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 2);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddTakeResources(int date, TaiwuVillageStorageType storageType, int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 3);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGatherResources(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 4);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddMigrateResources(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 5);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCookingIngredient(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 6);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerMakingItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 7);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerRepairItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 8);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerDisassembleItem0(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 9);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerDisassembleItem1(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 10);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerRefiningMedicine(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 11);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerDetoxify0(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 12);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerDetoxify1(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 13);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerEnvenomedItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 14);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerCure(int date, TaiwuVillageStorageType storageType, int charId, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 15);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerSoldItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 16);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerBuyItem(int date, TaiwuVillageStorageType storageType, int charId, int value, sbyte resourceType, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 17);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddOperatingBuilding(int date, TaiwuVillageStorageType storageType, sbyte itemType, short itemTemplateId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 18);
		AppendItem(itemType, itemTemplateId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddClearRecord(int date, TaiwuVillageStorageType storageType)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 19);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddEnvenomedItemOverload(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2, sbyte itemType3, short itemTemplateId3)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 20);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		AppendItem(itemType3, itemTemplateId3);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddDetoxifyItemOverload(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2, sbyte itemType3, short itemTemplateId3, sbyte itemType4, short itemTemplateId4)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 21);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		AppendItem(itemType3, itemTemplateId3);
		AppendItem(itemType4, itemTemplateId4);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGatherResourcesToTreasury(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 22);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGatherResourcesToStockStorageGoodsShelf(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 23);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGatherResourcesToFoodStorage(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 24);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGatherResourcesToMedicineStorage(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 25);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGatherResourcesToCraftStorage(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 26);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddGatherResourcesToCraftStorageToDisassemble(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 27);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLoseOverloadResources(int date, TaiwuVillageStorageType storageType, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 28);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLoseOverloadWarehouseItems(int date, TaiwuVillageStorageType storageType, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 29);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerGetRefineItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 30);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerUpgradeRefineItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 31);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerEarnMoney(int date, TaiwuVillageStorageType storageType, int charId, int charId1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 32);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerEnemyDropItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 33);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerEnemyDropResources(int date, TaiwuVillageStorageType storageType, int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 34);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerMakeHarvest(int date, TaiwuVillageStorageType storageType, short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 35);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddOutsiderMakeHarvest(int date, TaiwuVillageStorageType storageType, int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 36);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerMakeHarvest1(int date, TaiwuVillageStorageType storageType, short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 37);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddOutsiderMakeHarvest1(int date, TaiwuVillageStorageType storageType, int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 38);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerMakeHarvest2(int date, TaiwuVillageStorageType storageType, short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 39);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddOutsiderMakeHarvest2(int date, TaiwuVillageStorageType storageType, int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 40);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerUpgradeRefineItem1(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 41);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddVillagerDonateLegacy(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 42);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
