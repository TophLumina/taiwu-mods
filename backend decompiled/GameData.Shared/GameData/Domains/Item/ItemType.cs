using System.Collections.Generic;
using Redzen.Random;

namespace GameData.Domains.Item;

public static class ItemType
{
	public const sbyte Invalid = -1;

	public const sbyte Weapon = 0;

	public const sbyte Armor = 1;

	public const sbyte Accessory = 2;

	public const sbyte Clothing = 3;

	public const sbyte Carrier = 4;

	public const sbyte Material = 5;

	public const sbyte CraftTool = 6;

	public const sbyte Food = 7;

	public const sbyte Medicine = 8;

	public const sbyte TeaWine = 9;

	public const sbyte SkillBook = 10;

	public const sbyte Cricket = 11;

	public const sbyte Misc = 12;

	public const int Count = 13;

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

	public static readonly string[] TypeId2TypeName = new string[13]
	{
		"Weapon", "Armor", "Accessory", "Clothing", "Carrier", "Material", "CraftTool", "Food", "Medicine", "TeaWine",
		"SkillBook", "Cricket", "Misc"
	};

	public static sbyte GetRandom(IRandomSource random)
	{
		return (sbyte)random.Next(13);
	}

	public static bool IsEquipmentItemType(sbyte itemType)
	{
		if (itemType >= 0)
		{
			return itemType <= 4;
		}
		return false;
	}

	public static bool IsEatable(sbyte itemType)
	{
		if (itemType >= 7)
		{
			return itemType <= 9;
		}
		return false;
	}

	public static bool IsEquipmentEffectType(sbyte itemType)
	{
		if (itemType >= 0)
		{
			return itemType <= 2;
		}
		return false;
	}
}
