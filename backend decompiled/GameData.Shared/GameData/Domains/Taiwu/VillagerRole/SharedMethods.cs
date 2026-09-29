using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;

namespace GameData.Domains.Taiwu.VillagerRole;

public class SharedMethods
{
	public static List<short> DevelopMapBlockTemplateIdList = new List<short> { 39, 42, 45, 54, 48, 51 };

	public static int CalculateLiteratiLearnRequestSuccessChanceBonus(Personalities personalities)
	{
		return personalities[1];
	}

	public static int CalculateLiteratiLearnActionRepeatChance(Personalities personalities)
	{
		return personalities[2] / 2;
	}

	public static int CalculateLiteratiEntertainHappinessChange(Personalities personalities, LifeSkillShorts lifeSkillShorts)
	{
		return 2 + lifeSkillShorts.GetSum() / 100 * personalities[1] / 3 / 100;
	}

	public static int CalculateLiteratiContactCharacterAmount(Personalities personalities)
	{
		return personalities[2] / 10 + 1;
	}

	public static int CalculateLiteratiEntertainTargetAmount(Personalities personalities)
	{
		return personalities[2] / 10 + 1;
	}

	public static int CalculateLiteratiContactFavorabilityChange(Personalities personalities, LifeSkillShorts lifeSkillShorts)
	{
		return 500 + lifeSkillShorts.GetSum() * personalities[1] / 3 / 100;
	}

	public static int CalculateLiteratiInfluenceSettlementValueChange(Personalities personalities, LifeSkillShorts lifeSkillShorts)
	{
		return 2 + lifeSkillShorts.GetSum() / 100 * personalities[1] / 3 / 100;
	}

	public static int CalculateLiteratiSecretInformationGainChance(Personalities personalities)
	{
		return personalities[1] / 2;
	}

	public static int CalculateSwordTombKeeperContactFavorabilityChange(Personalities personalities, CombatSkillShorts combatSkillShorts)
	{
		return 500 + combatSkillShorts.GetSum() * personalities[3] / 3 / 100;
	}

	public static int CalculateSwordTombKeeperCollectInformationChance(Personalities personalities, CombatSkillShorts combatSkillShorts)
	{
		return 5 + combatSkillShorts.GetSum() / 100 * personalities[3] / 100;
	}

	public static int CalculateSwordTombKeeperInjuredByXiangshuAvatarChance(Personalities personalities, CombatSkillShorts combatSkillShorts)
	{
		return 100 - combatSkillShorts.GetSum() / 100 * personalities[4] / 100;
	}

	public static int CalculateSwordTombKeeperContactCharacterAmount(Personalities personalities)
	{
		return personalities[4] / 10 + 1;
	}

	public static int CalculateSwordTombKeeperLearnActionRepeatChance(Personalities personalities)
	{
		return personalities[4] / 2;
	}

	public static int CalculateSwordTombKeeperLearnRequestSuccessChanceBonus(Personalities personalities)
	{
		return personalities[3];
	}

	public static int CalculateSwordTombKeeperInfluenceSettlementValueChange(Personalities personalities, CombatSkillShorts combatSkillShorts)
	{
		return 2 + combatSkillShorts.GetSum() / 100 * personalities[3] / 3 / 100;
	}

	public static int CalculateMerchantSellActionRepeatChance(Personalities personalities)
	{
		return personalities[2] / 2;
	}

	public static int CalculateMerchantSellPricePercent(Personalities personalities)
	{
		return 50 + personalities[0];
	}

	public static int CalculateMerchantBuyActionRepeatChance(Personalities personalities)
	{
		return personalities[2] / 2;
	}

	public static int CalculateMerchantBuyPricePercent(Personalities personalities)
	{
		return 200 - personalities[0];
	}

	public static int CalculateMerchantPriceGougingPercentPerMonth(Personalities personalities)
	{
		return 5 + personalities[2] / 20;
	}

	public static int CalculateMerchantPriceGougingPercentCap(Personalities personalities)
	{
		return 120 + personalities[0] / 5;
	}

	public static int CalculateMerchantPriceSuppressionPercentPerMonth(Personalities personalities)
	{
		return 5 + personalities[2] / 20;
	}

	public static int CalculateMerchantPriceSuppressionPercentCap(Personalities personalities)
	{
		return 80 - personalities[0] / 5;
	}

	public static int CalculateMerchantUpgradedActionFavorChange(Personalities personalities)
	{
		return personalities[2] * 10;
	}

	[Obsolete]
	public static int CalculateFarmerMigrateResourceSuccessRate(int baseValue, Personalities personalities)
	{
		return baseValue + CalculateFarmerMigrateResourceSuccessRateBonus(personalities);
	}

	[Obsolete]
	public static int CalculateFarmerMigrateResourceSuccessRateBonus(Personalities personalities)
	{
		return personalities[6] / 5;
	}

	[Obsolete]
	public static int CalculateFarmerCollectResourceAmount(int baseAmount, Personalities personalities)
	{
		return baseAmount * (100 + CalculateFarmerCollectResourceAmountBonus(personalities)) / 100;
	}

	[Obsolete]
	public static int CalculateFarmerCollectResourceAmountBonus(Personalities personalities)
	{
		return 50 + personalities[6];
	}

	[Obsolete]
	public static int CalculateFarmerCollectItemChance(int baseAmount, Personalities personalities)
	{
		return baseAmount * (100 + CalculateFarmerCollectItemChangeBonus(personalities)) / 100;
	}

	[Obsolete]
	public static int CalculateFarmerCollectItemChangeBonus(Personalities personalities)
	{
		return personalities[5];
	}

	public static bool IsMapBlockCanDevelop(short mapBlockTemplateId)
	{
		MapBlockItem config = MapBlock.Instance[mapBlockTemplateId];
		EMapBlockType type = config.Type;
		if ((uint)(type - 5) <= 1u)
		{
			return config.Size <= 1;
		}
		return false;
	}

	public static int GetDevelopNeedResource(Personalities personalities)
	{
		sbyte resourceType = 0;
		MapBlockItem config = MapBlock.Instance[DevelopMapBlockTemplateIdList[resourceType]];
		return 20000 - config.Resources[resourceType] * (50 + personalities[6] / 4 + personalities[5] / 4);
	}

	[Obsolete]
	public static int CalculateDoctorHealActionRepeatChance(Personalities personalities)
	{
		return personalities[0] / 2;
	}

	[Obsolete]
	public static int CalculateDoctorMoneyIncomeBonusPercentage(Personalities personalities)
	{
		return personalities[1];
	}

	[Obsolete]
	public static int CalculateDoctorSpiritualDebtIncome(Personalities personalities)
	{
		return personalities[0] / 5;
	}

	[Obsolete]
	public static int CalculateVillageHeadPersonalityBonusPercent(Personalities personalities)
	{
		return personalities[5] / 5;
	}

	[Obsolete]
	public static int CalculateVillageHeadAttainmentBonusPercent(Personalities personalities)
	{
		return personalities[6] / 5;
	}

	public static bool CheckCanStoreItem(ItemSourceType sourceType, ItemDisplayData itemData, int taiwuAge = -1)
	{
		bool isResource = ItemTemplateHelper.IsMiscResource(itemData.Key.ItemType, itemData.Key.TemplateId);
		if (ItemTemplateHelper.GetMiscResourceType(itemData.Key.ItemType, itemData.Key.TemplateId) == 7)
		{
			return false;
		}
		bool isTransferable = ItemTemplateHelper.IsTransferable(itemData.Key.ItemType, itemData.Key.TemplateId);
		bool isDeadCricket = itemData.Key.ItemType == 11 && itemData.Durability == 0;
		bool isChildCloth = taiwuAge >= 0 && taiwuAge < 16 && itemData.UsingType == ItemDisplayData.ItemUsingType.Equiped && ItemTemplateHelper.GetEquipmentType(itemData.Key.ItemType, itemData.Key.TemplateId) == 2;
		bool isWuying = itemData.Key.ItemType == 12 && itemData.Key.TemplateId == 267;
		switch (sourceType)
		{
		case ItemSourceType.Inventory:
			return true;
		case ItemSourceType.Warehouse:
			if (isTransferable && !isResource && !isChildCloth)
			{
				return !isWuying;
			}
			return false;
		case ItemSourceType.Treasury:
			if ((isTransferable || isResource) && !isChildCloth)
			{
				return !isWuying;
			}
			return false;
		case ItemSourceType.Trough:
			return GameData.Domains.Building.SharedMethods.CheckItemCanFeedChicken(itemData.Key);
		case ItemSourceType.Stock:
			if (isTransferable && !isResource && !isDeadCricket && !isChildCloth)
			{
				return !isWuying;
			}
			return false;
		default:
			throw new ArgumentOutOfRangeException("sourceType", sourceType, null);
		}
	}

	public static sbyte GetItemResourceType(ItemDisplayData itemData)
	{
		if (!itemData.IsResource)
		{
			return ItemTemplateHelper.GetResourceType(itemData.Key.ItemType, itemData.Key.TemplateId);
		}
		return ItemTemplateHelper.GetMiscResourceType(itemData.Key.ItemType, itemData.Key.TemplateId);
	}

	private static bool CheckCraftStorageItemResourceType(ItemDisplayData itemData)
	{
		sbyte itemResourceType = GetItemResourceType(itemData);
		if ((uint)(itemResourceType - 1) <= 3u)
		{
			return true;
		}
		return false;
	}

	private static bool CheckMedicineStorageItemResourceType(ItemDisplayData itemData)
	{
		return GetItemResourceType(itemData) == 5;
	}

	private static bool CheckFoodStorageItemResourceType(ItemDisplayData itemData)
	{
		return GetItemResourceType(itemData) == 0;
	}

	public static int CalcSetVillagerRoleAuthorityCost(int villagerCount, short roleTemplateId)
	{
		VillagerRoleItem config = Config.VillagerRole.Instance[roleTemplateId];
		return villagerCount switch
		{
			0 => 0, 
			1 => config.AuthorityCostParam / 2, 
			_ => (villagerCount - 1) * config.AuthorityCostParam, 
		};
	}
}
