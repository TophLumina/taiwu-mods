using System;
using GameData.Serializer;

namespace GameData.Utilities;

[Serializable]
public struct ShortPair(short first, short second) : ISerializableGameData, IComparable<ShortPair>
{
	public short First = first;

	public short Second = second;

	public static explicit operator int(ShortPair value)
	{
		return (value.Second << 16) + value.First;
	}

	public static explicit operator ShortPair(int value)
	{
		return new ShortPair((short)value, (short)(value >> 16));
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 4;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = First;
		((short*)pData)[1] = Second;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		First = *(short*)pData;
		Second = ((short*)pData)[1];
		return 4;
	}

	public int CompareTo(ShortPair other)
	{
		int result = First - other.First;
		if (result == 0)
		{
			return Second - other.Second;
		}
		return result;
	}

	public bool Equals(ShortPair other)
	{
		if (First == other.First)
		{
			return Second == other.Second;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (First * 397) ^ Second;
	}
}
