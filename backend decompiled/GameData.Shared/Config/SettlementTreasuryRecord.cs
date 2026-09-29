using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SettlementTreasuryRecord : ConfigData<SettlementTreasuryRecordItem, short>
{
	public static class DefKey
	{
		public const short SupplementResource = 0;

		public const short SupplementItem = 1;

		public const short StorageResource = 2;

		public const short StorageItem = 3;

		public const short TakeOutResource = 4;

		public const short TakeOutItem = 5;

		public const short TaiwuStorageResource = 6;

		public const short TaiwuStorageItem = 7;

		public const short TaiwuTakeOutResource = 8;

		public const short TaiwuTakeOutItem = 9;

		public const short DonateSectTreasury = 10;

		public const short DonateTownTreasury = 11;

		public const short IntrudeSectTreasury = 12;

		public const short IntrudeTownTreasury = 13;

		public const short PlunderSectTreasurySuccess = 14;

		public const short PlunderTownTreasurySuccess = 15;

		public const short PlunderSectTreasuryFail = 16;

		public const short PlunderTownTreasuryFail = 17;

		public const short ConfiscateResource = 18;

		public const short ConfiscateItem = 19;

		public const short DistributeItem = 20;

		public const short ClearRecord = 21;

		public const short DistributeResource = 22;

		public const short SectStoryFulongLooting = 23;

		public const short DonateLegacy = 24;
	}

	public static class DefValue
	{
		public static SettlementTreasuryRecordItem SupplementResource => Instance[(short)0];

		public static SettlementTreasuryRecordItem SupplementItem => Instance[(short)1];

		public static SettlementTreasuryRecordItem StorageResource => Instance[(short)2];

		public static SettlementTreasuryRecordItem StorageItem => Instance[(short)3];

		public static SettlementTreasuryRecordItem TakeOutResource => Instance[(short)4];

		public static SettlementTreasuryRecordItem TakeOutItem => Instance[(short)5];

		public static SettlementTreasuryRecordItem TaiwuStorageResource => Instance[(short)6];

		public static SettlementTreasuryRecordItem TaiwuStorageItem => Instance[(short)7];

		public static SettlementTreasuryRecordItem TaiwuTakeOutResource => Instance[(short)8];

		public static SettlementTreasuryRecordItem TaiwuTakeOutItem => Instance[(short)9];

		public static SettlementTreasuryRecordItem DonateSectTreasury => Instance[(short)10];

		public static SettlementTreasuryRecordItem DonateTownTreasury => Instance[(short)11];

		public static SettlementTreasuryRecordItem IntrudeSectTreasury => Instance[(short)12];

		public static SettlementTreasuryRecordItem IntrudeTownTreasury => Instance[(short)13];

		public static SettlementTreasuryRecordItem PlunderSectTreasurySuccess => Instance[(short)14];

		public static SettlementTreasuryRecordItem PlunderTownTreasurySuccess => Instance[(short)15];

		public static SettlementTreasuryRecordItem PlunderSectTreasuryFail => Instance[(short)16];

		public static SettlementTreasuryRecordItem PlunderTownTreasuryFail => Instance[(short)17];

		public static SettlementTreasuryRecordItem ConfiscateResource => Instance[(short)18];

		public static SettlementTreasuryRecordItem ConfiscateItem => Instance[(short)19];

		public static SettlementTreasuryRecordItem DistributeItem => Instance[(short)20];

		public static SettlementTreasuryRecordItem ClearRecord => Instance[(short)21];

		public static SettlementTreasuryRecordItem DistributeResource => Instance[(short)22];

		public static SettlementTreasuryRecordItem SectStoryFulongLooting => Instance[(short)23];

		public static SettlementTreasuryRecordItem DonateLegacy => Instance[(short)24];
	}

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
