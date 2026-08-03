using System.Collections.Generic;
using Config;

namespace GameData.Domains.World;

/// <summary>
/// 时间相关计算工具集
/// </summary>
public static class TimeKit
{
	/// <summary>
	/// 通过日期计算年份
	/// </summary>
	/// <param name="date"></param>
	/// <returns></returns>
	public static int GetYear(int date)
	{
		return date / 12;
	}

	/// <summary>
	/// 通过日期计算月份
	/// </summary>
	/// <param name="date"></param>
	/// <returns></returns>
	public static sbyte GetMonth(int date)
	{
		return (sbyte)(date % 12);
	}

	/// <summary>
	/// 通过日期计算季节
	/// </summary>
	/// <param name="date"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取当前季节
	/// </summary>
	/// <returns></returns>
	public static sbyte GetCurrSeason()
	{
		return GetSeason(ExternalDataBridge.Context.CurrDate);
	}
}
