using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

public class TeaHorseCaravanData : ISerializableGameData
{
	public const sbyte FromInventory = 1;

	public const sbyte FromWarehouse = 2;

	public const sbyte FromTreasury = 3;

	public const sbyte FromStockStorage = 4;

	public const short CaravanReplenishmentInitValue = 100;

	public const short CaravanAwarenessInitValue = 100;

	public const short CaravanReplenishmentCostPerMonth = 5;

	[SerializableGameDataField]
	public List<(ItemKey, sbyte)> CarryGoodsList;

	[SerializableGameDataField]
	public List<ItemKey> ExchangeGoodsList;

	[Obsolete]
	[SerializableGameDataField]
	public List<short> DiaryList;

	[SerializableGameDataField]
	public sbyte CaravanState;

	[SerializableGameDataField]
	public bool IsStartSearch;

	[SerializableGameDataField]
	public short Weather;

	[SerializableGameDataField]
	public short Terrain;

	[SerializableGameDataField]
	public short CaravanAwareness;

	[SerializableGameDataField]
	public short CaravanReplenishment;

	[SerializableGameDataField]
	public short LackReplenishmentTurn;

	[SerializableGameDataField]
	public bool IsShowSeachReplenishment;

	[SerializableGameDataField]
	public bool IsShowExchangeReplenishment;

	[SerializableGameDataField]
	public short DistanceToTaiwuVillage;

	[SerializableGameDataField]
	public short StartMonth;

	[SerializableGameDataField]
	public short ExchangeReplenishmentAmountMax;

	[SerializableGameDataField]
	public short ExchangeReplenishmentRemainAmount;

	[SerializableGameDataField]
	public short SearchReplenishmentMax;

	[SerializableGameDataField]
	public short SearchReplenishmentAmount;

	public TeaHorseCaravanData()
	{
		CarryGoodsList = new List<(ItemKey, sbyte)>();
		ExchangeGoodsList = new List<ItemKey>();
		DiaryList = new List<short>();
		CaravanAwareness = 100;
		CaravanReplenishment = 100;
	}

	public int GetReplenishmentCost()
	{
		return TeaHorseCaravanWeather.Instance.GetItem(Weather).ReplenishmentChange + 5;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 26;
		totalSize = ((CarryGoodsList == null) ? (totalSize + 2) : (totalSize + (2 + 9 * CarryGoodsList.Count)));
		totalSize = ((ExchangeGoodsList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * ExchangeGoodsList.Count)));
		totalSize = ((DiaryList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * DiaryList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CarryGoodsList != null)
		{
			int elementsCount = CarryGoodsList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += CarryGoodsList[i].Item1.Serialize(pCurrData);
				*pCurrData = (byte)CarryGoodsList[i].Item2;
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ExchangeGoodsList != null)
		{
			int elementsCount2 = ExchangeGoodsList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += ExchangeGoodsList[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DiaryList != null)
		{
			int elementsCount3 = DiaryList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = DiaryList[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)CaravanState;
		pCurrData++;
		*pCurrData = (IsStartSearch ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = Weather;
		pCurrData += 2;
		*(short*)pCurrData = Terrain;
		pCurrData += 2;
		*(short*)pCurrData = CaravanAwareness;
		pCurrData += 2;
		*(short*)pCurrData = CaravanReplenishment;
		pCurrData += 2;
		*(short*)pCurrData = LackReplenishmentTurn;
		pCurrData += 2;
		*pCurrData = (IsShowSeachReplenishment ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsShowExchangeReplenishment ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = DistanceToTaiwuVillage;
		pCurrData += 2;
		*(short*)pCurrData = StartMonth;
		pCurrData += 2;
		*(short*)pCurrData = ExchangeReplenishmentAmountMax;
		pCurrData += 2;
		*(short*)pCurrData = ExchangeReplenishmentRemainAmount;
		pCurrData += 2;
		*(short*)pCurrData = SearchReplenishmentMax;
		pCurrData += 2;
		*(short*)pCurrData = SearchReplenishmentAmount;
		pCurrData += 2;
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
			if (CarryGoodsList == null)
			{
				CarryGoodsList = new List<(ItemKey, sbyte)>(elementsCount);
			}
			else
			{
				CarryGoodsList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ItemKey element = default(ItemKey);
				pCurrData += element.Deserialize(pCurrData);
				sbyte data = (sbyte)(*pCurrData);
				pCurrData++;
				CarryGoodsList.Add((element, data));
			}
		}
		else
		{
			CarryGoodsList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (ExchangeGoodsList == null)
			{
				ExchangeGoodsList = new List<ItemKey>(elementsCount2);
			}
			else
			{
				ExchangeGoodsList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ItemKey element2 = default(ItemKey);
				pCurrData += element2.Deserialize(pCurrData);
				ExchangeGoodsList.Add(element2);
			}
		}
		else
		{
			ExchangeGoodsList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (DiaryList == null)
			{
				DiaryList = new List<short>(elementsCount3);
			}
			else
			{
				DiaryList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				DiaryList.Add(((short*)pCurrData)[k]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			DiaryList?.Clear();
		}
		CaravanState = (sbyte)(*pCurrData);
		pCurrData++;
		IsStartSearch = *pCurrData != 0;
		pCurrData++;
		Weather = *(short*)pCurrData;
		pCurrData += 2;
		Terrain = *(short*)pCurrData;
		pCurrData += 2;
		CaravanAwareness = *(short*)pCurrData;
		pCurrData += 2;
		CaravanReplenishment = *(short*)pCurrData;
		pCurrData += 2;
		LackReplenishmentTurn = *(short*)pCurrData;
		pCurrData += 2;
		IsShowSeachReplenishment = *pCurrData != 0;
		pCurrData++;
		IsShowExchangeReplenishment = *pCurrData != 0;
		pCurrData++;
		DistanceToTaiwuVillage = *(short*)pCurrData;
		pCurrData += 2;
		StartMonth = *(short*)pCurrData;
		pCurrData += 2;
		ExchangeReplenishmentAmountMax = *(short*)pCurrData;
		pCurrData += 2;
		ExchangeReplenishmentRemainAmount = *(short*)pCurrData;
		pCurrData += 2;
		SearchReplenishmentMax = *(short*)pCurrData;
		pCurrData += 2;
		SearchReplenishmentAmount = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
