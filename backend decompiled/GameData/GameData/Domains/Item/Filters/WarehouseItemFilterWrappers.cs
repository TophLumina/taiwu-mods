using System.Collections.Generic;

namespace GameData.Domains.Item.Filters;

public static class WarehouseItemFilterWrappers
{
	public static void FindByTemplateId(sbyte itemType, short templateId, List<(ItemKey itemKey, int amount)> items)
	{
		DomainManager.Taiwu.FindWarehouseItems((ItemBase item) => ItemMatchers.MatchTemplateId(item, itemType, templateId), items);
	}

	public static void FindByTemplateGroupId(sbyte itemType, short startTemplateId, int count, List<(ItemKey itemKey, int amount)> items)
	{
		DomainManager.Taiwu.FindWarehouseItems((ItemBase item) => ItemMatchers.MatchTemplateIdGroup(item, itemType, startTemplateId, count), items);
	}

	public static void FindByItemSubType(sbyte itemSubType, List<(ItemKey itemKey, int amount)> items)
	{
		DomainManager.Taiwu.FindWarehouseItems((ItemBase item) => ItemMatchers.MatchItemSubType(item, itemSubType), items);
	}
}
