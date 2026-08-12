using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Map;

/// <summary>
/// 地格八方向特效类型
/// 与地格特效资源对应
/// </summary>
public class MapBlockEightDirectionType
{
	public const sbyte LeftUpDown = 0;

	public const sbyte LeftUp = 1;

	public const sbyte LeftUpRight = 2;

	public const sbyte LeftDown = 3;

	public const sbyte UpRight = 4;

	public const sbyte LeftDownRight = 5;

	public const sbyte DownRight = 6;

	public const sbyte UpDownRight = 7;

	public const sbyte Left = 1;

	public const sbyte Up = 2;

	public const sbyte Down = 4;

	public const sbyte Right = 8;

	public const sbyte AllDirection = 15;

	/// <summary>
	/// 一个地格是否在指定区域
	/// </summary>
	/// <param name="blocks"></param>
	/// <param name="areaSize"></param>
	/// <param name="coordinateX"></param>
	/// <param name="coordinateY"></param>
	/// <returns></returns>
	public static bool IsBlockInArea(Dictionary<short, int> blocks, byte areaSize, int coordinateX, int coordinateY)
	{
		if (coordinateX >= 0 && coordinateY >= 0)
		{
			return blocks.ContainsKey(ByteCoordinate.CoordinateToIndex(new ByteCoordinate((byte)coordinateX, (byte)coordinateY), areaSize));
		}
		return false;
	}

	/// <inheritdoc cref="M:GameData.Domains.Map.MapBlockEightDirectionType.IsBlockInArea(System.Collections.Generic.Dictionary{System.Int16,System.Int32},System.Byte,System.Int32,System.Int32)" />
	public static bool IsBlockInArea(Dictionary<short, short> blocks, byte areaSize, int coordinateX, int coordinateY, short settlementBlockId)
	{
		if (coordinateX >= 0 && coordinateY >= 0 && blocks.TryGetValue(ByteCoordinate.CoordinateToIndex(new ByteCoordinate((byte)coordinateX, (byte)coordinateY), areaSize), out var id))
		{
			return id == settlementBlockId;
		}
		return false;
	}

	/// <inheritdoc cref="M:GameData.Domains.Map.MapBlockEightDirectionType.IsBlockInArea(System.Collections.Generic.Dictionary{System.Int16,System.Int32},System.Byte,System.Int32,System.Int32)" />
	public static bool IsBlockInArea(HashSet<short> blocks, byte areaSize, int coordinateX, int coordinateY)
	{
		if (coordinateX >= 0 && coordinateY >= 0)
		{
			return blocks.Contains(ByteCoordinate.CoordinateToIndex(new ByteCoordinate((byte)coordinateX, (byte)coordinateY), areaSize));
		}
		return false;
	}

	/// <summary>
	/// 获取四方向类型
	/// </summary>
	/// <param name="blocks"></param>
	/// <param name="areaSize"></param>
	/// <param name="blockId"></param>
	/// <returns></returns>
	public static sbyte GetDirectionType(Dictionary<short, int> blocks, byte areaSize, short blockId)
	{
		ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(blockId, areaSize);
		sbyte res = 0;
		if (IsBlockInArea(blocks, areaSize, blockPos.X - 1, blockPos.Y))
		{
			res |= 1;
		}
		if (IsBlockInArea(blocks, areaSize, blockPos.X + 1, blockPos.Y))
		{
			res |= 8;
		}
		if (IsBlockInArea(blocks, areaSize, blockPos.X, blockPos.Y - 1))
		{
			res |= 4;
		}
		if (IsBlockInArea(blocks, areaSize, blockPos.X, blockPos.Y + 1))
		{
			res |= 2;
		}
		return res;
	}

	/// <summary>
	/// 获取四方向类型
	/// </summary>
	/// <param name="blocks"></param>
	/// <param name="areaSize"></param>
	/// <param name="blockId"></param>
	/// <returns></returns>
	public static sbyte GetDirectionType(HashSet<short> blocks, byte areaSize, short blockId)
	{
		ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(blockId, areaSize);
		sbyte res = 0;
		if (IsBlockInArea(blocks, areaSize, blockPos.X - 1, blockPos.Y))
		{
			res |= 1;
		}
		if (IsBlockInArea(blocks, areaSize, blockPos.X + 1, blockPos.Y))
		{
			res |= 8;
		}
		if (IsBlockInArea(blocks, areaSize, blockPos.X, blockPos.Y - 1))
		{
			res |= 4;
		}
		if (IsBlockInArea(blocks, areaSize, blockPos.X, blockPos.Y + 1))
		{
			res |= 2;
		}
		return res;
	}

	/// <summary>
	/// 获取四方向类型
	/// </summary>
	/// <param name="blocks"></param>
	/// <param name="areaSize"></param>
	/// <param name="blockId"></param>
	/// <returns></returns>
	public static sbyte GetDirectionType(Dictionary<short, short> blocks, byte areaSize, short blockId)
	{
		ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(blockId, areaSize);
		sbyte res = 0;
		if (!blocks.TryGetValue(blockId, out var settlementBlockId))
		{
			return res;
		}
		if (IsBlockInArea(blocks, areaSize, blockPos.X - 1, blockPos.Y, settlementBlockId))
		{
			res |= 1;
		}
		if (IsBlockInArea(blocks, areaSize, blockPos.X + 1, blockPos.Y, settlementBlockId))
		{
			res |= 8;
		}
		if (IsBlockInArea(blocks, areaSize, blockPos.X, blockPos.Y - 1, settlementBlockId))
		{
			res |= 4;
		}
		if (IsBlockInArea(blocks, areaSize, blockPos.X, blockPos.Y + 1, settlementBlockId))
		{
			res |= 2;
		}
		return res;
	}

	public static int GetSingleIndex(int type)
	{
		return type switch
		{
			1 => 0, 
			2 => 1, 
			4 => 2, 
			8 => 3, 
			_ => -1, 
		};
	}
}
