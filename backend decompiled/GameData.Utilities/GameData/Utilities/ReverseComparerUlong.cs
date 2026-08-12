using System.Collections.Generic;

namespace GameData.Utilities;

public class ReverseComparerUlong : IComparer<ulong>
{
	public int Compare(ulong x, ulong y)
	{
		if (y < x)
		{
			return -1;
		}
		return (y > x) ? 1 : 0;
	}
}
