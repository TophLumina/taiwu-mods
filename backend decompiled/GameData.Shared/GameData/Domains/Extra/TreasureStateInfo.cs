using System;
using GameData.Serializer;

namespace GameData.Domains.Extra;

/// <summary>
/// 宝藏州域分布信息
/// </summary>
[Serializable]
public struct TreasureStateInfo : ISerializableGameData, IEquatable<TreasureStateInfo>
{
	/// <summary>
	/// 州域 ID
	/// </summary>
	[SerializableGameDataField]
	public sbyte MapState;

	/// <summary>
	/// 心材数量
	/// </summary>
	[SerializableGameDataField]
	public sbyte Amount;

	/// <summary>
	/// 从配置表构建的方法
	/// </summary>
	public TreasureStateInfo(sbyte mapState, sbyte amount)
	{
		MapState = mapState;
		Amount = amount;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)MapState;
		byte* num = pData + 1;
		*num = (byte)Amount;
		int totalSize = (int)(num + 1 - pData);
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
		MapState = (sbyte)(*pCurrData);
		pCurrData++;
		Amount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public bool Equals(TreasureStateInfo other)
	{
		if (MapState == other.MapState)
		{
			return Amount == other.Amount;
		}
		return false;
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		if (obj is TreasureStateInfo other)
		{
			return Equals(other);
		}
		return false;
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return (MapState.GetHashCode() * 397) ^ Amount.GetHashCode();
	}
}
