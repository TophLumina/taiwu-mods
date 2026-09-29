using System;
using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public struct SpecialMiscData : ISerializableGameData, IEquatable<SpecialMiscData>
{
	[SerializableGameDataField]
	public int Chance;

	public bool CanUse => Chance > 0;

	public static implicit operator SpecialMiscData(int chance)
	{
		return new SpecialMiscData
		{
			Chance = chance
		};
	}

	public static bool operator ==(SpecialMiscData lhs, SpecialMiscData rhs)
	{
		return lhs.Chance == rhs.Chance;
	}

	public static bool operator !=(SpecialMiscData lhs, SpecialMiscData rhs)
	{
		return lhs.Chance != rhs.Chance;
	}

	public bool Equals(SpecialMiscData other)
	{
		return Chance == other.Chance;
	}

	public override bool Equals(object obj)
	{
		if (obj is SpecialMiscData other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Chance;
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
		*(int*)pData = Chance;
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
