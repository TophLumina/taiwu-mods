namespace GameData.Domains.Character;

public static class XiangshuInfectionType
{
	public const sbyte Invalid = -1;

	public const sbyte NotInfected = 0;

	public const sbyte PartlyInfected = 1;

	public const sbyte CompletelyInfected = 2;

	public const byte MinValue = 0;

	public const byte MaxValue = 200;

	public const byte PartlyInfectedThresholdValue = 100;

	public const byte CompletelyInfectedThresholdValue = 200;

	public static sbyte GetInfectionTypeThatShouldBe(byte xiangshuInfection)
	{
		if (xiangshuInfection < 100)
		{
			return 0;
		}
		if (xiangshuInfection < 200)
		{
			return 1;
		}
		return 2;
	}
}
