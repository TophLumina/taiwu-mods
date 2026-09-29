using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

public class TravelRoute : ISerializableGameData
{
	public readonly List<ByteCoordinate> PosList = new List<ByteCoordinate>();

	public readonly List<short> AreaList = new List<short>();

	public readonly List<short> CostList = new List<short>();

	public TravelRoute()
	{
	}

	public TravelRoute(TravelRoute other)
	{
		PosList.Clear();
		PosList.AddRange(other.PosList);
		AreaList.Clear();
		AreaList.AddRange(other.AreaList);
		CostList.Clear();
		CostList.AddRange(other.CostList);
	}

	public short GetTotalTimeCost()
	{
		int totalTimeCost = 0;
		for (int i = 0; i < CostList.Count; i++)
		{
			totalTimeCost += CostList[i];
		}
		return (short)totalTimeCost;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 2 + 2 * PosList.Count + 2 + 2 * AreaList.Count + 2 + 2 * CostList.Count;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int elementsCount = PosList.Count;
		*(ushort*)pCurrData = (ushort)elementsCount;
		pCurrData += 2;
		for (int i = 0; i < PosList.Count; i++)
		{
			ByteCoordinate item = PosList[i];
			*pCurrData = item.X;
			pCurrData++;
			*pCurrData = item.Y;
			pCurrData++;
		}
		elementsCount = AreaList.Count;
		*(ushort*)pCurrData = (ushort)elementsCount;
		pCurrData += 2;
		for (int j = 0; j < AreaList.Count; j++)
		{
			*(short*)pCurrData = AreaList[j];
			pCurrData += 2;
		}
		elementsCount = CostList.Count;
		*(ushort*)pCurrData = (ushort)elementsCount;
		pCurrData += 2;
		for (int k = 0; k < CostList.Count; k++)
		{
			*(short*)pCurrData = CostList[k];
			pCurrData += 2;
		}
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		PosList.Clear();
		PosList.Capacity = elementsCount;
		ByteCoordinate item = default(ByteCoordinate);
		for (int i = 0; i < elementsCount; i++)
		{
			item.X = *pCurrData;
			pCurrData++;
			item.Y = *pCurrData;
			pCurrData++;
			PosList.Add(item);
		}
		elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		AreaList.Clear();
		AreaList.Capacity = elementsCount;
		for (int j = 0; j < elementsCount; j++)
		{
			short item2 = *(short*)pCurrData;
			pCurrData += 2;
			AreaList.Add(item2);
		}
		elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		CostList.Clear();
		CostList.Capacity = elementsCount;
		for (int k = 0; k < elementsCount; k++)
		{
			short item3 = *(short*)pCurrData;
			pCurrData += 2;
			CostList.Add(item3);
		}
		return (int)(pCurrData - pData);
	}
}
