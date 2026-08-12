using System;
using GameData.Utilities;

namespace GameData.Domains.Map;

public struct EightDirection : IEquatable<EightDirection>
{
	public static readonly EightDirection Origin;

	public int X;

	public int Y;

	public sbyte Direction;

	public int Value;

	public const sbyte Invalid = -1;

	public const sbyte Start = 0;

	public const sbyte North = 0;

	public const sbyte NorthEast = 1;

	public const sbyte East = 2;

	public const sbyte SouthEast = 3;

	public const sbyte South = 4;

	public const sbyte SouthWest = 5;

	public const sbyte West = 6;

	public const sbyte NorthWest = 7;

	public const sbyte Count = 8;

	public const int Sqrt2 = 1414;

	public const int Scale = 1000;

	public EightDirection(ByteCoordinate origin, ByteCoordinate position)
	{
		X = position.X - origin.X;
		Y = position.Y - origin.Y;
		bool isNorth = Y > 0;
		bool isEast = X > 0;
		if (X == 0 && Y == 0)
		{
			Direction = -1;
		}
		else if (X == 0)
		{
			Direction = (sbyte)((!isNorth) ? 4 : 0);
		}
		else if (Y == 0)
		{
			Direction = (sbyte)(isEast ? 2 : 6);
		}
		else
		{
			int kxGreater = 2414 * X * (isEast ? 1 : (-1));
			int kxSmaller = 414 * X * (isEast ? 1 : (-1));
			int yScaled = 1000 * Y * (isNorth ? 1 : (-1));
			if (isNorth)
			{
				if (yScaled > kxGreater)
				{
					Direction = 0;
				}
				else
				{
					Direction = (sbyte)((!isEast) ? ((yScaled < kxSmaller) ? 6 : 7) : ((yScaled >= kxSmaller) ? 1 : 2));
				}
			}
			else if (yScaled > kxGreater)
			{
				Direction = 4;
			}
			else
			{
				Direction = (sbyte)((!isEast) ? ((yScaled < kxSmaller) ? 6 : 5) : ((yScaled < kxSmaller) ? 2 : 3));
			}
		}
		sbyte direction = Direction;
		if (1 == 0)
		{
		}
		int value;
		switch (direction)
		{
		case 0:
		case 4:
			value = X * X;
			break;
		case 2:
		case 6:
			value = Y * Y;
			break;
		case 1:
		case 5:
			value = (X - Y) * (X - Y) * 1000 / 1414;
			break;
		case 3:
		case 7:
			value = (-X - Y) * (-X - Y) * 1000 / 1414;
			break;
		default:
			value = 0;
			break;
		}
		if (1 == 0)
		{
		}
		Value = value;
	}

	public EightDirection(EightDirection other, int score)
	{
		X = other.X;
		Y = other.Y;
		Direction = other.Direction;
		Value = score;
	}

	public EightDirection()
	{
		X = 0;
		Y = 0;
		Direction = -1;
		Value = 0;
	}

	public int GetManhattanDistance(EightDirection other)
	{
		int x = X - other.X;
		int y = Y - other.Y;
		if (x < 0)
		{
			x = -x;
		}
		if (y < 0)
		{
			y = -y;
		}
		return x + y;
	}

	public bool Equals(EightDirection other)
	{
		return X == other.X && Y == other.Y;
	}

	static EightDirection()
	{
		Origin = new EightDirection();
	}
}
