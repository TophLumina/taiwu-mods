using System;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

/// <summary>
/// 地图位置
/// </summary>
[Serializable]
[SerializableGameData]
public struct Location(short areaId, short blockId) : ISerializableGameData, IEquatable<Location>
{
	/// <summary>
	/// 无效的地图位置
	/// </summary>
	public static readonly Location Invalid = new Location(-1, -1);

	/// <summary>
	/// 区域索引, 小于 0 表示无效值.
	/// </summary>
	public short AreaId = areaId;

	/// <summary>
	/// 地块索引, 小于 0 表示无效值.
	/// </summary>
	public short BlockId = blockId;

	/// <summary>
	/// 获取坐标间曼哈顿距离，不可比较时返回 int.MaxValue
	/// </summary>
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

	/// <summary>
	/// 检查地图位置是否有效
	/// </summary>
	/// <returns></returns>
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
