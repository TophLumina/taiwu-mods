using System;

namespace GameData.Domains.Item.Display;

/// <summary>
/// 物品显示数据筛选
/// </summary>
public static class ItemDisplayDataFilters
{
	/// <summary>
	/// 获取一个筛选委托
	/// </summary>
	/// <param name="filterId"></param>
	/// <returns></returns>
	public static Predicate<ITradeableContent> GetFilter(ushort filterId)
	{
		return filterId switch
		{
			1 => IsItemRepairable, 
			2 => IsItemTransferable, 
			3 => IsItemFullDurability, 
			4 => CanItemAsGift, 
			5 => IsItemTransferableOrLegendaryBook, 
			_ => null, 
		};
	}

	/// <summary>
	/// 物品是否可以修理
	/// </summary>
	/// <param name="itemDisplayData"></param>
	/// <returns></returns>
	public static bool IsItemRepairable(ITradeableContent itemDisplayData)
	{
		if (ItemTemplateHelper.IsRepairable(itemDisplayData.Key.ItemType, itemDisplayData.Key.TemplateId))
		{
			return itemDisplayData.Durability < itemDisplayData.MaxDurability;
		}
		return false;
	}

	/// <summary>
	/// 物品是否可以转移
	/// </summary>
	/// <param name="itemDisplayData"></param>
	/// <returns></returns>
	public static bool IsItemTransferable(ITradeableContent itemDisplayData)
	{
		if (!ItemTemplateHelper.IsTransferable(itemDisplayData.Key.ItemType, itemDisplayData.Key.TemplateId))
		{
			return ItemTemplateHelper.MiscResourceCanExchange(itemDisplayData.Key.ItemType, itemDisplayData.Key.TemplateId);
		}
		return true;
	}

	/// <summary>
	/// 物品是否可以转移或是奇书
	/// </summary>
	/// <param name="itemDisplayData"></param>
	/// <returns></returns>
	public static bool IsItemTransferableOrLegendaryBook(ITradeableContent itemDisplayData)
	{
		if (!IsItemTransferable(itemDisplayData))
		{
			return ItemTemplateHelper.GetItemSubType(itemDisplayData.Key.ItemType, itemDisplayData.Key.TemplateId) == 1202;
		}
		return true;
	}

	/// <summary>
	/// 物品是否是满耐久
	/// </summary>
	/// <param name="itemDisplayData"></param>
	/// <returns></returns>
	public static bool IsItemFullDurability(ITradeableContent itemDisplayData)
	{
		return itemDisplayData.Durability >= itemDisplayData.MaxDurability;
	}

	/// <summary>
	/// 物品是否可以作为礼物赠送
	/// </summary>
	/// <param name="itemDisplayData"></param>
	/// <returns></returns>
	public static bool CanItemAsGift(ITradeableContent itemDisplayData)
	{
		if (itemDisplayData.Key.ItemType == 11)
		{
			return true;
		}
		return IsItemFullDurability(itemDisplayData);
	}
}
