using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.Information;
using GameData.Domains.Item.Display;
using GameData.Domains.Taiwu.ExchangeSystem;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true, NotRestrictCollectionSerializedSize = true)]
public class ExchangeDisplayData : ISerializableGameData
{
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public Exchange Exchange;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TaiwuInventoryItemDisplayDataList;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TaiwuWarehouseItemDisplayDataList;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TaiwuTreasuryItemDisplayDataList;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TaiwuStockItemDisplayDataList;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TaiwuTroughItemDisplayDataList;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public KidnapMenuDisplayData TaiwuKidnapMenuDisplayData;

	[SerializableGameDataField]
	public CharacterDisplayData TaiwuDisplayData;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<short> TaiwuLearnedCombatSkills;

	[SerializableGameDataField]
	public sbyte ApproveHighestGrade;

	[SerializableGameDataField]
	public short ApproveRate;

	[SerializableGameDataField]
	public int ApproveRateMax;

	[SerializableGameDataField]
	public CharacterDisplayData TargetCharacterDisplayData;

	[SerializableGameDataField]
	public int TargetCharacterAlertnessValue;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayDataList;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayDataList1;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayDataList2;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayDataList3;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayDataList4;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayDataList5;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayDataList6;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> TargetItemDisplayDataListBuyBack;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public TreasuryData TreasuryData;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public SecretInformationDisplayPackage SecretInformationDisplayPackage;

	[SerializableGameDataField]
	public bool CanTransferItemToWarehouse;

	[SerializableGameDataField]
	public int WarehouseWeight;

	[SerializableGameDataField]
	public int TreasuryWeight;

	[SerializableGameDataField]
	public int StockWeight;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 24;
		totalSize = ((Exchange == null) ? (totalSize + 4) : (totalSize + (4 + Exchange.GetSerializedSize())));
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
		if (TaiwuTroughItemDisplayDataList != null)
		{
			totalSize += 2;
			for (int m = 0; m < TaiwuTroughItemDisplayDataList.Count; m++)
			{
				totalSize = ((TaiwuTroughItemDisplayDataList[m] == null) ? (totalSize + 4) : (totalSize + (4 + TaiwuTroughItemDisplayDataList[m].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((TaiwuKidnapMenuDisplayData == null) ? (totalSize + 4) : (totalSize + (4 + TaiwuKidnapMenuDisplayData.GetSerializedSize())));
		totalSize = ((TaiwuDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + TaiwuDisplayData.GetSerializedSize())));
		totalSize = ((TaiwuLearnedCombatSkills == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TaiwuLearnedCombatSkills.Count)));
		totalSize = ((TargetCharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + TargetCharacterDisplayData.GetSerializedSize())));
		if (TargetItemDisplayDataList != null)
		{
			totalSize += 2;
			for (int n = 0; n < TargetItemDisplayDataList.Count; n++)
			{
				totalSize = ((TargetItemDisplayDataList[n] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayDataList[n].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayDataList1 != null)
		{
			totalSize += 2;
			for (int num = 0; num < TargetItemDisplayDataList1.Count; num++)
			{
				totalSize = ((TargetItemDisplayDataList1[num] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayDataList1[num].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayDataList2 != null)
		{
			totalSize += 2;
			for (int num2 = 0; num2 < TargetItemDisplayDataList2.Count; num2++)
			{
				totalSize = ((TargetItemDisplayDataList2[num2] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayDataList2[num2].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayDataList3 != null)
		{
			totalSize += 2;
			for (int num3 = 0; num3 < TargetItemDisplayDataList3.Count; num3++)
			{
				totalSize = ((TargetItemDisplayDataList3[num3] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayDataList3[num3].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayDataList4 != null)
		{
			totalSize += 2;
			for (int num4 = 0; num4 < TargetItemDisplayDataList4.Count; num4++)
			{
				totalSize = ((TargetItemDisplayDataList4[num4] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayDataList4[num4].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayDataList5 != null)
		{
			totalSize += 2;
			for (int num5 = 0; num5 < TargetItemDisplayDataList5.Count; num5++)
			{
				totalSize = ((TargetItemDisplayDataList5[num5] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayDataList5[num5].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayDataList6 != null)
		{
			totalSize += 2;
			for (int num6 = 0; num6 < TargetItemDisplayDataList6.Count; num6++)
			{
				totalSize = ((TargetItemDisplayDataList6[num6] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayDataList6[num6].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TargetItemDisplayDataListBuyBack != null)
		{
			totalSize += 2;
			for (int num7 = 0; num7 < TargetItemDisplayDataListBuyBack.Count; num7++)
			{
				totalSize = ((TargetItemDisplayDataListBuyBack[num7] == null) ? (totalSize + 4) : (totalSize + (4 + TargetItemDisplayDataListBuyBack[num7].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((TreasuryData == null) ? (totalSize + 4) : (totalSize + (4 + TreasuryData.GetSerializedSize())));
		totalSize = ((SecretInformationDisplayPackage == null) ? (totalSize + 4) : (totalSize + (4 + SecretInformationDisplayPackage.GetSerializedSize())));
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
			pCurrData += 4;
			int fieldSize = Exchange.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= int.MaxValue);
			*(int*)intPtr = fieldSize;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
		if (TaiwuTroughItemDisplayDataList != null)
		{
			int elementsCount5 = TaiwuTroughItemDisplayDataList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				if (TaiwuTroughItemDisplayDataList[m] != null)
				{
					byte* intPtr6 = pCurrData;
					pCurrData += 4;
					int fieldSize6 = TaiwuTroughItemDisplayDataList[m].Serialize(pCurrData);
					pCurrData += fieldSize6;
					Tester.Assert(fieldSize6 <= int.MaxValue);
					*(int*)intPtr6 = fieldSize6;
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
		if (TaiwuKidnapMenuDisplayData != null)
		{
			byte* intPtr7 = pCurrData;
			pCurrData += 4;
			int fieldSize7 = TaiwuKidnapMenuDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize7;
			Tester.Assert(fieldSize7 <= int.MaxValue);
			*(int*)intPtr7 = fieldSize7;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (TaiwuDisplayData != null)
		{
			byte* intPtr8 = pCurrData;
			pCurrData += 2;
			int fieldSize8 = TaiwuDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize8;
			Tester.Assert(fieldSize8 <= 65535);
			*(ushort*)intPtr8 = (ushort)fieldSize8;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuLearnedCombatSkills != null)
		{
			int elementsCount6 = TaiwuLearnedCombatSkills.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				*(short*)pCurrData = TaiwuLearnedCombatSkills[n];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)ApproveHighestGrade;
		pCurrData++;
		*(short*)pCurrData = ApproveRate;
		pCurrData += 2;
		*(int*)pCurrData = ApproveRateMax;
		pCurrData += 4;
		if (TargetCharacterDisplayData != null)
		{
			byte* intPtr9 = pCurrData;
			pCurrData += 2;
			int fieldSize9 = TargetCharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize9;
			Tester.Assert(fieldSize9 <= 65535);
			*(ushort*)intPtr9 = (ushort)fieldSize9;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = TargetCharacterAlertnessValue;
		pCurrData += 4;
		if (TargetItemDisplayDataList != null)
		{
			int elementsCount7 = TargetItemDisplayDataList.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				if (TargetItemDisplayDataList[num] != null)
				{
					byte* intPtr10 = pCurrData;
					pCurrData += 4;
					int fieldSize10 = TargetItemDisplayDataList[num].Serialize(pCurrData);
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
		if (TargetItemDisplayDataList1 != null)
		{
			int elementsCount8 = TargetItemDisplayDataList1.Count;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				if (TargetItemDisplayDataList1[num2] != null)
				{
					byte* intPtr11 = pCurrData;
					pCurrData += 4;
					int fieldSize11 = TargetItemDisplayDataList1[num2].Serialize(pCurrData);
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
		if (TargetItemDisplayDataList2 != null)
		{
			int elementsCount9 = TargetItemDisplayDataList2.Count;
			Tester.Assert(elementsCount9 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount9;
			pCurrData += 2;
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				if (TargetItemDisplayDataList2[num3] != null)
				{
					byte* intPtr12 = pCurrData;
					pCurrData += 4;
					int fieldSize12 = TargetItemDisplayDataList2[num3].Serialize(pCurrData);
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
		if (TargetItemDisplayDataList3 != null)
		{
			int elementsCount10 = TargetItemDisplayDataList3.Count;
			Tester.Assert(elementsCount10 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount10;
			pCurrData += 2;
			for (int num4 = 0; num4 < elementsCount10; num4++)
			{
				if (TargetItemDisplayDataList3[num4] != null)
				{
					byte* intPtr13 = pCurrData;
					pCurrData += 4;
					int fieldSize13 = TargetItemDisplayDataList3[num4].Serialize(pCurrData);
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
		if (TargetItemDisplayDataList4 != null)
		{
			int elementsCount11 = TargetItemDisplayDataList4.Count;
			Tester.Assert(elementsCount11 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount11;
			pCurrData += 2;
			for (int num5 = 0; num5 < elementsCount11; num5++)
			{
				if (TargetItemDisplayDataList4[num5] != null)
				{
					byte* intPtr14 = pCurrData;
					pCurrData += 4;
					int fieldSize14 = TargetItemDisplayDataList4[num5].Serialize(pCurrData);
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
		if (TargetItemDisplayDataList5 != null)
		{
			int elementsCount12 = TargetItemDisplayDataList5.Count;
			Tester.Assert(elementsCount12 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount12;
			pCurrData += 2;
			for (int num6 = 0; num6 < elementsCount12; num6++)
			{
				if (TargetItemDisplayDataList5[num6] != null)
				{
					byte* intPtr15 = pCurrData;
					pCurrData += 4;
					int fieldSize15 = TargetItemDisplayDataList5[num6].Serialize(pCurrData);
					pCurrData += fieldSize15;
					Tester.Assert(fieldSize15 <= int.MaxValue);
					*(int*)intPtr15 = fieldSize15;
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
		if (TargetItemDisplayDataList6 != null)
		{
			int elementsCount13 = TargetItemDisplayDataList6.Count;
			Tester.Assert(elementsCount13 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount13;
			pCurrData += 2;
			for (int num7 = 0; num7 < elementsCount13; num7++)
			{
				if (TargetItemDisplayDataList6[num7] != null)
				{
					byte* intPtr16 = pCurrData;
					pCurrData += 4;
					int fieldSize16 = TargetItemDisplayDataList6[num7].Serialize(pCurrData);
					pCurrData += fieldSize16;
					Tester.Assert(fieldSize16 <= int.MaxValue);
					*(int*)intPtr16 = fieldSize16;
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
		if (TargetItemDisplayDataListBuyBack != null)
		{
			int elementsCount14 = TargetItemDisplayDataListBuyBack.Count;
			Tester.Assert(elementsCount14 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount14;
			pCurrData += 2;
			for (int num8 = 0; num8 < elementsCount14; num8++)
			{
				if (TargetItemDisplayDataListBuyBack[num8] != null)
				{
					byte* intPtr17 = pCurrData;
					pCurrData += 4;
					int fieldSize17 = TargetItemDisplayDataListBuyBack[num8].Serialize(pCurrData);
					pCurrData += fieldSize17;
					Tester.Assert(fieldSize17 <= int.MaxValue);
					*(int*)intPtr17 = fieldSize17;
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
		if (TreasuryData != null)
		{
			byte* intPtr18 = pCurrData;
			pCurrData += 4;
			int fieldSize18 = TreasuryData.Serialize(pCurrData);
			pCurrData += fieldSize18;
			Tester.Assert(fieldSize18 <= int.MaxValue);
			*(int*)intPtr18 = fieldSize18;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (SecretInformationDisplayPackage != null)
		{
			byte* intPtr19 = pCurrData;
			pCurrData += 4;
			int fieldSize19 = SecretInformationDisplayPackage.Serialize(pCurrData);
			pCurrData += fieldSize19;
			Tester.Assert(fieldSize19 <= int.MaxValue);
			*(int*)intPtr19 = fieldSize19;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*pCurrData = (CanTransferItemToWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = WarehouseWeight;
		pCurrData += 4;
		*(int*)pCurrData = TreasuryWeight;
		pCurrData += 4;
		*(int*)pCurrData = StockWeight;
		pCurrData += 4;
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
		int num = *(int*)pCurrData;
		pCurrData += 4;
		if (num > 0)
		{
			Exchange = new Exchange();
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
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (TaiwuTroughItemDisplayDataList == null)
			{
				TaiwuTroughItemDisplayDataList = new List<ItemDisplayData>();
			}
			else
			{
				TaiwuTroughItemDisplayDataList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				int num6 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element5;
				if (num6 > 0)
				{
					element5 = new ItemDisplayData();
					pCurrData += element5.Deserialize(pCurrData);
				}
				else
				{
					element5 = null;
				}
				TaiwuTroughItemDisplayDataList.Add(element5);
			}
		}
		else
		{
			TaiwuTroughItemDisplayDataList?.Clear();
		}
		int num7 = *(int*)pCurrData;
		pCurrData += 4;
		if (num7 > 0)
		{
			TaiwuKidnapMenuDisplayData = new KidnapMenuDisplayData();
			pCurrData += TaiwuKidnapMenuDisplayData.Deserialize(pCurrData);
		}
		else
		{
			TaiwuKidnapMenuDisplayData = null;
		}
		ushort num8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num8 > 0)
		{
			TaiwuDisplayData = new CharacterDisplayData();
			pCurrData += TaiwuDisplayData.Deserialize(pCurrData);
		}
		else
		{
			TaiwuDisplayData = null;
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (TaiwuLearnedCombatSkills == null)
			{
				TaiwuLearnedCombatSkills = new List<short>();
			}
			else
			{
				TaiwuLearnedCombatSkills.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				short element6 = *(short*)pCurrData;
				pCurrData += 2;
				TaiwuLearnedCombatSkills.Add(element6);
			}
		}
		else
		{
			TaiwuLearnedCombatSkills?.Clear();
		}
		ApproveHighestGrade = (sbyte)(*pCurrData);
		pCurrData++;
		ApproveRate = *(short*)pCurrData;
		pCurrData += 2;
		ApproveRateMax = *(int*)pCurrData;
		pCurrData += 4;
		ushort num9 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num9 > 0)
		{
			TargetCharacterDisplayData = new CharacterDisplayData();
			pCurrData += TargetCharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			TargetCharacterDisplayData = null;
		}
		TargetCharacterAlertnessValue = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (TargetItemDisplayDataList == null)
			{
				TargetItemDisplayDataList = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayDataList.Clear();
			}
			for (int num10 = 0; num10 < elementsCount7; num10++)
			{
				int num11 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element7;
				if (num11 > 0)
				{
					element7 = new ItemDisplayData();
					pCurrData += element7.Deserialize(pCurrData);
				}
				else
				{
					element7 = null;
				}
				TargetItemDisplayDataList.Add(element7);
			}
		}
		else
		{
			TargetItemDisplayDataList?.Clear();
		}
		ushort elementsCount8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount8 > 0)
		{
			if (TargetItemDisplayDataList1 == null)
			{
				TargetItemDisplayDataList1 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayDataList1.Clear();
			}
			for (int num12 = 0; num12 < elementsCount8; num12++)
			{
				int num13 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element8;
				if (num13 > 0)
				{
					element8 = new ItemDisplayData();
					pCurrData += element8.Deserialize(pCurrData);
				}
				else
				{
					element8 = null;
				}
				TargetItemDisplayDataList1.Add(element8);
			}
		}
		else
		{
			TargetItemDisplayDataList1?.Clear();
		}
		ushort elementsCount9 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount9 > 0)
		{
			if (TargetItemDisplayDataList2 == null)
			{
				TargetItemDisplayDataList2 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayDataList2.Clear();
			}
			for (int num14 = 0; num14 < elementsCount9; num14++)
			{
				int num15 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element9;
				if (num15 > 0)
				{
					element9 = new ItemDisplayData();
					pCurrData += element9.Deserialize(pCurrData);
				}
				else
				{
					element9 = null;
				}
				TargetItemDisplayDataList2.Add(element9);
			}
		}
		else
		{
			TargetItemDisplayDataList2?.Clear();
		}
		ushort elementsCount10 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount10 > 0)
		{
			if (TargetItemDisplayDataList3 == null)
			{
				TargetItemDisplayDataList3 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayDataList3.Clear();
			}
			for (int num16 = 0; num16 < elementsCount10; num16++)
			{
				int num17 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element10;
				if (num17 > 0)
				{
					element10 = new ItemDisplayData();
					pCurrData += element10.Deserialize(pCurrData);
				}
				else
				{
					element10 = null;
				}
				TargetItemDisplayDataList3.Add(element10);
			}
		}
		else
		{
			TargetItemDisplayDataList3?.Clear();
		}
		ushort elementsCount11 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount11 > 0)
		{
			if (TargetItemDisplayDataList4 == null)
			{
				TargetItemDisplayDataList4 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayDataList4.Clear();
			}
			for (int num18 = 0; num18 < elementsCount11; num18++)
			{
				int num19 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element11;
				if (num19 > 0)
				{
					element11 = new ItemDisplayData();
					pCurrData += element11.Deserialize(pCurrData);
				}
				else
				{
					element11 = null;
				}
				TargetItemDisplayDataList4.Add(element11);
			}
		}
		else
		{
			TargetItemDisplayDataList4?.Clear();
		}
		ushort elementsCount12 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount12 > 0)
		{
			if (TargetItemDisplayDataList5 == null)
			{
				TargetItemDisplayDataList5 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayDataList5.Clear();
			}
			for (int num20 = 0; num20 < elementsCount12; num20++)
			{
				int num21 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element12;
				if (num21 > 0)
				{
					element12 = new ItemDisplayData();
					pCurrData += element12.Deserialize(pCurrData);
				}
				else
				{
					element12 = null;
				}
				TargetItemDisplayDataList5.Add(element12);
			}
		}
		else
		{
			TargetItemDisplayDataList5?.Clear();
		}
		ushort elementsCount13 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount13 > 0)
		{
			if (TargetItemDisplayDataList6 == null)
			{
				TargetItemDisplayDataList6 = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayDataList6.Clear();
			}
			for (int num22 = 0; num22 < elementsCount13; num22++)
			{
				int num23 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element13;
				if (num23 > 0)
				{
					element13 = new ItemDisplayData();
					pCurrData += element13.Deserialize(pCurrData);
				}
				else
				{
					element13 = null;
				}
				TargetItemDisplayDataList6.Add(element13);
			}
		}
		else
		{
			TargetItemDisplayDataList6?.Clear();
		}
		ushort elementsCount14 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount14 > 0)
		{
			if (TargetItemDisplayDataListBuyBack == null)
			{
				TargetItemDisplayDataListBuyBack = new List<ItemDisplayData>();
			}
			else
			{
				TargetItemDisplayDataListBuyBack.Clear();
			}
			for (int num24 = 0; num24 < elementsCount14; num24++)
			{
				int num25 = *(int*)pCurrData;
				pCurrData += 4;
				ItemDisplayData element14;
				if (num25 > 0)
				{
					element14 = new ItemDisplayData();
					pCurrData += element14.Deserialize(pCurrData);
				}
				else
				{
					element14 = null;
				}
				TargetItemDisplayDataListBuyBack.Add(element14);
			}
		}
		else
		{
			TargetItemDisplayDataListBuyBack?.Clear();
		}
		int num26 = *(int*)pCurrData;
		pCurrData += 4;
		if (num26 > 0)
		{
			TreasuryData = new TreasuryData();
			pCurrData += TreasuryData.Deserialize(pCurrData);
		}
		else
		{
			TreasuryData = null;
		}
		int num27 = *(int*)pCurrData;
		pCurrData += 4;
		if (num27 > 0)
		{
			SecretInformationDisplayPackage = new SecretInformationDisplayPackage();
			pCurrData += SecretInformationDisplayPackage.Deserialize(pCurrData);
		}
		else
		{
			SecretInformationDisplayPackage = null;
		}
		CanTransferItemToWarehouse = *pCurrData != 0;
		pCurrData++;
		WarehouseWeight = *(int*)pCurrData;
		pCurrData += 4;
		TreasuryWeight = *(int*)pCurrData;
		pCurrData += 4;
		StockWeight = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
