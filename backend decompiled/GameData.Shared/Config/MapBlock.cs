using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlock : ConfigData<MapBlockItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 太吾村
		/// </summary>
		public const short Taiwucun = 0;

		/// <summary>
		/// 京城
		/// </summary>
		public const short Jingcheng = 1;

		/// <summary>
		/// 成都
		/// </summary>
		public const short Chengdu = 2;

		/// <summary>
		/// 桂州
		/// </summary>
		public const short Guizhou = 3;

		/// <summary>
		/// 襄阳
		/// </summary>
		public const short Xiangyang = 4;

		/// <summary>
		/// 太原
		/// </summary>
		public const short Taiyuan = 5;

		/// <summary>
		/// 广州
		/// </summary>
		public const short Guangzhou = 6;

		/// <summary>
		/// 青州
		/// </summary>
		public const short Qingzhou = 7;

		/// <summary>
		/// 江陵
		/// </summary>
		public const short Jiangling = 8;

		/// <summary>
		/// 福州
		/// </summary>
		public const short Fuzhou = 9;

		/// <summary>
		/// 辽阳
		/// </summary>
		public const short Liaoyang = 10;

		/// <summary>
		/// 秦州
		/// </summary>
		public const short Qinzhou = 11;

		/// <summary>
		/// 大理
		/// </summary>
		public const short Dali = 12;

		/// <summary>
		/// 寿春
		/// </summary>
		public const short Shouchun = 13;

		/// <summary>
		/// 杭州
		/// </summary>
		public const short Hangzhou = 14;

		/// <summary>
		/// 扬州
		/// </summary>
		public const short Yangzhou = 15;

		/// <summary>
		/// 隐秘小村
		/// </summary>
		public const short SecretVilliage = 16;

		/// <summary>
		/// 竹庐1
		/// </summary>
		public const short BambooHouse1 = 17;

		/// <summary>
		/// 竹庐2
		/// </summary>
		public const short BambooHouse2 = 18;

		/// <summary>
		/// 少林派
		/// </summary>
		public const short Shaolin = 19;

		/// <summary>
		/// 峨眉派
		/// </summary>
		public const short Emei = 20;

		/// <summary>
		/// 百花谷
		/// </summary>
		public const short Baihua = 21;

		/// <summary>
		/// 武当派
		/// </summary>
		public const short Wudang = 22;

		/// <summary>
		/// 元山派
		/// </summary>
		public const short Yuanshan = 23;

		/// <summary>
		/// 狮相门
		/// </summary>
		public const short Shixiang = 24;

		/// <summary>
		/// 然山派
		/// </summary>
		public const short Ranshan = 25;

		/// <summary>
		/// 璇女派
		/// </summary>
		public const short Xuannv = 26;

		/// <summary>
		/// 铸剑山庄
		/// </summary>
		public const short Zhujian = 27;

		/// <summary>
		/// 空桑派
		/// </summary>
		public const short Kongsang = 28;

		/// <summary>
		/// 金刚宗
		/// </summary>
		public const short Jingang = 29;

		/// <summary>
		/// 五仙教
		/// </summary>
		public const short Wuxian = 30;

		/// <summary>
		/// 界青门
		/// </summary>
		public const short Jieqing = 31;

		/// <summary>
		/// 伏龙坛
		/// </summary>
		public const short Fulong = 32;

		/// <summary>
		/// 血犼教
		/// </summary>
		public const short Xuehou = 33;

		/// <summary>
		/// 村庄
		/// </summary>
		public const short Village = 34;

		/// <summary>
		/// 市镇
		/// </summary>
		public const short Town = 35;

		/// <summary>
		/// 关寨
		/// </summary>
		public const short Stockade = 36;

		/// <summary>
		/// 驿站
		/// </summary>
		public const short Station = 37;

		/// <summary>
		/// 废弃驿站
		/// </summary>
		public const short BrokenStation = 38;

		/// <summary>
		/// 农田1
		/// </summary>
		public const short Farmland1 = 39;

		/// <summary>
		/// 园林1
		/// </summary>
		public const short Gardens1 = 42;

		/// <summary>
		/// 石林1
		/// </summary>
		public const short StoneForest1 = 45;

		/// <summary>
		/// 桑园1
		/// </summary>
		public const short MulberryField1 = 48;

		/// <summary>
		/// 药园1
		/// </summary>
		public const short HerbalGarden1 = 51;

		/// <summary>
		/// 玉山1
		/// </summary>
		public const short JadeMountain1 = 54;

		/// <summary>
		/// 山岳1
		/// </summary>
		public const short Mountain1 = 57;

		/// <summary>
		/// 山脉1
		/// </summary>
		public const short BigMountain1 = 60;

		/// <summary>
		/// 峡谷1
		/// </summary>
		public const short Canyon1 = 63;

		/// <summary>
		/// 天险1
		/// </summary>
		public const short BigCanyon1 = 66;

		/// <summary>
		/// 天险3
		/// </summary>
		public const short TianXian3 = 68;

		/// <summary>
		/// 丘陵1
		/// </summary>
		public const short Hill1 = 69;

		/// <summary>
		/// 高地1
		/// </summary>
		public const short BigHill1 = 72;

		/// <summary>
		/// 原野1
		/// </summary>
		public const short Field1 = 75;

		/// <summary>
		/// 平原1
		/// </summary>
		public const short BigField1 = 78;

		/// <summary>
		/// 林地1
		/// </summary>
		public const short Woodland1 = 81;

		/// <summary>
		/// 森林1
		/// </summary>
		public const short BigWoodland1 = 84;

		/// <summary>
		/// 河滩1
		/// </summary>
		public const short RiverBeach1 = 87;

		/// <summary>
		/// 河谷1
		/// </summary>
		public const short HeGu1 = 90;

		/// <summary>
		/// 河谷3
		/// </summary>
		public const short HeGu3 = 92;

		/// <summary>
		/// 湖泊
		/// </summary>
		public const short Lake1 = 93;

		/// <summary>
		/// 密林1
		/// </summary>
		public const short Jungle1 = 94;

		/// <summary>
		/// 洞穴1
		/// </summary>
		public const short Cave1 = 97;

		/// <summary>
		/// 沼泽1
		/// </summary>
		public const short Swamp1 = 100;

		/// <summary>
		/// 桃源1
		/// </summary>
		public const short TaoYuan1 = 103;

		/// <summary>
		/// 溪谷1
		/// </summary>
		public const short Valley1 = 106;

		/// <summary>
		/// 荒野1
		/// </summary>
		public const short Wild1 = 109;

		/// <summary>
		/// 毁坏地块1
		/// </summary>
		public const short Ruin1 = 118;

		/// <summary>
		/// 毁坏地块2
		/// </summary>
		public const short Ruin2 = 119;

		/// <summary>
		/// 毁坏地块3
		/// </summary>
		public const short Ruin3 = 120;

		/// <summary>
		/// 毁坏地块4
		/// </summary>
		public const short Ruin4 = 121;

		/// <summary>
		/// 毁坏地块5
		/// </summary>
		public const short Ruin5 = 122;

		/// <summary>
		/// 毁坏地块6
		/// </summary>
		public const short Ruin6 = 123;

		/// <summary>
		/// 暗渊
		/// </summary>
		public const short Abyss = 124;

		/// <summary>
		/// 阻挡
		/// </summary>
		public const short Block = 125;

		/// <summary>
		/// 镂空
		/// </summary>
		public const short None = 126;

		/// <summary>
		/// 莫女衣
		/// </summary>
		public const short SwordTombMonv = 128;

		/// <summary>
		/// 伏邪铁
		/// </summary>
		public const short SwordTombDayueYaochang = 129;

		/// <summary>
		/// 大玄凝
		/// </summary>
		public const short SwordTombJiuhan = 130;

		/// <summary>
		/// 凤凰茧
		/// </summary>
		public const short SwordTombJinHuanger = 131;

		/// <summary>
		/// 焚神炼
		/// </summary>
		public const short SwordTombYiYihou = 132;

		/// <summary>
		/// 解龙魄
		/// </summary>
		public const short SwordTombWeiQi = 133;

		/// <summary>
		/// 溶尘隐
		/// </summary>
		public const short SwordTombYixiang = 134;

		/// <summary>
		/// 囚魔木
		/// </summary>
		public const short SwordTombXuefeng = 135;

		/// <summary>
		/// 鬼神霞
		/// </summary>
		public const short SwordTombShuFang = 136;

		/// <summary>
		/// 雷泽
		/// </summary>
		public const short LoongWhiteBlock = 137;

		/// <summary>
		/// 洪泽
		/// </summary>
		public const short LoongBlackBlock = 138;

		/// <summary>
		/// 风泽
		/// </summary>
		public const short LoongGreenBlock = 139;

		/// <summary>
		/// 炎泽
		/// </summary>
		public const short LoongRedBlock = 140;

		/// <summary>
		/// 沙泽
		/// </summary>
		public const short LoongYellowBlock = 141;

		/// <summary>
		/// 毁坏地块大1
		/// </summary>
		public const short RuinBig1 = 142;

		/// <summary>
		/// 毁坏地块大2
		/// </summary>
		public const short RuinBig2 = 143;

		/// <summary>
		/// 毁坏地块大3
		/// </summary>
		public const short RuinBig3 = 144;

		/// <summary>
		/// 毁坏地块大4
		/// </summary>
		public const short RuinBig4 = 145;

		/// <summary>
		/// 毁坏地块大5
		/// </summary>
		public const short RuinBig5 = 146;

		/// <summary>
		/// 毁坏地块大6
		/// </summary>
		public const short RuinBig6 = 147;

		/// <summary>
		/// 柴山神炉
		/// </summary>
		public const short ChaishanFurnace = 148;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 太吾村
		/// </summary>
		public static MapBlockItem Taiwucun => Instance[(short)0];

		/// <summary>
		/// 京城
		/// </summary>
		public static MapBlockItem Jingcheng => Instance[(short)1];

		/// <summary>
		/// 成都
		/// </summary>
		public static MapBlockItem Chengdu => Instance[(short)2];

		/// <summary>
		/// 桂州
		/// </summary>
		public static MapBlockItem Guizhou => Instance[(short)3];

		/// <summary>
		/// 襄阳
		/// </summary>
		public static MapBlockItem Xiangyang => Instance[(short)4];

		/// <summary>
		/// 太原
		/// </summary>
		public static MapBlockItem Taiyuan => Instance[(short)5];

		/// <summary>
		/// 广州
		/// </summary>
		public static MapBlockItem Guangzhou => Instance[(short)6];

		/// <summary>
		/// 青州
		/// </summary>
		public static MapBlockItem Qingzhou => Instance[(short)7];

		/// <summary>
		/// 江陵
		/// </summary>
		public static MapBlockItem Jiangling => Instance[(short)8];

		/// <summary>
		/// 福州
		/// </summary>
		public static MapBlockItem Fuzhou => Instance[(short)9];

		/// <summary>
		/// 辽阳
		/// </summary>
		public static MapBlockItem Liaoyang => Instance[(short)10];

		/// <summary>
		/// 秦州
		/// </summary>
		public static MapBlockItem Qinzhou => Instance[(short)11];

		/// <summary>
		/// 大理
		/// </summary>
		public static MapBlockItem Dali => Instance[(short)12];

		/// <summary>
		/// 寿春
		/// </summary>
		public static MapBlockItem Shouchun => Instance[(short)13];

		/// <summary>
		/// 杭州
		/// </summary>
		public static MapBlockItem Hangzhou => Instance[(short)14];

		/// <summary>
		/// 扬州
		/// </summary>
		public static MapBlockItem Yangzhou => Instance[(short)15];

		/// <summary>
		/// 隐秘小村
		/// </summary>
		public static MapBlockItem SecretVilliage => Instance[(short)16];

		/// <summary>
		/// 竹庐1
		/// </summary>
		public static MapBlockItem BambooHouse1 => Instance[(short)17];

		/// <summary>
		/// 竹庐2
		/// </summary>
		public static MapBlockItem BambooHouse2 => Instance[(short)18];

		/// <summary>
		/// 少林派
		/// </summary>
		public static MapBlockItem Shaolin => Instance[(short)19];

		/// <summary>
		/// 峨眉派
		/// </summary>
		public static MapBlockItem Emei => Instance[(short)20];

		/// <summary>
		/// 百花谷
		/// </summary>
		public static MapBlockItem Baihua => Instance[(short)21];

		/// <summary>
		/// 武当派
		/// </summary>
		public static MapBlockItem Wudang => Instance[(short)22];

		/// <summary>
		/// 元山派
		/// </summary>
		public static MapBlockItem Yuanshan => Instance[(short)23];

		/// <summary>
		/// 狮相门
		/// </summary>
		public static MapBlockItem Shixiang => Instance[(short)24];

		/// <summary>
		/// 然山派
		/// </summary>
		public static MapBlockItem Ranshan => Instance[(short)25];

		/// <summary>
		/// 璇女派
		/// </summary>
		public static MapBlockItem Xuannv => Instance[(short)26];

		/// <summary>
		/// 铸剑山庄
		/// </summary>
		public static MapBlockItem Zhujian => Instance[(short)27];

		/// <summary>
		/// 空桑派
		/// </summary>
		public static MapBlockItem Kongsang => Instance[(short)28];

		/// <summary>
		/// 金刚宗
		/// </summary>
		public static MapBlockItem Jingang => Instance[(short)29];

		/// <summary>
		/// 五仙教
		/// </summary>
		public static MapBlockItem Wuxian => Instance[(short)30];

		/// <summary>
		/// 界青门
		/// </summary>
		public static MapBlockItem Jieqing => Instance[(short)31];

		/// <summary>
		/// 伏龙坛
		/// </summary>
		public static MapBlockItem Fulong => Instance[(short)32];

		/// <summary>
		/// 血犼教
		/// </summary>
		public static MapBlockItem Xuehou => Instance[(short)33];

		/// <summary>
		/// 村庄
		/// </summary>
		public static MapBlockItem Village => Instance[(short)34];

		/// <summary>
		/// 市镇
		/// </summary>
		public static MapBlockItem Town => Instance[(short)35];

		/// <summary>
		/// 关寨
		/// </summary>
		public static MapBlockItem Stockade => Instance[(short)36];

		/// <summary>
		/// 驿站
		/// </summary>
		public static MapBlockItem Station => Instance[(short)37];

		/// <summary>
		/// 废弃驿站
		/// </summary>
		public static MapBlockItem BrokenStation => Instance[(short)38];

		/// <summary>
		/// 农田1
		/// </summary>
		public static MapBlockItem Farmland1 => Instance[(short)39];

		/// <summary>
		/// 园林1
		/// </summary>
		public static MapBlockItem Gardens1 => Instance[(short)42];

		/// <summary>
		/// 石林1
		/// </summary>
		public static MapBlockItem StoneForest1 => Instance[(short)45];

		/// <summary>
		/// 桑园1
		/// </summary>
		public static MapBlockItem MulberryField1 => Instance[(short)48];

		/// <summary>
		/// 药园1
		/// </summary>
		public static MapBlockItem HerbalGarden1 => Instance[(short)51];

		/// <summary>
		/// 玉山1
		/// </summary>
		public static MapBlockItem JadeMountain1 => Instance[(short)54];

		/// <summary>
		/// 山岳1
		/// </summary>
		public static MapBlockItem Mountain1 => Instance[(short)57];

		/// <summary>
		/// 山脉1
		/// </summary>
		public static MapBlockItem BigMountain1 => Instance[(short)60];

		/// <summary>
		/// 峡谷1
		/// </summary>
		public static MapBlockItem Canyon1 => Instance[(short)63];

		/// <summary>
		/// 天险1
		/// </summary>
		public static MapBlockItem BigCanyon1 => Instance[(short)66];

		/// <summary>
		/// 天险3
		/// </summary>
		public static MapBlockItem TianXian3 => Instance[(short)68];

		/// <summary>
		/// 丘陵1
		/// </summary>
		public static MapBlockItem Hill1 => Instance[(short)69];

		/// <summary>
		/// 高地1
		/// </summary>
		public static MapBlockItem BigHill1 => Instance[(short)72];

		/// <summary>
		/// 原野1
		/// </summary>
		public static MapBlockItem Field1 => Instance[(short)75];

		/// <summary>
		/// 平原1
		/// </summary>
		public static MapBlockItem BigField1 => Instance[(short)78];

		/// <summary>
		/// 林地1
		/// </summary>
		public static MapBlockItem Woodland1 => Instance[(short)81];

		/// <summary>
		/// 森林1
		/// </summary>
		public static MapBlockItem BigWoodland1 => Instance[(short)84];

		/// <summary>
		/// 河滩1
		/// </summary>
		public static MapBlockItem RiverBeach1 => Instance[(short)87];

		/// <summary>
		/// 河谷1
		/// </summary>
		public static MapBlockItem HeGu1 => Instance[(short)90];

		/// <summary>
		/// 河谷3
		/// </summary>
		public static MapBlockItem HeGu3 => Instance[(short)92];

		/// <summary>
		/// 湖泊
		/// </summary>
		public static MapBlockItem Lake1 => Instance[(short)93];

		/// <summary>
		/// 密林1
		/// </summary>
		public static MapBlockItem Jungle1 => Instance[(short)94];

		/// <summary>
		/// 洞穴1
		/// </summary>
		public static MapBlockItem Cave1 => Instance[(short)97];

		/// <summary>
		/// 沼泽1
		/// </summary>
		public static MapBlockItem Swamp1 => Instance[(short)100];

		/// <summary>
		/// 桃源1
		/// </summary>
		public static MapBlockItem TaoYuan1 => Instance[(short)103];

		/// <summary>
		/// 溪谷1
		/// </summary>
		public static MapBlockItem Valley1 => Instance[(short)106];

		/// <summary>
		/// 荒野1
		/// </summary>
		public static MapBlockItem Wild1 => Instance[(short)109];

		/// <summary>
		/// 毁坏地块1
		/// </summary>
		public static MapBlockItem Ruin1 => Instance[(short)118];

		/// <summary>
		/// 毁坏地块2
		/// </summary>
		public static MapBlockItem Ruin2 => Instance[(short)119];

		/// <summary>
		/// 毁坏地块3
		/// </summary>
		public static MapBlockItem Ruin3 => Instance[(short)120];

		/// <summary>
		/// 毁坏地块4
		/// </summary>
		public static MapBlockItem Ruin4 => Instance[(short)121];

		/// <summary>
		/// 毁坏地块5
		/// </summary>
		public static MapBlockItem Ruin5 => Instance[(short)122];

		/// <summary>
		/// 毁坏地块6
		/// </summary>
		public static MapBlockItem Ruin6 => Instance[(short)123];

		/// <summary>
		/// 暗渊
		/// </summary>
		public static MapBlockItem Abyss => Instance[(short)124];

		/// <summary>
		/// 阻挡
		/// </summary>
		public static MapBlockItem Block => Instance[(short)125];

		/// <summary>
		/// 镂空
		/// </summary>
		public static MapBlockItem None => Instance[(short)126];

		/// <summary>
		/// 莫女衣
		/// </summary>
		public static MapBlockItem SwordTombMonv => Instance[(short)128];

		/// <summary>
		/// 伏邪铁
		/// </summary>
		public static MapBlockItem SwordTombDayueYaochang => Instance[(short)129];

		/// <summary>
		/// 大玄凝
		/// </summary>
		public static MapBlockItem SwordTombJiuhan => Instance[(short)130];

		/// <summary>
		/// 凤凰茧
		/// </summary>
		public static MapBlockItem SwordTombJinHuanger => Instance[(short)131];

		/// <summary>
		/// 焚神炼
		/// </summary>
		public static MapBlockItem SwordTombYiYihou => Instance[(short)132];

		/// <summary>
		/// 解龙魄
		/// </summary>
		public static MapBlockItem SwordTombWeiQi => Instance[(short)133];

		/// <summary>
		/// 溶尘隐
		/// </summary>
		public static MapBlockItem SwordTombYixiang => Instance[(short)134];

		/// <summary>
		/// 囚魔木
		/// </summary>
		public static MapBlockItem SwordTombXuefeng => Instance[(short)135];

		/// <summary>
		/// 鬼神霞
		/// </summary>
		public static MapBlockItem SwordTombShuFang => Instance[(short)136];

		/// <summary>
		/// 雷泽
		/// </summary>
		public static MapBlockItem LoongWhiteBlock => Instance[(short)137];

		/// <summary>
		/// 洪泽
		/// </summary>
		public static MapBlockItem LoongBlackBlock => Instance[(short)138];

		/// <summary>
		/// 风泽
		/// </summary>
		public static MapBlockItem LoongGreenBlock => Instance[(short)139];

		/// <summary>
		/// 炎泽
		/// </summary>
		public static MapBlockItem LoongRedBlock => Instance[(short)140];

		/// <summary>
		/// 沙泽
		/// </summary>
		public static MapBlockItem LoongYellowBlock => Instance[(short)141];

		/// <summary>
		/// 毁坏地块大1
		/// </summary>
		public static MapBlockItem RuinBig1 => Instance[(short)142];

		/// <summary>
		/// 毁坏地块大2
		/// </summary>
		public static MapBlockItem RuinBig2 => Instance[(short)143];

		/// <summary>
		/// 毁坏地块大3
		/// </summary>
		public static MapBlockItem RuinBig3 => Instance[(short)144];

		/// <summary>
		/// 毁坏地块大4
		/// </summary>
		public static MapBlockItem RuinBig4 => Instance[(short)145];

		/// <summary>
		/// 毁坏地块大5
		/// </summary>
		public static MapBlockItem RuinBig5 => Instance[(short)146];

		/// <summary>
		/// 毁坏地块大6
		/// </summary>
		public static MapBlockItem RuinBig6 => Instance[(short)147];

		/// <summary>
		/// 柴山神炉
		/// </summary>
		public static MapBlockItem ChaishanFurnace => Instance[(short)148];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static MapBlock Instance = new MapBlock();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "AdventureEditorName", "Desc", "SplitOrMergeBlockId", "MainResourceType", "ResourceCollectionType", "BlockNames", "LandFormType", "CenterBuilding", "PresetBuildingList",
		"RandomBuildingList", "InformationTemplateId", "CombatScene", "CombatState", "AdventureEnvironment", "TemplateId", "Art", "ArtEventBackground", "Bgm", "FixedBuildingImage",
		"EventBack"
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
		_dataArray.Add(new MapBlockItem(0, EMapBlockType.Town, EMapBlockSubType.TaiwuCun, LocalStringManager.GetConfig("MapBlock_language", "Name_0"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_0"), LocalStringManager.GetConfig("MapBlock_language", "Desc_0"), 1, 2, 3, 1, 1, freeStepIgnorePathCost: true, showTips: true, "town_taiwucun", new int[2] { 0, 1 }, blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "town_taiwucun", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: true, -1, new List<sbyte>(), new short[6], 0, -1, new string[0], "city_taiwucun", new string[1] { "Ambience_map_7" }, 18, 0, 44, 1, null, new List<short> { 48, 46 }, new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_town_taiwucun_1", 41, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 2));
		_dataArray.Add(new MapBlockItem(1, EMapBlockType.City, EMapBlockSubType.Jingcheng, LocalStringManager.GetConfig("MapBlock_language", "Name_1"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_1"), LocalStringManager.GetConfig("MapBlock_language", "Desc_1"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_jingcheng", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_JingCheng/eff_city_jingcheng" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_1_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_1_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_1_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_1_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_1_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_1_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_1_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_1_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_1_8")
		}, "city_jincheng", new string[9] { "Ambience_map_14", " Ambience_map_city03", " Ambience_map_17", " Ambience_map_city03", " Ambience_map_city03", " Ambience_map_city03", " Ambience_map_city03", " Ambience_map_city03", " Ambience_map_city03" }, 16, 0, 224, 10, null, new List<short>
		{
			48, 284, 279, 46, 46, 46, 47, 47, 47, 47,
			47, 47, 47, 47, 47
		}, new List<short> { 47, 47, 47, 47, 47, 47 }, 0, new List<(short, short)> { (1, 100) }, "tex_city_jincheng", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(2, EMapBlockType.City, EMapBlockSubType.Chengdu, LocalStringManager.GetConfig("MapBlock_language", "Name_2"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_2"), LocalStringManager.GetConfig("MapBlock_language", "Desc_2"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_chengdu", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_ChengDu/eff_city_chengdu" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_2_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_2_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_2_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_2_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_2_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_2_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_2_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_2_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_2_8")
		}, "city_chengdu", new string[9] { "Ambience_map_city03", " Ambience_map_city03", " Ambience_map_4", " Ambience_map_city01", " Ambience_map_14", " Ambience_map_4", " Ambience_map_4", " Ambience_map_14", " Ambience_map_17" }, 16, 1, 225, 10, null, new List<short>
		{
			48, 284, 277, 46, 46, 46, 46, 46, 46, 47,
			47, 47, 47, 47, 47
		}, new List<short> { 46, 46, 46, 47, 47, 47 }, 1, new List<(short, short)> { (1, 100) }, "tex_city_chengdu", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(3, EMapBlockType.City, EMapBlockSubType.Guizhou, LocalStringManager.GetConfig("MapBlock_language", "Name_3"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_3"), LocalStringManager.GetConfig("MapBlock_language", "Desc_3"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_guizhou", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_GuiZhou/eff_city_guizhou" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_3_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_3_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_3_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_3_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_3_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_3_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_3_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_3_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_3_8")
		}, "city_guizhou", new string[9] { "Ambience_map_4", " Ambience_map_14", " Ambience_map_17", " Ambience_map_17", " Ambience_map_17", " Ambience_map_17", " Ambience_map_17", " Ambience_map_17", " Ambience_map_14" }, 16, 2, 226, 10, null, new List<short>
		{
			48, 284, 280, 46, 46, 46, 46, 46, 46, 46,
			46, 46, 47, 47, 47
		}, new List<short> { 46, 46, 46, 47, 47, 47 }, 2, new List<(short, short)> { (1, 100) }, "tex_city_guizhou", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(4, EMapBlockType.City, EMapBlockSubType.Xiangyang, LocalStringManager.GetConfig("MapBlock_language", "Name_4"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_4"), LocalStringManager.GetConfig("MapBlock_language", "Desc_4"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_xiangyang", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_XiangYang/eff_city_xiangyang" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_4_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_4_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_4_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_4_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_4_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_4_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_4_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_4_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_4_8")
		}, "city_xiangyang", new string[9] { "Ambience_map_city01", " Ambience_map_city03", " Ambience_map_14", " Ambience_map_city02", " Ambience_map_city03", " Ambience_map_17", " Ambience_map_17", " Ambience_map_14", " Ambience_map_14" }, 16, 3, 227, 10, null, new List<short>
		{
			48, 284, 277, 46, 46, 46, 46, 46, 46, 47,
			47, 47, 47, 47, 47
		}, new List<short> { 46, 46, 46, 47, 47, 47 }, 3, new List<(short, short)> { (1, 100) }, "tex_city_xiangyang", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(5, EMapBlockType.City, EMapBlockSubType.Taiyuan, LocalStringManager.GetConfig("MapBlock_language", "Name_5"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_5"), LocalStringManager.GetConfig("MapBlock_language", "Desc_5"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_taiyuan", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_TaiYuan/eff_city_taiyuan" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_5_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_5_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_5_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_5_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_5_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_5_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_5_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_5_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_5_8")
		}, "city_taiyuan", new string[9] { "Ambience_map_city01", " Ambience_map_14", " Ambience_map_14", " Ambience_map_14", " Ambience_map_17", " Ambience_map_baihuagu_2", " Ambience_map_14", " Ambience_map_17", " Ambience_map_14" }, 16, 1, 228, 10, null, new List<short>
		{
			48, 284, 276, 46, 46, 46, 46, 46, 46, 46,
			46, 46, 47, 47, 47
		}, new List<short> { 46, 46, 46, 47, 47, 47 }, 4, new List<(short, short)> { (1, 100) }, "tex_city_taiyuan", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(6, EMapBlockType.City, EMapBlockSubType.Guangzhou, LocalStringManager.GetConfig("MapBlock_language", "Name_6"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_6"), LocalStringManager.GetConfig("MapBlock_language", "Desc_6"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_guangzhou", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_GuangZhou/eff_city_guangzhou" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_6_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_6_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_6_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_6_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_6_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_6_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_6_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_6_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_6_8")
		}, "city_guangzhou", new string[9] { "Ambience_map_city01", " Ambience_map_city01", " Ambience_map_12", " Ambience_map_17", " Ambience_map_city02", " Ambience_map_12", " Ambience_map_14", " Ambience_map_17", " Ambience_map_12" }, 16, 4, 229, 10, null, new List<short>
		{
			48, 284, 276, 46, 46, 46, 46, 46, 46, 47,
			47, 47, 47, 47, 47
		}, new List<short> { 46, 46, 46, 47, 47, 47 }, 5, new List<(short, short)> { (1, 100) }, "tex_city_guangzhou", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(7, EMapBlockType.City, EMapBlockSubType.Qingzhou, LocalStringManager.GetConfig("MapBlock_language", "Name_7"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_7"), LocalStringManager.GetConfig("MapBlock_language", "Desc_7"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_qingzhou", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_QingZhou/eff_city_qingzhou" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_7_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_7_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_7_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_7_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_7_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_7_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_7_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_7_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_7_8")
		}, "city_qingzhou", new string[9] { "Ambience_map_8", " Ambience_map_baihuagu_2", " Ambience_map_16", " Ambience_map_14", " Ambience_map_17", " Ambience_map_14", " Ambience_map_14", " Ambience_map_12", " Ambience_map_14" }, 16, 0, 230, 10, null, new List<short>
		{
			48, 284, 281, 46, 46, 46, 46, 46, 46, 47,
			47, 47, 47, 47, 47
		}, new List<short> { 46, 46, 46, 47, 47, 47 }, 6, new List<(short, short)> { (1, 100) }, "tex_city_qingzhou", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(8, EMapBlockType.City, EMapBlockSubType.Jiangling, LocalStringManager.GetConfig("MapBlock_language", "Name_8"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_8"), LocalStringManager.GetConfig("MapBlock_language", "Desc_8"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_jiangling", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_JiangLing/eff_city_jiangling" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_8_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_8_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_8_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_8_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_8_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_8_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_8_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_8_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_8_8")
		}, "city_jiangling", new string[9] { "Ambience_map_14", " Ambience_map_city02", " Ambience_map_city01", " Ambience_map_14", " Ambience_map_xuannv_1", " Ambience_map_yuanshan_2", " Ambience_map_14", " Ambience_map_12", " Ambience_map_14" }, 16, 3, 231, 10, null, new List<short>
		{
			48, 284, 282, 46, 46, 46, 47, 47, 47, 47,
			47, 47, 47, 47, 47, 47, 47, 47
		}, new List<short> { 47, 47, 47, 47, 47, 47 }, 7, new List<(short, short)> { (1, 100) }, "tex_city_jiangling", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 18));
		_dataArray.Add(new MapBlockItem(9, EMapBlockType.City, EMapBlockSubType.Fuzhou, LocalStringManager.GetConfig("MapBlock_language", "Name_9"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_9"), LocalStringManager.GetConfig("MapBlock_language", "Desc_9"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_fuzhou", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_FuZhou/eff_city_fuzhou" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_9_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_9_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_9_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_9_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_9_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_9_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_9_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_9_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_9_8")
		}, "city_fuzhou", new string[9] { "Ambience_map_14", " Ambience_map_city01", " Ambience_map_17", " Ambience_map_17", " Ambience_map_1", " Ambience_map_17", " Ambience_map_1", " Ambience_map_17", " Ambience_map_14" }, 16, 4, 232, 10, null, new List<short>
		{
			48, 284, 279, 46, 46, 46, 46, 46, 46, 47,
			47, 47, 47, 47, 47
		}, new List<short> { 46, 46, 46, 47, 47, 47 }, 8, new List<(short, short)> { (1, 100) }, "tex_city_fuzhou", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
		_dataArray.Add(new MapBlockItem(10, EMapBlockType.City, EMapBlockSubType.Liaoyang, LocalStringManager.GetConfig("MapBlock_language", "Name_10"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_10"), LocalStringManager.GetConfig("MapBlock_language", "Desc_10"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_liaoyang", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_LiaoYang/eff_city_liaoyang" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_10_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_10_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_10_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_10_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_10_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_10_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_10_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_10_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_10_8")
		}, "city_liaoyang", new string[9] { "Ambience_map_14", " Ambience_map_city03", " Ambience_map_14", " Ambience_map_14", " Ambience_map_city03", " Ambience_map_14", " Ambience_map_14", " Ambience_map_14", " Ambience_map_1" }, 16, 5, 233, 10, null, new List<short>
		{
			48, 284, 280, 46, 46, 46, 46, 46, 46, 47,
			47, 47, 47, 47, 47
		}, new List<short> { 46, 46, 46, 47, 47, 47 }, 9, new List<(short, short)> { (1, 100) }, "tex_city_liaoyang", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(11, EMapBlockType.City, EMapBlockSubType.Qinzhou, LocalStringManager.GetConfig("MapBlock_language", "Name_11"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_11"), LocalStringManager.GetConfig("MapBlock_language", "Desc_11"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_qinzhou", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_QinZhou/eff_city_qinzhou" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_11_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_11_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_11_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_11_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_11_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_11_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_11_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_11_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_11_8")
		}, "city_qinzhou", new string[9] { "Ambience_map_city05", " Ambience_map_jingangzong_2", " Ambience_map_15", " Ambience_map_city05", " Ambience_map_15", " Ambience_map_15", " Ambience_map_15", " Ambience_map_15", " Ambience_map_15" }, 16, 1, 234, 10, null, new List<short>
		{
			48, 284, 46, 46, 46, 46, 46, 46, 46, 46,
			46, 46, 46, 46
		}, new List<short> { 46, 46, 46, 46, 46, 46 }, 10, new List<(short, short)> { (1, 100) }, "tex_city_qinzhou", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
		_dataArray.Add(new MapBlockItem(12, EMapBlockType.City, EMapBlockSubType.Dali, LocalStringManager.GetConfig("MapBlock_language", "Name_12"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_12"), LocalStringManager.GetConfig("MapBlock_language", "Desc_12"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_dali", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_DaLi/eff_city_dali" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_12_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_12_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_12_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_12_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_12_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_12_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_12_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_12_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_12_8")
		}, "city_dali", new string[9] { "Ambience_map_16", " Ambience_map_yuanshan_2", " Ambience_map_14", " Ambience_map_14", " Ambience_map_14", " Ambience_map_14", " Ambience_map_14", " Ambience_map_17", " Ambience_map_12" }, 16, 2, 235, 10, null, new List<short>
		{
			48, 284, 281, 46, 46, 46, 46, 46, 46, 47,
			47, 47, 47, 47, 47
		}, new List<short> { 46, 46, 46, 47, 47, 47 }, 11, new List<(short, short)> { (1, 100) }, "tex_city_dali", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(13, EMapBlockType.City, EMapBlockSubType.Shouchun, LocalStringManager.GetConfig("MapBlock_language", "Name_13"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_13"), LocalStringManager.GetConfig("MapBlock_language", "Desc_13"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_shouchun", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_ShouChun/eff_city_shouchun" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_13_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_13_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_13_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_13_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_13_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_13_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_13_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_13_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_13_8")
		}, "city_shouchun", new string[9] { "Ambience_map_14", " Ambience_map_city03", " Ambience_map_14", " Ambience_map_14", " Ambience_map_city04", " Ambience_map_17", " Ambience_map_14", " Ambience_map_17", " Ambience_map_1" }, 16, 0, 236, 10, null, new List<short>
		{
			48, 284, 278, 46, 46, 46, 46, 46, 46, 47,
			47, 47, 47, 47, 47
		}, new List<short> { 46, 46, 46, 47, 47, 47 }, 12, new List<(short, short)> { (1, 100) }, "tex_city_shouchun", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(14, EMapBlockType.City, EMapBlockSubType.Hangzhou, LocalStringManager.GetConfig("MapBlock_language", "Name_14"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_14"), LocalStringManager.GetConfig("MapBlock_language", "Desc_14"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_hangzhou", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_HangZhou/eff_city_hangzhou" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_14_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_14_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_14_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_14_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_14_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_14_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_14_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_14_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_14_8")
		}, "city_hangzhou", new string[9] { "Ambience_map_14", " Ambience_map_city03", " Ambience_map_city04", " Ambience_map_17", " Ambience_map_city04", " Ambience_map_city04", " Ambience_map_14", " Ambience_map_12", " Ambience_map_14" }, 16, 4, 237, 10, null, new List<short>
		{
			48, 284, 282, 46, 46, 46, 47, 47, 47, 47,
			47, 47, 47, 47, 47
		}, new List<short> { 47, 47, 47, 47, 47, 47 }, 13, new List<(short, short)> { (1, 100) }, "tex_city_hangzhou", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(15, EMapBlockType.City, EMapBlockSubType.Yangzhou, LocalStringManager.GetConfig("MapBlock_language", "Name_15"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_15"), LocalStringManager.GetConfig("MapBlock_language", "Desc_15"), 3, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "city_yangzhou", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, "city_general", eventBackgroundWinter: true, new string[1] { "City_YangZhou/eff_city_yangzhou" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_15_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_15_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_15_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_15_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_15_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_15_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_15_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_15_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_15_8")
		}, "city_yangzhou", new string[9] { "Ambience_map_city03", " Ambience_map_city04", " Ambience_map_17", " Ambience_map_city02", " Ambience_map_city04", " Ambience_map_17", " Ambience_map_14", " Ambience_map_14", " Ambience_map_1" }, 16, 3, 238, 10, null, new List<short>
		{
			48, 284, 278, 46, 46, 46, 47, 47, 47, 47,
			47, 47, 47, 47, 47
		}, new List<short> { 47, 47, 47, 47, 47, 47 }, 14, new List<(short, short)> { (1, 100) }, "tex_city_yangzhou", 9, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(16, EMapBlockType.Town, EMapBlockSubType.Village, LocalStringManager.GetConfig("MapBlock_language", "Name_16"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_16"), LocalStringManager.GetConfig("MapBlock_language", "Desc_16"), 1, 3, 4, 1, 1, freeStepIgnorePathCost: true, showTips: true, "town_secret_village", new int[2] { 0, 1 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "town_secret_village", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: true, -1, new List<sbyte>(), new short[6], 0, -1, new string[0], null, new string[1] { "Ambience_map_1" }, 10, 0, 254, 5, null, new List<short> { 48, 46 }, new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_town_village", 11, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(17, EMapBlockType.Town, EMapBlockSubType.Zhulu, LocalStringManager.GetConfig("MapBlock_language", "Name_17"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_17"), LocalStringManager.GetConfig("MapBlock_language", "Desc_17"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "town_bamboo_house", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "town_bamboo_house", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[0], null, new string[1] { "Ambience_map_5" }, 6, 2, 257, 1, null, new List<short> { 48 }, new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bamboohouse_0", 11, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 2));
		_dataArray.Add(new MapBlockItem(18, EMapBlockType.Town, EMapBlockSubType.Zhulu, LocalStringManager.GetConfig("MapBlock_language", "Name_18"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_18"), LocalStringManager.GetConfig("MapBlock_language", "Desc_18"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "town_bamboo_house", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "town_bamboo_house", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[0], null, new string[1] { "Ambience_map_5" }, 6, 2, 258, 1, null, new List<short> { 48 }, new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bamboohouse_1", 11, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 2));
		_dataArray.Add(new MapBlockItem(19, EMapBlockType.Sect, EMapBlockSubType.ShaolinPai, LocalStringManager.GetConfig("MapBlock_language", "Name_19"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_19"), LocalStringManager.GetConfig("MapBlock_language", "Desc_19"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_shaolin", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_shaolin/eff_organization_shaolin" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_19_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_19_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_19_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_19_3")
		}, "sect_shaolinpai_zaoke", new string[4] { "Ambience_map_4", " Ambience_map_14", " Ambience_map_14", " Ambience_map_shaolin_1" }, 12, 1, 239, 8, "少林派", new List<short> { 48, 288, 303, 259, 46, 46, 46 }, new List<short> { 46, 46, 46 }, 15, new List<(short, short)> { (1, 100) }, "tex_sect_shaolinpai", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(20, EMapBlockType.Sect, EMapBlockSubType.EmeiPai, LocalStringManager.GetConfig("MapBlock_language", "Name_20"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_20"), LocalStringManager.GetConfig("MapBlock_language", "Desc_20"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_emei", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_emei/eff_organization_emei" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_20_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_20_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_20_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_20_3")
		}, "sect_emeipai", new string[4] { "Ambience_map_emeishan_1", " Ambience_map_4", " Ambience_map_6", " Ambience_map_5" }, 16, 1, 240, 8, "峨眉派", new List<short> { 48, 289, 304, 260, 46, 46, 47, 47 }, new List<short> { 46, 46, 46, 47, 47, 47 }, 16, new List<(short, short)> { (1, 100) }, "tex_sect_emeipai", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(21, EMapBlockType.Sect, EMapBlockSubType.BaihuaGu, LocalStringManager.GetConfig("MapBlock_language", "Name_21"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_21"), LocalStringManager.GetConfig("MapBlock_language", "Desc_21"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_baihua", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_baihua/eff_organization_baihua" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_21_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_21_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_21_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_21_3")
		}, "sect_baihuagu", new string[4] { "Ambience_map_1", " Ambience_map_baihuagu_1", " Ambience_map_baihuagu_2", " Ambience_map_1" }, 10, 3, 241, 8, "百花谷", new List<short> { 48, 290, 305, 261, 46, 46 }, new List<short> { 46, 46 }, 17, new List<(short, short)> { (1, 100) }, "tex_sect_baihuagu", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(22, EMapBlockType.Sect, EMapBlockSubType.WudangPai, LocalStringManager.GetConfig("MapBlock_language", "Name_22"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_22"), LocalStringManager.GetConfig("MapBlock_language", "Desc_22"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_wudang", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_wudang/eff_organization_wudang" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_22_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_22_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_22_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_22_3")
		}, "sect_wudangpai_tiangang", new string[4] { "Ambience_map_6", " Ambience_map_13", " Ambience_map_4", " Ambience_map_wudang_1" }, 12, 1, 242, 8, "武当派", new List<short> { 48, 291, 306, 262, 46, 46, 47, 47 }, new List<short> { 46, 47 }, 18, new List<(short, short)> { (1, 100) }, "tex_sect_wudangpai", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(23, EMapBlockType.Sect, EMapBlockSubType.YuanshanPai, LocalStringManager.GetConfig("MapBlock_language", "Name_23"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_23"), LocalStringManager.GetConfig("MapBlock_language", "Desc_23"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_yuanshan", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_yuanshan/eff_organization_yuanshan" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_23_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_23_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_23_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_23_3")
		}, "sect_yuanshanpai_daxiaoyuanshan", new string[4] { "Ambience_map_yuanshan_1", " Ambience_map_14", " Ambience_map_yuanshan_2", " Ambience_map_yuanshan_3" }, 16, 1, 243, 8, "元山派", new List<short> { 48, 292, 307, 263, 46, 46, 46, 46, 46 }, new List<short> { 46, 46, 46, 46, 46 }, 19, new List<(short, short)> { (1, 100) }, "tex_sect_yuanshanpai", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(24, EMapBlockType.Sect, EMapBlockSubType.ShixiangMen, LocalStringManager.GetConfig("MapBlock_language", "Name_24"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_24"), LocalStringManager.GetConfig("MapBlock_language", "Desc_24"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_shixiang", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_shixiang/eff_organization_shixiang" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_24_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_24_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_24_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_24_3")
		}, "sect_shixiangmen_xiongshijiuwu", new string[4] { "Ambience_map_13", " Ambience_map_13", " Ambience_map_shixiangmen_2", " Ambience_map_shixiangmen_1" }, 12, 4, 244, 8, "狮相门", new List<short> { 48, 293, 308, 264, 46, 46, 47, 47 }, new List<short> { 46, 47 }, 20, new List<(short, short)> { (1, 100) }, "tex_sect_shixiangmen", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(25, EMapBlockType.Sect, EMapBlockSubType.RanshanPai, LocalStringManager.GetConfig("MapBlock_language", "Name_25"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_25"), LocalStringManager.GetConfig("MapBlock_language", "Desc_25"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_ranshan", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_ranshan/eff_organization_ranshan" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_25_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_25_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_25_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_25_3")
		}, "sect_ranshanpai", new string[4] { "Ambience_map_14", " Ambience_map_ranshan_1", " Ambience_map_14", " Ambience_map_14" }, 10, 2, 245, 8, "然山派", new List<short> { 48, 294, 309, 265, 46 }, new List<short> { 46 }, 21, new List<(short, short)> { (1, 100) }, "tex_sect_ranshanpai", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(26, EMapBlockType.Sect, EMapBlockSubType.XuannvPai, LocalStringManager.GetConfig("MapBlock_language", "Name_26"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_26"), LocalStringManager.GetConfig("MapBlock_language", "Desc_26"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_xuannv", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_xuannv/eff_organization_xuannv" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_26_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_26_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_26_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_26_3")
		}, "sect_xuannvpai_xuannvfeng", new string[4] { "Ambience_map_xuannv_3", " Ambience_map_xuannv_2", " Ambience_map_xuannv_1", " Ambience_map_xuannv_1" }, 12, 5, 246, 8, "璇女派", new List<short> { 48, 295, 310, 266, 46, 46, 47, 47 }, new List<short> { 46, 47 }, 22, new List<(short, short)> { (1, 100) }, "tex_sect_xuannvpai", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 18));
		_dataArray.Add(new MapBlockItem(27, EMapBlockType.Sect, EMapBlockSubType.ZhujianShanzhuang, LocalStringManager.GetConfig("MapBlock_language", "Name_27"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_27"), LocalStringManager.GetConfig("MapBlock_language", "Desc_27"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_zhujian", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_zhujian/eff_organization_zhujian" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_27_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_27_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_27_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_27_3")
		}, "sect_zhujianshanzhuang_tiehao", new string[4] { "Ambience_map_zhujian_2", " Ambience_map_zhujian_1", " Ambience_map_13", " Ambience_map_zhujian_1" }, 12, 1, 247, 8, "铸剑山庄", new List<short> { 48, 296, 311, 267, 46, 46, 47, 47 }, new List<short> { 46, 47 }, 23, new List<(short, short)> { (1, 100) }, "tex_sect_zhujianshanzhuang", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
		_dataArray.Add(new MapBlockItem(28, EMapBlockType.Sect, EMapBlockSubType.KongsangPai, LocalStringManager.GetConfig("MapBlock_language", "Name_28"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_28"), LocalStringManager.GetConfig("MapBlock_language", "Desc_28"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_kongsang", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_kongsang/eff_organization_kongsang" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_28_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_28_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_28_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_28_3")
		}, "sect_kongsangpai", new string[4] { "Ambience_map_14", " Ambience_map_15", " Ambience_map_15", " Ambience_map_15" }, 12, 5, 248, 8, "空桑派", new List<short> { 48, 297, 312, 268, 46, 46 }, new List<short> { 46, 46 }, 24, new List<(short, short)> { (1, 100) }, "tex_sect_kongsangpai", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(29, EMapBlockType.Sect, EMapBlockSubType.JingangZong, LocalStringManager.GetConfig("MapBlock_language", "Name_29"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_29"), LocalStringManager.GetConfig("MapBlock_language", "Desc_29"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_jingang", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_jingang/eff_organization_jingang" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_29_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_29_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_29_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_29_3")
		}, "sect_jingangzong", new string[4] { "Ambience_map_jingangzong_1", " Ambience_map_15", " Ambience_map_jingangzong_2", " Ambience_map_jingangzong_1" }, 16, 1, 249, 8, "金刚宗", new List<short> { 48, 298, 313, 269, 46, 46, 47, 47 }, new List<short> { 46, 46, 46, 47, 47, 47 }, 25, new List<(short, short)> { (1, 100) }, "tex_sect_jingangzong", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
		_dataArray.Add(new MapBlockItem(30, EMapBlockType.Sect, EMapBlockSubType.WuxianJiao, LocalStringManager.GetConfig("MapBlock_language", "Name_30"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_30"), LocalStringManager.GetConfig("MapBlock_language", "Desc_30"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_wuxian", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_wuxian/eff_organization_wuxian" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_30_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_30_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_30_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_30_3")
		}, "sect_wuxianjiao_wuxian", new string[4] { "Ambience_map_wuxian_3", " Ambience_map_wuxian_2", " Ambience_map_wuxian_4", " Ambience_map_wuxian_1" }, 12, 2, 250, 8, "五仙教", new List<short> { 48, 299, 314, 270, 46, 46 }, new List<short> { 46, 46 }, 26, new List<(short, short)> { (1, 100) }, "tex_sect_wuxianjiao", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(31, EMapBlockType.Sect, EMapBlockSubType.JieqingMen, LocalStringManager.GetConfig("MapBlock_language", "Name_31"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_31"), LocalStringManager.GetConfig("MapBlock_language", "Desc_31"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_jieqing", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_jieqing/eff_organization_jieqing" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_31_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_31_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_31_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_31_3")
		}, "sect_jieqingya", new string[4] { "Ambience_map_4", " Ambience_map_4", " Ambience_map_4", " Ambience_map_4" }, 10, 2, 251, 8, "界青门", new List<short> { 48, 300, 315, 271, 275, 46 }, new List<short> { 46 }, 27, new List<(short, short)> { (1, 100) }, "tex_sect_jieqingya", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(32, EMapBlockType.Sect, EMapBlockSubType.FulongTan, LocalStringManager.GetConfig("MapBlock_language", "Name_32"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_32"), LocalStringManager.GetConfig("MapBlock_language", "Desc_32"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_fulong", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_fulong/eff_organization_fulong" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_32_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_32_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_32_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_32_3")
		}, "sect_fulongtan", new string[4] { "Ambience_map_fulongtan_1", " Ambience_map_fulongtan_1", " Ambience_map_fulongtan_1", " Ambience_map_fulongtan_2" }, 16, 4, 252, 8, "伏龙坛", new List<short> { 48, 301, 316, 272, 46, 46, 46, 47, 47, 47 }, new List<short> { 46, 46, 46, 47, 47, 47 }, 28, new List<(short, short)> { (1, 100) }, "tex_sect_fulongtan", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(33, EMapBlockType.Sect, EMapBlockSubType.XuehouJiao, LocalStringManager.GetConfig("MapBlock_language", "Name_33"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_33"), LocalStringManager.GetConfig("MapBlock_language", "Desc_33"), 2, 3, 5, 1, 1, freeStepIgnorePathCost: true, showTips: true, "sect_xuehou", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: true, null, eventBackgroundWinter: true, new string[1] { "Organization_xuehou/eff_organization_xuehou" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_33_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_33_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_33_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_33_3")
		}, "sect_xuehoujiao_xueji", new string[4] { "Ambience_map_xuehou_2", " Ambience_map_xuehou_1", " Ambience_map_10", " Ambience_map_xuehou_2" }, 12, 3, 253, 8, "血犼教", new List<short> { 48, 302, 317, 273, 46, 47 }, new List<short> { 47, 47 }, 29, new List<(short, short)> { (1, 100) }, "tex_sect_xuehoujiao", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(34, EMapBlockType.Town, EMapBlockSubType.Village, LocalStringManager.GetConfig("MapBlock_language", "Name_34"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_34"), LocalStringManager.GetConfig("MapBlock_language", "Desc_34"), 1, 3, 4, 1, 1, freeStepIgnorePathCost: true, showTips: true, "town_village", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[0], miniSceneHaveDirection: true, miniSceneHaveWinter: true, "town_village", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[0], null, new string[1] { "Ambience_map_1" }, 10, -1, 254, 5, null, new List<short> { 48, 286, 46, 46, 49 }, new List<short> { 46, 46 }, -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_town_village", 11, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 1));
		_dataArray.Add(new MapBlockItem(35, EMapBlockType.Town, EMapBlockSubType.Town, LocalStringManager.GetConfig("MapBlock_language", "Name_35"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_35"), LocalStringManager.GetConfig("MapBlock_language", "Desc_35"), 1, 3, 4, 1, 1, freeStepIgnorePathCost: true, showTips: true, "town_town", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[0], miniSceneHaveDirection: true, miniSceneHaveWinter: true, "town_town", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[0], null, new string[1] { "Ambience_map_1" }, 12, -1, 255, 5, null, new List<short> { 48, 285, 46, 46, 46, 47, 47, 47 }, new List<short> { 85, 92, 99, 106, 113, 213 }, -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_town_town", 20, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 2));
		_dataArray.Add(new MapBlockItem(36, EMapBlockType.Town, EMapBlockSubType.WalledTown, LocalStringManager.GetConfig("MapBlock_language", "Name_36"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_36"), LocalStringManager.GetConfig("MapBlock_language", "Desc_36"), 1, 3, 4, 1, 1, freeStepIgnorePathCost: true, showTips: true, "town_walled_town", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[0], miniSceneHaveDirection: true, miniSceneHaveWinter: true, "town_walled_town", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[0], null, new string[1] { "Ambience_map_11" }, 12, -1, 256, 5, null, new List<short> { 48, 287, 52, 46, 46, 46, 46, 46 }, new List<short> { 129, 139, 179, 169, 120, 203 }, -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_town_walledtown", 10, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 12));
		_dataArray.Add(new MapBlockItem(37, EMapBlockType.Station, EMapBlockSubType.Station, LocalStringManager.GetConfig("MapBlock_language", "Name_37"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_37"), LocalStringManager.GetConfig("MapBlock_language", "Desc_37"), 1, 0, 3, 1, 1, freeStepIgnorePathCost: true, showTips: true, "station_station", new int[0], blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[0], miniSceneHaveDirection: true, miniSceneHaveWinter: true, "station_station", eventBackgroundWinter: true, new string[1] { "Station_1/eff_Station1" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_station_travefixed", 11, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 12));
		_dataArray.Add(new MapBlockItem(38, EMapBlockType.Station, EMapBlockSubType.Station, LocalStringManager.GetConfig("MapBlock_language", "Name_38"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_38"), LocalStringManager.GetConfig("MapBlock_language", "Desc_38"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "station_broken_station", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "station_station", eventBackgroundWinter: true, new string[1] { "Station_2/eff_Station2" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], 0, -1, new string[0], null, new string[0], -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_station_traveruined", 11, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 12));
		_dataArray.Add(new MapBlockItem(39, EMapBlockType.Developed, EMapBlockSubType.Farmland, LocalStringManager.GetConfig("MapBlock_language", "Name_39"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_39"), LocalStringManager.GetConfig("MapBlock_language", "Desc_39"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_food", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_food", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 0 }, new short[6] { 150, -10, -10, -10, -10, -10 }, 1, 1000, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_farmland", 5, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 1));
		_dataArray.Add(new MapBlockItem(40, EMapBlockType.Developed, EMapBlockSubType.Farmland, LocalStringManager.GetConfig("MapBlock_language", "Name_40"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_40"), LocalStringManager.GetConfig("MapBlock_language", "Desc_40"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_food", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_food", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 0 }, new short[6] { 150, -10, -10, -10, -10, -10 }, 1, 1000, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_farmland", 5, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 1));
		_dataArray.Add(new MapBlockItem(41, EMapBlockType.Developed, EMapBlockSubType.Farmland, LocalStringManager.GetConfig("MapBlock_language", "Name_41"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_41"), LocalStringManager.GetConfig("MapBlock_language", "Desc_41"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_food", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_food", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 0 }, new short[6] { 150, -10, -10, -10, -10, -10 }, 1, 1000, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_farmland", 5, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 1));
		_dataArray.Add(new MapBlockItem(42, EMapBlockType.Developed, EMapBlockSubType.Gardens, LocalStringManager.GetConfig("MapBlock_language", "Name_42"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_42"), LocalStringManager.GetConfig("MapBlock_language", "Desc_42"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_wood", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_wood", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 1 }, new short[6] { -10, 150, -10, -10, -10, -10 }, 2, 1000, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_gardens", 3, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 2));
		_dataArray.Add(new MapBlockItem(43, EMapBlockType.Developed, EMapBlockSubType.Gardens, LocalStringManager.GetConfig("MapBlock_language", "Name_43"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_43"), LocalStringManager.GetConfig("MapBlock_language", "Desc_43"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_wood", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_wood", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 1 }, new short[6] { -10, 150, -10, -10, -10, -10 }, 2, 1000, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_gardens", 3, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 2));
		_dataArray.Add(new MapBlockItem(44, EMapBlockType.Developed, EMapBlockSubType.Gardens, LocalStringManager.GetConfig("MapBlock_language", "Name_44"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_44"), LocalStringManager.GetConfig("MapBlock_language", "Desc_44"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_wood", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_wood", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 1 }, new short[6] { -10, 150, -10, -10, -10, -10 }, 2, 1000, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_gardens", 3, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 2));
		_dataArray.Add(new MapBlockItem(45, EMapBlockType.Developed, EMapBlockSubType.StoneForest, LocalStringManager.GetConfig("MapBlock_language", "Name_45"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_45"), LocalStringManager.GetConfig("MapBlock_language", "Desc_45"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "developed_metal", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_metal", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 2 }, new short[6] { -10, -10, 150, -10, -10, -10 }, 3, 1000, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_stoneforest", 37, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 3));
		_dataArray.Add(new MapBlockItem(46, EMapBlockType.Developed, EMapBlockSubType.StoneForest, LocalStringManager.GetConfig("MapBlock_language", "Name_46"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_46"), LocalStringManager.GetConfig("MapBlock_language", "Desc_46"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "developed_metal", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_metal", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 2 }, new short[6] { -10, -10, 150, -10, -10, -10 }, 3, 1000, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_stoneforest", 37, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 3));
		_dataArray.Add(new MapBlockItem(47, EMapBlockType.Developed, EMapBlockSubType.StoneForest, LocalStringManager.GetConfig("MapBlock_language", "Name_47"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_47"), LocalStringManager.GetConfig("MapBlock_language", "Desc_47"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "developed_metal", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_metal", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 2 }, new short[6] { -10, -10, 150, -10, -10, -10 }, 3, 1000, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_stoneforest", 37, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 3));
		_dataArray.Add(new MapBlockItem(48, EMapBlockType.Developed, EMapBlockSubType.MulberryField, LocalStringManager.GetConfig("MapBlock_language", "Name_48"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_48"), LocalStringManager.GetConfig("MapBlock_language", "Desc_48"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_fabric", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_fabric", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 4 }, new short[6] { -10, -10, -10, -10, 150, -10 }, 5, 1000, new string[0], null, new string[1] { "Ambience_map_2" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_herbalgarden", 5, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 1));
		_dataArray.Add(new MapBlockItem(49, EMapBlockType.Developed, EMapBlockSubType.MulberryField, LocalStringManager.GetConfig("MapBlock_language", "Name_49"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_49"), LocalStringManager.GetConfig("MapBlock_language", "Desc_49"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_fabric", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_fabric", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 4 }, new short[6] { -10, -10, -10, -10, 150, -10 }, 5, 1000, new string[0], null, new string[1] { "Ambience_map_2" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_herbalgarden", 5, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 1));
		_dataArray.Add(new MapBlockItem(50, EMapBlockType.Developed, EMapBlockSubType.MulberryField, LocalStringManager.GetConfig("MapBlock_language", "Name_50"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_50"), LocalStringManager.GetConfig("MapBlock_language", "Desc_50"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_fabric", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_fabric", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 4 }, new short[6] { -10, -10, -10, -10, 150, -10 }, 5, 1000, new string[0], null, new string[1] { "Ambience_map_2" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_herbalgarden", 5, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 1));
		_dataArray.Add(new MapBlockItem(51, EMapBlockType.Developed, EMapBlockSubType.HerbalGarden, LocalStringManager.GetConfig("MapBlock_language", "Name_51"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_51"), LocalStringManager.GetConfig("MapBlock_language", "Desc_51"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_herb", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_herb", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 5 }, new short[6] { -10, -10, -10, -10, -10, 150 }, 6, 1000, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_mulberryfield", 3, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 1));
		_dataArray.Add(new MapBlockItem(52, EMapBlockType.Developed, EMapBlockSubType.HerbalGarden, LocalStringManager.GetConfig("MapBlock_language", "Name_52"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_52"), LocalStringManager.GetConfig("MapBlock_language", "Desc_52"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_herb", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_herb", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 5 }, new short[6] { -10, -10, -10, -10, -10, 150 }, 6, 1000, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_mulberryfield", 3, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 1));
		_dataArray.Add(new MapBlockItem(53, EMapBlockType.Developed, EMapBlockSubType.HerbalGarden, LocalStringManager.GetConfig("MapBlock_language", "Name_53"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_53"), LocalStringManager.GetConfig("MapBlock_language", "Desc_53"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "developed_herb", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_herb", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 5 }, new short[6] { -10, -10, -10, -10, -10, 150 }, 6, 1000, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_mulberryfield", 3, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 1));
		_dataArray.Add(new MapBlockItem(54, EMapBlockType.Developed, EMapBlockSubType.JadeMountain, LocalStringManager.GetConfig("MapBlock_language", "Name_54"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_54"), LocalStringManager.GetConfig("MapBlock_language", "Desc_54"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "developed_jade", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_jade", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 3 }, new short[6] { -10, -10, -10, 150, -10, -10 }, 4, 1000, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_jademountain", 37, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 6));
		_dataArray.Add(new MapBlockItem(55, EMapBlockType.Developed, EMapBlockSubType.JadeMountain, LocalStringManager.GetConfig("MapBlock_language", "Name_55"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_55"), LocalStringManager.GetConfig("MapBlock_language", "Desc_55"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "developed_jade", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_jade", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 3 }, new short[6] { -10, -10, -10, 150, -10, -10 }, 4, 1000, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_jademountain", 37, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 6));
		_dataArray.Add(new MapBlockItem(56, EMapBlockType.Developed, EMapBlockSubType.JadeMountain, LocalStringManager.GetConfig("MapBlock_language", "Name_56"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_56"), LocalStringManager.GetConfig("MapBlock_language", "Desc_56"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "developed_jade", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "developed_jade", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 3 }, new short[6] { -10, -10, -10, 150, -10, -10 }, 4, 1000, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_developedl_jademountain", 37, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 6));
		_dataArray.Add(new MapBlockItem(57, EMapBlockType.Normal, EMapBlockSubType.Mountain, LocalStringManager.GetConfig("MapBlock_language", "Name_57"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_57"), LocalStringManager.GetConfig("MapBlock_language", "Desc_57"), 1, 0, 2, 3, 3, freeStepIgnorePathCost: true, showTips: true, "normal_mountain", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_mountain", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 60, new List<sbyte> { 2 }, new short[6] { -18, -18, 125, -10, -18, -18 }, 9, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_mountain", 8, 131, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
		_dataArray.Add(new MapBlockItem(58, EMapBlockType.Normal, EMapBlockSubType.Mountain, LocalStringManager.GetConfig("MapBlock_language", "Name_58"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_58"), LocalStringManager.GetConfig("MapBlock_language", "Desc_58"), 1, 0, 2, 3, 3, freeStepIgnorePathCost: true, showTips: true, "normal_mountain", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_mountain", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 61, new List<sbyte> { 2 }, new short[6] { -18, -18, 125, -10, -18, -18 }, 9, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_mountain", 8, 131, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
		_dataArray.Add(new MapBlockItem(59, EMapBlockType.Normal, EMapBlockSubType.Mountain, LocalStringManager.GetConfig("MapBlock_language", "Name_59"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_59"), LocalStringManager.GetConfig("MapBlock_language", "Desc_59"), 1, 0, 2, 3, 3, freeStepIgnorePathCost: true, showTips: true, "normal_mountain", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_mountain", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 62, new List<sbyte> { 2 }, new short[6] { -18, -18, 125, -10, -18, -18 }, 9, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_mountain", 8, 131, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new MapBlockItem(60, EMapBlockType.Normal, EMapBlockSubType.BigMountain, LocalStringManager.GetConfig("MapBlock_language", "Name_60"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_60"), LocalStringManager.GetConfig("MapBlock_language", "Desc_60"), 2, 0, 2, 3, 3, freeStepIgnorePathCost: true, showTips: true, "normal_mountain_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_mountain", eventBackgroundWinter: true, new string[1] { "Block_Mountain/eff_block_mountain" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 57, new List<sbyte> { 2 }, new short[6] { -18, -18, 125, -10, -18, -18 }, 9, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_mountain", 8, 131, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
		_dataArray.Add(new MapBlockItem(61, EMapBlockType.Normal, EMapBlockSubType.BigMountain, LocalStringManager.GetConfig("MapBlock_language", "Name_61"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_61"), LocalStringManager.GetConfig("MapBlock_language", "Desc_61"), 2, 0, 2, 3, 3, freeStepIgnorePathCost: true, showTips: true, "normal_mountain_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_mountain", eventBackgroundWinter: true, new string[1] { "Block_Mountain/eff_block_mountain" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 58, new List<sbyte> { 2 }, new short[6] { -18, -18, 125, -10, -18, -18 }, 9, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_mountain", 8, 131, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
		_dataArray.Add(new MapBlockItem(62, EMapBlockType.Normal, EMapBlockSubType.BigMountain, LocalStringManager.GetConfig("MapBlock_language", "Name_62"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_62"), LocalStringManager.GetConfig("MapBlock_language", "Desc_62"), 2, 0, 2, 3, 3, freeStepIgnorePathCost: true, showTips: true, "normal_mountain_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_mountain", eventBackgroundWinter: true, new string[1] { "Block_Mountain/eff_block_mountain" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 59, new List<sbyte> { 2 }, new short[6] { -18, -18, 125, -10, -18, -18 }, 9, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_mountain", 8, 131, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
		_dataArray.Add(new MapBlockItem(63, EMapBlockType.Normal, EMapBlockSubType.Canyon, LocalStringManager.GetConfig("MapBlock_language", "Name_63"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_63"), LocalStringManager.GetConfig("MapBlock_language", "Desc_63"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_valley", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_valley", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 66, new List<sbyte> { 5 }, new short[6] { -18, -18, -18, -18, -18, 125 }, 12, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_canyon", 22, 132, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(64, EMapBlockType.Normal, EMapBlockSubType.Canyon, LocalStringManager.GetConfig("MapBlock_language", "Name_64"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_64"), LocalStringManager.GetConfig("MapBlock_language", "Desc_64"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_valley", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_valley", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 67, new List<sbyte> { 5 }, new short[6] { -18, -18, -18, -18, -18, 125 }, 12, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_canyon", 22, 132, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(65, EMapBlockType.Normal, EMapBlockSubType.Canyon, LocalStringManager.GetConfig("MapBlock_language", "Name_65"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_65"), LocalStringManager.GetConfig("MapBlock_language", "Desc_65"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_valley", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_valley", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 68, new List<sbyte> { 5 }, new short[6] { -18, -18, -18, -18, -18, 125 }, 12, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_canyon", 22, 132, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(66, EMapBlockType.Normal, EMapBlockSubType.BigCanyon, LocalStringManager.GetConfig("MapBlock_language", "Name_66"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_66"), LocalStringManager.GetConfig("MapBlock_language", "Desc_66"), 2, 0, 2, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_valley_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_valley", eventBackgroundWinter: true, new string[1] { "Block_Valley/eff_block_valley" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 63, new List<sbyte> { 5 }, new short[6] { -18, -18, -18, -18, -18, 125 }, 12, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_canyon", 22, 132, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(67, EMapBlockType.Normal, EMapBlockSubType.BigCanyon, LocalStringManager.GetConfig("MapBlock_language", "Name_67"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_67"), LocalStringManager.GetConfig("MapBlock_language", "Desc_67"), 2, 0, 2, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_valley_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_valley", eventBackgroundWinter: true, new string[1] { "Block_Valley/eff_block_valley" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 64, new List<sbyte> { 5 }, new short[6] { -18, -18, -18, -18, -18, 125 }, 12, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_canyon", 22, 132, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(68, EMapBlockType.Normal, EMapBlockSubType.BigCanyon, LocalStringManager.GetConfig("MapBlock_language", "Name_68"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_68"), LocalStringManager.GetConfig("MapBlock_language", "Desc_68"), 2, 0, 2, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_valley_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_valley", eventBackgroundWinter: true, new string[1] { "Block_Valley/eff_block_valley" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 65, new List<sbyte> { 5 }, new short[6] { -18, -18, -18, -18, -18, 125 }, 12, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_canyon", 22, 132, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(69, EMapBlockType.Normal, EMapBlockSubType.Hill, LocalStringManager.GetConfig("MapBlock_language", "Name_69"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_69"), LocalStringManager.GetConfig("MapBlock_language", "Desc_69"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_hill", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_hill", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 72, new List<sbyte> { 4 }, new short[6] { -18, -18, -18, -18, 125, -18 }, 11, 300, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_hill", 1, 133, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(70, EMapBlockType.Normal, EMapBlockSubType.Hill, LocalStringManager.GetConfig("MapBlock_language", "Name_70"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_70"), LocalStringManager.GetConfig("MapBlock_language", "Desc_70"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_hill", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_hill", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 73, new List<sbyte> { 4 }, new short[6] { -18, -18, -18, -18, 125, -18 }, 11, 300, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_hill", 1, 133, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(71, EMapBlockType.Normal, EMapBlockSubType.Hill, LocalStringManager.GetConfig("MapBlock_language", "Name_71"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_71"), LocalStringManager.GetConfig("MapBlock_language", "Desc_71"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_hill", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_hill", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 74, new List<sbyte> { 4 }, new short[6] { -18, -18, -18, -18, 125, -18 }, 11, 300, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_hill", 1, 133, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(72, EMapBlockType.Normal, EMapBlockSubType.BigHill, LocalStringManager.GetConfig("MapBlock_language", "Name_72"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_72"), LocalStringManager.GetConfig("MapBlock_language", "Desc_72"), 2, 0, 2, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_hill_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_hill", eventBackgroundWinter: true, new string[1] { "Block_Hill/eff_block_hill" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 69, new List<sbyte> { 4 }, new short[6] { -18, -18, -18, -18, 125, -18 }, 11, 300, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_hill", 1, 133, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(73, EMapBlockType.Normal, EMapBlockSubType.BigHill, LocalStringManager.GetConfig("MapBlock_language", "Name_73"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_73"), LocalStringManager.GetConfig("MapBlock_language", "Desc_73"), 2, 0, 2, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_hill_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_hill", eventBackgroundWinter: true, new string[1] { "Block_Hill/eff_block_hill" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 70, new List<sbyte> { 4 }, new short[6] { -18, -18, -18, -18, 125, -18 }, 11, 300, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_hill", 1, 133, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(74, EMapBlockType.Normal, EMapBlockSubType.BigHill, LocalStringManager.GetConfig("MapBlock_language", "Name_74"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_74"), LocalStringManager.GetConfig("MapBlock_language", "Desc_74"), 2, 0, 2, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_hill_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_hill", eventBackgroundWinter: true, new string[1] { "Block_Hill/eff_block_hill" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 71, new List<sbyte> { 4 }, new short[6] { -18, -18, -18, -18, 125, -18 }, 11, 300, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_hill", 1, 133, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(75, EMapBlockType.Normal, EMapBlockSubType.Field, LocalStringManager.GetConfig("MapBlock_language", "Name_75"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_75"), LocalStringManager.GetConfig("MapBlock_language", "Desc_75"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_filed", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_filed", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 78, new List<sbyte> { 0 }, new short[6] { 125, -18, -18, -18, -18, -18 }, 7, 300, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_field", 18, 134, canGenerate: true, "ui9_tex_character_menu_equip_test", 12));
		_dataArray.Add(new MapBlockItem(76, EMapBlockType.Normal, EMapBlockSubType.Field, LocalStringManager.GetConfig("MapBlock_language", "Name_76"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_76"), LocalStringManager.GetConfig("MapBlock_language", "Desc_76"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_filed", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_filed", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 79, new List<sbyte> { 0 }, new short[6] { 125, -18, -18, -18, -18, -18 }, 7, 300, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_field", 18, 134, canGenerate: true, "ui9_tex_character_menu_equip_test", 12));
		_dataArray.Add(new MapBlockItem(77, EMapBlockType.Normal, EMapBlockSubType.Field, LocalStringManager.GetConfig("MapBlock_language", "Name_77"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_77"), LocalStringManager.GetConfig("MapBlock_language", "Desc_77"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_filed", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_filed", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 80, new List<sbyte> { 0 }, new short[6] { 125, -18, -18, -18, -18, -18 }, 7, 300, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_field", 18, 134, canGenerate: true, "ui9_tex_character_menu_equip_test", 12));
		_dataArray.Add(new MapBlockItem(78, EMapBlockType.Normal, EMapBlockSubType.BigField, LocalStringManager.GetConfig("MapBlock_language", "Name_78"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_78"), LocalStringManager.GetConfig("MapBlock_language", "Desc_78"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_filed_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_filed", eventBackgroundWinter: true, new string[1] { "Block_Filed/eff_block_filed" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 75, new List<sbyte> { 0 }, new short[6] { 125, -18, -18, -18, -18, -18 }, 7, 300, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_field", 18, 134, canGenerate: true, "ui9_tex_character_menu_equip_test", 12));
		_dataArray.Add(new MapBlockItem(79, EMapBlockType.Normal, EMapBlockSubType.BigField, LocalStringManager.GetConfig("MapBlock_language", "Name_79"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_79"), LocalStringManager.GetConfig("MapBlock_language", "Desc_79"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_filed_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_filed", eventBackgroundWinter: true, new string[1] { "Block_Filed/eff_block_filed" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 76, new List<sbyte> { 0 }, new short[6] { 125, -18, -18, -18, -18, -18 }, 7, 300, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_field", 18, 134, canGenerate: true, "ui9_tex_character_menu_equip_test", 12));
		_dataArray.Add(new MapBlockItem(80, EMapBlockType.Normal, EMapBlockSubType.BigField, LocalStringManager.GetConfig("MapBlock_language", "Name_80"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_80"), LocalStringManager.GetConfig("MapBlock_language", "Desc_80"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_filed_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_filed", eventBackgroundWinter: true, new string[1] { "Block_Filed/eff_block_filed" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 77, new List<sbyte> { 0 }, new short[6] { 125, -18, -18, -18, -18, -18 }, 7, 300, new string[0], null, new string[1] { "Ambience_map_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_field", 18, 134, canGenerate: true, "ui9_tex_character_menu_equip_test", 12));
		_dataArray.Add(new MapBlockItem(81, EMapBlockType.Normal, EMapBlockSubType.Woodland, LocalStringManager.GetConfig("MapBlock_language", "Name_81"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_81"), LocalStringManager.GetConfig("MapBlock_language", "Desc_81"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_wood", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_wood", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 84, new List<sbyte> { 1 }, new short[6] { -18, 125, -18, -18, -18, -18 }, 8, 300, new string[0], null, new string[1] { "Ambience_map_6" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_woodland", 16, 135, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(82, EMapBlockType.Normal, EMapBlockSubType.Woodland, LocalStringManager.GetConfig("MapBlock_language", "Name_82"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_82"), LocalStringManager.GetConfig("MapBlock_language", "Desc_82"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_wood", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_wood", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 85, new List<sbyte> { 1 }, new short[6] { -18, 125, -18, -18, -18, -18 }, 8, 300, new string[0], null, new string[1] { "Ambience_map_6" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_woodland", 16, 135, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(83, EMapBlockType.Normal, EMapBlockSubType.Woodland, LocalStringManager.GetConfig("MapBlock_language", "Name_83"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_83"), LocalStringManager.GetConfig("MapBlock_language", "Desc_83"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_wood", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_wood", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 86, new List<sbyte> { 1 }, new short[6] { -18, 125, -18, -18, -18, -18 }, 8, 300, new string[0], null, new string[1] { "Ambience_map_6" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_woodland", 16, 135, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(84, EMapBlockType.Normal, EMapBlockSubType.BigWoodland, LocalStringManager.GetConfig("MapBlock_language", "Name_84"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_84"), LocalStringManager.GetConfig("MapBlock_language", "Desc_84"), 2, 0, 2, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_wood_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_wood", eventBackgroundWinter: true, new string[1] { "Block_Wood/eff_block_wood" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 81, new List<sbyte> { 1 }, new short[6] { -18, 125, -18, -18, -18, -18 }, 8, 300, new string[0], null, new string[1] { "Ambience_map_6" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_woodland", 16, 135, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(85, EMapBlockType.Normal, EMapBlockSubType.BigWoodland, LocalStringManager.GetConfig("MapBlock_language", "Name_85"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_85"), LocalStringManager.GetConfig("MapBlock_language", "Desc_85"), 2, 0, 2, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_wood_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_wood", eventBackgroundWinter: true, new string[1] { "Block_Wood/eff_block_wood" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 82, new List<sbyte> { 1 }, new short[6] { -18, 125, -18, -18, -18, -18 }, 8, 300, new string[0], null, new string[1] { "Ambience_map_6" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_woodland", 16, 135, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(86, EMapBlockType.Normal, EMapBlockSubType.BigWoodland, LocalStringManager.GetConfig("MapBlock_language", "Name_86"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_86"), LocalStringManager.GetConfig("MapBlock_language", "Desc_86"), 2, 0, 2, 2, 2, freeStepIgnorePathCost: true, showTips: true, "normal_wood_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_wood", eventBackgroundWinter: true, new string[1] { "Block_Wood/eff_block_wood" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 83, new List<sbyte> { 1 }, new short[6] { -18, 125, -18, -18, -18, -18 }, 8, 300, new string[0], null, new string[1] { "Ambience_map_6" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_woodland", 16, 135, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(87, EMapBlockType.Normal, EMapBlockSubType.RiverBeach, LocalStringManager.GetConfig("MapBlock_language", "Name_87"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_87"), LocalStringManager.GetConfig("MapBlock_language", "Desc_87"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_river", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_river", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 90, new List<sbyte> { 3 }, new short[6] { -18, -18, -18, 125, -18, -18 }, 10, 300, new string[0], null, new string[1] { "Ambience_map_5" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_riverbeach", 38, 136, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(88, EMapBlockType.Normal, EMapBlockSubType.RiverBeach, LocalStringManager.GetConfig("MapBlock_language", "Name_88"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_88"), LocalStringManager.GetConfig("MapBlock_language", "Desc_88"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_river", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_river", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 91, new List<sbyte> { 3 }, new short[6] { -18, -18, -18, 125, -18, -18 }, 10, 300, new string[0], null, new string[1] { "Ambience_map_5" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_riverbeach", 38, 136, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(89, EMapBlockType.Normal, EMapBlockSubType.RiverBeach, LocalStringManager.GetConfig("MapBlock_language", "Name_89"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_89"), LocalStringManager.GetConfig("MapBlock_language", "Desc_89"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_river", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_river", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 92, new List<sbyte> { 3 }, new short[6] { -18, -18, -18, 125, -18, -18 }, 10, 300, new string[0], null, new string[1] { "Ambience_map_5" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_riverbeach", 38, 136, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(90, EMapBlockType.Normal, EMapBlockSubType.BigRiverBeach, LocalStringManager.GetConfig("MapBlock_language", "Name_90"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_90"), LocalStringManager.GetConfig("MapBlock_language", "Desc_90"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_river_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_river", eventBackgroundWinter: true, new string[1] { "Block_River/eff_block_river" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 87, new List<sbyte> { 3 }, new short[6] { -18, -18, -18, 125, -18, -18 }, 10, 300, new string[0], null, new string[1] { "Ambience_map_5" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_riverbeach", 38, 136, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(91, EMapBlockType.Normal, EMapBlockSubType.BigRiverBeach, LocalStringManager.GetConfig("MapBlock_language", "Name_91"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_91"), LocalStringManager.GetConfig("MapBlock_language", "Desc_91"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_river_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_river", eventBackgroundWinter: true, new string[1] { "Block_River/eff_block_river" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 88, new List<sbyte> { 3 }, new short[6] { -18, -18, -18, 125, -18, -18 }, 10, 300, new string[0], null, new string[1] { "Ambience_map_5" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_riverbeach", 38, 136, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(92, EMapBlockType.Normal, EMapBlockSubType.BigRiverBeach, LocalStringManager.GetConfig("MapBlock_language", "Name_92"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_92"), LocalStringManager.GetConfig("MapBlock_language", "Desc_92"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "normal_river_big", new int[0], blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "normal_river", eventBackgroundWinter: true, new string[1] { "Block_River/eff_block_river" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, 89, new List<sbyte> { 3 }, new short[6] { -18, -18, -18, 125, -18, -18 }, 10, 300, new string[0], null, new string[1] { "Ambience_map_5" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_riverbeach", 38, 136, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(93, EMapBlockType.Wild, EMapBlockSubType.Lake, LocalStringManager.GetConfig("MapBlock_language", "Name_93"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_93"), LocalStringManager.GetConfig("MapBlock_language", "Desc_93"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "wild_lake", new int[3] { 1, 2, 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: true, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_lake", eventBackgroundWinter: true, new string[3] { "Block_Water/eff_block_water", "Block_Water/eff_block_water_1", "Block_Water/eff_block_water_2" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 0 }, new short[6] { 100, -14, -14, -14, -14, -14 }, 13, 300, new string[0], null, new string[1] { "Ambience_map_12" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_lake", 13, 137, canGenerate: true, "ui9_tex_character_menu_equip_test", 18));
		_dataArray.Add(new MapBlockItem(94, EMapBlockType.Wild, EMapBlockSubType.Jungle, LocalStringManager.GetConfig("MapBlock_language", "Name_94"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_94"), LocalStringManager.GetConfig("MapBlock_language", "Desc_94"), 1, 0, 1, 3, 3, freeStepIgnorePathCost: true, showTips: true, "wild_forest", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_forest", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 1 }, new short[6] { -14, 100, -14, -14, -14, -14 }, 14, 300, new string[0], null, new string[1] { "Ambience_map_6" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_jungle", 16, 138, canGenerate: true, "ui9_tex_character_menu_equip_test", 19));
		_dataArray.Add(new MapBlockItem(95, EMapBlockType.Wild, EMapBlockSubType.Jungle, LocalStringManager.GetConfig("MapBlock_language", "Name_95"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_95"), LocalStringManager.GetConfig("MapBlock_language", "Desc_95"), 1, 0, 1, 3, 3, freeStepIgnorePathCost: true, showTips: true, "wild_forest", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_forest", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 1 }, new short[6] { -14, 100, -14, -14, -14, -14 }, 14, 300, new string[0], null, new string[1] { "Ambience_map_6" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_jungle", 16, 138, canGenerate: true, "ui9_tex_character_menu_equip_test", 19));
		_dataArray.Add(new MapBlockItem(96, EMapBlockType.Wild, EMapBlockSubType.Jungle, LocalStringManager.GetConfig("MapBlock_language", "Name_96"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_96"), LocalStringManager.GetConfig("MapBlock_language", "Desc_96"), 1, 0, 1, 3, 3, freeStepIgnorePathCost: true, showTips: true, "wild_forest", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_forest", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 1 }, new short[6] { -14, 100, -14, -14, -14, -14 }, 14, 300, new string[0], null, new string[1] { "Ambience_map_6" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_jungle", 16, 138, canGenerate: true, "ui9_tex_character_menu_equip_test", 19));
		_dataArray.Add(new MapBlockItem(97, EMapBlockType.Wild, EMapBlockSubType.Cave, LocalStringManager.GetConfig("MapBlock_language", "Name_97"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_97"), LocalStringManager.GetConfig("MapBlock_language", "Desc_97"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "wild_cave", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_cave", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 2 }, new short[6] { -14, -14, 100, -14, -14, -14 }, 15, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_cave", 2, 139, canGenerate: true, "ui9_tex_character_menu_equip_test", 20));
		_dataArray.Add(new MapBlockItem(98, EMapBlockType.Wild, EMapBlockSubType.Cave, LocalStringManager.GetConfig("MapBlock_language", "Name_98"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_98"), LocalStringManager.GetConfig("MapBlock_language", "Desc_98"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "wild_cave", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_cave", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 2 }, new short[6] { -14, -14, 100, -14, -14, -14 }, 15, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_cave", 2, 139, canGenerate: true, "ui9_tex_character_menu_equip_test", 20));
		_dataArray.Add(new MapBlockItem(99, EMapBlockType.Wild, EMapBlockSubType.Cave, LocalStringManager.GetConfig("MapBlock_language", "Name_99"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_99"), LocalStringManager.GetConfig("MapBlock_language", "Desc_99"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "wild_cave", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_cave", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 2 }, new short[6] { -14, -14, 100, -14, -14, -14 }, 15, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_cave", 2, 139, canGenerate: true, "ui9_tex_character_menu_equip_test", 20));
		_dataArray.Add(new MapBlockItem(100, EMapBlockType.Wild, EMapBlockSubType.Swamp, LocalStringManager.GetConfig("MapBlock_language", "Name_100"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_100"), LocalStringManager.GetConfig("MapBlock_language", "Desc_100"), 1, 0, 1, 3, 3, freeStepIgnorePathCost: true, showTips: true, "wild_swamp", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_swamp", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 5 }, new short[6] { -14, -14, -14, -14, -14, 100 }, 18, 300, new string[0], null, new string[1] { "Ambience_map_9" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_swamp", 12, 140, canGenerate: true, "ui9_tex_character_menu_equip_test", 21));
		_dataArray.Add(new MapBlockItem(101, EMapBlockType.Wild, EMapBlockSubType.Swamp, LocalStringManager.GetConfig("MapBlock_language", "Name_101"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_101"), LocalStringManager.GetConfig("MapBlock_language", "Desc_101"), 1, 0, 1, 3, 3, freeStepIgnorePathCost: true, showTips: true, "wild_swamp", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_swamp", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 5 }, new short[6] { -14, -14, -14, -14, -14, 100 }, 18, 300, new string[0], null, new string[1] { "Ambience_map_9" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_swamp", 12, 140, canGenerate: true, "ui9_tex_character_menu_equip_test", 21));
		_dataArray.Add(new MapBlockItem(102, EMapBlockType.Wild, EMapBlockSubType.Swamp, LocalStringManager.GetConfig("MapBlock_language", "Name_102"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_102"), LocalStringManager.GetConfig("MapBlock_language", "Desc_102"), 1, 0, 1, 3, 3, freeStepIgnorePathCost: true, showTips: true, "wild_swamp", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_swamp", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 5 }, new short[6] { -14, -14, -14, -14, -14, 100 }, 18, 300, new string[0], null, new string[1] { "Ambience_map_9" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_swamp", 12, 140, canGenerate: true, "ui9_tex_character_menu_equip_test", 21));
		_dataArray.Add(new MapBlockItem(103, EMapBlockType.Wild, EMapBlockSubType.TaoYuan, LocalStringManager.GetConfig("MapBlock_language", "Name_103"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_103"), LocalStringManager.GetConfig("MapBlock_language", "Desc_103"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "wild_tao", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_tao", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 4 }, new short[6] { -14, -14, -14, -14, 100, -14 }, 17, 300, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_taoyuan", 2, 141, canGenerate: true, "ui9_tex_character_menu_equip_test", 2));
		_dataArray.Add(new MapBlockItem(104, EMapBlockType.Wild, EMapBlockSubType.TaoYuan, LocalStringManager.GetConfig("MapBlock_language", "Name_104"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_104"), LocalStringManager.GetConfig("MapBlock_language", "Desc_104"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "wild_tao", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_tao", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 4 }, new short[6] { -14, -14, -14, -14, 100, -14 }, 17, 300, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_taoyuan", 2, 141, canGenerate: true, "ui9_tex_character_menu_equip_test", 2));
		_dataArray.Add(new MapBlockItem(105, EMapBlockType.Wild, EMapBlockSubType.TaoYuan, LocalStringManager.GetConfig("MapBlock_language", "Name_105"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_105"), LocalStringManager.GetConfig("MapBlock_language", "Desc_105"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "wild_tao", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_tao", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 4 }, new short[6] { -14, -14, -14, -14, 100, -14 }, 17, 300, new string[0], null, new string[1] { "Ambience_map_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_taoyuan", 2, 141, canGenerate: true, "ui9_tex_character_menu_equip_test", 2));
		_dataArray.Add(new MapBlockItem(106, EMapBlockType.Wild, EMapBlockSubType.Valley, LocalStringManager.GetConfig("MapBlock_language", "Name_106"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_106"), LocalStringManager.GetConfig("MapBlock_language", "Desc_106"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "wild_stream", new int[1] { 1 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_stream", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 3 }, new short[6] { -14, -14, -14, 100, -14, -14 }, 16, 300, new string[0], null, new string[1] { "Ambience_map_8" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_valley", 36, 136, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(107, EMapBlockType.Wild, EMapBlockSubType.Valley, LocalStringManager.GetConfig("MapBlock_language", "Name_107"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_107"), LocalStringManager.GetConfig("MapBlock_language", "Desc_107"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "wild_stream", new int[1] { 2 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_stream", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 3 }, new short[6] { -14, -14, -14, 100, -14, -14 }, 16, 300, new string[0], null, new string[1] { "Ambience_map_8" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_valley", 36, 136, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(108, EMapBlockType.Wild, EMapBlockSubType.Valley, LocalStringManager.GetConfig("MapBlock_language", "Name_108"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_108"), LocalStringManager.GetConfig("MapBlock_language", "Desc_108"), 1, 0, 1, 2, 2, freeStepIgnorePathCost: true, showTips: true, "wild_stream", new int[1] { 3 }, blockHasDirection: true, blockHasSeason: true, blockHasFix: false, new int[2] { 1, 2 }, miniSceneHaveDirection: true, miniSceneHaveWinter: true, "wild_stream", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte> { 3 }, new short[6] { -14, -14, -14, 100, -14, -14 }, 16, 300, new string[0], null, new string[1] { "Ambience_map_8" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_valley", 36, 136, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(109, EMapBlockType.Bad, EMapBlockSubType.Wild, LocalStringManager.GetConfig("MapBlock_language", "Name_109"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_109"), LocalStringManager.GetConfig("MapBlock_language", "Desc_109"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_wildland", new int[1] { 1 }, blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[1] { 1 }, miniSceneHaveDirection: false, miniSceneHaveWinter: true, "bad_wildland", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_10" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_wild_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(110, EMapBlockType.Bad, EMapBlockSubType.Wild, LocalStringManager.GetConfig("MapBlock_language", "Name_110"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_110"), LocalStringManager.GetConfig("MapBlock_language", "Desc_110"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_wildland", new int[1] { 2 }, blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[1] { 1 }, miniSceneHaveDirection: false, miniSceneHaveWinter: true, "bad_wildland", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_10" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_wild_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(111, EMapBlockType.Bad, EMapBlockSubType.Wild, LocalStringManager.GetConfig("MapBlock_language", "Name_111"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_111"), LocalStringManager.GetConfig("MapBlock_language", "Desc_111"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_wildland", new int[1] { 3 }, blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[1] { 1 }, miniSceneHaveDirection: false, miniSceneHaveWinter: true, "bad_wildland", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_10" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_wild_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(112, EMapBlockType.Bad, EMapBlockSubType.Wild, LocalStringManager.GetConfig("MapBlock_language", "Name_112"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_112"), LocalStringManager.GetConfig("MapBlock_language", "Desc_112"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_wildland", new int[1] { 4 }, blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[1] { 1 }, miniSceneHaveDirection: false, miniSceneHaveWinter: true, "bad_wildland", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_10" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_wild_1", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(113, EMapBlockType.Bad, EMapBlockSubType.Wild, LocalStringManager.GetConfig("MapBlock_language", "Name_113"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_113"), LocalStringManager.GetConfig("MapBlock_language", "Desc_113"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_wildland", new int[1] { 5 }, blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[1] { 1 }, miniSceneHaveDirection: false, miniSceneHaveWinter: true, "bad_wildland", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_10" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_wild_1", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(114, EMapBlockType.Bad, EMapBlockSubType.Wild, LocalStringManager.GetConfig("MapBlock_language", "Name_114"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_114"), LocalStringManager.GetConfig("MapBlock_language", "Desc_114"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_wildland", new int[1] { 6 }, blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[1] { 1 }, miniSceneHaveDirection: false, miniSceneHaveWinter: true, "bad_wildland", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_10" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_wild_1", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(115, EMapBlockType.Bad, EMapBlockSubType.Wild, LocalStringManager.GetConfig("MapBlock_language", "Name_115"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_115"), LocalStringManager.GetConfig("MapBlock_language", "Desc_115"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_wildland", new int[1] { 7 }, blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[1] { 1 }, miniSceneHaveDirection: false, miniSceneHaveWinter: true, "bad_wildland", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_10" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_wild_2", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(116, EMapBlockType.Bad, EMapBlockSubType.Wild, LocalStringManager.GetConfig("MapBlock_language", "Name_116"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_116"), LocalStringManager.GetConfig("MapBlock_language", "Desc_116"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_wildland", new int[1] { 8 }, blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[1] { 1 }, miniSceneHaveDirection: false, miniSceneHaveWinter: true, "bad_wildland", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_10" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_wild_2", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(117, EMapBlockType.Bad, EMapBlockSubType.Wild, LocalStringManager.GetConfig("MapBlock_language", "Name_117"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_117"), LocalStringManager.GetConfig("MapBlock_language", "Desc_117"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_wildland", new int[1] { 9 }, blockHasDirection: false, blockHasSeason: true, blockHasFix: false, new int[1] { 1 }, miniSceneHaveDirection: false, miniSceneHaveWinter: true, "bad_wildland", eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_10" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_wild_2", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(118, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_118"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_118"), LocalStringManager.GetConfig("MapBlock_language", "Desc_118"), 1, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland", new int[2] { 1, 7 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 142, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_0", 32, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 25));
		_dataArray.Add(new MapBlockItem(119, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_119"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_119"), LocalStringManager.GetConfig("MapBlock_language", "Desc_119"), 1, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland", new int[2] { 2, 7 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 143, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_0", 32, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 25));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new MapBlockItem(120, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_120"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_120"), LocalStringManager.GetConfig("MapBlock_language", "Desc_120"), 1, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland", new int[2] { 3, 7 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 144, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_0", 32, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 25));
		_dataArray.Add(new MapBlockItem(121, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_121"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_121"), LocalStringManager.GetConfig("MapBlock_language", "Desc_121"), 1, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland", new int[2] { 4, 7 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 145, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_1", 32, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 25));
		_dataArray.Add(new MapBlockItem(122, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_122"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_122"), LocalStringManager.GetConfig("MapBlock_language", "Desc_122"), 1, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland", new int[2] { 5, 7 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 146, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_1", 32, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 25));
		_dataArray.Add(new MapBlockItem(123, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_123"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_123"), LocalStringManager.GetConfig("MapBlock_language", "Desc_123"), 1, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland", new int[2] { 6, 7 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 147, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_1", 32, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 25));
		_dataArray.Add(new MapBlockItem(124, EMapBlockType.Bad, EMapBlockSubType.DarkPool, LocalStringManager.GetConfig("MapBlock_language", "Name_124"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_124"), LocalStringManager.GetConfig("MapBlock_language", "Desc_124"), 1, 0, 1, 4, 99, freeStepIgnorePathCost: false, showTips: true, "bad_darkland", new int[6] { 1, 2, 3, 4, 5, 6 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_darkland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_darkpool", 14, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 26));
		_dataArray.Add(new MapBlockItem(125, EMapBlockType.Invalid, EMapBlockSubType.Block, LocalStringManager.GetConfig("MapBlock_language", "Name_125"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_125"), LocalStringManager.GetConfig("MapBlock_language", "Desc_125"), 1, 0, 1, -1, -1, freeStepIgnorePathCost: false, showTips: false, null, new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[0], null, new string[0], -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_valley", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 26));
		_dataArray.Add(new MapBlockItem(126, EMapBlockType.Invalid, EMapBlockSubType.None, LocalStringManager.GetConfig("MapBlock_language", "Name_126"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_126"), LocalStringManager.GetConfig("MapBlock_language", "Desc_126"), 1, 0, 1, -1, -1, freeStepIgnorePathCost: false, showTips: false, null, new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[0], null, new string[0], -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_wild_valley", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 26));
		_dataArray.Add(new MapBlockItem(127, EMapBlockType.scenery, EMapBlockSubType.Scenery_1, LocalStringManager.GetConfig("MapBlock_language", "Name_127"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_127"), LocalStringManager.GetConfig("MapBlock_language", "Desc_127"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, null, new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6] { 150, 150, 150, 150, 150, 150 }, 9, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_127_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_127_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_127_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_127_3")
		}, null, new string[0], -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_normal_mountain", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(128, EMapBlockType.Bad, EMapBlockSubType.SwordTomb, LocalStringManager.GetConfig("MapBlock_language", "Name_128"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_128"), LocalStringManager.GetConfig("MapBlock_language", "Desc_128"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_monvyi", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: false, new string[1] { "SwordTomb_monv/eff_Swordtomb_monv" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_128_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_128_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_128_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_128_3")
		}, null, new string[4] { "Ambience_map_12", "Ambience_map_12", "Ambience_map_12", "Ambience_map_12" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_swordtomb_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 18));
		_dataArray.Add(new MapBlockItem(129, EMapBlockType.Bad, EMapBlockSubType.SwordTomb, LocalStringManager.GetConfig("MapBlock_language", "Name_129"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_129"), LocalStringManager.GetConfig("MapBlock_language", "Desc_129"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_fuxietie", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: false, new string[1] { "SwordTomb_dayue/eff_Swordtomb_dayue" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_129_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_129_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_129_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_129_3")
		}, null, new string[4] { "Ambience_map_boss_5", "Ambience_map_boss_5", "Ambience_map_boss_5", "Ambience_map_boss_5" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_swordtomb_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 10));
		_dataArray.Add(new MapBlockItem(130, EMapBlockType.Bad, EMapBlockSubType.SwordTomb, LocalStringManager.GetConfig("MapBlock_language", "Name_130"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_130"), LocalStringManager.GetConfig("MapBlock_language", "Desc_130"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_daxuanning", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: false, new string[1] { "SwordTomb_jiuhan/eff_Swordtomb_jiuhan" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_130_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_130_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_130_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_130_3")
		}, null, new string[4] { "Ambience_map_15", "Ambience_map_15", "Ambience_map_15", "Ambience_map_15" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_swordtomb_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 26));
		_dataArray.Add(new MapBlockItem(131, EMapBlockType.Bad, EMapBlockSubType.SwordTomb, LocalStringManager.GetConfig("MapBlock_language", "Name_131"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_131"), LocalStringManager.GetConfig("MapBlock_language", "Desc_131"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_fenghuangjian", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: false, new string[1] { "SwordTomb_fenghuangjian/eff_Swordtomb_fenghuangjian" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_131_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_131_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_131_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_131_3")
		}, null, new string[4] { "Ambience_map_boss_3", "Ambience_map_boss_3", "Ambience_map_boss_3", "Ambience_map_boss_3" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_swordtomb_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
		_dataArray.Add(new MapBlockItem(132, EMapBlockType.Bad, EMapBlockSubType.SwordTomb, LocalStringManager.GetConfig("MapBlock_language", "Name_132"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_132"), LocalStringManager.GetConfig("MapBlock_language", "Desc_132"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_fenshenlian", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: false, new string[1] { "SwordTomb_fenshenlian/eff_Swordtomb_fenshenlian" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_132_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_132_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_132_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_132_3")
		}, null, new string[4] { "Ambience_map_boss_2", "Ambience_map_boss_2", "Ambience_map_boss_2", "Ambience_map_boss_2" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_swordtomb_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 7));
		_dataArray.Add(new MapBlockItem(133, EMapBlockType.Bad, EMapBlockSubType.SwordTomb, LocalStringManager.GetConfig("MapBlock_language", "Name_133"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_133"), LocalStringManager.GetConfig("MapBlock_language", "Desc_133"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_jielongpo", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: false, new string[1] { "SwordTomb_xielongpo/eff_Swordtomb_xielongpo" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_133_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_133_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_133_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_133_3")
		}, null, new string[4] { "Ambience_map_10", "Ambience_map_10", "Ambience_map_10", "Ambience_map_10" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_swordtomb_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(134, EMapBlockType.Bad, EMapBlockSubType.SwordTomb, LocalStringManager.GetConfig("MapBlock_language", "Name_134"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_134"), LocalStringManager.GetConfig("MapBlock_language", "Desc_134"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_rongchenyin", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: false, new string[1] { "SwordTomb_yixiang/eff_Swordtomb_yixiang" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_134_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_134_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_134_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_134_3")
		}, null, new string[4] { "Ambience_map_boss_6", "Ambience_map_boss_6", "Ambience_map_boss_6", "Ambience_map_boss_6" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_swordtomb_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 21));
		_dataArray.Add(new MapBlockItem(135, EMapBlockType.Bad, EMapBlockSubType.SwordTomb, LocalStringManager.GetConfig("MapBlock_language", "Name_135"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_135"), LocalStringManager.GetConfig("MapBlock_language", "Desc_135"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_qiumomu", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: false, new string[1] { "SwordTomb_xuefeng/eff_Swordtomb_xuefeng" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_135_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_135_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_135_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_135_3")
		}, null, new string[4] { "Ambience_map_boss_4", "Ambience_map_boss_4", "Ambience_map_boss_4", "Ambience_map_boss_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_swordtomb_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 13));
		_dataArray.Add(new MapBlockItem(136, EMapBlockType.Bad, EMapBlockSubType.SwordTomb, LocalStringManager.GetConfig("MapBlock_language", "Name_136"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_136"), LocalStringManager.GetConfig("MapBlock_language", "Desc_136"), 2, 0, 2, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_guishenxia", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: true, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: false, new string[1] { "SwordTomb_guishenxia/eff_Swordtomb_guishenxia" }, ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[4]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_136_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_136_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_136_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_136_3")
		}, null, new string[4] { "Ambience_map_boss_1", "Ambience_map_boss_1", "Ambience_map_boss_1", "Ambience_map_boss_1" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_swordtomb_0", 0, -1, canGenerate: true, "ui9_tex_character_menu_equip_test", 3));
		_dataArray.Add(new MapBlockItem(137, EMapBlockType.Wild, EMapBlockSubType.DLCLoong, LocalStringManager.GetConfig("MapBlock_language", "Name_137"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_137"), LocalStringManager.GetConfig("MapBlock_language", "Desc_137"), 1, 0, 1, 5, 5, freeStepIgnorePathCost: true, showTips: true, "wild_fiveloong", new int[1] { 1 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[1] { 1 }, miniSceneHaveDirection: false, miniSceneHaveWinter: false, "wild_fiveloong_1", eventBackgroundWinter: false, new string[2] { "Justiselong_jin/eff_wulong_jin_xiao1", "Justiselong_jin/eff_wulong_jin_xiao2" }, ignoreDestroyed: true, taiwuEventChangedBlock: false, -1, new List<sbyte> { 2 }, new short[6] { 0, 0, 300, 90, 90, 150 }, 19, 0, new string[0], null, new string[2] { "Ambience_map_dragon_jin_big", "Ambience_map_dragon_jin_small" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_fiveloong_4_0", 0, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 3));
		_dataArray.Add(new MapBlockItem(138, EMapBlockType.Wild, EMapBlockSubType.DLCLoong, LocalStringManager.GetConfig("MapBlock_language", "Name_138"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_138"), LocalStringManager.GetConfig("MapBlock_language", "Desc_138"), 1, 0, 1, 5, 5, freeStepIgnorePathCost: true, showTips: true, "wild_fiveloong", new int[1] { 2 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: true, new int[1] { 2 }, miniSceneHaveDirection: false, miniSceneHaveWinter: false, "wild_fiveloong_2", eventBackgroundWinter: false, new string[1] { "Justiselong_shui/eff_wulong_shui_xiao1" }, ignoreDestroyed: true, taiwuEventChangedBlock: false, -1, new List<sbyte> { 3 }, new short[6] { 0, 90, 90, 300, 0, 150 }, 20, 0, new string[0], null, new string[2] { "Ambience_map_dragon_shui_big", "Ambience_map_dragon_shui_small" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_fiveloong_4_1", 0, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 3));
		_dataArray.Add(new MapBlockItem(139, EMapBlockType.Wild, EMapBlockSubType.DLCLoong, LocalStringManager.GetConfig("MapBlock_language", "Name_139"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_139"), LocalStringManager.GetConfig("MapBlock_language", "Desc_139"), 1, 0, 1, 5, 5, freeStepIgnorePathCost: true, showTips: true, "wild_fiveloong", new int[1] { 3 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[1] { 3 }, miniSceneHaveDirection: false, miniSceneHaveWinter: false, "wild_fiveloong_3", eventBackgroundWinter: false, new string[2] { "Justiselong_feng/eff_wulong_mu_xiao1", "Justiselong_feng/eff_wulong_mu_xiao2" }, ignoreDestroyed: true, taiwuEventChangedBlock: false, -1, new List<sbyte> { 1 }, new short[6] { 90, 300, 0, 90, 0, 150 }, 21, 0, new string[0], null, new string[2] { "Ambience_map_dragon_mu_big", "Ambience_map_dragon_mu_small" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_fiveloong_4_3", 0, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 3));
		_dataArray.Add(new MapBlockItem(140, EMapBlockType.Wild, EMapBlockSubType.DLCLoong, LocalStringManager.GetConfig("MapBlock_language", "Name_140"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_140"), LocalStringManager.GetConfig("MapBlock_language", "Desc_140"), 1, 0, 1, 5, 5, freeStepIgnorePathCost: true, showTips: true, "wild_fiveloong", new int[1] { 4 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[1] { 4 }, miniSceneHaveDirection: false, miniSceneHaveWinter: false, "wild_fiveloong_4", eventBackgroundWinter: false, new string[1] { "Justiselong_huo/eff_wulong_huo_xiao1" }, ignoreDestroyed: true, taiwuEventChangedBlock: false, -1, new List<sbyte> { 0 }, new short[6] { 300, 90, 0, 0, 90, 150 }, 22, 0, new string[0], null, new string[2] { "Ambience_map_dragon_huo_big", "Ambience_map_dragon_huo_small" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_fiveloong_4_2", 0, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 3));
		_dataArray.Add(new MapBlockItem(141, EMapBlockType.Wild, EMapBlockSubType.DLCLoong, LocalStringManager.GetConfig("MapBlock_language", "Name_141"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_141"), LocalStringManager.GetConfig("MapBlock_language", "Desc_141"), 1, 0, 1, 5, 5, freeStepIgnorePathCost: true, showTips: true, "wild_fiveloong", new int[1] { 5 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[1] { 5 }, miniSceneHaveDirection: false, miniSceneHaveWinter: false, "wild_fiveloong_5", eventBackgroundWinter: false, new string[1] { "Justiselong_sha/eff_wulong_tu_xiao1" }, ignoreDestroyed: true, taiwuEventChangedBlock: false, -1, new List<sbyte> { 4 }, new short[6] { 90, 0, 90, 0, 300, 150 }, 23, 0, new string[0], null, new string[2] { "Ambience_map_dragon_tu_big", "Ambience_map_dragon_tu_small" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_fiveloong_4_4", 0, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 3));
		_dataArray.Add(new MapBlockItem(142, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_142"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_142"), LocalStringManager.GetConfig("MapBlock_language", "Desc_142"), 2, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland_big", new int[2] { 0, 1 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 118, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_0", 32, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 25));
		_dataArray.Add(new MapBlockItem(143, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_143"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_143"), LocalStringManager.GetConfig("MapBlock_language", "Desc_143"), 2, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland_big", new int[2] { 0, 1 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 119, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_0", 32, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 25));
		_dataArray.Add(new MapBlockItem(144, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_144"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_144"), LocalStringManager.GetConfig("MapBlock_language", "Desc_144"), 2, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland_big", new int[2] { 0, 1 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 120, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_0", 32, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 25));
		_dataArray.Add(new MapBlockItem(145, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_145"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_145"), LocalStringManager.GetConfig("MapBlock_language", "Desc_145"), 2, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland_big", new int[2] { 0, 1 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 121, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_1", 32, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 25));
		_dataArray.Add(new MapBlockItem(146, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_146"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_146"), LocalStringManager.GetConfig("MapBlock_language", "Desc_146"), 2, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland_big", new int[2] { 0, 1 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 122, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_1", 32, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 25));
		_dataArray.Add(new MapBlockItem(147, EMapBlockType.Bad, EMapBlockSubType.Ruin, LocalStringManager.GetConfig("MapBlock_language", "Name_147"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_147"), LocalStringManager.GetConfig("MapBlock_language", "Desc_147"), 2, 0, 1, 2, 90, freeStepIgnorePathCost: true, showTips: true, "bad_ruinland_big", new int[2] { 0, 1 }, blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, "bad_ruinland", eventBackgroundWinter: false, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, 123, new List<sbyte>(), new short[6], -1, 300, new string[0], null, new string[1] { "Ambience_map_4" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_mapblockevent_bad_ruin_1", 32, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 25));
		_dataArray.Add(new MapBlockItem(148, EMapBlockType.Bad, EMapBlockSubType.Wild, LocalStringManager.GetConfig("MapBlock_language", "Name_148"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_148"), LocalStringManager.GetConfig("MapBlock_language", "Desc_148"), 3, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "bad_chaishanfurnace", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[9]
		{
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_148_0"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_148_1"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_148_2"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_148_3"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_148_4"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_148_5"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_148_6"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_148_7"),
			LocalStringManager.GetConfig("MapBlock_language", "BlockNames_148_8")
		}, null, new string[9] { "Ambience_map_15", "Ambience_map_15", "Ambience_map_15", "Ambience_map_15", "Ambience_map_15", "Ambience_map_15", "Ambience_map_15", "Ambience_map_15", "Ambience_map_15" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_main_chapter_7_0", 0, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 0));
		_dataArray.Add(new MapBlockItem(149, EMapBlockType.Station, EMapBlockSubType.Station, LocalStringManager.GetConfig("MapBlock_language", "Name_149"), LocalStringManager.GetConfig("MapBlock_language", "AdventureEditorName_149"), LocalStringManager.GetConfig("MapBlock_language", "Desc_149"), 1, 0, 1, 1, 1, freeStepIgnorePathCost: true, showTips: true, "reed_ferry", new int[0], blockHasDirection: false, blockHasSeason: false, blockHasFix: false, new int[0], miniSceneHaveDirection: false, miniSceneHaveWinter: false, null, eventBackgroundWinter: true, new string[0], ignoreDestroyed: false, taiwuEventChangedBlock: false, -1, new List<sbyte>(), new short[6], -1, -1, new string[0], null, new string[1] { "Ambience_map_15" }, -1, -1, -1, -1, null, new List<short>(), new List<short>(), -1, new List<(short, short)> { (1, 100) }, "tex_main_chapter_7_1", 0, -1, canGenerate: false, "ui9_tex_character_menu_equip_test", 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MapBlockItem>(150);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
