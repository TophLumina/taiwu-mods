using System;
using GameData.Serializer;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

/// <summary>
/// 过月行为的唯一Key
/// </summary>
[Serializable]
public struct MonthlyActionKey(sbyte actionType, short index = 0) : ISerializableGameData, IEquatable<MonthlyActionKey>
{
	/// <summary>
	/// 是否为配置表中配置的过月行为
	/// </summary>
	[SerializableGameDataField]
	public sbyte ActionType = actionType;

	/// <summary>
	/// 该过月行为在集合中的序号
	/// </summary>
	[SerializableGameDataField]
	public short Index = index;

	/// <summary>
	/// 无效值
	/// </summary>
	public static readonly MonthlyActionKey Invalid = new MonthlyActionKey(-1, -1);

	/// <summary>
	/// 是否为有效Key
	/// </summary>
	/// <returns></returns>
	public bool IsValid()
	{
		return Index >= 0;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)ActionType;
		byte* num = pData + 1;
		*(short*)num = Index;
		int totalSize = (int)(num + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ActionType = (sbyte)(*pCurrData);
		pCurrData++;
		Index = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public override string ToString()
	{
		return $"({ActionType},{Index})";
	}

	public bool Equals(MonthlyActionKey other)
	{
		if (ActionType == other.ActionType)
		{
			return Index == other.Index;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is MonthlyActionKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (ActionType.GetHashCode() * 397) ^ Index.GetHashCode();
	}
}
