using Config;

namespace GameData.Domains.Character.SortFilter;

public static class CharacterFilterSubType
{
	public const sbyte MapState = 0;

	public const sbyte RelationDisplayType = 1;

	public const sbyte VillagerRole = 2;

	public const sbyte MapStateWithoutTeammates = 3;

	public static readonly int[] SubTypeToFilterCount;

	static CharacterFilterSubType()
	{
		int[] obj = new int[4] { 16, 10, 0, 15 };
		obj[2] = Config.VillagerRole.Instance.Count + 1;
		SubTypeToFilterCount = obj;
	}
}
