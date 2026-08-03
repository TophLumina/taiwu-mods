using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Config;

namespace GameData.Domains.Item;

/// <summary>
/// 蛐蛐相关常量计算逻辑类，对 GlobalConfig 的访问进行简单封装，可以直接静态 using 相关访问方法
/// </summary>
public static class CricketSpecialConstants
{
	/// <summary>
	/// 蛐蛐物品类型赌注检索器（每个检索器对应一个赌注）
	/// </summary>
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

	/// <inheritdoc cref="F:GlobalConfig.BaseCricketWagerGrade" />
	public static sbyte[] BaseWagerGrade => GlobalConfig.Instance.BaseCricketWagerGrade;

	/// <summary>
	/// 计算赌注品阶范围
	/// </summary>
	/// <param name="charGrade">人物身份品阶</param>
	/// <param name="taiwuFame">太吾名誉值</param>
	/// <returns></returns>
	public static (sbyte min, sbyte max) CalcWagerGradeRange(sbyte charGrade, sbyte taiwuFame)
	{
		sbyte maxGrade = (sbyte)Math.Clamp(BaseWagerGrade[Math.Clamp(charGrade, 0, BaseWagerGrade.Length - 1)] + Math.Min(taiwuFame / 25, 3), 0, 8);
		return (min: (sbyte)Math.Max(maxGrade - 3, 0), max: maxGrade);
	}

	/// <summary>
	/// 将价格转为资源
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int PriceToResource(sbyte resourceType, int price)
	{
		return price / GlobalConfig.ResourcesPrice[resourceType];
	}

	/// <summary>
	/// 将资源转为价格
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ResourceToPrice(sbyte resourceType, int count)
	{
		return GlobalConfig.ResourcesPrice[resourceType] * count;
	}

	/// <summary>
	/// 将价格转为历练
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int PriceToExp(int price)
	{
		return price / 5;
	}

	/// <summary>
	/// 将历练转为价格
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ExpToPrice(int count)
	{
		return count * 5;
	}

	/// <summary>
	/// 将道具品级转为同价格资源
	/// </summary>
	public static int GradeToPriceResource(sbyte resourceType, sbyte grade)
	{
		int price = Accessory.Instance[grade].BaseValue;
		return PriceToResource(resourceType, price);
	}

	/// <summary>
	/// 将资源转为同价格道具品级
	/// </summary>
	public static sbyte ResourceToPriceGrade(sbyte resourceType, int count)
	{
		return PriceToGrade(ResourceToPrice(resourceType, count));
	}

	/// <summary>
	/// 将道具品级转为同价格历练
	/// </summary>
	public static int GradeToPriceExp(sbyte grade)
	{
		return PriceToExp(Accessory.Instance[grade].BaseValue);
	}

	/// <summary>
	/// 将历练转为同价格道具品级
	/// </summary>
	public static sbyte ExpToPriceGrade(int count)
	{
		return PriceToGrade(ExpToPrice(count));
	}

	/// <summary>
	/// 将价格转换为等价物道具品级
	/// </summary>
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
