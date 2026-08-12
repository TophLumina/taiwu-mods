using System;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 旅行僧相关数据
/// </summary>
[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteTravelingBuddhistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	/// <summary>
	/// 各个州域的寺庙是否被访问过
	/// areaId -&gt; 是否访问过
	/// </summary>
	[SerializableGameDataField]
	public bool[] _stateTempleVisited;

	/// <summary>
	/// 各个州域的寺庙所在位置
	/// areaId -&gt; 寺庙地点 blockId
	/// </summary>
	[SerializableGameDataField]
	public Location[] _stateTempleLocation;

	/// <summary>
	/// 被访问的寺庙数量, 该数据只作为缓存, 不存档
	/// </summary>
	public int _visitedCount;

	/// <summary>
	/// 是否拜访完所有寺庙
	/// </summary>
	public bool HasVisitedAllTemple => _visitedCount >= 15;

	/// <inheritdoc />
	public void Initialize()
	{
		for (int i = 0; i < _stateTempleLocation.Length; i++)
		{
			_stateTempleLocation[i] = Location.Invalid;
		}
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}

	/// <summary>
	/// 获取被访问的寺庙数量
	/// </summary>
	/// <returns></returns>
	public int GetVisitedTempleCount()
	{
		return _visitedCount;
	}

	/// <summary>
	/// 检查指定区域是否建立郭寺庙
	/// </summary>
	public bool StateHasTemple(sbyte stateId)
	{
		if (_stateTempleLocation.CheckIndex(stateId))
		{
			return _stateTempleLocation[stateId].IsValid();
		}
		return false;
	}

	public Location GetStateTempleLocation(sbyte stateId)
	{
		return _stateTempleLocation[stateId];
	}

	/// <summary>
	/// 检查指定区域的寺庙是否被访问过
	/// </summary>
	public bool IsStateTempleVisited(sbyte stateId)
	{
		if (_stateTempleVisited.CheckIndex(stateId))
		{
			return _stateTempleVisited[stateId];
		}
		return false;
	}

	/// <summary>
	/// 计算访问过的寺庙数量
	/// </summary>
	private void CalcVisitedTempleCount()
	{
		int count = 0;
		bool[] stateTempleVisited = _stateTempleVisited;
		for (int i = 0; i < stateTempleVisited.Length; i++)
		{
			if (stateTempleVisited[i])
			{
				count++;
			}
		}
		_visitedCount = count;
	}

	public ObsoleteTravelingBuddhistMonkSkillsData()
	{
		_stateTempleLocation = new Location[15];
		_stateTempleVisited = new bool[15];
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((_stateTempleVisited == null) ? (totalSize + 2) : (totalSize + (2 + _stateTempleVisited.Length)));
		totalSize = ((_stateTempleLocation == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _stateTempleLocation.Length)));
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
		if (_stateTempleVisited != null)
		{
			int elementsCount = _stateTempleVisited.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = (_stateTempleVisited[i] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_stateTempleLocation != null)
		{
			int elementsCount2 = _stateTempleLocation.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += _stateTempleLocation[j].Serialize(pCurrData);
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
			if (_stateTempleVisited == null || _stateTempleVisited.Length != elementsCount)
			{
				_stateTempleVisited = new bool[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				_stateTempleVisited[i] = pCurrData[i] != 0;
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			_stateTempleVisited = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (_stateTempleLocation == null || _stateTempleLocation.Length != elementsCount2)
			{
				_stateTempleLocation = new Location[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				Location element = default(Location);
				pCurrData += element.Deserialize(pCurrData);
				_stateTempleLocation[j] = element;
			}
		}
		else
		{
			_stateTempleLocation = null;
		}
		CalcVisitedTempleCount();
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
