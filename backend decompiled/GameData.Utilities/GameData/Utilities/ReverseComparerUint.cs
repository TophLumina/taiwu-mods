using System.Collections.Generic;

namespace GameData.Utilities;

public class ReverseComparerUint : IComparer<uint>
{
	public int Compare(uint x, uint y)
	{
		if (y < x)
		{
			return -1;
		}
		return (y > x) ? 1 : 0;
	}
}
