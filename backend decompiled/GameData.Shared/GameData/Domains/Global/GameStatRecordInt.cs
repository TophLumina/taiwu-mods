using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Global;

public class GameStatRecordInt : IGameStatRecord, ISerializableGameData
{
	[SerializableGameDataField]
	private int _value;

	public int GetStat()
	{
		return _value;
	}

	public bool SetStat<T>(T value, EStatInfoSetType setType)
	{
		if (!(value is int case1))
		{
			if (value is List<int> case2)
			{
				_value = 0;
				switch (setType)
				{
				case EStatInfoSetType.Replace:
					_value += case2.Count;
					break;
				case EStatInfoSetType.Remove:
					foreach (int element3 in case2)
					{
						_value &= ~element3;
					}
					break;
				case EStatInfoSetType.AddValue:
					foreach (int element2 in case2)
					{
						_value += element2;
					}
					break;
				case EStatInfoSetType.AddType:
					foreach (int element in case2)
					{
						_value |= element;
					}
					break;
				default:
					throw new Exception("not a valid StatInfoSetType");
				}
				return true;
			}
			return false;
		}
		_value = setType switch
		{
			EStatInfoSetType.Replace => case1, 
			EStatInfoSetType.Remove => _value & ~case1, 
			EStatInfoSetType.AddValue => _value + case1, 
			EStatInfoSetType.AddType => _value | case1, 
			_ => throw new Exception("not a valid StatInfoSetType"), 
		};
		return true;
	}

	public bool Contains(int value)
	{
		return (_value & value) == value;
	}

	public bool Overlaps<T>(T other)
	{
		if (other is GameStatRecordInt value)
		{
			return (value._value & _value) != 0;
		}
		return false;
	}

	public GameStatRecordInt()
	{
		_value = 0;
	}

	public GameStatRecordInt(GameStatRecordInt other)
	{
		_value = other._value;
	}

	public void Assign(GameStatRecordInt other)
	{
		_value = other._value;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = _value;
		int totalSize = (int)(pData + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		_value = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
