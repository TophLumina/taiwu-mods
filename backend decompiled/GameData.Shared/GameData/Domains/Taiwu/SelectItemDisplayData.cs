using System.Collections.Generic;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 选择道具显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class SelectItemDisplayData : ISerializableGameData
{
	/// <summary>
	/// 行囊道具
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> InventoryItems;

	/// <summary>
	/// 私库道具
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> WarehouseItems;

	/// <summary>
	/// 公库道具
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> TreasuryItems;

	/// <summary>
	/// 货仓道具
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> StockItems;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (InventoryItems != null)
		{
			totalSize += 2;
			int elementsCount = InventoryItems.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				ItemDisplayData element = InventoryItems[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (WarehouseItems != null)
		{
			totalSize += 2;
			int elementsCount2 = WarehouseItems.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				ItemDisplayData element2 = WarehouseItems[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + element2.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TreasuryItems != null)
		{
			totalSize += 2;
			int elementsCount3 = TreasuryItems.Count;
			for (int k = 0; k < elementsCount3; k++)
			{
				ItemDisplayData element3 = TreasuryItems[k];
				totalSize = ((element3 == null) ? (totalSize + 2) : (totalSize + (2 + element3.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (StockItems != null)
		{
			totalSize += 2;
			int elementsCount4 = StockItems.Count;
			for (int l = 0; l < elementsCount4; l++)
			{
				ItemDisplayData element4 = StockItems[l];
				totalSize = ((element4 == null) ? (totalSize + 2) : (totalSize + (2 + element4.GetSerializedSize())));
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (InventoryItems != null)
		{
			int elementsCount = InventoryItems.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				ItemDisplayData element = InventoryItems[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
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
				ItemDisplayData element2 = WarehouseItems[j];
				if (element2 != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int subDataSize2 = element2.Serialize(pCurrData);
					pCurrData += subDataSize2;
					Tester.Assert(subDataSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)subDataSize2;
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
				ItemDisplayData element3 = TreasuryItems[k];
				if (element3 != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int subDataSize3 = element3.Serialize(pCurrData);
					pCurrData += subDataSize3;
					Tester.Assert(subDataSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)subDataSize3;
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
				ItemDisplayData element4 = StockItems[l];
				if (element4 != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int subDataSize4 = element4.Serialize(pCurrData);
					pCurrData += subDataSize4;
					Tester.Assert(subDataSize4 <= 65535);
					*(ushort*)intPtr4 = (ushort)subDataSize4;
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (InventoryItems == null)
			{
				InventoryItems = new List<ItemDisplayData>(elementsCount);
			}
			else
			{
				InventoryItems.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					ItemDisplayData element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
					InventoryItems.Add(element);
				}
				else
				{
					InventoryItems.Add(null);
				}
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
				WarehouseItems = new List<ItemDisplayData>(elementsCount2);
			}
			else
			{
				WarehouseItems.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num2 > 0)
				{
					ItemDisplayData element2 = new ItemDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
					WarehouseItems.Add(element2);
				}
				else
				{
					WarehouseItems.Add(null);
				}
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
				TreasuryItems = new List<ItemDisplayData>(elementsCount3);
			}
			else
			{
				TreasuryItems.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num3 > 0)
				{
					ItemDisplayData element3 = new ItemDisplayData();
					pCurrData += element3.Deserialize(pCurrData);
					TreasuryItems.Add(element3);
				}
				else
				{
					TreasuryItems.Add(null);
				}
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
				StockItems = new List<ItemDisplayData>(elementsCount4);
			}
			else
			{
				StockItems.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ushort num4 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num4 > 0)
				{
					ItemDisplayData element4 = new ItemDisplayData();
					pCurrData += element4.Deserialize(pCurrData);
					StockItems.Add(element4);
				}
				else
				{
					StockItems.Add(null);
				}
			}
		}
		else
		{
			StockItems?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
