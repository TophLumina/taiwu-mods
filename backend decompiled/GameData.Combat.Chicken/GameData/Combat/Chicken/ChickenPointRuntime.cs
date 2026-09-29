using System.Runtime.CompilerServices;
using System.Text;

namespace GameData.Combat.Chicken;

public readonly record struct ChickenPointRuntime
{
	public sbyte Type => OverrideType ?? Point.Type;

	public int Value => OverrideValue ?? Point.Value;

	public ChickenPoint FinalPoint => new ChickenPoint(Type, Value);

	public readonly int Id;

	public readonly ChickenPoint Point;

	public readonly sbyte? OverrideType;

	public readonly int? OverrideValue;

	public readonly bool Stable;

	public ChickenPointRuntime(int id, ChickenPoint point, sbyte? overrideType = null, int? overrideValue = null, bool stable = true)
	{
		Id = id;
		Point = point;
		OverrideType = overrideType;
		OverrideValue = overrideValue;
		Stable = stable;
	}

	public ChickenPointRuntime ClearOverride()
	{
		return new ChickenPointRuntime(Id, Point);
	}

	public ChickenPointRuntime DoOverrideType(sbyte overrideType)
	{
		return new ChickenPointRuntime(Id, Point, overrideType, OverrideValue);
	}

	public ChickenPointRuntime DoOverrideValue(int overrideValue)
	{
		return new ChickenPointRuntime(Id, Point, OverrideType, overrideValue);
	}

	[CompilerGenerated]
	private bool PrintMembers(StringBuilder builder)
	{
		builder.Append("Id = ");
		builder.Append(Id.ToString());
		builder.Append(", Point = ");
		builder.Append(Point.ToString());
		builder.Append(", OverrideType = ");
		builder.Append(OverrideType.ToString());
		builder.Append(", OverrideValue = ");
		builder.Append(OverrideValue.ToString());
		builder.Append(", Stable = ");
		builder.Append(Stable.ToString());
		builder.Append(", Type = ");
		builder.Append(Type.ToString());
		builder.Append(", Value = ");
		builder.Append(Value.ToString());
		builder.Append(", FinalPoint = ");
		builder.Append(FinalPoint.ToString());
		return true;
	}
}
