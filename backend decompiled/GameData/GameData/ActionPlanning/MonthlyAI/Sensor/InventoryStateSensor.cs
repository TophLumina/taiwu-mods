using GameData.Domains.Character;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class InventoryStateSensor : CharacterStateSensorBase
{
	public override int Sense(ContextArgGroupHandle args, Character selfChar, StateKey stateKey)
	{
		Inventory inventory = selfChar.GetInventory();
		int stateTemplateId = stateKey.StateTemplateId;
		if (1 == 0)
		{
		}
		int result = stateTemplateId switch
		{
			40 => selfChar.GetOrganizationInfo().GetOrgMemberConfig().ItemSatisfyingThreshold, 
			416 => inventory.ContainsMedicine(EMedicineEffectType.ApplyPoison).ToInt(), 
			418 => inventory.ContainsMedicine(EMedicineEffectType.DetoxPoison).ToInt(), 
			422 => inventory.ContainsMedicine(EMedicineEffectType.RecoverHealth).ToInt(), 
			417 => inventory.ContainsMedicine(EMedicineEffectType.ChangeDisorderOfQi).ToInt(), 
			415 => (inventory.ContainsMedicine(EMedicineEffectType.RecoverOuterInjury) || inventory.ContainsMedicine(EMedicineEffectType.RecoverInnerInjury)).ToInt(), 
			420 => inventory.HasItemInGroup(12, 9, 0, 8).ToInt(), 
			421 => (args.MainAttributeType >= 0) ? inventory.ContainsMainAttributeRegenItem(args.MainAttributeType).ToInt() : int.MinValue, 
			423 => inventory.ContainsMedicine(EMedicineEffectType.DetoxWug).ToInt(), 
			409 => inventory.ContainsItemType(6).ToInt(), 
			419 => inventory.HasItemInGroup(7, 0, 0, 8).ToInt(), 
			410 => inventory.ContainsItemSubType(1205).ToInt(), 
			411 => inventory.GetInventoryItemKey(12, 265).IsValid().ToInt(), 
			412 => inventory.ContainsItemSubType(402).ToInt(), 
			424 => inventory.ContainsItemSubType(901).ToInt(), 
			425 => inventory.ContainsItemSubType(900).ToInt(), 
			413 => inventory.ContainsItemSubType(1001).ToInt(), 
			414 => inventory.ContainsItemSubType(1000).ToInt(), 
			393 => inventory.GetInventoryItemCount(args.ItemType, args.ItemTemplateId), 
			391 => (inventory.GetInventoryItemKey(args.ItemType, args.ItemTemplateId).IsValid() || selfChar.HasEquippedItem(args.ItemType, args.ItemTemplateId)).ToInt(), 
			113 => inventory.GetTotalValueByItemSubType(800), 
			114 => inventory.GetTotalValueByItemSubType(801), 
			112 => inventory.GetTotalValue(), 
			109 => selfChar.GetCurrInventoryLoad(), 
			111 => selfChar.GetMaxInventoryLoad(), 
			108 => selfChar.GetCurrEquipmentLoad(), 
			110 => selfChar.GetMaxEquipmentLoad(), 
			614 => selfChar.HasSpareableItem(allowUsed: true).ToInt(), 
			_ => throw new ActionPlanningException($"Unimplemented planning state: {stateKey}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
