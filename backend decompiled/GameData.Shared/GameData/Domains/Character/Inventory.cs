using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

public class Inventory : ISerializableGameData
{
	[SerializableGameDataField]
	public readonly Dictionary<ItemKey, int> Items;

	public bool NeedCommit;

	public static readonly IReadOnlyDictionary<ItemKey, int> Empty = new Dictionary<ItemKey, int>();

	public int InventoryItemTotalCount => Items.Sum((KeyValuePair<ItemKey, int> i) => i.Value);

	public Inventory()
	{
		Items = new Dictionary<ItemKey, int>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 4 + 12 * Items.Count;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Items.Count;
		pCurrData += 4;
		foreach (KeyValuePair<ItemKey, int> entry in Items)
		{
			pCurrData += entry.Key.Serialize(pCurrData);
			*(int*)pCurrData = entry.Value;
			pCurrData += 4;
		}
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		Items.Clear();
		byte* pCurrData = pData;
		int itemsCount = *(int*)pCurrData;
		pCurrData += 4;
		for (int i = 0; i < itemsCount; i++)
		{
			ItemKey itemKey = default(ItemKey);
			pCurrData += itemKey.Deserialize(pCurrData);
			int amount = *(int*)pCurrData;
			pCurrData += 4;
			Items.Add(itemKey, amount);
		}
		return (int)(pCurrData - pData);
	}

	public void OfflineAdd(ItemKey itemKey, int amount)
	{
		Tester.Assert(amount > 0);
		int oriAmount;
		bool alreadyInInventory = Items.TryGetValue(itemKey, out oriAmount);
		if (itemKey.Id >= 0 && !ItemTemplateHelper.IsPureStackable(itemKey))
		{
			if (alreadyInInventory)
			{
				PredefinedLog.DefValue.InvalidItemStacking1.Log(itemKey);
				return;
			}
			if (amount > 1)
			{
				PredefinedLog.DefValue.InvalidItemStacking2.Log(itemKey, amount);
				amount = 1;
			}
		}
		if (alreadyInInventory)
		{
			Items[itemKey] = (int)Math.Min((long)oriAmount + (long)amount, 2147483647L);
		}
		else
		{
			Items.Add(itemKey, Math.Min(amount, int.MaxValue));
		}
	}

	public void OfflineAddUncheck(ItemKey itemKey, int amount)
	{
		Tester.Assert(amount > 0);
		if (Items.TryGetValue(itemKey, out var oriAmount))
		{
			Items[itemKey] = (int)Math.Min((long)oriAmount + (long)amount, 2147483647L);
		}
		else
		{
			Items.Add(itemKey, Math.Min(amount, int.MaxValue));
		}
	}

	public void OfflineAdd(List<ItemKey> keyList)
	{
		Tester.Assert(keyList != null);
		Tester.Assert(keyList.Count > 0);
		foreach (ItemKey key in keyList)
		{
			OfflineAdd(key, 1);
		}
	}

	public void OfflineAdd(Dictionary<ItemKey, int> dict)
	{
		Tester.Assert(dict != null);
		Tester.Assert(dict.Count > 0);
		foreach (var (key, count) in dict)
		{
			OfflineAdd(key, count);
		}
	}

	public void OfflineAdd(Inventory inventory)
	{
		Tester.Assert(inventory != null);
		OfflineAdd(inventory.Items);
	}

	public void OfflineRemove(ItemKey itemKey, int amount)
	{
		Tester.Assert(amount > 0);
		int currAmount = Items[itemKey] - amount;
		if (currAmount > 0)
		{
			Items[itemKey] = currAmount;
			return;
		}
		if (currAmount == 0)
		{
			Items.Remove(itemKey);
			return;
		}
		throw new Exception($"Item amount cannot be negative after removing: {itemKey}, {amount}");
	}

	public void OfflineRemove(ItemKey itemKey)
	{
		Items.Remove(itemKey);
	}

	public void OfflineRemove(List<ItemKey> keyList)
	{
		Tester.Assert(keyList != null);
		Tester.Assert(keyList.Count > 0);
		foreach (ItemKey key in keyList)
		{
			OfflineRemove(key, 1);
		}
	}

	public void OfflineRemove(Dictionary<ItemKey, int> dict)
	{
		Tester.Assert(dict != null);
		Tester.Assert(dict.Count > 0);
		foreach (var (key, count) in dict)
		{
			OfflineRemove(key, count);
		}
	}

	public void OfflineRemove(Inventory inventory)
	{
		Tester.Assert(inventory != null);
		OfflineRemove(inventory.Items);
	}

	public int GetInventoryItemCount(ItemKey itemKey)
	{
		Items.TryGetValue(itemKey, out var count);
		return count;
	}

	public int GetInventoryItemCount(sbyte itemType, short itemTemplateId)
	{
		Tester.Assert(itemTemplateId >= 0);
		int count = 0;
		foreach (KeyValuePair<ItemKey, int> pair in Items)
		{
			if (pair.Key.ItemType == itemType && pair.Key.TemplateId == itemTemplateId)
			{
				count += Items[pair.Key];
			}
		}
		return count;
	}

	public int GetInventoryItemTypeCount(sbyte itemType)
	{
		int count = 0;
		foreach (KeyValuePair<ItemKey, int> pair in Items)
		{
			if (pair.Key.ItemType == itemType)
			{
				count += Items[pair.Key];
			}
		}
		return count;
	}

	public ItemKey GetInventoryItemKey(sbyte itemType, short itemTemplateId = -1)
	{
		Tester.Assert(itemTemplateId >= 0);
		foreach (ItemKey itemKey in Items.Keys)
		{
			if (itemKey.ItemType == itemType && (itemTemplateId == -1 || itemKey.TemplateId == itemTemplateId))
			{
				return itemKey;
			}
		}
		return ItemKey.Invalid;
	}

	public ItemKey GetInventoryItemKeyByItemType(short itemType)
	{
		Tester.Assert(itemType >= 0);
		foreach (ItemKey itemKey in Items.Keys)
		{
			if (itemKey.ItemType == itemType)
			{
				return itemKey;
			}
		}
		return ItemKey.Invalid;
	}

	public ItemKey GetInventoryItemKeyByItemSubType(short itemSubType)
	{
		Tester.Assert(itemSubType >= 0);
		foreach (ItemKey itemKey in Items.Keys)
		{
			if (itemKey.HasTemplate && ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == itemSubType)
			{
				return itemKey;
			}
		}
		return ItemKey.Invalid;
	}

	public void GetInventoryItemKeyList(sbyte itemType, short itemTemplateId, List<ItemKey> resultList)
	{
		Tester.Assert(itemTemplateId >= 0);
		Tester.Assert(resultList != null);
		foreach (ItemKey itemKey in Items.Keys)
		{
			if (itemKey.ItemType == itemType && itemKey.TemplateId == itemTemplateId)
			{
				resultList.Add(itemKey);
			}
		}
	}

	public bool HasItemInGroup(sbyte itemType, short groupId, sbyte minGrade = 0, sbyte maxGrade = 8, List<ItemKey> resultList = null)
	{
		bool hasItem = false;
		bool hasResultList = resultList != null;
		foreach (ItemKey itemKey in Items.Keys)
		{
			if (itemKey.ItemType != itemType || ItemTemplateHelper.GetGroupId(itemKey.ItemType, itemKey.TemplateId) != groupId)
			{
				continue;
			}
			sbyte grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
			if (grade >= minGrade && grade <= maxGrade)
			{
				hasItem = true;
				if (!hasResultList)
				{
					return true;
				}
				resultList.Add(itemKey);
			}
		}
		return hasItem;
	}

	public bool HasItemInSameGroup(sbyte itemType, short templateId, int minGradeOffset = -9, List<ItemKey> resultList = null)
	{
		Tester.Assert(minGradeOffset <= 0);
		short groupId = ItemTemplateHelper.GetGroupId(itemType, templateId);
		if (groupId < 0)
		{
			return GetInventoryItemKey(itemType, templateId).HasTemplate;
		}
		sbyte requiredMinGrade = (sbyte)(ItemTemplateHelper.GetGrade(itemType, templateId) + minGradeOffset);
		return HasItemInGroup(itemType, groupId, requiredMinGrade, 8, resultList);
	}

	public ItemKey GetItemInGroup(sbyte itemType, short groupId, sbyte minGrade, sbyte maxGrade)
	{
		ItemKey currItemKey = ItemKey.Invalid;
		int currGrade = -1;
		foreach (ItemKey itemKey in Items.Keys)
		{
			if (itemKey.ItemType == itemType && ItemTemplateHelper.GetGroupId(itemKey.ItemType, itemKey.TemplateId) == groupId)
			{
				sbyte grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
				if (grade == maxGrade)
				{
					return itemKey;
				}
				if (grade >= minGrade && grade <= maxGrade && grade >= currGrade)
				{
					currGrade = grade;
					currItemKey = itemKey;
				}
			}
		}
		return currItemKey;
	}

	public ItemKey GetItemInSameGroup(sbyte itemType, short templateId, int minGradeOffset = -9)
	{
		Tester.Assert(minGradeOffset <= 0);
		short groupId = ItemTemplateHelper.GetGroupId(itemType, templateId);
		if (groupId < 0)
		{
			return GetInventoryItemKey(itemType, templateId);
		}
		sbyte expectedGrade = ItemTemplateHelper.GetGrade(itemType, templateId);
		sbyte requiredMinGrade = (sbyte)(expectedGrade + minGradeOffset);
		return GetItemInGroup(itemType, groupId, requiredMinGrade, expectedGrade);
	}

	public bool ContainsMedicine(EMedicineEffectType effectType)
	{
		foreach (ItemKey itemKey in Items.Keys)
		{
			if (itemKey.ItemType == 8 && Medicine.Instance[itemKey.TemplateId].EffectType == effectType)
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsMainAttributeRegenItem(sbyte attributeType)
	{
		foreach (ItemKey itemKey in Items.Keys)
		{
			if (itemKey.ItemType == 7 && Food.Instance[itemKey.TemplateId].MainAttributesRegen[attributeType] > 0)
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsItemType(sbyte itemType)
	{
		foreach (ItemKey key in Items.Keys)
		{
			if (key.ItemType == itemType)
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsItemSubType(short itemSubType)
	{
		foreach (ItemKey itemKey in Items.Keys)
		{
			if (ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == itemSubType)
			{
				return true;
			}
		}
		return false;
	}

	public bool Contains(int itemId)
	{
		foreach (ItemKey key in Items.Keys)
		{
			if (key.Id == itemId)
			{
				return true;
			}
		}
		return false;
	}
}
