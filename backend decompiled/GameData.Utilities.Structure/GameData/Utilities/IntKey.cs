using System;
using GameData.Serializer;

namespace GameData.Utilities;

public struct IntKey : ISerializableGameData, IEquatable<IntKey>
{
	private int _internalValue;

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
		*(int*)pData = _internalValue;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		_internalValue = *(int*)pData;
		return 4;
	}

	public bool Equals(IntKey other)
	{
		return _internalValue == other._internalValue;
	}

	public override bool Equals(object obj)
	{
		if (obj is IntKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _internalValue;
	}
}
