namespace GameData.Combat.Math;

public struct CValueMultiplier
{
	private int _multiplier;

	public static implicit operator CValueMultiplier(int multiplier)
	{
		return new CValueMultiplier
		{
			_multiplier = multiplier
		};
	}

	public static explicit operator int(CValueMultiplier multiplier)
	{
		return multiplier._multiplier;
	}

	public static CValuePercent operator *(CValuePercent percent, CValueMultiplier multiplier)
	{
		return (int)percent * multiplier._multiplier;
	}

	public static CValuePercentBonus operator *(CValuePercentBonus bonus, CValueMultiplier multiplier)
	{
		return (int)bonus * multiplier._multiplier;
	}

	public static CValueMultiplier operator +(CValueMultiplier left, CValueMultiplier right)
	{
		return new CValueMultiplier
		{
			_multiplier = left._multiplier + right._multiplier
		};
	}
}
