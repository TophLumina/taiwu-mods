using System.Linq;
using Redzen.Random;

namespace GameData.Domains.Item;

/// <summary>
/// 物品子类
/// </summary>
public static class ItemSubType
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const short Invalid = -1;

	/// <summary>
	/// 武器 - 针匣
	/// </summary>
	public const short NeedleBox = 0;

	/// <summary>
	/// 武器 - 对刺
	/// </summary>
	public const short DoubleDaggers = 1;

	/// <summary>
	/// 武器 - 暗器
	/// </summary>
	public const short Hidden = 2;

	/// <summary>
	/// 武器 - 箫笛
	/// </summary>
	public const short Flute = 3;

	/// <summary>
	/// 武器 - 拳套
	/// </summary>
	public const short Gloves = 4;

	/// <summary>
	/// 武器 - 短杵
	/// </summary>
	public const short Pestle = 5;

	/// <summary>
	/// 武器 - 拂尘
	/// </summary>
	public const short Whisk = 6;

	/// <summary>
	/// 武器 - 长鞭
	/// </summary>
	public const short Whip = 7;

	/// <summary>
	/// 武器 - 剑
	/// </summary>
	public const short Sword = 8;

	/// <summary>
	/// 武器 - 刀
	/// </summary>
	public const short Blade = 9;

	/// <summary>
	/// 武器 - 长兵
	/// </summary>
	public const short Polearm = 10;

	/// <summary>
	/// 武器 - 瑶琴
	/// </summary>
	public const short Zither = 11;

	/// <summary>
	/// 武器 - 机关
	/// </summary>
	public const short MechanicWeapon = 12;

	/// <summary>
	/// 武器 - 令符
	/// </summary>
	public const short MagicSymbol = 13;

	/// <summary>
	/// 武器 - 毒霜
	/// </summary>
	public const short PoisonWeaponCream = 14;

	/// <summary>
	/// 武器 - 毒砂
	/// </summary>
	public const short PoisonWeaponSand = 15;

	/// <summary>
	/// 武器 - 神兵
	/// </summary>
	public const short SuperWeapon = 16;

	/// <summary>
	/// 武器 - 动物
	/// </summary>
	public const short AnimalWeapon = 17;

	/// <summary>
	/// 防具 - 冠饰
	/// </summary>
	public const short Helm = 100;

	/// <summary>
	/// 防具 - 躯干护甲
	/// </summary>
	public const short TorsoArmor = 101;

	/// <summary>
	/// 防具 - 护手
	/// </summary>
	public const short Bracers = 102;

	/// <summary>
	/// 防具 - 护足
	/// </summary>
	public const short Boots = 103;

	/// <summary>
	/// 防具 - 动物
	/// </summary>
	public const short AnimalArmor = 104;

	/// <summary>
	/// 饰品 - 饰品 (宝物)
	/// </summary>
	public const short Accessory = 200;

	/// <summary>
	/// 口袋 - 口袋 (宝物)
	/// </summary>
	public const short Pocket = 201;

	/// <summary>
	/// 衣装 - 衣装
	/// </summary>
	public const short Clothing = 300;

	/// <summary>
	/// 代步 - 代步
	/// </summary>
	public const short Carrier = 400;

	/// <summary>
	/// 代步 - 家畜
	/// </summary>
	public const short LivestockCarrier = 401;

	/// <summary>
	/// 代步 - 野兽
	/// </summary>
	public const short BeastCarrier = 402;

	/// <summary>
	/// 代步 - 蛟
	/// </summary>
	public const short JiaoCarrier = 403;

	/// <summary>
	/// 代步 - 龙
	/// </summary>
	public const short LoongCarrier = 404;

	/// <summary>
	/// 材料 - 食材
	/// </summary>
	public const short FoodMaterial = 500;

	/// <summary>
	/// 材料 - 木材
	/// </summary>
	public const short WoodMaterial = 501;

	/// <summary>
	/// 材料 - 金铁
	/// </summary>
	public const short MetalMaterial = 502;

	/// <summary>
	/// 材料 - 玉石
	/// </summary>
	public const short JadeMaterial = 503;

	/// <summary>
	/// 材料 - 织物
	/// </summary>
	public const short FabricMaterial = 504;

	/// <summary>
	/// 材料 - 药材
	/// </summary>
	public const short MedicineMaterial = 505;

	/// <summary>
	/// 材料 - 毒物
	/// </summary>
	public const short PoisonMaterial = 506;

	/// <summary>
	/// 制作工具 - 制作工具
	/// </summary>
	public const short CraftTool = 600;

	/// <summary>
	/// 食物 - 素食
	/// </summary>
	public const short VegetarianFood = 700;

	/// <summary>
	/// 食物 - 荤食
	/// </summary>
	public const short MeatFood = 701;

	/// <summary>
	/// 药毒 - 丹药
	/// </summary>
	public const short Medicine = 800;

	/// <summary>
	/// 药毒 - 毒药
	/// </summary>
	public const short Poison = 801;

	/// <summary>
	/// 药毒 - 蛊虫
	/// </summary>
	public const short Wug = 802;

	/// <summary>
	/// 药毒 - 混合毒
	/// </summary>
	public const short MixedPoison = 803;

	/// <summary>
	/// 茶酒 - 茶
	/// </summary>
	public const short Tea = 900;

	/// <summary>
	/// 茶酒 - 酒
	/// </summary>
	public const short Wine = 901;

	/// <summary>
	/// 技能书 - 技艺书
	/// </summary>
	public const short LifeSkillBook = 1000;

	/// <summary>
	/// 技能书 - 武学书
	/// </summary>
	public const short CombatSkillBook = 1001;

	/// <summary>
	/// 促织 - 促织
	/// </summary>
	public const short Cricket = 1100;

	/// <summary>
	/// 杂物 - 杂物中无法细分的部分
	/// </summary>
	public const short Misc = 1200;

	/// <summary>
	/// 杂物 - 蛐蛐罐
	/// </summary>
	public const short CricketJar = 1201;

	/// <summary>
	/// 杂物 - 宝典
	/// </summary>
	public const short LegendaryBook = 1202;

	/// <summary>
	/// 杂物 - 西域珍宝
	/// </summary>
	public const short WesternTreasure = 1203;

	/// <summary>
	/// 杂物 - 杂虫
	/// </summary>
	public const short OtherInsect = 1204;

	/// <summary>
	/// 杂物 - 心材 （建筑核心）
	/// </summary>
	public const short BuildingCore = 1205;

	/// <summary>
	/// 杂物 - 绳索
	/// </summary>
	public const short Rope = 1206;

	/// <summary>
	/// 杂物 - 奖励 （武林大会的奖励）
	/// </summary>
	public const short Reward = 1207;

	/// <summary>
	/// 通过大类获取所有子类
	/// </summary>
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

	/// <summary>
	/// 子类型是否是装备
	/// </summary>
	/// <param name="subType"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取随机子类
	/// </summary>
	/// <param name="random"></param>
	/// <returns></returns>
	public static short GetRandom(IRandomSource random)
	{
		sbyte type = ItemType.GetRandom(random);
		short[] subTypes = Type2SubTypes[type];
		return subTypes[random.Next(subTypes.Length)];
	}

	/// <summary>
	/// 通过子类获取大类
	/// </summary>
	/// <param name="subType"></param>
	/// <returns></returns>
	public static sbyte GetType(short subType)
	{
		return (sbyte)(subType / 100);
	}

	/// <summary>
	/// 判断指定子类能否出现在物品喜恶中
	/// </summary>
	/// <param name="subType"></param>
	/// <returns></returns>
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
