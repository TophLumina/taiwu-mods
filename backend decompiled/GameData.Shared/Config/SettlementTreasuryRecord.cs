using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SettlementTreasuryRecord : ConfigData<SettlementTreasuryRecordItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// SupplementResource
		/// </summary>
		public const short SupplementResource = 0;

		/// <summary>
		/// SupplementItem
		/// </summary>
		public const short SupplementItem = 1;

		/// <summary>
		/// StorageResource
		/// </summary>
		public const short StorageResource = 2;

		/// <summary>
		/// StorageItem
		/// </summary>
		public const short StorageItem = 3;

		/// <summary>
		/// TakeOutResource
		/// </summary>
		public const short TakeOutResource = 4;

		/// <summary>
		/// TakeOutItem
		/// </summary>
		public const short TakeOutItem = 5;

		/// <summary>
		/// TaiwuStorageResource
		/// </summary>
		public const short TaiwuStorageResource = 6;

		/// <summary>
		/// TaiwuStorageItem
		/// </summary>
		public const short TaiwuStorageItem = 7;

		/// <summary>
		/// TaiwuTakeOutResource
		/// </summary>
		public const short TaiwuTakeOutResource = 8;

		/// <summary>
		/// TaiwuTakeOutItem
		/// </summary>
		public const short TaiwuTakeOutItem = 9;

		/// <summary>
		/// DonateSectTreasury
		/// </summary>
		public const short DonateSectTreasury = 10;

		/// <summary>
		/// DonateTownTreasury
		/// </summary>
		public const short DonateTownTreasury = 11;

		/// <summary>
		/// IntrudeSectTreasury
		/// </summary>
		public const short IntrudeSectTreasury = 12;

		/// <summary>
		/// IntrudeTownTreasury
		/// </summary>
		public const short IntrudeTownTreasury = 13;

		/// <summary>
		/// PlunderSectTreasurySuccess
		/// </summary>
		public const short PlunderSectTreasurySuccess = 14;

		/// <summary>
		/// PlunderTownTreasurySuccess
		/// </summary>
		public const short PlunderTownTreasurySuccess = 15;

		/// <summary>
		/// PlunderSectTreasuryFail
		/// </summary>
		public const short PlunderSectTreasuryFail = 16;

		/// <summary>
		/// PlunderTownTreasuryFail
		/// </summary>
		public const short PlunderTownTreasuryFail = 17;

		/// <summary>
		/// ConfiscateResource
		/// </summary>
		public const short ConfiscateResource = 18;

		/// <summary>
		/// ConfiscateItem
		/// </summary>
		public const short ConfiscateItem = 19;

		/// <summary>
		/// DistributeItem
		/// </summary>
		public const short DistributeItem = 20;

		/// <summary>
		/// ClearRecord
		/// </summary>
		public const short ClearRecord = 21;

		/// <summary>
		/// DistributeResource
		/// </summary>
		public const short DistributeResource = 22;

		/// <summary>
		/// SectStoryFulongLooting
		/// </summary>
		public const short SectStoryFulongLooting = 23;

		/// <summary>
		/// DonateLegacy
		/// </summary>
		public const short DonateLegacy = 24;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// SupplementResource
		/// </summary>
		public static SettlementTreasuryRecordItem SupplementResource => Instance[(short)0];

		/// <summary>
		/// SupplementItem
		/// </summary>
		public static SettlementTreasuryRecordItem SupplementItem => Instance[(short)1];

		/// <summary>
		/// StorageResource
		/// </summary>
		public static SettlementTreasuryRecordItem StorageResource => Instance[(short)2];

		/// <summary>
		/// StorageItem
		/// </summary>
		public static SettlementTreasuryRecordItem StorageItem => Instance[(short)3];

		/// <summary>
		/// TakeOutResource
		/// </summary>
		public static SettlementTreasuryRecordItem TakeOutResource => Instance[(short)4];

		/// <summary>
		/// TakeOutItem
		/// </summary>
		public static SettlementTreasuryRecordItem TakeOutItem => Instance[(short)5];

		/// <summary>
		/// TaiwuStorageResource
		/// </summary>
		public static SettlementTreasuryRecordItem TaiwuStorageResource => Instance[(short)6];

		/// <summary>
		/// TaiwuStorageItem
		/// </summary>
		public static SettlementTreasuryRecordItem TaiwuStorageItem => Instance[(short)7];

		/// <summary>
		/// TaiwuTakeOutResource
		/// </summary>
		public static SettlementTreasuryRecordItem TaiwuTakeOutResource => Instance[(short)8];

		/// <summary>
		/// TaiwuTakeOutItem
		/// </summary>
		public static SettlementTreasuryRecordItem TaiwuTakeOutItem => Instance[(short)9];

		/// <summary>
		/// DonateSectTreasury
		/// </summary>
		public static SettlementTreasuryRecordItem DonateSectTreasury => Instance[(short)10];

		/// <summary>
		/// DonateTownTreasury
		/// </summary>
		public static SettlementTreasuryRecordItem DonateTownTreasury => Instance[(short)11];

		/// <summary>
		/// IntrudeSectTreasury
		/// </summary>
		public static SettlementTreasuryRecordItem IntrudeSectTreasury => Instance[(short)12];

		/// <summary>
		/// IntrudeTownTreasury
		/// </summary>
		public static SettlementTreasuryRecordItem IntrudeTownTreasury => Instance[(short)13];

		/// <summary>
		/// PlunderSectTreasurySuccess
		/// </summary>
		public static SettlementTreasuryRecordItem PlunderSectTreasurySuccess => Instance[(short)14];

		/// <summary>
		/// PlunderTownTreasurySuccess
		/// </summary>
		public static SettlementTreasuryRecordItem PlunderTownTreasurySuccess => Instance[(short)15];

		/// <summary>
		/// PlunderSectTreasuryFail
		/// </summary>
		public static SettlementTreasuryRecordItem PlunderSectTreasuryFail => Instance[(short)16];

		/// <summary>
		/// PlunderTownTreasuryFail
		/// </summary>
		public static SettlementTreasuryRecordItem PlunderTownTreasuryFail => Instance[(short)17];

		/// <summary>
		/// ConfiscateResource
		/// </summary>
		public static SettlementTreasuryRecordItem ConfiscateResource => Instance[(short)18];

		/// <summary>
		/// ConfiscateItem
		/// </summary>
		public static SettlementTreasuryRecordItem ConfiscateItem => Instance[(short)19];

		/// <summary>
		/// DistributeItem
		/// </summary>
		public static SettlementTreasuryRecordItem DistributeItem => Instance[(short)20];

		/// <summary>
		/// ClearRecord
		/// </summary>
		public static SettlementTreasuryRecordItem ClearRecord => Instance[(short)21];

		/// <summary>
		/// DistributeResource
		/// </summary>
		public static SettlementTreasuryRecordItem DistributeResource => Instance[(short)22];

		/// <summary>
		/// SectStoryFulongLooting
		/// </summary>
		public static SettlementTreasuryRecordItem SectStoryFulongLooting => Instance[(short)23];

		/// <summary>
		/// DonateLegacy
		/// </summary>
		public static SettlementTreasuryRecordItem DonateLegacy => Instance[(short)24];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SettlementTreasuryRecord Instance = new SettlementTreasuryRecord();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId" };

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
		_dataArray.Add(new SettlementTreasuryRecordItem(0, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_0"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_0"), new string[6] { "", "", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(1, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_1"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_1"), new string[6] { "", "", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(2, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_2"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_2"), new string[6] { "Character", "Resource", "Integer", "Integer", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(3, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_3"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_3"), new string[6] { "Character", "Item", "Integer", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(4, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_4"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_4"), new string[6] { "Character", "Resource", "Integer", "Integer", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(5, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_5"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_5"), new string[6] { "Character", "Item", "Integer", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(6, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_6"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_6"), new string[6] { "Character", "Resource", "Integer", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(7, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_7"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_7"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(8, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_8"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_8"), new string[6] { "Character", "Resource", "Integer", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(9, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_9"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_9"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(10, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_10"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_10"), new string[6] { "Character", "", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(11, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_11"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_11"), new string[6] { "Character", "", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(12, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_12"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_12"), new string[6] { "Character", "", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(13, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_13"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_13"), new string[6] { "Character", "", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(14, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_14"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_14"), new string[6] { "Character", "", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(15, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_15"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_15"), new string[6] { "Character", "", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(16, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_16"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_16"), new string[6] { "Character", "", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(17, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_17"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_17"), new string[6] { "Character", "", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(18, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_18"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_18"), new string[6] { "Character", "Resource", "Integer", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(19, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_19"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_19"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(20, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_20"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_20"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(21, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_21"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_21"), new string[6] { "", "", "", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(22, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_22"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_22"), new string[6] { "Character", "Resource", "Integer", "", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(23, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_23"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_23"), new string[6] { "Resource", "Integer", "Resource", "Integer", "", "" }));
		_dataArray.Add(new SettlementTreasuryRecordItem(24, LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Name_24"), LocalStringManager.GetConfig("SettlementTreasuryRecord_language", "Desc_24"), new string[6] { "Character", "Item", "", "", "", "" }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SettlementTreasuryRecordItem>(25);
		CreateItems0();
	}
}
