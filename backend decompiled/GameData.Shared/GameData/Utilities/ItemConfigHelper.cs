using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Item;

namespace GameData.Utilities;

public static class ItemConfigHelper
{
	public static IEnumerable<IItemConfig> AllConfigs => GetAllConfigs().SelectMany(Selector);

	public static IItemConfig GetConfig(this ItemKey itemKey)
	{
		return GetConfig(itemKey.ItemType, itemKey.TemplateId);
	}

	public static T GetConfigAs<T>(this ItemKey itemKey) where T : class
	{
		return itemKey.GetConfig() as T;
	}

	public static IItemConfig Upgrade(this IItemConfig config)
	{
		return FindGroupItem(config.ItemType, config.TemplateId, 1);
	}

	public static IItemConfig Degrade(this IItemConfig config)
	{
		return FindGroupItem(config.ItemType, config.TemplateId, -1);
	}

	public static bool IsEat(this IItemConfig config)
	{
		if (config.Duration > 0)
		{
			return config.ItemSubType != 802;
		}
		return false;
	}

	public static IItemConfig FindGroupItem(sbyte itemType, short templateId, sbyte gradeDelta)
	{
		IReadOnlyList<IItemConfig> config = GetConfig(itemType);
		if (config == null)
		{
			return null;
		}
		IItemConfig targetConfig = GetConfig(itemType, templateId);
		if (targetConfig == null || targetConfig.GroupId < 0)
		{
			return null;
		}
		int targetGrade = targetConfig.Grade + gradeDelta;
		foreach (IItemConfig itemConfig in config)
		{
			if (itemConfig.GroupId >= 0 && itemConfig.GroupId == targetConfig.GroupId && itemConfig.Grade == targetGrade)
			{
				return itemConfig;
			}
		}
		return null;
	}

	private static IEnumerable<IItemConfig> Selector(IEnumerable<IItemConfig> arg)
	{
		return arg;
	}

	private static IEnumerable<IEnumerable<IItemConfig>> GetAllConfigs()
	{
		for (sbyte i = 0; i < 13; i++)
		{
			IReadOnlyList<IItemConfig> config = GetConfig(i);
			if (config != null)
			{
				yield return config;
			}
		}
	}

	public static IReadOnlyList<IItemConfig> GetConfig(sbyte itemType)
	{
		return itemType switch
		{
			0 => Weapon.Instance, 
			1 => Armor.Instance, 
			2 => Accessory.Instance, 
			3 => Clothing.Instance, 
			4 => Carrier.Instance, 
			5 => Material.Instance, 
			6 => CraftTool.Instance, 
			7 => Food.Instance, 
			8 => Medicine.Instance, 
			9 => TeaWine.Instance, 
			10 => SkillBook.Instance, 
			11 => Cricket.Instance, 
			12 => Misc.Instance, 
			_ => null, 
		};
	}

	public static IItemConfig GetConfig(sbyte itemType, short templateId)
	{
		return GetConfig(itemType)?[templateId];
	}
}
