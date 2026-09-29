using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Config;

namespace GameData.Domains.Item;

public static class CricketSpecialConstants
{
	public static readonly IReadOnlyList<Func<ItemKey, bool>> WagerItemMatchers = new List<Func<ItemKey, bool>>
	{
		delegate(ItemKey itemKey)
		{
			sbyte itemType = itemKey.ItemType;
			return (itemType == 7 || itemType == 9) ? true : false;
		},
		(ItemKey itemKey) => itemKey.ItemType == 8,
		(ItemKey itemKey) => ItemType.IsEquipmentItemType(itemKey.ItemType),
		(ItemKey itemKey) => itemKey.ItemType == 10,
		(ItemKey itemKey) => itemKey.ItemType == 6,
		(ItemKey itemKey) => itemKey.ItemType == 5,
		(ItemKey itemKey) => itemKey.ItemType == 12
	};

	public static sbyte[] BaseWagerGrade => GlobalConfig.Instance.BaseCricketWagerGrade;

	public static (sbyte min, sbyte max) CalcWagerGradeRange(sbyte charGrade, sbyte taiwuFame)
	{
		sbyte maxGrade = (sbyte)Math.Clamp(BaseWagerGrade[Math.Clamp(charGrade, 0, BaseWagerGrade.Length - 1)] + Math.Min(taiwuFame / 25, 3), 0, 8);
		return (min: (sbyte)Math.Max(maxGrade - 3, 0), max: maxGrade);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int PriceToResource(sbyte resourceType, int price)
	{
		return price / GlobalConfig.ResourcesPrice[resourceType];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ResourceToPrice(sbyte resourceType, int count)
	{
		return GlobalConfig.ResourcesPrice[resourceType] * count;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int PriceToExp(int price)
	{
		return price / 5;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ExpToPrice(int count)
	{
		return count * 5;
	}

	public static int GradeToPriceResource(sbyte resourceType, sbyte grade)
	{
		int price = Accessory.Instance[grade].BaseValue;
		return PriceToResource(resourceType, price);
	}

	public static sbyte ResourceToPriceGrade(sbyte resourceType, int count)
	{
		return PriceToGrade(ResourceToPrice(resourceType, count));
	}

	public static int GradeToPriceExp(sbyte grade)
	{
		return PriceToExp(Accessory.Instance[grade].BaseValue);
	}

	public static sbyte ExpToPriceGrade(int count)
	{
		return PriceToGrade(ExpToPrice(count));
	}

	public static sbyte PriceToGrade(int price)
	{
		for (sbyte grade = 8; grade >= 0; grade--)
		{
			AccessoryItem equivalentItem = Accessory.Instance[grade];
			if (price >= equivalentItem.BaseValue)
			{
				return grade;
			}
		}
		return -1;
	}
}
