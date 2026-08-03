using System;

namespace GameData.Utilities;

public struct Coordinate2D<T> : IEquatable<Coordinate2D<T>> where T : unmanaged
{
	private static Func<T, T, bool> _opEquals;

	private static Func<T, T, T> _opAdd;

	private static Func<T, T, T> _opMinus;

	private static Func<T, T> _opAbs;

	private static Func<T, int> _opToInt;

	private static Func<T, double> _opToReal;

	public T X;

	public T Y;

	public static Coordinate2D<T> Zero => default(Coordinate2D<T>);

	public static void Initialize(Func<T, T, bool> opEquals, Func<T, T, T> opAdd, Func<T, T, T> opMinus, Func<T, T> opAbs, Func<T, int> opToInt, Func<T, double> opToReal)
	{
		_opEquals = opEquals;
		_opAdd = opAdd;
		_opMinus = opMinus;
		_opAbs = opAbs;
		_opToInt = opToInt;
		_opToReal = opToReal;
	}

	public Coordinate2D(T x, T y)
	{
		X = x;
		Y = y;
	}

	public override string ToString()
	{
		return $"({X}, {Y})";
	}

	public bool Equals(Coordinate2D<T> other)
	{
		if (_opEquals(X, other.X))
		{
			return _opEquals(Y, other.Y);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is Coordinate2D<T> other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y);
	}

	public static bool operator ==(Coordinate2D<T> a, Coordinate2D<T> b)
	{
		if (_opEquals(a.X, b.X))
		{
			return _opEquals(a.Y, b.Y);
		}
		return false;
	}

	public static bool operator !=(Coordinate2D<T> a, Coordinate2D<T> b)
	{
		return !(a == b);
	}

	public static Coordinate2D<T> operator +(Coordinate2D<T> a, Coordinate2D<T> b)
	{
		return new Coordinate2D<T>(_opAdd(a.X, b.X), _opAdd(a.Y, b.Y));
	}

	public static Coordinate2D<T> operator -(Coordinate2D<T> a, Coordinate2D<T> b)
	{
		return new Coordinate2D<T>(_opAbs(_opMinus(a.X, b.X)), _opAbs(_opMinus(a.Y, b.Y)));
	}

	public int GetManhattanDistance(Coordinate2D<T> a, Coordinate2D<T> b)
	{
		return _opToInt(_opAdd(_opAbs(_opMinus(a.X, b.X)), _opAbs(_opMinus(a.Y, b.Y))));
	}

	public static double Distance(Coordinate2D<T> a, Coordinate2D<T> b)
	{
		Coordinate2D<T> distanceCoordinate = a - b;
		double num = _opToReal(distanceCoordinate.X);
		double y = _opToReal(distanceCoordinate.Y);
		return Math.Sqrt(num * num + y * y);
	}
}
