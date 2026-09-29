using System;

namespace GameData.Domains.Organization;

public static class TreasuryOrPrisonHelper
{
	public static TreasuryOrPrisonVisitStatusType VisitStatus(this TreasuryOrPrisonPage page)
	{
		return page switch
		{
			TreasuryOrPrisonPage.Mid => TreasuryOrPrisonVisitStatusType.MidVisited, 
			TreasuryOrPrisonPage.High => TreasuryOrPrisonVisitStatusType.HighVisited, 
			_ => TreasuryOrPrisonVisitStatusType.None, 
		};
	}

	public static sbyte GuardLevel(this TreasuryOrPrisonPage page)
	{
		return Math.Clamp((sbyte)page, 0, 2);
	}

	public static bool CanPassUnConditionally(this TreasuryOrPrisonPage page)
	{
		if (page == TreasuryOrPrisonPage.Low || page == TreasuryOrPrisonPage.Infected)
		{
			return true;
		}
		return false;
	}

	public static bool HasVisitStatus(this TreasuryOrPrisonPage page)
	{
		if ((uint)(page - 1) <= 1u)
		{
			return true;
		}
		return false;
	}
}
