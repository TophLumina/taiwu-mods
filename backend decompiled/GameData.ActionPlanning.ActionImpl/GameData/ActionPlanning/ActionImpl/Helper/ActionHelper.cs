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

	public static ItemKey SelectSpareableItem(DataContext context, Character character, sbyte targetGrade, bool allowUsed)
	{
		int currBestGrade = 9;
		IReadOnlyDictionary<ItemKey, int> taiwuGiftItems = DomainManager.Extra.GetTaiwuGiftItems(character.GetId());
		List<(ItemBase, int)> selectableItems = context.AdvanceMonthRelatedData.ItemsWithAmount.Occupy();
		int villagerIdealClothing = ((character.GetOrganizationInfo().OrgTemplateId == 16) ? character.GetIdealClothingTemplateId() : (-1));
		int keepClothingCount = ((villagerIdealClothing >= 0 && character.GetEquipment().Exist((ItemKey e) => e.IsValid() && e.ItemType == 3 && e.TemplateId == villagerIdealClothing)) ? 1 : 0);
		foreach (var (itemKey2, amount) in character.GetInventory().Items)
		{
			if (!ItemTemplateHelper.IsTransferable(itemKey2.ItemType, itemKey2.TemplateId) || ItemTemplateHelper.GetBaseValue(itemKey2.ItemType, itemKey2.TemplateId) <= 0 || (taiwuGiftItems.TryGetValue(itemKey2, out var giftAmount) && giftAmount >= amount))
			{
				continue;
			}
			ItemBase baseItem = DomainManager.Item.GetBaseItem(itemKey2);
			if ((!allowUsed && baseItem.GetCurrDurability() < baseItem.GetMaxDurability()) || character.TryDetectAttachedPoisons(itemKey2))
			{
				continue;
			}
			if (itemKey2.ItemType == 10)
			{
				if (baseItem.GetItemSubType() == 1001)
				{
					(int, byte) readingInfo = character.GetCombatSkillBookCurrReadingInfo((SkillBook)baseItem);
					if (readingInfo.Item1 < 0 || readingInfo.Item2 < 6)
					{
						continue;
					}
				}
				else
				{
					(int, byte) readingInfo2 = character.GetLifeSkillBookCurrReadingInfo((SkillBook)baseItem);
					if (readingInfo2.Item1 < 0 || readingInfo2.Item2 < 5)
					{
						continue;
					}
				}
			}
			else if (itemKey2.ItemType == 3 && keepClothingCount > 0)
			{
				keepClothingCount--;
				continue;
			}
			if (itemKey2.ItemType == 12 && itemKey2.TemplateId == 267)
			{
				continue;
			}
			sbyte grade = baseItem.GetGrade();
			if (grade == currBestGrade)
			{
				selectableItems.Add((baseItem, amount));
			}
			else if (currBestGrade < targetGrade)
			{
				if (grade >= currBestGrade && grade <= targetGrade)
				{
					currBestGrade = grade;
					selectableItems.Clear();
					selectableItems.Add((baseItem, amount));
				}
			}
			else if (currBestGrade > targetGrade && grade < currBestGrade)
			{
				currBestGrade = grade;
				selectableItems.Clear();
				selectableItems.Add((baseItem, amount));
			}
		}
		ItemKey result = ((selectableItems.Count == 0) ? ItemKey.Invalid : selectableItems.GetRandom(context.Random).Item1.GetItemKey());
		context.AdvanceMonthRelatedData.ItemsWithAmount.Release(ref selectableItems);
		return result;
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
}
