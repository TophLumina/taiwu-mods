using System;
using GameData.Common;

namespace GameData.Dependencies;

public readonly struct DataUidWithType(DomainDataType type, DataUid dataUid) : IEquatable<DataUidWithType>
{
	public readonly DomainDataType Type = type;

	public readonly DataUid DataUid = dataUid;

	public bool Equals(DataUidWithType other)
	{
		return Type == other.Type && DataUid.Equals(other.DataUid);
	}

	public override bool Equals(object obj)
	{
		return obj is DataUidWithType other && Equals(other);
	}

	public override int GetHashCode()
	{
		return ((int)Type * 397) ^ DataUid.GetHashCode();
	}
}
