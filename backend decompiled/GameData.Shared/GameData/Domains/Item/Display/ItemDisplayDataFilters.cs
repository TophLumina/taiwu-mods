using System;

namespace GameData.Domains.Item.Display;

public static class ItemDisplayDataFilters
{
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

	public static bool IsItemRepairable(ITradeableContent itemDisplayData)
	{
		if (ItemTemplateHelper.IsRepairable(itemDisplayData.Key.ItemType, itemDisplayData.Key.TemplateId))
		{
			return itemDisplayData.Durability < itemDisplayData.MaxDurability;
		}
		return false;
	}

	public static bool IsItemTransferable(ITradeableContent itemDisplayData)
	{
		if (!itemDisplayData.ForceNotTransferable)
		{
			if (!ItemTemplateHelper.IsTransferable(itemDisplayData.Key.ItemType, itemDisplayData.Key.TemplateId))
			{
				return ItemTemplateHelper.MiscResourceCanExchange(itemDisplayData.Key.ItemType, itemDisplayData.Key.TemplateId);
			}
			return true;
		}
		return false;
	}

	public static bool IsItemTransferableOrLegendaryBook(ITradeableContent itemDisplayData)
	{
		if (!IsItemTransferable(itemDisplayData))
		{
			return ItemTemplateHelper.GetItemSubType(itemDisplayData.Key.ItemType, itemDisplayData.Key.TemplateId) == 1202;
		}
		return true;
	}

	public static bool IsItemFullDurability(ITradeableContent itemDisplayData)
	{
		return itemDisplayData.Durability >= itemDisplayData.MaxDurability;
	}

	public static bool CanItemAsGift(ITradeableContent itemDisplayData)
	{
		if (itemDisplayData.Key.ItemType == 11)
		{
			return true;
		}
		return IsItemFullDurability(itemDisplayData);
	}
}
