using System.Collections.Generic;

namespace GameData.Utilities;

public class ReverseComparerByte : IComparer<byte>
{
	public int Compare(byte x, byte y)
	{
		return y - x;
	}
}
