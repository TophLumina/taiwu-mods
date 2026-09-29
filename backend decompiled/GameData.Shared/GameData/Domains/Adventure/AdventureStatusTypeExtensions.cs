namespace GameData.Domains.Adventure;

public static class AdventureStatusTypeExtensions
{
	public static bool IsActive(this EAdventureStatusType type)
	{
		if (type - 1 <= EAdventureStatusType.Ready)
		{
			return true;
		}
		return false;
	}

	public static bool IsAsleep(this EAdventureStatusType type)
	{
		if (type == EAdventureStatusType.Preparing || type == EAdventureStatusType.Hide)
		{
			return true;
		}
		return false;
	}
}
