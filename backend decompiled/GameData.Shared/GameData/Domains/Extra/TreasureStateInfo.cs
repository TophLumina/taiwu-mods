using System;
using GameData.Serializer;

namespace GameData.Domains.Extra;

[Serializable]
public struct TreasureStateInfo(sbyte mapState, sbyte amount) : ISerializableGameData, IEquatable<TreasureStateInfo>
{
	[SerializableGameDataField]
	public sbyte MapState = mapState;

	[SerializableGameDataField]
	public sbyte Amount = amount;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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

	public bool Equals(TreasureStateInfo other)
	{
		if (MapState == other.MapState)
		{
			return Amount == other.Amount;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is TreasureStateInfo other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (MapState.GetHashCode() * 397) ^ Amount.GetHashCode();
	}
}
