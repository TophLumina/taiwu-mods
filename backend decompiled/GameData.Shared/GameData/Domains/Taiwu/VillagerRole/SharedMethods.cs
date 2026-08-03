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

	/// <summary>
	/// 文人学习成功率加成
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateLiteratiLearnRequestSuccessChanceBonus(Personalities personalities)
	{
		return personalities[1];
	}

	/// <summary>
	/// 文人二次请教概率
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateLiteratiLearnActionRepeatChance(Personalities personalities)
	{
		return personalities[2] / 2;
	}

	/// <summary>
	/// 文人娱乐心情变化公式
	/// </summary>
	/// <param name="personalities"></param>
	/// <param name="lifeSkillShorts"></param>
	/// <returns></returns>
	public static int CalculateLiteratiEntertainHappinessChange(Personalities personalities, LifeSkillShorts lifeSkillShorts)
	{
		return 2 + lifeSkillShorts.GetSum() / 100 * personalities[1] / 3 / 100;
	}

	/// <summary>
	/// 文人联络人数
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateLiteratiContactCharacterAmount(Personalities personalities)
	{
		return personalities[2] / 10 + 1;
	}

	/// <summary>
	/// 文人娱乐目标数量
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateLiteratiEntertainTargetAmount(Personalities personalities)
	{
		return personalities[2] / 10 + 1;
	}

	/// <summary>
	/// 文人联络感情好感变化公式
	/// </summary>
	/// <param name="personalities"></param>
	/// <param name="lifeSkillShorts"></param>
	/// <returns></returns>
	public static int CalculateLiteratiContactFavorabilityChange(Personalities personalities, LifeSkillShorts lifeSkillShorts)
	{
		return 500 + lifeSkillShorts.GetSum() * personalities[1] / 3 / 100;
	}

	/// <summary>
	/// 文人影响文化变化
	/// </summary>
	/// <param name="personalities"></param>
	/// <param name="lifeSkillShorts"></param>
	/// <returns></returns>
	public static int CalculateLiteratiInfluenceSettlementValueChange(Personalities personalities, LifeSkillShorts lifeSkillShorts)
	{
		return 2 + lifeSkillShorts.GetSum() / 100 * personalities[1] / 3 / 100;
	}

	/// <summary>
	/// 文人获取秘闻概率
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateLiteratiSecretInformationGainChance(Personalities personalities)
	{
		return personalities[1] / 2;
	}

	/// <summary>
	/// 护冢联络感情好感变化公式
	/// </summary>
	/// <param name="personalities"></param>
	/// <param name="combatSkillShorts"></param>
	/// <returns></returns>
	public static int CalculateSwordTombKeeperContactFavorabilityChange(Personalities personalities, CombatSkillShorts combatSkillShorts)
	{
		return 500 + combatSkillShorts.GetSum() * personalities[3] / 3 / 100;
	}

	/// <summary>
	/// 护冢见闻收集概率
	/// </summary>
	/// <param name="personalities"></param>
	/// <param name="combatSkillShorts"></param>
	/// <returns></returns>
	public static int CalculateSwordTombKeeperCollectInformationChance(Personalities personalities, CombatSkillShorts combatSkillShorts)
	{
		return 5 + combatSkillShorts.GetSum() / 100 * personalities[3] / 100;
	}

	/// <summary>
	/// 护冢受伤概率
	/// </summary>
	/// <param name="personalities"></param>
	/// <param name="combatSkillShorts"></param>
	/// <returns></returns>
	public static int CalculateSwordTombKeeperInjuredByXiangshuAvatarChance(Personalities personalities, CombatSkillShorts combatSkillShorts)
	{
		return 100 - combatSkillShorts.GetSum() / 100 * personalities[4] / 100;
	}

	/// <summary>
	/// 护冢联络人数
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateSwordTombKeeperContactCharacterAmount(Personalities personalities)
	{
		return personalities[4] / 10 + 1;
	}

	/// <summary>
	/// 护冢二次请教概率
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateSwordTombKeeperLearnActionRepeatChance(Personalities personalities)
	{
		return personalities[4] / 2;
	}

	/// <summary>
	/// 护冢学习成功率加成
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateSwordTombKeeperLearnRequestSuccessChanceBonus(Personalities personalities)
	{
		return personalities[3];
	}

	/// <summary>
	/// 护冢影响安定变化
	/// </summary>
	/// <param name="personalities"></param>
	/// <param name="combatSkillShorts"></param>
	/// <returns></returns>
	public static int CalculateSwordTombKeeperInfluenceSettlementValueChange(Personalities personalities, CombatSkillShorts combatSkillShorts)
	{
		return 2 + combatSkillShorts.GetSum() / 100 * personalities[3] / 3 / 100;
	}

	/// <summary>
	/// 商人二次叫卖概率
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateMerchantSellActionRepeatChance(Personalities personalities)
	{
		return personalities[2] / 2;
	}

	/// <summary>
	/// 商人售出价格比例
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateMerchantSellPricePercent(Personalities personalities)
	{
		return 50 + personalities[0];
	}

	/// <summary>
	/// 商人额外收购概率
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateMerchantBuyActionRepeatChance(Personalities personalities)
	{
		return personalities[2] / 2;
	}

	/// <summary>
	/// 商人购入价格比例
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateMerchantBuyPricePercent(Personalities personalities)
	{
		return 200 - personalities[0];
	}

	/// <summary>
	/// 商人抬价每月提高百分比
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateMerchantPriceGougingPercentPerMonth(Personalities personalities)
	{
		return 5 + personalities[2] / 20;
	}

	/// <summary>
	/// 商人抬价百分比上限
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateMerchantPriceGougingPercentCap(Personalities personalities)
	{
		return 120 + personalities[0] / 5;
	}

	/// <summary>
	/// 商人砍价每月降低百分比
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateMerchantPriceSuppressionPercentPerMonth(Personalities personalities)
	{
		return 5 + personalities[2] / 20;
	}

	/// <summary>
	/// 商人砍价百分比下限
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateMerchantPriceSuppressionPercentCap(Personalities personalities)
	{
		return 80 - personalities[0] / 5;
	}

	/// <summary>
	/// 商人商会好感
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	public static int CalculateMerchantUpgradedActionFavorChange(Personalities personalities)
	{
		return personalities[2] * 10;
	}

	/// <summary>
	/// 农户迁移成功率公式
	/// </summary>
	/// <param name="baseValue"></param>
	/// <param name="personalities"></param>
	/// <returns></returns>
	[Obsolete]
	public static int CalculateFarmerMigrateResourceSuccessRate(int baseValue, Personalities personalities)
	{
		return baseValue + CalculateFarmerMigrateResourceSuccessRateBonus(personalities);
	}

	/// <summary>
	/// 农户迁移成功率加成部分
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	[Obsolete]
	public static int CalculateFarmerMigrateResourceSuccessRateBonus(Personalities personalities)
	{
		return personalities[6] / 5;
	}

	/// <summary>
	/// 农户派遣采集资源量
	/// </summary>
	/// <param name="baseAmount"></param>
	/// <param name="personalities"></param>
	/// <returns></returns>
	[Obsolete]
	public static int CalculateFarmerCollectResourceAmount(int baseAmount, Personalities personalities)
	{
		return baseAmount * (100 + CalculateFarmerCollectResourceAmountBonus(personalities)) / 100;
	}

	/// <summary>
	/// 农户派遣采集资源量加成部分
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	[Obsolete]
	public static int CalculateFarmerCollectResourceAmountBonus(Personalities personalities)
	{
		return 50 + personalities[6];
	}

	/// <summary>
	/// 派遣采集获取引子概率
	/// </summary>
	/// <param name="baseAmount"></param>
	/// <param name="personalities"></param>
	/// <returns></returns>
	[Obsolete]
	public static int CalculateFarmerCollectItemChance(int baseAmount, Personalities personalities)
	{
		return baseAmount * (100 + CalculateFarmerCollectItemChangeBonus(personalities)) / 100;
	}

	/// <summary>
	/// 农户派遣采集获取引子概率加成部分
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 大夫二次行医概率
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	[Obsolete]
	public static int CalculateDoctorHealActionRepeatChance(Personalities personalities)
	{
		return personalities[0] / 2;
	}

	/// <summary>
	/// 大夫行医收入百分比
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	[Obsolete]
	public static int CalculateDoctorMoneyIncomeBonusPercentage(Personalities personalities)
	{
		return personalities[1];
	}

	/// <summary>
	/// 大夫恩义增加量
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	[Obsolete]
	public static int CalculateDoctorSpiritualDebtIncome(Personalities personalities)
	{
		return personalities[0] / 5;
	}

	/// <summary>
	/// 村长七元加成
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	[Obsolete]
	public static int CalculateVillageHeadPersonalityBonusPercent(Personalities personalities)
	{
		return personalities[5] / 5;
	}

	/// <summary>
	/// 村长造诣加成
	/// </summary>
	/// <param name="personalities"></param>
	/// <returns></returns>
	[Obsolete]
	public static int CalculateVillageHeadAttainmentBonusPercent(Personalities personalities)
	{
		return personalities[6] / 5;
	}

	/// <summary>
	/// 检查库房是否能存储该物品
	/// </summary>
	/// <param name="sourceType">要存入的位置</param>
	/// <param name="itemData">要存入的物品</param>
	/// <param name="taiwuAge"></param>
	/// <returns></returns>
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

	/// <summary>
	///
	/// </summary>
	/// <param name="villagerCount">当前在册和遗失走漏人数之和</param>
	/// <param name="roleTemplateId"></param>
	/// <returns></returns>
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
