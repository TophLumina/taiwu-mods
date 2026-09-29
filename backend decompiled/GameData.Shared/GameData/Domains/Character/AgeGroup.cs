namespace GameData.Domains.Character;

public static class AgeGroup
{
	public const sbyte Baby = 0;

	public const sbyte Child = 1;

	public const sbyte Adult = 2;

	public static sbyte GetAgeGroup(short age)
	{
		if (age >= 16)
		{
			return 2;
		}
		if (age >= GlobalConfig.Instance.AgeBaby)
		{
			return 1;
		}
		if (age >= 0)
		{
			return 0;
		}
		return 2;
	}
}
