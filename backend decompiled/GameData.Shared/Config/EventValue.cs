using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventValue : ConfigData<EventValueItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 太吾人物
		/// </summary>
		public const int Taiwu = 0;

		/// <summary>
		/// 当前游戏时间戳
		/// </summary>
		public const int CurrDate = 1;

		/// <summary>
		/// 当前游戏月份
		/// </summary>
		public const int CurrMonth = 2;

		/// <summary>
		/// 当前游戏年份
		/// </summary>
		public const int CurrYear = 3;

		/// <summary>
		/// 本月剩余天数
		/// </summary>
		public const int LeftDaysInCurrMonth = 4;

		/// <summary>
		/// 侵袭等级
		/// </summary>
		public const int XiangshuLevel = 5;

		/// <summary>
		/// 少林派
		/// </summary>
		public const int Shaolin = 7;

		/// <summary>
		/// 峨眉派
		/// </summary>
		public const int Emei = 8;

		/// <summary>
		/// 百花谷
		/// </summary>
		public const int Baihua = 9;

		/// <summary>
		/// 武当派
		/// </summary>
		public const int Wudang = 10;

		/// <summary>
		/// 元山派
		/// </summary>
		public const int Yuanshan = 11;

		/// <summary>
		/// 狮相门
		/// </summary>
		public const int Shixiang = 12;

		/// <summary>
		/// 然山派
		/// </summary>
		public const int Ranshan = 13;

		/// <summary>
		/// 璇女派
		/// </summary>
		public const int Xuannv = 14;

		/// <summary>
		/// 铸剑山庄
		/// </summary>
		public const int Zhujian = 15;

		/// <summary>
		/// 空桑派
		/// </summary>
		public const int Kongsang = 16;

		/// <summary>
		/// 金刚宗
		/// </summary>
		public const int Jingang = 17;

		/// <summary>
		/// 五仙教
		/// </summary>
		public const int Wuxian = 18;

		/// <summary>
		/// 界青门
		/// </summary>
		public const int Jieqing = 19;

		/// <summary>
		/// 伏龙坛
		/// </summary>
		public const int Fulong = 20;

		/// <summary>
		/// 血犼教
		/// </summary>
		public const int Xuehou = 21;

		/// <summary>
		/// 太吾村
		/// </summary>
		public const int TaiwuVillage = 22;

		/// <summary>
		/// 京城
		/// </summary>
		public const int Jingcheng = 23;

		/// <summary>
		/// 成都
		/// </summary>
		public const int Chengdu = 24;

		/// <summary>
		/// 桂州
		/// </summary>
		public const int Guizhou = 25;

		/// <summary>
		/// 襄阳
		/// </summary>
		public const int Xiangyang = 26;

		/// <summary>
		/// 太原
		/// </summary>
		public const int Taiyuan = 27;

		/// <summary>
		/// 广州
		/// </summary>
		public const int Guangzhou = 28;

		/// <summary>
		/// 青州
		/// </summary>
		public const int Qingzhou = 29;

		/// <summary>
		/// 江陵
		/// </summary>
		public const int Jiangling = 30;

		/// <summary>
		/// 福州
		/// </summary>
		public const int Fuzhou = 31;

		/// <summary>
		/// 辽阳
		/// </summary>
		public const int Liaoyang = 32;

		/// <summary>
		/// 秦州
		/// </summary>
		public const int Qinzhou = 33;

		/// <summary>
		/// 大理
		/// </summary>
		public const int Dali = 34;

		/// <summary>
		/// 寿春
		/// </summary>
		public const int Shouchun = 35;

		/// <summary>
		/// 杭州
		/// </summary>
		public const int Hangzhou = 36;

		/// <summary>
		/// 扬州
		/// </summary>
		public const int Yangzhou = 37;

		/// <summary>
		/// 引导竹庐
		/// </summary>
		public const int GuideBambooHouse = 46;

		/// <summary>
		/// 主线深谷竹庐
		/// </summary>
		public const int BambooHouse = 47;

		/// <summary>
		/// 对话人物
		/// </summary>
		public const int InteractingCharacter = 6;

		/// <summary>
		/// 当前奇遇元素
		/// </summary>
		public const int CurrentAdventureElement = 38;

		/// <summary>
		/// 事件左侧人物
		/// </summary>
		public const int EventLeftActorKey = 39;

		/// <summary>
		/// 事件右侧人物
		/// </summary>
		public const int EventRightActorKey = 40;

		/// <summary>
		/// 战斗被捕捉人物
		/// </summary>
		public const int CharIdSeizedInCombat = 41;

		/// <summary>
		/// 战斗发起捕捉人物
		/// </summary>
		public const int UseItemKeySeizeCharacterId = 42;

		/// <summary>
		/// 战斗捕捉人物绳索
		/// </summary>
		public const int ItemKeySeizeCharacterInCombat = 43;

		/// <summary>
		/// 预设常量事件-空事件
		/// </summary>
		public const int PresetConstantEmptyEvent = 44;

		/// <summary>
		/// 预设常量事件-退出奇遇
		/// </summary>
		public const int PresetConstantExitAdventure = 45;

		/// <summary>
		/// 太吾所在地格
		/// </summary>
		public const int TaiwuCurrMapBlock = 48;

		/// <summary>
		/// 太吾村所在地格
		/// </summary>
		public const int TaiwuVillageMapBlock = 49;

		/// <summary>
		/// 太吾村驿站地格
		/// </summary>
		public const int TaiwuVillageStation = 50;

		/// <summary>
		/// 对话人物品级
		/// </summary>
		public const int InteractingGrade = 51;

		/// <summary>
		/// 过去的太吾村所在地格
		/// </summary>
		public const int PastTaiwuVillageMapBlock = 52;

		/// <summary>
		/// 柴山神炉地格
		/// </summary>
		public const int ChaishanFurnace = 53;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 太吾人物
		/// </summary>
		public static EventValueItem Taiwu => Instance[0];

		/// <summary>
		/// 当前游戏时间戳
		/// </summary>
		public static EventValueItem CurrDate => Instance[1];

		/// <summary>
		/// 当前游戏月份
		/// </summary>
		public static EventValueItem CurrMonth => Instance[2];

		/// <summary>
		/// 当前游戏年份
		/// </summary>
		public static EventValueItem CurrYear => Instance[3];

		/// <summary>
		/// 本月剩余天数
		/// </summary>
		public static EventValueItem LeftDaysInCurrMonth => Instance[4];

		/// <summary>
		/// 侵袭等级
		/// </summary>
		public static EventValueItem XiangshuLevel => Instance[5];

		/// <summary>
		/// 少林派
		/// </summary>
		public static EventValueItem Shaolin => Instance[7];

		/// <summary>
		/// 峨眉派
		/// </summary>
		public static EventValueItem Emei => Instance[8];

		/// <summary>
		/// 百花谷
		/// </summary>
		public static EventValueItem Baihua => Instance[9];

		/// <summary>
		/// 武当派
		/// </summary>
		public static EventValueItem Wudang => Instance[10];

		/// <summary>
		/// 元山派
		/// </summary>
		public static EventValueItem Yuanshan => Instance[11];

		/// <summary>
		/// 狮相门
		/// </summary>
		public static EventValueItem Shixiang => Instance[12];

		/// <summary>
		/// 然山派
		/// </summary>
		public static EventValueItem Ranshan => Instance[13];

		/// <summary>
		/// 璇女派
		/// </summary>
		public static EventValueItem Xuannv => Instance[14];

		/// <summary>
		/// 铸剑山庄
		/// </summary>
		public static EventValueItem Zhujian => Instance[15];

		/// <summary>
		/// 空桑派
		/// </summary>
		public static EventValueItem Kongsang => Instance[16];

		/// <summary>
		/// 金刚宗
		/// </summary>
		public static EventValueItem Jingang => Instance[17];

		/// <summary>
		/// 五仙教
		/// </summary>
		public static EventValueItem Wuxian => Instance[18];

		/// <summary>
		/// 界青门
		/// </summary>
		public static EventValueItem Jieqing => Instance[19];

		/// <summary>
		/// 伏龙坛
		/// </summary>
		public static EventValueItem Fulong => Instance[20];

		/// <summary>
		/// 血犼教
		/// </summary>
		public static EventValueItem Xuehou => Instance[21];

		/// <summary>
		/// 太吾村
		/// </summary>
		public static EventValueItem TaiwuVillage => Instance[22];

		/// <summary>
		/// 京城
		/// </summary>
		public static EventValueItem Jingcheng => Instance[23];

		/// <summary>
		/// 成都
		/// </summary>
		public static EventValueItem Chengdu => Instance[24];

		/// <summary>
		/// 桂州
		/// </summary>
		public static EventValueItem Guizhou => Instance[25];

		/// <summary>
		/// 襄阳
		/// </summary>
		public static EventValueItem Xiangyang => Instance[26];

		/// <summary>
		/// 太原
		/// </summary>
		public static EventValueItem Taiyuan => Instance[27];

		/// <summary>
		/// 广州
		/// </summary>
		public static EventValueItem Guangzhou => Instance[28];

		/// <summary>
		/// 青州
		/// </summary>
		public static EventValueItem Qingzhou => Instance[29];

		/// <summary>
		/// 江陵
		/// </summary>
		public static EventValueItem Jiangling => Instance[30];

		/// <summary>
		/// 福州
		/// </summary>
		public static EventValueItem Fuzhou => Instance[31];

		/// <summary>
		/// 辽阳
		/// </summary>
		public static EventValueItem Liaoyang => Instance[32];

		/// <summary>
		/// 秦州
		/// </summary>
		public static EventValueItem Qinzhou => Instance[33];

		/// <summary>
		/// 大理
		/// </summary>
		public static EventValueItem Dali => Instance[34];

		/// <summary>
		/// 寿春
		/// </summary>
		public static EventValueItem Shouchun => Instance[35];

		/// <summary>
		/// 杭州
		/// </summary>
		public static EventValueItem Hangzhou => Instance[36];

		/// <summary>
		/// 扬州
		/// </summary>
		public static EventValueItem Yangzhou => Instance[37];

		/// <summary>
		/// 引导竹庐
		/// </summary>
		public static EventValueItem GuideBambooHouse => Instance[46];

		/// <summary>
		/// 主线深谷竹庐
		/// </summary>
		public static EventValueItem BambooHouse => Instance[47];

		/// <summary>
		/// 对话人物
		/// </summary>
		public static EventValueItem InteractingCharacter => Instance[6];

		/// <summary>
		/// 当前奇遇元素
		/// </summary>
		public static EventValueItem CurrentAdventureElement => Instance[38];

		/// <summary>
		/// 事件左侧人物
		/// </summary>
		public static EventValueItem EventLeftActorKey => Instance[39];

		/// <summary>
		/// 事件右侧人物
		/// </summary>
		public static EventValueItem EventRightActorKey => Instance[40];

		/// <summary>
		/// 战斗被捕捉人物
		/// </summary>
		public static EventValueItem CharIdSeizedInCombat => Instance[41];

		/// <summary>
		/// 战斗发起捕捉人物
		/// </summary>
		public static EventValueItem UseItemKeySeizeCharacterId => Instance[42];

		/// <summary>
		/// 战斗捕捉人物绳索
		/// </summary>
		public static EventValueItem ItemKeySeizeCharacterInCombat => Instance[43];

		/// <summary>
		/// 预设常量事件-空事件
		/// </summary>
		public static EventValueItem PresetConstantEmptyEvent => Instance[44];

		/// <summary>
		/// 预设常量事件-退出奇遇
		/// </summary>
		public static EventValueItem PresetConstantExitAdventure => Instance[45];

		/// <summary>
		/// 太吾所在地格
		/// </summary>
		public static EventValueItem TaiwuCurrMapBlock => Instance[48];

		/// <summary>
		/// 太吾村所在地格
		/// </summary>
		public static EventValueItem TaiwuVillageMapBlock => Instance[49];

		/// <summary>
		/// 太吾村驿站地格
		/// </summary>
		public static EventValueItem TaiwuVillageStation => Instance[50];

		/// <summary>
		/// 对话人物品级
		/// </summary>
		public static EventValueItem InteractingGrade => Instance[51];

		/// <summary>
		/// 过去的太吾村所在地格
		/// </summary>
		public static EventValueItem PastTaiwuVillageMapBlock => Instance[52];

		/// <summary>
		/// 柴山神炉地格
		/// </summary>
		public static EventValueItem ChaishanFurnace => Instance[53];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static EventValue Instance = new EventValue();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "EventArgument", "TemplateId", "ArgBoxKey", "Alias", "ConstValue" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new EventValueItem(0, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_0"), LocalStringManager.GetConfig("EventValue_language", "Desc_0"), null, 6, "Taiwu", null));
		_dataArray.Add(new EventValueItem(1, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_1"), LocalStringManager.GetConfig("EventValue_language", "Desc_1"), null, 1, "CurrDate", null));
		_dataArray.Add(new EventValueItem(2, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_2"), LocalStringManager.GetConfig("EventValue_language", "Desc_2"), null, 1, "CurrMonth", null));
		_dataArray.Add(new EventValueItem(3, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_3"), LocalStringManager.GetConfig("EventValue_language", "Desc_3"), null, 1, "CurrYear", null));
		_dataArray.Add(new EventValueItem(4, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_4"), LocalStringManager.GetConfig("EventValue_language", "Desc_4"), null, 1, "LeftDaysInCurrMonth", null));
		_dataArray.Add(new EventValueItem(5, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_5"), LocalStringManager.GetConfig("EventValue_language", "Desc_5"), null, 1, "XiangshuLevel", null));
		_dataArray.Add(new EventValueItem(6, EEventValueType.Event, LocalStringManager.GetConfig("EventValue_language", "Name_6"), LocalStringManager.GetConfig("EventValue_language", "Desc_6"), "CharacterId", 6, null, null));
		_dataArray.Add(new EventValueItem(7, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_7"), LocalStringManager.GetConfig("EventValue_language", "Desc_7"), null, 10, "Shaolin", null));
		_dataArray.Add(new EventValueItem(8, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_8"), LocalStringManager.GetConfig("EventValue_language", "Desc_8"), null, 10, "Emei", null));
		_dataArray.Add(new EventValueItem(9, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_9"), LocalStringManager.GetConfig("EventValue_language", "Desc_9"), null, 10, "Baihua", null));
		_dataArray.Add(new EventValueItem(10, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_10"), LocalStringManager.GetConfig("EventValue_language", "Desc_10"), null, 10, "Wudang", null));
		_dataArray.Add(new EventValueItem(11, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_11"), LocalStringManager.GetConfig("EventValue_language", "Desc_11"), null, 10, "Yuanshan", null));
		_dataArray.Add(new EventValueItem(12, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_12"), LocalStringManager.GetConfig("EventValue_language", "Desc_12"), null, 10, "Shixiang", null));
		_dataArray.Add(new EventValueItem(13, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_13"), LocalStringManager.GetConfig("EventValue_language", "Desc_13"), null, 10, "Ranshan", null));
		_dataArray.Add(new EventValueItem(14, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_14"), LocalStringManager.GetConfig("EventValue_language", "Desc_14"), null, 10, "Xuannv", null));
		_dataArray.Add(new EventValueItem(15, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_15"), LocalStringManager.GetConfig("EventValue_language", "Desc_15"), null, 10, "Zhujian", null));
		_dataArray.Add(new EventValueItem(16, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_16"), LocalStringManager.GetConfig("EventValue_language", "Desc_16"), null, 10, "Kongsang", null));
		_dataArray.Add(new EventValueItem(17, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_17"), LocalStringManager.GetConfig("EventValue_language", "Desc_17"), null, 10, "Jingang", null));
		_dataArray.Add(new EventValueItem(18, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_18"), LocalStringManager.GetConfig("EventValue_language", "Desc_18"), null, 10, "Wuxian", null));
		_dataArray.Add(new EventValueItem(19, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_19"), LocalStringManager.GetConfig("EventValue_language", "Desc_19"), null, 10, "Jieqing", null));
		_dataArray.Add(new EventValueItem(20, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_20"), LocalStringManager.GetConfig("EventValue_language", "Desc_20"), null, 10, "Fulong", null));
		_dataArray.Add(new EventValueItem(21, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_21"), LocalStringManager.GetConfig("EventValue_language", "Desc_21"), null, 10, "Xuehou", null));
		_dataArray.Add(new EventValueItem(22, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_22"), LocalStringManager.GetConfig("EventValue_language", "Desc_22"), null, 10, "TaiwuVillage", null));
		_dataArray.Add(new EventValueItem(23, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_23"), LocalStringManager.GetConfig("EventValue_language", "Desc_23"), null, 10, "Jingcheng", null));
		_dataArray.Add(new EventValueItem(24, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_24"), LocalStringManager.GetConfig("EventValue_language", "Desc_24"), null, 10, "Chengdu", null));
		_dataArray.Add(new EventValueItem(25, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_25"), LocalStringManager.GetConfig("EventValue_language", "Desc_25"), null, 10, "Guizhou", null));
		_dataArray.Add(new EventValueItem(26, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_26"), LocalStringManager.GetConfig("EventValue_language", "Desc_26"), null, 10, "Xiangyang", null));
		_dataArray.Add(new EventValueItem(27, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_27"), LocalStringManager.GetConfig("EventValue_language", "Desc_27"), null, 10, "Taiyuan", null));
		_dataArray.Add(new EventValueItem(28, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_28"), LocalStringManager.GetConfig("EventValue_language", "Desc_28"), null, 10, "Guangzhou", null));
		_dataArray.Add(new EventValueItem(29, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_29"), LocalStringManager.GetConfig("EventValue_language", "Desc_29"), null, 10, "Qingzhou", null));
		_dataArray.Add(new EventValueItem(30, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_30"), LocalStringManager.GetConfig("EventValue_language", "Desc_30"), null, 10, "Jiangling", null));
		_dataArray.Add(new EventValueItem(31, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_31"), LocalStringManager.GetConfig("EventValue_language", "Desc_31"), null, 10, "Fuzhou", null));
		_dataArray.Add(new EventValueItem(32, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_32"), LocalStringManager.GetConfig("EventValue_language", "Desc_32"), null, 10, "Liaoyang", null));
		_dataArray.Add(new EventValueItem(33, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_33"), LocalStringManager.GetConfig("EventValue_language", "Desc_33"), null, 10, "Qinzhou", null));
		_dataArray.Add(new EventValueItem(34, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_34"), LocalStringManager.GetConfig("EventValue_language", "Desc_34"), null, 10, "Dali", null));
		_dataArray.Add(new EventValueItem(35, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_35"), LocalStringManager.GetConfig("EventValue_language", "Desc_35"), null, 10, "Shouchun", null));
		_dataArray.Add(new EventValueItem(36, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_36"), LocalStringManager.GetConfig("EventValue_language", "Desc_36"), null, 10, "Hangzhou", null));
		_dataArray.Add(new EventValueItem(37, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_37"), LocalStringManager.GetConfig("EventValue_language", "Desc_37"), null, 10, "Yangzhou", null));
		_dataArray.Add(new EventValueItem(38, EEventValueType.Event, LocalStringManager.GetConfig("EventValue_language", "Name_38"), LocalStringManager.GetConfig("EventValue_language", "Desc_38"), "ConchShipPresetKey_ElementId", 82, null, null));
		_dataArray.Add(new EventValueItem(39, EEventValueType.Event, LocalStringManager.GetConfig("EventValue_language", "Name_39"), LocalStringManager.GetConfig("EventValue_language", "Desc_39"), null, 6, "EventLeftActorKey", null));
		_dataArray.Add(new EventValueItem(40, EEventValueType.Event, LocalStringManager.GetConfig("EventValue_language", "Name_40"), LocalStringManager.GetConfig("EventValue_language", "Desc_40"), null, 6, "EventRightActorKey", null));
		_dataArray.Add(new EventValueItem(41, EEventValueType.Event, LocalStringManager.GetConfig("EventValue_language", "Name_41"), LocalStringManager.GetConfig("EventValue_language", "Desc_41"), "CharIdSeizedInCombat", 6, null, null));
		_dataArray.Add(new EventValueItem(42, EEventValueType.Event, LocalStringManager.GetConfig("EventValue_language", "Name_42"), LocalStringManager.GetConfig("EventValue_language", "Desc_42"), "UseItemKeySeizeCharacterId", 6, null, null));
		_dataArray.Add(new EventValueItem(43, EEventValueType.Event, LocalStringManager.GetConfig("EventValue_language", "Name_43"), LocalStringManager.GetConfig("EventValue_language", "Desc_43"), "ItemKeySeizeCharacterInCombat", 7, null, null));
		_dataArray.Add(new EventValueItem(44, EEventValueType.Constant, LocalStringManager.GetConfig("EventValue_language", "Name_44"), LocalStringManager.GetConfig("EventValue_language", "Desc_44"), null, 5, null, null));
		_dataArray.Add(new EventValueItem(45, EEventValueType.Constant, LocalStringManager.GetConfig("EventValue_language", "Name_45"), LocalStringManager.GetConfig("EventValue_language", "Desc_45"), null, 5, null, "88a7b63e-9df4-4d65-ac27-b22f25b9b124"));
		_dataArray.Add(new EventValueItem(46, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_46"), LocalStringManager.GetConfig("EventValue_language", "Desc_46"), null, 10, "GuideBambooHouse", null));
		_dataArray.Add(new EventValueItem(47, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_47"), LocalStringManager.GetConfig("EventValue_language", "Desc_47"), null, 10, "BambooHouse", null));
		_dataArray.Add(new EventValueItem(48, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_48"), LocalStringManager.GetConfig("EventValue_language", "Desc_48"), null, 9, "TaiwuCurrMapBlock", null));
		_dataArray.Add(new EventValueItem(49, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_49"), LocalStringManager.GetConfig("EventValue_language", "Desc_49"), null, 9, "TaiwuVillageMapBlock", null));
		_dataArray.Add(new EventValueItem(50, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_50"), LocalStringManager.GetConfig("EventValue_language", "Desc_50"), null, 9, "TaiwuVillageStation", null));
		_dataArray.Add(new EventValueItem(51, EEventValueType.Event, LocalStringManager.GetConfig("EventValue_language", "Name_51"), LocalStringManager.GetConfig("EventValue_language", "Desc_51"), null, 13, "InteractingGrade", null));
		_dataArray.Add(new EventValueItem(52, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_52"), LocalStringManager.GetConfig("EventValue_language", "Desc_52"), null, 9, "PastTaiwuVillageMapBlock", null));
		_dataArray.Add(new EventValueItem(53, EEventValueType.Global, LocalStringManager.GetConfig("EventValue_language", "Name_53"), LocalStringManager.GetConfig("EventValue_language", "Desc_53"), null, 9, "ChaishanFurnace", null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventValueItem>(54);
		CreateItems0();
	}
}
