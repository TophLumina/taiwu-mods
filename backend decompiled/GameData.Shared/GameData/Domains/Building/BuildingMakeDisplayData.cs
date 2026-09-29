using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Extra;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class BuildingMakeDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<BuildingBlockData> BlockList;

	[SerializableGameDataField]
	public List<ItemDisplayData> InventoryItemList;

	[SerializableGameDataField]
	public List<ItemDisplayData> EquippedItemList;

	[SerializableGameDataField]
	public List<ItemDisplayData> WarehouseItemList;

	[SerializableGameDataField]
	public List<ItemDisplayData> TreasuryItemList;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public ItemKey EmptyToolKey;

	[SerializableGameDataField]
	public int BuildingAttainmentEffect;

	[SerializableGameDataField]
	public bool CanTransferItemToWarehouse;

	[SerializableGameDataField]
	public CharacterDisplayData CharacterDisplayData;

	[SerializableGameDataField]
	public bool BuildingUpgradeMakeItem;

	[SerializableGameDataField]
	public int AllPagesReadCookingSkillBookCount;

	[SerializableGameDataField]
	public int StoreLocation;

	[SerializableGameDataField]
	public List<short> OwnedClothingList;

	[SerializableGameDataField]
	public WeaveClothingDisplaySetting WeaveClothingDisplaySetting;

	[SerializableGameDataField]
	public Dictionary<int, short> ClothingDisplayModifications;

	public void Clear()
	{
		InventoryItemList?.Clear();
		EquippedItemList?.Clear();
		WarehouseItemList?.Clear();
		TreasuryItemList?.Clear();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 58;
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
		if (InventoryItemList != null)
		{
			totalSize += 2;
			for (int j = 0; j < InventoryItemList.Count; j++)
			{
				totalSize = ((InventoryItemList[j] == null) ? (totalSize + 2) : (totalSize + (2 + InventoryItemList[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (EquippedItemList != null)
		{
			totalSize += 2;
			for (int k = 0; k < EquippedItemList.Count; k++)
			{
				totalSize = ((EquippedItemList[k] == null) ? (totalSize + 2) : (totalSize + (2 + EquippedItemList[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (WarehouseItemList != null)
		{
			totalSize += 2;
			for (int l = 0; l < WarehouseItemList.Count; l++)
			{
				totalSize = ((WarehouseItemList[l] == null) ? (totalSize + 2) : (totalSize + (2 + WarehouseItemList[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TreasuryItemList != null)
		{
			totalSize += 2;
			for (int m = 0; m < TreasuryItemList.Count; m++)
			{
				totalSize = ((TreasuryItemList[m] == null) ? (totalSize + 2) : (totalSize + (2 + TreasuryItemList[m].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((CharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayData.GetSerializedSize())));
		totalSize = ((OwnedClothingList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * OwnedClothingList.Count)));
		totalSize += 4;
		if (ClothingDisplayModifications != null)
		{
			foreach (KeyValuePair<int, short> clothingDisplayModification in ClothingDisplayModifications)
			{
				_ = clothingDisplayModification;
				totalSize += 4;
				totalSize += 2;
			}
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
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = BlockList[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
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
		if (InventoryItemList != null)
		{
			int elementsCount2 = InventoryItemList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (InventoryItemList[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = InventoryItemList[j].Serialize(pCurrData);
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
		if (EquippedItemList != null)
		{
			int elementsCount3 = EquippedItemList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (EquippedItemList[k] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = EquippedItemList[k].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)fieldSize3;
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
		if (WarehouseItemList != null)
		{
			int elementsCount4 = WarehouseItemList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (WarehouseItemList[l] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int fieldSize4 = WarehouseItemList[l].Serialize(pCurrData);
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
		if (TreasuryItemList != null)
		{
			int elementsCount5 = TreasuryItemList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				if (TreasuryItemList[m] != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int fieldSize5 = TreasuryItemList[m].Serialize(pCurrData);
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
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		pCurrData += EmptyToolKey.Serialize(pCurrData);
		*(int*)pCurrData = BuildingAttainmentEffect;
		pCurrData += 4;
		*pCurrData = (CanTransferItemToWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (CharacterDisplayData != null)
		{
			byte* intPtr6 = pCurrData;
			pCurrData += 2;
			int fieldSize6 = CharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize6;
			Tester.Assert(fieldSize6 <= 65535);
			*(ushort*)intPtr6 = (ushort)fieldSize6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (BuildingUpgradeMakeItem ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = AllPagesReadCookingSkillBookCount;
		pCurrData += 4;
		*(int*)pCurrData = StoreLocation;
		pCurrData += 4;
		if (OwnedClothingList != null)
		{
			int elementsCount6 = OwnedClothingList.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				*(short*)pCurrData = OwnedClothingList[n];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += WeaveClothingDisplaySetting.Serialize(pCurrData);
		if (ClothingDisplayModifications != null)
		{
			*(int*)pCurrData = ClothingDisplayModifications.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, short> pair in ClothingDisplayModifications)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				*(short*)pCurrData = pair.Value;
				pCurrData += 2;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				BuildingBlockData element;
				if (num > 0)
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
			if (InventoryItemList == null)
			{
				InventoryItemList = new List<ItemDisplayData>();
			}
			else
			{
				InventoryItemList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element2;
				if (num2 > 0)
				{
					element2 = new ItemDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				InventoryItemList.Add(element2);
			}
		}
		else
		{
			InventoryItemList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (EquippedItemList == null)
			{
				EquippedItemList = new List<ItemDisplayData>();
			}
			else
			{
				EquippedItemList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element3;
				if (num3 > 0)
				{
					element3 = new ItemDisplayData();
					pCurrData += element3.Deserialize(pCurrData);
				}
				else
				{
					element3 = null;
				}
				EquippedItemList.Add(element3);
			}
		}
		else
		{
			EquippedItemList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (WarehouseItemList == null)
			{
				WarehouseItemList = new List<ItemDisplayData>();
			}
			else
			{
				WarehouseItemList.Clear();
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
				WarehouseItemList.Add(element4);
			}
		}
		else
		{
			WarehouseItemList?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (TreasuryItemList == null)
			{
				TreasuryItemList = new List<ItemDisplayData>();
			}
			else
			{
				TreasuryItemList.Clear();
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
				TreasuryItemList.Add(element5);
			}
		}
		else
		{
			TreasuryItemList?.Clear();
		}
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += EmptyToolKey.Deserialize(pCurrData);
		BuildingAttainmentEffect = *(int*)pCurrData;
		pCurrData += 4;
		CanTransferItemToWarehouse = *pCurrData != 0;
		pCurrData++;
		ushort num6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num6 > 0)
		{
			CharacterDisplayData = new CharacterDisplayData();
			pCurrData += CharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayData = null;
		}
		BuildingUpgradeMakeItem = *pCurrData != 0;
		pCurrData++;
		AllPagesReadCookingSkillBookCount = *(int*)pCurrData;
		pCurrData += 4;
		StoreLocation = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (OwnedClothingList == null)
			{
				OwnedClothingList = new List<short>();
			}
			else
			{
				OwnedClothingList.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				short element6 = *(short*)pCurrData;
				pCurrData += 2;
				OwnedClothingList.Add(element6);
			}
		}
		else
		{
			OwnedClothingList?.Clear();
		}
		pCurrData += WeaveClothingDisplaySetting.Deserialize(pCurrData);
		int ClothingDisplayModificationsElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ClothingDisplayModificationsElementsCount > 0)
		{
			if (ClothingDisplayModifications == null)
			{
				ClothingDisplayModifications = new Dictionary<int, short>();
			}
			else
			{
				ClothingDisplayModifications.Clear();
			}
			for (int num7 = 0; num7 < ClothingDisplayModificationsElementsCount; num7++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				short value = *(short*)pCurrData;
				pCurrData += 2;
				ClothingDisplayModifications.Add(key, value);
			}
		}
		else
		{
			ClothingDisplayModifications?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
