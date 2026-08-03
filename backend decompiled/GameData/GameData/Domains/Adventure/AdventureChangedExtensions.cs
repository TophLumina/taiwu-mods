namespace GameData.Domains.Adventure;

public static class AdventureChangedExtensions
{
	public static bool Contains(this EAdventureChanged value, EAdventureChanged flags)
	{
		return (value & flags) == flags;
	}
}
