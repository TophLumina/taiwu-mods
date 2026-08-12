using System;
using Config;

namespace GameData.Domains.World;

/// <summary>
/// 世界数据域 - 数据模块和表现模块共用的方法
/// </summary>
public static class SharedMethods
{
	/// <summary>
	/// 根据日期计算月份
	/// </summary>
	/// <param name="date"></param>
	/// <returns></returns>
	public static sbyte CalcMonthInYear(int date)
	{
		return (sbyte)(date % 12);
	}

	/// <summary>
	/// 获取世界相枢级别.
	/// 取值范围 [0, 9].
	/// 初始为 0, 剑冢出现之后为 1, 打败了七个剑冢 Boss 之后为 8, 之后走完某些剧情增加到 9.
	/// </summary>
	/// <param name="xiangshuProgress"></param>
	/// <returns></returns>
	public static sbyte GetXiangshuLevel(sbyte xiangshuProgress)
	{
		return (sbyte)(xiangshuProgress / 2);
	}

	/// <summary>
	/// 获取可以相枢化的最高阶层.
	/// 同时也是可加入太吾队伍的最高阶层.
	/// </summary>
	/// <param name="xiangshuProgress"></param>
	/// <returns><see cref="T:GameData.Domains.Character.Grade" />. 为 -1 表示所有人都无法相枢化.</returns>
	public static sbyte GetMaxGradeOfXiangshuInfection(sbyte xiangshuProgress)
	{
		sbyte xiangshuLevel = GetXiangshuLevel(xiangshuProgress);
		if (xiangshuLevel == 0)
		{
			return -1;
		}
		return Math.Min(xiangshuLevel, 8);
	}

	/// <summary>
	/// 是否是隐秘小村中的相枢闻恶声和相枢入魔人
	/// </summary>
	/// <param name="orgTemplateId"></param>
	/// <param name="includeXiangshuInfected">是否包含相枢入魔人</param>
	/// <returns></returns>
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

	/// <summary>
	/// 世界进度是探索小村或离开小村，此时相枢闻恶声和相枢入魔人有特殊显示需求
	/// </summary>
	/// <returns></returns>
	public static bool SmallVillageXiangshuProgress()
	{
		return ExternalDataBridge.Context.TaiwuLocation.AreaId == 137;
	}

	/// <summary>
	/// 获取资源百分比
	/// </summary>
	/// <param name="worldResourceType"></param>
	/// <returns></returns>
	public static short GetGainResourcePercent(byte worldResourceType)
	{
		byte resourceAmountType = GetWorldResourceAmountType();
		return WorldResource.Instance[worldResourceType].InfluenceFactors[resourceAmountType];
	}

	/// <summary>
	/// 前后端共用的获取当前世界资源类型接口
	/// </summary>
	/// <returns></returns>
	public static byte GetWorldResourceAmountType()
	{
		return ExternalDataBridge.Context.WorldResourceAmountType;
	}

	/// <summary>
	/// 支持度的显示数据 转换
	/// </summary>
	/// <param name="approvingRate"></param>
	/// <returns></returns>
	public static double GetApproveTaiwuDisplayData(short approvingRate)
	{
		return Math.Round((float)approvingRate / 10f, 1);
	}

	/// <summary>
	/// 支持度的显示数据 转换
	/// </summary>
	/// <param name="approvingRate"></param>
	/// <returns></returns>
	public static string GetApproveTaiwuDisplayDataString(short approvingRate)
	{
		return Math.Round((float)approvingRate / 10f, 1) + "%";
	}

	/// <summary>
	///
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 根据成长值获得神木模板id
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 获得资源兑换的神木成长
	/// </summary>
	/// <param name="stateTaskStatus"></param>
	/// <param name="resourceCount"></param>
	/// <returns></returns>
	public static int GetHeavenlyTreeGrewUpValueByResource(sbyte stateTaskStatus, int resourceCount)
	{
		if (stateTaskStatus == 0)
		{
			return resourceCount / 100;
		}
		return resourceCount * 3 / 100;
	}

	/// <summary>
	/// 获得读书的神木成长
	/// </summary>
	/// <returns></returns>
	public static int GetHeavenlyTreeGrewUpValueByBook(sbyte stateTaskStatus)
	{
		if (stateTaskStatus == 0)
		{
			return 100;
		}
		return 300;
	}
}
