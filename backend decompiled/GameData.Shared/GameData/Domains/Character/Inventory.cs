using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 人物行囊内的物品集合.
/// 由于是单值数据, 所以总长不能超过 64KB, 因而最大可容纳的不同物品数量约为 5.4K.
/// </summary>
public class Inventory : ISerializableGameData
{
	/// <summary>
	/// ItemKey -&gt; amount
	/// </summary>
	[SerializableGameDataField]
	public readonly Dictionary<ItemKey, int> Items;

	/// <summary>
	/// 是否需要提交数据，非序列化
	/// </summary>
	public bool NeedCommit;

	/// <summary>
	/// 空字典
	/// </summary>
	public static readonly IReadOnlyDictionary<ItemKey, int> Empty = new Dictionary<ItemKey, int>();

	/// <summary>
	/// 行囊所有物品的总数量
	/// </summary>
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

	/// <summary>
	/// 向行囊添加物品.
	/// *** 如果是已注册游戏数据, 修改之后一定要调用相关数据状态更新方法. ***
	/// </summary>
	/// <param name="itemKey"></param>
	/// <param name="amount"></param>
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

	/// <summary>
	/// 用于兼容假数据的版本.
	/// ***此处仅用于旧逻辑兼容, 新逻辑假数据应避免使用Inventory存储, 如果必要ID应为 -1.***
	/// <see cref="M:GameData.Domains.Character.Inventory.OfflineAdd(GameData.Domains.Item.ItemKey,System.Int32)" />
	/// </summary>
	/// <param name="itemKey"></param>
	/// <param name="amount"></param>
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

	/// <summary>
	/// 向行囊添加物品.对太吾和其交互对象操作复数物品时用此方法，因为有淬毒系统
	/// *** 如果是已注册游戏数据, 修改之后一定要调用相关数据状态更新方法. ***
	/// </summary>
	/// <param name="keyList"></param>
	public void OfflineAdd(List<ItemKey> keyList)
	{
		Tester.Assert(keyList != null);
		Tester.Assert(keyList.Count > 0);
		foreach (ItemKey key in keyList)
		{
			OfflineAdd(key, 1);
		}
	}

	/// <summary>
	/// 向行囊添加物品.对太吾和其交互对象操作复数物品时用此方法，因为有淬毒系统
	/// *** 如果是已注册游戏数据, 修改之后一定要调用相关数据状态更新方法. ***
	/// </summary>
	/// <param name="dict"></param>
	public void OfflineAdd(Dictionary<ItemKey, int> dict)
	{
		Tester.Assert(dict != null);
		Tester.Assert(dict.Count > 0);
		foreach (var (key, count) in dict)
		{
			OfflineAdd(key, count);
		}
	}

	/// <summary>
	/// 向行囊添加物品.对太吾和其交互对象操作复数物品时用此方法，因为有淬毒系统
	/// *** 如果是已注册游戏数据, 修改之后一定要调用相关数据状态更新方法. ***
	/// </summary>
	/// <param name="inventory"></param>
	public void OfflineAdd(Inventory inventory)
	{
		Tester.Assert(inventory != null);
		OfflineAdd(inventory.Items);
	}

	/// <summary>
	/// 离线从行囊移出物品，不涉及研读书籍、鉴定状态处理。默认应该调用 <see cref="!:Character.RemoveInventoryItem" />
	/// 移出后物品仍然存在. 如果想彻底删除物品, 需要调用物品数据域的相关方法.
	/// *** 如果是已注册游戏数据, 修改之后一定要调用相关数据状态更新方法. ***
	/// </summary>
	/// <param name="itemKey"></param>
	/// <param name="amount"></param>
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

	/// <summary>
	/// 离线从行囊移出物品，不涉及研读书籍、鉴定状态处理。默认应该调用 <see cref="!:Character.RemoveInventoryItem" />
	/// 移出后物品仍然存在. 如果想彻底删除物品, 需要调用物品数据域的相关方法.
	/// *** 如果是已注册游戏数据, 修改之后一定要调用相关数据状态更新方法. ***
	/// </summary>
	/// <param name="itemKey"></param>
	public void OfflineRemove(ItemKey itemKey)
	{
		Items.Remove(itemKey);
	}

	/// <summary>
	/// 离线从行囊移出物品，不涉及研读书籍、鉴定状态处理。对太吾和其交互对象操作复数物品时用此方法，因为有淬毒系统
	/// *** 如果是已注册游戏数据, 修改之后一定要调用相关数据状态更新方法. ***
	/// </summary>
	/// <param name="keyList"></param>
	public void OfflineRemove(List<ItemKey> keyList)
	{
		Tester.Assert(keyList != null);
		Tester.Assert(keyList.Count > 0);
		foreach (ItemKey key in keyList)
		{
			OfflineRemove(key, 1);
		}
	}

	/// <summary>
	/// 离线从行囊移出物品，不涉及研读书籍、鉴定状态处理。对太吾和其交互对象操作复数物品时用此方法，因为有淬毒系统
	/// *** 如果是已注册游戏数据, 修改之后一定要调用相关数据状态更新方法. ***
	/// </summary>
	/// <param name="dict"></param>
	public void OfflineRemove(Dictionary<ItemKey, int> dict)
	{
		Tester.Assert(dict != null);
		Tester.Assert(dict.Count > 0);
		foreach (var (key, count) in dict)
		{
			OfflineRemove(key, count);
		}
	}

	/// <summary>
	/// 离线从行囊移出物品，不涉及研读书籍、鉴定状态处理。对太吾和其交互对象操作复数物品时用此方法，因为有淬毒系统
	/// *** 如果是已注册游戏数据, 修改之后一定要调用相关数据状态更新方法. ***
	/// </summary>
	/// <param name="inventory"></param>
	public void OfflineRemove(Inventory inventory)
	{
		Tester.Assert(inventory != null);
		OfflineRemove(inventory.Items);
	}

	/// <summary>
	/// 查询行囊道具数量
	/// </summary>
	/// <param name="itemKey"></param>
	/// <returns></returns>
	public int GetInventoryItemCount(ItemKey itemKey)
	{
		Items.TryGetValue(itemKey, out var count);
		return count;
	}

	/// <summary>
	/// 查询行囊道具数量
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="itemTemplateId"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 查询某类型行囊道具数量
	/// </summary>
	/// <param name="itemType"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取行囊中指定类型道具索引
	/// </summary>
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

	/// <summary>
	/// 获取行囊中指定类型道具索引
	/// </summary>
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

	/// <summary>
	/// 获取行囊中指定类型道具索引
	/// </summary>
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

	/// <summary>
	/// 获取行囊中指定类型的全部道具索引
	/// </summary>
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

	/// <summary>
	/// 行囊中是否有指定分组的道具
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="groupId"></param>
	/// <param name="minGrade"></param>
	/// <param name="maxGrade"></param>
	/// <param name="resultList"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 行囊中是否有同组道具
	/// 优先获取更高级的道具.
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <param name="minGradeOffset"></param>
	/// <param name="resultList"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取行囊中指定分组的道具
	/// 优先获取更高级的道具.
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="groupId"></param>
	/// <param name="minGrade"></param>
	/// <param name="maxGrade"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取行囊中与指定道具同分组的道具
	/// 优先获取更高级的道具.
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <param name="minGradeOffset"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 是否有指定类型药物
	/// </summary>
	/// <param name="effectType"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 是否包含恢复主要属性的道具
	/// </summary>
	/// <param name="attributeType"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 是否包含指定类型的道具
	/// </summary>
	/// <param name="itemType"><see cref="T:GameData.Domains.Item.ItemType" /></param>
	/// <returns></returns>
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

	/// <summary>
	/// 是否包含指定子类型的道具
	/// </summary>
	/// <param name="itemSubType"><see cref="T:GameData.Domains.Item.ItemSubType" /></param>
	/// <returns></returns>
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

	/// <summary>
	/// 是否包含指定道具
	/// </summary>
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
