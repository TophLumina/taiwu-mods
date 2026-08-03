using System.Collections.Generic;

namespace GameData.Utilities;

public class ReverseComparerShort : IComparer<short>
{
	public int Compare(short x, short y)
	{
		return y - x;
	}
}
