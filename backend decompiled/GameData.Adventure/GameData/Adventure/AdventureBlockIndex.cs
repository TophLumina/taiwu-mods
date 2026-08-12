using System;
using System.Collections.Generic;
using GameData.Common.Algorithm;

namespace GameData.Adventure;

public readonly struct AdventureBlockIndex : IAStarPos<AdventureBlockIndex>, IEquatable<AdventureBlockIndex>, IComparable<AdventureBlockIndex>
{
	public const int SubBlockWidth = 3;

	public const int SubBlockHeight = 3;

	public const int SubBlockCount = 9;

	public static readonly IReadOnlyList<EAdventureDirection> Directions;

	public readonly int X;

	public readonly int Y;

	public readonly int I;

	public static AdventureBlockIndex Center => new AdventureBlockIndex(0, 0, CenterI);

	public static int CenterI => IxyToI(0, 0);

	public int Ix => I % 3 - 1;

	public int Iy => I / 3 - 1;

	public int Gx => X * 3 + Ix;

	public int Gy => Y * 3 + Iy;

	public static AdventureBlockIndex XyToCenter(int x, int y)
	{
		return new AdventureBlockIndex(x, y, CenterI);
	}

	public static int IxyToI(int ix, int iy)
	{
		return (iy + 1) * 3 + (ix + 1);
	}

	public static void ClampIxyToXy(ref int ixy, ref int xy, int unit)
	{
		if (ixy < -unit / 2)
		{
			ixy += unit;
			xy--;
		}
		else if (ixy > unit / 2)
		{
			ixy -= unit;
			xy++;
		}
	}

	public static IEnumerable<AdventureBlockIndex> GetIndexes(int size)
	{
		for (int x = -size; x <= size; x++)
		{
			for (int y = -size; y <= size; y++)
			{
				for (int i = 0; i < 9; i++)
				{
					if (Math.Abs(x) + Math.Abs(y) <= size)
					{
						yield return (x: x, y: y, i: i);
					}
				}
			}
		}
	}

	public static IEnumerable<AdventureBlockIndex> GetIndexesBySquare(int size)
	{
		for (int x = -size; x <= size; x++)
		{
			for (int y = -size; y <= size; y++)
			{
				for (int i = 0; i < 9; i++)
				{
					yield return (x: x, y: y, i: i);
				}
			}
		}
	}

	public AdventureBlockIndex(int gx, int gy)
	{
		X = gx / 3;
		Y = gy / 3;
		int ix = gx % 3;
		int iy = gy % 3;
		ClampIxyToXy(ref ix, ref X, 3);
		ClampIxyToXy(ref iy, ref Y, 3);
		I = IxyToI(ix, iy);
	}

	public AdventureBlockIndex(int x, int y, int i)
	{
		X = x;
		Y = y;
		I = i;
	}

	public static implicit operator AdventureBlockIndex((int x, int y, int i) tuple)
	{
		return new AdventureBlockIndex(tuple.x, tuple.y, tuple.i);
	}

	public void Deconstruct(out int x, out int y, out int i)
	{
		int x2 = X;
		int y2 = Y;
		int i2 = I;
		x = x2;
		y = y2;
		i = i2;
	}

	public AdventureBlockIndex SetX(int newX)
	{
		return new AdventureBlockIndex(newX, Y, I);
	}

	public AdventureBlockIndex SetY(int newY)
	{
		return new AdventureBlockIndex(X, newY, I);
	}

	public AdventureBlockIndex SetI(int newI)
	{
		return new AdventureBlockIndex(X, Y, newI);
	}

	public AdventureBlockIndex SetGx(int newGx)
	{
		return new AdventureBlockIndex(newGx, Gy);
	}

	public AdventureBlockIndex SetGy(int newGy)
	{
		return new AdventureBlockIndex(Gx, newGy);
	}

	public AdventureBlockIndex Move(EAdventureDirection direction)
	{
		if (direction == EAdventureDirection.None)
		{
			return this;
		}
		int x = X;
		int y = Y;
		int ix = Ix;
		int iy = Iy;
		int ix2 = ix;
		int y2 = y;
		int x2 = x;
		direction.Move(ref ix2, ref iy);
		ClampIxyToXy(ref ix2, ref x2, 3);
		ClampIxyToXy(ref iy, ref y2, 3);
		return new AdventureBlockIndex(x2, y2, IxyToI(ix2, iy));
	}

	public EAdventureDirection GetDirection(AdventureBlockIndex index)
	{
		int ixDelta = (X - index.X) * 3 + (Ix - index.Ix);
		int iyDelta = (Y - index.Y) * 3 + (Iy - index.Iy);
		if (ixDelta != 0 && iyDelta == 0)
		{
			if (ixDelta <= 0)
			{
				return EAdventureDirection.Right;
			}
			return EAdventureDirection.Left;
		}
		if (ixDelta == 0 && iyDelta != 0)
		{
			if (iyDelta <= 0)
			{
				return EAdventureDirection.Up;
			}
			return EAdventureDirection.Down;
		}
		return EAdventureDirection.None;
	}

	public bool InDirection(AdventureBlockIndex index, EAdventureDirection direction)
	{
		return direction switch
		{
			EAdventureDirection.Up => index.Gy > Gy, 
			EAdventureDirection.Down => index.Gy < Gy, 
			EAdventureDirection.Left => index.Gx < Gx, 
			EAdventureDirection.Right => index.Gx > Gx, 
			_ => false, 
		};
	}

	public AdventureBlockIndex MoveBlock(EAdventureDirection direction)
	{
		if (direction == EAdventureDirection.None)
		{
			return this;
		}
		int x = X;
		int y = Y;
		int x2 = x;
		direction.Move(ref x2, ref y);
		return new AdventureBlockIndex(x2, y, I);
	}

	public int GetManhattanDistance(AdventureBlockIndex other)
	{
		return Math.Abs(Gx - other.Gx) + Math.Abs(Gy - other.Gy);
	}

	public int GetRegionBoxDistance(AdventureBlockIndex other)
	{
		return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
	}

	public int GetChebyshevDistance(AdventureBlockIndex other)
	{
		return Math.Max(Math.Abs(Gx - other.Gx), Math.Abs(Gy - other.Gy));
	}

	public bool XyEquals(AdventureBlockIndex other)
	{
		if (X == other.X)
		{
			return Y == other.Y;
		}
		return false;
	}

	public override string ToString()
	{
		return "(" + X + "," + Y + "," + I + ")";
	}

	public int CompareTo(AdventureBlockIndex other)
	{
		if (X != other.X)
		{
			return X.CompareTo(other.X);
		}
		if (Y != other.Y)
		{
			return Y.CompareTo(other.Y);
		}
		return I.CompareTo(other.I);
	}

	public bool Equals(AdventureBlockIndex other)
	{
		if (X == other.X && Y == other.Y)
		{
			return I == other.I;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is AdventureBlockIndex other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((X * 397) ^ Y) * 397) ^ I;
	}

	public static bool operator ==(AdventureBlockIndex left, AdventureBlockIndex right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(AdventureBlockIndex left, AdventureBlockIndex right)
	{
		return !left.Equals(right);
	}

	static AdventureBlockIndex()
	{
		Directions = new EAdventureDirection[4]
		{
			EAdventureDirection.Up,
			EAdventureDirection.Down,
			EAdventureDirection.Left,
			EAdventureDirection.Right
		};
	}
}
