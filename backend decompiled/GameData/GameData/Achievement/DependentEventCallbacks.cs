using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Taiwu;

namespace GameData.Achievement;

public class DependentEventCallbacks
{
	[DependentIdentifier(EDependent.OnArchiveDataLoaded)]
	private static ulong[] EDependent_OnArchiveDataLoaded(DataContext context)
	{
		return Array.Empty<ulong>();
	}

	[DependentIdentifier(EDependent.OnTaiwuCharIdChanged)]
	private static ulong[] EDependent_OnTaiwuCharIdChanged(DataContext context)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		HashSet<int> lovers = DomainManager.Character.GetReversedRelatedCharIds(taiwuId, 16384).GetCollection();
		HashSet<int> haters = DomainManager.Character.GetReversedRelatedCharIds(taiwuId, 32768).GetCollection();
		int loveAndHateCount = 0;
		foreach (int id in lovers)
		{
			if (haters.Contains(id))
			{
				loveAndHateCount++;
			}
		}
		AchievementManager.RequestSetStat(context, 1, lovers.Count);
		AchievementManager.RequestSetStat(context, 2, haters.Count);
		AchievementManager.RequestSetStat(context, 3, loveAndHateCount);
		return new ulong[1] { (ulong)DomainManager.Taiwu.GetTaiwuCharId() };
	}

	[DependentIdentifier(EDependent.OnTaiwuItemsChanged)]
	private static ulong[] EDependent_OnTaiwuItemsChanged(DataContext context)
	{
		Character taiwu = DomainManager.Taiwu.GetTaiwu();
		IReadOnlyDictionary<ItemKey, int> inventory = DomainManager.Taiwu.GetItems(ItemSourceType.Inventory);
		IReadOnlyDictionary<ItemKey, int> warehouse = DomainManager.Taiwu.GetItems(ItemSourceType.Warehouse);
		IReadOnlyDictionary<ItemKey, int> treasury = DomainManager.Taiwu.GetItems(ItemSourceType.Treasury);
		ItemKey[] equipment = taiwu.GetEquipment();
		Dictionary<ItemKey, int> curItems = new Dictionary<ItemKey, int>();
		foreach (KeyValuePair<ItemKey, int> item in inventory)
		{
			curItems[item.Key] = (curItems.TryGetValue(item.Key, out var curItem) ? (curItem + item.Value) : item.Value);
		}
		foreach (KeyValuePair<ItemKey, int> item2 in warehouse)
		{
			curItems[item2.Key] = (curItems.TryGetValue(item2.Key, out var curItem2) ? (curItem2 + item2.Value) : item2.Value);
		}
		foreach (KeyValuePair<ItemKey, int> item3 in treasury)
		{
			curItems[item3.Key] = (curItems.TryGetValue(item3.Key, out var curItem3) ? (curItem3 + item3.Value) : item3.Value);
		}
		for (int i = 0; i < 17; i++)
		{
			ItemKey itemKey = equipment[i];
			if (itemKey.IsValid())
			{
				curItems[itemKey] = ((!curItems.TryGetValue(itemKey, out var curItem4)) ? 1 : (curItem4 + 1));
			}
		}
		int cookingBeast1Count = 0;
		foreach (KeyValuePair<ItemKey, int> item4 in curItems)
		{
			switch (item4.Key.ItemType)
			{
			case 5:
				if (item4.Key.TemplateId == 64)
				{
					cookingBeast1Count = item4.Value;
				}
				break;
			}
		}
		int cookingBeast1CountDelta = cookingBeast1Count - AchievementManager.CookingBeast1Count;
		if (AchievementManager.CookingBeast1Count >= 0 && cookingBeast1CountDelta > 0)
		{
			AchievementManager.RequestSetStat(context, 0, cookingBeast1CountDelta);
		}
		AchievementManager.CookingBeast1Count = cookingBeast1Count;
		return Array.Empty<ulong>();
	}
}
