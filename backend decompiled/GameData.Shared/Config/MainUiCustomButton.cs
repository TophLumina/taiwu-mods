using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MainUiCustomButton : ConfigData<MainUiCustomButtonItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 队伍
		/// </summary>
		public const sbyte Party = 0;

		/// <summary>
		/// 装备
		/// </summary>
		public const sbyte Equipment = 1;

		/// <summary>
		/// 行囊
		/// </summary>
		public const sbyte Inventory = 2;

		/// <summary>
		/// 关押
		/// </summary>
		public const sbyte Prisoner = 3;

		/// <summary>
		/// 造诣
		/// </summary>
		public const sbyte Attainment = 4;

		/// <summary>
		/// 突破
		/// </summary>
		public const sbyte SkillBreak = 5;

		/// <summary>
		/// 内力
		/// </summary>
		public const sbyte Neili = 6;

		/// <summary>
		/// 运功
		/// </summary>
		public const sbyte EquipCombatSkill = 7;

		/// <summary>
		/// 见闻
		/// </summary>
		public const sbyte Information = 8;

		/// <summary>
		/// 秘闻
		/// </summary>
		public const sbyte SecretInformation = 9;

		/// <summary>
		/// 经历
		/// </summary>
		public const sbyte LifeRecord = 10;

		/// <summary>
		/// 诊疗
		/// </summary>
		public const sbyte Heal = 11;

		/// <summary>
		/// 促织陈列
		/// </summary>
		public const sbyte Cricket = 12;

		/// <summary>
		/// 石屋
		/// </summary>
		public const sbyte StoneRoom = 13;

		/// <summary>
		/// 蛟池
		/// </summary>
		public const sbyte Jiao = 14;

		/// <summary>
		/// 茶马帮
		/// </summary>
		public const sbyte TeaCaravan = 15;

		/// <summary>
		/// 轮回台
		/// </summary>
		public const sbyte SamsaraPlatform = 16;

		/// <summary>
		/// 元鸡舍
		/// </summary>
		public const sbyte ChickenCoop = 17;

		/// <summary>
		/// 调遣元鸡
		/// </summary>
		public const sbyte ChickenAssign = 19;

		/// <summary>
		/// 奇纹星斗
		/// </summary>
		public const sbyte SectJieqing = 20;

		/// <summary>
		/// 蛊仙
		/// </summary>
		public const sbyte SectWuxian = 21;

		/// <summary>
		/// 化念珠
		/// </summary>
		public const sbyte SectYuanshan = 22;

		/// <summary>
		/// 孤鸾镜水谣
		/// </summary>
		public const sbyte SectXuannv = 23;

		/// <summary>
		/// 神鸡图
		/// </summary>
		public const sbyte SectFulong = 24;

		/// <summary>
		/// 产业视图
		/// </summary>
		public const sbyte Building = 25;

		/// <summary>
		/// 村民名册
		/// </summary>
		public const sbyte Villager = 26;

		/// <summary>
		/// 传承名谱
		/// </summary>
		public const sbyte Lineage = 18;

		/// <summary>
		/// 派遣名册
		/// </summary>
		public const sbyte VillagerAssign = 27;

		/// <summary>
		/// 势力情报
		/// </summary>
		public const sbyte SettlementInformation = 28;

		/// <summary>
		/// 查看绘卷
		/// </summary>
		public const sbyte TaiwuScroll = 29;

		/// <summary>
		/// 太吾传承
		/// </summary>
		public const sbyte TaiwuScrollLegacy = 30;

		/// <summary>
		/// 铭刻
		/// </summary>
		public const sbyte Inscribe = 31;

		/// <summary>
		/// 太吾百晓册
		/// </summary>
		public const sbyte Encyclopedia = 32;

		/// <summary>
		/// 奇书宝典
		/// </summary>
		public const sbyte LegendaryBook = 33;

		/// <summary>
		/// 太吾日志
		/// </summary>
		public const sbyte TaiwuLog = 34;

		/// <summary>
		/// 关注
		/// </summary>
		public const sbyte Follow = 35;

		/// <summary>
		/// 历程
		/// </summary>
		public const sbyte TaiwuLifeSummary = 36;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 队伍
		/// </summary>
		public static MainUiCustomButtonItem Party => Instance[(sbyte)0];

		/// <summary>
		/// 装备
		/// </summary>
		public static MainUiCustomButtonItem Equipment => Instance[(sbyte)1];

		/// <summary>
		/// 行囊
		/// </summary>
		public static MainUiCustomButtonItem Inventory => Instance[(sbyte)2];

		/// <summary>
		/// 关押
		/// </summary>
		public static MainUiCustomButtonItem Prisoner => Instance[(sbyte)3];

		/// <summary>
		/// 造诣
		/// </summary>
		public static MainUiCustomButtonItem Attainment => Instance[(sbyte)4];

		/// <summary>
		/// 突破
		/// </summary>
		public static MainUiCustomButtonItem SkillBreak => Instance[(sbyte)5];

		/// <summary>
		/// 内力
		/// </summary>
		public static MainUiCustomButtonItem Neili => Instance[(sbyte)6];

		/// <summary>
		/// 运功
		/// </summary>
		public static MainUiCustomButtonItem EquipCombatSkill => Instance[(sbyte)7];

		/// <summary>
		/// 见闻
		/// </summary>
		public static MainUiCustomButtonItem Information => Instance[(sbyte)8];

		/// <summary>
		/// 秘闻
		/// </summary>
		public static MainUiCustomButtonItem SecretInformation => Instance[(sbyte)9];

		/// <summary>
		/// 经历
		/// </summary>
		public static MainUiCustomButtonItem LifeRecord => Instance[(sbyte)10];

		/// <summary>
		/// 诊疗
		/// </summary>
		public static MainUiCustomButtonItem Heal => Instance[(sbyte)11];

		/// <summary>
		/// 促织陈列
		/// </summary>
		public static MainUiCustomButtonItem Cricket => Instance[(sbyte)12];

		/// <summary>
		/// 石屋
		/// </summary>
		public static MainUiCustomButtonItem StoneRoom => Instance[(sbyte)13];

		/// <summary>
		/// 蛟池
		/// </summary>
		public static MainUiCustomButtonItem Jiao => Instance[(sbyte)14];

		/// <summary>
		/// 茶马帮
		/// </summary>
		public static MainUiCustomButtonItem TeaCaravan => Instance[(sbyte)15];

		/// <summary>
		/// 轮回台
		/// </summary>
		public static MainUiCustomButtonItem SamsaraPlatform => Instance[(sbyte)16];

		/// <summary>
		/// 元鸡舍
		/// </summary>
		public static MainUiCustomButtonItem ChickenCoop => Instance[(sbyte)17];

		/// <summary>
		/// 调遣元鸡
		/// </summary>
		public static MainUiCustomButtonItem ChickenAssign => Instance[(sbyte)19];

		/// <summary>
		/// 奇纹星斗
		/// </summary>
		public static MainUiCustomButtonItem SectJieqing => Instance[(sbyte)20];

		/// <summary>
		/// 蛊仙
		/// </summary>
		public static MainUiCustomButtonItem SectWuxian => Instance[(sbyte)21];

		/// <summary>
		/// 化念珠
		/// </summary>
		public static MainUiCustomButtonItem SectYuanshan => Instance[(sbyte)22];

		/// <summary>
		/// 孤鸾镜水谣
		/// </summary>
		public static MainUiCustomButtonItem SectXuannv => Instance[(sbyte)23];

		/// <summary>
		/// 神鸡图
		/// </summary>
		public static MainUiCustomButtonItem SectFulong => Instance[(sbyte)24];

		/// <summary>
		/// 产业视图
		/// </summary>
		public static MainUiCustomButtonItem Building => Instance[(sbyte)25];

		/// <summary>
		/// 村民名册
		/// </summary>
		public static MainUiCustomButtonItem Villager => Instance[(sbyte)26];

		/// <summary>
		/// 传承名谱
		/// </summary>
		public static MainUiCustomButtonItem Lineage => Instance[(sbyte)18];

		/// <summary>
		/// 派遣名册
		/// </summary>
		public static MainUiCustomButtonItem VillagerAssign => Instance[(sbyte)27];

		/// <summary>
		/// 势力情报
		/// </summary>
		public static MainUiCustomButtonItem SettlementInformation => Instance[(sbyte)28];

		/// <summary>
		/// 查看绘卷
		/// </summary>
		public static MainUiCustomButtonItem TaiwuScroll => Instance[(sbyte)29];

		/// <summary>
		/// 太吾传承
		/// </summary>
		public static MainUiCustomButtonItem TaiwuScrollLegacy => Instance[(sbyte)30];

		/// <summary>
		/// 铭刻
		/// </summary>
		public static MainUiCustomButtonItem Inscribe => Instance[(sbyte)31];

		/// <summary>
		/// 太吾百晓册
		/// </summary>
		public static MainUiCustomButtonItem Encyclopedia => Instance[(sbyte)32];

		/// <summary>
		/// 奇书宝典
		/// </summary>
		public static MainUiCustomButtonItem LegendaryBook => Instance[(sbyte)33];

		/// <summary>
		/// 太吾日志
		/// </summary>
		public static MainUiCustomButtonItem TaiwuLog => Instance[(sbyte)34];

		/// <summary>
		/// 关注
		/// </summary>
		public static MainUiCustomButtonItem Follow => Instance[(sbyte)35];

		/// <summary>
		/// 历程
		/// </summary>
		public static MainUiCustomButtonItem TaiwuLifeSummary => Instance[(sbyte)36];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static MainUiCustomButton Instance = new MainUiCustomButton();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TutorialFunctionType", "MainMenuButtonId", "TemplateId", "IconNormal", "IconHighLight", "IconPressed", "IconDisable" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new MainUiCustomButtonItem(0, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_0"), "ui9_btn_bottom_custom_button_party_0", "ui9_btn_bottom_custom_button_party_1", "ui9_btn_bottom_custom_button_party_2", "ui9_btn_bottom_custom_button_party_3", visible: true, 1, 2, 0));
		_dataArray.Add(new MainUiCustomButtonItem(1, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_1"), "ui9_btn_bottom_custom_button_equipment_0", "ui9_btn_bottom_custom_button_equipment_1", "ui9_btn_bottom_custom_button_equipment_2", "ui9_btn_bottom_custom_button_equipment_3", visible: true, 1, 8, 0));
		_dataArray.Add(new MainUiCustomButtonItem(2, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_2"), "ui9_btn_bottom_custom_button_inventory_0", "ui9_btn_bottom_custom_button_inventory_1", "ui9_btn_bottom_custom_button_inventory_2", "ui9_btn_bottom_custom_button_inventory_3", visible: true, 1, 8, 0));
		_dataArray.Add(new MainUiCustomButtonItem(3, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_3"), "ui9_btn_bottom_custom_button_prisoner_0", "ui9_btn_bottom_custom_button_prisoner_1", "ui9_btn_bottom_custom_button_prisoner_2", "ui9_btn_bottom_custom_button_prisoner_3", visible: true, 1, 8, 0));
		_dataArray.Add(new MainUiCustomButtonItem(4, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_4"), "ui9_btn_bottom_custom_button_attainment_0", "ui9_btn_bottom_custom_button_attainment_1", "ui9_btn_bottom_custom_button_attainment_2", "ui9_btn_bottom_custom_button_attainment_3", visible: true, 1, 2, 0));
		_dataArray.Add(new MainUiCustomButtonItem(5, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_5"), "ui9_btn_bottom_custom_button_skillbreak_0", "ui9_btn_bottom_custom_button_skillbreak_1", "ui9_btn_bottom_custom_button_skillbreak_2", "ui9_btn_bottom_custom_button_skillbreak_3", visible: true, 1, 7, 0));
		_dataArray.Add(new MainUiCustomButtonItem(6, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_6"), "ui9_btn_bottom_custom_button_neili_0", "ui9_btn_bottom_custom_button_neili_1", "ui9_btn_bottom_custom_button_neili_2", "ui9_btn_bottom_custom_button_neili_3", visible: true, 1, 5, 0));
		_dataArray.Add(new MainUiCustomButtonItem(7, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_7"), "ui9_btn_bottom_custom_button_equipcombatskill_0", "ui9_btn_bottom_custom_button_equipcombatskill_1", "ui9_btn_bottom_custom_button_equipcombatskill_2", "ui9_btn_bottom_custom_button_equipcombatskill_3", visible: true, 1, 4, 0));
		_dataArray.Add(new MainUiCustomButtonItem(8, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_8"), "ui9_btn_bottom_custom_button_information_0", "ui9_btn_bottom_custom_button_information_1", "ui9_btn_bottom_custom_button_information_2", "ui9_btn_bottom_custom_button_information_3", visible: true, 1, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(9, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_9"), "ui9_btn_bottom_custom_button_secretinformation_0", "ui9_btn_bottom_custom_button_secretinformation_1", "ui9_btn_bottom_custom_button_secretinformation_2", "ui9_btn_bottom_custom_button_secretinformation_3", visible: true, 1, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(10, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_10"), "ui9_btn_bottom_custom_button_liferecord_0", "ui9_btn_bottom_custom_button_liferecord_1", "ui9_btn_bottom_custom_button_liferecord_2", "ui9_btn_bottom_custom_button_liferecord_3", visible: true, 1, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(11, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_11"), "ui9_btn_bottom_custom_button_heal_0", "ui9_btn_bottom_custom_button_heal_1", "ui9_btn_bottom_custom_button_heal_2", "ui9_btn_bottom_custom_button_heal_3", visible: true, 1, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(12, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_12"), "ui9_btn_bottom_custom_button_cricket_0", "ui9_btn_bottom_custom_button_cricket_1", "ui9_btn_bottom_custom_button_cricket_2", "ui9_btn_bottom_custom_button_cricket_3", visible: false, 2, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(13, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_13"), "ui9_btn_bottom_custom_button_stoneroom_0", "ui9_btn_bottom_custom_button_stoneroom_1", "ui9_btn_bottom_custom_button_stoneroom_2", "ui9_btn_bottom_custom_button_stoneroom_3", visible: true, 2, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(14, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_14"), "ui9_btn_bottom_custom_button_jiao_0", "ui9_btn_bottom_custom_button_jiao_1", "ui9_btn_bottom_custom_button_jiao_2", "ui9_btn_bottom_custom_button_jiao_3", visible: true, 2, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(15, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_15"), "ui9_btn_bottom_custom_button_teacaravan_0", "ui9_btn_bottom_custom_button_teacaravan_1", "ui9_btn_bottom_custom_button_teacaravan_2", "ui9_btn_bottom_custom_button_teacaravan_3", visible: true, 2, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(16, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_16"), "ui9_btn_bottom_custom_button_samsaraplatform_0", "ui9_btn_bottom_custom_button_samsaraplatform_1", "ui9_btn_bottom_custom_button_samsaraplatform_2", "ui9_btn_bottom_custom_button_samsaraplatform_3", visible: true, 2, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(17, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_17"), "ui9_btn_bottom_custom_button_chickencoop_0", "ui9_btn_bottom_custom_button_chickencoop_1", "ui9_btn_bottom_custom_button_chickencoop_2", "ui9_btn_bottom_custom_button_chickencoop_3", visible: true, 2, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(18, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_18"), "ui9_btn_bottom_custom_button_lineage_0", "ui9_btn_bottom_custom_button_lineage_1", "ui9_btn_bottom_custom_button_lineage_2", "ui9_btn_bottom_custom_button_lineage_3", visible: true, 4, -1, 2));
		_dataArray.Add(new MainUiCustomButtonItem(19, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_19"), "ui9_btn_bottom_custom_button_chickenassign_0", "ui9_btn_bottom_custom_button_chickenassign_1", "ui9_btn_bottom_custom_button_chickenassign_2", "ui9_btn_bottom_custom_button_chickenassign_3", visible: true, 2, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(20, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_20"), "ui9_btn_bottom_custom_button_sectjieqing_0", "ui9_btn_bottom_custom_button_sectjieqing_1", "ui9_btn_bottom_custom_button_sectjieqing_2", "ui9_btn_bottom_custom_button_sectjieqing_3", visible: true, 3, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(21, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_21"), "ui9_btn_bottom_custom_button_sectwuxian_0", "ui9_btn_bottom_custom_button_sectwuxian_1", "ui9_btn_bottom_custom_button_sectwuxian_2", "ui9_btn_bottom_custom_button_sectwuxian_3", visible: true, 3, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(22, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_22"), "ui9_btn_bottom_custom_button_sectyuanshan_0", "ui9_btn_bottom_custom_button_sectyuanshan_1", "ui9_btn_bottom_custom_button_sectyuanshan_2", "ui9_btn_bottom_custom_button_sectyuanshan_3", visible: true, 3, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(23, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_23"), "ui9_btn_bottom_custom_button_sectxuannv_0", "ui9_btn_bottom_custom_button_sectxuannv_1", "ui9_btn_bottom_custom_button_sectxuannv_2", "ui9_btn_bottom_custom_button_sectxuannv_3", visible: true, 3, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(24, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_24"), "ui9_btn_bottom_custom_button_sectfulong_0", "ui9_btn_bottom_custom_button_sectfulong_1", "ui9_btn_bottom_custom_button_sectfulong_2", "ui9_btn_bottom_custom_button_sectfulong_3", visible: true, 3, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(25, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_25"), "ui9_btn_bottom_custom_button_building_0", "ui9_btn_bottom_custom_button_building_1", "ui9_btn_bottom_custom_button_building_2", "ui9_btn_bottom_custom_button_building_3", visible: true, 4, -1, 0));
		_dataArray.Add(new MainUiCustomButtonItem(26, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_26"), "ui9_btn_bottom_custom_button_villager_0", "ui9_btn_bottom_custom_button_villager_1", "ui9_btn_bottom_custom_button_villager_2", "ui9_btn_bottom_custom_button_villager_3", visible: true, 4, -1, 1));
		_dataArray.Add(new MainUiCustomButtonItem(27, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_27"), "ui9_btn_bottom_custom_button_villagerassign_0", "ui9_btn_bottom_custom_button_villagerassign_1", "ui9_btn_bottom_custom_button_villagerassign_2", "ui9_btn_bottom_custom_button_villagerassign_3", visible: true, 4, -1, 3));
		_dataArray.Add(new MainUiCustomButtonItem(28, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_28"), "ui9_btn_bottom_custom_button_settlementinformation_0", "ui9_btn_bottom_custom_button_settlementinformation_1", "ui9_btn_bottom_custom_button_settlementinformation_2", "ui9_btn_bottom_custom_button_settlementinformation_3", visible: true, 4, -1, 5));
		_dataArray.Add(new MainUiCustomButtonItem(29, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_29"), "ui9_btn_bottom_custom_button_taiwuscroll_0", "ui9_btn_bottom_custom_button_taiwuscroll_1", "ui9_btn_bottom_custom_button_taiwuscroll_2", "ui9_btn_bottom_custom_button_taiwuscroll_3", visible: true, 4, -1, 6));
		_dataArray.Add(new MainUiCustomButtonItem(30, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_30"), "ui9_btn_bottom_custom_button_taiwuscrolllegacy_0", "ui9_btn_bottom_custom_button_taiwuscrolllegacy_1", "ui9_btn_bottom_custom_button_taiwuscrolllegacy_2", "ui9_btn_bottom_custom_button_taiwuscrolllegacy_3", visible: true, 4, -1, 7));
		_dataArray.Add(new MainUiCustomButtonItem(31, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_31"), "ui9_btn_bottom_custom_button_inscribe_0", "ui9_btn_bottom_custom_button_inscribe_1", "ui9_btn_bottom_custom_button_inscribe_2", "ui9_btn_bottom_custom_button_inscribe_3", visible: true, 4, -1, 8));
		_dataArray.Add(new MainUiCustomButtonItem(32, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_32"), "ui9_btn_bottom_custom_button_encyclopedia_0", "ui9_btn_bottom_custom_button_encyclopedia_1", "ui9_btn_bottom_custom_button_encyclopedia_2", "ui9_btn_bottom_custom_button_encyclopedia_3", visible: true, 4, -1, 9));
		_dataArray.Add(new MainUiCustomButtonItem(33, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_33"), "ui9_btn_bottom_custom_button_legendarybook_0", "ui9_btn_bottom_custom_button_legendarybook_1", "ui9_btn_bottom_custom_button_legendarybook_2", "ui9_btn_bottom_custom_button_legendarybook_3", visible: true, 4, -1, 10));
		_dataArray.Add(new MainUiCustomButtonItem(34, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_34"), "ui9_btn_bottom_custom_button_taiwulog_0", "ui9_btn_bottom_custom_button_taiwulog_1", "ui9_btn_bottom_custom_button_taiwulog_2", "ui9_btn_bottom_custom_button_taiwulog_3", visible: true, 4, -1, 11));
		_dataArray.Add(new MainUiCustomButtonItem(35, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_35"), "ui9_btn_bottom_custom_button_follow_0", "ui9_btn_bottom_custom_button_follow_1", "ui9_btn_bottom_custom_button_follow_2", "ui9_btn_bottom_custom_button_follow_3", visible: true, 4, -1, 12));
		_dataArray.Add(new MainUiCustomButtonItem(36, LocalStringManager.GetConfig("MainUiCustomButton_language", "Name_36"), "ui9_btn_bottom_custom_button_taiwulifesummary_0", "ui9_btn_bottom_custom_button_taiwulifesummary_1", "ui9_btn_bottom_custom_button_taiwulifesummary_2", "ui9_btn_bottom_custom_button_taiwulifesummary_3", visible: true, 4, -1, 13));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MainUiCustomButtonItem>(37);
		CreateItems0();
	}
}
