using System;

namespace GameData.Combat.Chicken;

public readonly record struct ChickenPoint : IComparable<ChickenPoint>
{
	public readonly sbyte Type;

	public readonly int Value;

	public ChickenPoint(sbyte type, int value)
	{
		Type = type;
		Value = value;
	}

	public int CompareTo(ChickenPoint other)
	{
		int typeComparison = Type.CompareTo(other.Type);
		if (typeComparison != 0)
		{
			return typeComparison;
		}
		return Value.CompareTo(other.Value);
	}
}
