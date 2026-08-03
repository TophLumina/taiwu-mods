using System;
using System.Collections.Generic;
using Config;
using Config.ConfigCells;

namespace GameData.Domains.Item.Filters;

public static class ItemMatchers
{
	public static bool MatchAll(ItemBase item, List<Predicate<ItemBase>> predicates)
	{
		int i = 0;
		for (int count = predicates.Count; i < count; i++)
		{
			if (!predicates[i](item))
			{
				return false;
			}
		}
		return true;
	}

	public static bool MatchItemType(ItemBase item, sbyte itemType)
	{
		return item.GetItemType() == itemType;
	}

	public static bool MatchEquipment(ItemBase item)
	{
		return ItemType.IsEquipmentItemType(item.GetItemType());
	}

	public static bool MatchTemplateId(ItemBase item, sbyte itemType, short templateId)
	{
		return item.GetItemType() == itemType && item.GetTemplateId() == templateId;
	}

	public static bool MatchTemplateIdGroup(ItemBase item, sbyte itemType, short startTemplateId, int count)
	{
		if (item.GetItemType() != itemType)
		{
			return false;
		}
		short templateId = item.GetTemplateId();
		return templateId >= startTemplateId && templateId < startTemplateId + count;
	}

	public static bool MatchItemSubType(ItemBase item, short itemSubType)
	{
		return item.GetItemSubType() == itemSubType;
	}

	public static bool MatchItemFilterRule(ItemBase itemBase, ItemFilterRulesItem rule)
	{
		if (rule.AppointId.TemplateId != -1)
		{
			return itemBase.GetItemType() == rule.AppointId.ItemType && itemBase.GetTemplateId() == rule.AppointId.TemplateId;
		}
		List<PresetItemSubTypeWithGradeRange> appointOrSubTypeCore = rule.AppointOrSubTypeCore;
		if (appointOrSubTypeCore != null && appointOrSubTypeCore.Count > 0)
		{
			sbyte grade = itemBase.GetGrade();
			foreach (PresetItemSubTypeWithGradeRange itemSubTypeWithGrade in rule.AppointOrSubTypeCore)
			{
				if (itemBase.GetItemSubType() == itemSubTypeWithGrade.SubType && grade >= itemSubTypeWithGrade.GradeMin && grade <= itemSubTypeWithGrade.GradeMax)
				{
					return true;
				}
			}
		}
		List<PresetItemTemplateIdGroup> appointOrIdCore = rule.AppointOrIdCore;
		if (appointOrIdCore != null && appointOrIdCore.Count > 0)
		{
			foreach (PresetItemTemplateIdGroup coreCell in rule.AppointOrIdCore)
			{
				if (MatchTemplateIdGroup(itemBase, coreCell.ItemType, coreCell.StartId, coreCell.GroupLength))
				{
					return true;
				}
			}
		}
		return false;
	}
}
