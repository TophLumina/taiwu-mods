using System;
using System.Collections.Generic;
using System.Linq;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class ItemFunctions
{
	[EventFunction(62)]
	private static ItemKey CreateItem(EventScriptRuntime runtime, UnmanagedVariant<TemplateKey> itemTemplate)
	{
		return DomainManager.Item.CreateItem(runtime.Context, itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId);
	}

	[EventFunction(556)]
	private static ItemKey CreateCombatSkillBook(EventScriptRuntime runtime, UnmanagedVariant<TemplateKey> itemTemplate, sbyte outlinePageType, sbyte directProb, sbyte completePagesCount, sbyte lostPagesCount)
	{
		if (ItemTemplateHelper.GetItemSubType(itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId) != 1001)
		{
			throw new Exception($"Unable to create {itemTemplate.Value} as combat skill book.");
		}
		return DomainManager.Item.CreateSkillBook(runtime.Context, itemTemplate.Value.TemplateId, completePagesCount, lostPagesCount, outlinePageType, directProb);
	}

	[EventFunction(408)]
	private static void SetEquipmentEffectId(EventScriptRuntime runtime, ItemKey itemKey, short equipmentEffectId)
	{
		if (!ItemType.IsEquipmentEffectType(itemKey.ItemType))
		{
			throw new Exception($"Equipment effect is not allowed on {itemKey}.");
		}
		EquipmentBase equipment = DomainManager.Item.GetBaseEquipment(itemKey);
		if (equipmentEffectId >= 0)
		{
			if (equipmentEffectId == 54)
			{
				short durability = (short)(equipment.GetMaxDurability() * 2);
				equipment.SetMaxDurability(durability, runtime.Context);
				equipment.SetCurrDurability(durability, runtime.Context);
			}
			equipment.SetEquipmentEffectId(equipmentEffectId, runtime.Context);
		}
	}

	[EventFunction(166)]
	private static ItemKey CreateFixedSkillBook(EventScriptRuntime runtime, UnmanagedVariant<TemplateKey> itemTemplate)
	{
		sbyte outlinePageType = DomainManager.Taiwu.GetTaiwu().GetBehaviorType();
		return DomainManager.Item.CreateSkillBook(runtime.Context, itemTemplate.Value.TemplateId, 5, 0, outlinePageType, 100);
	}

	[EventFunction(63)]
	private static ItemKey CreateCricket(EventScriptRuntime runtime, short colorId, short partId)
	{
		return DomainManager.Item.CreateCricket(runtime.Context, colorId, partId);
	}

	[EventFunction(836)]
	private static ItemKey CreateCricketByGrade(EventScriptRuntime runtime, short grade)
	{
		return DomainManager.Item.CreateCricket(runtime.Context, grade);
	}

	[EventFunction(348)]
	private static ValueInfo CheckItemValid(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		return evaluator.PushEvaluationResult(parameters[0].GetAnyValue<ItemKey>(evaluator).IsValid());
	}

	[EventFunction(398)]
	private static ValueInfo CheckItemPoisoned(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ItemKey itemKey = parameters[0].GetAnyValue<ItemKey>(evaluator);
		int wanted = parameters[1].GetIntValue(evaluator);
		PoisonsAndLevels data = DomainManager.Item.GetAttachedPoisons(itemKey);
		bool res = ((wanted < 0) ? (data.GetTotalPoisonCount() > 0) : (data.GetValue(wanted) > 0));
		return evaluator.PushEvaluationResult(res);
	}

	[EventFunction(476)]
	private static ItemList GenerateSectComplementCombatSkillBookByGrade(EventScriptRuntime runtime, sbyte sectId, sbyte grade)
	{
		DataContext context = runtime.Context;
		ItemList result = new ItemList();
		short morality = Config.Organization.Instance[sectId].MainMorality;
		sbyte outlineType = GameData.Domains.Character.BehaviorType.GetBehaviorType(morality);
		foreach (CombatSkillItem combatSkill in (IEnumerable<CombatSkillItem>)Config.CombatSkill.Instance)
		{
			if (combatSkill.Grade == grade && combatSkill.SectId == sectId && combatSkill.BookId >= 0)
			{
				short bookTemplateId = combatSkill.BookId;
				ItemKey directBook = DomainManager.Item.CreateSkillBook(context, bookTemplateId, 5, -1, outlineType, 100);
				result.Add(directBook);
				ItemKey reverseBook = DomainManager.Item.CreateSkillBook(context, bookTemplateId, 5, -1, outlineType, 0);
				result.Add(reverseBook);
			}
		}
		return result;
	}

	[EventFunction(675)]
	private static ItemList GenerateMatchItem(EventScriptRuntime runtime)
	{
		return runtime.Current.CreateItemListByRegister(runtime.Context, createItem: true);
	}

	[EventFunction(477)]
	private static void SelectItemFromList(EventScriptRuntime runtime, ItemList itemKeys, string selectItemKey)
	{
		EventSelectItemData data = new EventSelectItemData();
		data.FilterList.Add(new SelectItemFilter
		{
			Key = selectItemKey,
			DisplayDataFilterId = 0,
			FilterTemplateId = -1
		});
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		itemKeys.Sort((ItemKey a, ItemKey b) => a.Id.CompareTo(b.Id));
		EventSelectItemData eventSelectItemData = data;
		if (eventSelectItemData.CanSelectItemList == null)
		{
			eventSelectItemData.CanSelectItemList = new List<ITradeableContent>();
		}
		data.CanSelectItemList.AddRange(itemKeys.Select((ItemKey x) => DomainManager.Item.GetItemDisplayData(x, taiwuCharId)));
		runtime.ArgBox.Set("SelectItemInfo", data);
	}

	[EventFunction(478)]
	private static void RemoveItemFromList(EventScriptRuntime runtime, ItemList itemKeys, ItemKey itemKey)
	{
		itemKeys.Remove(itemKey);
	}

	[EventFunction(479)]
	private static void AddItemToList(EventScriptRuntime runtime, ItemList itemKeys, ItemKey itemKey)
	{
		itemKeys.Add(itemKey);
	}

	[EventFunction(676)]
	private static void AddItemListToList(EventScriptRuntime runtime, ItemList itemKeys1, ItemList itemKeys2)
	{
		itemKeys1.AddRange(itemKeys2);
	}

	[EventFunction(480)]
	private static void DeleteAllItemFromList(EventScriptRuntime runtime, ItemList itemKeys)
	{
		foreach (ItemKey itemKey in itemKeys)
		{
			DomainManager.Item.RemoveItem(runtime.Context, itemKey);
		}
	}

	[EventFunction(537)]
	private static int GetItemGrade(EventScriptRuntime runtime, ItemKey itemKey)
	{
		return ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
	}

	[EventFunction(599)]
	private static UnmanagedVariant<TemplateKey> GetSectCombatSkillBookByGrade(EventScriptRuntime runtime, Settlement settlement, sbyte grade)
	{
		List<SkillBookItem> items = new List<SkillBookItem>();
		sbyte targetOrgTemplateId = settlement.GetOrgTemplateId();
		foreach (SkillBookItem skillBook in (IEnumerable<SkillBookItem>)Config.SkillBook.Instance)
		{
			if (skillBook.ItemSubType == 1001 && skillBook.Grade == grade)
			{
				CombatSkillItem combatSkillItem = Config.CombatSkill.Instance[skillBook.CombatSkillTemplateId];
				if (combatSkillItem.SectId == targetOrgTemplateId)
				{
					items.Add(skillBook);
				}
			}
		}
		SkillBookItem result = items.GetRandom(runtime.Context.Random);
		TemplateKey templateKey = new TemplateKey(result.ItemType, result.TemplateId);
		return new UnmanagedVariant<TemplateKey>(templateKey);
	}

	[EventFunction(320)]
	private static UnmanagedVariant<TemplateKey> GetRandomItemTemplateByGrade(EventScriptRuntime runtime, short itemSubType, sbyte grade)
	{
		short templateId = ItemDomain.GetRandomItemIdInSubType(runtime.Context.Random, itemSubType, grade);
		sbyte itemType = ItemSubType.GetType(itemSubType);
		TemplateKey templateKey = new TemplateKey(itemType, templateId);
		return new UnmanagedVariant<TemplateKey>(templateKey);
	}

	[EventFunction(596)]
	private static UnmanagedVariant<TemplateKey> GetRandomItemTemplate(EventScriptRuntime runtime)
	{
		TemplateKey templateKey = runtime.Current.GetRandomTemplateKey(runtime.Context);
		return new UnmanagedVariant<TemplateKey>(templateKey);
	}

	[EventFunction(677)]
	private static int GetCharacterInventoryItemCount(EventScriptRuntime runtime, GameData.Domains.Character.Character character, UnmanagedVariant<TemplateKey> templateKey)
	{
		Inventory inventory = character.GetInventory();
		return inventory.GetInventoryItemCount(templateKey.Value.ItemType, templateKey.Value.TemplateId);
	}

	[EventFunction(736)]
	private static ItemKey GetLegendaryBookItem(EventScriptRuntime runtime, sbyte combatSkillType)
	{
		return DomainManager.LegendaryBook.GetLegendaryBookItem(combatSkillType);
	}
}
