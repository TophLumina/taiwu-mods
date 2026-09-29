using System;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

[Serializable]
[SerializableGameData]
public struct Location(short areaId, short blockId) : ISerializableGameData, IEquatable<Location>
{
	public static readonly Location Invalid = new Location(-1, -1);

	public short AreaId = areaId;

	public short BlockId = blockId;

	public int GetManhattanDistanceToPos(Location other)
	{
		if (!IsValid() || !other.IsValid() || AreaId != other.AreaId)
		{
			return int.MaxValue;
		}
		byte areaSize = ExternalDataBridge.Context.GetAreaSize(AreaId);
		ByteCoordinate pos = ByteCoordinate.IndexToCoordinate(BlockId, areaSize);
		ByteCoordinate otherPos = ByteCoordinate.IndexToCoordinate(other.BlockId, areaSize);
		return pos.GetManhattanDistance(otherPos);
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
		*(short*)pData = AreaId;
		((short*)pData)[1] = BlockId;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		AreaId = *(short*)pData;
		BlockId = ((short*)pData)[1];
		return 4;
	}

	public bool IsValid()
	{
		if (AreaId >= 0)
		{
			return BlockId >= 0;
		}
		return false;
	}

	public static bool operator ==(Location a, Location b)
	{
		if (a.AreaId == b.AreaId)
		{
			return a.BlockId == b.BlockId;
		}
		return false;
	}

	public static bool operator !=(Location a, Location b)
	{
		if (a.AreaId == b.AreaId)
		{
			return a.BlockId != b.BlockId;
		}
		return true;
	}

	public bool Equals(Location other)
	{
		if (AreaId == other.AreaId)
		{
			return BlockId == other.BlockId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is Location other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (AreaId.GetHashCode() * 397) ^ BlockId.GetHashCode();
	}

	public override string ToString()
	{
		return $"{{{AreaId}, {BlockId}}}";
	}
}
