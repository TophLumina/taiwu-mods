using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Domains.Taiwu.ExchangeSystem;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true, NotRestrictCollectionSerializedSize = true)]
public class ShopDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public ShopExchange Exchange;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TaiwuInventoryItemDisplayDataList;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TaiwuWarehouseItemDisplayDataList;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TaiwuTreasuryItemDisplayDataList;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TaiwuStockItemDisplayDataList;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public CharacterDisplayData TaiwuDisplayData;

	[SerializableGameDataField]
	public short CharacterTemplateId = -1;

	[SerializableGameDataField]
	public bool CanTransferItemToWarehouse;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayData0;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayData1;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayData2;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayData3;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayData4;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayData5;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayData6;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> BuyBackDisplayData;

	public CharacterDisplayData TargetCharacterDisplayData => Exchange.MerchantCharData;

	public List<ItemDisplayData> this[int index] => index switch
	{
		0 => TargetItemDisplayData0, 
		1 => TargetItemDisplayData1, 
		2 => TargetItemDisplayData2, 
		3 => TargetItemDisplayData3, 
		4 => TargetItemDisplayData4, 
		5 => TargetItemDisplayData5, 
		6 => TargetItemDisplayData6, 
		_ => BuyBackDisplayData, 
	};

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((Exchange == null) ? (totalSize + 2) : (totalSize + (2 + Exchange.GetSerializedSize())));
		if (TaiwuInventoryItemDisplayDataList != null)
		{
			totalSize += 2;
			for (int i = 0; i < TaiwuInventoryItemDisplayDataList.Count; i++)
			{
				totalSize = ((TaiwuInventoryItemDisplayDataList[i] == null) ? (totalSize + 4) : (totalSize + (4 + TaiwuInventoryItemDisplayDataList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TaiwuWarehouseItemDisplayDataList != null)
		{
			totalSize += 2;
			for (int j = 0; j < TaiwuWarehouseItemDisplayDataList.Count; j++)
			{
				totalSize = ((TaiwuWarehouseItemDisplayDataList[j] == null) ? (totalSize + 4) : (totalSize + (4 + TaiwuWarehouseItemDisplayDataList[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TaiwuTreasuryItemDisplayDataList != null)
		{
			totalSize += 2;
			for (int k = 0; k < TaiwuTreasuryItemDisplayDataList.Count; k++)
			{
				totalSize = ((TaiwuTreasuryItemDisplayDataList[k] == null) ? (totalSize + 4) : (totalSize + (4 + TaiwuTreasuryItemDisplayDataList[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TaiwuStockItemDisplayDataList != null)
		{
			totalSize += 2;
			for (int l = 0; l < TaiwuStockItemDisplayDataList.Count; l++)
			{
				totalSize = ((TaiwuStockItemDisplayDataList[l] == null) ? (totalSize + 4) : (totalSize + (4 + TaiwuStockItemDisplayDataList[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((TaiwuDisplayData == null) ? (totalSize + 4) : (totalSize + (4 + TaiwuDisplayData.GetSerializedSize())));
		if (TargetItemDisplayData0 != null)
		{
			totalSize += 2;
			for (int m = 0; m < TargetItemDisplayData0.Count; m++)
			{
				totalSize = ((TargetItemDisplayData0[m] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayData0[m].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayData1 != null)
		{
			totalSize += 2;
			for (int n = 0; n < TargetItemDisplayData1.Count; n++)
			{
				totalSize = ((TargetItemDisplayData1[n] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayData1[n].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayData2 != null)
		{
			totalSize += 2;
			for (int num = 0; num < TargetItemDisplayData2.Count; num++)
			{
				totalSize = ((TargetItemDisplayData2[num] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayData2[num].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayData3 != null)
		{
			totalSize += 2;
			for (int num2 = 0; num2 < TargetItemDisplayData3.Count; num2++)
			{
				totalSize = ((TargetItemDisplayData3[num2] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayData3[num2].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayData4 != null)
		{
			totalSize += 2;
			for (int num3 = 0; num3 < TargetItemDisplayData4.Count; num3++)
			{
				totalSize = ((TargetItemDisplayData4[num3] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayData4[num3].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayData5 != null)
		{
			totalSize += 2;
			for (int num4 = 0; num4 < TargetItemDisplayData5.Count; num4++)
			{
				totalSize = ((TargetItemDisplayData5[num4] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayData5[num4].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayData6 != null)
		{
			totalSize += 2;
			for (int num5 = 0; num5 < TargetItemDisplayData6.Count; num5++)
			{
				totalSize = ((TargetItemDisplayData6[num5] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayData6[num5].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (BuyBackDisplayData != null)
		{
			totalSize += 2;
			for (int num6 = 0; num6 < BuyBackDisplayData.Count; num6++)
			{
				totalSize = ((BuyBackDisplayData[num6] == null) ? (totalSize + 4) : (totalSize + (4 + BuyBackDisplayData[num6].GetSerializedSize())));
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
		if (Exchange != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Exchange.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuInventoryItemDisplayDataList != null)
		{
			int elementsCount = TaiwuInventoryItemDisplayDataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (TaiwuInventoryItemDisplayDataList[i] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 4;
					int fieldSize2 = TaiwuInventoryItemDisplayDataList[i].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= int.MaxValue);
					*(int*)intPtr2 = fieldSize2;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuWarehouseItemDisplayDataList != null)
		{
			int elementsCount2 = TaiwuWarehouseItemDisplayDataList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (TaiwuWarehouseItemDisplayDataList[j] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 4;
					int fieldSize3 = TaiwuWarehouseItemDisplayDataList[j].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= int.MaxValue);
					*(int*)intPtr3 = fieldSize3;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuTreasuryItemDisplayDataList != null)
		{
			int elementsCount3 = TaiwuTreasuryItemDisplayDataList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (TaiwuTreasuryItemDisplayDataList[k] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 4;
					int fieldSize4 = TaiwuTreasuryItemDisplayDataList[k].Serialize(pCurrData);
					pCurrData += fieldSize4;
					Tester.Assert(fieldSize4 <= int.MaxValue);
					*(int*)intPtr4 = fieldSize4;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuStockItemDisplayDataList != null)
		{
			int elementsCount4 = TaiwuStockItemDisplayDataList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (TaiwuStockItemDisplayDataList[l] != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 4;
					int fieldSize5 = TaiwuStockItemDisplayDataList[l].Serialize(pCurrData);
					pCurrData += fieldSize5;
					Tester.Assert(fieldSize5 <= int.MaxValue);
					*(int*)intPtr5 = fieldSize5;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuDisplayData != null)
		{
			byte* intPtr6 = pCurrData;
			pCurrData += 4;
			int fieldSize6 = TaiwuDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize6;
			Tester.Assert(fieldSize6 <= int.MaxValue);
			*(int*)intPtr6 = fieldSize6;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*(short*)pCurrData = CharacterTemplateId;
		pCurrData += 2;
		*pCurrData = (CanTransferItemToWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (TargetItemDisplayData0 != null)
		{
			int elementsCount5 = TargetItemDisplayData0.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				if (TargetItemDisplayData0[m] != null)
				{
					byte* intPtr7 = pCurrData;
					pCurrData += 4;
					int fieldSize7 = TargetItemDisplayData0[m].Serialize(pCurrData);
					pCurrData += fieldSize7;
					Tester.Assert(fieldSize7 <= int.MaxValue);
					*(int*)intPtr7 = fieldSize7;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TargetItemDisplayData1 != null)
		{
			int elementsCount6 = TargetItemDisplayData1.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				if (TargetItemDisplayData1[n] != null)
				{
					byte* intPtr8 = pCurrData;
					pCurrData += 4;
					int fieldSize8 = TargetItemDisplayData1[n].Serialize(pCurrData);
					pCurrData += fieldSize8;
					Tester.Assert(fieldSize8 <= int.MaxValue);
					*(int*)intPtr8 = fieldSize8;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TargetItemDisplayData2 != null)
		{
			int elementsCount7 = TargetItemDisplayData2.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				if (TargetItemDisplayData2[num] != null)
				{
					byte* intPtr9 = pCurrData;
					pCurrData += 4;
					int fieldSize9 = TargetItemDisplayData2[num].Serialize(pCurrData);
					pCurrData += fieldSize9;
					Tester.Assert(fieldSize9 <= int.MaxValue);
					*(int*)intPtr9 = fieldSize9;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TargetItemDisplayData3 != null)
		{
			int elementsCount8 = TargetItemDisplayData3.Count;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				if (TargetItemDisplayData3[num2] != null)
				{
					byte* intPtr10 = pCurrData;
					pCurrData += 4;
					int fieldSize10 = TargetItemDisplayData3[num2].Serialize(pCurrData);
					pCurrData += fieldSize10;
					Tester.Assert(fieldSize10 <= int.MaxValue);
					*(int*)intPtr10 = fieldSize10;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TargetItemDisplayData4 != null)
		{
			int elementsCount9 = TargetItemDisplayData4.Count;
			Tester.Assert(elementsCount9 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount9;
			pCurrData += 2;
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				if (TargetItemDisplayData4[num3] != null)
				{
					byte* intPtr11 = pCurrData;
					pCurrData += 4;
					int fieldSize11 = TargetItemDisplayData4[num3].Serialize(pCurrData);
					pCurrData += fieldSize11;
					Tester.Assert(fieldSize11 <= int.MaxValue);
					*(int*)intPtr11 = fieldSize11;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TargetItemDisplayData5 != null)
		{
			int elementsCount10 = TargetItemDisplayData5.Count;
			Tester.Assert(elementsCount10 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount10;
			pCurrData += 2;
			for (int num4 = 0; num4 < elementsCount10; num4++)
			{
				if (TargetItemDisplayData5[num4] != null)
				{
					byte* intPtr12 = pCurrData;
					pCurrData += 4;
					int fieldSize12 = TargetItemDisplayData5[num4].Serialize(pCurrData);
					pCurrData += fieldSize12;
					Tester.Assert(fieldSize12 <= int.MaxValue);
					*(int*)intPtr12 = fieldSize12;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TargetItemDisplayData6 != null)
		{
			int elementsCount11 = TargetItemDisplayData6.Count;
			Tester.Assert(elementsCount11 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount11;
			pCurrData += 2;
			for (int num5 = 0; num5 < elementsCount11; num5++)
			{
				if (TargetItemDisplayData6[num5] != null)
				{
					byte* intPtr13 = pCurrData;
					pCurrData += 4;
					int fieldSize13 = TargetItemDisplayData6[num5].Serialize(pCurrData);
					pCurrData += fieldSize13;
					Tester.Assert(fieldSize13 <= int.MaxValue);
					*(int*)intPtr13 = fieldSize13;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BuyBackDisplayData != null)
		{
			int elementsCount12 = BuyBackDisplayData.Count;
			Tester.Assert(elementsCount12 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount12;
			pCurrData += 2;
			for (int num6 = 0; num6 < elementsCount12; num6++)
			{
				if (BuyBackDisplayData[num6] != null)
				{
					byte* intPtr14 = pCurrData;
					pCurrData += 4;
					int fieldSize14 = BuyBackDisplayData[num6].Serialize(pCurrData);
					pCurrData += fieldSize14;
					Tester.Assert(fieldSize14 <= int.MaxValue);
					*(int*)intPtr14 = fieldSize14;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Exchange = new ShopExchange();
			pCurrData += Exchange.Deserialize(pCurrData);
		}
		else
		{
			Exchange = null;
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (TaiwuInventoryItemDisplayDataList == null)
			{
				TaiwuInventoryItemDisplayDataList = new List<ItemDisplayData>();
			}
			else
			{
				TaiwuInventoryItemDisplayDataList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int num2 = *(int*)pCurrData;
				pCurrData += 4;
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
				TaiwuInventoryItemDisplayDataList.Add(element);
			}
		}
		else
		{
			TaiwuInventoryItemDisplayDataList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (TaiwuWarehouseItemDisplayDataList == null)
			{
				TaiwuWarehouseItemDisplayDataList = new List<ItemDisplayData>();
			}
			else
			{
				TaiwuWarehouseItemDisplayDataList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				int num3 = *(int*)pCurrData;
				pCurrData += 4;
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
				TaiwuWarehouseItemDisplayDataList.Add(element2);
			}
		}
		else
		{
			TaiwuWarehouseItemDisplayDataList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (TaiwuTreasuryItemDisplayDataList == null)
			{
				TaiwuTreasuryItemDisplayDataList = new List<ItemDisplayData>();
			}
			else
			{
				TaiwuTreasuryItemDisplayDataList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				int num4 = *(int*)pCurrData;
				pCurrData += 4;
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
				TaiwuTreasuryItemDisplayDataList.Add(element3);
			}
		}
		else
		{
			TaiwuTreasuryItemDisplayDataList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (TaiwuStockItemDisplayDataList == null)
			{
				TaiwuStockItemDisplayDataList = new List<ItemDisplayData>();
			}
			else
			{
				TaiwuStockItemDisplayDataList.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				int num5 = *(int*)pCurrData;
				pCurrData += 4;
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
				TaiwuStockItemDisplayDataList.Add(element4);
			}
		}
		else
		{
			TaiwuStockItemDisplayDataList?.Clear();
		}
		int num6 = *(int*)pCurrData;
		pCurrData += 4;
		if (num6 > 0)
		{
			TaiwuDisplayData = new CharacterDisplayData();
			pCurrData += TaiwuDisplayData.Deserialize(pCurrData);
		}
		else
		{
			TaiwuDisplayData = null;
		}
		CharacterTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		CanTransferItemToWarehouse = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (TargetItemDisplayData0 == null)
			{
				TargetItemDisplayData0 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayData0.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				int num7 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element5;
				if (num7 > 0)
				{
					element5 = new ItemDisplayData();
					pCurrData += element5.Deserialize(pCurrData);
				}
				else
				{
					element5 = null;
				}
				TargetItemDisplayData0.Add(element5);
			}
		}
		else
		{
			TargetItemDisplayData0?.Clear();
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (TargetItemDisplayData1 == null)
			{
				TargetItemDisplayData1 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayData1.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				int num8 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element6;
				if (num8 > 0)
				{
					element6 = new ItemDisplayData();
					pCurrData += element6.Deserialize(pCurrData);
				}
				else
				{
					element6 = null;
				}
				TargetItemDisplayData1.Add(element6);
			}
		}
		else
		{
			TargetItemDisplayData1?.Clear();
		}
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (TargetItemDisplayData2 == null)
			{
				TargetItemDisplayData2 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayData2.Clear();
			}
			for (int num9 = 0; num9 < elementsCount7; num9++)
			{
				int num10 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element7;
				if (num10 > 0)
				{
					element7 = new ItemDisplayData();
					pCurrData += element7.Deserialize(pCurrData);
				}
				else
				{
					element7 = null;
				}
				TargetItemDisplayData2.Add(element7);
			}
		}
		else
		{
			TargetItemDisplayData2?.Clear();
		}
		ushort elementsCount8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount8 > 0)
		{
			if (TargetItemDisplayData3 == null)
			{
				TargetItemDisplayData3 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayData3.Clear();
			}
			for (int num11 = 0; num11 < elementsCount8; num11++)
			{
				int num12 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element8;
				if (num12 > 0)
				{
					element8 = new ItemDisplayData();
					pCurrData += element8.Deserialize(pCurrData);
				}
				else
				{
					element8 = null;
				}
				TargetItemDisplayData3.Add(element8);
			}
		}
		else
		{
			TargetItemDisplayData3?.Clear();
		}
		ushort elementsCount9 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount9 > 0)
		{
			if (TargetItemDisplayData4 == null)
			{
				TargetItemDisplayData4 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayData4.Clear();
			}
			for (int num13 = 0; num13 < elementsCount9; num13++)
			{
				int num14 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element9;
				if (num14 > 0)
				{
					element9 = new ItemDisplayData();
					pCurrData += element9.Deserialize(pCurrData);
				}
				else
				{
					element9 = null;
				}
				TargetItemDisplayData4.Add(element9);
			}
		}
		else
		{
			TargetItemDisplayData4?.Clear();
		}
		ushort elementsCount10 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount10 > 0)
		{
			if (TargetItemDisplayData5 == null)
			{
				TargetItemDisplayData5 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayData5.Clear();
			}
			for (int num15 = 0; num15 < elementsCount10; num15++)
			{
				int num16 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element10;
				if (num16 > 0)
				{
					element10 = new ItemDisplayData();
					pCurrData += element10.Deserialize(pCurrData);
				}
				else
				{
					element10 = null;
				}
				TargetItemDisplayData5.Add(element10);
			}
		}
		else
		{
			TargetItemDisplayData5?.Clear();
		}
		ushort elementsCount11 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount11 > 0)
		{
			if (TargetItemDisplayData6 == null)
			{
				TargetItemDisplayData6 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayData6.Clear();
			}
			for (int num17 = 0; num17 < elementsCount11; num17++)
			{
				int num18 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element11;
				if (num18 > 0)
				{
					element11 = new ItemDisplayData();
					pCurrData += element11.Deserialize(pCurrData);
				}
				else
				{
					element11 = null;
				}
				TargetItemDisplayData6.Add(element11);
			}
		}
		else
		{
			TargetItemDisplayData6?.Clear();
		}
		ushort elementsCount12 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount12 > 0)
		{
			if (BuyBackDisplayData == null)
			{
				BuyBackDisplayData = new List<ItemDisplayData>();
			}
			else
			{
				BuyBackDisplayData.Clear();
			}
			for (int num19 = 0; num19 < elementsCount12; num19++)
			{
				int num20 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element12;
				if (num20 > 0)
				{
					element12 = new ItemDisplayData();
					pCurrData += element12.Deserialize(pCurrData);
				}
				else
				{
					element12 = null;
				}
				BuyBackDisplayData.Add(element12);
			}
		}
		else
		{
			BuyBackDisplayData?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
