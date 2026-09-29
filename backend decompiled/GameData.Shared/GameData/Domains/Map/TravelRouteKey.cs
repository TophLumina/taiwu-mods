using System;
using GameData.Serializer;

namespace GameData.Domains.Map;

public struct TravelRouteKey(short fromAreaId, short toAreaId) : ISerializableGameData, IEquatable<TravelRouteKey>
{
	public short FromAreaId = fromAreaId;

	public short ToAreaId = toAreaId;

	public void Reverse()
	{
		FromAreaId += ToAreaId;
		ToAreaId = (short)(FromAreaId - ToAreaId);
		FromAreaId -= ToAreaId;
	}

	public bool Equals(TravelRouteKey other)
	{
		if (FromAreaId == other.FromAreaId)
		{
			return ToAreaId == other.ToAreaId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is TravelRouteKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (FromAreaId.GetHashCode() * 397) ^ ToAreaId.GetHashCode();
	}

	public override string ToString()
	{
		return $"{FromAreaId} => {ToAreaId}";
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
		*(short*)pData = FromAreaId;
		((short*)pData)[1] = ToAreaId;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		FromAreaId = *(short*)pData;
		ToAreaId = ((short*)pData)[1];
		return 4;
	}
}
