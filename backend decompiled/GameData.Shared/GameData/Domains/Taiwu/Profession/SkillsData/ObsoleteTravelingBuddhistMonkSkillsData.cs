using System;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteTravelingBuddhistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	[SerializableGameDataField]
	public bool[] _stateTempleVisited;

	[SerializableGameDataField]
	public Location[] _stateTempleLocation;

	public int _visitedCount;

	public bool HasVisitedAllTemple => _visitedCount >= 15;

	public void Initialize()
	{
		for (int i = 0; i < _stateTempleLocation.Length; i++)
		{
			_stateTempleLocation[i] = Location.Invalid;
		}
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}

	public int GetVisitedTempleCount()
	{
		return _visitedCount;
	}

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

	public bool IsStateTempleVisited(sbyte stateId)
	{
		if (_stateTempleVisited.CheckIndex(stateId))
		{
			return _stateTempleVisited[stateId];
		}
		return false;
	}

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

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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
