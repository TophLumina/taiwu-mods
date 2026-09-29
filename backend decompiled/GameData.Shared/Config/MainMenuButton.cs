using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MainMenuButton : ConfigData<MainMenuButtonItem, byte>
{
	public static class DefKey
	{
		public const byte Building = 0;

		public const byte Villager = 1;

		public const byte VillagerRole = 2;

		public const byte VillagerAssign = 3;

		public const byte SecretInformation = 4;

		public const byte SettlementInformation = 5;

		public const byte TaiwuScroll = 6;

		public const byte TaiwuScrollLegacy = 7;

		public const byte Inscribe = 8;

		public const byte Encyclopedia = 9;

		public const byte LegendaryBook = 10;

		public const byte TaiwuLog = 11;

		public const byte Follow = 12;

		public const byte TaiwuLifeSummary = 13;
	}

	public static class DefValue
	{
		public static MainMenuButtonItem Building => Instance[(byte)0];

		public static MainMenuButtonItem Villager => Instance[(byte)1];

		public static MainMenuButtonItem VillagerRole => Instance[(byte)2];

		public static MainMenuButtonItem VillagerAssign => Instance[(byte)3];

		public static MainMenuButtonItem SecretInformation => Instance[(byte)4];

		public static MainMenuButtonItem SettlementInformation => Instance[(byte)5];

		public static MainMenuButtonItem TaiwuScroll => Instance[(byte)6];

		public static MainMenuButtonItem TaiwuScrollLegacy => Instance[(byte)7];

		public static MainMenuButtonItem Inscribe => Instance[(byte)8];

		public static MainMenuButtonItem Encyclopedia => Instance[(byte)9];

		public static MainMenuButtonItem LegendaryBook => Instance[(byte)10];

		public static MainMenuButtonItem TaiwuLog => Instance[(byte)11];

		public static MainMenuButtonItem Follow => Instance[(byte)12];

		public static MainMenuButtonItem TaiwuLifeSummary => Instance[(byte)13];
	}

	public static MainMenuButton Instance = new MainMenuButton();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Summary", "Desc", "TemplateId", "WorldFunction", "IconPrefix" };

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
		_dataArray.Add(new MainMenuButtonItem(0, LocalStringManager.GetConfig("MainMenuButton_language", "Name_0"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_0"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_0"), allowInGuiding: false, 10, "ui9_btn_main_menu_circle_building"));
		_dataArray.Add(new MainMenuButtonItem(1, LocalStringManager.GetConfig("MainMenuButton_language", "Name_1"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_1"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_1"), allowInGuiding: false, 10, "ui9_btn_main_menu_circle_villager"));
		_dataArray.Add(new MainMenuButtonItem(2, LocalStringManager.GetConfig("MainMenuButton_language", "Name_2"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_2"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_2"), allowInGuiding: false, 10, "ui9_btn_main_menu_circle_villager_role"));
		_dataArray.Add(new MainMenuButtonItem(3, LocalStringManager.GetConfig("MainMenuButton_language", "Name_3"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_3"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_3"), allowInGuiding: false, 10, "ui9_btn_main_menu_circle_villager_assign"));
		_dataArray.Add(new MainMenuButtonItem(4, LocalStringManager.GetConfig("MainMenuButton_language", "Name_4"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_4"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_4"), allowInGuiding: false, 20, "ui9_btn_main_menu_circle_secret_information"));
		_dataArray.Add(new MainMenuButtonItem(5, LocalStringManager.GetConfig("MainMenuButton_language", "Name_5"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_5"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_5"), allowInGuiding: false, 13, "ui9_btn_main_menu_circle_settlement_information"));
		_dataArray.Add(new MainMenuButtonItem(6, LocalStringManager.GetConfig("MainMenuButton_language", "Name_6"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_6"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_6"), allowInGuiding: false, 10, "ui9_btn_main_menu_circle_taiwu_scroll"));
		_dataArray.Add(new MainMenuButtonItem(7, LocalStringManager.GetConfig("MainMenuButton_language", "Name_7"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_7"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_7"), allowInGuiding: false, 10, "ui9_btn_main_menu_circle_taiwu_scroll_legacy"));
		_dataArray.Add(new MainMenuButtonItem(8, LocalStringManager.GetConfig("MainMenuButton_language", "Name_8"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_8"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_8"), allowInGuiding: false, 10, "ui9_btn_main_menu_circle_inscribe"));
		_dataArray.Add(new MainMenuButtonItem(9, LocalStringManager.GetConfig("MainMenuButton_language", "Name_9"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_9"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_9"), allowInGuiding: true, -1, "ui9_btn_main_menu_circle_encyclopedia"));
		_dataArray.Add(new MainMenuButtonItem(10, LocalStringManager.GetConfig("MainMenuButton_language", "Name_10"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_10"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_10"), allowInGuiding: false, 21, "ui9_btn_main_menu_circle_legendary_book"));
		_dataArray.Add(new MainMenuButtonItem(11, LocalStringManager.GetConfig("MainMenuButton_language", "Name_11"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_11"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_11"), allowInGuiding: true, -1, "ui9_btn_main_menu_circle_taiwu_log"));
		_dataArray.Add(new MainMenuButtonItem(12, LocalStringManager.GetConfig("MainMenuButton_language", "Name_12"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_12"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_12"), allowInGuiding: false, -1, "ui9_btn_main_menu_circle_follow"));
		_dataArray.Add(new MainMenuButtonItem(13, LocalStringManager.GetConfig("MainMenuButton_language", "Name_13"), LocalStringManager.GetConfig("MainMenuButton_language", "Summary_13"), LocalStringManager.GetConfig("MainMenuButton_language", "Desc_13"), allowInGuiding: false, -1, "ui9_btn_main_menu_circle_taiwulifesummary"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MainMenuButtonItem>(14);
		CreateItems0();
	}
}
