namespace GameData.Domains.Taiwu.Profession;

public static class ProfessionSkillInvalidType
{
	public const int InvalidLocation = 1;

	public const int NotEnoughCharacter = 2;

	public const int NotEnoughSkillBook = 4;

	public const int NotEnoughPrisoner = 8;

	public const int NotEnoughEatingSlot = 16;

	public static int Add(int res, int target)
	{
		return res | target;
	}

	public static bool Contains(int set, int target)
	{
		return (set & target) != 0;
	}
}
