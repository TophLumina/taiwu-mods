using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Profession;

[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class ChangeWeaponTrickDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<ItemDisplayData> InventoryItemList;

	[SerializableGameDataField]
	public List<ItemDisplayData> WarehouseItemList;

	[SerializableGameDataField]
	public List<ItemDisplayData> TreasuryItemList;

	[SerializableGameDataField]
	public List<ItemDisplayData> StockItemList;

	[SerializableGameDataField]
	public Inventory AllMaterialInventory;

	[SerializableGameDataField]
	public bool CanTransferItemToWarehouse;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public ItemKey EmptyToolKey;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 41;
		if (InventoryItemList != null)
		{
			totalSize += 2;
			for (int i = 0; i < InventoryItemList.Count; i++)
			{
				totalSize = ((InventoryItemList[i] == null) ? (totalSize + 2) : (totalSize + (2 + InventoryItemList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (WarehouseItemList != null)
		{
			totalSize += 2;
			for (int j = 0; j < WarehouseItemList.Count; j++)
			{
				totalSize = ((WarehouseItemList[j] == null) ? (totalSize + 2) : (totalSize + (2 + WarehouseItemList[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TreasuryItemList != null)
		{
			totalSize += 2;
			for (int k = 0; k < TreasuryItemList.Count; k++)
			{
				totalSize = ((TreasuryItemList[k] == null) ? (totalSize + 2) : (totalSize + (2 + TreasuryItemList[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (StockItemList != null)
		{
			totalSize += 2;
			for (int l = 0; l < StockItemList.Count; l++)
			{
				totalSize = ((StockItemList[l] == null) ? (totalSize + 2) : (totalSize + (2 + StockItemList[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((AllMaterialInventory == null) ? (totalSize + 2) : (totalSize + (2 + AllMaterialInventory.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (InventoryItemList != null)
		{
			int elementsCount = InventoryItemList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (InventoryItemList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = InventoryItemList[i].Serialize(pCurrData);
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
		if (WarehouseItemList != null)
		{
			int elementsCount2 = WarehouseItemList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (WarehouseItemList[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = WarehouseItemList[j].Serialize(pCurrData);
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
		if (TreasuryItemList != null)
		{
			int elementsCount3 = TreasuryItemList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (TreasuryItemList[k] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = TreasuryItemList[k].Serialize(pCurrData);
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
		if (StockItemList != null)
		{
			int elementsCount4 = StockItemList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (StockItemList[l] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int fieldSize4 = StockItemList[l].Serialize(pCurrData);
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
		if (AllMaterialInventory != null)
		{
			byte* intPtr5 = pCurrData;
			pCurrData += 2;
			int fieldSize5 = AllMaterialInventory.Serialize(pCurrData);
			pCurrData += fieldSize5;
			Tester.Assert(fieldSize5 <= 65535);
			*(ushort*)intPtr5 = (ushort)fieldSize5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (CanTransferItemToWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		pCurrData += EmptyToolKey.Serialize(pCurrData);
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
			if (InventoryItemList == null)
			{
				InventoryItemList = new List<ItemDisplayData>();
			}
			else
			{
				InventoryItemList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element;
				if (num > 0)
				{
					element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				InventoryItemList.Add(element);
			}
		}
		else
		{
			InventoryItemList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (WarehouseItemList == null)
			{
				WarehouseItemList = new List<ItemDisplayData>();
			}
			else
			{
				WarehouseItemList.Clear();
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
				WarehouseItemList.Add(element2);
			}
		}
		else
		{
			WarehouseItemList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (TreasuryItemList == null)
			{
				TreasuryItemList = new List<ItemDisplayData>();
			}
			else
			{
				TreasuryItemList.Clear();
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
				TreasuryItemList.Add(element3);
			}
		}
		else
		{
			TreasuryItemList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (StockItemList == null)
			{
				StockItemList = new List<ItemDisplayData>();
			}
			else
			{
				StockItemList.Clear();
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
				StockItemList.Add(element4);
			}
		}
		else
		{
			StockItemList?.Clear();
		}
		ushort num5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num5 > 0)
		{
			AllMaterialInventory = new Inventory();
			pCurrData += AllMaterialInventory.Deserialize(pCurrData);
		}
		else
		{
			AllMaterialInventory = null;
		}
		CanTransferItemToWarehouse = *pCurrData != 0;
		pCurrData++;
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += EmptyToolKey.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
