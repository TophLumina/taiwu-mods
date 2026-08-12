using System.Collections.Generic;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Map;

/// <summary>
/// 长途旅行路线
/// 纯显示数据，不入存档
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true)]
public class TravelRouteDisplayData : ISerializableGameData
{
	/// <summary>
	/// 途经区域列表。含起点与终点
	/// </summary>
	[SerializableGameDataField]
	public List<TravelRouteElement> AreaList = new List<TravelRouteElement>();

	/// <summary>
	/// 获取总消耗天数
	/// </summary>
	public short GetTotalTimeCost()
	{
		return (short)AreaList.Sum((TravelRouteElement x) => x.Cost);
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TravelRouteDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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
