using System;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Global;

[SerializableGameData(NotForDisplayModule = true)]
public class GameStatRecordWrapper : ISerializableGameData
{
	private short _statId;

	private IGameStatRecord _record;

	public GameStatRecordWrapper()
	{
		_statId = -1;
		_record = null;
	}

	public GameStatRecordWrapper(short statId)
	{
		_statId = statId;
		_record = CreateGameStatRecord();
	}

	public IGameStatRecord CreateGameStatRecord()
	{
		return StatInfo.Instance[_statId].Type switch
		{
			EStatInfoType.Int => new GameStatRecordInt(), 
			EStatInfoType.ListInt => new GameStatRecordListInt(), 
			_ => throw new Exception(StatInfo.Instance[_statId].Name + " has a invalid type"), 
		};
	}

	public int GetStat()
	{
		return _record.GetStat();
	}

	public bool SetStat<T>(T value, EStatInfoSetType setType)
	{
		return _record.SetStat(value, setType);
	}

	public bool Contains(int value)
	{
		return _record.Contains(value);
	}

	public bool Overlaps(GameStatRecordWrapper other)
	{
		return _record.Overlaps(other._record);
	}

	public GameStatRecordWrapper(GameStatRecordWrapper other)
	{
		_statId = other._statId;
		_record = other._record;
	}

	public void Assign(GameStatRecordWrapper other)
	{
		_statId = other._statId;
		_record = other._record;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (_statId >= 0)
		{
			totalSize += _record.GetSerializedSize();
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = _statId;
		pCurrData += 2;
		if (_statId >= 0)
		{
			pCurrData += _record.Serialize(pCurrData);
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
		_statId = *(short*)pCurrData;
		pCurrData += 2;
		if (_statId >= 0)
		{
			_record = CreateGameStatRecord();
			pCurrData += _record.Deserialize(pCurrData);
		}
		else
		{
			_record = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
