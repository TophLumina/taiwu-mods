using System;
using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 特殊杂物数据，用于前端使用提示
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct SpecialMiscData : ISerializableGameData, IEquatable<SpecialMiscData>
{
	/// <summary>
	/// 成功概率
	/// </summary>
	[SerializableGameDataField]
	public int Chance;

	/// <summary>
	/// 显示使用提示
	/// </summary>
	public bool CanUse => Chance > 0;

	/// <summary>
	/// 隐式转换
	/// </summary>
	public static implicit operator SpecialMiscData(int chance)
	{
		return new SpecialMiscData
		{
			Chance = chance
		};
	}

	/// <summary>
	/// 等于运算符
	/// </summary>
	public static bool operator ==(SpecialMiscData lhs, SpecialMiscData rhs)
	{
		return lhs.Chance == rhs.Chance;
	}

	/// <summary>
	/// 不等运算符
	/// </summary>
	public static bool operator !=(SpecialMiscData lhs, SpecialMiscData rhs)
	{
		return lhs.Chance != rhs.Chance;
	}

	/// <inheritdoc />
	public bool Equals(SpecialMiscData other)
	{
		return Chance == other.Chance;
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		if (obj is SpecialMiscData other)
		{
			return Equals(other);
		}
		return false;
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return Chance;
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
		*(int*)pData = Chance;
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
		Chance = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
