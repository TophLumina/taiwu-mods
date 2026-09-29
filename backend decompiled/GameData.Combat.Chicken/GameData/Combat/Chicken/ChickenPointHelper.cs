using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Combat.Chicken;

public static class ChickenPointHelper
{
	public const sbyte TypeOther = sbyte.MaxValue;

	public const int MaxCurrentPoint = 7;

	public const int SecondBySixTotalPoint = 100;

	private static readonly Dictionary<int, int> GroupCache = new Dictionary<int, int>();

	private static readonly List<ChickenPointRuntime> PointsCache = new List<ChickenPointRuntime>();

	private static readonly List<sbyte> PointTypesCache = new List<sbyte>();

	public static EChickenTypeGroup CalcTypeGroup(this IEnumerable<ChickenPointRuntime> points)
	{
		GroupCache.Clear();
		foreach (ChickenPointRuntime point in points)
		{
			if (point.Type != sbyte.MaxValue)
			{
				GroupCache.Accumulate(point.Type);
			}
		}
		return GroupCache.Count switch
		{
			1 => GroupCache.Values.All((int x) => x >= 3) ? EChickenTypeGroup.One : EChickenTypeGroup.None, 
			2 => GroupCache.Values.All((int x) => x == 2) ? EChickenTypeGroup.Two : EChickenTypeGroup.None, 
			3 => GroupCache.Values.All((int x) => x == 1) ? EChickenTypeGroup.Three : EChickenTypeGroup.None, 
			4 => GroupCache.Values.All((int x) => x == 1) ? EChickenTypeGroup.Four : EChickenTypeGroup.None, 
			5 => GroupCache.Values.All((int x) => x == 1) ? EChickenTypeGroup.Five : EChickenTypeGroup.None, 
			6 => GroupCache.Values.All((int x) => x == 1) ? EChickenTypeGroup.Six : EChickenTypeGroup.None, 
			7 => GroupCache.Values.All((int x) => x == 1) ? EChickenTypeGroup.Seven : EChickenTypeGroup.None, 
			_ => EChickenTypeGroup.None, 
		};
	}

	public static EChickenValueGroup CalcValueGroup(this IEnumerable<ChickenPointRuntime> points)
	{
		GroupCache.Clear();
		foreach (ChickenPointRuntime point in points)
		{
			GroupCache.Accumulate(point.Value);
		}
		int minValue = int.MaxValue;
		int maxValue = int.MinValue;
		foreach (var (value, num3) in GroupCache)
		{
			if (num3 >= 4)
			{
				return value switch
				{
					1 => EChickenValueGroup.OneChangeToNine, 
					9 => EChickenValueGroup.AllChangeToNine, 
					_ => EChickenValueGroup.ValueMultiplyOnePointFive, 
				};
			}
			minValue = System.Math.Min(minValue, value);
			maxValue = System.Math.Max(maxValue, value);
		}
		if (GroupCache.Count < 5 || GroupCache.Count != maxValue - minValue + 1)
		{
			return EChickenValueGroup.None;
		}
		return EChickenValueGroup.ValueMultiplyTwo;
	}

	public static ChickenPointInvokeResult InvokePoints(IRandomSource random, IReadOnlyList<int> selected, ChickenPointZones zones, ChickenPointHandler handler)
	{
		if (random == null || selected == null || selected.Count <= 0 || zones == null || handler == null)
		{
			return false;
		}
		PointsCache.Clear();
		if (!zones.TakeFromCurrent(selected, PointsCache))
		{
			return false;
		}
		EChickenTypeGroup typeGroup = PointsCache.CalcTypeGroup();
		InvokeFirstByCache(handler, out var valueGroup);
		InvokeTypeGroupEffect(random, zones, handler, typeGroup);
		zones.RemoveOverflow();
		foreach (ChickenPointRuntime point in PointsCache)
		{
			zones.RecyclePoint(point);
		}
		PointsCache.Clear();
		return new ChickenPointInvokeResult(Success: true, typeGroup, valueGroup);
	}

	private static void InvokeFirstByCache(ChickenPointHandler handler, out EChickenValueGroup valueGroup)
	{
		valueGroup = PointsCache.CalcValueGroup();
		PointTypesCache.Clear();
		foreach (ChickenPointRuntime point in PointsCache)
		{
			PointTypesCache.AddUnique(point.Type);
		}
		foreach (sbyte type in PointTypesCache)
		{
			int totalPoint = SumTotalPoint(PointsCache, type, valueGroup);
			handler(type, totalPoint);
		}
	}

	private static void InvokeSecondBySix(ChickenPointHandler handler, IList<ChickenPointRuntime> current)
	{
		foreach (ChickenPointRuntime item in current)
		{
			handler(item.Type, 100);
		}
		PointsCache.AddRange(current);
		current.Clear();
	}

	private static void InvokeTypeGroupEffect(IRandomSource random, ChickenPointZones zones, ChickenPointHandler handler, EChickenTypeGroup typeGroup)
	{
		List<ChickenPointRuntime> current = zones.Current;
		if (typeGroup == EChickenTypeGroup.One && zones.AnyDrawable)
		{
			sbyte oneType = PointsCache[0].Type;
			if (zones.Draw(random))
			{
				current[current.Count - 1] = current[current.Count - 1].DoOverrideType(oneType);
			}
			return;
		}
		if (typeGroup == EChickenTypeGroup.Two && current.Count > 0)
		{
			sbyte remainType = current.GetRandom(random).Type;
			for (int i = 0; i < current.Count; i++)
			{
				current[i] = current[i].DoOverrideType(remainType);
			}
			return;
		}
		switch (typeGroup)
		{
		case EChickenTypeGroup.Three:
			DoOverrideValue(current, 1);
			return;
		case EChickenTypeGroup.Four:
			DoOverrideValue(current, 9);
			return;
		case EChickenTypeGroup.Five:
			PointsCache.AddRange(current);
			current.Clear();
			zones.Draw(random, 3);
			return;
		case EChickenTypeGroup.Six:
			if (current.Count > 0)
			{
				InvokeSecondBySix(handler, current);
				return;
			}
			break;
		}
		if (typeGroup == EChickenTypeGroup.Seven)
		{
			zones.Draw(random, 7);
		}
	}

	private static void DoOverrideValue(IList<ChickenPointRuntime> current, int value)
	{
		for (int i = 0; i < current.Count; i++)
		{
			current[i] = current[i].DoOverrideValue(value);
		}
	}

	public static int SumTotalPoint(IReadOnlyList<ChickenPointRuntime> points, sbyte type, EChickenValueGroup valueGroup)
	{
		int totalPoint = 0;
		foreach (ChickenPointRuntime point in points)
		{
			if (point.Type == type)
			{
				totalPoint = ((valueGroup != EChickenValueGroup.AllChangeToNine && (valueGroup != EChickenValueGroup.OneChangeToNine || point.Value != 1)) ? (totalPoint + point.Value) : (totalPoint + 9));
			}
		}
		int num = totalPoint;
		return num * valueGroup switch
		{
			EChickenValueGroup.ValueMultiplyOnePointFive => 150, 
			EChickenValueGroup.ValueMultiplyTwo => 200, 
			_ => 100, 
		};
	}
}
