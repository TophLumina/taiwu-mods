using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Domains.Organization;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character;

public static class InventoryHelper
{
	public static int GetTotalValue(this Inventory inventory)
	{
		int totalValue = 0;
		foreach (KeyValuePair<ItemKey, int> item in inventory.Items)
		{
			item.Deconstruct(out var key, out var value);
			ItemKey itemKey = key;
			int amount = value;
			int value2 = (ItemTemplateHelper.IsMiscResource(itemKey.ItemType, itemKey.TemplateId) ? GlobalConfig.ResourcesWorth[ItemTemplateHelper.GetMiscResourceType(itemKey.ItemType, itemKey.TemplateId)] : DomainManager.Item.GetValue(itemKey));
			totalValue += value2 * amount;
		}
		return totalValue;
	}

	public static int GetTotalValueByItemSubType(this Inventory inventory, short itemSubType)
	{
		int totalValue = 0;
		foreach (var (itemKey2, amount) in inventory.Items)
		{
			if (itemSubType == ItemTemplateHelper.GetItemSubType(itemKey2.ItemType, itemKey2.TemplateId))
			{
				int value = (ItemTemplateHelper.IsMiscResource(itemKey2.ItemType, itemKey2.TemplateId) ? GlobalConfig.ResourcesWorth[ItemTemplateHelper.GetMiscResourceType(itemKey2.ItemType, itemKey2.TemplateId)] : DomainManager.Item.GetValue(itemKey2));
				totalValue += value * amount;
			}
		}
		return totalValue;
	}

	public static int GetTotalContribution(this Inventory inventory, Settlement settlement)
	{
		int totalValue = 0;
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		foreach (KeyValuePair<ItemKey, int> item in inventory.Items)
		{
			item.Deconstruct(out var key, out var value);
			ItemKey itemKey = key;
			int amount = value;
			totalValue += (ItemTemplateHelper.IsMiscResource(itemKey.ItemType, itemKey.TemplateId) ? DomainManager.Organization.CalcResourceContribution(orgTemplateId, ItemTemplateHelper.GetMiscResourceType(itemKey.ItemType, itemKey.TemplateId), amount) : DomainManager.Organization.CalcItemContribution(settlement, itemKey, amount));
		}
		return totalValue;
	}

	public static int GetTotalWeight(this Inventory inventory)
	{
		int weight = 0;
		foreach (KeyValuePair<ItemKey, int> item2 in inventory.Items)
		{
			item2.Deconstruct(out var key, out var value);
			ItemKey itemKey = key;
			int amount = value;
			ItemBase item = DomainManager.Item.TryGetBaseItem(itemKey);
			if (item != null)
			{
				weight += item.GetWeight() * amount;
			}
		}
		return weight;
	}

	public static ItemKey GetBestCraftTool(this Inventory inventory, sbyte lifeSkillType, sbyte targetGrade, out short durabilityCost)
	{
		ItemKey bestTool = ItemKey.Invalid;
		int bestToolAttainmentBonus = int.MinValue;
		short minCost = short.MaxValue;
		durabilityCost = 0;
		foreach (var (itemKey2, _) in inventory.Items)
		{
			if (itemKey2.ItemType != 6)
			{
				continue;
			}
			CraftToolItem toolCfg = Config.CraftTool.Instance[itemKey2.TemplateId];
			if (toolCfg.RequiredLifeSkillTypes.Contains(lifeSkillType) && toolCfg.AttainmentBonus > bestToolAttainmentBonus)
			{
				ItemBase baseItem = DomainManager.Item.GetBaseItem(itemKey2);
				durabilityCost = toolCfg.DurabilityCost[targetGrade];
				if (baseItem.GetCurrDurability() >= durabilityCost && durabilityCost <= minCost)
				{
					bestToolAttainmentBonus = toolCfg.AttainmentBonus;
					bestTool = itemKey2;
					minCost = durabilityCost;
				}
			}
		}
		return bestTool;
	}

	public static ItemKey GetWorstUsableCraftTool(this Inventory inventory, sbyte lifeSkillType, short requiredAttainment, short targetCharAttainment, sbyte targetGrade, out short durabilityCost)
	{
		ItemKey selectedTool = ItemKey.Invalid;
		short minCost = short.MaxValue;
		durabilityCost = 0;
		foreach (ItemKey toolItemKey in inventory.Items.Keys)
		{
			if (toolItemKey.ItemType != 6)
			{
				continue;
			}
			ItemBase tool = DomainManager.Item.GetBaseItem(toolItemKey);
			if (tool.GetCurrDurability() <= 0)
			{
				continue;
			}
			CraftToolItem cfg = Config.CraftTool.Instance[toolItemKey.TemplateId];
			if (cfg.RequiredLifeSkillTypes.Contains(lifeSkillType) && targetCharAttainment + cfg.AttainmentBonus >= requiredAttainment)
			{
				short cost = cfg.DurabilityCost[targetGrade];
				if (tool.GetCurrDurability() >= cost && cost <= minCost)
				{
					selectedTool = toolItemKey;
					minCost = cost;
					durabilityCost = cost;
				}
			}
		}
		return selectedTool;
	}

	public static void GetCraftMaterials(this Inventory inventory, sbyte lifeSkillType, List<ItemKey> materials)
	{
		materials.Clear();
		foreach (var (itemKey2, _) in inventory.Items)
		{
			if (itemKey2.ItemType == 5)
			{
				MaterialItem materialCfg = Config.Material.Instance[itemKey2.TemplateId];
				if (materialCfg.RequiredLifeSkillType == lifeSkillType && materialCfg.CraftableItemTypes != null && materialCfg.CraftableItemTypes.Count > 0)
				{
					materials.Add(itemKey2);
				}
			}
		}
	}

	public static void GetRepairableItem(this Inventory inventory, List<ItemKey> itemKeys)
	{
		itemKeys.Clear();
		foreach (var (itemKey2, _) in inventory.Items)
		{
			if (ItemTemplateHelper.IsRepairable(itemKey2.ItemType, itemKey2.TemplateId))
			{
				ItemBase item = DomainManager.Item.GetBaseItem(itemKey2);
				if (item.GetCurrDurability() < item.GetMaxDurability())
				{
					itemKeys.Add(itemKey2);
				}
			}
		}
	}

	public static bool HasRepairableItem(this Inventory inventory)
	{
		foreach (var (itemKey2, _) in inventory.Items)
		{
			if (ItemTemplateHelper.IsRepairable(itemKey2.ItemType, itemKey2.TemplateId))
			{
				ItemBase item = DomainManager.Item.GetBaseItem(itemKey2);
				if (item.GetCurrDurability() < item.GetMaxDurability())
				{
					return true;
				}
			}
		}
		return false;
	}

	public static void SelectPoisonsToAdd(this Inventory inventory, IRandomSource random, short lifeSkillAttainment, sbyte grade, ItemKey itemToAttachPoisonOn, ref SpanList<ItemKey> selectedPoisons)
	{
		if (!ItemTemplateHelper.IsPoisonable(itemToAttachPoisonOn.ItemType, itemToAttachPoisonOn.TemplateId))
		{
			return;
		}
		Span<sbyte> span = stackalloc sbyte[6];
		SpanList<sbyte> exceptions = span;
		if (ModificationStateHelper.IsActive(itemToAttachPoisonOn.ModificationState, 1))
		{
			FullPoisonEffects poisonEffects = DomainManager.Item.GetPoisonEffects(itemToAttachPoisonOn);
			short poisonTemplateId = poisonEffects.GetMedicineTemplateId();
			if (!MixedPoisonType.IsMixedPoisonItem(poisonTemplateId))
			{
				MedicineItem poisonCfg = Config.Medicine.Instance[poisonTemplateId];
				exceptions.Add(poisonCfg.PoisonType);
			}
			else
			{
				sbyte mixedPoisonType = MixedPoisonType.FromMedicineTemplateId(poisonTemplateId);
				exceptions.AddRange(MixedPoisonType.ToPoisonTypes[mixedPoisonType]);
			}
		}
		Span<ItemKey> selectablePoisons = stackalloc ItemKey[6];
		Span<int> minDeviations = stackalloc int[6];
		selectablePoisons.Fill(ItemKey.Invalid);
		minDeviations.Fill(127);
		foreach (ItemKey itemKey in inventory.Items.Keys)
		{
			if (itemKey.ItemType != 8)
			{
				continue;
			}
			MedicineItem medicineCfg = Config.Medicine.Instance[itemKey.TemplateId];
			if (medicineCfg.EffectType != EMedicineEffectType.ApplyPoison)
			{
				continue;
			}
			sbyte poisonType = medicineCfg.PoisonType;
			short attainmentRequired = GlobalConfig.Instance.PoisonAttainments[medicineCfg.Grade];
			if (lifeSkillAttainment >= attainmentRequired && !exceptions.Contains(poisonType))
			{
				int diff = medicineCfg.Grade - grade;
				int currDeviation = diff * diff;
				if (currDeviation <= minDeviations[poisonType])
				{
					minDeviations[poisonType] = currDeviation;
					selectablePoisons[poisonType] = itemKey;
				}
			}
		}
		for (int i = 0; i < 6; i++)
		{
			ItemKey poisonItemKey = selectablePoisons[i];
			if (poisonItemKey.IsValid())
			{
				selectedPoisons.Add(poisonItemKey);
			}
		}
		if (selectedPoisons.Count != 0)
		{
			selectedPoisons.Shuffle(random);
			int maxCount = 3 - exceptions.Count;
			if (selectedPoisons.Count > maxCount)
			{
				selectedPoisons.RemoveRange(maxCount, 6);
			}
		}
	}
}
