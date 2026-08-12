namespace GameData.Combat.Math;

public static class CValueHalf
{
	public static CValueFraction RoundUp => new CValueFraction(1, 2, roundUp: true);

	public static CValueFraction RoundDown => new CValueFraction(1, 2);
}
