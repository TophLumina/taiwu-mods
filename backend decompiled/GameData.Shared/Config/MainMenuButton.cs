using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MainMenuButton : ConfigData<MainMenuButtonItem, byte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 产业视图
		/// </summary>
		public const byte Building = 0;

		/// <summary>
		/// 村民名册
		/// </summary>
		public const byte Villager = 1;

		/// <summary>
		/// 传承名谱
		/// </summary>
		public const byte VillagerRole = 2;

		/// <summary>
		/// 派遣名册
		/// </summary>
		public const byte VillagerAssign = 3;

		/// <summary>
		/// 公开秘闻
		/// </summary>
		public const byte SecretInformation = 4;

		/// <summary>
		/// 势力情报
		/// </summary>
		public const byte SettlementInformation = 5;

		/// <summary>
		/// 查看绘卷
		/// </summary>
		public const byte TaiwuScroll = 6;

		/// <summary>
		/// 太吾传承
		/// </summary>
		public const byte TaiwuScrollLegacy = 7;

		/// <summary>
		/// 铭刻
		/// </summary>
		public const byte Inscribe = 8;

		/// <summary>
		/// 太吾百晓册
		/// </summary>
		public const byte Encyclopedia = 9;

		/// <summary>
		/// 奇书宝典
		/// </summary>
		public const byte LegendaryBook = 10;

		/// <summary>
		/// 太吾日志
		/// </summary>
		public const byte TaiwuLog = 11;

		/// <summary>
		/// 关注
		/// </summary>
		public const byte Follow = 12;

		/// <summary>
		/// 历程
		/// </summary>
		public const byte TaiwuLifeSummary = 13;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 产业视图
		/// </summary>
		public static MainMenuButtonItem Building => Instance[(byte)0];

		/// <summary>
		/// 村民名册
		/// </summary>
		public static MainMenuButtonItem Villager => Instance[(byte)1];

		/// <summary>
		/// 传承名谱
		/// </summary>
		public static MainMenuButtonItem VillagerRole => Instance[(byte)2];

		/// <summary>
		/// 派遣名册
		/// </summary>
		public static MainMenuButtonItem VillagerAssign => Instance[(byte)3];

		/// <summary>
		/// 公开秘闻
		/// </summary>
		public static MainMenuButtonItem SecretInformation => Instance[(byte)4];

		/// <summary>
		/// 势力情报
		/// </summary>
		public static MainMenuButtonItem SettlementInformation => Instance[(byte)5];

		/// <summary>
		/// 查看绘卷
		/// </summary>
		public static MainMenuButtonItem TaiwuScroll => Instance[(byte)6];

		/// <summary>
		/// 太吾传承
		/// </summary>
		public static MainMenuButtonItem TaiwuScrollLegacy => Instance[(byte)7];

		/// <summary>
		/// 铭刻
		/// </summary>
		public static MainMenuButtonItem Inscribe => Instance[(byte)8];

		/// <summary>
		/// 太吾百晓册
		/// </summary>
		public static MainMenuButtonItem Encyclopedia => Instance[(byte)9];

		/// <summary>
		/// 奇书宝典
		/// </summary>
		public static MainMenuButtonItem LegendaryBook => Instance[(byte)10];

		/// <summary>
		/// 太吾日志
		/// </summary>
		public static MainMenuButtonItem TaiwuLog => Instance[(byte)11];

		/// <summary>
		/// 关注
		/// </summary>
		public static MainMenuButtonItem Follow => Instance[(byte)12];

		/// <summary>
		/// 历程
		/// </summary>
		public static MainMenuButtonItem TaiwuLifeSummary => Instance[(byte)13];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
