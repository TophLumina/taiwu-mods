using System.Collections.Generic;
using Config;
using GameData.Domains.Character;

namespace GameData.Domains.Item.Filters;

public static class CharacterItemFilterWrappers
{
	public static void FindByTemplateId(GameData.Domains.Character.Character character, sbyte itemType, short templateId, List<(ItemKey itemKey, int amount)> items, bool searchInventory, bool searchEquipment)
	{
		character.FindItems((ItemBase item) => ItemMatchers.MatchTemplateId(item, itemType, templateId), items, searchInventory, searchEquipment);
	}

	public static void FindByTemplateIdGroup(GameData.Domains.Character.Character character, sbyte itemType, short startTemplateId, int count, List<(ItemKey itemKey, int amount)> items, bool searchInventory, bool searchEquipment)
	{
		character.FindItems((ItemBase item) => ItemMatchers.MatchTemplateIdGroup(item, itemType, startTemplateId, count), items, searchInventory, searchEquipment);
	}

	public static void FindByItemSubType(GameData.Domains.Character.Character character, short itemSubType, List<(ItemKey itemKey, int amount)> items, bool searchInventory, bool searchEquipment)
	{
		character.FindItems((ItemBase item) => ItemMatchers.MatchItemSubType(item, itemSubType), items, searchInventory, searchEquipment);
	}

	public static void FindByItemType(GameData.Domains.Character.Character character, sbyte itemType, List<(ItemKey itemKey, int amount)> items, bool searchInventory, bool searchEquipment)
	{
		character.FindItems((ItemBase item) => ItemMatchers.MatchItemType(item, itemType), items, searchInventory, searchEquipment);
	}

	public static void FindEquipment(GameData.Domains.Character.Character character, List<(ItemKey itemKey, int amount)> items, bool searchInventory, bool searchEquipment)
	{
		character.FindItems(ItemMatchers.MatchEquipment, items, searchInventory, searchEquipment);
	}

	public static void FindByItemFilterRule(GameData.Domains.Character.Character character, short filterRuleTemplateId, List<(ItemKey itemKey, int amount)> items, bool searchInventory, bool searchEquipment)
	{
		ItemFilterRulesItem config = ItemFilterRules.Instance[filterRuleTemplateId];
		character.FindItems((ItemBase item) => ItemMatchers.MatchItemFilterRule(item, config), items, searchInventory, searchEquipment);
	}
}
