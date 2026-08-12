using System.Collections.Generic;

namespace GameData.Utilities;

public class ReverseComparerInt : IComparer<int>
{
	public int Compare(int x, int y)
	{
		if (y < x)
		{
			return -1;
		}
		return (y > x) ? 1 : 0;
	}
}
