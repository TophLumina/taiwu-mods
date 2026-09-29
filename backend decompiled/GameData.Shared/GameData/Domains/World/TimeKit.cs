using System.Collections.Generic;
using Config;

namespace GameData.Domains.World;

public static class TimeKit
{
	public static int GetYear(int date)
	{
		return date / 12;
	}

	public static sbyte GetMonth(int date)
	{
		return (sbyte)(date % 12);
	}

	public static sbyte GetSeason(int date)
	{
		sbyte month = GetMonth(date);
		foreach (SeasonItem season in (IEnumerable<SeasonItem>)Season.Instance)
		{
			if (season.Months.Contains(month))
			{
				return season.TemplateId;
			}
		}
		return -1;
	}

	public static sbyte GetCurrSeason()
	{
		return GetSeason(ExternalDataBridge.Context.CurrDate);
	}
}
