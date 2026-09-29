using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Utilities;

namespace GameData.ActionPlanning.ActionImpl.Helper;

public class ActionHelper
{
	public static bool CanInteractTreasury(Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		Location location = character.GetLocation();
		if (orgInfo.SettlementId < 0)
		{
			return false;
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(orgInfo.SettlementId);
		if (!settlement.HasTreasury())
		{
			return false;
		}
		Location settlementLocation = settlement.GetLocation();
		if (settlementLocation.AreaId != location.AreaId)
		{
			return false;
		}
		if (DomainManager.Map.GetBlock(location).GetRootBlock().GetLocation() != settlementLocation)
		{
			return false;
		}
		return true;
	}

	public static ItemKey SelectTreasuryItemReward(DataContext context, Character character)
	{
		SettlementTreasury treasury = DomainManager.Organization.GetTreasury(character.GetOrganizationInfo());
		sbyte targetGrade = character.GetInteractionGrade();
		List<ItemKey> items = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		foreach (var (itemKey2, _) in treasury.Inventory.Items)
		{
			if (ItemTemplateHelper.GetGrade(itemKey2.ItemType, itemKey2.TemplateId) <= targetGrade && ItemTemplateHelper.IsTransferable(itemKey2.ItemType, itemKey2.TemplateId))
			{
				items.Add(itemKey2);
			}
		}
		ItemKey randomOrDefault = items.GetRandomOrDefault(context.Random, ItemKey.Invalid);
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref items);
		return randomOrDefault;
	}

	public static int GetTargetGraveId(DataContext context, Character character, Predicate<Grave> graveFilter, sbyte restrictActionType)
	{
		Location location = character.GetLocation();
		if (!location.IsValid())
		{
			return -1;
		}
		HashSet<int> currBlockGraves = DomainManager.Map.GetBlock(location).GraveSet;
		if (currBlockGraves == null)
		{
			return -1;
		}
		int charId = character.GetId();
		sbyte selfBehaviorType = character.GetBehaviorType();
		short rateAdjust = DomainManager.Character.GetAiActionRateAdjust(charId, restrictActionType, 4);
		List<int> targets = context.AdvanceMonthRelatedData.TargetCharIdList.Occupy();
		targets.Clear();
		foreach (int graveId in currBlockGraves)
		{
			Grave grave = DomainManager.Character.GetElement_Graves(graveId);
			if (DomainManager.Character.TryGetRelation(charId, graveId, out var selfToTarget) && graveFilter(grave) && !DomainManager.Character.IsGraveProtected(grave))
			{
				sbyte category = AiHelper.ActionTargetRelationCategory.GetTargetRelationCategory(selfToTarget.RelationType);
				if (context.Random.CheckPercentProb(AiHelper.GeneralActionConstants.StartRobbingFromGraveChance[selfBehaviorType][category] + rateAdjust))
				{
					targets.Add(graveId);
				}
			}
		}
		int randomOrDefault = targets.GetRandomOrDefault(context.Random, -1);
		context.AdvanceMonthRelatedData.TargetCharIdList.Release(ref targets);
		return randomOrDefault;
	}

	public static bool HasIncreaseInventoryLoadItem(Character character, Inventory inventory)
	{
		foreach (var (itemKey2, _) in inventory.Items)
		{
			switch (itemKey2.ItemType)
			{
			case 4:
			{
				Carrier item2 = DomainManager.Item.GetElement_Carriers(itemKey2.Id);
				if (!item2.IsDurabilityRunningOut())
				{
					sbyte equipmentType2 = item2.GetEquipmentType();
					short worstValue2 = character.GetWorstInventoryLoadBonusInEquipment(equipmentType2);
					if (item2.GetEquipmentCombatPowerValueFactor() > worstValue2)
					{
						return true;
					}
				}
				break;
			}
			case 2:
			{
				Accessory item = DomainManager.Item.GetElement_Accessories(itemKey2.Id);
				if (!item.IsDurabilityRunningOut())
				{
					sbyte equipmentType = item.GetEquipmentType();
					short worstValue = character.GetWorstInventoryLoadBonusInEquipment(equipmentType);
					if (item.GetEquipmentCombatPowerValueFactor() > worstValue)
					{
						return true;
					}
				}
				break;
			}
			}
		}
		return false;
	}

	public static ItemKey SelectIncreaseInventoryLoadItem(Character character, Inventory inventory)
	{
		ItemKey selectedItemKey = ItemKey.Invalid;
		int bestScore = int.MinValue;
		foreach (var (itemKey2, _) in inventory.Items)
		{
			switch (itemKey2.ItemType)
			{
			case 4:
			{
				Carrier item2 = DomainManager.Item.GetElement_Carriers(itemKey2.Id);
				if (item2.IsDurabilityRunningOut())
				{
					break;
				}
				sbyte equipmentType2 = item2.GetEquipmentType();
				short worstValue2 = character.GetWorstInventoryLoadBonusInEquipment(equipmentType2);
				if (item2.GetEquipmentCombatPowerValueFactor() > worstValue2)
				{
					int score2 = Equipping.CalcEquipmentScore(itemKey2, -1).score;
					if (score2 > bestScore)
					{
						bestScore = score2;
						selectedItemKey = itemKey2;
					}
				}
				break;
			}
			case 2:
			{
				Accessory item = DomainManager.Item.GetElement_Accessories(itemKey2.Id);
				if (item.IsDurabilityRunningOut())
				{
					break;
				}
				sbyte equipmentType = item.GetEquipmentType();
				short worstValue = character.GetWorstInventoryLoadBonusInEquipment(equipmentType);
				if (item.GetEquipmentCombatPowerValueFactor() > worstValue)
				{
					int score = Equipping.CalcEquipmentScore(itemKey2, -1).score;
					if (score > bestScore)
					{
						bestScore = score;
						selectedItemKey = itemKey2;
					}
				}
				break;
			}
			}
		}
		return selectedItemKey;
	}
}
