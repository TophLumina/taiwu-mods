using System.Collections.Generic;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Map;

[AutoGenerateSerializableGameData(NotForArchive = true)]
public class TravelRouteDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<TravelRouteElement> AreaList = new List<TravelRouteElement>();

	public short GetTotalTimeCost()
	{
		return (short)AreaList.Sum((TravelRouteElement x) => x.Cost);
	}

	public TravelRouteDisplayData()
	{
	}

	public TravelRouteDisplayData(TravelRouteDisplayData other)
	{
		if (other.AreaList != null)
		{
			List<TravelRouteElement> areaList = other.AreaList;
			int elementsCount = areaList.Count;
			AreaList = new List<TravelRouteElement>(elementsCount);
			{
				foreach (TravelRouteElement element in areaList)
				{
					AreaList.Add(new TravelRouteElement(element));
				}
				return;
			}
		}
		AreaList = null;
	}

	public void Assign(TravelRouteDisplayData other)
	{
		if (other.AreaList != null)
		{
			List<TravelRouteElement> areaList = other.AreaList;
			int elementsCount = areaList.Count;
			AreaList = new List<TravelRouteElement>(elementsCount);
			{
				foreach (TravelRouteElement element in areaList)
				{
					AreaList.Add(new TravelRouteElement(element));
				}
				return;
			}
		}
		AreaList = null;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((AreaList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * AreaList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (AreaList != null)
		{
			int elementsCount = AreaList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += AreaList[i].Serialize(pCurrData);
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (AreaList == null)
			{
				AreaList = new List<TravelRouteElement>();
			}
			else
			{
				AreaList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				TravelRouteElement element = new TravelRouteElement();
				pCurrData += element.Deserialize(pCurrData);
				AreaList.Add(element);
			}
		}
		else
		{
			AreaList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
