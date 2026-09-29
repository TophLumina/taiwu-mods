namespace GameData.Domains.Extra;

public class SectStoryThreeCorpsesCharacterNotch
{
	public const sbyte Low = 0;

	public const sbyte Mid = 1;

	public const sbyte High = 2;

	public static bool IsValid(sbyte notch)
	{
		if (notch >= 0)
		{
			return notch <= 2;
		}
		return false;
	}
}
