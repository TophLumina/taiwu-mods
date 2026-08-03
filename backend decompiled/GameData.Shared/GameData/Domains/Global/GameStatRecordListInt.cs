using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Global;

/// <summary>
/// </summary>
public class GameStatRecordListInt : IGameStatRecord, ISerializableGameData
{
	/// <summary>
	/// 实际存储在本地存档的值
	/// </summary>
	[SerializableGameDataField]
	private List<int> _value;

	/// <summary>
	/// 将本地存档的值转换为统计需要的int值
	/// </summary>
	/// 该值为列表长度
	/// <returns></returns>
	public int GetStat()
	{
		return _value.Count;
	}

	/// <summary>
	/// 将value存入本地存储
	/// </summary>
	/// <param name="value"></param>
	/// <param name="setType"></param>
	/// <typeparam name="T">
	/// 输入值为int会导致列表更新为仅包含该输入值的新表
	/// 输入值为ListInt会导致列表更新为输入值
	/// </typeparam>
	/// <returns></returns>
	public bool SetStat<T>(T value, EStatInfoSetType setType)
	{
		if (!(value is int case1))
		{
			if (value is List<int> case2)
			{
				switch (setType)
				{
				case EStatInfoSetType.Replace:
					_value = case2;
					return true;
				case EStatInfoSetType.Remove:
					foreach (int x2 in case2)
					{
						foreach (int y2 in _value)
						{
							if (x2 == y2)
							{
								_value.Remove(x2);
								break;
							}
						}
					}
					return true;
				case EStatInfoSetType.AddValue:
				case EStatInfoSetType.AddType:
					foreach (int x in case2)
					{
						bool flag = true;
						foreach (int y in _value)
						{
							if (x == y)
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							_value.Add(x);
						}
					}
					return true;
				default:
					throw new Exception("not a valid StatInfoSetType");
				}
			}
			return false;
		}
		switch (setType)
		{
		case EStatInfoSetType.Replace:
			_value = new List<int> { case1 };
			return true;
		case EStatInfoSetType.Remove:
			foreach (int val in _value)
			{
				if (val == case1)
				{
					_value.Remove(val);
					break;
				}
			}
			return true;
		case EStatInfoSetType.AddValue:
		case EStatInfoSetType.AddType:
			foreach (int item in _value)
			{
				if (item == case1)
				{
					return true;
				}
			}
			_value.Add(case1);
			return true;
		default:
			throw new Exception("not a valid StatInfoSetType");
		}
	}

	/// <summary>
	/// 查询一个值是否在表中
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public bool Contains(int value)
	{
		foreach (int item in _value)
		{
			if (item == value)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 查询两个存储是否共有一个特定的值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public bool Overlaps<T>(T other)
	{
		if (other is GameStatRecordListInt value)
		{
			foreach (int value2 in _value)
			{
				foreach (int value3 in value._value)
				{
					if (value2 == value3)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	/// <summary>
	///
	/// </summary>
	public GameStatRecordListInt()
	{
		_value = new List<int>();
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="other"></param>
	public GameStatRecordListInt(GameStatRecordListInt other)
	{
		_value = new List<int>(other._value);
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="other"></param>
	public void Assign(GameStatRecordListInt other)
	{
		_value = new List<int>(other._value);
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
		totalSize = ((_value == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _value.Count)));
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
		if (_value != null)
		{
			int elementsCount = _value.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _value[i];
			}
			pCurrData += 4 * elementsCount;
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
			if (_value == null)
			{
				_value = new List<int>(elementsCount);
			}
			else
			{
				_value.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				_value.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			_value?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
