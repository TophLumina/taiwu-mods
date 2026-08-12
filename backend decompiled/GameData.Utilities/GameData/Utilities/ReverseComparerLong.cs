using System.Collections.Generic;

namespace GameData.Utilities;

public class ReverseComparerLong : IComparer<long>
{
	public int Compare(long x, long y)
	{
		if (y < x)
		{
			return -1;
		}
		return (y > x) ? 1 : 0;
	}
}
