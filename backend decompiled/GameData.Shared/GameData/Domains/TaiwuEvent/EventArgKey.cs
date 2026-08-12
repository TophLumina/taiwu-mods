using System;
using GameData.Serializer;

namespace GameData.Domains.TaiwuEvent;

public struct EventArgKey : ISerializableGameData, IEquatable<EventArgKey>
{
	private string _internalValue;

	public static implicit operator string(EventArgKey key)
	{
		return key._internalValue;
	}

	public static implicit operator EventArgKey(string str)
	{
		return new EventArgKey
		{
			_internalValue = str
		};
	}

	public bool Equals(EventArgKey other)
	{
		return _internalValue == other._internalValue;
	}

	public override bool Equals(object obj)
	{
		if (obj is EventArgKey other)
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
