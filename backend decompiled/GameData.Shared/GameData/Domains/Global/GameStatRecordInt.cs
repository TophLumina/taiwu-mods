using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Global;

/// <summary>
/// </summary>
public class GameStatRecordInt : IGameStatRecord, ISerializableGameData
{
	/// <summary>
	/// 实际存储在本地存档的值
	/// </summary>
	[SerializableGameDataField]
	private int _value;

	/// <summary>
	/// 将本地存档的值转换为统计需要的int值
	/// </summary>
	/// <returns></returns>
	public int GetStat()
	{
		return _value;
	}

	/// <summary>
	/// 将value存入
	/// </summary>
	/// <param name="value"></param>
	/// <param name="setType"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
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

	/// <summary>
	/// 查询实际存储在本地的值中是否存在一个特定的值
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public bool Contains(int value)
	{
		return (_value & value) == value;
	}

	/// <summary>
	/// 查询两个存储是否共有一个特定的值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public bool Overlaps<T>(T other)
	{
		if (other is GameStatRecordInt value)
		{
			return (value._value & _value) != 0;
		}
		return false;
	}

	/// <summary>
	///
	/// </summary>
	public GameStatRecordInt()
	{
		_value = 0;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="other"></param>
	public GameStatRecordInt(GameStatRecordInt other)
	{
		_value = other._value;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="other"></param>
	public void Assign(GameStatRecordInt other)
	{
		_value = other._value;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
