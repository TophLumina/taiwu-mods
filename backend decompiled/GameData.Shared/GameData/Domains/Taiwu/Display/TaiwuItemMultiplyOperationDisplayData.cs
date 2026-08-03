using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 太吾的批量操作界面数据
/// </summary>
[AutoGenerateSerializableGameData]
[SerializableGameData(NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class TaiwuItemMultiplyOperationDisplayData : ISerializableGameData
{
	/// <summary>
	/// 太吾的人物显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData CharacterDisplayData;

	/// <summary>
	/// 当前行囊负重
	/// </summary>
	[SerializableGameDataField]
	public int CurInventoryLoad;

	/// <summary>
	/// 最大行囊负重
	/// </summary>
	[SerializableGameDataField]
	public int MaxInventoryLoad;

	[SerializableGameDataField]
	public int MoveTimeCostPercent;

	/// <summary>
	/// 当前仓库负重
	/// </summary>
	[SerializableGameDataField]
	public int CurWarehouseLoad;

	/// <summary>
	/// 最大仓库负重
	/// </summary>
	[SerializableGameDataField]
	public int MaxWarehouseLoad;

	/// <summary>
	/// 行囊物品显示数据，包括资源和装备栏
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> InventoryItems;

	/// <summary>
	/// 私库物品显示数据
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> WarehouseItems;

	/// <summary>
	/// 公库物品显示数据
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> TreasuryItems;

	/// <summary>
	/// 货仓物品显示数据
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> StockItems;

	/// <summary>
	/// 徒手工具
	/// </summary>
	[SerializableGameDataField]
	public ItemKey EmptyToolKey;

	/// <summary>
	/// 太吾能否使用仓库
	/// </summary>
	[SerializableGameDataField]
	public bool CanTransferItemToWarehouse;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 21;
		totalSize = ((CharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayData.GetSerializedSize())));
		if (InventoryItems != null)
		{
			totalSize += 2;
			for (int i = 0; i < InventoryItems.Count; i++)
			{
				totalSize = ((InventoryItems[i] == null) ? (totalSize + 2) : (totalSize + (2 + InventoryItems[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (WarehouseItems != null)
		{
			totalSize += 2;
			for (int j = 0; j < WarehouseItems.Count; j++)
			{
				totalSize = ((WarehouseItems[j] == null) ? (totalSize + 2) : (totalSize + (2 + WarehouseItems[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TreasuryItems != null)
		{
			totalSize += 2;
			for (int k = 0; k < TreasuryItems.Count; k++)
			{
				totalSize = ((TreasuryItems[k] == null) ? (totalSize + 2) : (totalSize + (2 + TreasuryItems[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (StockItems != null)
		{
			totalSize += 2;
			for (int l = 0; l < StockItems.Count; l++)
			{
				totalSize = ((StockItems[l] == null) ? (totalSize + 2) : (totalSize + (2 + StockItems[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += EmptyToolKey.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CharacterDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = CurInventoryLoad;
		pCurrData += 4;
		*(int*)pCurrData = MaxInventoryLoad;
		pCurrData += 4;
		*(int*)pCurrData = MoveTimeCostPercent;
		pCurrData += 4;
		*(int*)pCurrData = CurWarehouseLoad;
		pCurrData += 4;
		*(int*)pCurrData = MaxWarehouseLoad;
		pCurrData += 4;
		if (InventoryItems != null)
		{
			int elementsCount = InventoryItems.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (InventoryItems[i] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = InventoryItems[i].Serialize(pCurrData);
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
		if (WarehouseItems != null)
		{
			int elementsCount2 = WarehouseItems.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (WarehouseItems[j] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = WarehouseItems[j].Serialize(pCurrData);
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
		if (TreasuryItems != null)
		{
			int elementsCount3 = TreasuryItems.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (TreasuryItems[k] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int fieldSize4 = TreasuryItems[k].Serialize(pCurrData);
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
		if (StockItems != null)
		{
			int elementsCount4 = StockItems.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (StockItems[l] != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int fieldSize5 = StockItems[l].Serialize(pCurrData);
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
		pCurrData += EmptyToolKey.Serialize(pCurrData);
		*pCurrData = (CanTransferItemToWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
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
			CharacterDisplayData = new CharacterDisplayData();
			pCurrData += CharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayData = null;
		}
		CurInventoryLoad = *(int*)pCurrData;
		pCurrData += 4;
		MaxInventoryLoad = *(int*)pCurrData;
		pCurrData += 4;
		MoveTimeCostPercent = *(int*)pCurrData;
		pCurrData += 4;
		CurWarehouseLoad = *(int*)pCurrData;
		pCurrData += 4;
		MaxWarehouseLoad = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (InventoryItems == null)
			{
				InventoryItems = new List<ItemDisplayData>();
			}
			else
			{
				InventoryItems.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element;
				if (num2 > 0)
				{
					element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				InventoryItems.Add(element);
			}
		}
		else
		{
			InventoryItems?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (WarehouseItems == null)
			{
				WarehouseItems = new List<ItemDisplayData>();
			}
			else
			{
				WarehouseItems.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element2;
				if (num3 > 0)
				{
					element2 = new ItemDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				WarehouseItems.Add(element2);
			}
		}
		else
		{
			WarehouseItems?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (TreasuryItems == null)
			{
				TreasuryItems = new List<ItemDisplayData>();
			}
			else
			{
				TreasuryItems.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num4 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element3;
				if (num4 > 0)
				{
					element3 = new ItemDisplayData();
					pCurrData += element3.Deserialize(pCurrData);
				}
				else
				{
					element3 = null;
				}
				TreasuryItems.Add(element3);
			}
		}
		else
		{
			TreasuryItems?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (StockItems == null)
			{
				StockItems = new List<ItemDisplayData>();
			}
			else
			{
				StockItems.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ushort num5 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element4;
				if (num5 > 0)
				{
					element4 = new ItemDisplayData();
					pCurrData += element4.Deserialize(pCurrData);
				}
				else
				{
					element4 = null;
				}
				StockItems.Add(element4);
			}
		}
		else
		{
			StockItems?.Clear();
		}
		pCurrData += EmptyToolKey.Deserialize(pCurrData);
		CanTransferItemToWarehouse = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
