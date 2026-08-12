using System;
using System.Runtime.CompilerServices;
using Config;

namespace GameData.Domains.Character;

/// <summary>
/// 资源相关辅助方法
/// </summary>
public static class ResourceTypeHelper
{
	/// <summary>
	/// 获取总价值
	/// </summary>
	/// <returns></returns>
	public static int GetTotalWorth(this ResourceInts resources)
	{
		int totalWorth = 0;
		for (sbyte resourceType = 0; resourceType < 8; resourceType++)
		{
			totalWorth += ResourceAmountToWorth(resourceType, resources[resourceType]);
		}
		return totalWorth;
	}

	/// <summary>
	/// 将资源转换成价值
	/// </summary>
	/// <param name="resourceType">资源类型</param>
	/// <param name="amount">资源量</param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Obsolete("Use ResourceAmountToLongWorth instead.")]
	public static int ResourceAmountToWorth(sbyte resourceType, int amount)
	{
		return GlobalConfig.ResourcesWorth[resourceType] * amount;
	}

	/// <summary>
	/// 将资源转换成价值
	/// </summary>
	/// <param name="resourceType">资源类型</param>
	/// <param name="amount">资源量</param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long ResourceAmountToLongWorth(sbyte resourceType, long amount)
	{
		return GlobalConfig.ResourcesWorth[resourceType] * amount;
	}

	/// <summary>
	/// 将价值转换成资源量
	/// </summary>
	/// <param name="resourceType">资源类型</param>
	/// <param name="worth">价值</param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int WorthToResourceAmount(sbyte resourceType, int worth)
	{
		return (int)LongWorthToResourceAmount(resourceType, worth);
	}

	/// <summary>
	/// 将价值转换成资源量
	/// </summary>
	/// <param name="resourceType">资源类型</param>
	/// <param name="worth">价值</param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long LongWorthToResourceAmount(sbyte resourceType, long worth)
	{
		sbyte unit = GlobalConfig.ResourcesWorth[resourceType];
		long remainder;
		long result = Math.DivRem(worth, unit, out remainder);
		if (remainder <= 0)
		{
			return result;
		}
		return result + 1;
	}

	/// <summary>
	/// 将资源量转为道具品级
	/// </summary>
	/// <param name="resourceType">资源类型</param>
	/// <param name="amount">资源量</param>
	/// <returns>道具品级 <see cref="T:GameData.Domains.Character.Grade" />, -1 表示数量不足以对应任何有效品级</returns>
	public static sbyte ResourceAmountToGrade(sbyte resourceType, int amount)
	{
		return ResourceWorthToGrade(ResourceAmountToWorth(resourceType, amount));
	}

	/// <summary>
	/// 将道具品级转为资源量
	/// </summary>
	/// <param name="resourceType">资源类型</param>
	/// <param name="grade">道具品级 <see cref="T:GameData.Domains.Character.Grade" /></param>
	/// <returns>资源量</returns>
	public static int GradeToResourceAmount(sbyte resourceType, sbyte grade)
	{
		int worth = Accessory.Instance[grade].BaseValue;
		return WorthToResourceAmount(resourceType, worth);
	}

	/// <summary>
	/// 将资源价值转为道具品级
	/// </summary>
	/// <param name="worth">资源价值</param>
	/// <returns>道具品级 <see cref="T:GameData.Domains.Character.Grade" />, -1 表示数量不足以对应任何有效品级</returns>
	public static sbyte ResourceWorthToGrade(int worth)
	{
		for (sbyte grade = 8; grade >= 0; grade--)
		{
			AccessoryItem equivalentItem = Accessory.Instance[grade];
			if (worth >= equivalentItem.BaseValue)
			{
				return grade;
			}
		}
		return -1;
	}
}
