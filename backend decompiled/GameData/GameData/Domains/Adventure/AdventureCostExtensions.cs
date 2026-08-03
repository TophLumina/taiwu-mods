using System.Collections.Generic;
using GameData.Adventure;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

public static class AdventureCostExtensions
{
	public static bool IsCostEnough(this AdventureCostData costData, IReadOnlyList<ItemKey> costItems)
	{
		if (!DomainManager.Extra.IsActionPointEnough(costData.CostTime))
		{
			return false;
		}
		bool resourceNotEnough = false;
		Dictionary<int, int> costResources = ObjectPool<Dictionary<int, int>>.Instance.Get();
		foreach (AdventureCostResource costResource in costData.CostResources)
		{
			costResources[costResource.Type] = costResources.GetOrDefault(costResource.Type) + costResource.Value;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int value;
		foreach (KeyValuePair<int, int> item in costResources)
		{
			item.Deconstruct(out var key, out value);
			int type = key;
			int value2 = value;
			if (taiwu.GetResource((sbyte)type) < value2)
			{
				resourceNotEnough = true;
			}
		}
		ObjectPool<Dictionary<int, int>>.Instance.Return(costResources);
		if (resourceNotEnough)
		{
			return false;
		}
		if (taiwu.GetExp() < costData.CostExp)
		{
			return false;
		}
		if (costItems == null || costItems.Count <= 0)
		{
			return costData.CostItems.Count == 0;
		}
		if (costItems.Count != costData.CostItems.Count)
		{
			return false;
		}
		for (int i = 0; i < costItems.Count; i++)
		{
			if (!costData.CostItems[i].Contains(costItems[i].ItemType, costItems[i].TemplateId))
			{
				return false;
			}
		}
		bool itemEnough = true;
		Dictionary<ItemKey, int> itemCounts = ObjectPool<Dictionary<ItemKey, int>>.Instance.Get();
		List<ItemKey> noCostKeys = ObjectPool<List<ItemKey>>.Instance.Get();
		for (int j = 0; j < costItems.Count; j++)
		{
			ItemKey itemKey = costItems[j];
			if (costData.CostItems[j].NoCost)
			{
				noCostKeys.AddUnique(itemKey);
			}
			else
			{
				itemCounts.Accumulate(itemKey);
			}
		}
		Inventory inventory = taiwu.GetInventory();
		foreach (KeyValuePair<ItemKey, int> item2 in itemCounts)
		{
			item2.Deconstruct(out var key2, out value);
			ItemKey itemKey2 = key2;
			int count = value;
			if (!inventory.Items.TryGetValue(itemKey2, out var hasCount) || hasCount < count)
			{
				itemEnough = false;
			}
		}
		foreach (ItemKey itemKey3 in noCostKeys)
		{
			if (DomainManager.Taiwu.GetItemCount(itemKey3.ItemType, itemKey3.TemplateId) == 0)
			{
				itemEnough = false;
			}
		}
		ObjectPool<Dictionary<ItemKey, int>>.Instance.Return(itemCounts);
		return itemEnough;
	}

	public static void MakeCost(this AdventureCostData costData, DataContext context, IReadOnlyList<ItemKey> costItems)
	{
		DomainManager.Extra.ConsumeActionPoint(context, costData.CostTime);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		foreach (AdventureCostResource costResource in costData.CostResources)
		{
			taiwu.ChangeResource(context, (sbyte)costResource.Type, -costResource.Value);
		}
		taiwu.ChangeExp(context, -costData.CostExp);
		if (costItems == null || costItems.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < costItems.Count; i++)
		{
			if (!costData.CostItems[i].NoCost)
			{
				ItemKey itemKey = costItems[i];
				taiwu.RemoveInventoryItem(context, itemKey, 1, deleteItem: true);
			}
		}
	}
}
