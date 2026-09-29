using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventValue : ConfigData<EventValueItem, int>
{
	public static class DefKey
	{
		public const int Taiwu = 0;

		public const int CurrDate = 1;

		public const int CurrMonth = 2;

		public const int CurrYear = 3;

		public const int LeftDaysInCurrMonth = 4;

		public const int XiangshuLevel = 5;

		public const int Shaolin = 7;

		public const int Emei = 8;

		public const int Baihua = 9;

		public const int Wudang = 10;

		public const int Yuanshan = 11;

		public const int Shixiang = 12;

		public const int Ranshan = 13;

		public const int Xuannv = 14;

		public const int Zhujian = 15;

		public const int Kongsang = 16;

		public const int Jingang = 17;

		public const int Wuxian = 18;

		public const int Jieqing = 19;

		public const int Fulong = 20;

		public const int Xuehou = 21;

		public const int TaiwuVillage = 22;

		public const int Jingcheng = 23;

		public const int Chengdu = 24;

		public const int Guizhou = 25;

		public const int Xiangyang = 26;

		public const int Taiyuan = 27;

		public const int Guangzhou = 28;

		public const int Qingzhou = 29;

		public const int Jiangling = 30;

		public const int Fuzhou = 31;

		public const int Liaoyang = 32;

		public const int Qinzhou = 33;

		public const int Dali = 34;

		public const int Shouchun = 35;

		public const int Hangzhou = 36;

		public const int Yangzhou = 37;

		public const int GuideBambooHouse = 46;

		public const int BambooHouse = 47;

		public const int InteractingCharacter = 6;

		public const int CurrentAdventureElement = 38;

		public const int EventLeftActorKey = 39;

		public const int EventRightActorKey = 40;

		public const int CharIdSeizedInCombat = 41;

		public const int UseItemKeySeizeCharacterId = 42;

		public const int ItemKeySeizeCharacterInCombat = 43;

		public const int PresetConstantEmptyEvent = 44;

		public const int PresetConstantExitAdventure = 45;

		public const int TaiwuCurrMapBlock = 48;

		public const int TaiwuVillageMapBlock = 49;

		public const int TaiwuVillageStation = 50;

		public const int InteractingGrade = 51;

		public const int PastTaiwuVillageMapBlock = 52;

		public const int ChaishanFurnace = 53;
	}

	public static class DefValue
	{
		public static EventValueItem Taiwu => Instance[0];

		public static EventValueItem CurrDate => Instance[1];

		public static EventValueItem CurrMonth => Instance[2];

		public static EventValueItem CurrYear => Instance[3];

		public static EventValueItem LeftDaysInCurrMonth => Instance[4];

		public static EventValueItem XiangshuLevel => Instance[5];

		public static EventValueItem Shaolin => Instance[7];

		public static EventValueItem Emei => Instance[8];

		public static EventValueItem Baihua => Instance[9];

		public static EventValueItem Wudang => Instance[10];

		public static EventValueItem Yuanshan => Instance[11];

		public static EventValueItem Shixiang => Instance[12];

		public static EventValueItem Ranshan => Instance[13];

		public static EventValueItem Xuannv => Instance[14];

		public static EventValueItem Zhujian => Instance[15];

		public static EventValueItem Kongsang => Instance[16];

		public static EventValueItem Jingang => Instance[17];

		public static EventValueItem Wuxian => Instance[18];

		public static EventValueItem Jieqing => Instance[19];

		public static EventValueItem Fulong => Instance[20];

		public static EventValueItem Xuehou => Instance[21];

		public static EventValueItem TaiwuVillage => Instance[22];

		public static EventValueItem Jingcheng => Instance[23];

		public static EventValueItem Chengdu => Instance[24];

		public static EventValueItem Guizhou => Instance[25];

		public static EventValueItem Xiangyang => Instance[26];

		public static EventValueItem Taiyuan => Instance[27];

		public static EventValueItem Guangzhou => Instance[28];

		public static EventValueItem Qingzhou => Instance[29];

		public static EventValueItem Jiangling => Instance[30];

		public static EventValueItem Fuzhou => Instance[31];

		public static EventValueItem Liaoyang => Instance[32];

		public static EventValueItem Qinzhou => Instance[33];

		public static EventValueItem Dali => Instance[34];

		public static EventValueItem Shouchun => Instance[35];

		public static EventValueItem Hangzhou => Instance[36];

		public static EventValueItem Yangzhou => Instance[37];

		public static EventValueItem GuideBambooHouse => Instance[46];

		public static EventValueItem BambooHouse => Instance[47];

		public static EventValueItem InteractingCharacter => Instance[6];

		public static EventValueItem CurrentAdventureElement => Instance[38];

		public static EventValueItem EventLeftActorKey => Instance[39];

		public static EventValueItem EventRightActorKey => Instance[40];

		public static EventValueItem CharIdSeizedInCombat => Instance[41];

		public static EventValueItem UseItemKeySeizeCharacterId => Instance[42];

		public static EventValueItem ItemKeySeizeCharacterInCombat => Instance[43];

		public static EventValueItem PresetConstantEmptyEvent => Instance[44];

		public static EventValueItem PresetConstantExitAdventure => Instance[45];

		public static EventValueItem TaiwuCurrMapBlock => Instance[48];

		public static EventValueItem TaiwuVillageMapBlock => Instance[49];

		public static EventValueItem TaiwuVillageStation => Instance[50];

		public static EventValueItem InteractingGrade => Instance[51];

		public static EventValueItem PastTaiwuVillageMapBlock => Instance[52];

		public static EventValueItem ChaishanFurnace => Instance[53];
	}

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
