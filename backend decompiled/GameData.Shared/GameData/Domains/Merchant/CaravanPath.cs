using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Merchant;

/// <summary>
/// 商队旅行路线
/// </summary>
[Serializable]
public class CaravanPath : ISerializableGameData
{
	/// <summary>
	/// 每次移动前进天数
	/// </summary>
	public const int CostDaysPerMove = 15;

	/// <summary>
	/// 途经地块列表
	/// </summary>
	[SerializableGameDataField]
	public List<Location> FullPath = new List<Location>();

	/// <summary>
	/// 每一次移动后所在地址索引。对应FullPath的索引，为-1时表示位于区域之间的虚空中
	/// </summary>
	[SerializableGameDataField]
	public List<int> MoveNodes = new List<int>();

	/// <summary>
	/// 下次移动等待时间
	/// </summary>
	[SerializableGameDataField]
	public short MoveWaitDays;

	public CaravanPath(List<(Location location, short cost)> path)
	{
	}

	/// <summary>
	/// 获取当前所在地块，位于虚空时返回路线中的下一个地块
	/// </summary>
	public Location GetCurrLocation()
	{
		int nodeIndex;
		for (nodeIndex = 0; MoveNodes[nodeIndex] < 0; nodeIndex++)
		{
		}
		return FullPath[MoveNodes[nodeIndex]];
	}

	/// <summary>
	/// 获取下一个地块，位于虚空时返回当前地块
	/// </summary>
	/// <returns></returns>
	public Location GetNextLocation()
	{
		Location location = GetCurrLocation();
		int nextIndex = FullPath.IndexOf(location) + 1;
		if (!FullPath.CheckIndex(nextIndex))
		{
			return location;
		}
		return FullPath[nextIndex];
	}

	/// <summary>
	/// 获取上一个地块，位于虚空时返回当前地块
	/// </summary>
	/// <returns></returns>
	public Location GetLastLocation()
	{
		Location location = GetCurrLocation();
		int lastIndex = FullPath.IndexOf(location) - 1;
		if (!FullPath.CheckIndex(lastIndex))
		{
			return location;
		}
		return FullPath[lastIndex];
	}

	/// <summary>
	/// 获取终点地块
	/// </summary>
	/// <returns></returns>
	public Location GetDestLocation()
	{
		return FullPath.Last();
	}

	/// <summary>
	/// 获取起点地块
	/// </summary>
	/// <returns></returns>
	public Location GetSrcLocation()
	{
		return FullPath.First();
	}

	/// <summary>
	/// 获取商队在当前地区的剩余路径，包括当前位置
	/// </summary>
	/// <returns></returns>
	public CaravanPath GetRemainCaravanPathInCurrentArea()
	{
		CaravanPath path = new CaravanPath();
		path.MoveWaitDays = MoveWaitDays;
		Location location = GetCurrLocation();
		Location nextLocation = GetNextLocation();
		Location lastLocation = GetLastLocation();
		int locationIndex = -1;
		for (int i = 0; i < FullPath.Count; i++)
		{
			if (location == FullPath[i])
			{
				int next = i + 1;
				bool num = !FullPath.CheckIndex(next) || FullPath[next] == nextLocation;
				int last = i - 1;
				bool lastIsSame = !FullPath.CheckIndex(last) || FullPath[last] == lastLocation;
				if (num && lastIsSame)
				{
					locationIndex = i;
					break;
				}
			}
		}
		for (int j = locationIndex; j < FullPath.Count; j++)
		{
			Location nodeLocation = FullPath[j];
			if (nodeLocation.AreaId == location.AreaId)
			{
				path.FullPath.Add(nodeLocation);
			}
		}
		List<Location> originNodes = (from index in MoveNodes
			where FullPath.CheckIndex(index)
			select FullPath[index]).ToList();
		for (int i2 = 0; i2 < path.FullPath.Count; i2++)
		{
			Location nodeLocation2 = path.FullPath[i2];
			if (originNodes.Contains(nodeLocation2))
			{
				path.MoveNodes.Add(i2);
			}
		}
		return path;
	}

	public CaravanPath()
	{
	}

	public CaravanPath(CaravanPath other)
	{
		FullPath = new List<Location>(other.FullPath);
		MoveNodes = new List<int>(other.MoveNodes);
		MoveWaitDays = other.MoveWaitDays;
	}

	public void Assign(CaravanPath other)
	{
		FullPath = new List<Location>(other.FullPath);
		MoveNodes = new List<int>(other.MoveNodes);
		MoveWaitDays = other.MoveWaitDays;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((FullPath == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FullPath.Count)));
		totalSize = ((MoveNodes == null) ? (totalSize + 2) : (totalSize + (2 + 4 * MoveNodes.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (FullPath != null)
		{
			int elementsCount = FullPath.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += FullPath[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (MoveNodes != null)
		{
			int elementsCount2 = MoveNodes.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = MoveNodes[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = MoveWaitDays;
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
			if (FullPath == null)
			{
				FullPath = new List<Location>(elementsCount);
			}
			else
			{
				FullPath.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				Location element = default(Location);
				pCurrData += element.Deserialize(pCurrData);
				FullPath.Add(element);
			}
		}
		else
		{
			FullPath?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (MoveNodes == null)
			{
				MoveNodes = new List<int>(elementsCount2);
			}
			else
			{
				MoveNodes.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				MoveNodes.Add(((int*)pCurrData)[j]);
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			MoveNodes?.Clear();
		}
		MoveWaitDays = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
