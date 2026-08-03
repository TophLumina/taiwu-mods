using System;

namespace GameData.Common.Binary;

public struct OriginalDataFragment(int currOffset, int size, int oriOffset) : IComparable<OriginalDataFragment>
{
	public int CurrOffset = currOffset;

	public int Size = size;

	public int OriOffset = oriOffset;

	public int CompareTo(OriginalDataFragment other)
	{
		return CurrOffset - other.CurrOffset;
	}
}
