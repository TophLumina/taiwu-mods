using System;

namespace GameData.Domains.Organization;

public static class TreasuryOrPrisonHelper
{
	/// <summary>
	/// 访问状态
	/// </summary>
	/// <param name="page"></param>
	/// <returns></returns>
	public static TreasuryOrPrisonVisitStatusType VisitStatus(this TreasuryOrPrisonPage page)
	{
		return page switch
		{
			TreasuryOrPrisonPage.Mid => TreasuryOrPrisonVisitStatusType.MidVisited, 
			TreasuryOrPrisonPage.High => TreasuryOrPrisonVisitStatusType.HighVisited, 
			_ => TreasuryOrPrisonVisitStatusType.None, 
		};
	}

	/// <summary>
	/// 守卫等级
	/// </summary>
	/// <param name="page"></param>
	/// <returns></returns>
	public static sbyte GuardLevel(this TreasuryOrPrisonPage page)
	{
		return Math.Clamp((sbyte)page, 0, 2);
	}

	/// <summary>
	/// 可无条件访问
	/// </summary>
	/// <param name="page"></param>
	/// <returns></returns>
	public static bool CanPassUnConditionally(this TreasuryOrPrisonPage page)
	{
		if (page == TreasuryOrPrisonPage.Low || page == TreasuryOrPrisonPage.Infected)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 存在用于记录访问条件的状态
	/// </summary>
	/// <param name="page"></param>
	/// <returns></returns>
	public static bool HasVisitStatus(this TreasuryOrPrisonPage page)
	{
		if ((uint)(page - 1) <= 1u)
		{
			return true;
		}
		return false;
	}
}
