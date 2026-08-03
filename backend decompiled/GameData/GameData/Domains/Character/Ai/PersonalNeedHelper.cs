using System.Collections.Generic;
using Config;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Character.Ai;

public static class PersonalNeedHelper
{
	public unsafe static bool CheckValid(this PersonalNeed need, Character character)
	{
		switch (need.TemplateId)
		{
		case 0:
			return character.GetHappiness() < HappinessType.Ranges[3].min;
		case 1:
			return character.GetHealth() < character.GetLeftMaxHealth();
		case 2:
			return DisorderLevelOfQi.GetDisorderLevelOfQi(character.GetDisorderOfQi()) > 0;
		case 3:
			return character.GetCurrNeili() < character.GetMaxNeili();
		case 4:
			return character.GetInjuries().HasAnyInjury(need.InjuryType == 1);
		case 5:
		{
			PoisonInts poisoned = character.GetPoisoned();
			return poisoned.Items[need.PoisonType] > 0 && !character.HasPoisonImmunity(need.PoisonType);
		}
		case 6:
		{
			MainAttributes currMainAttributes = character.GetCurrMainAttributes();
			MainAttributes maxMainAttributes = character.GetMaxMainAttributes();
			return currMainAttributes.Items[need.MainAttributeType] < maxMainAttributes.Items[need.MainAttributeType];
		}
		case 7:
			return character.GetEatingItems().IndexOfWug(need.WugType) >= 0;
		case 8:
			return character.GetResource(need.ResourceType) < need.Amount && need.Amount >= 0;
		case 9:
			return character.GetResource(need.ResourceType) > need.Amount && need.Amount >= 0;
		case 10:
		{
			sbyte itemType = need.ItemType;
			short itemTemplateId = need.ItemTemplateId;
			List<ItemKey> itemList = ObjectPool<List<ItemKey>>.Instance.Get();
			if (character.GetInventory().HasItemInSameGroup(itemType, itemTemplateId, -2, itemList) && itemList.Exists(delegate(ItemKey k)
			{
				ItemBase baseItem2 = DomainManager.Item.GetBaseItem(k);
				if (baseItem2.GetMaxDurability() <= 0)
				{
					return true;
				}
				return baseItem2.GetCurrDurability() > 0;
			}))
			{
				ObjectPool<List<ItemKey>>.Instance.Return(itemList);
				return false;
			}
			ObjectPool<List<ItemKey>>.Instance.Return(itemList);
			if (ItemTemplateHelper.GetEquipmentType(itemType, itemTemplateId) < 0)
			{
				return true;
			}
			short groupId = ItemTemplateHelper.GetGroupId(itemType, itemTemplateId);
			sbyte expectedGrade = ItemTemplateHelper.GetGrade(itemType, itemTemplateId);
			sbyte requiredMinGrade = (sbyte)(expectedGrade - -2);
			ItemKey[] equipments = character.GetEquipment();
			for (int i = 0; i < equipments.Length; i++)
			{
				ItemKey equippedKey = equipments[i];
				if (equippedKey.ItemType == itemType)
				{
					if (equippedKey.TemplateId == itemTemplateId)
					{
						return false;
					}
					if (groupId >= 0 && ItemTemplateHelper.GetGroupId(equippedKey.ItemType, equippedKey.TemplateId) == groupId && ItemTemplateHelper.GetGrade(equippedKey.ItemType, equippedKey.TemplateId) >= requiredMinGrade)
					{
						return false;
					}
				}
			}
			return true;
		}
		case 11:
		{
			ItemKey itemKey = new ItemKey(need.ItemType, 0, -1, need.ItemId);
			if (!DomainManager.Item.ItemExists(itemKey))
			{
				return false;
			}
			ItemBase baseItem = DomainManager.Item.GetBaseItem(itemKey);
			itemKey = baseItem.GetItemKey();
			return character.GetInventory().Items.ContainsKey(itemKey) && baseItem.GetCurrDurability() < baseItem.GetMaxDurability();
		}
		case 12:
			if (!Config.Organization.Instance[character.GetOrganizationInfo().OrgTemplateId].AllowPoisoning)
			{
				return false;
			}
			return true;
		case 13:
			return character.GetInventoryTotalValue() > need.Amount;
		case 14:
			return character.GetCombatSkillAttainment(need.CombatSkillType) < need.Amount;
		case 15:
			return character.GetLifeSkillAttainment(need.LifeSkillType) < need.Amount;
		case 16:
			return character.GetExp() < need.Amount;
		case 17:
		{
			if (!DomainManager.Item.TryGetElement_SkillBooks(need.ItemId, out var item))
			{
				return false;
			}
			if (!character.GetInventory().Items.ContainsKey(item.GetItemKey()))
			{
				return false;
			}
			if (item.IsCombatSkillBook())
			{
				return character.GetCombatSkillBookCurrReadingInfo(item).readingPage < 6;
			}
			return character.GetLifeSkillBookCurrReadingInfo(item).readingPage < 5;
		}
		case 18:
		{
			GameData.Domains.CombatSkill.CombatSkill combatSkill;
			return DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(character.GetId(), need.CombatSkillTemplateId), out combatSkill) && !CombatSkillStateHelper.IsBrokenOut(combatSkill.GetActivationState()) && combatSkill.CanBreakout();
		}
		case 19:
			return DomainManager.Character.IsCharacterAlive(need.CharId);
		case 20:
			return DomainManager.Character.IsCharacterAlive(need.CharId) && !DomainManager.Character.IsInTheSameGroup(character.GetId(), need.CharId);
		case 21:
			return DomainManager.Character.HasRelation(character.GetId(), need.CharId, 32768);
		case 22:
		{
			Grave element;
			return DomainManager.Character.TryGetElement_Graves(need.CharId, out element);
		}
		case 23:
			return DomainManager.Character.IsCharacterAlive(need.CharId);
		default:
			return true;
		}
	}
}
