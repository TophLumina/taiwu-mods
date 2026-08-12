using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Item;

namespace GameData.Utilities;

/// <summary>
/// 道具配置辅助工具集
/// </summary>
public static class ItemConfigHelper
{
	/// <summary>
	/// 所有道具配置
	/// </summary>
	public static IEnumerable<IItemConfig> AllConfigs => GetAllConfigs().SelectMany(Selector);

	/// <summary>
	/// 获取指定道具键配置
	/// </summary>
	public static IItemConfig GetConfig(this ItemKey itemKey)
	{
		return GetConfig(itemKey.ItemType, itemKey.TemplateId);
	}

	/// <summary>
	/// 获取指定道具键配置（作为指定类型转换，失败时返回 null）
	/// </summary>
	public static T GetConfigAs<T>(this ItemKey itemKey) where T : class
	{
		return itemKey.GetConfig() as T;
	}

	/// <summary>
	/// 查找指定道具升级后的道具
	/// </summary>
	public static IItemConfig Upgrade(this IItemConfig config)
	{
		return FindGroupItem(config.ItemType, config.TemplateId, 1);
	}

	/// <summary>
	/// 查找指定道具降级后的道具
	/// </summary>
	public static IItemConfig Degrade(this IItemConfig config)
	{
		return FindGroupItem(config.ItemType, config.TemplateId, -1);
	}

	/// <summary>
	/// 指定道具是否需要可用服食栏位
	/// 王蛊服食时不直接占用可用栏位，可覆盖栏位，因此在这里返回 false
	/// </summary>
	public static bool IsEat(this IItemConfig config)
	{
		if (config.Duration > 0)
		{
			return config.ItemSubType != 802;
		}
		return false;
	}

	/// <summary>
	/// 查找指定道具同组改变品级的道具
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <param name="gradeDelta">品级变化</param>
	/// <returns></returns>
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

	/// <summary>
	/// 根据道具类型与模板 ID 获得对应配置
	/// </summary>
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

	/// <summary>
	/// 根据道具类型与模板 ID 获得对应配置
	/// </summary>
	public static IItemConfig GetConfig(sbyte itemType, short templateId)
	{
		return GetConfig(itemType)?[templateId];
	}
}
