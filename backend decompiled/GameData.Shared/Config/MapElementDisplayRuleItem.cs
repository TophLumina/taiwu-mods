using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapElementDisplayRuleItem : ConfigData<MapElementDisplayRuleItemItem, short>
{
	public static class DefKey
	{
		public const short CharacterCountNormal = 0;

		public const short CharacterCountVillager = 1;

		public const short CharacterCountBadEnemy = 2;

		public const short CharacterCountGoodEnemy = 3;

		public const short CharacterCountFriend = 4;

		public const short CharacterCountEnemy = 5;

		public const short CharacterCountInfected = 6;

		public const short CharacterCountXiangshu = 43;

		public const short CharacterCountBookConsumed = 44;

		public const short CharacterCountBook = 7;

		public const short CharacterCountFixed = 8;

		public const short CharacterCountBeast = 9;

		public const short CharacterCountOldRelation = 10;

		public const short CharacterCountJieqing = 11;

		public const short CharacterCountInfectedDemon = 42;

		public const short CharacterAvatarFixed = 12;

		public const short CharacterAvatarBeast = 13;

		public const short CharacterAvatarMerchantFoods = 14;

		public const short CharacterAvatarMerchantBooks = 15;

		public const short CharacterAvatarMerchantMaterials = 16;

		public const short CharacterAvatarMerchantEquipments = 17;

		public const short CharacterAvatarMerchantMedicines = 18;

		public const short CharacterAvatarMerchantConstructions = 19;

		public const short CharacterAvatarMerchantAccessories = 20;

		public const short CharacterAvatarRobbedCaravan = 21;

		public const short CharacterAvatarZizhu = 22;

		public const short CharacterAvatarXiangshu = 23;

		public const short CharacterAvatarJiao = 24;

		public const short CharacterAvatarLoong = 25;

		public const short MapElementGrave = 26;

		public const short MapElementTreasureFind = 27;

		public const short MapElementMark = 28;

		public const short MapElementMerchantFoods = 29;

		public const short MapElementMerchantBooks = 30;

		public const short MapElementMerchantMaterials = 31;

		public const short MapElementMerchantEquipments = 32;

		public const short MapElementMerchantMedicines = 33;

		public const short MapElementMerchantConstructions = 34;

		public const short MapElementMerchantAccessories = 35;

		public const short MapInteractCricket = 36;

		public const short MapInteractAdventure = 37;

		public const short MapInteractMainStory = 38;

		public const short MapInteractTask = 39;

		public const short MapInteractPickup = 40;

		public const short MapInteractInvisiblePickup = 41;
	}

	public static class DefValue
	{
		public static MapElementDisplayRuleItemItem CharacterCountNormal => Instance[(short)0];

		public static MapElementDisplayRuleItemItem CharacterCountVillager => Instance[(short)1];

		public static MapElementDisplayRuleItemItem CharacterCountBadEnemy => Instance[(short)2];

		public static MapElementDisplayRuleItemItem CharacterCountGoodEnemy => Instance[(short)3];

		public static MapElementDisplayRuleItemItem CharacterCountFriend => Instance[(short)4];

		public static MapElementDisplayRuleItemItem CharacterCountEnemy => Instance[(short)5];

		public static MapElementDisplayRuleItemItem CharacterCountInfected => Instance[(short)6];

		public static MapElementDisplayRuleItemItem CharacterCountXiangshu => Instance[(short)43];

		public static MapElementDisplayRuleItemItem CharacterCountBookConsumed => Instance[(short)44];

		public static MapElementDisplayRuleItemItem CharacterCountBook => Instance[(short)7];

		public static MapElementDisplayRuleItemItem CharacterCountFixed => Instance[(short)8];

		public static MapElementDisplayRuleItemItem CharacterCountBeast => Instance[(short)9];

		public static MapElementDisplayRuleItemItem CharacterCountOldRelation => Instance[(short)10];

		public static MapElementDisplayRuleItemItem CharacterCountJieqing => Instance[(short)11];

		public static MapElementDisplayRuleItemItem CharacterCountInfectedDemon => Instance[(short)42];

		public static MapElementDisplayRuleItemItem CharacterAvatarFixed => Instance[(short)12];

		public static MapElementDisplayRuleItemItem CharacterAvatarBeast => Instance[(short)13];

		public static MapElementDisplayRuleItemItem CharacterAvatarMerchantFoods => Instance[(short)14];

		public static MapElementDisplayRuleItemItem CharacterAvatarMerchantBooks => Instance[(short)15];

		public static MapElementDisplayRuleItemItem CharacterAvatarMerchantMaterials => Instance[(short)16];

		public static MapElementDisplayRuleItemItem CharacterAvatarMerchantEquipments => Instance[(short)17];

		public static MapElementDisplayRuleItemItem CharacterAvatarMerchantMedicines => Instance[(short)18];

		public static MapElementDisplayRuleItemItem CharacterAvatarMerchantConstructions => Instance[(short)19];

		public static MapElementDisplayRuleItemItem CharacterAvatarMerchantAccessories => Instance[(short)20];

		public static MapElementDisplayRuleItemItem CharacterAvatarRobbedCaravan => Instance[(short)21];

		public static MapElementDisplayRuleItemItem CharacterAvatarZizhu => Instance[(short)22];

		public static MapElementDisplayRuleItemItem CharacterAvatarXiangshu => Instance[(short)23];

		public static MapElementDisplayRuleItemItem CharacterAvatarJiao => Instance[(short)24];

		public static MapElementDisplayRuleItemItem CharacterAvatarLoong => Instance[(short)25];

		public static MapElementDisplayRuleItemItem MapElementGrave => Instance[(short)26];

		public static MapElementDisplayRuleItemItem MapElementTreasureFind => Instance[(short)27];

		public static MapElementDisplayRuleItemItem MapElementMark => Instance[(short)28];

		public static MapElementDisplayRuleItemItem MapElementMerchantFoods => Instance[(short)29];

		public static MapElementDisplayRuleItemItem MapElementMerchantBooks => Instance[(short)30];

		public static MapElementDisplayRuleItemItem MapElementMerchantMaterials => Instance[(short)31];

		public static MapElementDisplayRuleItemItem MapElementMerchantEquipments => Instance[(short)32];

		public static MapElementDisplayRuleItemItem MapElementMerchantMedicines => Instance[(short)33];

		public static MapElementDisplayRuleItemItem MapElementMerchantConstructions => Instance[(short)34];

		public static MapElementDisplayRuleItemItem MapElementMerchantAccessories => Instance[(short)35];

		public static MapElementDisplayRuleItemItem MapInteractCricket => Instance[(short)36];

		public static MapElementDisplayRuleItemItem MapInteractAdventure => Instance[(short)37];

		public static MapElementDisplayRuleItemItem MapInteractMainStory => Instance[(short)38];

		public static MapElementDisplayRuleItemItem MapInteractTask => Instance[(short)39];

		public static MapElementDisplayRuleItemItem MapInteractPickup => Instance[(short)40];

		public static MapElementDisplayRuleItemItem MapInteractInvisiblePickup => Instance[(short)41];
	}

	public static MapElementDisplayRuleItem Instance = new MapElementDisplayRuleItem();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Group", "Name", "MerchantType", "TemplateId", "Icon", "BlockInfoIcon" };

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
		_dataArray.Add(new MapElementDisplayRuleItemItem(0, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_0"), "pinkyellow", 0, -1, "ui9_icon_outline_normal_count", "ui9_icon_mapelement_normal_count", EMapElementDisplayRuleItemPoisionType.BottomMiddle, EMapElementDisplayRuleItemCharacterCountGroup.Common, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Neutral));
		_dataArray.Add(new MapElementDisplayRuleItemItem(1, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_1"), "pinkyellow", 3, -1, "ui9_icon_outline_villager", "ui9_icon_mapelement_villager_count", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Friend, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Friend));
		_dataArray.Add(new MapElementDisplayRuleItemItem(2, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_2"), "orange", 6, -1, "ui9_icon_outline_badenemy", "ui9_icon_mapelement_badenemy_count", EMapElementDisplayRuleItemPoisionType.Left, EMapElementDisplayRuleItemCharacterCountGroup.Enemy, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Enemy));
		_dataArray.Add(new MapElementDisplayRuleItemItem(3, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_3"), "brightblue", 7, -1, "ui9_icon_outline_goodenemy", "ui9_icon_mapelement_goodenemy_count", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Neutral, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Neutral));
		_dataArray.Add(new MapElementDisplayRuleItemItem(4, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_4"), "brightblue", 2, -1, "ui9_icon_outline_friend", "ui9_icon_mapelement_friend_count", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Friend, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Friend));
		_dataArray.Add(new MapElementDisplayRuleItemItem(5, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_5"), "darkred", 4, -1, "ui9_icon_outline_enemy", "ui9_icon_mapelement_enemy_count", EMapElementDisplayRuleItemPoisionType.Left, EMapElementDisplayRuleItemCharacterCountGroup.Enemy, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Enemy));
		_dataArray.Add(new MapElementDisplayRuleItemItem(6, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_6"), "orange", 2, -1, "ui9_icon_outline_infect", "ui9_icon_mapelement_infect_count", EMapElementDisplayRuleItemPoisionType.Left, EMapElementDisplayRuleItemCharacterCountGroup.Enemy, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Enemy));
		_dataArray.Add(new MapElementDisplayRuleItemItem(7, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_7"), "orange", 1, -1, "ui9_icon_outline_book", "ui9_icon_mapelement_book_count", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Neutral, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Neutral));
		_dataArray.Add(new MapElementDisplayRuleItemItem(8, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_8"), "pinkyellow", 4, -1, "ui9_icon_fixed_count", "ui9_icon_mapelement_fixed_count", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Friend, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Friend));
		_dataArray.Add(new MapElementDisplayRuleItemItem(9, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_9"), "orange", 6, -1, "ui9_icon_outline_beast", "ui9_icon_mapelement_beast_count", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Neutral, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Neutral));
		_dataArray.Add(new MapElementDisplayRuleItemItem(10, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_10"), "pinkyellow", 5, -1, "ui9_icon_outline_oldrelation", "ui9_icon_mapelement_oldrelation_count", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Friend, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Friend));
		_dataArray.Add(new MapElementDisplayRuleItemItem(11, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_11"), "pinkyellow", 3, -1, "ui9_back_sectpopup_12_icon_2_0", "sp_icon_jieqingmark_0", EMapElementDisplayRuleItemPoisionType.Left, EMapElementDisplayRuleItemCharacterCountGroup.Special, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Special));
		_dataArray.Add(new MapElementDisplayRuleItemItem(12, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_12"), "pinkyellow", 0, -1, "ui9_icon_outline_fixed", "ui9_icon_mapelement_fixed_count", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(13, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_13"), "pinkyellow", 0, -1, "ui9_icon_outline_beast", "ui9_icon_mapelement_beast_count", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(14, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_14"), "pinkyellow", 0, 0, "ui9_sp_icon_trader_small_0", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(15, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_15"), "pinkyellow", 0, 1, "ui9_sp_icon_trader_small_1", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(16, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_16"), "pinkyellow", 0, 2, "ui9_sp_icon_trader_small_2", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(17, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_17"), "pinkyellow", 0, 3, "ui9_sp_icon_trader_small_3", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(18, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_18"), "pinkyellow", 0, 4, "ui9_sp_icon_trader_small_4", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(19, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_19"), "pinkyellow", 0, 5, "ui9_sp_icon_trader_small_5", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(20, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_20"), "pinkyellow", 0, 6, "ui9_sp_icon_trader_small_6", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(21, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_21"), "pinkyellow", 0, -1, "ui9_icon_outline_robbedcaravan", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(22, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_22"), "pinkyellow", 0, -1, "ui9_icon_outline_zizhu", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(23, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_23"), "pinkyellow", 0, -1, "ui9_icon_outlilne_xiangshu", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(24, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_24"), "pinkyellow", 0, -1, "ui9_icon_outline_legend_4", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(25, 1, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_25"), "pinkyellow", 0, -1, "ui9_icon_outline_legend_9", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(26, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_26"), "pinkyellow", 7, -1, "ui9_icon_outline_grave", "ui9_icon_mapelement_grave_count", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Neutral, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Neutral));
		_dataArray.Add(new MapElementDisplayRuleItemItem(27, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_27"), "pinkyellow", 8, -1, "ui9_icon_outline_treasurefind", "ui9_icon_mapelement_treasure_find_count_0", EMapElementDisplayRuleItemPoisionType.Left, EMapElementDisplayRuleItemCharacterCountGroup.Special, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Special));
		_dataArray.Add(new MapElementDisplayRuleItemItem(28, 2, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_28"), "pinkyellow", 0, -1, "ui9_icon_outline_newmark", "ui9_icon_mapelement_newmark", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(29, 2, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_29"), "pinkyellow", 0, 0, "sp_icon_shanghui_0", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(30, 2, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_30"), "pinkyellow", 0, 1, "sp_icon_shanghui_1", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(31, 2, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_31"), "pinkyellow", 0, 2, "sp_icon_shanghui_2", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(32, 2, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_32"), "pinkyellow", 0, 3, "sp_icon_shanghui_3", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(33, 2, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_33"), "pinkyellow", 0, 4, "sp_icon_shanghui_4", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(34, 2, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_34"), "pinkyellow", 0, 5, "sp_icon_shanghui_5", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(35, 2, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_35"), "pinkyellow", 0, 6, "sp_icon_shanghui_6", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(36, 3, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_36"), "pinkyellow", 0, -1, "ui9_icon_outline_cricket", "ui9_icon_mapelement_cricket", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(37, 3, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_37"), "pinkyellow", 0, -1, "ui9_icon_outline_goodenemyadventure", "ui9_icon_mapelement_goodenemyadventure", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(38, 3, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_38"), "pinkyellow", 0, -1, "ui9_icon_outline_mainstory", "ui9_icon_mapelement_mainstory", EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(39, 3, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_39"), "pinkyellow", 0, -1, "ui9_icon_outline_task", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(40, 3, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_40"), "pinkyellow", 0, -1, "ui9_icon_outline_pickup", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(41, 3, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_41"), "pinkyellow", 0, -1, "ui9_icon_mapelement_objectwithoutfieldview", null, EMapElementDisplayRuleItemPoisionType.Right, EMapElementDisplayRuleItemCharacterCountGroup.Invalid, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid));
		_dataArray.Add(new MapElementDisplayRuleItemItem(42, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_42"), "ac57b3", 1, -1, "ui9_icon_outline_infecteddemon", "ui9_icon_mapelement_infecteddemon", EMapElementDisplayRuleItemPoisionType.Left, EMapElementDisplayRuleItemCharacterCountGroup.Enemy, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Enemy));
		_dataArray.Add(new MapElementDisplayRuleItemItem(43, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_43"), "orange", 2, -1, "ui9_icon_clawsandfangs", "ui9_icon_clawsandfangs_big", EMapElementDisplayRuleItemPoisionType.Left, EMapElementDisplayRuleItemCharacterCountGroup.Enemy, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Enemy));
		_dataArray.Add(new MapElementDisplayRuleItemItem(44, 0, LocalStringManager.GetConfig("MapElementDisplayRuleItem_language", "Name_44"), "orange", 2, -1, "ui9_icon_largemap_legend_base_11", "ui9_icon_largemap_legend_base_11", EMapElementDisplayRuleItemPoisionType.Left, EMapElementDisplayRuleItemCharacterCountGroup.Enemy, EMapElementDisplayRuleItemCharacterCountGroupDisplay.Enemy));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MapElementDisplayRuleItemItem>(45);
		CreateItems0();
	}
}
