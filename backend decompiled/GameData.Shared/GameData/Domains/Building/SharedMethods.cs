using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.Common;
using GameData.Combat.Math;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Map;
using GameData.Domains.Organization.Display;
using GameData.Utilities;

namespace GameData.Domains.Building;

public static class SharedMethods
{
	public const int ResourceBlockBaseValueCount = 5;

	public static short GetMaterialGradeAndAttainment(short materialTemplateId, sbyte itemType, sbyte lifeSkillType, int totalAttainment, List<short> makeItemSubtypeIdList, out sbyte grade, out short baseRequiredAttainment, int allPagesReadCookingSkillBookCount, short makeItemSubTypeId = -1, int attainmentEffect = 0, bool isPerfect = false, bool isManul = false, short manulFoodTemplateId = -1)
	{
		MaterialItem materialConfig = Material.Instance[materialTemplateId];
		grade = materialConfig.Grade;
		baseRequiredAttainment = materialConfig.RequiredAttainment;
		if (itemType == 8 && lifeSkillType == 8)
		{
			grade = GetHerbMaterialTempGrade(grade, makeItemSubtypeIdList, makeItemSubTypeId, isManul);
			baseRequiredAttainment = GlobalConfig.Instance.MakeMadicineAttainments[grade];
		}
		else if (itemType == 7)
		{
			if (manulFoodTemplateId >= 0)
			{
				FoodItem foodConfig = Food.Instance[manulFoodTemplateId];
				grade = foodConfig.Grade;
				MaterialItem manulMaterialConfig = Material.Instance.Where((MaterialItem m) => m.GroupId == materialConfig.GroupId).FirstOrDefault((MaterialItem m) => m.Grade == foodConfig.Grade);
				if (manulMaterialConfig == null)
				{
					manulMaterialConfig = (from m in Material.Instance
						where m.GroupId == materialConfig.GroupId
						orderby m.Grade descending
						select m).First();
				}
				int offset = foodConfig.Grade - manulMaterialConfig.Grade;
				baseRequiredAttainment = GetStageRequiredAttainment(offset, manulMaterialConfig.RequiredAttainment, 0);
			}
			else
			{
				sbyte originGrade = grade;
				for (int i = 0; i < allPagesReadCookingSkillBookCount; i++)
				{
					sbyte targetGrade = (sbyte)Math.Min(6, originGrade + i);
					(bool success, sbyte finalGrade, short finialTemplateId) finalGradeAndId = GetFinalGradeAndId(originGrade, targetGrade, itemType, materialTemplateId);
					sbyte finalGrade = finalGradeAndId.finalGrade;
					short finalId = finalGradeAndId.finialTemplateId;
					short foodRequire = Material.Instance[finalId].RequiredAttainment;
					if (totalAttainment < foodRequire)
					{
						break;
					}
					grade = finalGrade;
					baseRequiredAttainment = foodRequire;
				}
			}
		}
		int manualAttainment;
		int perfectAttainment;
		int buildingReduceAttainment;
		return GetMakeRequiredLifeSkillAttainment(makeItemSubTypeId, isManul, isPerfect, attainmentEffect, baseRequiredAttainment, grade, out manualAttainment, out perfectAttainment, out buildingReduceAttainment);
	}

	public static void GetStageRequirementAndGrade(int i, sbyte startGrade, sbyte itemType, int requirement, short subTypeExtraLifeSkill, out sbyte targetGrade, out int targetRequirement)
	{
		requirement -= subTypeExtraLifeSkill;
		switch (i)
		{
		case 0:
			targetRequirement = GetStageRequiredAttainment(i, requirement, subTypeExtraLifeSkill);
			targetGrade = ((itemType == 7) ? startGrade : Convert.ToSByte(startGrade - 1));
			break;
		case 1:
			targetRequirement = GetStageRequiredAttainment(i, requirement, subTypeExtraLifeSkill);
			targetGrade = ((itemType == 7) ? Convert.ToSByte(startGrade + 1) : startGrade);
			break;
		default:
			targetRequirement = GetStageRequiredAttainment(i, requirement, subTypeExtraLifeSkill);
			targetGrade = ((itemType == 7) ? Convert.ToSByte(startGrade + 2) : Convert.ToSByte(startGrade + 1));
			break;
		}
	}

	public static (sbyte minGrade, sbyte maxGrade) GetMakeResultGradeRange(sbyte materialFinalGrade, sbyte makeResultItemType)
	{
		sbyte minGrade = materialFinalGrade;
		sbyte maxGrade = materialFinalGrade;
		for (int i = 0; i < 3; i++)
		{
			GetStageRequirementAndGrade(i, materialFinalGrade, makeResultItemType, 0, 0, out var grade, out var _);
			minGrade = Math.Min(minGrade, grade);
			maxGrade = Math.Max(maxGrade, grade);
		}
		return (minGrade: minGrade, maxGrade: maxGrade);
	}

	public static short GetStageRequiredAttainment(int i, int attainment, short subTypeExtraLifeSkill)
	{
		return (short)(attainment * GlobalConfig.Instance.MakeItemStageAttainmentFactor[i] / 100 + subTypeExtraLifeSkill);
	}

	public static (bool success, sbyte finalGrade, short finialTemplateId) GetFinalGradeAndId(sbyte baseGrade, sbyte targetGrade, sbyte itemType, short baseTemplateId)
	{
		short baseGroupId = ItemTemplateHelper.GetGroupId(itemType, baseTemplateId);
		if (baseGroupId < 0)
		{
			return (success: true, finalGrade: Convert.ToSByte(baseGrade), finialTemplateId: baseTemplateId);
		}
		targetGrade = Math.Clamp(targetGrade, 0, 8);
		int gradeOffset = Math.Max(targetGrade - baseGrade, -2);
		short resultTemplateId = Convert.ToInt16(baseTemplateId + gradeOffset);
		return (success: (ItemTemplateHelper.CheckTemplateValid(itemType, resultTemplateId) ? ItemTemplateHelper.GetGroupId(itemType, resultTemplateId) : (-1)) == baseGroupId, finalGrade: Convert.ToSByte(targetGrade), finialTemplateId: resultTemplateId);
	}

	public static sbyte GetHerbMaterialTempGrade(sbyte grade, List<short> makeItemSubtypeIdList, short makeItemSubTypeId, bool isManual)
	{
		if (makeItemSubtypeIdList.FindIndex((short item) => item == makeItemSubTypeId) == -1)
		{
			return grade;
		}
		MakeItemSubTypeItem config = MakeItemSubType.Instance[makeItemSubTypeId];
		return GetHerbMaterialTempGrade(grade, isManual, !config.IsOdd);
	}

	public static sbyte GetHerbMaterialTempGrade(sbyte grade, bool isManual, bool isMain)
	{
		if (!isManual)
		{
			return grade;
		}
		return (sbyte)(grade switch
		{
			1 => (!isMain) ? 1 : 4, 
			3 => isMain ? 5 : 2, 
			5 => isMain ? 6 : 3, 
			7 => isMain ? 7 : 4, 
			_ => 1, 
		});
	}

	public static short GetMakeRequiredLifeSkillAttainment(short makeItemSubTypeId, bool isManual, bool isPerfect, int effectValue, int materialAttainment, int materialGrade, out int manualAttainment, out int perfectAttainment, out int buildingReduceAttainment)
	{
		buildingReduceAttainment = GetReduceLifeSkillAttainmentByBuildingEffect(materialAttainment, effectValue);
		int total = materialAttainment - buildingReduceAttainment;
		perfectAttainment = (isPerfect ? (total / 2) : 0);
		total += perfectAttainment;
		manualAttainment = GetMakeExtraLifeSkillAttainment(makeItemSubTypeId, isManual, materialGrade);
		total += manualAttainment;
		return (short)total;
	}

	public static short GetMakeExtraLifeSkillAttainment(short makeItemSubTypeId, bool isManual, int materialGrade)
	{
		if (!isManual || makeItemSubTypeId < 0)
		{
			return 0;
		}
		MakeItemSubTypeItem makeItemSubTypeConfig = MakeItemSubType.Instance[makeItemSubTypeId];
		if (makeItemSubTypeConfig.Result.ItemType == 7)
		{
			return 0;
		}
		return (short)(makeItemSubTypeConfig.ExtraLifeSkill * (materialGrade + 1));
	}

	public static short GetRequiredLifeSkillAttainmentByBuildingEffect(int attainment, int effectValue)
	{
		return (short)(attainment - GetReduceLifeSkillAttainmentByBuildingEffect(attainment, effectValue));
	}

	public static short GetReduceLifeSkillAttainmentByBuildingEffect(int attainment, int effectValue)
	{
		return (short)(attainment * effectValue / 100);
	}

	public static bool CheckItemCanFeedChicken(ItemKey itemKey)
	{
		if (ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == 1204)
		{
			return true;
		}
		if (itemKey.ItemType != 11)
		{
			return itemKey.ItemType == 5;
		}
		return true;
	}

	public static bool IsBuildingCanSoldItem(BuildingBlockItem config, ItemKey itemKey)
	{
		if (!ItemTemplateHelper.IsTransferable(itemKey.ItemType, itemKey.TemplateId))
		{
			return false;
		}
		if (itemKey.ItemType == 5)
		{
			return false;
		}
		if (config.TemplateId == 47)
		{
			sbyte itemType = itemKey.ItemType;
			if (itemType == 7 || itemType == 9)
			{
				return true;
			}
			return false;
		}
		if (config.RequireLifeSkillType == 14)
		{
			if (itemKey.ItemType == 7 || (itemKey.ItemType == 5 && Material.Instance[itemKey.TemplateId].RequiredLifeSkillType == 14 && Material.Instance[itemKey.TemplateId].RefiningEffect == -1))
			{
				return true;
			}
			return false;
		}
		if (config.RequireLifeSkillType == 5 && config.TemplateId == 121)
		{
			short itemSubType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
			if (itemKey.ItemType == 9 && itemSubType == 900)
			{
				return true;
			}
			return false;
		}
		if (config.RequireLifeSkillType == 5 && config.TemplateId == 122)
		{
			short itemSubType2 = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
			if (itemKey.ItemType == 9 && itemSubType2 == 901)
			{
				return true;
			}
			return false;
		}
		if (config.RequireLifeSkillType == 5 && config.TemplateId == 124)
		{
			if (itemKey.ItemType == 9)
			{
				return true;
			}
			return false;
		}
		if (config.RequireLifeSkillType == 15)
		{
			short itemSubType3 = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
			if (itemKey.ItemType == 10 || itemKey.ItemType == 6 || itemKey.ItemType == 11 || itemSubType3 == 1204 || itemSubType3 == 1201 || itemSubType3 == 1203 || (itemKey.ItemType == 12 && itemKey.TemplateId == 18) || (itemKey.ItemType == 12 && itemKey.TemplateId == 264))
			{
				return true;
			}
			return false;
		}
		if (config.RequireLifeSkillType == 8)
		{
			if (ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == 800 || (itemKey.ItemType == 5 && Material.Instance[itemKey.TemplateId].RequiredLifeSkillType == 8 && Material.Instance[itemKey.TemplateId].RefiningEffect == -1))
			{
				return true;
			}
			return false;
		}
		if (config.RequireLifeSkillType == 9)
		{
			if (ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == 801 || (itemKey.ItemType == 5 && Material.Instance[itemKey.TemplateId].RequiredLifeSkillType == 9 && Material.Instance[itemKey.TemplateId].RefiningEffect == -1))
			{
				return true;
			}
			return false;
		}
		if (config.RequireLifeSkillType == 6)
		{
			if ((itemKey.ItemType == 0 && Weapon.Instance[itemKey.TemplateId].ResourceType == 2) || (itemKey.ItemType == 1 && Armor.Instance[itemKey.TemplateId].ResourceType == 2) || (itemKey.ItemType == 2 && Accessory.Instance[itemKey.TemplateId].ResourceType == 2) || (itemKey.ItemType == 4 && Carrier.Instance[itemKey.TemplateId].ResourceType == 2) || (itemKey.ItemType == 3 && Clothing.Instance[itemKey.TemplateId].ResourceType == 2) || (itemKey.ItemType == 5 && Material.Instance[itemKey.TemplateId].RequiredLifeSkillType == 6))
			{
				return true;
			}
			return false;
		}
		if (config.RequireLifeSkillType == 7)
		{
			if ((itemKey.ItemType == 0 && Weapon.Instance[itemKey.TemplateId].ResourceType == 1) || (itemKey.ItemType == 1 && Armor.Instance[itemKey.TemplateId].ResourceType == 1) || (itemKey.ItemType == 2 && Accessory.Instance[itemKey.TemplateId].ResourceType == 1) || (itemKey.ItemType == 4 && Carrier.Instance[itemKey.TemplateId].ResourceType == 1) || (itemKey.ItemType == 3 && Clothing.Instance[itemKey.TemplateId].ResourceType == 1) || (itemKey.ItemType == 5 && Material.Instance[itemKey.TemplateId].RequiredLifeSkillType == 7))
			{
				return true;
			}
			return false;
		}
		if (config.RequireLifeSkillType == 11)
		{
			if ((itemKey.ItemType == 0 && Weapon.Instance[itemKey.TemplateId].ResourceType == 3) || (itemKey.ItemType == 1 && Armor.Instance[itemKey.TemplateId].ResourceType == 3) || (itemKey.ItemType == 2 && Accessory.Instance[itemKey.TemplateId].ResourceType == 3) || (itemKey.ItemType == 4 && Carrier.Instance[itemKey.TemplateId].ResourceType == 3) || (itemKey.ItemType == 3 && Clothing.Instance[itemKey.TemplateId].ResourceType == 3) || (itemKey.ItemType == 5 && Material.Instance[itemKey.TemplateId].RequiredLifeSkillType == 11))
			{
				return true;
			}
			return false;
		}
		if (config.RequireLifeSkillType == 10)
		{
			short itemSubType4 = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
			if ((itemKey.ItemType == 0 && Weapon.Instance[itemKey.TemplateId].ResourceType == 4) || (itemKey.ItemType == 1 && Armor.Instance[itemKey.TemplateId].ResourceType == 4) || (itemKey.ItemType == 2 && Accessory.Instance[itemKey.TemplateId].ResourceType == 4) || (itemKey.ItemType == 4 && Carrier.Instance[itemKey.TemplateId].ResourceType == 4) || (itemKey.ItemType == 3 && Clothing.Instance[itemKey.TemplateId].ResourceType == 4) || (itemKey.ItemType == 5 && Material.Instance[itemKey.TemplateId].RequiredLifeSkillType == 10) || itemSubType4 == 1206)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static List<sbyte> GetBuildingCanSoldItemTypeList(BuildingBlockItem config, out short itemSubType)
	{
		itemSubType = -1;
		List<sbyte> typeList = new List<sbyte>();
		switch (config.RequireLifeSkillType)
		{
		case 14:
			typeList.Add(7);
			break;
		case 5:
			typeList.Add(9);
			if (config.TemplateId == 121)
			{
				itemSubType = 900;
			}
			else if (config.TemplateId == 122)
			{
				itemSubType = 901;
			}
			break;
		case 15:
			typeList.Add(10);
			typeList.Add(6);
			typeList.Add(12);
			typeList.Add(11);
			break;
		case 8:
			typeList.Add(8);
			itemSubType = 800;
			break;
		case 9:
			typeList.Add(8);
			itemSubType = 801;
			break;
		case 6:
		case 11:
			typeList.Add(0);
			typeList.Add(1);
			typeList.Add(2);
			break;
		case 7:
			typeList.Add(0);
			typeList.Add(1);
			typeList.Add(2);
			typeList.Add(4);
			break;
		case 10:
			typeList.Add(0);
			typeList.Add(1);
			typeList.Add(2);
			typeList.Add(3);
			typeList.Add(12);
			break;
		}
		return typeList;
	}

	public static int GetExpandBuildingCost(int baseCost, int addCostPerLevel, sbyte buildingLevel)
	{
		return baseCost + baseCost * addCostPerLevel * buildingLevel / 100;
	}

	public static int GetShopManageProgressDelta(short buildingTemplateId, int attainment)
	{
		if (buildingTemplateId == 105)
		{
			return attainment;
		}
		return GlobalConfig.Instance.ShopManageProgressBaseDelta + attainment;
	}

	public static int GetResourceReturnOfRemoveBuilding(BuildingBlockItem config, sbyte level, sbyte resourceType, BuildingBlockData blockData)
	{
		CValuePercent percent = config.RemoveGetResourcePercent;
		int cost = config.BaseBuildCost[resourceType];
		if (config.Class == EBuildingBlockClass.BornResource)
		{
			cost *= level;
		}
		else if (level > 1)
		{
			BoolArray64 unlockArray = blockData.LevelUnlockedFlags;
			IReadOnlyList<ResourceInfo> unlockCost = config.TemplateId switch
			{
				46 => GlobalConfig.Instance.ResidentUnlockCost, 
				48 => GlobalConfig.Instance.WarehouseUnlockCost, 
				47 => GlobalConfig.Instance.ComfortableHouseUnlockCost, 
				_ => null, 
			};
			if (unlockCost != null)
			{
				for (int i = 0; i < unlockCost.Count; i++)
				{
					if (unlockArray[i] && unlockCost[i].ResourceType == resourceType)
					{
						cost += unlockCost[i].ResourceCount;
					}
				}
			}
		}
		return cost * percent;
	}

	public static bool BuildingCanUpgrade(BuildingBlockItem config)
	{
		if (config.MaxLevel > 1)
		{
			return config.TemplateId != 50;
		}
		return false;
	}

	public static int GetTaiwuShrineEffect(sbyte leaderFameType, int attainment)
	{
		return BuildingFormula.DefValue.TaiwuShrineEffect.Calculate(leaderFameType, attainment);
	}

	public static int CalcSafetyOrCultureFactorSettlementPickValue(short requiredValue, short value)
	{
		if (requiredValue > 0)
		{
			if (value <= requiredValue)
			{
				return 0;
			}
			return (value - requiredValue) / 5 + 5;
		}
		if (value >= -requiredValue)
		{
			return 0;
		}
		return (-requiredValue - value) / 5 + 5;
	}

	public static List<SettlementDisplayData> PickSafetyOrCultureFactorSettlements(BuildingBlockItem config, IList<SettlementDisplayData> source, out int addition)
	{
		List<SettlementDisplayData> settlements = new List<SettlementDisplayData>();
		settlements.AddRange(source);
		List<SettlementDisplayData> result = new List<SettlementDisplayData>();
		for (int i = settlements.Count - 1; i >= 0; i--)
		{
			if (settlements[i].AreaTemplateId == 136 || settlements[i].AreaTemplateId == 137 || settlements[i].AreaTemplateId == 0)
			{
				settlements.RemoveAt(i);
			}
		}
		addition = 0;
		if (config.RequireSafety != 0)
		{
			if (settlements.Count > 10 && config.RequireSafety > 0)
			{
				settlements.Sort((SettlementDisplayData l, SettlementDisplayData r) => r.Safety - l.Safety);
			}
			else if (settlements.Count > 10 && config.RequireSafety < 0)
			{
				settlements.Sort((SettlementDisplayData l, SettlementDisplayData r) => l.Safety - r.Safety);
			}
			for (int i2 = 0; i2 < Math.Min(10, settlements.Count); i2++)
			{
				if (settlements[i2].SettlementId >= 0)
				{
					addition += CalcSafetyOrCultureFactorSettlementPickValue(config.RequireSafety, settlements[i2].Safety);
					result.Add(settlements[i2]);
				}
			}
		}
		if (config.RequireCulture != 0)
		{
			if (settlements.Count > 10 && config.RequireCulture > 0)
			{
				settlements.Sort((SettlementDisplayData l, SettlementDisplayData r) => r.Culture - l.Culture);
			}
			else if (settlements.Count > 10 && config.RequireCulture < 0)
			{
				settlements.Sort((SettlementDisplayData l, SettlementDisplayData r) => l.Culture - r.Culture);
			}
			for (int i3 = 0; i3 < Math.Min(10, settlements.Count); i3++)
			{
				if (settlements[i3].SettlementId >= 0)
				{
					addition += CalcSafetyOrCultureFactorSettlementPickValue(config.RequireCulture, settlements[i3].Culture);
					result.Add(settlements[i3]);
				}
			}
		}
		return result;
	}

	public static bool IsBuildingProduceMoneyAuthority(BuildingBlockItem buildingBlockItem, ShopEventItem shopEventItem)
	{
		if (buildingBlockItem.IsShop && shopEventItem != null)
		{
			return shopEventItem.ResourceGoods != -1;
		}
		return false;
	}

	public static bool IsBuildingSoldItem(BuildingBlockItem buildingBlockItem, ShopEventItem shopEventItem)
	{
		if (buildingBlockItem.IsShop && shopEventItem != null)
		{
			return shopEventItem.ExchangeResourceGoods != -1;
		}
		return false;
	}

	public static bool IsBuildingExchangeResourceGoods(BuildingBlockItem buildingBlockItem)
	{
		if (buildingBlockItem.SuccesEvent.Count != 0)
		{
			return Config.ShopEvent.Instance.GetItem(buildingBlockItem.SuccesEvent[0]).ExchangeResourceGoods != -1;
		}
		return false;
	}

	public static bool IsBuildingCollectResourceGoods(BuildingBlockItem buildingBlockItem)
	{
		if (buildingBlockItem.SuccesEvent.Count != 0)
		{
			return Config.ShopEvent.Instance.GetItem(buildingBlockItem.SuccesEvent[0]).ResourceGoods != -1;
		}
		return false;
	}

	public static sbyte GetBuildingResourceGoodsOrExchangeResourceGoodsType(BuildingBlockItem buildingBlockItem, ShopEventItem shopEventItem)
	{
		if (buildingBlockItem.IsShop && shopEventItem != null && (shopEventItem.ResourceGoods != -1 || shopEventItem.ExchangeResourceGoods != -1))
		{
			if (shopEventItem.ResourceGoods != -1)
			{
				return shopEventItem.ResourceGoods;
			}
			return shopEventItem.ExchangeResourceGoods;
		}
		return -1;
	}

	public static bool BuildingRequireSafetyOrCulture(BuildingBlockItem buildingBlockItem)
	{
		if (buildingBlockItem.RequireCulture == 0)
		{
			return buildingBlockItem.RequireSafety != 0;
		}
		return true;
	}

	public static int CalcCricketRegenTime(sbyte jarGrade)
	{
		return 3 - Grade.GetGroup(jarGrade);
	}

	public static (bool, int count) HasBuildingCore(BuildingBlockItem config, List<ItemDisplayData> canUseBuildingCore)
	{
		if (canUseBuildingCore != null)
		{
			foreach (ItemDisplayData item in canUseBuildingCore)
			{
				if (item.Key.ItemType == 12 && item.Key.TemplateId == config.BuildingCoreItem && !item.IsLocked)
				{
					return (true, count: item.Amount);
				}
			}
		}
		return (false, count: 0);
	}

	public static bool HasEffect(BuildingBlockItem config)
	{
		if (config == null)
		{
			return false;
		}
		if (config.TemplateId == 52)
		{
			return true;
		}
		List<short> expandInfos = config.ExpandInfos;
		if (expandInfos != null && expandInfos.Count > 0)
		{
			return true;
		}
		if (config.UpgradeMakeItem || config.ReduceMakeRequirementLifeSkillType > -1)
		{
			return true;
		}
		return false;
	}

	public static bool BuildingIsShopWithEvent(BuildingBlockItem config)
	{
		if (config.IsShop)
		{
			List<short> succesEvent = config.SuccesEvent;
			if (succesEvent == null)
			{
				return false;
			}
			return succesEvent.Count > 0;
		}
		return false;
	}

	public static bool BuildingShowManageProgress(BuildingBlockItem config)
	{
		if (!BuildingIsShopWithEvent(config))
		{
			return config.TemplateId == 105;
		}
		return true;
	}

	public static bool BuildingShopEventHaveItemList(BuildingBlockItem config)
	{
		List<short> succesEvent = config.SuccesEvent;
		if (succesEvent != null && succesEvent.Count > 0 && Config.ShopEvent.Instance[config.SuccesEvent[0]].ItemList.Count > 0)
		{
			return true;
		}
		return false;
	}

	public static bool BuildingShopEventHaveResourceList(BuildingBlockItem config)
	{
		List<short> succesEvent = config.SuccesEvent;
		if (succesEvent != null && succesEvent.Count > 0 && Config.ShopEvent.Instance[config.SuccesEvent[0]].ResourceGoods > 0)
		{
			return true;
		}
		return false;
	}

	public static bool BuildingShopEventHaveSoldItemList(BuildingBlockItem config)
	{
		List<short> succesEvent = config.SuccesEvent;
		if (succesEvent != null && succesEvent.Count > 0 && Config.ShopEvent.Instance[config.SuccesEvent[0]].ExchangeResourceGoods > 0)
		{
			return true;
		}
		return false;
	}

	public static bool BuildingShopEventRecruitPeople(BuildingBlockItem config)
	{
		List<short> succesEvent = config.SuccesEvent;
		if (succesEvent != null && succesEvent.Count > 0 && Config.ShopEvent.Instance[config.SuccesEvent[0]].RecruitPeopleProb.Count > 0)
		{
			return true;
		}
		return false;
	}

	public static bool BuildingCanGetEarningData(BuildingBlockItem configData)
	{
		if (!configData.IsShop)
		{
			return configData.TemplateId == 47;
		}
		return true;
	}

	public static bool BuildingGetDisplayData(BuildingBlockItem configData)
	{
		if (!configData.IsShop && configData.TemplateId != 47)
		{
			return configData.TemplateId == 46;
		}
		return true;
	}

	public static sbyte GetBuildingSlotCount(short buildingTemplateId)
	{
		switch (buildingTemplateId)
		{
		case 47:
			return (sbyte)GlobalConfig.Instance.FeastCount;
		case 105:
			return 1;
		default:
		{
			BuildingBlockItem config = BuildingBlock.Instance[buildingTemplateId];
			int slot = 1;
			for (int i = 0; i < config.ExpandInfos.Count; i++)
			{
				BuildingScaleItem expandInfoConfig = BuildingScale.Instance[config.ExpandInfos[i]];
				if (expandInfoConfig.Class == EBuildingScaleClass.Slot)
				{
					slot = expandInfoConfig.LevelEffect[0];
					break;
				}
			}
			return (sbyte)slot;
		}
		}
	}

	public static int GetBuildingEarnPreserveTime(short buildingTemplateId)
	{
		return GetBuildingSlotCount(buildingTemplateId);
	}

	public static int MaxProductionProgress(bool isAffectedByChallenge)
	{
		if (!ExternalDataBridge.Context.ChallengeModeData.IsEnabled(EChallengeModeImplement.BuildingWorkHard))
		{
			return GlobalConfig.Instance.MaxProductionProgress;
		}
		return GlobalConfig.Instance.MaxProductionProgress * 3;
	}

	public static int GetItemProductionProgress(ItemDisplayData content)
	{
		if (!content.IsResource)
		{
			return (int)content.Value;
		}
		return 1;
	}

	public static sbyte GetBuildingFixedBuff(short buildingTemplateId)
	{
		BuildingBlockItem config = BuildingBlock.Instance[buildingTemplateId];
		sbyte fixedBuff = 0;
		if (config.ExpandInfos == null)
		{
			return fixedBuff;
		}
		for (int i = 0; i < config.ExpandInfos.Count; i++)
		{
			BuildingScaleItem expandInfoConfig = BuildingScale.Instance[config.ExpandInfos[i]];
			if (expandInfoConfig.Class == EBuildingScaleClass.FixedBuff)
			{
				fixedBuff = (sbyte)expandInfoConfig.LevelEffect[0];
				break;
			}
		}
		return fixedBuff;
	}

	public static sbyte GetBuildingLevelEffect(short buildingTemplateId, int level)
	{
		BuildingBlockItem config = BuildingBlock.Instance[buildingTemplateId];
		sbyte levelEffect = 0;
		if (config.ExpandInfos == null)
		{
			return levelEffect;
		}
		for (int i = 0; i < config.ExpandInfos.Count; i++)
		{
			BuildingScaleItem expandInfoConfig = BuildingScale.Instance[config.ExpandInfos[i]];
			if (expandInfoConfig.Class == EBuildingScaleClass.LevelEffect)
			{
				levelEffect = (sbyte)expandInfoConfig.LevelEffect.GetOrLast(level - 1);
				break;
			}
		}
		return levelEffect;
	}

	public static int CalcRepairBuildingCost(BuildingBlockData blockData, BuildingBlockItem config)
	{
		return (config.MaxDurability - blockData.Durability) * config.BaseRepairCost;
	}

	public unsafe static (short, short) CalcVillagerRoleLifeSkillAndPersonalityType(short roleTemplateId, LifeSkillShorts attainments, Personalities personalities)
	{
		switch (roleTemplateId)
		{
		case 0:
			return (14, 6);
		case 1:
		{
			Span<short> arr4 = stackalloc short[4] { 6, 7, 10, 11 };
			short* arrV4 = stackalloc short[arr4.Length];
			for (int l = 0; l < arr4.Length; l++)
			{
				arrV4[l] = attainments.Get(arr4[l]);
			}
			return (arr4[CollectionUtils.GetMaxIndex(arrV4, arr4.Length)], 4);
		}
		case 2:
		{
			Span<short> arr2 = stackalloc short[2] { 8, 9 };
			short* arrV2 = stackalloc short[arr2.Length];
			for (int j = 0; j < arr2.Length; j++)
			{
				arrV2[j] = attainments.Get(arr2[j]);
			}
			return (arr2[CollectionUtils.GetMaxIndex(arrV2, arr2.Length)], 0);
		}
		case 3:
			return (15, 2);
		case 4:
		{
			Span<short> arr3 = stackalloc short[4] { 0, 1, 2, 3 };
			short* arrV3 = stackalloc short[arr3.Length];
			for (int k = 0; k < arr3.Length; k++)
			{
				arrV3[k] = attainments.Get(arr3[k]);
			}
			return (arr3[CollectionUtils.GetMaxIndex(arrV3, arr3.Length)], 1);
		}
		case 5:
		{
			Span<short> arr = stackalloc short[2] { 13, 12 };
			short* arrV = stackalloc short[arr.Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arrV[i] = attainments.Get(arr[i]);
			}
			return (arr[CollectionUtils.GetMaxIndex(arrV, arr.Length)], 3);
		}
		case 6:
			return (4, 5);
		default:
			return (-1, -1);
		}
	}

	public static bool NeedCostResourceToBuild(BuildingBlockItem buildingBlockConfigItem)
	{
		return buildingBlockConfigItem.Class != EBuildingBlockClass.BornResource;
	}

	public static int[] GetFinalMaintenanceCost(BuildingBlockItem configData)
	{
		int[] resourceCosts = new int[8];
		foreach (ResourceInfo resInfoBase in configData.BaseMaintenanceCost)
		{
			resourceCosts[resInfoBase.ResourceType] += resInfoBase.ResourceCount;
		}
		return resourceCosts;
	}

	public static int CalcResourceBlockTotalEffectValue(int formulaTemplateId, Span<int> baseValues)
	{
		BuildingFormulaItem formula = BuildingFormula.Instance[formulaTemplateId];
		int total = 0;
		for (int i = 0; i < baseValues.Length; i++)
		{
			total += formula.Calculate(baseValues[i]);
		}
		return total;
	}

	public static int GetResourceBlockEffectPercentage(int index)
	{
		if (5 <= index)
		{
			return 0;
		}
		return 100 * (5 - index) / 5;
	}

	public static int GetResourceBlockEffectPercentageValue(int level, int percentage)
	{
		return level * percentage / 100;
	}

	public static List<short> GetResourceBlockEffectScaleTemplateIdList(short templateId)
	{
		BuildingBlockItem config = BuildingBlock.Instance[templateId];
		List<short> list = new List<short>();
		if (config.ExpandInfos.Count > 0)
		{
			foreach (short scaleTemplateId in config.ExpandInfos)
			{
				if (BuildingScale.Instance[scaleTemplateId].Class != EBuildingScaleClass.LevelEffect)
				{
					list.Add(scaleTemplateId);
				}
			}
		}
		return list;
	}

	public static bool HaveResourceBlockEffect(short buildingScaleTemplateId)
	{
		BuildingScaleItem config = BuildingScale.Instance[buildingScaleTemplateId];
		if (config.Class == EBuildingScaleClass.MemberExpIncome || config.Class == EBuildingScaleClass.MemberResourceIncome || config.Formula > 0)
		{
			return true;
		}
		return false;
	}

	public static bool HaveUsefulResourceBlockEffect(short buildingBlockTemplateId, int rank)
	{
		if (BuildingBlock.Instance[buildingBlockTemplateId].Class == EBuildingBlockClass.BornResource)
		{
			return rank < 5;
		}
		return false;
	}

	public static ItemDisplayData BestTool(IEnumerable<ItemDisplayData> tools, LifeSkillShorts attainments, ItemKey equipment, short equipmentDurability, HashSet<ItemKey> runOut = null)
	{
		bool flag = equipment.IsValid();
		if (flag)
		{
			sbyte resourceType = ItemTemplateHelper.GetResourceType(equipment.ItemType, equipment.TemplateId);
			bool flag2 = (uint)(resourceType - 1) <= 4u;
			flag = flag2;
		}
		if (!flag)
		{
			return new ItemDisplayData();
		}
		return (tools ?? Enumerable.Empty<ItemDisplayData>()).Prepend(new ItemDisplayData(6, 54)).Where(delegate(ItemDisplayData x)
		{
			HashSet<ItemKey> hashSet = runOut;
			return (hashSet == null || !hashSet.Contains(x.RealKey)) && CheckBestToolAttainment(x.RealKey, equipment, equipmentDurability, attainments);
		}).OrderBy(delegate(ItemDisplayData x)
		{
			CraftToolItem craftToolItem = CraftTool.Instance[x.RealKey.TemplateId];
			short num = craftToolItem.DurabilityCost[ItemTemplateHelper.GetGrade(equipment.ItemType, equipment.TemplateId)];
			return (cost: num, (num > 0) ? craftToolItem.Grade : (-craftToolItem.Grade));
		})
			.FirstOrDefault() ?? new ItemDisplayData();
	}

	public static ItemKey BestTool(IEnumerable<ItemKey> tools, LifeSkillShorts attainments, ItemKey equipment, short equipmentDurability, HashSet<ItemKey> runOut = null)
	{
		if (!equipment.IsValid())
		{
			return ItemKey.Invalid;
		}
		return tools.Prepend(new ItemKey(6, 0, 54, -1)).Where(delegate(ItemKey x)
		{
			HashSet<ItemKey> hashSet = runOut;
			return (hashSet == null || !hashSet.Contains(x)) && CheckBestToolAttainment(x, equipment, equipmentDurability, attainments);
		}).OrderBy(delegate(ItemKey x)
		{
			CraftToolItem craftToolItem = CraftTool.Instance[x.TemplateId];
			short num = craftToolItem.DurabilityCost[ItemTemplateHelper.GetGrade(equipment.ItemType, equipment.TemplateId)];
			return (cost: num, (num > 0) ? craftToolItem.Grade : (-craftToolItem.Grade));
		})
			.Append(ItemKey.Invalid)
			.FirstOrDefault();
	}

	public static bool CheckBestToolAttainment(ItemDisplayData itemData, ItemKey tool, LifeSkillShorts attainments)
	{
		return CheckBestToolAttainment(itemData.RealKey, tool, itemData.Durability, attainments);
	}

	public static bool CheckBestToolAttainment(ItemKey tool, ItemKey equipment, short durability, LifeSkillShorts attainments)
	{
		sbyte lifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(equipment.ItemType, equipment.TemplateId);
		if (lifeSkillType == -1)
		{
			return false;
		}
		short currentAttainment = attainments[lifeSkillType];
		short requiredAttainment = ItemTemplateHelper.GetRepairRequiredAttainment(equipment.ItemType, equipment.TemplateId, durability);
		if (currentAttainment >= requiredAttainment)
		{
			if (tool.ItemType == 6)
			{
				return CraftTool.Instance[tool.TemplateId].RequiredLifeSkillTypes.Contains(lifeSkillType);
			}
			return false;
		}
		int needToolAttainment = requiredAttainment - currentAttainment;
		if (tool.ItemType == 6 && tool.IsValid())
		{
			CraftToolItem toolCfg = CraftTool.Instance[tool.TemplateId];
			if (toolCfg != null && toolCfg.RequiredLifeSkillTypes.Contains(lifeSkillType))
			{
				return toolCfg.AttainmentBonus >= needToolAttainment;
			}
		}
		return false;
	}

	public static ResourceInts GetRepairResource(ItemDisplayData itemData)
	{
		return GetRepairResource(itemData.MaterialResources, itemData.RealKey, itemData.Durability);
	}

	public static ResourceInts GetRepairResource(MaterialResources resources, ItemKey equipment, short durability)
	{
		return ItemTemplateHelper.GetRepairNeedResources(resources, equipment, durability);
	}
}
