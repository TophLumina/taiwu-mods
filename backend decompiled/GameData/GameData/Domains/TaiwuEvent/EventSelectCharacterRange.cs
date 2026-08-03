namespace GameData.Domains.TaiwuEvent;

public static class EventSelectCharacterRange
{
	public const sbyte Group = 0;

	public const sbyte GroupWithSpecial = 1;

	public const sbyte Block = 2;

	public const sbyte GroupAndBlock = 3;

	public const sbyte GroupWithSpecialAndBlock = 4;

	public static bool SelectInGroup(sbyte selectRange)
	{
		if ((uint)selectRange <= 1u || (uint)(selectRange - 3) <= 1u)
		{
			return true;
		}
		return false;
	}

	public static bool SelectInInBlock(sbyte selectRange)
	{
		if ((uint)(selectRange - 2) <= 2u)
		{
			return true;
		}
		return false;
	}

	public static bool SelectInSpecialGroup(sbyte selectRange)
	{
		if (selectRange == 1 || selectRange == 4)
		{
			return true;
		}
		return false;
	}
}
