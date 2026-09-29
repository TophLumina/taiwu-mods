using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class NewFunctionUnlock : ConfigData<NewFunctionUnlockItem, byte>
{
	public static class DefKey
	{
		public const byte Loop = 0;

		public const byte ReadBook = 1;

		public const byte SkillBreak = 2;

		public const byte WorldResourceCollection = 3;

		public const byte Craft = 4;

		public const byte Secret = 5;

		public const byte CracketFight = 6;

		public const byte LifeSkillCombat = 7;

		public const byte Company = 8;

		public const byte MonthlyNotifications = 9;

		public const byte Talk = 10;

		public const byte SendVillager = 11;

		public const byte TaiwuVillageManagement = 12;

		public const byte Aspiration = 13;

		public const byte SwordLegacy = 14;

		public const byte Chicken = 15;

		public const byte InterStateTravel = 16;

		public const byte SkillLearning = 17;

		public const byte SpiritualDebtAction = 18;

		public const byte SkillBookExchange = 19;

		public const byte TeaCaravan = 20;

		public const byte SamsaraPlatform = 21;

		public const byte LegendaryBook = 22;

		public const byte JuniorXiangshuSummoning = 23;

		public const byte MartialArtContest = 24;

		public const byte FreeMode = 25;

		public const byte ReEvolutionJade = 26;

		public const byte WishingCricket = 27;
	}

	public static class DefValue
	{
		public static NewFunctionUnlockItem Loop => Instance[(byte)0];

		public static NewFunctionUnlockItem ReadBook => Instance[(byte)1];

		public static NewFunctionUnlockItem SkillBreak => Instance[(byte)2];

		public static NewFunctionUnlockItem WorldResourceCollection => Instance[(byte)3];

		public static NewFunctionUnlockItem Craft => Instance[(byte)4];

		public static NewFunctionUnlockItem Secret => Instance[(byte)5];

		public static NewFunctionUnlockItem CracketFight => Instance[(byte)6];

		public static NewFunctionUnlockItem LifeSkillCombat => Instance[(byte)7];

		public static NewFunctionUnlockItem Company => Instance[(byte)8];

		public static NewFunctionUnlockItem MonthlyNotifications => Instance[(byte)9];

		public static NewFunctionUnlockItem Talk => Instance[(byte)10];

		public static NewFunctionUnlockItem SendVillager => Instance[(byte)11];

		public static NewFunctionUnlockItem TaiwuVillageManagement => Instance[(byte)12];

		public static NewFunctionUnlockItem Aspiration => Instance[(byte)13];

		public static NewFunctionUnlockItem SwordLegacy => Instance[(byte)14];

		public static NewFunctionUnlockItem Chicken => Instance[(byte)15];

		public static NewFunctionUnlockItem InterStateTravel => Instance[(byte)16];

		public static NewFunctionUnlockItem SkillLearning => Instance[(byte)17];

		public static NewFunctionUnlockItem SpiritualDebtAction => Instance[(byte)18];

		public static NewFunctionUnlockItem SkillBookExchange => Instance[(byte)19];

		public static NewFunctionUnlockItem TeaCaravan => Instance[(byte)20];

		public static NewFunctionUnlockItem SamsaraPlatform => Instance[(byte)21];

		public static NewFunctionUnlockItem LegendaryBook => Instance[(byte)22];

		public static NewFunctionUnlockItem JuniorXiangshuSummoning => Instance[(byte)23];

		public static NewFunctionUnlockItem MartialArtContest => Instance[(byte)24];

		public static NewFunctionUnlockItem FreeMode => Instance[(byte)25];

		public static NewFunctionUnlockItem ReEvolutionJade => Instance[(byte)26];

		public static NewFunctionUnlockItem WishingCricket => Instance[(byte)27];
	}

	public static NewFunctionUnlock Instance = new NewFunctionUnlock();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Title", "Desc", "EncyclopediaTabId", "TemplateId", "Type", "Icon", "UIPage", "EncyclopediaTabFirst", "EncyclopediaTabSecond", "EncyclopediaTabThird",
		"EncyclopediaTabFourth"
	};

	internal override int ToInt(byte value)
	{
		return value;
	}

	internal override byte ToTemplateId(int value)
	{
		return (byte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new NewFunctionUnlockItem(0, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_0"), ENewFunctionUnlockType.Personal, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_0"), "ui9_back_newfeature_icon_0", null, "修习", "修习方式", "周天运转", null, 27));
		_dataArray.Add(new NewFunctionUnlockItem(1, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_1"), ENewFunctionUnlockType.Personal, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_1"), "ui9_back_newfeature_icon_1", null, "修习", "修习方式", "研读书籍", null, 26));
		_dataArray.Add(new NewFunctionUnlockItem(2, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_2"), ENewFunctionUnlockType.SkillBreak, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_2"), "ui9_back_newfeature_icon_2", null, "修习", "武学", "突破", null, 13));
		_dataArray.Add(new NewFunctionUnlockItem(3, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_3"), ENewFunctionUnlockType.Personal, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_3"), "ui9_back_newfeature_icon_3", null, "世界", "世界地图", "地格交互", null, 120));
		_dataArray.Add(new NewFunctionUnlockItem(4, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_4"), ENewFunctionUnlockType.Building, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_4"), "ui9_back_newfeature_icon_4", null, "物品", "制造加工", "制造", null, 70));
		_dataArray.Add(new NewFunctionUnlockItem(5, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_5"), ENewFunctionUnlockType.World, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_5"), "ui9_back_newfeature_icon_5", null, "交互", "交互信息", "秘闻", null, 56));
		_dataArray.Add(new NewFunctionUnlockItem(6, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_6"), ENewFunctionUnlockType.World, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_6"), "ui9_back_newfeature_icon_6", null, "游历", "促织", "促织决斗", null, 71));
		_dataArray.Add(new NewFunctionUnlockItem(7, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_7"), ENewFunctionUnlockType.World, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_7"), "ui9_back_newfeature_icon_7", null, "修习", "技艺", "较艺", null, 61));
		_dataArray.Add(new NewFunctionUnlockItem(8, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_8"), ENewFunctionUnlockType.World, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_8"), "ui9_back_newfeature_icon_8", null, "交互", "其他交互", "同道", null, 121));
		_dataArray.Add(new NewFunctionUnlockItem(9, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_9"), ENewFunctionUnlockType.World, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_9"), "ui9_back_newfeature_icon_9", null, "世界", "世界演化", "月份更替", null, 122));
		_dataArray.Add(new NewFunctionUnlockItem(10, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_10"), ENewFunctionUnlockType.World, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_10"), "ui9_back_newfeature_icon_10", null, "交互", "人物互动", "人物互动", null, 123));
		_dataArray.Add(new NewFunctionUnlockItem(11, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_11"), ENewFunctionUnlockType.Building, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_11"), "ui9_back_newfeature_icon_11", null, "世界", "世界地图", "地格交互", null, 120));
		_dataArray.Add(new NewFunctionUnlockItem(12, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_12"), ENewFunctionUnlockType.TaiwuVillage, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_12"), "ui9_back_newfeature_icon_12", null, "产业", "产业", "产业视图", null, 48));
		_dataArray.Add(new NewFunctionUnlockItem(13, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_13"), ENewFunctionUnlockType.Profession, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_13"), "ui9_back_newfeature_icon_13", null, "游历", "志向", "志向", null, 59));
		_dataArray.Add(new NewFunctionUnlockItem(14, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_14"), ENewFunctionUnlockType.Legacy, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_14"), "ui9_back_newfeature_icon_14", null, "启程", "太吾", "太吾传承", null, 30));
		_dataArray.Add(new NewFunctionUnlockItem(15, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_15"), ENewFunctionUnlockType.Building, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_15"), "ui9_back_newfeature_icon_15", null, "产业", "特殊建筑", "元鸡舍", "元鸡", 124));
		_dataArray.Add(new NewFunctionUnlockItem(16, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_16"), ENewFunctionUnlockType.Map, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_16"), "ui9_back_newfeature_icon_16", null, "世界", "世界地图", "州域与地区", "旅行", 62));
		_dataArray.Add(new NewFunctionUnlockItem(17, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_17"), ENewFunctionUnlockType.World, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_17"), "ui9_back_newfeature_icon_17", null, "门派", "门派概述", "门派", "学艺许可", 125));
		_dataArray.Add(new NewFunctionUnlockItem(18, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_18"), ENewFunctionUnlockType.World, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_18"), "ui9_back_newfeature_icon_18", null, "交互", "人物互动", "门派恩义互动", null, 126));
		_dataArray.Add(new NewFunctionUnlockItem(19, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_19"), ENewFunctionUnlockType.World, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_19"), "ui9_back_newfeature_icon_19", null, "交互", "人物互动", "修习", "交换私人藏书", 127));
		_dataArray.Add(new NewFunctionUnlockItem(20, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_20"), ENewFunctionUnlockType.Building, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_20"), "ui9_back_newfeature_icon_20", null, "产业", "特殊建筑", "茶马帮", null, 46));
		_dataArray.Add(new NewFunctionUnlockItem(21, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_21"), ENewFunctionUnlockType.Building, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_21"), "ui9_back_newfeature_icon_21", null, "产业", "特殊建筑", "轮回台", null, 58));
		_dataArray.Add(new NewFunctionUnlockItem(22, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_22"), ENewFunctionUnlockType.LegendaryBook, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_22"), "ui9_back_newfeature_icon_22", null, "修习", "奇书宝典", "奇书", null, 63));
		_dataArray.Add(new NewFunctionUnlockItem(23, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_23"), ENewFunctionUnlockType.MainStory, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_23"), "ui9_back_newfeature_icon_23", null, "启程", "相枢", "剑冢", "紫竹化身", 128));
		_dataArray.Add(new NewFunctionUnlockItem(24, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_24"), ENewFunctionUnlockType.MainStory, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_24"), "ui9_back_newfeature_icon_24", null, null, null, null, null, -1));
		_dataArray.Add(new NewFunctionUnlockItem(25, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_25"), ENewFunctionUnlockType.Map, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_25"), "ui9_back_newfeature_icon_16", null, "启程", "创建人物", "基本信息", null, 130));
		_dataArray.Add(new NewFunctionUnlockItem(26, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_26"), ENewFunctionUnlockType.ReEvolutionJade, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_26"), null, null, null, null, null, null, -1));
		_dataArray.Add(new NewFunctionUnlockItem(27, 0, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Title_27"), ENewFunctionUnlockType.WishingCricket, LocalStringManager.GetConfig("NewFunctionUnlock_language", "Desc_27"), null, null, null, null, null, null, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<NewFunctionUnlockItem>(28);
		CreateItems0();
	}
}
