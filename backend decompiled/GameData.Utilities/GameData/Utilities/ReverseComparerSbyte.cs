using System.Collections.Generic;

namespace GameData.Utilities;

public class ReverseComparerSbyte : IComparer<sbyte>
{
	public int Compare(sbyte x, sbyte y)
	{
		return y - x;
	}
}
