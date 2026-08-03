using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.TaiwuEvent.EventHelper;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class BuildingFunctions
{
	[EventFunction(368)]
	private static bool RemoveItemPoison(EventScriptRuntime runtime, GameData.Domains.Character.Character character, ItemKey targetItemKey, ItemKey medicineItemKey)
	{
		return DomainManager.Building.RemoveItemPoison(runtime.Context, character, targetItemKey, medicineItemKey);
	}

	[EventFunction(401)]
	private static ItemKey AddItemPoison(EventScriptRuntime runtime, ItemKey targetItemKey, ItemKey medicineItemKey)
	{
		ItemBase itemBase = DomainManager.Item.GetBaseItem(targetItemKey);
		ItemBase newItemBase = DomainManager.Item.SetAttachedPoisons(runtime.Context, itemBase, medicineItemKey.TemplateId, add: true).item;
		return newItemBase.GetItemKey();
	}

	[EventFunction(628)]
	private static void CreateChickenKingToTaiwuVillage(EventScriptRuntime runtime)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateChickenCoopAtTaiwuVillage();
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateChickenKingToTaiwuVillage();
		DomainManager.Taiwu.RecordLifeSummary(DomainManager.TaiwuEvent.MainThreadDataContext, 79);
	}
}
