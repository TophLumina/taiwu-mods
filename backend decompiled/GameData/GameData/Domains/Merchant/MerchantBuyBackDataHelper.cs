using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Merchant;

public static class MerchantBuyBackDataHelper
{
	public static ItemKey TryGetGoodInSameGroup(this MerchantBuyBackData data, DataContext context, sbyte itemType, short itemTemplateId, int minGradeOffset = -9, bool requireDurability = true)
	{
		if (data.BuyInGoodsList == null || data.BuyInPrice == null)
		{
			return ItemKey.Invalid;
		}
		List<ItemKey> itemKeys = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		data.BuyInGoodsList.HasItemInSameGroup(itemType, itemTemplateId, minGradeOffset, itemKeys);
		if (requireDurability)
		{
			for (int i = itemKeys.Count - 1; i >= 0; i--)
			{
				ItemKey itemKey = itemKeys[i];
				ItemBase itemBase = DomainManager.Item.GetBaseItem(itemKey);
				if (itemBase.GetMaxDurability() > 0 && itemBase.GetCurrDurability() <= 0)
				{
					CollectionUtils.SwapAndRemove(itemKeys, i);
				}
			}
		}
		ItemKey selectedItemKey = itemKeys.GetRandomOrDefault(context.Random, ItemKey.Invalid);
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref itemKeys);
		return selectedItemKey;
	}

	public static void RemoveAllGoods(this MerchantBuyBackData data, DataContext context)
	{
		if (data.BuyInGoodsList == null || data.BuyInPrice == null)
		{
			return;
		}
		int merchantMoney = DomainManager.Merchant.GetMerchantMoney(context, data.MerchantType);
		foreach (KeyValuePair<ItemKey, int> item in data.BuyInGoodsList.Items)
		{
			ItemKey itemKey = item.Key;
			ItemBase itemBase = DomainManager.Item.GetBaseItem(itemKey);
			int value = DomainManager.Item.GetValue(itemKey);
			if (itemBase is GameData.Domains.Item.Cricket cricket)
			{
				CricketPartsItem colorConfig = CricketParts.Instance[cricket.GetColorId()];
				CricketPartsItem partConfig = CricketParts.Instance[cricket.GetPartId()];
				value = ((cricket.GetPartId() > 0) ? Math.Max(colorConfig.Price, partConfig.Price) : colorConfig.Price);
			}
			short durability = itemBase.GetCurrDurability();
			short maxDurability = itemBase.GetMaxDurability();
			int durabilityRate = ((maxDurability == 0) ? 100 : (durability * 100 / maxDurability));
			int durabilityBidding = 50 + durabilityRate / 2;
			int money = Math.Max(0, value * 20 / 100 * durabilityBidding / 100);
			if (money > 0)
			{
				merchantMoney += money;
			}
		}
		DomainManager.Merchant.SetMerchantMoney(context, data.MerchantType, merchantMoney);
		DomainManager.Item.RemoveItems(context, data.BuyInGoodsList.Items);
		data.BuyInGoodsList.Items.Clear();
		data.BuyInPrice.Clear();
	}
}
