using System.Collections.Generic;

namespace GameData.Utilities;

public class ReverseComparerUshort : IComparer<ushort>
{
	public int Compare(ushort x, ushort y)
	{
		return y - x;
	}
}
