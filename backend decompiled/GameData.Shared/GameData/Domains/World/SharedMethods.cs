using System;
using Config;

namespace GameData.Domains.World;

public static class SharedMethods
{
	public static sbyte CalcMonthInYear(int date)
	{
		return (sbyte)(date % 12);
	}

	public static sbyte GetXiangshuLevel(sbyte xiangshuProgress)
	{
		return (sbyte)(xiangshuProgress / 2);
	}

	public static sbyte GetMaxGradeOfXiangshuInfection(sbyte xiangshuProgress)
	{
		sbyte xiangshuLevel = GetXiangshuLevel(xiangshuProgress);
		if (xiangshuLevel == 0)
		{
			return -1;
		}
		return Math.Min(xiangshuLevel, 8);
	}

	public static bool SmallVillageXiangshu(short orgTemplateId, bool includeXiangshuInfected = true)
	{
		if (SmallVillageXiangshuProgress())
		{
			if (orgTemplateId != 19)
			{
				return orgTemplateId == 20 && includeXiangshuInfected;
			}
			return true;
		}
		return false;
	}

	public static bool SmallVillageXiangshuProgress()
	{
		return ExternalDataBridge.Context.TaiwuLocation.AreaId == 137;
	}

	public static short GetGainResourcePercent(byte worldResourceType)
	{
		byte resourceAmountType = GetWorldResourceAmountType();
		return WorldResource.Instance[worldResourceType].InfluenceFactors[resourceAmountType];
	}

	public static byte GetWorldResourceAmountType()
	{
		return ExternalDataBridge.Context.WorldResourceAmountType;
	}

	public static double GetApproveTaiwuDisplayData(short approvingRate)
	{
		return Math.Round((float)approvingRate / 10f, 1);
	}

	public static string GetApproveTaiwuDisplayDataString(short approvingRate)
	{
		return Math.Round((float)approvingRate / 10f, 1) + "%";
	}

	public static sbyte GetInvasionWorldStateTemplateId()
	{
		return GetXiangshuLevel(ExternalDataBridge.Context.XiangshuProgress) switch
		{
			0 => 0, 
			1 => 1, 
			2 => 2, 
			3 => 3, 
			4 => 4, 
			5 => 5, 
			6 => 6, 
			7 => 7, 
			8 => 8, 
			_ => 9, 
		};
	}

	public static short GetHeavenlyTreeTemplateIdByGrowValue(ushort growPoint)
	{
		if (growPoint < 100)
		{
			return 598;
		}
		if (growPoint < 300)
		{
			return 599;
		}
		if (growPoint < 600)
		{
			return 600;
		}
		if (growPoint < 900)
		{
			return 601;
		}
		return 602;
	}

	public static int GetHeavenlyTreeGrewUpValueByResource(sbyte stateTaskStatus, int resourceCount)
	{
		if (stateTaskStatus == 0)
		{
			return resourceCount / 100;
		}
		return resourceCount * 3 / 100;
	}

	public static int GetHeavenlyTreeGrewUpValueByBook(sbyte stateTaskStatus)
	{
		if (stateTaskStatus == 0)
		{
			return 100;
		}
		return 300;
	}
}
