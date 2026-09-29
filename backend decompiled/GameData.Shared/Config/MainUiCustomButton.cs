using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MainUiCustomButton : ConfigData<MainUiCustomButtonItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Party = 0;

		public const sbyte Equipment = 1;

		public const sbyte Inventory = 2;

		public const sbyte Prisoner = 3;

		public const sbyte Attainment = 4;

		public const sbyte SkillBreak = 5;

		public const sbyte Neili = 6;

		public const sbyte EquipCombatSkill = 7;

		public const sbyte Information = 8;

		public const sbyte SecretInformation = 9;

		public const sbyte LifeRecord = 10;

		public const sbyte Heal = 11;

		public const sbyte Cricket = 12;

		public const sbyte StoneRoom = 13;

		public const sbyte Jiao = 14;

		public const sbyte TeaCaravan = 15;

		public const sbyte SamsaraPlatform = 16;

		public const sbyte ChickenCoop = 17;

		public const sbyte ChickenAssign = 19;

		public const sbyte SectJieqing = 20;

		public const sbyte SectWuxian = 21;

		public const sbyte SectYuanshan = 22;

		public const sbyte SectXuannv = 23;

		public const sbyte SectFulong = 24;

		public const sbyte Building = 25;

		public const sbyte Villager = 26;

		public const sbyte Lineage = 18;

		public const sbyte VillagerAssign = 27;

		public const sbyte SettlementInformation = 28;

		public const sbyte TaiwuScroll = 29;

		public const sbyte TaiwuScrollLegacy = 30;

		public const sbyte Inscribe = 31;

		public const sbyte Encyclopedia = 32;

		public const sbyte LegendaryBook = 33;

		public const sbyte TaiwuLog = 34;

		public const sbyte Follow = 35;

		public const sbyte TaiwuLifeSummary = 36;
	}

	public static class DefValue
	{
		public static MainUiCustomButtonItem Party => Instance[(sbyte)0];

		public static MainUiCustomButtonItem Equipment => Instance[(sbyte)1];

		public static MainUiCustomButtonItem Inventory => Instance[(sbyte)2];

		public static MainUiCustomButtonItem Prisoner => Instance[(sbyte)3];

		public static MainUiCustomButtonItem Attainment => Instance[(sbyte)4];

		public static MainUiCustomButtonItem SkillBreak => Instance[(sbyte)5];

		public static MainUiCustomButtonItem Neili => Instance[(sbyte)6];

		public static MainUiCustomButtonItem EquipCombatSkill => Instance[(sbyte)7];

		public static MainUiCustomButtonItem Information => Instance[(sbyte)8];

		public static MainUiCustomButtonItem SecretInformation => Instance[(sbyte)9];

		public static MainUiCustomButtonItem LifeRecord => Instance[(sbyte)10];

		public static MainUiCustomButtonItem Heal => Instance[(sbyte)11];

		public static MainUiCustomButtonItem Cricket => Instance[(sbyte)12];

		public static MainUiCustomButtonItem StoneRoom => Instance[(sbyte)13];

		public static MainUiCustomButtonItem Jiao => Instance[(sbyte)14];

		public static MainUiCustomButtonItem TeaCaravan => Instance[(sbyte)15];

		public static MainUiCustomButtonItem SamsaraPlatform => Instance[(sbyte)16];

		public static MainUiCustomButtonItem ChickenCoop => Instance[(sbyte)17];

		public static MainUiCustomButtonItem ChickenAssign => Instance[(sbyte)19];

		public static MainUiCustomButtonItem SectJieqing => Instance[(sbyte)20];

		public static MainUiCustomButtonItem SectWuxian => Instance[(sbyte)21];

		public static MainUiCustomButtonItem SectYuanshan => Instance[(sbyte)22];

		public static MainUiCustomButtonItem SectXuannv => Instance[(sbyte)23];

		public static MainUiCustomButtonItem SectFulong => Instance[(sbyte)24];

		public static MainUiCustomButtonItem Building => Instance[(sbyte)25];

		public static MainUiCustomButtonItem Villager => Instance[(sbyte)26];

		public static MainUiCustomButtonItem Lineage => Instance[(sbyte)18];

		public static MainUiCustomButtonItem VillagerAssign => Instance[(sbyte)27];

		public static MainUiCustomButtonItem SettlementInformation => Instance[(sbyte)28];

		public static MainUiCustomButtonItem TaiwuScroll => Instance[(sbyte)29];

		public static MainUiCustomButtonItem TaiwuScrollLegacy => Instance[(sbyte)30];

		public static MainUiCustomButtonItem Inscribe => Instance[(sbyte)31];

		public static MainUiCustomButtonItem Encyclopedia => Instance[(sbyte)32];

		public static MainUiCustomButtonItem LegendaryBook => Instance[(sbyte)33];

		public static MainUiCustomButtonItem TaiwuLog => Instance[(sbyte)34];

		public static MainUiCustomButtonItem Follow => Instance[(sbyte)35];

		public static MainUiCustomButtonItem TaiwuLifeSummary => Instance[(sbyte)36];
	}

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
