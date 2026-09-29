using System.Linq;
using Redzen.Random;

namespace GameData.Domains.Item;

public static class ItemSubType
{
	public const short Invalid = -1;

	public const short NeedleBox = 0;

	public const short DoubleDaggers = 1;

	public const short Hidden = 2;

	public const short Flute = 3;

	public const short Gloves = 4;

	public const short Pestle = 5;

	public const short Whisk = 6;

	public const short Whip = 7;

	public const short Sword = 8;

	public const short Blade = 9;

	public const short Polearm = 10;

	public const short Zither = 11;

	public const short MechanicWeapon = 12;

	public const short MagicSymbol = 13;

	public const short PoisonWeaponCream = 14;

	public const short PoisonWeaponSand = 15;

	public const short SuperWeapon = 16;

	public const short AnimalWeapon = 17;

	public const short Helm = 100;

	public const short TorsoArmor = 101;

	public const short Bracers = 102;

	public const short Boots = 103;

	public const short AnimalArmor = 104;

	public const short Accessory = 200;

	public const short Pocket = 201;

	public const short Clothing = 300;

	public const short Carrier = 400;

	public const short LivestockCarrier = 401;

	public const short BeastCarrier = 402;

	public const short JiaoCarrier = 403;

	public const short LoongCarrier = 404;

	public const short FiveLoongCarrier = 405;

	public const short FoodMaterial = 500;

	public const short WoodMaterial = 501;

	public const short MetalMaterial = 502;

	public const short JadeMaterial = 503;

	public const short FabricMaterial = 504;

	public const short MedicineMaterial = 505;

	public const short PoisonMaterial = 506;

	public const short CraftTool = 600;

	public const short VegetarianFood = 700;

	public const short MeatFood = 701;

	public const short Medicine = 800;

	public const short Poison = 801;

	public const short Wug = 802;

	public const short MixedPoison = 803;

	public const short Tea = 900;

	public const short Wine = 901;

	public const short LifeSkillBook = 1000;

	public const short CombatSkillBook = 1001;

	public const short Cricket = 1100;

	public const short Misc = 1200;

	public const short CricketJar = 1201;

	public const short LegendaryBook = 1202;

	public const short WesternTreasure = 1203;

	public const short OtherInsect = 1204;

	public const short BuildingCore = 1205;

	public const short Rope = 1206;

	public const short Reward = 1207;

	public static readonly short[][] Type2SubTypes = new short[13][]
	{
		new short[18]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13, 14, 15, 16, 17
		},
		new short[5] { 100, 101, 102, 103, 104 },
		new short[1] { 200 },
		new short[1] { 300 },
		new short[3] { 400, 401, 402 },
		new short[7] { 500, 501, 502, 503, 504, 505, 506 },
		new short[1] { 600 },
		new short[2] { 700, 701 },
		new short[4] { 800, 801, 802, 803 },
		new short[2] { 900, 901 },
		new short[2] { 1000, 1001 },
		new short[1] { 1100 },
		new short[8] { 1200, 1201, 1202, 1203, 1204, 1205, 1206, 1207 }
	};

	public static bool IsEquipment(short subType)
	{
		for (int type = 0; type <= 4; type++)
		{
			if (Type2SubTypes[type].Contains(subType))
			{
				return true;
			}
		}
		return false;
	}

	public static short GetRandom(IRandomSource random)
	{
		sbyte type = ItemType.GetRandom(random);
		short[] subTypes = Type2SubTypes[type];
		return subTypes[random.Next(subTypes.Length)];
	}

	public static sbyte GetType(short subType)
	{
		return (sbyte)(subType / 100);
	}

	public static bool IsHobbyType(short subType)
	{
		bool flag;
		switch (subType)
		{
		case 16:
		case 17:
		case 104:
		case 802:
		case 803:
		case 1100:
		case 1200:
		case 1202:
		case 1203:
		case 1204:
		case 1206:
		case 1207:
			flag = true;
			break;
		default:
			flag = false;
			break;
		}
		return !flag;
	}
}
