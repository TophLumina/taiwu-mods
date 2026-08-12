using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

/// <summary>
/// 茶马帮交易数据
/// </summary>
public class TeaHorseCaravanData : ISerializableGameData
{
	/// <summary>
	/// 来自行囊
	/// </summary>
	public const sbyte FromInventory = 1;

	/// <summary>
	/// 来自仓库
	/// </summary>
	public const sbyte FromWarehouse = 2;

	/// <summary>
	/// 来自公库
	/// </summary>
	public const sbyte FromTreasury = 3;

	/// <summary>
	/// 来自货仓
	/// </summary>
	public const sbyte FromStockStorage = 4;

	/// <summary>
	/// 茶马帮初始补给值 100
	/// </summary>
	public const short CaravanReplenishmentInitValue = 100;

	/// <summary>
	/// 茶马帮初始知名度 100
	/// </summary>
	public const short CaravanAwarenessInitValue = 100;

	/// <summary>
	/// 商队补给每时节消耗 5
	/// </summary>
	public const short CaravanReplenishmentCostPerMonth = 5;

	/// <summary>
	///  携带物品：从行囊仓库等添加进来，丢失时需要从世界删除
	///  item2 保存的是来源FromInventory或者FromWarehouse
	/// </summary>
	[SerializableGameDataField]
	public List<(ItemKey, sbyte)> CarryGoodsList;

	/// <summary>
	/// 收获物品：只有最后回到太吾村才真正创造物品，之前丢失不需要从世界删除
	/// </summary>
	[SerializableGameDataField]
	public List<ItemKey> ExchangeGoodsList;

	/// <summary>
	/// 记录茶马帮遇到的事件，用来显示日志
	/// </summary>
	[Obsolete]
	[SerializableGameDataField]
	public List<short> DiaryList;

	/// <summary>
	/// 茶马帮状态：1：准备出发  2：前进  3：返回  4:携带物品返回待领取
	/// </summary>
	[SerializableGameDataField]
	public sbyte CaravanState;

	/// <summary>
	/// 是否为搜集补给状态（搜集状态下不进行后续判断，过月变成false）
	/// </summary>
	[SerializableGameDataField]
	public bool IsStartSearch;

	/// <summary>
	/// 天气 
	/// </summary>
	[SerializableGameDataField]
	public short Weather;

	/// <summary>
	/// 地形
	/// </summary>
	[SerializableGameDataField]
	public short Terrain;

	/// <summary>
	/// 茶马帮知名度
	/// </summary>
	[SerializableGameDataField]
	public short CaravanAwareness;

	/// <summary>
	/// 携带补给
	/// </summary>
	[SerializableGameDataField]
	public short CaravanReplenishment;

	/// <summary>
	/// 无补给轮次(影响货物丢失概率)
	/// </summary>
	[SerializableGameDataField]
	public short LackReplenishmentTurn;

	/// <summary>
	/// 是否出现搜集补给按钮
	/// </summary>
	[SerializableGameDataField]
	public bool IsShowSeachReplenishment;

	/// <summary>
	/// 是否出现交换补给按钮
	/// </summary>
	[SerializableGameDataField]
	public bool IsShowExchangeReplenishment;

	/// <summary>
	/// 与太吾村的距离
	/// </summary>
	[SerializableGameDataField]
	public short DistanceToTaiwuVillage;

	/// <summary>
	/// 已经出发了的时间
	/// </summary>
	[SerializableGameDataField]
	public short StartMonth;

	/// <summary>
	/// 可以交换补给的数量
	/// </summary>
	[SerializableGameDataField]
	public short ExchangeReplenishmentAmountMax;

	/// <summary>
	/// 可以交换补给的数量
	/// </summary>
	[SerializableGameDataField]
	public short ExchangeReplenishmentRemainAmount;

	/// <summary>
	/// 可以搜寻补给的上限
	/// </summary>
	[SerializableGameDataField]
	public short SearchReplenishmentMax;

	/// <summary>
	/// 每次搜寻补给的数量
	/// </summary>
	[SerializableGameDataField]
	public short SearchReplenishmentAmount;

	/// <summary>
	/// 构造方法, 初始化字段
	/// </summary>
	public TeaHorseCaravanData()
	{
		CarryGoodsList = new List<(ItemKey, sbyte)>();
		ExchangeGoodsList = new List<ItemKey>();
		DiaryList = new List<short>();
		CaravanAwareness = 100;
		CaravanReplenishment = 100;
	}

	/// <summary>
	/// 补给消耗（常规和天气）
	/// </summary>
	/// <returns></returns>
	public int GetReplenishmentCost()
	{
		return TeaHorseCaravanWeather.Instance.GetItem(Weather).ReplenishmentChange + 5;
	}

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc />
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

	/// <inheritdoc />
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

	/// <inheritdoc />
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
