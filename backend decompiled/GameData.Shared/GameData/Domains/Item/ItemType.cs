using System.Collections.Generic;
using Redzen.Random;

namespace GameData.Domains.Item;

/// <summary>
/// 物品类型 (和物品表一一对应)
/// </summary>
public static class ItemType
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 武器
	/// </summary>
	public const sbyte Weapon = 0;

	/// <summary>
	/// 防具
	/// </summary>
	public const sbyte Armor = 1;

	/// <summary>
	/// 饰品
	/// </summary>
	public const sbyte Accessory = 2;

	/// <summary>
	/// 衣装
	/// </summary>
	public const sbyte Clothing = 3;

	/// <summary>
	/// 代步
	/// </summary>
	public const sbyte Carrier = 4;

	/// <summary>
	/// 材料
	/// </summary>
	public const sbyte Material = 5;

	/// <summary>
	/// 制作工具
	/// </summary>
	public const sbyte CraftTool = 6;

	/// <summary>
	/// 食物
	/// </summary>
	public const sbyte Food = 7;

	/// <summary>
	/// 药毒
	/// </summary>
	public const sbyte Medicine = 8;

	/// <summary>
	/// 茶酒
	/// </summary>
	public const sbyte TeaWine = 9;

	/// <summary>
	/// 技能书
	/// </summary>
	public const sbyte SkillBook = 10;

	/// <summary>
	/// 促织
	/// </summary>
	public const sbyte Cricket = 11;

	/// <summary>
	/// 杂物
	/// </summary>
	public const sbyte Misc = 12;

	/// <summary>
	/// 物品类型个数
	/// </summary>
	public const int Count = 13;

	/// <summary>
	/// 通过物品名称索引到物品类型
	/// </summary>
	public static readonly Dictionary<string, sbyte> TypeName2TypeId = new Dictionary<string, sbyte>
	{
		{ "Weapon", 0 },
		{ "Armor", 1 },
		{ "Accessory", 2 },
		{ "Clothing", 3 },
		{ "Carrier", 4 },
		{ "Material", 5 },
		{ "CraftTool", 6 },
		{ "Food", 7 },
		{ "Medicine", 8 },
		{ "TeaWine", 9 },
		{ "SkillBook", 10 },
		{ "Cricket", 11 },
		{ "Misc", 12 }
	};

	/// <summary>
	/// 通过物品类型索引到物品名称
	/// </summary>
	public static readonly string[] TypeId2TypeName = new string[13]
	{
		"Weapon", "Armor", "Accessory", "Clothing", "Carrier", "Material", "CraftTool", "Food", "Medicine", "TeaWine",
		"SkillBook", "Cricket", "Misc"
	};

	/// <summary>
	/// 获取随机类型
	/// </summary>
	/// <param name="random"></param>
	/// <returns></returns>
	public static sbyte GetRandom(IRandomSource random)
	{
		return (sbyte)random.Next(13);
	}

	/// <summary>
	/// 指定物品类型是否为装备
	/// </summary>
	public static bool IsEquipmentItemType(sbyte itemType)
	{
		if (itemType >= 0)
		{
			return itemType <= 4;
		}
		return false;
	}

	/// <summary>
	/// 指定物品类型是否可服食
	/// </summary>
	public static bool IsEatable(sbyte itemType)
	{
		if (itemType >= 7)
		{
			return itemType <= 9;
		}
		return false;
	}

	/// <summary>
	/// 指定物品类型是否有装备特效
	/// </summary>
	public static bool IsEquipmentEffectType(sbyte itemType)
	{
		if (itemType >= 0)
		{
			return itemType <= 2;
		}
		return false;
	}
}
