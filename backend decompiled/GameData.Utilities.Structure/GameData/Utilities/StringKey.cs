using System;
using GameData.Serializer;

namespace GameData.Utilities;

public struct StringKey : IEquatable<StringKey>, ISerializableGameData
{
	private string _internalValue;

	public static implicit operator string(StringKey key)
	{
		return key._internalValue;
	}

	public static implicit operator StringKey(string str)
	{
		return new StringKey
		{
			_internalValue = str
		};
	}

	public bool Equals(StringKey other)
	{
		return _internalValue == other._internalValue;
	}

	public override bool Equals(object obj)
	{
		if (obj is StringKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (_internalValue == null)
		{
			return 0;
		}
		return _internalValue.GetHashCode();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return SerializationHelper.GetSerializedSize(_internalValue);
	}

	public unsafe int Serialize(byte* pData)
	{
		return SerializationHelper.Serialize(pData, _internalValue);
	}

	public unsafe int Deserialize(byte* pData)
	{
		return SerializationHelper.Deserialize(pData, out _internalValue);
	}
}
