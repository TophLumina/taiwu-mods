using System;
using System.Runtime.CompilerServices;
using Config;

namespace GameData.Domains.Character;

public static class ResourceTypeHelper
{
	public static int GetTotalWorth(this ResourceInts resources)
	{
		int totalWorth = 0;
		for (sbyte resourceType = 0; resourceType < 8; resourceType++)
		{
			totalWorth += ResourceAmountToWorth(resourceType, resources[resourceType]);
		}
		return totalWorth;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Obsolete("Use ResourceAmountToLongWorth instead.")]
	public static int ResourceAmountToWorth(sbyte resourceType, int amount)
	{
		return GlobalConfig.ResourcesWorth[resourceType] * amount;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long ResourceAmountToLongWorth(sbyte resourceType, long amount)
	{
		return GlobalConfig.ResourcesWorth[resourceType] * amount;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int WorthToResourceAmount(sbyte resourceType, int worth)
	{
		return (int)LongWorthToResourceAmount(resourceType, worth);
	}

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

	public static sbyte ResourceAmountToGrade(sbyte resourceType, int amount)
	{
		return ResourceWorthToGrade(ResourceAmountToWorth(resourceType, amount));
	}

	public static int GradeToResourceAmount(sbyte resourceType, sbyte grade)
	{
		int worth = Accessory.Instance[grade].BaseValue;
		return WorthToResourceAmount(resourceType, worth);
	}

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
