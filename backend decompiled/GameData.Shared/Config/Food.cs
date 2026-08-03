using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class Food : ConfigData<FoodItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 野果
		/// </summary>
		public const short Yeguo0 = 0;

		/// <summary>
		/// 鸭梨
		/// </summary>
		public const short Yeguo1 = 1;

		/// <summary>
		/// 金柑橘
		/// </summary>
		public const short Yeguo2 = 2;

		/// <summary>
		/// 海棠果
		/// </summary>
		public const short Yeguo3 = 3;

		/// <summary>
		/// 五色葡萄
		/// </summary>
		public const short Yeguo4 = 4;

		/// <summary>
		/// 荔枝
		/// </summary>
		public const short Yeguo5 = 5;

		/// <summary>
		/// 野石榴
		/// </summary>
		public const short Yeguo6 = 6;

		/// <summary>
		/// 人参果
		/// </summary>
		public const short Yeguo7 = 7;

		/// <summary>
		/// 蟠桃仙果
		/// </summary>
		public const short Yeguo8 = 8;

		/// <summary>
		/// 清煮鸡蛋
		/// </summary>
		public const short Qingzhujidan0 = 9;

		/// <summary>
		/// 荷包蛋
		/// </summary>
		public const short Qingzhujidan1 = 10;

		/// <summary>
		/// 蛋炒饭
		/// </summary>
		public const short Qingzhujidan2 = 11;

		/// <summary>
		/// 扬州炒饭
		/// </summary>
		public const short Qingzhujidan3 = 12;

		/// <summary>
		/// 蛋花点翠汤
		/// </summary>
		public const short Qingzhujidan4 = 13;

		/// <summary>
		/// 三丝蛋卷
		/// </summary>
		public const short Qingzhujidan5 = 14;

		/// <summary>
		/// 无黄蛋
		/// </summary>
		public const short Qingzhujidan6 = 15;

		/// <summary>
		/// 天地一口香
		/// </summary>
		public const short Qingzhujidan7 = 16;

		/// <summary>
		/// 金袍饭
		/// </summary>
		public const short Qingzhujidan8 = 17;

		/// <summary>
		/// 炙鸭
		/// </summary>
		public const short Zhiya0 = 26;

		/// <summary>
		/// 葫芦鸭
		/// </summary>
		public const short Zhiya1 = 27;

		/// <summary>
		/// 昭君鸭
		/// </summary>
		public const short Zhiya2 = 28;

		/// <summary>
		/// 寿字鸭羹
		/// </summary>
		public const short Zhiya3 = 29;

		/// <summary>
		/// 梅血细粉
		/// </summary>
		public const short Zhiya4 = 30;

		/// <summary>
		/// 太白鸭
		/// </summary>
		public const short Zhiya5 = 31;

		/// <summary>
		/// 金陵盐水鸭
		/// </summary>
		public const short Zhiya6 = 32;

		/// <summary>
		/// 炭烤兔肉
		/// </summary>
		public const short Tankaoturou0 = 51;

		/// <summary>
		/// 冷吃兔
		/// </summary>
		public const short Tankaoturou1 = 52;

		/// <summary>
		/// 麻辣兔头
		/// </summary>
		public const short Tankaoturou2 = 53;

		/// <summary>
		/// 鲜锅兔
		/// </summary>
		public const short Tankaoturou3 = 54;

		/// <summary>
		/// 百味羹
		/// </summary>
		public const short Tankaoturou4 = 55;

		/// <summary>
		/// 火靠五味兔
		/// </summary>
		public const short Tankaoturou5 = 56;

		/// <summary>
		/// 影戏算条
		/// </summary>
		public const short Tankaoturou6 = 57;

		/// <summary>
		/// 玉兔羹
		/// </summary>
		public const short Tankaoturou7 = 58;

		/// <summary>
		/// 拨霞供
		/// </summary>
		public const short Tankaoturou8 = 59;

		/// <summary>
		/// 细抹羊生烩
		/// </summary>
		public const short Ximoyangshenghui0 = 68;

		/// <summary>
		/// 羊杂熓
		/// </summary>
		public const short Ximoyangshenghui1 = 69;

		/// <summary>
		/// 葱扒羊肉
		/// </summary>
		public const short Ximoyangshenghui2 = 70;

		/// <summary>
		/// 砂锅散丹
		/// </summary>
		public const short Ximoyangshenghui3 = 71;

		/// <summary>
		/// 火靠羊腰
		/// </summary>
		public const short Ximoyangshenghui4 = 72;

		/// <summary>
		/// 消灵炙
		/// </summary>
		public const short Ximoyangshenghui5 = 73;

		/// <summary>
		/// 羊方藏鱼
		/// </summary>
		public const short Ximoyangshenghui6 = 74;

		/// <summary>
		/// 扒熊掌
		/// </summary>
		public const short Baxiongzhang0 = 90;

		/// <summary>
		/// 八宝熊掌
		/// </summary>
		public const short Baxiongzhang1 = 91;

		/// <summary>
		/// 一品大王掌
		/// </summary>
		public const short Baxiongzhang2 = 92;

		/// <summary>
		/// 炊饼
		/// </summary>
		public const short Chuibing0 = 93;

		/// <summary>
		/// 阳春面
		/// </summary>
		public const short Chuibing1 = 94;

		/// <summary>
		/// 四色馒头
		/// </summary>
		public const short Chuibing2 = 95;

		/// <summary>
		/// 芙蓉饼
		/// </summary>
		public const short Chuibing3 = 96;

		/// <summary>
		/// 枣箍荷叶饼
		/// </summary>
		public const short Chuibing4 = 97;

		/// <summary>
		/// 金银牡丹饼
		/// </summary>
		public const short Chuibing5 = 98;

		/// <summary>
		/// 子母春茧
		/// </summary>
		public const short Chuibing6 = 99;

		/// <summary>
		/// 樱桃毕罗
		/// </summary>
		public const short Chuibing7 = 100;

		/// <summary>
		/// 寿带龟仙桃
		/// </summary>
		public const short Chuibing8 = 101;

		/// <summary>
		/// 生煎豆腐
		/// </summary>
		public const short Shengjiandoufu0 = 102;

		/// <summary>
		/// 豆腐清汤
		/// </summary>
		public const short Shengjiandoufu1 = 103;

		/// <summary>
		/// 鱼香豆腐
		/// </summary>
		public const short Shengjiandoufu2 = 104;

		/// <summary>
		/// 上汤白玉
		/// </summary>
		public const short Shengjiandoufu3 = 105;

		/// <summary>
		/// 文思豆腐
		/// </summary>
		public const short Shengjiandoufu4 = 106;

		/// <summary>
		/// 一品豆腐
		/// </summary>
		public const short Shengjiandoufu5 = 107;

		/// <summary>
		/// 东坡豆腐
		/// </summary>
		public const short Shengjiandoufu6 = 108;

		/// <summary>
		/// 白壁青云
		/// </summary>
		public const short Shengjiandoufu7 = 109;

		/// <summary>
		/// 太清汤
		/// </summary>
		public const short Taiqingtang0 = 132;

		/// <summary>
		/// 玉带猴头羹
		/// </summary>
		public const short Taiqingtang1 = 133;

		/// <summary>
		/// 琼浆白猿头
		/// </summary>
		public const short Taiqingtang2 = 134;

		/// <summary>
		/// 乱炖鱼片
		/// </summary>
		public const short Luandunyupian0 = 135;

		/// <summary>
		/// 红烧鱼
		/// </summary>
		public const short Luandunyupian1 = 136;

		/// <summary>
		/// 鱼鳔二色脍
		/// </summary>
		public const short Luandunyupian2 = 137;

		/// <summary>
		/// 火靠糊辣鱼
		/// </summary>
		public const short Luandunyupian3 = 138;

		/// <summary>
		/// 花雕怪味鱼
		/// </summary>
		public const short Luandunyupian4 = 139;

		/// <summary>
		/// 宋嫂鱼羹
		/// </summary>
		public const short Luandunyupian5 = 140;

		/// <summary>
		/// 圣旨骨酥鱼
		/// </summary>
		public const short Luandunyupian6 = 141;

		/// <summary>
		/// 西湖醋鱼
		/// </summary>
		public const short Luandunyupian7 = 142;

		/// <summary>
		/// 杜鹃醉鱼
		/// </summary>
		public const short Luandunyupian8 = 143;

		/// <summary>
		/// 白灼虾
		/// </summary>
		public const short Baizhuoxia0 = 144;

		/// <summary>
		/// 酒炙青虾
		/// </summary>
		public const short Baizhuoxia1 = 145;

		/// <summary>
		/// 芥辣虾
		/// </summary>
		public const short Baizhuoxia2 = 146;

		/// <summary>
		/// 紫苏虾
		/// </summary>
		public const short Baizhuoxia3 = 147;

		/// <summary>
		/// 御带虾仁
		/// </summary>
		public const short Baizhuoxia4 = 148;

		/// <summary>
		/// 撺望潮青虾
		/// </summary>
		public const short Baizhuoxia5 = 149;

		/// <summary>
		/// 群仙羹
		/// </summary>
		public const short Baizhuoxia6 = 150;

		/// <summary>
		/// 龙井虾仁
		/// </summary>
		public const short Baizhuoxia7 = 151;

		/// <summary>
		/// 鲜鳇熝
		/// </summary>
		public const short Xianhuanglu0 = 174;

		/// <summary>
		/// 梅雪生龙片
		/// </summary>
		public const short Xianhuanglu1 = 175;

		/// <summary>
		/// 烧秦皇鱼骨
		/// </summary>
		public const short Xianhuanglu2 = 176;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 野果
		/// </summary>
		public static FoodItem Yeguo0 => Instance[(short)0];

		/// <summary>
		/// 鸭梨
		/// </summary>
		public static FoodItem Yeguo1 => Instance[(short)1];

		/// <summary>
		/// 金柑橘
		/// </summary>
		public static FoodItem Yeguo2 => Instance[(short)2];

		/// <summary>
		/// 海棠果
		/// </summary>
		public static FoodItem Yeguo3 => Instance[(short)3];

		/// <summary>
		/// 五色葡萄
		/// </summary>
		public static FoodItem Yeguo4 => Instance[(short)4];

		/// <summary>
		/// 荔枝
		/// </summary>
		public static FoodItem Yeguo5 => Instance[(short)5];

		/// <summary>
		/// 野石榴
		/// </summary>
		public static FoodItem Yeguo6 => Instance[(short)6];

		/// <summary>
		/// 人参果
		/// </summary>
		public static FoodItem Yeguo7 => Instance[(short)7];

		/// <summary>
		/// 蟠桃仙果
		/// </summary>
		public static FoodItem Yeguo8 => Instance[(short)8];

		/// <summary>
		/// 清煮鸡蛋
		/// </summary>
		public static FoodItem Qingzhujidan0 => Instance[(short)9];

		/// <summary>
		/// 荷包蛋
		/// </summary>
		public static FoodItem Qingzhujidan1 => Instance[(short)10];

		/// <summary>
		/// 蛋炒饭
		/// </summary>
		public static FoodItem Qingzhujidan2 => Instance[(short)11];

		/// <summary>
		/// 扬州炒饭
		/// </summary>
		public static FoodItem Qingzhujidan3 => Instance[(short)12];

		/// <summary>
		/// 蛋花点翠汤
		/// </summary>
		public static FoodItem Qingzhujidan4 => Instance[(short)13];

		/// <summary>
		/// 三丝蛋卷
		/// </summary>
		public static FoodItem Qingzhujidan5 => Instance[(short)14];

		/// <summary>
		/// 无黄蛋
		/// </summary>
		public static FoodItem Qingzhujidan6 => Instance[(short)15];

		/// <summary>
		/// 天地一口香
		/// </summary>
		public static FoodItem Qingzhujidan7 => Instance[(short)16];

		/// <summary>
		/// 金袍饭
		/// </summary>
		public static FoodItem Qingzhujidan8 => Instance[(short)17];

		/// <summary>
		/// 炙鸭
		/// </summary>
		public static FoodItem Zhiya0 => Instance[(short)26];

		/// <summary>
		/// 葫芦鸭
		/// </summary>
		public static FoodItem Zhiya1 => Instance[(short)27];

		/// <summary>
		/// 昭君鸭
		/// </summary>
		public static FoodItem Zhiya2 => Instance[(short)28];

		/// <summary>
		/// 寿字鸭羹
		/// </summary>
		public static FoodItem Zhiya3 => Instance[(short)29];

		/// <summary>
		/// 梅血细粉
		/// </summary>
		public static FoodItem Zhiya4 => Instance[(short)30];

		/// <summary>
		/// 太白鸭
		/// </summary>
		public static FoodItem Zhiya5 => Instance[(short)31];

		/// <summary>
		/// 金陵盐水鸭
		/// </summary>
		public static FoodItem Zhiya6 => Instance[(short)32];

		/// <summary>
		/// 炭烤兔肉
		/// </summary>
		public static FoodItem Tankaoturou0 => Instance[(short)51];

		/// <summary>
		/// 冷吃兔
		/// </summary>
		public static FoodItem Tankaoturou1 => Instance[(short)52];

		/// <summary>
		/// 麻辣兔头
		/// </summary>
		public static FoodItem Tankaoturou2 => Instance[(short)53];

		/// <summary>
		/// 鲜锅兔
		/// </summary>
		public static FoodItem Tankaoturou3 => Instance[(short)54];

		/// <summary>
		/// 百味羹
		/// </summary>
		public static FoodItem Tankaoturou4 => Instance[(short)55];

		/// <summary>
		/// 火靠五味兔
		/// </summary>
		public static FoodItem Tankaoturou5 => Instance[(short)56];

		/// <summary>
		/// 影戏算条
		/// </summary>
		public static FoodItem Tankaoturou6 => Instance[(short)57];

		/// <summary>
		/// 玉兔羹
		/// </summary>
		public static FoodItem Tankaoturou7 => Instance[(short)58];

		/// <summary>
		/// 拨霞供
		/// </summary>
		public static FoodItem Tankaoturou8 => Instance[(short)59];

		/// <summary>
		/// 细抹羊生烩
		/// </summary>
		public static FoodItem Ximoyangshenghui0 => Instance[(short)68];

		/// <summary>
		/// 羊杂熓
		/// </summary>
		public static FoodItem Ximoyangshenghui1 => Instance[(short)69];

		/// <summary>
		/// 葱扒羊肉
		/// </summary>
		public static FoodItem Ximoyangshenghui2 => Instance[(short)70];

		/// <summary>
		/// 砂锅散丹
		/// </summary>
		public static FoodItem Ximoyangshenghui3 => Instance[(short)71];

		/// <summary>
		/// 火靠羊腰
		/// </summary>
		public static FoodItem Ximoyangshenghui4 => Instance[(short)72];

		/// <summary>
		/// 消灵炙
		/// </summary>
		public static FoodItem Ximoyangshenghui5 => Instance[(short)73];

		/// <summary>
		/// 羊方藏鱼
		/// </summary>
		public static FoodItem Ximoyangshenghui6 => Instance[(short)74];

		/// <summary>
		/// 扒熊掌
		/// </summary>
		public static FoodItem Baxiongzhang0 => Instance[(short)90];

		/// <summary>
		/// 八宝熊掌
		/// </summary>
		public static FoodItem Baxiongzhang1 => Instance[(short)91];

		/// <summary>
		/// 一品大王掌
		/// </summary>
		public static FoodItem Baxiongzhang2 => Instance[(short)92];

		/// <summary>
		/// 炊饼
		/// </summary>
		public static FoodItem Chuibing0 => Instance[(short)93];

		/// <summary>
		/// 阳春面
		/// </summary>
		public static FoodItem Chuibing1 => Instance[(short)94];

		/// <summary>
		/// 四色馒头
		/// </summary>
		public static FoodItem Chuibing2 => Instance[(short)95];

		/// <summary>
		/// 芙蓉饼
		/// </summary>
		public static FoodItem Chuibing3 => Instance[(short)96];

		/// <summary>
		/// 枣箍荷叶饼
		/// </summary>
		public static FoodItem Chuibing4 => Instance[(short)97];

		/// <summary>
		/// 金银牡丹饼
		/// </summary>
		public static FoodItem Chuibing5 => Instance[(short)98];

		/// <summary>
		/// 子母春茧
		/// </summary>
		public static FoodItem Chuibing6 => Instance[(short)99];

		/// <summary>
		/// 樱桃毕罗
		/// </summary>
		public static FoodItem Chuibing7 => Instance[(short)100];

		/// <summary>
		/// 寿带龟仙桃
		/// </summary>
		public static FoodItem Chuibing8 => Instance[(short)101];

		/// <summary>
		/// 生煎豆腐
		/// </summary>
		public static FoodItem Shengjiandoufu0 => Instance[(short)102];

		/// <summary>
		/// 豆腐清汤
		/// </summary>
		public static FoodItem Shengjiandoufu1 => Instance[(short)103];

		/// <summary>
		/// 鱼香豆腐
		/// </summary>
		public static FoodItem Shengjiandoufu2 => Instance[(short)104];

		/// <summary>
		/// 上汤白玉
		/// </summary>
		public static FoodItem Shengjiandoufu3 => Instance[(short)105];

		/// <summary>
		/// 文思豆腐
		/// </summary>
		public static FoodItem Shengjiandoufu4 => Instance[(short)106];

		/// <summary>
		/// 一品豆腐
		/// </summary>
		public static FoodItem Shengjiandoufu5 => Instance[(short)107];

		/// <summary>
		/// 东坡豆腐
		/// </summary>
		public static FoodItem Shengjiandoufu6 => Instance[(short)108];

		/// <summary>
		/// 白壁青云
		/// </summary>
		public static FoodItem Shengjiandoufu7 => Instance[(short)109];

		/// <summary>
		/// 太清汤
		/// </summary>
		public static FoodItem Taiqingtang0 => Instance[(short)132];

		/// <summary>
		/// 玉带猴头羹
		/// </summary>
		public static FoodItem Taiqingtang1 => Instance[(short)133];

		/// <summary>
		/// 琼浆白猿头
		/// </summary>
		public static FoodItem Taiqingtang2 => Instance[(short)134];

		/// <summary>
		/// 乱炖鱼片
		/// </summary>
		public static FoodItem Luandunyupian0 => Instance[(short)135];

		/// <summary>
		/// 红烧鱼
		/// </summary>
		public static FoodItem Luandunyupian1 => Instance[(short)136];

		/// <summary>
		/// 鱼鳔二色脍
		/// </summary>
		public static FoodItem Luandunyupian2 => Instance[(short)137];

		/// <summary>
		/// 火靠糊辣鱼
		/// </summary>
		public static FoodItem Luandunyupian3 => Instance[(short)138];

		/// <summary>
		/// 花雕怪味鱼
		/// </summary>
		public static FoodItem Luandunyupian4 => Instance[(short)139];

		/// <summary>
		/// 宋嫂鱼羹
		/// </summary>
		public static FoodItem Luandunyupian5 => Instance[(short)140];

		/// <summary>
		/// 圣旨骨酥鱼
		/// </summary>
		public static FoodItem Luandunyupian6 => Instance[(short)141];

		/// <summary>
		/// 西湖醋鱼
		/// </summary>
		public static FoodItem Luandunyupian7 => Instance[(short)142];

		/// <summary>
		/// 杜鹃醉鱼
		/// </summary>
		public static FoodItem Luandunyupian8 => Instance[(short)143];

		/// <summary>
		/// 白灼虾
		/// </summary>
		public static FoodItem Baizhuoxia0 => Instance[(short)144];

		/// <summary>
		/// 酒炙青虾
		/// </summary>
		public static FoodItem Baizhuoxia1 => Instance[(short)145];

		/// <summary>
		/// 芥辣虾
		/// </summary>
		public static FoodItem Baizhuoxia2 => Instance[(short)146];

		/// <summary>
		/// 紫苏虾
		/// </summary>
		public static FoodItem Baizhuoxia3 => Instance[(short)147];

		/// <summary>
		/// 御带虾仁
		/// </summary>
		public static FoodItem Baizhuoxia4 => Instance[(short)148];

		/// <summary>
		/// 撺望潮青虾
		/// </summary>
		public static FoodItem Baizhuoxia5 => Instance[(short)149];

		/// <summary>
		/// 群仙羹
		/// </summary>
		public static FoodItem Baizhuoxia6 => Instance[(short)150];

		/// <summary>
		/// 龙井虾仁
		/// </summary>
		public static FoodItem Baizhuoxia7 => Instance[(short)151];

		/// <summary>
		/// 鲜鳇熝
		/// </summary>
		public static FoodItem Xianhuanglu0 => Instance[(short)174];

		/// <summary>
		/// 梅雪生龙片
		/// </summary>
		public static FoodItem Xianhuanglu1 => Instance[(short)175];

		/// <summary>
		/// 烧秦皇鱼骨
		/// </summary>
		public static FoodItem Xianhuanglu2 => Instance[(short)176];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static Food Instance = new Food();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "ItemSubType", "GroupId", "Desc", "FunctionDesc", "ResourceType", "BreakBonusEffect", "TaskLock", "FoodType", "TemplateId",
		"Grade", "Icon", "BigIcon", "BaseWeight", "BaseHappinessChange", "DropRate"
	};

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new FoodItem(0, LocalStringManager.GetConfig("Food_language", "Name_0"), 7, 700, 0, 0, "icon_Food_yeguo", "bigIcon_Food_yeguo", LocalStringManager.GetConfig("Food_language", "Desc_0"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_0"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 10, 50, 0, 1, 600, 3, allowRandomCreate: true, 50, isSpecial: false, 0, 3, 35, new List<int>(), 1, 1, new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 0, 0, 0, 0, 0, 0, 25, 25, 25, 25, 0, 0, 25, 25, 25, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(1, LocalStringManager.GetConfig("Food_language", "Name_1"), 7, 700, 1, 0, "icon_Food_yali", "bigIcon_Food_yali", LocalStringManager.GetConfig("Food_language", "Desc_1"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_1"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 100, 0, 2, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 3, 35, new List<int>(), 1, 1, new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 0, 0, 0, 0, 0, 0, 30, 30, 30, 30, 0, 0, 30, 30, 30, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(2, LocalStringManager.GetConfig("Food_language", "Name_2"), 7, 700, 2, 0, "icon_Food_jinganju", "bigIcon_Food_jinganju", LocalStringManager.GetConfig("Food_language", "Desc_2"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_2"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 10, 300, 0, 3, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 35, new List<int>(), 1, 1, new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 0, 0, 0, 0, 0, 0, 35, 35, 35, 35, 0, 0, 35, 35, 35, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(3, LocalStringManager.GetConfig("Food_language", "Name_3"), 7, 700, 3, 0, "icon_Food_haitangguo", "bigIcon_Food_haitangguo", LocalStringManager.GetConfig("Food_language", "Desc_3"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_3"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 10, 750, 0, 4, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 35, new List<int>(), 1, 1, new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 0, 0, 0, 0, 0, 0, 40, 40, 40, 40, 0, 0, 40, 40, 40, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(4, LocalStringManager.GetConfig("Food_language", "Name_4"), 7, 700, 4, 0, "icon_Food_wuseputao", "bigIcon_Food_wuseputao", LocalStringManager.GetConfig("Food_language", "Desc_4"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_4"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 1550, 1, 5, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 35, new List<int>(), 1, 1, new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 0, 0, 0, 0, 0, 0, 45, 45, 45, 45, 0, 0, 45, 45, 45, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(5, LocalStringManager.GetConfig("Food_language", "Name_5"), 7, 700, 5, 0, "icon_Food_lizhi", "bigIcon_Food_lizhi", LocalStringManager.GetConfig("Food_language", "Desc_5"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_5"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 10, 2800, 2, 6, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 35, new List<int>(), 1, 1, new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 0, 0, 0, 0, 0, 0, 50, 50, 50, 50, 0, 0, 50, 50, 50, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(6, LocalStringManager.GetConfig("Food_language", "Name_6"), 7, 700, 6, 0, "icon_Food_yeshiliu", "bigIcon_Food_yeshiliu", LocalStringManager.GetConfig("Food_language", "Desc_6"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_6"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 4600, 3, 7, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 35, new List<int>(), 1, 1, new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 0, 0, 0, 0, 0, 0, 60, 60, 60, 60, 0, 0, 60, 60, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(7, LocalStringManager.GetConfig("Food_language", "Name_7"), 7, 700, 7, 0, "icon_Food_renshenguo", "bigIcon_Food_renshenguo", LocalStringManager.GetConfig("Food_language", "Desc_7"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_7"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 7050, 4, 8, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 35, new List<int>(), 1, 1, new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 0, 0, 0, 0, 0, 0, 75, 75, 75, 75, 0, 0, 75, 75, 75, 75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(8, LocalStringManager.GetConfig("Food_language", "Name_8"), 7, 700, 8, 0, "icon_Food_pantaoxianguo", "bigIcon_Food_pantaoxianguo", LocalStringManager.GetConfig("Food_language", "Desc_8"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_8"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 10250, 5, 9, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 35, new List<int>(), 1, 1, new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 0, 0, 0, 0, 0, 0, 95, 95, 95, 95, 0, 0, 95, 95, 95, 95, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(9, LocalStringManager.GetConfig("Food_language", "Name_9"), 7, 701, 0, 9, "icon_Food_qingzhujidan", "bigIcon_Food_qingzhujidan", LocalStringManager.GetConfig("Food_language", "Desc_9"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_9"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 10, 50, 0, 2, 600, 3, allowRandomCreate: true, 50, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(10, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Egg
		}));
		_dataArray.Add(new FoodItem(10, LocalStringManager.GetConfig("Food_language", "Name_10"), 7, 701, 1, 9, "icon_Food_hebaodan", "bigIcon_Food_hebaodan", LocalStringManager.GetConfig("Food_language", "Desc_10"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_10"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 10, 100, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(15, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Egg
		}));
		_dataArray.Add(new FoodItem(11, LocalStringManager.GetConfig("Food_language", "Name_11"), 7, 701, 2, 9, "icon_Food_danchaofan", "bigIcon_Food_danchaofan", LocalStringManager.GetConfig("Food_language", "Desc_11"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_11"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(20, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Egg,
			EFoodFoodType.Rice
		}));
		_dataArray.Add(new FoodItem(12, LocalStringManager.GetConfig("Food_language", "Name_12"), 7, 701, 3, 9, "icon_Food_yangzhouchaofan", "bigIcon_Food_yangzhouchaofan", LocalStringManager.GetConfig("Food_language", "Desc_12"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_12"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(25, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Egg,
			EFoodFoodType.Rice
		}));
		_dataArray.Add(new FoodItem(13, LocalStringManager.GetConfig("Food_language", "Name_13"), 7, 701, 4, 9, "icon_Food_danhuadiancuitang", "bigIcon_Food_danhuadiancuitang", LocalStringManager.GetConfig("Food_language", "Desc_13"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_13"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(30, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Egg,
			EFoodFoodType.Soup
		}));
		_dataArray.Add(new FoodItem(14, LocalStringManager.GetConfig("Food_language", "Name_14"), 7, 701, 5, 9, "icon_Food_sansidanjuan", "bigIcon_Food_sansidanjuan", LocalStringManager.GetConfig("Food_language", "Desc_14"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_14"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(35, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Egg,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(15, LocalStringManager.GetConfig("Food_language", "Name_15"), 7, 701, 6, 9, "icon_Food_wuhuangdan", "bigIcon_Food_wuhuangdan", LocalStringManager.GetConfig("Food_language", "Desc_15"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_15"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 10, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(40, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Egg
		}));
		_dataArray.Add(new FoodItem(16, LocalStringManager.GetConfig("Food_language", "Name_16"), 7, 701, 7, 9, "icon_Food_tiandiyikouxiang", "bigIcon_Food_tiandiyikouxiang", LocalStringManager.GetConfig("Food_language", "Desc_16"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_16"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 10, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(45, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Egg
		}));
		_dataArray.Add(new FoodItem(17, LocalStringManager.GetConfig("Food_language", "Name_17"), 7, 701, 8, 9, "icon_Food_jinpaofan", "bigIcon_Food_jinpaofan", LocalStringManager.GetConfig("Food_language", "Desc_17"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_17"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(50, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Egg,
			EFoodFoodType.Rice
		}));
		_dataArray.Add(new FoodItem(18, LocalStringManager.GetConfig("Food_language", "Name_18"), 7, 701, 1, 18, "icon_Food_jiaohuaji", "bigIcon_Food_jiaohuaji", LocalStringManager.GetConfig("Food_language", "Desc_18"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_18"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 100, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 20, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(19, LocalStringManager.GetConfig("Food_language", "Name_19"), 7, 701, 2, 18, "icon_Food_babeiji", "bigIcon_Food_babeiji", LocalStringManager.GetConfig("Food_language", "Desc_19"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_19"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 25, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(20, LocalStringManager.GetConfig("Food_language", "Name_20"), 7, 701, 3, 18, "icon_Food_jiangbaojiding", "bigIcon_Food_jiangbaojiding", LocalStringManager.GetConfig("Food_language", "Desc_20"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_20"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 30, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(21, LocalStringManager.GetConfig("Food_language", "Name_21"), 7, 701, 4, 18, "icon_Food_wuweixinglaoji", "bigIcon_Food_wuweixinglaoji", LocalStringManager.GetConfig("Food_language", "Desc_21"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_21"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 35, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(22, LocalStringManager.GetConfig("Food_language", "Name_22"), 7, 701, 5, 18, "icon_Food_huangjinji", "bigIcon_Food_huangjinji", LocalStringManager.GetConfig("Food_language", "Desc_22"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_22"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 40, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Egg
		}));
		_dataArray.Add(new FoodItem(23, LocalStringManager.GetConfig("Food_language", "Name_23"), 7, 701, 6, 18, "icon_Food_furongjipian", "bigIcon_Food_furongjipian", LocalStringManager.GetConfig("Food_language", "Desc_23"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_23"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 45, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Flower
		}));
		_dataArray.Add(new FoodItem(24, LocalStringManager.GetConfig("Food_language", "Name_24"), 7, 701, 7, 18, "icon_Food_baizhanxiangyaji", "bigIcon_Food_baizhanxiangyaji", LocalStringManager.GetConfig("Food_language", "Desc_24"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_24"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 50, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(25, LocalStringManager.GetConfig("Food_language", "Name_25"), 7, 701, 8, 18, "icon_Food_naixiangxinfaji", "bigIcon_Food_naixiangxinfaji", LocalStringManager.GetConfig("Food_language", "Desc_25"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_25"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 55, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(26, LocalStringManager.GetConfig("Food_language", "Name_26"), 7, 701, 2, 26, "icon_Food_zhiya", "bigIcon_Food_zhiya", LocalStringManager.GetConfig("Food_language", "Desc_26"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_26"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 50, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 30, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(27, LocalStringManager.GetConfig("Food_language", "Name_27"), 7, 701, 3, 26, "icon_Food_huluya", "bigIcon_Food_huluya", LocalStringManager.GetConfig("Food_language", "Desc_27"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_27"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 60, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 35, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(28, LocalStringManager.GetConfig("Food_language", "Name_28"), 7, 701, 4, 26, "icon_Food_zhaojunya", "bigIcon_Food_zhaojunya", LocalStringManager.GetConfig("Food_language", "Desc_28"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_28"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 50, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 40, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Rice,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(29, LocalStringManager.GetConfig("Food_language", "Name_29"), 7, 701, 5, 26, "icon_Food_shouziyageng", "bigIcon_Food_shouziyageng", LocalStringManager.GetConfig("Food_language", "Desc_29"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_29"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 45, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(30, LocalStringManager.GetConfig("Food_language", "Name_30"), 7, 701, 6, 26, "icon_Food_meixuexifen", "bigIcon_Food_meixuexifen", LocalStringManager.GetConfig("Food_language", "Desc_30"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_30"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 50, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Rice
		}));
		_dataArray.Add(new FoodItem(31, LocalStringManager.GetConfig("Food_language", "Name_31"), 7, 701, 7, 26, "icon_Food_taibaiya", "bigIcon_Food_taibaiya", LocalStringManager.GetConfig("Food_language", "Desc_31"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_31"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 50, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 55, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Wine
		}));
		_dataArray.Add(new FoodItem(32, LocalStringManager.GetConfig("Food_language", "Name_32"), 7, 701, 8, 26, "icon_Food_jinlingyanshuiya", "bigIcon_Food_jinlingyanshuiya", LocalStringManager.GetConfig("Food_language", "Desc_32"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_32"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 60, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(33, LocalStringManager.GetConfig("Food_language", "Name_33"), 7, 701, 3, 33, "icon_Food_efenqian", "bigIcon_Food_efenqian", LocalStringManager.GetConfig("Food_language", "Desc_33"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_33"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(40, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(34, LocalStringManager.GetConfig("Food_language", "Name_34"), 7, 701, 4, 33, "icon_Food_xiuchuie", "bigIcon_Food_xiuchuie", LocalStringManager.GetConfig("Food_language", "Desc_34"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_34"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 50, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(45, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(35, LocalStringManager.GetConfig("Food_language", "Name_35"), 7, 701, 5, 33, "icon_Food_jiuweicuipie", "bigIcon_Food_jiuweicuipie", LocalStringManager.GetConfig("Food_language", "Desc_35"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_35"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 60, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(50, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(36, LocalStringManager.GetConfig("Food_language", "Name_36"), 7, 701, 6, 33, "icon_Food_jiansunzhenge", "bigIcon_Food_jiansunzhenge", LocalStringManager.GetConfig("Food_language", "Desc_36"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_36"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 50, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(55, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(37, LocalStringManager.GetConfig("Food_language", "Name_37"), 7, 701, 7, 33, "icon_Food_xiangsutiane", "bigIcon_Food_xiangsutiane", LocalStringManager.GetConfig("Food_language", "Desc_37"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_37"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 60, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(60, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(38, LocalStringManager.GetConfig("Food_language", "Name_38"), 7, 701, 8, 33, "icon_Food_baizhachune", "bigIcon_Food_baizhachune", LocalStringManager.GetConfig("Food_language", "Desc_38"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_38"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 50, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(65, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(39, LocalStringManager.GetConfig("Food_language", "Name_39"), 7, 701, 4, 39, "icon_Food_wuyisu", "bigIcon_Food_wuyisu", LocalStringManager.GetConfig("Food_language", "Desc_39"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_39"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 50, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(40, LocalStringManager.GetConfig("Food_language", "Name_40"), 7, 701, 5, 39, "icon_Food_renshenwujitang", "bigIcon_Food_renshenwujitang", LocalStringManager.GetConfig("Food_language", "Desc_40"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_40"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 55, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Soup
		}));
		_dataArray.Add(new FoodItem(41, LocalStringManager.GetConfig("Food_language", "Name_41"), 7, 701, 6, 39, "icon_Food_wudaitaoji", "bigIcon_Food_wudaitaoji", LocalStringManager.GetConfig("Food_language", "Desc_41"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_41"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 50, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 60, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(42, LocalStringManager.GetConfig("Food_language", "Name_42"), 7, 701, 7, 39, "icon_Food_chongcaowujitang", "bigIcon_Food_chongcaowujitang", LocalStringManager.GetConfig("Food_language", "Desc_42"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_42"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 65, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Soup
		}));
		_dataArray.Add(new FoodItem(43, LocalStringManager.GetConfig("Food_language", "Name_43"), 7, 701, 8, 39, "icon_Food_jinzhiwuwan", "bigIcon_Food_jinzhiwuwan", LocalStringManager.GetConfig("Food_language", "Desc_43"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_43"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 70, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(44, LocalStringManager.GetConfig("Food_language", "Name_44"), 7, 701, 5, 44, "icon_Food_zhagaochunzi", "bigIcon_Food_zhagaochunzi", LocalStringManager.GetConfig("Food_language", "Desc_44"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_44"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 10, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 60, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(45, LocalStringManager.GetConfig("Food_language", "Name_45"), 7, 701, 6, 44, "icon_Food_aoyinchun", "bigIcon_Food_aoyinchun", LocalStringManager.GetConfig("Food_language", "Desc_45"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_45"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 65, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(46, LocalStringManager.GetConfig("Food_language", "Name_46"), 7, 701, 7, 44, "icon_Food_bainiaoguichao", "bigIcon_Food_bainiaoguichao", LocalStringManager.GetConfig("Food_language", "Desc_46"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_46"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 70, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(47, LocalStringManager.GetConfig("Food_language", "Name_47"), 7, 701, 8, 44, "icon_Food_qiankunguo", "bigIcon_Food_qiankunguo", LocalStringManager.GetConfig("Food_language", "Desc_47"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_47"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 75, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(48, LocalStringManager.GetConfig("Food_language", "Name_48"), 7, 701, 6, 48, "icon_Food_fengchuanhua", "bigIcon_Food_fengchuanhua", LocalStringManager.GetConfig("Food_language", "Desc_48"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_48"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 70, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Flower
		}));
		_dataArray.Add(new FoodItem(49, LocalStringManager.GetConfig("Food_language", "Name_49"), 7, 701, 7, 48, "icon_Food_fuguiwucaihui", "bigIcon_Food_fuguiwucaihui", LocalStringManager.GetConfig("Food_language", "Desc_49"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_49"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 75, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(50, LocalStringManager.GetConfig("Food_language", "Name_50"), 7, 701, 8, 48, "icon_Food_chenlutang", "bigIcon_Food_chenlutang", LocalStringManager.GetConfig("Food_language", "Desc_50"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_50"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 80, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(51, LocalStringManager.GetConfig("Food_language", "Name_51"), 7, 701, 0, 51, "icon_Food_tankaoturou", "bigIcon_Food_tankaoturou", LocalStringManager.GetConfig("Food_language", "Desc_51"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_51"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 50, 0, 2, 600, 3, allowRandomCreate: true, 50, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 10, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(52, LocalStringManager.GetConfig("Food_language", "Name_52"), 7, 701, 1, 51, "icon_Food_lengchitu", "bigIcon_Food_lengchitu", LocalStringManager.GetConfig("Food_language", "Desc_52"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_52"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 100, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 15, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(53, LocalStringManager.GetConfig("Food_language", "Name_53"), 7, 701, 2, 51, "icon_Food_malatutou", "bigIcon_Food_malatutou", LocalStringManager.GetConfig("Food_language", "Desc_53"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_53"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 20, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(54, LocalStringManager.GetConfig("Food_language", "Name_54"), 7, 701, 3, 51, "icon_Food_xianguotu", "bigIcon_Food_xianguotu", LocalStringManager.GetConfig("Food_language", "Desc_54"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_54"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 25, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(55, LocalStringManager.GetConfig("Food_language", "Name_55"), 7, 701, 4, 51, "icon_Food_baiweigeng", "bigIcon_Food_baiweigeng", LocalStringManager.GetConfig("Food_language", "Desc_55"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_55"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 30, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(56, LocalStringManager.GetConfig("Food_language", "Name_56"), 7, 701, 5, 51, "icon_Food_huokaowuweitu", "bigIcon_Food_huokaowuweitu", LocalStringManager.GetConfig("Food_language", "Desc_56"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_56"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 35, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(57, LocalStringManager.GetConfig("Food_language", "Name_57"), 7, 701, 6, 51, "icon_Food_yingxisuantiao", "bigIcon_Food_yingxisuantiao", LocalStringManager.GetConfig("Food_language", "Desc_57"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_57"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 40, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(58, LocalStringManager.GetConfig("Food_language", "Name_58"), 7, 701, 7, 51, "icon_Food_yutugeng", "bigIcon_Food_yutugeng", LocalStringManager.GetConfig("Food_language", "Desc_58"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_58"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 45, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(59, LocalStringManager.GetConfig("Food_language", "Name_59"), 7, 701, 8, 51, "icon_Food_boxiagong", "bigIcon_Food_boxiagong", LocalStringManager.GetConfig("Food_language", "Desc_59"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_59"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 50, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new FoodItem(60, LocalStringManager.GetConfig("Food_language", "Name_60"), 7, 701, 1, 60, "icon_Food_huiguorou", "bigIcon_Food_huiguorou", LocalStringManager.GetConfig("Food_language", "Desc_60"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_60"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 100, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(20, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(61, LocalStringManager.GetConfig("Food_language", "Name_61"), 7, 701, 2, 60, "icon_Food_heyefenzhengrou", "bigIcon_Food_heyefenzhengrou", LocalStringManager.GetConfig("Food_language", "Desc_61"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_61"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(25, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Rice
		}));
		_dataArray.Add(new FoodItem(62, LocalStringManager.GetConfig("Food_language", "Name_62"), 7, 701, 3, 60, "icon_Food_meicaikourou", "bigIcon_Food_meicaikourou", LocalStringManager.GetConfig("Food_language", "Desc_62"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_62"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(30, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(63, LocalStringManager.GetConfig("Food_language", "Name_63"), 7, 701, 4, 60, "icon_Food_jiuzhuandachang", "bigIcon_Food_jiuzhuandachang", LocalStringManager.GetConfig("Food_language", "Desc_63"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_63"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(35, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(64, LocalStringManager.GetConfig("Food_language", "Name_64"), 7, 701, 5, 60, "icon_Food_cunjingu", "bigIcon_Food_cunjingu", LocalStringManager.GetConfig("Food_language", "Desc_64"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_64"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(40, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(65, LocalStringManager.GetConfig("Food_language", "Name_65"), 7, 701, 6, 60, "icon_Food_shuijingyaorou", "bigIcon_Food_shuijingyaorou", LocalStringManager.GetConfig("Food_language", "Desc_65"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_65"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(45, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(66, LocalStringManager.GetConfig("Food_language", "Name_66"), 7, 701, 7, 60, "icon_Food_xiefenshizitou", "bigIcon_Food_xiefenshizitou", LocalStringManager.GetConfig("Food_language", "Desc_66"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_66"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(50, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(67, LocalStringManager.GetConfig("Food_language", "Name_67"), 7, 701, 8, 60, "icon_Food_dongporou", "bigIcon_Food_dongporou", LocalStringManager.GetConfig("Food_language", "Desc_67"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_67"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(55, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Wine
		}));
		_dataArray.Add(new FoodItem(68, LocalStringManager.GetConfig("Food_language", "Name_68"), 7, 701, 2, 68, "icon_Food_ximoyangshenghui", "bigIcon_Food_ximoyangshenghui", LocalStringManager.GetConfig("Food_language", "Desc_68"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_68"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 30, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(69, LocalStringManager.GetConfig("Food_language", "Name_69"), 7, 701, 3, 68, "icon_Food_yangzawu", "bigIcon_Food_yangzawu", LocalStringManager.GetConfig("Food_language", "Desc_69"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_69"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 35, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(70, LocalStringManager.GetConfig("Food_language", "Name_70"), 7, 701, 4, 68, "icon_Food_congbayangrou", "bigIcon_Food_congbayangrou", LocalStringManager.GetConfig("Food_language", "Desc_70"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_70"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 50, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 40, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(71, LocalStringManager.GetConfig("Food_language", "Name_71"), 7, 701, 5, 68, "icon_Food_shaguosandan", "bigIcon_Food_shaguosandan", LocalStringManager.GetConfig("Food_language", "Desc_71"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_71"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 45, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(72, LocalStringManager.GetConfig("Food_language", "Name_72"), 7, 701, 6, 68, "icon_Food_huokaoyangyao", "bigIcon_Food_huokaoyangyao", LocalStringManager.GetConfig("Food_language", "Desc_72"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_72"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 50, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(73, LocalStringManager.GetConfig("Food_language", "Name_73"), 7, 701, 7, 68, "icon_Food_xiaolingzhi", "bigIcon_Food_xiaolingzhi", LocalStringManager.GetConfig("Food_language", "Desc_73"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_73"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 55, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(74, LocalStringManager.GetConfig("Food_language", "Name_74"), 7, 701, 8, 68, "icon_Food_yangfangcangyu", "bigIcon_Food_yangfangcangyu", LocalStringManager.GetConfig("Food_language", "Desc_74"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_74"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 50, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 60, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(75, LocalStringManager.GetConfig("Food_language", "Name_75"), 7, 701, 3, 75, "icon_Food_sheyaoque", "bigIcon_Food_sheyaoque", LocalStringManager.GetConfig("Food_language", "Desc_75"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_75"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 40, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Bird
		}));
		_dataArray.Add(new FoodItem(76, LocalStringManager.GetConfig("Food_language", "Name_76"), 7, 701, 4, 75, "icon_Food_zaoshaozuishe", "bigIcon_Food_zaoshaozuishe", LocalStringManager.GetConfig("Food_language", "Desc_76"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_76"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 45, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Wine
		}));
		_dataArray.Add(new FoodItem(77, LocalStringManager.GetConfig("Food_language", "Name_77"), 7, 701, 5, 75, "icon_Food_longzigeng", "bigIcon_Food_longzigeng", LocalStringManager.GetConfig("Food_language", "Desc_77"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_77"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 50, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(78, LocalStringManager.GetConfig("Food_language", "Name_78"), 7, 701, 6, 75, "icon_Food_yaozhuguishehui", "bigIcon_Food_yaozhuguishehui", LocalStringManager.GetConfig("Food_language", "Desc_78"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_78"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 55, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(79, LocalStringManager.GetConfig("Food_language", "Name_79"), 7, 701, 7, 75, "icon_Food_mudanniangshefu", "bigIcon_Food_mudanniangshefu", LocalStringManager.GetConfig("Food_language", "Desc_79"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_79"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 60, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Flower
		}));
		_dataArray.Add(new FoodItem(80, LocalStringManager.GetConfig("Food_language", "Name_80"), 7, 701, 8, 75, "icon_Food_longhudou", "bigIcon_Food_longhudou", LocalStringManager.GetConfig("Food_language", "Desc_80"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_80"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 65, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(81, LocalStringManager.GetConfig("Food_language", "Name_81"), 7, 701, 4, 81, "icon_Food_qingcuanlurou", "bigIcon_Food_qingcuanlurou", LocalStringManager.GetConfig("Food_language", "Desc_81"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_81"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 50, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(82, LocalStringManager.GetConfig("Food_language", "Name_82"), 7, 701, 5, 81, "icon_Food_ganlugeng", "bigIcon_Food_ganlugeng", LocalStringManager.GetConfig("Food_language", "Desc_82"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_82"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 55, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(83, LocalStringManager.GetConfig("Food_language", "Name_83"), 7, 701, 6, 81, "icon_Food_sanshengmeihuatang", "bigIcon_Food_sanshengmeihuatang", LocalStringManager.GetConfig("Food_language", "Desc_83"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_83"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 60, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Fruit,
			EFoodFoodType.Soup
		}));
		_dataArray.Add(new FoodItem(84, LocalStringManager.GetConfig("Food_language", "Name_84"), 7, 701, 7, 81, "icon_Food_lurouyubaigeng", "bigIcon_Food_lurouyubaigeng", LocalStringManager.GetConfig("Food_language", "Desc_84"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_84"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 65, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(85, LocalStringManager.GetConfig("Food_language", "Name_85"), 7, 701, 8, 81, "icon_Food_yudinglu", "bigIcon_Food_yudinglu", LocalStringManager.GetConfig("Food_language", "Desc_85"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_85"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 70, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(86, LocalStringManager.GetConfig("Food_language", "Name_86"), 7, 701, 5, 86, "icon_Food_xiangbazhi", "bigIcon_Food_xiangbazhi", LocalStringManager.GetConfig("Food_language", "Desc_86"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_86"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 60, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(60, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(87, LocalStringManager.GetConfig("Food_language", "Name_87"), 7, 701, 6, 86, "icon_Food_jinsixiangba", "bigIcon_Food_jinsixiangba", LocalStringManager.GetConfig("Food_language", "Desc_87"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_87"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 60, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(65, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(88, LocalStringManager.GetConfig("Food_language", "Name_88"), 7, 701, 7, 86, "icon_Food_longnaohai", "bigIcon_Food_longnaohai", LocalStringManager.GetConfig("Food_language", "Desc_88"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_88"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 60, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(70, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(89, LocalStringManager.GetConfig("Food_language", "Name_89"), 7, 701, 8, 86, "icon_Food_ziyujiangxiangba", "bigIcon_Food_ziyujiangxiangba", LocalStringManager.GetConfig("Food_language", "Desc_89"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_89"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 60, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(75, 0, 0, 0, 0, 0), 0, 0, 0, 0, 0, 0, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Wine
		}));
		_dataArray.Add(new FoodItem(90, LocalStringManager.GetConfig("Food_language", "Name_90"), 7, 701, 6, 90, "icon_Food_baxiongzhang", "bigIcon_Food_baxiongzhang", LocalStringManager.GetConfig("Food_language", "Desc_90"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_90"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 80, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 70, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(91, LocalStringManager.GetConfig("Food_language", "Name_91"), 7, 701, 7, 90, "icon_Food_babaoxiongzhang", "bigIcon_Food_babaoxiongzhang", LocalStringManager.GetConfig("Food_language", "Desc_91"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_91"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 80, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 75, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast
		}));
		_dataArray.Add(new FoodItem(92, LocalStringManager.GetConfig("Food_language", "Name_92"), 7, 701, 8, 90, "icon_Food_yipindawangzhang", "bigIcon_Food_yipindawangzhang", LocalStringManager.GetConfig("Food_language", "Desc_92"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_92"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 80, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 80, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Beast,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(93, LocalStringManager.GetConfig("Food_language", "Name_93"), 7, 700, 0, 93, "icon_Food_chuibing", "bigIcon_Food_chuibing", LocalStringManager.GetConfig("Food_language", "Desc_93"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_93"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 50, 0, 2, 600, 3, allowRandomCreate: true, 50, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 10, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(94, LocalStringManager.GetConfig("Food_language", "Name_94"), 7, 700, 1, 93, "icon_Food_yangchunmian", "bigIcon_Food_yangchunmian", LocalStringManager.GetConfig("Food_language", "Desc_94"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_94"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 100, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 15, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(95, LocalStringManager.GetConfig("Food_language", "Name_95"), 7, 700, 2, 93, "icon_Food_sisemantou", "bigIcon_Food_sisemantou", LocalStringManager.GetConfig("Food_language", "Desc_95"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_95"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 20, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(96, LocalStringManager.GetConfig("Food_language", "Name_96"), 7, 700, 3, 93, "icon_Food_furongbing", "bigIcon_Food_furongbing", LocalStringManager.GetConfig("Food_language", "Desc_96"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_96"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 25, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Noodle,
			EFoodFoodType.Flower
		}));
		_dataArray.Add(new FoodItem(97, LocalStringManager.GetConfig("Food_language", "Name_97"), 7, 700, 4, 93, "icon_Food_zaoguheyebing", "bigIcon_Food_zaoguheyebing", LocalStringManager.GetConfig("Food_language", "Desc_97"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_97"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 30, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(98, LocalStringManager.GetConfig("Food_language", "Name_98"), 7, 700, 5, 93, "icon_Food_jinyinmudanbing", "bigIcon_Food_jinyinmudanbing", LocalStringManager.GetConfig("Food_language", "Desc_98"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_98"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 35, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(99, LocalStringManager.GetConfig("Food_language", "Name_99"), 7, 700, 6, 93, "icon_Food_zimuchunjian", "bigIcon_Food_zimuchunjian", LocalStringManager.GetConfig("Food_language", "Desc_99"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_99"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 40, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(100, LocalStringManager.GetConfig("Food_language", "Name_100"), 7, 700, 7, 93, "icon_Food_yingtaobiluo", "bigIcon_Food_yingtaobiluo", LocalStringManager.GetConfig("Food_language", "Desc_100"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_100"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 45, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Noodle,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(101, LocalStringManager.GetConfig("Food_language", "Name_101"), 7, 700, 8, 93, "icon_Food_shoudaiguixiantao", "bigIcon_Food_shoudaiguixiantao", LocalStringManager.GetConfig("Food_language", "Desc_101"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_101"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 50, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(102, LocalStringManager.GetConfig("Food_language", "Name_102"), 7, 700, 1, 102, "icon_Food_shengjiandoufu", "bigIcon_Food_shengjiandoufu", LocalStringManager.GetConfig("Food_language", "Desc_102"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_102"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 100, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 20), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Bean
		}));
		_dataArray.Add(new FoodItem(103, LocalStringManager.GetConfig("Food_language", "Name_103"), 7, 700, 2, 102, "icon_Food_doufuqingtang", "bigIcon_Food_doufuqingtang", LocalStringManager.GetConfig("Food_language", "Desc_103"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_103"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 25), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Bean,
			EFoodFoodType.Soup
		}));
		_dataArray.Add(new FoodItem(104, LocalStringManager.GetConfig("Food_language", "Name_104"), 7, 700, 3, 102, "icon_Food_yuxiangdoufu", "bigIcon_Food_yuxiangdoufu", LocalStringManager.GetConfig("Food_language", "Desc_104"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_104"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 30), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Bean
		}));
		_dataArray.Add(new FoodItem(105, LocalStringManager.GetConfig("Food_language", "Name_105"), 7, 700, 4, 102, "icon_Food_shangtangbaiyu", "bigIcon_Food_shangtangbaiyu", LocalStringManager.GetConfig("Food_language", "Desc_105"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_105"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 35), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Bean,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(106, LocalStringManager.GetConfig("Food_language", "Name_106"), 7, 700, 5, 102, "icon_Food_wensidoufu", "bigIcon_Food_wensidoufu", LocalStringManager.GetConfig("Food_language", "Desc_106"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_106"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 40), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Bean
		}));
		_dataArray.Add(new FoodItem(107, LocalStringManager.GetConfig("Food_language", "Name_107"), 7, 700, 6, 102, "icon_Food_yipindoufu", "bigIcon_Food_yipindoufu", LocalStringManager.GetConfig("Food_language", "Desc_107"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_107"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 45), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Bean
		}));
		_dataArray.Add(new FoodItem(108, LocalStringManager.GetConfig("Food_language", "Name_108"), 7, 700, 7, 102, "icon_Food_dongpodoufu", "bigIcon_Food_dongpodoufu", LocalStringManager.GetConfig("Food_language", "Desc_108"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_108"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 50), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Bean
		}));
		_dataArray.Add(new FoodItem(109, LocalStringManager.GetConfig("Food_language", "Name_109"), 7, 700, 8, 102, "icon_Food_baibiqingyun", "bigIcon_Food_baibiqingyun", LocalStringManager.GetConfig("Food_language", "Desc_109"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_109"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 55), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Bean,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(110, LocalStringManager.GetConfig("Food_language", "Name_110"), 7, 700, 2, 110, "icon_Food_xianggulengtao", "bigIcon_Food_xianggulengtao", LocalStringManager.GetConfig("Food_language", "Desc_110"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_110"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 30, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Mushroom
		}));
		_dataArray.Add(new FoodItem(111, LocalStringManager.GetConfig("Food_language", "Name_111"), 7, 700, 3, 110, "icon_Food_yinerxianggutang", "bigIcon_Food_yinerxianggutang", LocalStringManager.GetConfig("Food_language", "Desc_111"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_111"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 35, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Mushroom,
			EFoodFoodType.Soup
		}));
		_dataArray.Add(new FoodItem(112, LocalStringManager.GetConfig("Food_language", "Name_112"), 7, 700, 4, 110, "icon_Food_zacaigeng", "bigIcon_Food_zacaigeng", LocalStringManager.GetConfig("Food_language", "Desc_112"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_112"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 40, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Mushroom,
			EFoodFoodType.Vegetable,
			EFoodFoodType.Rice,
			EFoodFoodType.Soup
		}));
		_dataArray.Add(new FoodItem(113, LocalStringManager.GetConfig("Food_language", "Name_113"), 7, 700, 5, 110, "icon_Food_mizhishuijinggu", "bigIcon_Food_mizhishuijinggu", LocalStringManager.GetConfig("Food_language", "Desc_113"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_113"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 45, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Mushroom
		}));
		_dataArray.Add(new FoodItem(114, LocalStringManager.GetConfig("Food_language", "Name_114"), 7, 700, 6, 110, "icon_Food_taijitang", "bigIcon_Food_taijitang", LocalStringManager.GetConfig("Food_language", "Desc_114"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_114"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 50, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Mushroom,
			EFoodFoodType.Egg
		}));
		_dataArray.Add(new FoodItem(115, LocalStringManager.GetConfig("Food_language", "Name_115"), 7, 700, 7, 110, "icon_Food_banyuechenjiang", "bigIcon_Food_banyuechenjiang", LocalStringManager.GetConfig("Food_language", "Desc_115"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_115"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 55, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Mushroom,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(116, LocalStringManager.GetConfig("Food_language", "Name_116"), 7, 700, 8, 110, "icon_Food_luohanzhai", "bigIcon_Food_luohanzhai", LocalStringManager.GetConfig("Food_language", "Desc_116"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_116"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 60, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Mushroom,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(117, LocalStringManager.GetConfig("Food_language", "Name_117"), 7, 700, 3, 117, "icon_Food_qinggongniangsun", "bigIcon_Food_qinggongniangsun", LocalStringManager.GetConfig("Food_language", "Desc_117"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_117"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 40, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(118, LocalStringManager.GetConfig("Food_language", "Name_118"), 7, 700, 4, 117, "icon_Food_shangsushijin", "bigIcon_Food_shangsushijin", LocalStringManager.GetConfig("Food_language", "Desc_118"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_118"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 45, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(119, LocalStringManager.GetConfig("Food_language", "Name_119"), 7, 700, 5, 117, "icon_Food_sansebiqingsi", "bigIcon_Food_sansebiqingsi", LocalStringManager.GetConfig("Food_language", "Desc_119"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_119"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 50, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Vegetable
		}));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new FoodItem(120, LocalStringManager.GetConfig("Food_language", "Name_120"), 7, 700, 6, 117, "icon_Food_litanggeng", "bigIcon_Food_litanggeng", LocalStringManager.GetConfig("Food_language", "Desc_120"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_120"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 55, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(121, LocalStringManager.GetConfig("Food_language", "Name_121"), 7, 700, 7, 117, "icon_Food_shisetougeng", "bigIcon_Food_shisetougeng", LocalStringManager.GetConfig("Food_language", "Desc_121"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_121"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 60, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(122, LocalStringManager.GetConfig("Food_language", "Name_122"), 7, 700, 8, 117, "icon_Food_shisuifeicuita", "bigIcon_Food_shisuifeicuita", LocalStringManager.GetConfig("Food_language", "Desc_122"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_122"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 65, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(123, LocalStringManager.GetConfig("Food_language", "Name_123"), 7, 700, 4, 123, "icon_Food_lianzitougeng", "bigIcon_Food_lianzitougeng", LocalStringManager.GetConfig("Food_language", "Desc_123"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_123"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 50, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(124, LocalStringManager.GetConfig("Food_language", "Name_124"), 7, 700, 5, 123, "icon_Food_qingshuifozuo", "bigIcon_Food_qingshuifozuo", LocalStringManager.GetConfig("Food_language", "Desc_124"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_124"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 55, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Vegetable,
			EFoodFoodType.Rice
		}));
		_dataArray.Add(new FoodItem(125, LocalStringManager.GetConfig("Food_language", "Name_125"), 7, 700, 6, 123, "icon_Food_lianrongsutuo", "bigIcon_Food_lianrongsutuo", LocalStringManager.GetConfig("Food_language", "Desc_125"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_125"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 60, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Vegetable,
			EFoodFoodType.Noodle
		}));
		_dataArray.Add(new FoodItem(126, LocalStringManager.GetConfig("Food_language", "Name_126"), 7, 700, 7, 123, "icon_Food_bingtangxianglian", "bigIcon_Food_bingtangxianglian", LocalStringManager.GetConfig("Food_language", "Desc_126"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_126"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 65, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(127, LocalStringManager.GetConfig("Food_language", "Name_127"), 7, 700, 8, 123, "icon_Food_qibaoqizi", "bigIcon_Food_qibaoqizi", LocalStringManager.GetConfig("Food_language", "Desc_127"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_127"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 70, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Vegetable,
			EFoodFoodType.Rice
		}));
		_dataArray.Add(new FoodItem(128, LocalStringManager.GetConfig("Food_language", "Name_128"), 7, 700, 5, 128, "icon_Food_yurongbaiguo", "bigIcon_Food_yurongbaiguo", LocalStringManager.GetConfig("Food_language", "Desc_128"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_128"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 60), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(129, LocalStringManager.GetConfig("Food_language", "Name_129"), 7, 700, 6, 128, "icon_Food_yanwoyinxingzhou", "bigIcon_Food_yanwoyinxingzhou", LocalStringManager.GetConfig("Food_language", "Desc_129"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_129"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 65), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(130, LocalStringManager.GetConfig("Food_language", "Name_130"), 7, 700, 7, 128, "icon_Food_jinbozhenzhugeng", "bigIcon_Food_jinbozhenzhugeng", LocalStringManager.GetConfig("Food_language", "Desc_130"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_130"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 70), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(131, LocalStringManager.GetConfig("Food_language", "Name_131"), 7, 700, 8, 128, "icon_Food_shiliyinxing", "bigIcon_Food_shiliyinxing", LocalStringManager.GetConfig("Food_language", "Desc_131"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_131"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 75), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(132, LocalStringManager.GetConfig("Food_language", "Name_132"), 7, 700, 6, 132, "icon_Food_taiqingtang", "bigIcon_Food_taiqingtang", LocalStringManager.GetConfig("Food_language", "Desc_132"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_132"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 70, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Mushroom
		}));
		_dataArray.Add(new FoodItem(133, LocalStringManager.GetConfig("Food_language", "Name_133"), 7, 700, 7, 132, "icon_Food_yudaihoutougeng", "bigIcon_Food_yudaihoutougeng", LocalStringManager.GetConfig("Food_language", "Desc_133"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_133"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 75, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Mushroom
		}));
		_dataArray.Add(new FoodItem(134, LocalStringManager.GetConfig("Food_language", "Name_134"), 7, 700, 8, 132, "icon_Food_qiongjiangbaiyuantou", "bigIcon_Food_qiongjiangbaiyuantou", LocalStringManager.GetConfig("Food_language", "Desc_134"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_134"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 80, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Vegetarian,
			EFoodFoodType.Mushroom
		}));
		_dataArray.Add(new FoodItem(135, LocalStringManager.GetConfig("Food_language", "Name_135"), 7, 701, 0, 135, "icon_Food_luandunyupian", "bigIcon_Food_luandunyupian", LocalStringManager.GetConfig("Food_language", "Desc_135"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_135"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 50, 0, 2, 600, 3, allowRandomCreate: true, 50, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 10), 0, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(136, LocalStringManager.GetConfig("Food_language", "Name_136"), 7, 701, 1, 135, "icon_Food_hongshaoyu", "bigIcon_Food_hongshaoyu", LocalStringManager.GetConfig("Food_language", "Desc_136"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_136"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 100, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 15), 0, 0, 0, 0, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(137, LocalStringManager.GetConfig("Food_language", "Name_137"), 7, 701, 2, 135, "icon_Food_yubiaoersekuai", "bigIcon_Food_yubiaoersekuai", LocalStringManager.GetConfig("Food_language", "Desc_137"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_137"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 20), 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(138, LocalStringManager.GetConfig("Food_language", "Name_138"), 7, 701, 3, 135, "icon_Food_huokaohulayu", "bigIcon_Food_huokaohulayu", LocalStringManager.GetConfig("Food_language", "Desc_138"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_138"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 25), 0, 0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(139, LocalStringManager.GetConfig("Food_language", "Name_139"), 7, 701, 4, 135, "icon_Food_huadiaoguaiweiyu", "bigIcon_Food_huadiaoguaiweiyu", LocalStringManager.GetConfig("Food_language", "Desc_139"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_139"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 30), 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Wine
		}));
		_dataArray.Add(new FoodItem(140, LocalStringManager.GetConfig("Food_language", "Name_140"), 7, 701, 5, 135, "icon_Food_songsaoyugeng", "bigIcon_Food_songsaoyugeng", LocalStringManager.GetConfig("Food_language", "Desc_140"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_140"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 35), 0, 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(141, LocalStringManager.GetConfig("Food_language", "Name_141"), 7, 701, 6, 135, "icon_Food_shengzhigusuyu", "bigIcon_Food_shengzhigusuyu", LocalStringManager.GetConfig("Food_language", "Desc_141"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_141"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 40), 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(142, LocalStringManager.GetConfig("Food_language", "Name_142"), 7, 701, 7, 135, "icon_Food_xihucuyu", "bigIcon_Food_xihucuyu", LocalStringManager.GetConfig("Food_language", "Desc_142"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_142"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 45), 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(143, LocalStringManager.GetConfig("Food_language", "Name_143"), 7, 701, 8, 135, "icon_Food_dujuanzuiyu", "bigIcon_Food_dujuanzuiyu", LocalStringManager.GetConfig("Food_language", "Desc_143"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_143"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 50), 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(144, LocalStringManager.GetConfig("Food_language", "Name_144"), 7, 701, 1, 144, "icon_Food_baizhuoxia", "bigIcon_Food_baizhuoxia", LocalStringManager.GetConfig("Food_language", "Desc_144"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_144"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 100, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 20, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(145, LocalStringManager.GetConfig("Food_language", "Name_145"), 7, 701, 2, 144, "icon_Food_jiuzhiqingxia", "bigIcon_Food_jiuzhiqingxia", LocalStringManager.GetConfig("Food_language", "Desc_145"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_145"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 25, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Wine
		}));
		_dataArray.Add(new FoodItem(146, LocalStringManager.GetConfig("Food_language", "Name_146"), 7, 701, 3, 144, "icon_Food_gailaxia", "bigIcon_Food_gailaxia", LocalStringManager.GetConfig("Food_language", "Desc_146"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_146"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 30, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(147, LocalStringManager.GetConfig("Food_language", "Name_147"), 7, 701, 4, 144, "icon_Food_zisuxia", "bigIcon_Food_zisuxia", LocalStringManager.GetConfig("Food_language", "Desc_147"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_147"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 35, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(148, LocalStringManager.GetConfig("Food_language", "Name_148"), 7, 701, 5, 144, "icon_Food_yudaixiaren", "bigIcon_Food_yudaixiaren", LocalStringManager.GetConfig("Food_language", "Desc_148"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_148"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 40, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(149, LocalStringManager.GetConfig("Food_language", "Name_149"), 7, 701, 6, 144, "icon_Food_cuanwangchaoqingxia", "bigIcon_Food_cuanwangchaoqingxia", LocalStringManager.GetConfig("Food_language", "Desc_149"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_149"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 45, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(150, LocalStringManager.GetConfig("Food_language", "Name_150"), 7, 701, 7, 144, "icon_Food_qunxiangeng", "bigIcon_Food_qunxiangeng", LocalStringManager.GetConfig("Food_language", "Desc_150"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_150"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 50, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(151, LocalStringManager.GetConfig("Food_language", "Name_151"), 7, 701, 8, 144, "icon_Food_longjingxiaren", "bigIcon_Food_longjingxiaren", LocalStringManager.GetConfig("Food_language", "Desc_151"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_151"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 55, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Tea
		}));
		_dataArray.Add(new FoodItem(152, LocalStringManager.GetConfig("Food_language", "Name_152"), 7, 701, 2, 152, "icon_Food_liyukuai", "bigIcon_Food_liyukuai", LocalStringManager.GetConfig("Food_language", "Desc_152"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_152"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 300, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 30, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(153, LocalStringManager.GetConfig("Food_language", "Name_153"), 7, 701, 3, 152, "icon_Food_ganshaoyanli", "bigIcon_Food_ganshaoyanli", LocalStringManager.GetConfig("Food_language", "Desc_153"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_153"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 35, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(154, LocalStringManager.GetConfig("Food_language", "Name_154"), 7, 701, 4, 152, "icon_Food_huaibaoli", "bigIcon_Food_huaibaoli", LocalStringManager.GetConfig("Food_language", "Desc_154"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_154"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 40, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(155, LocalStringManager.GetConfig("Food_language", "Name_155"), 7, 701, 5, 152, "icon_Food_wuliucuyu", "bigIcon_Food_wuliucuyu", LocalStringManager.GetConfig("Food_language", "Desc_155"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_155"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 45, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(156, LocalStringManager.GetConfig("Food_language", "Name_156"), 7, 701, 6, 152, "icon_Food_songshuliyu", "bigIcon_Food_songshuliyu", LocalStringManager.GetConfig("Food_language", "Desc_156"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_156"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 50, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(157, LocalStringManager.GetConfig("Food_language", "Name_157"), 7, 701, 7, 152, "icon_Food_baihuayudu", "bigIcon_Food_baihuayudu", LocalStringManager.GetConfig("Food_language", "Desc_157"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_157"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 55, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(158, LocalStringManager.GetConfig("Food_language", "Name_158"), 7, 701, 8, 152, "icon_Food_longxuhui", "bigIcon_Food_longxuhui", LocalStringManager.GetConfig("Food_language", "Desc_158"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_158"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 60, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(159, LocalStringManager.GetConfig("Food_language", "Name_159"), 7, 701, 3, 159, "icon_Food_qingzhengxie", "bigIcon_Food_qingzhengxie", LocalStringManager.GetConfig("Food_language", "Desc_159"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_159"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 750, 0, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 40), 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(160, LocalStringManager.GetConfig("Food_language", "Name_160"), 7, 701, 4, 159, "icon_Food_shengsixieyao", "bigIcon_Food_shengsixieyao", LocalStringManager.GetConfig("Food_language", "Desc_160"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_160"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 45), 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(161, LocalStringManager.GetConfig("Food_language", "Name_161"), 7, 701, 5, 159, "icon_Food_yuanyanggaoxie", "bigIcon_Food_yuanyanggaoxie", LocalStringManager.GetConfig("Food_language", "Desc_161"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_161"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 50), 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(162, LocalStringManager.GetConfig("Food_language", "Name_162"), 7, 701, 6, 159, "icon_Food_xieniangcheng", "bigIcon_Food_xieniangcheng", LocalStringManager.GetConfig("Food_language", "Desc_162"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_162"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 55), 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(163, LocalStringManager.GetConfig("Food_language", "Name_163"), 7, 701, 7, 159, "icon_Food_naixianghexie", "bigIcon_Food_naixianghexie", LocalStringManager.GetConfig("Food_language", "Desc_163"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_163"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 60), 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Fruit
		}));
		_dataArray.Add(new FoodItem(164, LocalStringManager.GetConfig("Food_language", "Name_164"), 7, 701, 8, 159, "icon_Food_chengcuxishouxie", "bigIcon_Food_chengcuxishouxie", LocalStringManager.GetConfig("Food_language", "Desc_164"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_164"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 20, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 0, 65), 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(165, LocalStringManager.GetConfig("Food_language", "Name_165"), 7, 701, 4, 165, "icon_Food_luyukuai", "bigIcon_Food_luyukuai", LocalStringManager.GetConfig("Food_language", "Desc_165"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_165"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 1550, 1, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 50, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(166, LocalStringManager.GetConfig("Food_language", "Name_166"), 7, 701, 5, 165, "icon_Food_qingzhengluyu", "bigIcon_Food_qingzhengluyu", LocalStringManager.GetConfig("Food_language", "Desc_166"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_166"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 55, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(167, LocalStringManager.GetConfig("Food_language", "Name_167"), 7, 701, 6, 165, "icon_Food_cuanluyuqinggeng", "bigIcon_Food_cuanluyuqinggeng", LocalStringManager.GetConfig("Food_language", "Desc_167"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_167"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 60, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(168, LocalStringManager.GetConfig("Food_language", "Name_168"), 7, 701, 7, 165, "icon_Food_saixiegeng", "bigIcon_Food_saixiegeng", LocalStringManager.GetConfig("Food_language", "Desc_168"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_168"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 65, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Mushroom,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(169, LocalStringManager.GetConfig("Food_language", "Name_169"), 7, 701, 8, 165, "icon_Food_tihuqizhenlu", "bigIcon_Food_tihuqizhenlu", LocalStringManager.GetConfig("Food_language", "Desc_169"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_169"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 70, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Mushroom
		}));
		_dataArray.Add(new FoodItem(170, LocalStringManager.GetConfig("Food_language", "Name_170"), 7, 701, 5, 170, "icon_Food_yuankebaoyu", "bigIcon_Food_yuankebaoyu", LocalStringManager.GetConfig("Food_language", "Desc_170"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_170"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 2800, 2, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 60, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(171, LocalStringManager.GetConfig("Food_language", "Name_171"), 7, 701, 6, 170, "icon_Food_jiangjiujueming", "bigIcon_Food_jiangjiujueming", LocalStringManager.GetConfig("Food_language", "Desc_171"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_171"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 65, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Wine
		}));
		_dataArray.Add(new FoodItem(172, LocalStringManager.GetConfig("Food_language", "Name_172"), 7, 701, 7, 170, "icon_Food_baibasibao", "bigIcon_Food_baibasibao", LocalStringManager.GetConfig("Food_language", "Desc_172"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_172"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 70, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Bird,
			EFoodFoodType.Vegetable
		}));
		_dataArray.Add(new FoodItem(173, LocalStringManager.GetConfig("Food_language", "Name_173"), 7, 701, 8, 170, "icon_Food_fotiaoqiang", "bigIcon_Food_fotiaoqiang", LocalStringManager.GetConfig("Food_language", "Desc_173"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_173"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 50, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 75, 0, 0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Mushroom
		}));
		_dataArray.Add(new FoodItem(174, LocalStringManager.GetConfig("Food_language", "Name_174"), 7, 701, 6, 174, "icon_Food_xianhuanglu", "bigIcon_Food_xianhuanglu", LocalStringManager.GetConfig("Food_language", "Desc_174"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_174"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 4600, 3, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 70, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
		_dataArray.Add(new FoodItem(175, LocalStringManager.GetConfig("Food_language", "Name_175"), 7, 701, 7, 174, "icon_Food_meixueshenglongpian", "bigIcon_Food_meixueshenglongpian", LocalStringManager.GetConfig("Food_language", "Desc_175"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_175"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 30, 7050, 4, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 75, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish,
			EFoodFoodType.Flower
		}));
		_dataArray.Add(new FoodItem(176, LocalStringManager.GetConfig("Food_language", "Name_176"), 7, 701, 8, 174, "icon_Food_shaoqinhuangyugu", "bigIcon_Food_shaoqinhuangyugu", LocalStringManager.GetConfig("Food_language", "Desc_176"), LocalStringManager.GetConfig("Food_language", "FunctionDesc_176"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 10250, 5, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 3, 38, new List<int>(), 1, 1, new MainAttributes(0, 0, 0, 0, 80, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<EFoodFoodType>
		{
			EFoodFoodType.Meat,
			EFoodFoodType.Fish
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<FoodItem>(177);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}

	public static int GetCharacterPropertyBonus(int key, ECharacterPropertyReferencedType property)
	{
		return Instance[key]?.GetCharacterPropertyBonusInt(property) ?? 0;
	}

	public static int GetCharacterPropertyBonus(short[] keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Length; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(List<short> keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Count; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(int[] keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Length; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(List<int> keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Count; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}
}
