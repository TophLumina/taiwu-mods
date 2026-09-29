using System;
using Config;
using GameData.Domains.Item;

namespace GameData.Domains.Extra;

public static class SharedMethods
{
	public static int GetTreeExtraNameTextTemplateId(int miscTemplateId)
	{
		return miscTemplateId switch
		{
			316 => 6, 
			317 => 7, 
			318 => 8, 
			319 => 9, 
			320 => 10, 
			321 => 11, 
			322 => 12, 
			323 => 13, 
			324 => 14, 
			325 => 15, 
			326 => 16, 
			327 => 17, 
			304 => 20, 
			305 => 21, 
			306 => 22, 
			307 => 23, 
			308 => 24, 
			309 => 25, 
			310 => 26, 
			311 => 27, 
			312 => 28, 
			313 => 29, 
			314 => 30, 
			315 => 31, 
			_ => throw new Exception($"Exception HeavenlyTree Seed TemplateId: {miscTemplateId}"), 
		};
	}

	public static string GetTreeName(int miscTemplateId)
	{
		int extraNameTextTemplateId = GetTreeExtraNameTextTemplateId(miscTemplateId);
		return ExtraNameText.Instance[extraNameTextTemplateId].Content;
	}

	public static int GetFoodAddCarrierDurability(short carrierTemplateId, short materialTemplateId, int count = 1)
	{
		CarrierItem carrierConfig = Carrier.Instance[carrierTemplateId];
		MaterialItem materialConfig = Material.Instance[materialTemplateId];
		int value = GlobalConfig.Instance.FoodGradeAddCarrierDurability[materialConfig.Grade];
		if (carrierConfig.LoveFoodType.Contains(materialTemplateId))
		{
			value += GlobalConfig.Instance.LikeFoodAddCarrierDurability;
		}
		else if (carrierConfig.HateFoodType.Contains(materialTemplateId))
		{
			value += GlobalConfig.Instance.DislikeFoodAddCarrierDurability;
		}
		return value * count;
	}

	public static int GetFoodAddCarrierTamePoint(short carrierId, short materialId, int count = 1)
	{
		CarrierItem carrierConfig = Carrier.Instance[carrierId];
		MaterialItem foodConfig = Material.Instance[materialId];
		int increment = Material.Instance[materialId].Grade + 1;
		if (carrierConfig.LoveFoodType.Contains(foodConfig.TemplateId))
		{
			increment = Math.Max(1, (int)Math.Ceiling((float)increment * 1.5f));
		}
		else if (carrierConfig.HateFoodType.Contains(foodConfig.TemplateId))
		{
			increment = Math.Max(1, (int)Math.Floor((float)increment * 0.5f));
		}
		return increment * count;
	}

	public static int GetExchangeToolSpiritualDebtCost(sbyte grade)
	{
		return (grade + 1) * 50;
	}

	public static int GetFixItemAttainmentNeed(sbyte grade)
	{
		return grade * (grade + 1) * 5 / 2 + 5;
	}

	public static sbyte GetItemRequireLifeSkillType(ItemKey itemKey)
	{
		sbyte resourceType = ItemTemplateHelper.GetResourceType(itemKey.ItemType, itemKey.TemplateId);
		if (resourceType < 0)
		{
			return -1;
		}
		return ResourceType.Instance[resourceType].LifeSkillType;
	}
}
