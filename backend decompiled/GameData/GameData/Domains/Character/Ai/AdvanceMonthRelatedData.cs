using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.Character.Ai;

public class AdvanceMonthRelatedData
{
	public readonly TempListContainer<(ItemBase item, int amount)> ItemsWithAmount = new TempListContainer<(ItemBase, int)>();

	public readonly TempListContainer<TemplateKey> ItemTemplateKeys = new TempListContainer<TemplateKey>();

	public readonly TempListContainer<ItemKey> ItemKeys = new TempListContainer<ItemKey>();

	public readonly StrictTempObjectContainer<List<(ItemBase item, int amount)>[]> ClassifiedItems = new StrictTempObjectContainer<List<(ItemBase, int)>[]>(new List<(ItemBase, int)>[3]
	{
		new List<(ItemBase, int)>(),
		new List<(ItemBase, int)>(),
		new List<(ItemBase, int)>()
	}, Clear);

	public readonly TempDictionaryContainer<short, (sbyte maxGrade, int totalAmount)> ItemSubTypeStats = new TempDictionaryContainer<short, (sbyte, int)>();

	public readonly StrictTempObjectContainer<List<(GameData.Domains.Item.Medicine item, int amount)>[]> CategorizedMedicines = new StrictTempObjectContainer<List<(GameData.Domains.Item.Medicine, int)>[]>(new List<(GameData.Domains.Item.Medicine, int)>[7]
	{
		new List<(GameData.Domains.Item.Medicine, int)>(),
		new List<(GameData.Domains.Item.Medicine, int)>(),
		new List<(GameData.Domains.Item.Medicine, int)>(),
		new List<(GameData.Domains.Item.Medicine, int)>(),
		new List<(GameData.Domains.Item.Medicine, int)>(),
		new List<(GameData.Domains.Item.Medicine, int)>(),
		new List<(GameData.Domains.Item.Medicine, int)>()
	}, Clear);

	public readonly TempListContainer<(GameData.Domains.Item.Misc item, int amount)> ItemsForNeili = new TempListContainer<(GameData.Domains.Item.Misc, int)>();

	public readonly StrictTempObjectContainer<List<(GameData.Domains.Item.Food item, int amount)>[]> FoodsForMainAttributes = new StrictTempObjectContainer<List<(GameData.Domains.Item.Food, int)>[]>(new List<(GameData.Domains.Item.Food, int)>[6]
	{
		new List<(GameData.Domains.Item.Food, int)>(),
		new List<(GameData.Domains.Item.Food, int)>(),
		new List<(GameData.Domains.Item.Food, int)>(),
		new List<(GameData.Domains.Item.Food, int)>(),
		new List<(GameData.Domains.Item.Food, int)>(),
		new List<(GameData.Domains.Item.Food, int)>()
	}, Clear);

	public readonly TempListContainer<(GameData.Domains.Item.TeaWine item, int amount)> TeaWinesForHappiness = new TempListContainer<(GameData.Domains.Item.TeaWine, int)>();

	public readonly TempObjectContainer<PotentialRelatedCharacters> CurrBlockCanStartRelationChars = new TempObjectContainer<PotentialRelatedCharacters>(delegate(PotentialRelatedCharacters obj)
	{
		obj.OfflineClear();
	});

	public readonly TempObjectContainer<PotentialRelatedCharacters> CurrBlockCanEndRelationChars = new TempObjectContainer<PotentialRelatedCharacters>(delegate(PotentialRelatedCharacters obj)
	{
		obj.OfflineClear();
	});

	public readonly TempListContainer<int> CharIdList = new TempListContainer<int>();

	public readonly TempListContainer<int> TargetCharIdList = new TempListContainer<int>();

	public readonly TempHashsetContainer<int> BlockCharSet = new TempHashsetContainer<int>();

	public readonly TempHashsetContainer<int> RelatedCharIds = new TempHashsetContainer<int>();

	public readonly TempHashsetContainer<int> CaringCharIds = new TempHashsetContainer<int>();

	public readonly List<ItemKey> WorldItemsToBeRemoved = new List<ItemKey>();

	public readonly StrictTempObjectContainer<List<int>[]> DemandActionTargets = new StrictTempObjectContainer<List<int>[]>(new List<int>[5]
	{
		new List<int>(),
		new List<int>(),
		new List<int>(),
		new List<int>(),
		new List<int>()
	}, Clear);

	public readonly StrictTempObjectContainer<List<int>[]> PrioritizedTargets = new StrictTempObjectContainer<List<int>[]>(new List<int>[9]
	{
		new List<int>(),
		new List<int>(),
		new List<int>(),
		new List<int>(),
		new List<int>(),
		new List<int>(),
		new List<int>(),
		new List<int>(),
		new List<int>()
	}, Clear);

	public readonly TempListContainer<(short, short)> WeightTable = new TempListContainer<(short, short)>();

	public readonly TempListContainer<short> BlockIds = new TempListContainer<short>();

	public readonly TempListContainer<MapBlockData> Blocks = new TempListContainer<MapBlockData>();

	public readonly TempHashsetContainer<short> TemplateIdSet = new TempHashsetContainer<short>();

	public readonly TempListContainer<Wager> Wagers = new TempListContainer<Wager>();

	public readonly TempListContainer<int> IntList = new TempListContainer<int>();

	public static void Clear<T>(List<T>[] listArray)
	{
		foreach (List<T> list in listArray)
		{
			list.Clear();
		}
	}

	public unsafe void CategorizedRegenItems(IReadOnlyDictionary<ItemKey, int> inventoryItems)
	{
		List<(GameData.Domains.Item.Medicine, int)>[] categorizedRegenItems = CategorizedMedicines.Occupy();
		List<(GameData.Domains.Item.Food, int)>[] foods = FoodsForMainAttributes.Occupy();
		List<(GameData.Domains.Item.TeaWine, int)> teaWines = TeaWinesForHappiness.Occupy();
		List<(GameData.Domains.Item.Misc, int)> itemsForNeili = ItemsForNeili.Occupy();
		foreach (var (itemKey2, amount) in inventoryItems)
		{
			switch (itemKey2.ItemType)
			{
			case 7:
			{
				FoodItem config3 = Config.Food.Instance[itemKey2.TemplateId];
				for (sbyte attrType = 0; attrType < 6; attrType++)
				{
					if (config3.MainAttributesRegen.Items[attrType] > 0)
					{
						GameData.Domains.Item.Food item4 = DomainManager.Item.GetElement_Foods(itemKey2.Id);
						foods[attrType].Add((item4, amount));
						break;
					}
				}
				break;
			}
			case 8:
			{
				MedicineItem config2 = Config.Medicine.Instance[itemKey2.TemplateId];
				if (config2.EffectType != EMedicineEffectType.Invalid)
				{
					GameData.Domains.Item.Medicine item2 = DomainManager.Item.GetElement_Medicines(itemKey2.Id);
					categorizedRegenItems[(int)config2.EffectType].Add((item2, amount));
				}
				break;
			}
			case 9:
				if (DomainManager.Item.GetBaseItem(itemKey2).GetHappinessChange() > 0)
				{
					GameData.Domains.Item.TeaWine item3 = DomainManager.Item.GetElement_TeaWines(itemKey2.Id);
					teaWines.Add((item3, amount));
				}
				break;
			case 12:
			{
				MiscItem config = Config.Misc.Instance[itemKey2.TemplateId];
				if (config.Neili > 0)
				{
					GameData.Domains.Item.Misc item = DomainManager.Item.GetElement_Misc(itemKey2.Id);
					itemsForNeili.Add((item, amount));
				}
				break;
			}
			}
		}
	}

	public void ReleaseCategorizedRegenItems()
	{
		QuickRelease(CategorizedMedicines);
		QuickRelease(FoodsForMainAttributes);
		QuickRelease(TeaWinesForHappiness);
		QuickRelease(ItemsForNeili);
	}

	public void SummarizeItemSubTypeStats(Dictionary<ItemKey, int> inventoryItems, ItemKey[] equipmentItems)
	{
		Dictionary<short, (sbyte, int)> itemSubTypeStats = ItemSubTypeStats.Occupy();
		itemSubTypeStats.Clear();
		foreach (KeyValuePair<ItemKey, int> pair in inventoryItems)
		{
			ItemKey itemKey = pair.Key;
			int amount = pair.Value;
			short itemSubType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
			sbyte itemGrade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
			if (itemSubTypeStats.TryGetValue(itemSubType, out var itemInfo))
			{
				itemGrade = Math.Max(itemInfo.Item1, itemGrade);
				amount = itemInfo.Item2 + amount;
			}
			itemSubTypeStats[itemSubType] = (itemGrade, amount);
		}
		for (int i = 0; i < equipmentItems.Length; i++)
		{
			ItemKey itemKey2 = equipmentItems[i];
			if (itemKey2.IsValid())
			{
				int amount2 = 1;
				short itemSubType2 = ItemTemplateHelper.GetItemSubType(itemKey2.ItemType, itemKey2.TemplateId);
				sbyte itemGrade2 = ItemTemplateHelper.GetGrade(itemKey2.ItemType, itemKey2.TemplateId);
				if (itemSubTypeStats.TryGetValue(itemSubType2, out var itemInfo2))
				{
					itemGrade2 = Math.Max(itemInfo2.Item1, itemGrade2);
					amount2 = itemInfo2.Item2 + amount2;
				}
				itemSubTypeStats[itemSubType2] = (itemGrade2, amount2);
			}
		}
	}

	public void ReleaseItemSubTypeStats()
	{
		QuickRelease(ItemSubTypeStats);
	}

	private static void QuickRelease<T>(TempObjectContainerBase<T> container) where T : class
	{
		T obj = container.Get();
		container.Release(ref obj);
	}
}
