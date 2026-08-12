using System;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Building;

/// <summary>
/// 产业格索引
/// </summary>
public struct BuildingBlockKey(short areaId, short blockId, short buildingBlockIndex) : ISerializableGameData, IEquatable<BuildingBlockKey>
{
	/// <summary>
	/// 区域索引
	/// </summary>
	[SerializableGameDataField]
	public short AreaId = areaId;

	/// <summary>
	/// 地块索引
	/// </summary>
	[SerializableGameDataField]
	public short BlockId = blockId;

	/// <summary>
	/// 在产业地图中的索引
	/// </summary>
	[SerializableGameDataField]
	public short BuildingBlockIndex = buildingBlockIndex;

	public static readonly BuildingBlockKey Invalid = new BuildingBlockKey(-1, -1, 0);

	/// <summary>
	/// 是否为无效
	/// </summary>
	public bool IsInvalid => Equals(Invalid);

	/// <summary>
	/// 获取所在地块
	/// </summary>
	public Location GetLocation()
	{
		return new Location(AreaId, BlockId);
	}

	public bool Equals(BuildingBlockKey other)
	{
		if (AreaId == other.AreaId && BlockId == other.BlockId)
		{
			return BuildingBlockIndex == other.BuildingBlockIndex;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is BuildingBlockKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((AreaId.GetHashCode() * 397) ^ BlockId.GetHashCode()) * 397) ^ BuildingBlockIndex.GetHashCode();
	}

	public static explicit operator ulong(BuildingBlockKey value)
	{
		return (ulong)(((long)value.AreaId << 32) + ((long)value.BlockId << 16) + value.BuildingBlockIndex);
	}

	public static explicit operator BuildingBlockKey(ulong value)
	{
		return new BuildingBlockKey((short)(value >> 32), (short)(value >> 16), (short)value);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = AreaId;
		byte* num = pData + 2;
		*(short*)num = BlockId;
		byte* num2 = num + 2;
		*(short*)num2 = BuildingBlockIndex;
		int totalSize = (int)(num2 + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		AreaId = *(short*)pCurrData;
		pCurrData += 2;
		BlockId = *(short*)pCurrData;
		pCurrData += 2;
		BuildingBlockIndex = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
