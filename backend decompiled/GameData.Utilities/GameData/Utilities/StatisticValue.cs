using System.Collections.Generic;
using System.Linq;

namespace GameData.Utilities;

public class StatisticValue
{
	private readonly List<int> _values = new List<int>();

	public double Total { get; private set; }

	public int Count => _values.Count;

	public double Median => GetMedian(_values, 0);

	public double Mode => GetMode(_values, 0);

	public double Average => Total / (double)Count;

	public void Record(int value)
	{
		_values.Add(value);
		Total += value;
	}

	public static int GetAverage(IReadOnlyList<int> numbers, int defaultValue)
	{
		if (numbers.Count == 0)
		{
			return defaultValue;
		}
		int total = 0;
		foreach (int number in numbers)
		{
			total += number;
		}
		return total / numbers.Count;
	}

	public static int GetMedian(IReadOnlyList<int> numbers, int defaultValue)
	{
		if (numbers.Count == 0)
		{
			return defaultValue;
		}
		List<int> sorted = new List<int>(numbers);
		sorted.Sort();
		int count = sorted.Count;
		if (count % 2 != 0)
		{
			return sorted[count / 2];
		}
		return (sorted[count / 2 - 1] + sorted[count / 2]) / 2;
	}

	public static int GetMode(IReadOnlyList<int> numbers, int defaultValue)
	{
		if (numbers.Count == 0)
		{
			return defaultValue;
		}
		IEnumerable<IGrouping<int, int>> enumerable = from n in numbers
			group n by n;
		int maxCount = -1;
		int maxNumber = defaultValue;
		foreach (IGrouping<int, int> group in enumerable)
		{
			int count = group.Count();
			if (count > maxCount)
			{
				maxNumber = group.Key;
				maxCount = count;
			}
		}
		return maxNumber;
	}
}
