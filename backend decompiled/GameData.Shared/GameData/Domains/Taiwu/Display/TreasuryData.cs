using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 商店界面的显示数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true, NotRestrictCollectionSerializedSize = true)]
public class TreasuryData : ISerializableGameData
{
	[SerializableGameDataField]
	public int SupplyLevel;

	[SerializableGameDataField]
	public int DebtOrSupport;

	/// <summary>
	/// 库房数据
	/// </summary>
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<SettlementTreasury> Treasuries;

	/// <summary>
	/// 库房显示数据
	/// </summary>
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> SettlementTreasuryDisplayDataListLow;

	/// <summary>
	/// 库房显示数据
	/// </summary>
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> SettlementTreasuryDisplayDataListMid;

	/// <summary>
	/// 库房显示数据
	/// </summary>
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<ItemDisplayData> SettlementTreasuryDisplayDataListHigh;

	/// <summary>
	/// 守卫数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData SettlementGuardDisplayDataListLow;

	/// <summary>
	/// 守卫数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData SettlementGuardDisplayDataListMid;

	/// <summary>
	/// 守卫数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData SettlementGuardDisplayDataListHigh;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (Treasuries != null)
		{
			totalSize += 2;
			for (int i = 0; i < Treasuries.Count; i++)
			{
				totalSize = ((Treasuries[i] == null) ? (totalSize + 4) : (totalSize + (4 + Treasuries[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (SettlementTreasuryDisplayDataListLow != null)
		{
			totalSize += 2;
			for (int j = 0; j < SettlementTreasuryDisplayDataListLow.Count; j++)
			{
				totalSize = ((SettlementTreasuryDisplayDataListLow[j] == null) ? (totalSize + 4) : (totalSize + (4 + SettlementTreasuryDisplayDataListLow[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (SettlementTreasuryDisplayDataListMid != null)
		{
			totalSize += 2;
			for (int k = 0; k < SettlementTreasuryDisplayDataListMid.Count; k++)
			{
				totalSize = ((SettlementTreasuryDisplayDataListMid[k] == null) ? (totalSize + 4) : (totalSize + (4 + SettlementTreasuryDisplayDataListMid[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (SettlementTreasuryDisplayDataListHigh != null)
		{
			totalSize += 2;
			for (int l = 0; l < SettlementTreasuryDisplayDataListHigh.Count; l++)
			{
				totalSize = ((SettlementTreasuryDisplayDataListHigh[l] == null) ? (totalSize + 4) : (totalSize + (4 + SettlementTreasuryDisplayDataListHigh[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((SettlementGuardDisplayDataListLow == null) ? (totalSize + 2) : (totalSize + (2 + SettlementGuardDisplayDataListLow.GetSerializedSize())));
		totalSize = ((SettlementGuardDisplayDataListMid == null) ? (totalSize + 2) : (totalSize + (2 + SettlementGuardDisplayDataListMid.GetSerializedSize())));
		totalSize = ((SettlementGuardDisplayDataListHigh == null) ? (totalSize + 2) : (totalSize + (2 + SettlementGuardDisplayDataListHigh.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = SupplyLevel;
		pCurrData += 4;
		*(int*)pCurrData = DebtOrSupport;
		pCurrData += 4;
		if (Treasuries != null)
		{
			int elementsCount = Treasuries.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (Treasuries[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 4;
					int fieldSize = Treasuries[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= int.MaxValue);
					*(int*)intPtr = fieldSize;
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
		if (SettlementTreasuryDisplayDataListLow != null)
		{
			int elementsCount2 = SettlementTreasuryDisplayDataListLow.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (SettlementTreasuryDisplayDataListLow[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 4;
					int fieldSize2 = SettlementTreasuryDisplayDataListLow[j].Serialize(pCurrData);
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
		if (SettlementTreasuryDisplayDataListMid != null)
		{
			int elementsCount3 = SettlementTreasuryDisplayDataListMid.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (SettlementTreasuryDisplayDataListMid[k] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 4;
					int fieldSize3 = SettlementTreasuryDisplayDataListMid[k].Serialize(pCurrData);
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
		if (SettlementTreasuryDisplayDataListHigh != null)
		{
			int elementsCount4 = SettlementTreasuryDisplayDataListHigh.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (SettlementTreasuryDisplayDataListHigh[l] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 4;
					int fieldSize4 = SettlementTreasuryDisplayDataListHigh[l].Serialize(pCurrData);
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
		if (SettlementGuardDisplayDataListLow != null)
		{
			byte* intPtr5 = pCurrData;
			pCurrData += 2;
			int fieldSize5 = SettlementGuardDisplayDataListLow.Serialize(pCurrData);
			pCurrData += fieldSize5;
			Tester.Assert(fieldSize5 <= 65535);
			*(ushort*)intPtr5 = (ushort)fieldSize5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SettlementGuardDisplayDataListMid != null)
		{
			byte* intPtr6 = pCurrData;
			pCurrData += 2;
			int fieldSize6 = SettlementGuardDisplayDataListMid.Serialize(pCurrData);
			pCurrData += fieldSize6;
			Tester.Assert(fieldSize6 <= 65535);
			*(ushort*)intPtr6 = (ushort)fieldSize6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SettlementGuardDisplayDataListHigh != null)
		{
			byte* intPtr7 = pCurrData;
			pCurrData += 2;
			int fieldSize7 = SettlementGuardDisplayDataListHigh.Serialize(pCurrData);
			pCurrData += fieldSize7;
			Tester.Assert(fieldSize7 <= 65535);
			*(ushort*)intPtr7 = (ushort)fieldSize7;
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
		SupplyLevel = *(int*)pCurrData;
		pCurrData += 4;
		DebtOrSupport = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Treasuries == null)
			{
				Treasuries = new List<SettlementTreasury>();
			}
			else
			{
				Treasuries.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int num = *(int*)pCurrData;
				pCurrData += 4;
				SettlementTreasury element;
				if (num > 0)
				{
					element = new SettlementTreasury();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				Treasuries.Add(element);
			}
		}
		else
		{
			Treasuries?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (SettlementTreasuryDisplayDataListLow == null)
			{
				SettlementTreasuryDisplayDataListLow = new List<ItemDisplayData>();
			}
			else
			{
				SettlementTreasuryDisplayDataListLow.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				int num2 = *(int*)pCurrData;
				pCurrData += 4;
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
				SettlementTreasuryDisplayDataListLow.Add(element2);
			}
		}
		else
		{
			SettlementTreasuryDisplayDataListLow?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (SettlementTreasuryDisplayDataListMid == null)
			{
				SettlementTreasuryDisplayDataListMid = new List<ItemDisplayData>();
			}
			else
			{
				SettlementTreasuryDisplayDataListMid.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				int num3 = *(int*)pCurrData;
				pCurrData += 4;
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
				SettlementTreasuryDisplayDataListMid.Add(element3);
			}
		}
		else
		{
			SettlementTreasuryDisplayDataListMid?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (SettlementTreasuryDisplayDataListHigh == null)
			{
				SettlementTreasuryDisplayDataListHigh = new List<ItemDisplayData>();
			}
			else
			{
				SettlementTreasuryDisplayDataListHigh.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				int num4 = *(int*)pCurrData;
				pCurrData += 4;
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
				SettlementTreasuryDisplayDataListHigh.Add(element4);
			}
		}
		else
		{
			SettlementTreasuryDisplayDataListHigh?.Clear();
		}
		ushort num5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num5 > 0)
		{
			SettlementGuardDisplayDataListLow = new CharacterDisplayData();
			pCurrData += SettlementGuardDisplayDataListLow.Deserialize(pCurrData);
		}
		else
		{
			SettlementGuardDisplayDataListLow = null;
		}
		ushort num6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num6 > 0)
		{
			SettlementGuardDisplayDataListMid = new CharacterDisplayData();
			pCurrData += SettlementGuardDisplayDataListMid.Deserialize(pCurrData);
		}
		else
		{
			SettlementGuardDisplayDataListMid = null;
		}
		ushort num7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num7 > 0)
		{
			SettlementGuardDisplayDataListHigh = new CharacterDisplayData();
			pCurrData += SettlementGuardDisplayDataListHigh.Deserialize(pCurrData);
		}
		else
		{
			SettlementGuardDisplayDataListHigh = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
