using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MerchantType : ConfigData<MerchantTypeItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 服牛帮
		/// </summary>
		public const sbyte Foods = 0;

		/// <summary>
		/// 文山书海阁
		/// </summary>
		public const sbyte Books = 1;

		/// <summary>
		/// 五湖商会
		/// </summary>
		public const sbyte Materials = 2;

		/// <summary>
		/// 大武魁商号
		/// </summary>
		public const sbyte Equipments = 3;

		/// <summary>
		/// 回春堂
		/// </summary>
		public const sbyte Medicines = 4;

		/// <summary>
		/// 公输坊
		/// </summary>
		public const sbyte Constructions = 5;

		/// <summary>
		/// 奇货斋
		/// </summary>
		public const sbyte Accessories = 6;

		/// <summary>
		/// 农户互动
		/// </summary>
		public const sbyte FruitShop = 7;

		/// <summary>
		/// 峨眉互动
		/// </summary>
		public const sbyte EMeiShop = 8;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 服牛帮
		/// </summary>
		public static MerchantTypeItem Foods => Instance[(sbyte)0];

		/// <summary>
		/// 文山书海阁
		/// </summary>
		public static MerchantTypeItem Books => Instance[(sbyte)1];

		/// <summary>
		/// 五湖商会
		/// </summary>
		public static MerchantTypeItem Materials => Instance[(sbyte)2];

		/// <summary>
		/// 大武魁商号
		/// </summary>
		public static MerchantTypeItem Equipments => Instance[(sbyte)3];

		/// <summary>
		/// 回春堂
		/// </summary>
		public static MerchantTypeItem Medicines => Instance[(sbyte)4];

		/// <summary>
		/// 公输坊
		/// </summary>
		public static MerchantTypeItem Constructions => Instance[(sbyte)5];

		/// <summary>
		/// 奇货斋
		/// </summary>
		public static MerchantTypeItem Accessories => Instance[(sbyte)6];

		/// <summary>
		/// 农户互动
		/// </summary>
		public static MerchantTypeItem FruitShop => Instance[(sbyte)7];

		/// <summary>
		/// 峨眉互动
		/// </summary>
		public static MerchantTypeItem EMeiShop => Instance[(sbyte)8];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static MerchantType Instance = new MerchantType();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "HeadArea", "BranchArea", "Prologue", "IntroduceDialog", "FavorDialog1", "FavorDialog2", "FavorDialog3", "SpringSeasonDialog", "SummerSeasonDialog",
		"AutumnSeasonDialog", "WinterSeasonDialog", "SpringMarketsAdventureSeasonDialog", "EventContent", "EventDialogContent", "TaiwuVillagerMerchantChangingTypeContent", "RefreshDesc", "TemplateId", "HeadLevel", "BranchLevel",
		"CaravanAvatar", "CaravanSpineName", "BuildingSpineName", "Icon"
	};

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
		_dataArray.Add(new MerchantTypeItem(0, LocalStringManager.GetConfig("MerchantType_language", "Name_0"), 6, 6, 5, 5, EMerchantTypeCityAttributeType.Safety, "NpcFace_funiubangyewai", "Shop/NPC/NpcFace_funiuyewai", "Shop/NPC/NpcFace_funiu", "sp_icon_shanghui_0", LocalStringManager.GetConfig("MerchantType_language", "Prologue_0"), LocalStringManager.GetConfig("MerchantType_language", "IntroduceDialog_0"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog1_0"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog2_0"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog3_0"), LocalStringManager.GetConfig("MerchantType_language", "SpringSeasonDialog_0"), LocalStringManager.GetConfig("MerchantType_language", "SummerSeasonDialog_0"), LocalStringManager.GetConfig("MerchantType_language", "AutumnSeasonDialog_0"), LocalStringManager.GetConfig("MerchantType_language", "WinterSeasonDialog_0"), LocalStringManager.GetConfig("MerchantType_language", "SpringMarketsAdventureSeasonDialog_0"), LocalStringManager.GetConfig("MerchantType_language", "EventContent_0"), LocalStringManager.GetConfig("MerchantType_language", "EventDialogContent_0"), LocalStringManager.GetConfig("MerchantType_language", "TaiwuVillagerMerchantChangingTypeContent_0"), LocalStringManager.GetConfig("MerchantType_language", "RefreshDesc_0")));
		_dataArray.Add(new MerchantTypeItem(1, LocalStringManager.GetConfig("MerchantType_language", "Name_1"), 4, 6, 2, 5, EMerchantTypeCityAttributeType.Culture, "NpcFace_wenshanshuhaigeyewai", "Shop/NPC/NpcFace_wenshanyewai", "Shop/NPC/NpcFace_wenshan", "sp_icon_shanghui_1", LocalStringManager.GetConfig("MerchantType_language", "Prologue_1"), LocalStringManager.GetConfig("MerchantType_language", "IntroduceDialog_1"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog1_1"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog2_1"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog3_1"), LocalStringManager.GetConfig("MerchantType_language", "SpringSeasonDialog_1"), LocalStringManager.GetConfig("MerchantType_language", "SummerSeasonDialog_1"), LocalStringManager.GetConfig("MerchantType_language", "AutumnSeasonDialog_1"), LocalStringManager.GetConfig("MerchantType_language", "WinterSeasonDialog_1"), LocalStringManager.GetConfig("MerchantType_language", "SpringMarketsAdventureSeasonDialog_1"), LocalStringManager.GetConfig("MerchantType_language", "EventContent_1"), LocalStringManager.GetConfig("MerchantType_language", "EventDialogContent_1"), LocalStringManager.GetConfig("MerchantType_language", "TaiwuVillagerMerchantChangingTypeContent_1"), LocalStringManager.GetConfig("MerchantType_language", "RefreshDesc_1")));
		_dataArray.Add(new MerchantTypeItem(2, LocalStringManager.GetConfig("MerchantType_language", "Name_2"), 15, 6, 13, 5, EMerchantTypeCityAttributeType.Safety, "NpcFace_wuhushanghuiyewai", "Shop/NPC/NpcFace_wuhuyewai", "Shop/NPC/NpcFace_wuhu", "sp_icon_shanghui_2", LocalStringManager.GetConfig("MerchantType_language", "Prologue_2"), LocalStringManager.GetConfig("MerchantType_language", "IntroduceDialog_2"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog1_2"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog2_2"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog3_2"), LocalStringManager.GetConfig("MerchantType_language", "SpringSeasonDialog_2"), LocalStringManager.GetConfig("MerchantType_language", "SummerSeasonDialog_2"), LocalStringManager.GetConfig("MerchantType_language", "AutumnSeasonDialog_2"), LocalStringManager.GetConfig("MerchantType_language", "WinterSeasonDialog_2"), LocalStringManager.GetConfig("MerchantType_language", "SpringMarketsAdventureSeasonDialog_2"), LocalStringManager.GetConfig("MerchantType_language", "EventContent_2"), LocalStringManager.GetConfig("MerchantType_language", "EventDialogContent_2"), LocalStringManager.GetConfig("MerchantType_language", "TaiwuVillagerMerchantChangingTypeContent_2"), LocalStringManager.GetConfig("MerchantType_language", "RefreshDesc_2")));
		_dataArray.Add(new MerchantTypeItem(3, LocalStringManager.GetConfig("MerchantType_language", "Name_3"), 9, 6, 1, 5, EMerchantTypeCityAttributeType.Safety, "NpcFace_dawukuishanghaoyewai", "Shop/NPC/NpcFace_dawukuiyewai", "Shop/NPC/NpcFace_dawukui", "sp_icon_shanghui_3", LocalStringManager.GetConfig("MerchantType_language", "Prologue_3"), LocalStringManager.GetConfig("MerchantType_language", "IntroduceDialog_3"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog1_3"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog2_3"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog3_3"), LocalStringManager.GetConfig("MerchantType_language", "SpringSeasonDialog_3"), LocalStringManager.GetConfig("MerchantType_language", "SummerSeasonDialog_3"), LocalStringManager.GetConfig("MerchantType_language", "AutumnSeasonDialog_3"), LocalStringManager.GetConfig("MerchantType_language", "WinterSeasonDialog_3"), LocalStringManager.GetConfig("MerchantType_language", "SpringMarketsAdventureSeasonDialog_3"), LocalStringManager.GetConfig("MerchantType_language", "EventContent_3"), LocalStringManager.GetConfig("MerchantType_language", "EventDialogContent_3"), LocalStringManager.GetConfig("MerchantType_language", "TaiwuVillagerMerchantChangingTypeContent_3"), LocalStringManager.GetConfig("MerchantType_language", "RefreshDesc_3")));
		_dataArray.Add(new MerchantTypeItem(4, LocalStringManager.GetConfig("MerchantType_language", "Name_4"), 3, 6, 10, 5, EMerchantTypeCityAttributeType.Safety, "NpcFace_huichuntangyewai", "Shop/NPC/NpcFace_huichunyewai", "Shop/NPC/NpcFace_huichun", "sp_icon_shanghui_4", LocalStringManager.GetConfig("MerchantType_language", "Prologue_4"), LocalStringManager.GetConfig("MerchantType_language", "IntroduceDialog_4"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog1_4"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog2_4"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog3_4"), LocalStringManager.GetConfig("MerchantType_language", "SpringSeasonDialog_4"), LocalStringManager.GetConfig("MerchantType_language", "SummerSeasonDialog_4"), LocalStringManager.GetConfig("MerchantType_language", "AutumnSeasonDialog_4"), LocalStringManager.GetConfig("MerchantType_language", "WinterSeasonDialog_4"), LocalStringManager.GetConfig("MerchantType_language", "SpringMarketsAdventureSeasonDialog_4"), LocalStringManager.GetConfig("MerchantType_language", "EventContent_4"), LocalStringManager.GetConfig("MerchantType_language", "EventDialogContent_4"), LocalStringManager.GetConfig("MerchantType_language", "TaiwuVillagerMerchantChangingTypeContent_4"), LocalStringManager.GetConfig("MerchantType_language", "RefreshDesc_4")));
		_dataArray.Add(new MerchantTypeItem(5, LocalStringManager.GetConfig("MerchantType_language", "Name_5"), 7, 6, 12, 5, EMerchantTypeCityAttributeType.Culture, "NpcFace_gongshufangyewai", "Shop/NPC/NpcFace_gongshuyewai", "Shop/NPC/NpcFace_gongshu", "sp_icon_shanghui_5", LocalStringManager.GetConfig("MerchantType_language", "Prologue_5"), LocalStringManager.GetConfig("MerchantType_language", "IntroduceDialog_5"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog1_5"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog2_5"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog3_5"), LocalStringManager.GetConfig("MerchantType_language", "SpringSeasonDialog_5"), LocalStringManager.GetConfig("MerchantType_language", "SummerSeasonDialog_5"), LocalStringManager.GetConfig("MerchantType_language", "AutumnSeasonDialog_5"), LocalStringManager.GetConfig("MerchantType_language", "WinterSeasonDialog_5"), LocalStringManager.GetConfig("MerchantType_language", "SpringMarketsAdventureSeasonDialog_5"), LocalStringManager.GetConfig("MerchantType_language", "EventContent_5"), LocalStringManager.GetConfig("MerchantType_language", "EventDialogContent_5"), LocalStringManager.GetConfig("MerchantType_language", "TaiwuVillagerMerchantChangingTypeContent_5"), LocalStringManager.GetConfig("MerchantType_language", "RefreshDesc_5")));
		_dataArray.Add(new MerchantTypeItem(6, LocalStringManager.GetConfig("MerchantType_language", "Name_6"), 8, 6, 14, 5, EMerchantTypeCityAttributeType.Culture, "NpcFace_qihuozhaiyewai", "Shop/NPC/NpcFace_qihuoyewai", "Shop/NPC/NpcFace_qihuo", "sp_icon_shanghui_6", LocalStringManager.GetConfig("MerchantType_language", "Prologue_6"), LocalStringManager.GetConfig("MerchantType_language", "IntroduceDialog_6"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog1_6"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog2_6"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog3_6"), LocalStringManager.GetConfig("MerchantType_language", "SpringSeasonDialog_6"), LocalStringManager.GetConfig("MerchantType_language", "SummerSeasonDialog_6"), LocalStringManager.GetConfig("MerchantType_language", "AutumnSeasonDialog_6"), LocalStringManager.GetConfig("MerchantType_language", "WinterSeasonDialog_6"), LocalStringManager.GetConfig("MerchantType_language", "SpringMarketsAdventureSeasonDialog_6"), LocalStringManager.GetConfig("MerchantType_language", "EventContent_6"), LocalStringManager.GetConfig("MerchantType_language", "EventDialogContent_6"), LocalStringManager.GetConfig("MerchantType_language", "TaiwuVillagerMerchantChangingTypeContent_6"), LocalStringManager.GetConfig("MerchantType_language", "RefreshDesc_6")));
		_dataArray.Add(new MerchantTypeItem(7, LocalStringManager.GetConfig("MerchantType_language", "Name_7"), -1, -1, -1, -1, EMerchantTypeCityAttributeType.Invalid, null, null, null, null, LocalStringManager.GetConfig("MerchantType_language", "Prologue_7"), LocalStringManager.GetConfig("MerchantType_language", "IntroduceDialog_7"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog1_7"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog2_7"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog3_7"), LocalStringManager.GetConfig("MerchantType_language", "SpringSeasonDialog_7"), LocalStringManager.GetConfig("MerchantType_language", "SummerSeasonDialog_7"), LocalStringManager.GetConfig("MerchantType_language", "AutumnSeasonDialog_7"), LocalStringManager.GetConfig("MerchantType_language", "WinterSeasonDialog_7"), LocalStringManager.GetConfig("MerchantType_language", "SpringMarketsAdventureSeasonDialog_7"), LocalStringManager.GetConfig("MerchantType_language", "EventContent_7"), LocalStringManager.GetConfig("MerchantType_language", "EventDialogContent_7"), LocalStringManager.GetConfig("MerchantType_language", "TaiwuVillagerMerchantChangingTypeContent_7"), LocalStringManager.GetConfig("MerchantType_language", "RefreshDesc_7")));
		_dataArray.Add(new MerchantTypeItem(8, LocalStringManager.GetConfig("MerchantType_language", "Name_8"), -1, -1, -1, -1, EMerchantTypeCityAttributeType.Invalid, null, null, null, null, LocalStringManager.GetConfig("MerchantType_language", "Prologue_8"), LocalStringManager.GetConfig("MerchantType_language", "IntroduceDialog_8"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog1_8"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog2_8"), LocalStringManager.GetConfig("MerchantType_language", "FavorDialog3_8"), LocalStringManager.GetConfig("MerchantType_language", "SpringSeasonDialog_8"), LocalStringManager.GetConfig("MerchantType_language", "SummerSeasonDialog_8"), LocalStringManager.GetConfig("MerchantType_language", "AutumnSeasonDialog_8"), LocalStringManager.GetConfig("MerchantType_language", "WinterSeasonDialog_8"), LocalStringManager.GetConfig("MerchantType_language", "SpringMarketsAdventureSeasonDialog_8"), LocalStringManager.GetConfig("MerchantType_language", "EventContent_8"), LocalStringManager.GetConfig("MerchantType_language", "EventDialogContent_8"), LocalStringManager.GetConfig("MerchantType_language", "TaiwuVillagerMerchantChangingTypeContent_8"), LocalStringManager.GetConfig("MerchantType_language", "RefreshDesc_8")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MerchantTypeItem>(9);
		CreateItems0();
	}
}
