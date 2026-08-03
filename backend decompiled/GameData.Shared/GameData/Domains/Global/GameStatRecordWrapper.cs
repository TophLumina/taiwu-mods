using System;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Global;

/// <summary>
///
/// </summary>
[SerializableGameData(NotForDisplayModule = true)]
public class GameStatRecordWrapper : ISerializableGameData
{
	private short _statId;

	private IGameStatRecord _record;

	/// <summary>
	///
	/// </summary>
	public GameStatRecordWrapper()
	{
		_statId = -1;
		_record = null;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="statId"></param>
	public GameStatRecordWrapper(short statId)
	{
		_statId = statId;
		_record = CreateGameStatRecord();
	}

	/// <summary>
	///
	/// </summary>
	/// <returns></returns>
	/// <exception cref="T:System.Exception"></exception>
	public IGameStatRecord CreateGameStatRecord()
	{
		return StatInfo.Instance[_statId].Type switch
		{
			EStatInfoType.Int => new GameStatRecordInt(), 
			EStatInfoType.ListInt => new GameStatRecordListInt(), 
			_ => throw new Exception(StatInfo.Instance[_statId].Name + " has a invalid type"), 
		};
	}

	/// <summary>
	/// 将统计的存储值转换为成就统计实际所需要的int值
	/// </summary>
	/// <returns></returns>
	public int GetStat()
	{
		return _record.GetStat();
	}

	/// <summary>
	/// 修改一个统计的存储值
	/// </summary>
	/// <param name="value"></param>
	/// <param name="setType"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public bool SetStat<T>(T value, EStatInfoSetType setType)
	{
		return _record.SetStat(value, setType);
	}

	/// <summary>
	/// 查询统计的存储是否存在一个特定的值
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public bool Contains(int value)
	{
		return _record.Contains(value);
	}

	/// <summary>
	/// 查询两个统计的存储是否共有一个特定的值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public bool Overlaps(GameStatRecordWrapper other)
	{
		return _record.Overlaps(other._record);
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="other"></param>
	public GameStatRecordWrapper(GameStatRecordWrapper other)
	{
		_statId = other._statId;
		_record = other._record;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="other"></param>
	public void Assign(GameStatRecordWrapper other)
	{
		_statId = other._statId;
		_record = other._record;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
