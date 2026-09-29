using System;
using System.Collections.Generic;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Combat.Chicken;

public class ChickenPointZones
{
	public readonly List<ChickenPointRuntime> Pending = new List<ChickenPointRuntime>();

	public readonly List<ChickenPointRuntime> Current = new List<ChickenPointRuntime>();

	public readonly List<ChickenPointRuntime> Discard = new List<ChickenPointRuntime>();

	public int MaxDrawableCount => Pending.Count + Discard.Count;

	public bool AnyDrawable => MaxDrawableCount > 0;

	public bool NoDrawable => !AnyDrawable;

	public bool CurrentOverflow => Current.Count > 7;

	public bool CurrentNoOverflow => !CurrentOverflow;

	public bool CurrentFull => Current.Count >= 7;

	public bool CurrentNotFull => !CurrentFull;

	public void Clear()
	{
		Pending.Clear();
		Current.Clear();
		Discard.Clear();
	}

	public bool CurrentContains(int id)
	{
		foreach (ChickenPointRuntime item in Current)
		{
			if (item.Id == id)
			{
				return true;
			}
		}
		return false;
	}

	public bool Draw(IRandomSource random, int maxCount = 1)
	{
		int newPointCount = System.Math.Min(MaxDrawableCount, maxCount);
		for (int i = 0; i < newPointCount; i++)
		{
			List<ChickenPointRuntime> pending = Pending;
			if (pending == null || pending.Count <= 0)
			{
				Recycle();
			}
			int index = random.Next(Pending.Count);
			ChickenPointRuntime point = Pending[index];
			CollectionUtils.SwapAndRemove(Pending, index);
			Current.Add(point);
		}
		return newPointCount > 0;
	}

	public void RecyclePoint(ChickenPointRuntime point)
	{
		if (point.Stable)
		{
			Discard.Add(point.ClearOverride());
		}
	}

	private void Recycle()
	{
		Pending.AddRange(Discard);
		Discard.Clear();
	}

	public bool RemoveOverflow()
	{
		int removeCount = Current.Count - 7;
		if (removeCount <= 0)
		{
			return false;
		}
		for (int i = 0; i < removeCount; i++)
		{
			RecyclePoint(Current[i]);
		}
		for (int j = 0; j < Current.Count - removeCount; j++)
		{
			Current[j] = Current[j + removeCount];
		}
		for (int i2 = removeCount; i2 > 0; i2--)
		{
			Current.RemoveAt(Current.Count - 1);
		}
		return true;
	}

	public ChickenPointRuntime? RemoveOverflowInPriority(sbyte finallyType)
	{
		if (CurrentNoOverflow)
		{
			return null;
		}
		int index = PickOverflowIndexInPriority(finallyType);
		ChickenPointRuntime result = Current[index];
		RecyclePoint(result);
		Current.RemoveAt(index);
		return result;
	}

	private int PickOverflowIndexInPriority(sbyte finallyType)
	{
		int? firstOtherIndex = null;
		for (int i = 0; i < Current.Count; i++)
		{
			ChickenPointRuntime point = Current[i];
			if (point.Type == sbyte.MaxValue)
			{
				return i;
			}
			if (!firstOtherIndex.HasValue && point.Type != finallyType)
			{
				firstOtherIndex = i;
			}
		}
		return firstOtherIndex.GetValueOrDefault();
	}

	public void AddToCurrent(ChickenPointRuntime point)
	{
		Current.Add(point);
	}

	public bool TakeFromCurrent(IReadOnlyList<int> ids, List<ChickenPointRuntime> taken)
	{
		foreach (int id in ids)
		{
			if (!CurrentContains(id))
			{
				return false;
			}
		}
		foreach (int id2 in ids)
		{
			for (int i = 0; i < Current.Count; i++)
			{
				if (Current[i].Id == id2)
				{
					taken.Add(Current[i]);
					Current.RemoveAt(i);
					break;
				}
			}
		}
		return true;
	}
}
