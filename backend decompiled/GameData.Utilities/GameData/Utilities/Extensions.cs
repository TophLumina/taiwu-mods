using System;
using System.Collections.Generic;
using System.Diagnostics;
using Redzen.Random;

namespace GameData.Utilities;

public static class Extensions
{
	public static T GetRandom<T>(this IList<T> list, IRandomSource random)
	{
		if (list == null || list.Count <= 0)
		{
			return default(T);
		}
		return list[random.Next(0, list.Count)];
	}

	public static T GetRandomReadOnly<T>(this IReadOnlyList<T> list, IRandomSource random)
	{
		if (list == null || list.Count <= 0)
		{
			throw new ArgumentException("list is empty", "list");
		}
		return list[random.Next(0, list.Count)];
	}

	public static T GetRandomOrDefault<T>(this IList<T> list, IRandomSource random, T defaultValue)
	{
		if (list == null || list.Count <= 0)
		{
			return defaultValue;
		}
		return list[random.Next(0, list.Count)];
	}

	public static T Min<T>(this IReadOnlyList<T> list) where T : IComparable<T>
	{
		if (list.Count > 0)
		{
			T min = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				if (list[i].CompareTo(min) < 0)
				{
					min = list[i];
				}
			}
			return min;
		}
		return default(T);
	}

	public static T Max<T>(this IReadOnlyList<T> list) where T : IComparable<T>
	{
		if (list.Count > 0)
		{
			T max = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				if (list[i].CompareTo(max) > 0)
				{
					max = list[i];
				}
			}
			return max;
		}
		return default(T);
	}

	public static T Max<T>(this IList<T> list, Comparison<T> comparison)
	{
		if (list.Count == 0)
		{
			return default(T);
		}
		T max = list[0];
		for (int i = 1; i < list.Count; i++)
		{
			if (comparison(list[i], max) > 0)
			{
				max = list[i];
			}
		}
		return max;
	}

	public static bool CheckIndex<T>(this IList<T> list, int index)
	{
		if (list == null)
		{
			return false;
		}
		if (index >= 0)
		{
			return index < list.Count;
		}
		return false;
	}

	public static int Count(this IList<byte> list, byte element)
	{
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] == element)
			{
				count++;
			}
		}
		return count;
	}

	public static void Assign<T>(this List<T> self, List<T> other)
	{
		int otherCount = other.Count;
		if (self.Count != otherCount)
		{
			self.Clear();
			self.AddRange(other);
			return;
		}
		for (int i = 0; i < otherCount; i++)
		{
			self[i] = other[i];
		}
	}

	public static bool SequenceEqual<T>(this IReadOnlyList<T> self, IReadOnlyList<T> other) where T : IEquatable<T>
	{
		if (self.Count != other.Count)
		{
			return false;
		}
		for (int i = 0; i < self.Count; i++)
		{
			if (!self[i].Equals(other[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static bool SequenceEqualWithNullParam<T>(this IReadOnlyList<T> self, IReadOnlyList<T> other) where T : IEquatable<T>
	{
		bool selfIsNull = self == null;
		bool otherIsNull = other == null;
		if (selfIsNull != otherIsNull)
		{
			return false;
		}
		if (!selfIsNull)
		{
			return self.SequenceEqual(other);
		}
		return true;
	}

	public static int Sum(this IList<int> list)
	{
		int sum = 0;
		for (int i = 0; i < list.Count; i++)
		{
			sum += list[i];
		}
		return sum;
	}

	public static bool Contains<T>(this SpanList<T> spanList, T element) where T : unmanaged, IEquatable<T>
	{
		for (int index = 0; index < spanList.Count; index++)
		{
			T item = spanList[index];
			if (item.Equals(element))
			{
				return true;
			}
		}
		return false;
	}

	public static bool Remove<T>(this ref SpanList<T> spanList, T element) where T : unmanaged, IEquatable<T>
	{
		for (int index = 0; index < spanList.Count; index++)
		{
			T item = spanList[index];
			if (item.Equals(element))
			{
				spanList.RemoveAt(index);
				return true;
			}
		}
		return false;
	}

	public static T Min<T>(this Span<T> span) where T : IComparable<T>
	{
		if (span.Length > 0)
		{
			T min = span[0];
			for (int i = 1; i < span.Length; i++)
			{
				if (span[i].CompareTo(min) < 0)
				{
					min = span[i];
				}
			}
			return min;
		}
		return default(T);
	}

	public static T Max<T>(this T[] span) where T : IComparable<T>
	{
		if (span.Length != 0)
		{
			T max = span[0];
			for (int i = 1; i < span.Length; i++)
			{
				if (span[i].CompareTo(max) > 0)
				{
					max = span[i];
				}
			}
			return max;
		}
		return default(T);
	}

	public static long TimedInvoke(this Action action)
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		action();
		stopwatch.Stop();
		return stopwatch.ElapsedMilliseconds;
	}

	public static bool TryPop<T>(this IList<T> list, out T value)
	{
		int count = list.Count;
		if (count == 0)
		{
			value = default(T);
			return false;
		}
		int lastIndex = count - 1;
		value = list[lastIndex];
		list.RemoveAt(lastIndex);
		return true;
	}

	public static T Pop<T>(this IList<T> list)
	{
		int lastIndex = list.Count - 1;
		T result = list[lastIndex];
		list.RemoveAt(lastIndex);
		return result;
	}
}
