namespace GameData.Domains.LegendaryBook;

public static class LegendaryBookSlotStateExtensions
{
	public static bool ContainsYin(this ELegendaryBookSlotState state)
	{
		if (state == ELegendaryBookSlotState.OnlyYin || state == ELegendaryBookSlotState.BothUnlocked)
		{
			return true;
		}
		return false;
	}

	public static bool ContainsYang(this ELegendaryBookSlotState state)
	{
		if ((uint)(state - 1) <= 1u)
		{
			return true;
		}
		return false;
	}
}
