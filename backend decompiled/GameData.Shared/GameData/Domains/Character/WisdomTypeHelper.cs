namespace GameData.Domains.Character;

public static class WisdomTypeHelper
{
	public static EWisdomType FromWisdomCount(int wisdomCount)
	{
		if (wisdomCount == 0)
		{
			return EWisdomType.None;
		}
		if (wisdomCount >= 0)
		{
			return EWisdomType.Positive;
		}
		return EWisdomType.Negative;
	}
}
