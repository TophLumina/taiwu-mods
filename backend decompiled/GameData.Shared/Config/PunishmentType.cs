using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class PunishmentType : ConfigData<PunishmentTypeItem, short>
{
	public static class DefKey
	{
		public const short Default = 0;

		public const short PunishedBecauseOfSpouse = 21;

		public const short XiangshuCompletelyInfected = 40;

		public const short EscapeFromPrison = 41;

		public const short EnemySects = 42;

		public const short EnemyRelationship = 43;
	}

	public static class DefValue
	{
		public static PunishmentTypeItem Default => Instance[(short)0];

		public static PunishmentTypeItem PunishedBecauseOfSpouse => Instance[(short)21];

		public static PunishmentTypeItem XiangshuCompletelyInfected => Instance[(short)40];

		public static PunishmentTypeItem EscapeFromPrison => Instance[(short)41];

		public static PunishmentTypeItem EnemySects => Instance[(short)42];

		public static PunishmentTypeItem EnemyRelationship => Instance[(short)43];
	}

	public static PunishmentType Instance = new PunishmentType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "ShortName", "Severity", "PunishmentDesc", "SectPunishmentSeverities", "CivilianPunishmentSeverities", "TemplateId", "DisplayType", "Image" };

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
		_dataArray.Add(new PunishmentTypeItem(0, LocalStringManager.GetConfig("PunishmentType_language", "Name_0"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_0"), EPunishmentTypeDisplayType.Default, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_0"), "ui9_prison_Illustration_3_5", new List<ShortPair>(), new List<ShortPair>(), 0, 0u));
		_dataArray.Add(new PunishmentTypeItem(1, LocalStringManager.GetConfig("PunishmentType_language", "Name_1"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_1"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_1"), "ui9_prison_Illustration_0_2", new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(2, 1),
			new ShortPair(3, 1),
			new ShortPair(4, 2),
			new ShortPair(5, 1)
		}, new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 3),
			new ShortPair(5, 3),
			new ShortPair(6, 3),
			new ShortPair(7, 3),
			new ShortPair(8, 3),
			new ShortPair(9, 3),
			new ShortPair(10, 3),
			new ShortPair(11, 3),
			new ShortPair(12, 3),
			new ShortPair(13, 3),
			new ShortPair(14, 3),
			new ShortPair(15, 3)
		}, 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(2, LocalStringManager.GetConfig("PunishmentType_language", "Name_2"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_2"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_2"), "ui9_prison_Illustration_0_2", new List<ShortPair>
		{
			new ShortPair(7, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 3),
			new ShortPair(5, 3),
			new ShortPair(6, 3),
			new ShortPair(7, 3),
			new ShortPair(8, 3),
			new ShortPair(9, 3),
			new ShortPair(10, 3),
			new ShortPair(11, 3),
			new ShortPair(12, 3),
			new ShortPair(13, 3),
			new ShortPair(14, 3),
			new ShortPair(15, 3)
		}, 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(3, LocalStringManager.GetConfig("PunishmentType_language", "Name_3"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_3"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_3"), "ui9_prison_Illustration_0_2", new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(2, 1),
			new ShortPair(3, 1),
			new ShortPair(4, 2),
			new ShortPair(5, 1),
			new ShortPair(7, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 3),
			new ShortPair(5, 3),
			new ShortPair(6, 3),
			new ShortPair(7, 3),
			new ShortPair(8, 3),
			new ShortPair(9, 3),
			new ShortPair(10, 3),
			new ShortPair(11, 3),
			new ShortPair(12, 3),
			new ShortPair(13, 3),
			new ShortPair(14, 3),
			new ShortPair(15, 3)
		}, 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(4, LocalStringManager.GetConfig("PunishmentType_language", "Name_4"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_4"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_4"), "ui9_prison_Illustration_1_2", new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(4, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 2),
			new ShortPair(5, 2),
			new ShortPair(6, 2),
			new ShortPair(7, 2),
			new ShortPair(8, 2),
			new ShortPair(9, 2),
			new ShortPair(10, 2),
			new ShortPair(11, 2),
			new ShortPair(12, 2),
			new ShortPair(13, 2),
			new ShortPair(14, 2),
			new ShortPair(15, 2)
		}, 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(5, LocalStringManager.GetConfig("PunishmentType_language", "Name_5"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_5"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_5"), "ui9_prison_Illustration_1_2", new List<ShortPair>(), new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 2),
			new ShortPair(5, 2),
			new ShortPair(6, 2),
			new ShortPair(7, 2),
			new ShortPair(8, 2),
			new ShortPair(9, 2),
			new ShortPair(10, 2),
			new ShortPair(11, 2),
			new ShortPair(12, 2),
			new ShortPair(13, 2),
			new ShortPair(14, 2),
			new ShortPair(15, 2)
		}, 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(6, LocalStringManager.GetConfig("PunishmentType_language", "Name_6"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_6"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_6"), "ui9_prison_Illustration_1_2", new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(4, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 2),
			new ShortPair(5, 2),
			new ShortPair(6, 2),
			new ShortPair(7, 2),
			new ShortPair(8, 2),
			new ShortPair(9, 2),
			new ShortPair(10, 2),
			new ShortPair(11, 2),
			new ShortPair(12, 2),
			new ShortPair(13, 2),
			new ShortPair(14, 2),
			new ShortPair(15, 2)
		}, 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(7, LocalStringManager.GetConfig("PunishmentType_language", "Name_7"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_7"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_7"), "ui9_prison_Illustration_0_0", new List<ShortPair>(), new List<ShortPair>(), 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(8, LocalStringManager.GetConfig("PunishmentType_language", "Name_8"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_8"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_8"), "ui9_prison_Illustration_1_0", new List<ShortPair>(), new List<ShortPair>(), 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(9, LocalStringManager.GetConfig("PunishmentType_language", "Name_9"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_9"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_9"), "ui9_prison_Illustration_5_0", new List<ShortPair>(), new List<ShortPair>(), 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(10, LocalStringManager.GetConfig("PunishmentType_language", "Name_10"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_10"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_10"), "ui9_prison_Illustration_3_0", new List<ShortPair>
		{
			new ShortPair(1, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 0),
			new ShortPair(5, 0),
			new ShortPair(6, 0),
			new ShortPair(7, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0),
			new ShortPair(10, 0),
			new ShortPair(11, 0),
			new ShortPair(12, 0),
			new ShortPair(13, 0),
			new ShortPair(14, 0),
			new ShortPair(15, 0)
		}, 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(11, LocalStringManager.GetConfig("PunishmentType_language", "Name_11"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_11"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_11"), "ui9_prison_Illustration_3_0", new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(4, 0),
			new ShortPair(5, 0),
			new ShortPair(8, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 0),
			new ShortPair(5, 0),
			new ShortPair(6, 0),
			new ShortPair(7, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0),
			new ShortPair(10, 0),
			new ShortPair(11, 0),
			new ShortPair(12, 0),
			new ShortPair(13, 0),
			new ShortPair(14, 0),
			new ShortPair(15, 0)
		}, 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(12, LocalStringManager.GetConfig("PunishmentType_language", "Name_12"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_12"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_12"), "ui9_prison_Illustration_3_2", new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 0),
			new ShortPair(5, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 1),
			new ShortPair(3, 1),
			new ShortPair(4, 1),
			new ShortPair(5, 1),
			new ShortPair(6, 1),
			new ShortPair(7, 1),
			new ShortPair(8, 1),
			new ShortPair(9, 1),
			new ShortPair(10, 1),
			new ShortPair(11, 1),
			new ShortPair(12, 1),
			new ShortPair(13, 1),
			new ShortPair(14, 1),
			new ShortPair(15, 1)
		}, 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(13, LocalStringManager.GetConfig("PunishmentType_language", "Name_13"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_13"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_13"), "ui9_prison_Illustration_3_1", new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 1),
			new ShortPair(5, 1),
			new ShortPair(8, 1),
			new ShortPair(9, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 1),
			new ShortPair(3, 1),
			new ShortPair(4, 1),
			new ShortPair(5, 1),
			new ShortPair(6, 1),
			new ShortPair(7, 1),
			new ShortPair(8, 1),
			new ShortPair(9, 1),
			new ShortPair(10, 1),
			new ShortPair(11, 1),
			new ShortPair(12, 1),
			new ShortPair(13, 1),
			new ShortPair(14, 1),
			new ShortPair(15, 1)
		}, 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(14, LocalStringManager.GetConfig("PunishmentType_language", "Name_14"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_14"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_14"), "ui9_prison_Illustration_3_4", new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(4, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 2),
			new ShortPair(5, 2),
			new ShortPair(6, 2),
			new ShortPair(7, 2),
			new ShortPair(8, 2),
			new ShortPair(9, 2),
			new ShortPair(10, 2),
			new ShortPair(11, 2),
			new ShortPair(12, 2),
			new ShortPair(13, 2),
			new ShortPair(14, 2),
			new ShortPair(15, 2)
		}, 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(15, LocalStringManager.GetConfig("PunishmentType_language", "Name_15"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_15"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_15"), "ui9_prison_Illustration_3_4", new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(4, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 2),
			new ShortPair(5, 2),
			new ShortPair(6, 2),
			new ShortPair(7, 2),
			new ShortPair(8, 2),
			new ShortPair(9, 2),
			new ShortPair(10, 2),
			new ShortPair(11, 2),
			new ShortPair(12, 2),
			new ShortPair(13, 2),
			new ShortPair(14, 2),
			new ShortPair(15, 2)
		}, 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(16, LocalStringManager.GetConfig("PunishmentType_language", "Name_16"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_16"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_16"), "ui9_prison_Illustration_4_2", new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 1),
			new ShortPair(5, 0),
			new ShortPair(7, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(17, LocalStringManager.GetConfig("PunishmentType_language", "Name_17"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_17"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_17"), "ui9_prison_Illustration_4_2", new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 1),
			new ShortPair(5, 0),
			new ShortPair(7, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(18, LocalStringManager.GetConfig("PunishmentType_language", "Name_18"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_18"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_18"), "ui9_prison_Illustration_0_0", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(19, LocalStringManager.GetConfig("PunishmentType_language", "Name_19"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_19"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_19"), "ui9_prison_Illustration_4_0", new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(4, 0),
			new ShortPair(5, 0),
			new ShortPair(6, 0),
			new ShortPair(9, 0),
			new ShortPair(14, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(20, LocalStringManager.GetConfig("PunishmentType_language", "Name_20"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_20"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_20"), "ui9_prison_Illustration_4_0", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(21, LocalStringManager.GetConfig("PunishmentType_language", "Name_21"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_21"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_21"), "ui9_prison_Illustration_4_3", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(22, LocalStringManager.GetConfig("PunishmentType_language", "Name_22"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_22"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_22"), "ui9_prison_Illustration_0_1", new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 3),
			new ShortPair(5, 2),
			new ShortPair(6, 0),
			new ShortPair(7, 1),
			new ShortPair(8, 1),
			new ShortPair(9, 1),
			new ShortPair(10, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 4),
			new ShortPair(2, 4),
			new ShortPair(3, 4),
			new ShortPair(4, 4),
			new ShortPair(5, 4),
			new ShortPair(6, 4),
			new ShortPair(7, 4),
			new ShortPair(8, 4),
			new ShortPair(9, 4),
			new ShortPair(10, 4),
			new ShortPair(11, 4),
			new ShortPair(12, 4),
			new ShortPair(13, 4),
			new ShortPair(14, 4),
			new ShortPair(15, 4)
		}, 5000, 0u));
		_dataArray.Add(new PunishmentTypeItem(23, LocalStringManager.GetConfig("PunishmentType_language", "Name_23"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_23"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_23"), "ui9_prison_Illustration_1_1", new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(4, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 3),
			new ShortPair(5, 3),
			new ShortPair(6, 3),
			new ShortPair(7, 3),
			new ShortPair(8, 3),
			new ShortPair(9, 3),
			new ShortPair(10, 3),
			new ShortPair(11, 3),
			new ShortPair(12, 3),
			new ShortPair(13, 3),
			new ShortPair(14, 3),
			new ShortPair(15, 3)
		}, 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(24, LocalStringManager.GetConfig("PunishmentType_language", "Name_24"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_24"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_24"), "ui9_prison_Illustration_7_0", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(25, LocalStringManager.GetConfig("PunishmentType_language", "Name_25"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_25"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_25"), "ui9_prison_Illustration_7_0", new List<ShortPair>
		{
			new ShortPair(11, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(26, LocalStringManager.GetConfig("PunishmentType_language", "Name_26"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_26"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_26"), "ui9_prison_Illustration_7_0", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(27, LocalStringManager.GetConfig("PunishmentType_language", "Name_27"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_27"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_27"), "ui9_prison_Illustration_7_0", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(28, LocalStringManager.GetConfig("PunishmentType_language", "Name_28"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_28"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_28"), "ui9_prison_Illustration_7_0", new List<ShortPair>
		{
			new ShortPair(12, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(29, LocalStringManager.GetConfig("PunishmentType_language", "Name_29"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_29"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_29"), "ui9_prison_Illustration_7_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(30, LocalStringManager.GetConfig("PunishmentType_language", "Name_30"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_30"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_30"), "ui9_prison_Illustration_7_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(31, LocalStringManager.GetConfig("PunishmentType_language", "Name_31"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_31"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_31"), "ui9_prison_Illustration_7_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(32, LocalStringManager.GetConfig("PunishmentType_language", "Name_32"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_32"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_32"), "ui9_prison_Illustration_7_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(33, LocalStringManager.GetConfig("PunishmentType_language", "Name_33"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_33"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_33"), "ui9_prison_Illustration_7_1", new List<ShortPair>
		{
			new ShortPair(7, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(34, LocalStringManager.GetConfig("PunishmentType_language", "Name_34"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_34"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_34"), "ui9_prison_Illustration_7_2", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(35, LocalStringManager.GetConfig("PunishmentType_language", "Name_35"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_35"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_35"), "ui9_prison_Illustration_7_2", new List<ShortPair>
		{
			new ShortPair(5, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(36, LocalStringManager.GetConfig("PunishmentType_language", "Name_36"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_36"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_36"), "ui9_prison_Illustration_7_2", new List<ShortPair>
		{
			new ShortPair(4, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(37, LocalStringManager.GetConfig("PunishmentType_language", "Name_37"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_37"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_37"), "ui9_prison_Illustration_7_2", new List<ShortPair>
		{
			new ShortPair(1, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(38, LocalStringManager.GetConfig("PunishmentType_language", "Name_38"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_38"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_38"), "ui9_prison_Illustration_7_2", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(39, LocalStringManager.GetConfig("PunishmentType_language", "Name_39"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_39"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_39"), "ui9_prison_Illustration_3_5", new List<ShortPair>(), new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(40, LocalStringManager.GetConfig("PunishmentType_language", "Name_40"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_40"), EPunishmentTypeDisplayType.XiangshuInfected, 3, isPermanent: true, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_40"), "ui9_prison_Illustration_2_0", new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 3),
			new ShortPair(5, 3),
			new ShortPair(6, 3),
			new ShortPair(7, 3),
			new ShortPair(8, 3),
			new ShortPair(9, 3),
			new ShortPair(10, 3),
			new ShortPair(11, 3),
			new ShortPair(12, 3),
			new ShortPair(13, 3),
			new ShortPair(14, 3),
			new ShortPair(15, 3)
		}, new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 3),
			new ShortPair(5, 3),
			new ShortPair(6, 3),
			new ShortPair(7, 3),
			new ShortPair(8, 3),
			new ShortPair(9, 3),
			new ShortPair(10, 3),
			new ShortPair(11, 3),
			new ShortPair(12, 3),
			new ShortPair(13, 3),
			new ShortPair(14, 3),
			new ShortPair(15, 3)
		}, 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(41, LocalStringManager.GetConfig("PunishmentType_language", "Name_41"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_41"), EPunishmentTypeDisplayType.Criminal, 3, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_41"), "ui9_prison_Illustration_4_3", new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 3),
			new ShortPair(5, 3),
			new ShortPair(6, 3),
			new ShortPair(7, 3),
			new ShortPair(8, 3),
			new ShortPair(9, 3),
			new ShortPair(10, 3),
			new ShortPair(11, 3),
			new ShortPair(12, 3),
			new ShortPair(13, 3),
			new ShortPair(14, 3),
			new ShortPair(15, 3)
		}, new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 3),
			new ShortPair(5, 3),
			new ShortPair(6, 3),
			new ShortPair(7, 3),
			new ShortPair(8, 3),
			new ShortPair(9, 3),
			new ShortPair(10, 3),
			new ShortPair(11, 3),
			new ShortPair(12, 3),
			new ShortPair(13, 3),
			new ShortPair(14, 3),
			new ShortPair(15, 3)
		}, 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(42, LocalStringManager.GetConfig("PunishmentType_language", "Name_42"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_42"), EPunishmentTypeDisplayType.SettlementEnemy, 1, isPermanent: true, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_42"), "ui9_prison_Illustration_4_3", new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 1),
			new ShortPair(3, 1),
			new ShortPair(4, 1),
			new ShortPair(5, 1),
			new ShortPair(6, 1),
			new ShortPair(7, 1),
			new ShortPair(8, 1),
			new ShortPair(9, 1),
			new ShortPair(10, 1),
			new ShortPair(11, 1),
			new ShortPair(12, 1),
			new ShortPair(13, 1),
			new ShortPair(14, 1),
			new ShortPair(15, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(43, LocalStringManager.GetConfig("PunishmentType_language", "Name_43"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_43"), EPunishmentTypeDisplayType.PersonalEnemy, 1, isPermanent: true, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_43"), "ui9_prison_Illustration_4_3", new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 1),
			new ShortPair(3, 1),
			new ShortPair(4, 1),
			new ShortPair(5, 1),
			new ShortPair(6, 1),
			new ShortPair(7, 1),
			new ShortPair(8, 1),
			new ShortPair(9, 1),
			new ShortPair(10, 1),
			new ShortPair(11, 1),
			new ShortPair(12, 1),
			new ShortPair(13, 1),
			new ShortPair(14, 1),
			new ShortPair(15, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(44, LocalStringManager.GetConfig("PunishmentType_language", "Name_44"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_44"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_44"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(8, 4)
		}, new List<ShortPair>(), 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(45, LocalStringManager.GetConfig("PunishmentType_language", "Name_45"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_45"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_45"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(2, 2),
			new ShortPair(4, 2),
			new ShortPair(7, 1)
		}, new List<ShortPair>(), 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(46, LocalStringManager.GetConfig("PunishmentType_language", "Name_46"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_46"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_46"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(11, 1),
			new ShortPair(12, 3)
		}, new List<ShortPair>(), 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(47, LocalStringManager.GetConfig("PunishmentType_language", "Name_47"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_47"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_47"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(1, 3)
		}, new List<ShortPair>(), 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(48, LocalStringManager.GetConfig("PunishmentType_language", "Name_48"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_48"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_48"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(2, 2),
			new ShortPair(4, 2),
			new ShortPair(7, 1)
		}, new List<ShortPair>(), 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(49, LocalStringManager.GetConfig("PunishmentType_language", "Name_49"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_49"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_49"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(11, 2),
			new ShortPair(12, 2)
		}, new List<ShortPair>(), 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(50, LocalStringManager.GetConfig("PunishmentType_language", "Name_50"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_50"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_50"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(8, 3)
		}, new List<ShortPair>(), 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(51, LocalStringManager.GetConfig("PunishmentType_language", "Name_51"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_51"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_51"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(2, 2),
			new ShortPair(4, 3),
			new ShortPair(7, 2)
		}, new List<ShortPair>(), 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(52, LocalStringManager.GetConfig("PunishmentType_language", "Name_52"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_52"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_52"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(11, 3),
			new ShortPair(12, 3)
		}, new List<ShortPair>(), 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(53, LocalStringManager.GetConfig("PunishmentType_language", "Name_53"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_53"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_53"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(8, 2)
		}, new List<ShortPair>(), 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(54, LocalStringManager.GetConfig("PunishmentType_language", "Name_54"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_54"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_54"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(2, 1),
			new ShortPair(4, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(55, LocalStringManager.GetConfig("PunishmentType_language", "Name_55"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_55"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_55"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(11, 1),
			new ShortPair(12, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(56, LocalStringManager.GetConfig("PunishmentType_language", "Name_56"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_56"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_56"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(1, 4),
			new ShortPair(8, 4)
		}, new List<ShortPair>(), 5000, 0u));
		_dataArray.Add(new PunishmentTypeItem(57, LocalStringManager.GetConfig("PunishmentType_language", "Name_57"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_57"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_57"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(2, 3),
			new ShortPair(4, 3),
			new ShortPair(7, 1)
		}, new List<ShortPair>(), 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(58, LocalStringManager.GetConfig("PunishmentType_language", "Name_58"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_58"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_58"), "ui9_prison_Illustration_5_1", new List<ShortPair>
		{
			new ShortPair(11, 2),
			new ShortPair(12, 2)
		}, new List<ShortPair>(), 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(59, LocalStringManager.GetConfig("PunishmentType_language", "Name_59"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_59"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_59"), "ui9_prison_Illustration_5_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new PunishmentTypeItem(60, LocalStringManager.GetConfig("PunishmentType_language", "Name_60"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_60"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_60"), "ui9_prison_Illustration_5_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(61, LocalStringManager.GetConfig("PunishmentType_language", "Name_61"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_61"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_61"), "ui9_prison_Illustration_5_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(62, LocalStringManager.GetConfig("PunishmentType_language", "Name_62"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_62"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_62"), "ui9_prison_Illustration_5_2", new List<ShortPair>
		{
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 0),
			new ShortPair(5, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(63, LocalStringManager.GetConfig("PunishmentType_language", "Name_63"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_63"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_63"), "ui9_prison_Illustration_5_3", new List<ShortPair>
		{
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 2),
			new ShortPair(5, 2),
			new ShortPair(7, 1),
			new ShortPair(9, 1),
			new ShortPair(10, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 2),
			new ShortPair(5, 2),
			new ShortPair(6, 2),
			new ShortPair(7, 2),
			new ShortPair(8, 2),
			new ShortPair(9, 2),
			new ShortPair(10, 2),
			new ShortPair(11, 2),
			new ShortPair(12, 2),
			new ShortPair(13, 2),
			new ShortPair(14, 2),
			new ShortPair(15, 2)
		}, 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(64, LocalStringManager.GetConfig("PunishmentType_language", "Name_64"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_64"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_64"), "ui9_prison_Illustration_8_0", new List<ShortPair>
		{
			new ShortPair(14, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(65, LocalStringManager.GetConfig("PunishmentType_language", "Name_65"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_65"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_65"), "ui9_prison_Illustration_8_0", new List<ShortPair>
		{
			new ShortPair(11, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(66, LocalStringManager.GetConfig("PunishmentType_language", "Name_66"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_66"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_66"), "ui9_prison_Illustration_8_0", new List<ShortPair>
		{
			new ShortPair(15, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(67, LocalStringManager.GetConfig("PunishmentType_language", "Name_67"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_67"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_67"), "ui9_prison_Illustration_8_0", new List<ShortPair>
		{
			new ShortPair(13, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(68, LocalStringManager.GetConfig("PunishmentType_language", "Name_68"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_68"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_68"), "ui9_prison_Illustration_8_0", new List<ShortPair>
		{
			new ShortPair(12, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(69, LocalStringManager.GetConfig("PunishmentType_language", "Name_69"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_69"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_69"), "ui9_prison_Illustration_8_1", new List<ShortPair>
		{
			new ShortPair(9, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(70, LocalStringManager.GetConfig("PunishmentType_language", "Name_70"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_70"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_70"), "ui9_prison_Illustration_8_1", new List<ShortPair>
		{
			new ShortPair(6, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(71, LocalStringManager.GetConfig("PunishmentType_language", "Name_71"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_71"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_71"), "ui9_prison_Illustration_8_1", new List<ShortPair>
		{
			new ShortPair(10, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(72, LocalStringManager.GetConfig("PunishmentType_language", "Name_72"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_72"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_72"), "ui9_prison_Illustration_8_1", new List<ShortPair>
		{
			new ShortPair(8, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(73, LocalStringManager.GetConfig("PunishmentType_language", "Name_73"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_73"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_73"), "ui9_prison_Illustration_8_1", new List<ShortPair>
		{
			new ShortPair(7, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(74, LocalStringManager.GetConfig("PunishmentType_language", "Name_74"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_74"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_74"), "ui9_prison_Illustration_8_2", new List<ShortPair>
		{
			new ShortPair(2, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(75, LocalStringManager.GetConfig("PunishmentType_language", "Name_75"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_75"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_75"), "ui9_prison_Illustration_8_2", new List<ShortPair>
		{
			new ShortPair(5, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(76, LocalStringManager.GetConfig("PunishmentType_language", "Name_76"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_76"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_76"), "ui9_prison_Illustration_8_2", new List<ShortPair>
		{
			new ShortPair(4, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(77, LocalStringManager.GetConfig("PunishmentType_language", "Name_77"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_77"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_77"), "ui9_prison_Illustration_8_2", new List<ShortPair>(), new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(78, LocalStringManager.GetConfig("PunishmentType_language", "Name_78"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_78"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_78"), "ui9_prison_Illustration_8_2", new List<ShortPair>
		{
			new ShortPair(3, 0)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(79, LocalStringManager.GetConfig("PunishmentType_language", "Name_79"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_79"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_79"), "ui9_prison_Illustration_6_0", new List<ShortPair>
		{
			new ShortPair(14, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(80, LocalStringManager.GetConfig("PunishmentType_language", "Name_80"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_80"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_80"), "ui9_prison_Illustration_6_0", new List<ShortPair>
		{
			new ShortPair(11, 1)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(81, LocalStringManager.GetConfig("PunishmentType_language", "Name_81"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_81"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_81"), "ui9_prison_Illustration_6_0", new List<ShortPair>
		{
			new ShortPair(15, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(82, LocalStringManager.GetConfig("PunishmentType_language", "Name_82"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_82"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_82"), "ui9_prison_Illustration_6_0", new List<ShortPair>
		{
			new ShortPair(13, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(83, LocalStringManager.GetConfig("PunishmentType_language", "Name_83"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_83"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_83"), "ui9_prison_Illustration_6_0", new List<ShortPair>
		{
			new ShortPair(12, 1)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(84, LocalStringManager.GetConfig("PunishmentType_language", "Name_84"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_84"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_84"), "ui9_prison_Illustration_6_1", new List<ShortPair>
		{
			new ShortPair(9, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(85, LocalStringManager.GetConfig("PunishmentType_language", "Name_85"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_85"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_85"), "ui9_prison_Illustration_6_1", new List<ShortPair>
		{
			new ShortPair(6, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(86, LocalStringManager.GetConfig("PunishmentType_language", "Name_86"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_86"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_86"), "ui9_prison_Illustration_6_1", new List<ShortPair>
		{
			new ShortPair(10, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(87, LocalStringManager.GetConfig("PunishmentType_language", "Name_87"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_87"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_87"), "ui9_prison_Illustration_6_1", new List<ShortPair>
		{
			new ShortPair(8, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(88, LocalStringManager.GetConfig("PunishmentType_language", "Name_88"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_88"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_88"), "ui9_prison_Illustration_6_1", new List<ShortPair>
		{
			new ShortPair(7, 1)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(89, LocalStringManager.GetConfig("PunishmentType_language", "Name_89"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_89"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_89"), "ui9_prison_Illustration_6_2", new List<ShortPair>
		{
			new ShortPair(2, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(90, LocalStringManager.GetConfig("PunishmentType_language", "Name_90"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_90"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_90"), "ui9_prison_Illustration_6_2", new List<ShortPair>
		{
			new ShortPair(5, 1)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(91, LocalStringManager.GetConfig("PunishmentType_language", "Name_91"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_91"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_91"), "ui9_prison_Illustration_6_2", new List<ShortPair>
		{
			new ShortPair(4, 1)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(92, LocalStringManager.GetConfig("PunishmentType_language", "Name_92"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_92"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_92"), "ui9_prison_Illustration_6_2", new List<ShortPair>
		{
			new ShortPair(1, 1)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(93, LocalStringManager.GetConfig("PunishmentType_language", "Name_93"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_93"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_93"), "ui9_prison_Illustration_6_2", new List<ShortPair>
		{
			new ShortPair(3, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(94, LocalStringManager.GetConfig("PunishmentType_language", "Name_94"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_94"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_94"), "ui9_prison_Illustration_10_0", new List<ShortPair>
		{
			new ShortPair(14, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(95, LocalStringManager.GetConfig("PunishmentType_language", "Name_95"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_95"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_95"), "ui9_prison_Illustration_10_0", new List<ShortPair>
		{
			new ShortPair(11, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(96, LocalStringManager.GetConfig("PunishmentType_language", "Name_96"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_96"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_96"), "ui9_prison_Illustration_10_0", new List<ShortPair>
		{
			new ShortPair(15, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(97, LocalStringManager.GetConfig("PunishmentType_language", "Name_97"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_97"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_97"), "ui9_prison_Illustration_10_0", new List<ShortPair>
		{
			new ShortPair(13, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(98, LocalStringManager.GetConfig("PunishmentType_language", "Name_98"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_98"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_98"), "ui9_prison_Illustration_10_0", new List<ShortPair>
		{
			new ShortPair(12, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(99, LocalStringManager.GetConfig("PunishmentType_language", "Name_99"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_99"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_99"), "ui9_prison_Illustration_10_1", new List<ShortPair>
		{
			new ShortPair(9, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(100, LocalStringManager.GetConfig("PunishmentType_language", "Name_100"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_100"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_100"), "ui9_prison_Illustration_10_1", new List<ShortPair>
		{
			new ShortPair(6, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(101, LocalStringManager.GetConfig("PunishmentType_language", "Name_101"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_101"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_101"), "ui9_prison_Illustration_10_1", new List<ShortPair>
		{
			new ShortPair(10, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(102, LocalStringManager.GetConfig("PunishmentType_language", "Name_102"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_102"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_102"), "ui9_prison_Illustration_10_1", new List<ShortPair>
		{
			new ShortPair(8, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(103, LocalStringManager.GetConfig("PunishmentType_language", "Name_103"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_103"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_103"), "ui9_prison_Illustration_10_1", new List<ShortPair>
		{
			new ShortPair(7, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(104, LocalStringManager.GetConfig("PunishmentType_language", "Name_104"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_104"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_104"), "ui9_prison_Illustration_10_2", new List<ShortPair>
		{
			new ShortPair(2, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(105, LocalStringManager.GetConfig("PunishmentType_language", "Name_105"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_105"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_105"), "ui9_prison_Illustration_10_2", new List<ShortPair>
		{
			new ShortPair(5, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(106, LocalStringManager.GetConfig("PunishmentType_language", "Name_106"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_106"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_106"), "ui9_prison_Illustration_10_2", new List<ShortPair>
		{
			new ShortPair(4, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(107, LocalStringManager.GetConfig("PunishmentType_language", "Name_107"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_107"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_107"), "ui9_prison_Illustration_10_2", new List<ShortPair>
		{
			new ShortPair(1, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(108, LocalStringManager.GetConfig("PunishmentType_language", "Name_108"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_108"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_108"), "ui9_prison_Illustration_10_2", new List<ShortPair>
		{
			new ShortPair(3, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(109, LocalStringManager.GetConfig("PunishmentType_language", "Name_109"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_109"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_109"), "ui9_prison_Illustration_11_0", new List<ShortPair>
		{
			new ShortPair(14, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(110, LocalStringManager.GetConfig("PunishmentType_language", "Name_110"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_110"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_110"), "ui9_prison_Illustration_11_0", new List<ShortPair>
		{
			new ShortPair(11, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(111, LocalStringManager.GetConfig("PunishmentType_language", "Name_111"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_111"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_111"), "ui9_prison_Illustration_11_0", new List<ShortPair>
		{
			new ShortPair(15, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(112, LocalStringManager.GetConfig("PunishmentType_language", "Name_112"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_112"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_112"), "ui9_prison_Illustration_11_0", new List<ShortPair>
		{
			new ShortPair(13, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(113, LocalStringManager.GetConfig("PunishmentType_language", "Name_113"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_113"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_113"), "ui9_prison_Illustration_11_0", new List<ShortPair>
		{
			new ShortPair(12, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(114, LocalStringManager.GetConfig("PunishmentType_language", "Name_114"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_114"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_114"), "ui9_prison_Illustration_11_1", new List<ShortPair>
		{
			new ShortPair(9, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(115, LocalStringManager.GetConfig("PunishmentType_language", "Name_115"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_115"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_115"), "ui9_prison_Illustration_11_1", new List<ShortPair>
		{
			new ShortPair(6, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(116, LocalStringManager.GetConfig("PunishmentType_language", "Name_116"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_116"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_116"), "ui9_prison_Illustration_11_1", new List<ShortPair>
		{
			new ShortPair(10, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(117, LocalStringManager.GetConfig("PunishmentType_language", "Name_117"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_117"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_117"), "ui9_prison_Illustration_11_1", new List<ShortPair>
		{
			new ShortPair(8, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(118, LocalStringManager.GetConfig("PunishmentType_language", "Name_118"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_118"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_118"), "ui9_prison_Illustration_11_1", new List<ShortPair>
		{
			new ShortPair(7, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(119, LocalStringManager.GetConfig("PunishmentType_language", "Name_119"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_119"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_119"), "ui9_prison_Illustration_11_2", new List<ShortPair>
		{
			new ShortPair(2, 1)
		}, new List<ShortPair>(), 2000, 0u));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new PunishmentTypeItem(120, LocalStringManager.GetConfig("PunishmentType_language", "Name_120"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_120"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_120"), "ui9_prison_Illustration_11_2", new List<ShortPair>
		{
			new ShortPair(5, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(121, LocalStringManager.GetConfig("PunishmentType_language", "Name_121"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_121"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_121"), "ui9_prison_Illustration_11_2", new List<ShortPair>
		{
			new ShortPair(4, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(122, LocalStringManager.GetConfig("PunishmentType_language", "Name_122"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_122"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_122"), "ui9_prison_Illustration_11_2", new List<ShortPair>
		{
			new ShortPair(1, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(123, LocalStringManager.GetConfig("PunishmentType_language", "Name_123"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_123"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_123"), "ui9_prison_Illustration_11_2", new List<ShortPair>
		{
			new ShortPair(3, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(124, LocalStringManager.GetConfig("PunishmentType_language", "Name_124"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_124"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_124"), "ui9_prison_Illustration_9_0", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(125, LocalStringManager.GetConfig("PunishmentType_language", "Name_125"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_125"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_125"), "ui9_prison_Illustration_9_0", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(126, LocalStringManager.GetConfig("PunishmentType_language", "Name_126"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_126"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_126"), "ui9_prison_Illustration_9_0", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(127, LocalStringManager.GetConfig("PunishmentType_language", "Name_127"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_127"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_127"), "ui9_prison_Illustration_9_0", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(128, LocalStringManager.GetConfig("PunishmentType_language", "Name_128"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_128"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_128"), "ui9_prison_Illustration_9_0", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(129, LocalStringManager.GetConfig("PunishmentType_language", "Name_129"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_129"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_129"), "ui9_prison_Illustration_9_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(130, LocalStringManager.GetConfig("PunishmentType_language", "Name_130"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_130"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_130"), "ui9_prison_Illustration_9_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(131, LocalStringManager.GetConfig("PunishmentType_language", "Name_131"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_131"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_131"), "ui9_prison_Illustration_9_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(132, LocalStringManager.GetConfig("PunishmentType_language", "Name_132"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_132"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_132"), "ui9_prison_Illustration_9_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(133, LocalStringManager.GetConfig("PunishmentType_language", "Name_133"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_133"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_133"), "ui9_prison_Illustration_9_1", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(134, LocalStringManager.GetConfig("PunishmentType_language", "Name_134"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_134"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_134"), "ui9_prison_Illustration_9_2", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(135, LocalStringManager.GetConfig("PunishmentType_language", "Name_135"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_135"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_135"), "ui9_prison_Illustration_9_2", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(136, LocalStringManager.GetConfig("PunishmentType_language", "Name_136"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_136"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_136"), "ui9_prison_Illustration_9_2", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(137, LocalStringManager.GetConfig("PunishmentType_language", "Name_137"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_137"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_137"), "ui9_prison_Illustration_9_2", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(138, LocalStringManager.GetConfig("PunishmentType_language", "Name_138"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_138"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_138"), "ui9_prison_Illustration_9_2", new List<ShortPair>(), new List<ShortPair>(), 2000, 2305890u));
		_dataArray.Add(new PunishmentTypeItem(139, LocalStringManager.GetConfig("PunishmentType_language", "Name_139"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_139"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_139"), "ui9_prison_Illustration_12_0", new List<ShortPair>
		{
			new ShortPair(14, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(140, LocalStringManager.GetConfig("PunishmentType_language", "Name_140"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_140"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_140"), "ui9_prison_Illustration_12_0", new List<ShortPair>
		{
			new ShortPair(11, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(141, LocalStringManager.GetConfig("PunishmentType_language", "Name_141"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_141"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_141"), "ui9_prison_Illustration_12_0", new List<ShortPair>
		{
			new ShortPair(15, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(142, LocalStringManager.GetConfig("PunishmentType_language", "Name_142"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_142"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_142"), "ui9_prison_Illustration_12_0", new List<ShortPair>
		{
			new ShortPair(13, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(143, LocalStringManager.GetConfig("PunishmentType_language", "Name_143"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_143"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_143"), "ui9_prison_Illustration_12_0", new List<ShortPair>
		{
			new ShortPair(12, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(144, LocalStringManager.GetConfig("PunishmentType_language", "Name_144"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_144"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_144"), "ui9_prison_Illustration_12_1", new List<ShortPair>
		{
			new ShortPair(9, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(145, LocalStringManager.GetConfig("PunishmentType_language", "Name_145"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_145"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_145"), "ui9_prison_Illustration_12_1", new List<ShortPair>
		{
			new ShortPair(6, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(146, LocalStringManager.GetConfig("PunishmentType_language", "Name_146"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_146"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_146"), "ui9_prison_Illustration_12_1", new List<ShortPair>
		{
			new ShortPair(10, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(147, LocalStringManager.GetConfig("PunishmentType_language", "Name_147"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_147"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_147"), "ui9_prison_Illustration_12_1", new List<ShortPair>
		{
			new ShortPair(8, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(148, LocalStringManager.GetConfig("PunishmentType_language", "Name_148"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_148"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_148"), "ui9_prison_Illustration_12_1", new List<ShortPair>
		{
			new ShortPair(7, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(149, LocalStringManager.GetConfig("PunishmentType_language", "Name_149"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_149"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_149"), "ui9_prison_Illustration_12_2", new List<ShortPair>
		{
			new ShortPair(2, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(150, LocalStringManager.GetConfig("PunishmentType_language", "Name_150"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_150"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_150"), "ui9_prison_Illustration_12_2", new List<ShortPair>
		{
			new ShortPair(5, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(151, LocalStringManager.GetConfig("PunishmentType_language", "Name_151"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_151"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_151"), "ui9_prison_Illustration_12_2", new List<ShortPair>
		{
			new ShortPair(4, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(152, LocalStringManager.GetConfig("PunishmentType_language", "Name_152"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_152"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_152"), "ui9_prison_Illustration_12_2", new List<ShortPair>
		{
			new ShortPair(1, 2)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(153, LocalStringManager.GetConfig("PunishmentType_language", "Name_153"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_153"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_153"), "ui9_prison_Illustration_12_2", new List<ShortPair>
		{
			new ShortPair(3, 1)
		}, new List<ShortPair>(), 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(154, LocalStringManager.GetConfig("PunishmentType_language", "Name_154"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_154"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_154"), "ui9_prison_Illustration_0_0", new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 3),
			new ShortPair(5, 2),
			new ShortPair(6, 0),
			new ShortPair(7, 1),
			new ShortPair(8, 1),
			new ShortPair(9, 1),
			new ShortPair(10, 0)
		}, new List<ShortPair>(), 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(155, LocalStringManager.GetConfig("PunishmentType_language", "Name_155"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_155"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_155"), "ui9_prison_Illustration_1_0", new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 1),
			new ShortPair(5, 0),
			new ShortPair(7, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0)
		}, new List<ShortPair>(), 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(156, LocalStringManager.GetConfig("PunishmentType_language", "Name_156"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_156"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_156"), "ui9_prison_Illustration_0_0", new List<ShortPair>
		{
			new ShortPair(1, 4),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 4),
			new ShortPair(5, 3),
			new ShortPair(6, 1),
			new ShortPair(7, 2),
			new ShortPair(8, 2),
			new ShortPair(9, 2),
			new ShortPair(10, 1)
		}, new List<ShortPair>(), 5000, 0u));
		_dataArray.Add(new PunishmentTypeItem(157, LocalStringManager.GetConfig("PunishmentType_language", "Name_157"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_157"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_157"), "ui9_prison_Illustration_1_0", new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 1),
			new ShortPair(5, 0),
			new ShortPair(7, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0)
		}, new List<ShortPair>(), 5000, 0u));
		_dataArray.Add(new PunishmentTypeItem(158, LocalStringManager.GetConfig("PunishmentType_language", "Name_158"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_158"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_158"), "ui9_prison_Illustration_3_5", new List<ShortPair>
		{
			new ShortPair(1, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 0),
			new ShortPair(5, 0),
			new ShortPair(6, 0),
			new ShortPair(7, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0),
			new ShortPair(10, 0),
			new ShortPair(11, 0),
			new ShortPair(12, 0),
			new ShortPair(13, 0),
			new ShortPair(14, 0),
			new ShortPair(15, 0)
		}, 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(159, LocalStringManager.GetConfig("PunishmentType_language", "Name_159"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_159"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_159"), "ui9_prison_Illustration_3_5", new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(4, 0),
			new ShortPair(5, 0),
			new ShortPair(8, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 1),
			new ShortPair(3, 1),
			new ShortPair(4, 1),
			new ShortPair(5, 1),
			new ShortPair(6, 1),
			new ShortPair(7, 1),
			new ShortPair(8, 1),
			new ShortPair(9, 1),
			new ShortPair(10, 1),
			new ShortPair(11, 1),
			new ShortPair(12, 1),
			new ShortPair(13, 1),
			new ShortPair(14, 1),
			new ShortPair(15, 1)
		}, 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(160, LocalStringManager.GetConfig("PunishmentType_language", "Name_160"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_160"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_160"), "ui9_prison_Illustration_3_5", new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 0),
			new ShortPair(5, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 0),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 0),
			new ShortPair(5, 0),
			new ShortPair(6, 0),
			new ShortPair(7, 0),
			new ShortPair(8, 0),
			new ShortPair(9, 0),
			new ShortPair(10, 0),
			new ShortPair(11, 0),
			new ShortPair(12, 0),
			new ShortPair(13, 0),
			new ShortPair(14, 0),
			new ShortPair(15, 0)
		}, 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(161, LocalStringManager.GetConfig("PunishmentType_language", "Name_161"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_161"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_161"), "ui9_prison_Illustration_3_5", new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 0),
			new ShortPair(3, 0),
			new ShortPair(4, 1),
			new ShortPair(5, 1),
			new ShortPair(8, 1),
			new ShortPair(9, 0)
		}, new List<ShortPair>
		{
			new ShortPair(1, 1),
			new ShortPair(2, 1),
			new ShortPair(3, 1),
			new ShortPair(4, 1),
			new ShortPair(5, 1),
			new ShortPair(6, 1),
			new ShortPair(7, 1),
			new ShortPair(8, 1),
			new ShortPair(9, 1),
			new ShortPair(10, 1),
			new ShortPair(11, 1),
			new ShortPair(12, 1),
			new ShortPair(13, 1),
			new ShortPair(14, 1),
			new ShortPair(15, 1)
		}, 2000, 0u));
		_dataArray.Add(new PunishmentTypeItem(162, LocalStringManager.GetConfig("PunishmentType_language", "Name_162"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_162"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_162"), "ui9_prison_Illustration_4_0", new List<ShortPair>
		{
			new ShortPair(5, 0),
			new ShortPair(7, 0),
			new ShortPair(13, 0),
			new ShortPair(1, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(163, LocalStringManager.GetConfig("PunishmentType_language", "Name_163"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_163"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_163"), "ui9_prison_Illustration_4_0", new List<ShortPair>
		{
			new ShortPair(10, 0),
			new ShortPair(1, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(164, LocalStringManager.GetConfig("PunishmentType_language", "Name_164"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_164"), EPunishmentTypeDisplayType.Criminal, -1, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_164"), "ui9_prison_Illustration_4_0", new List<ShortPair>
		{
			new ShortPair(2, 0),
			new ShortPair(4, 0)
		}, new List<ShortPair>(), 1000, 0u));
		_dataArray.Add(new PunishmentTypeItem(165, LocalStringManager.GetConfig("PunishmentType_language", "Name_165"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_165"), EPunishmentTypeDisplayType.Criminal, 2, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_165"), "ui9_prison_Illustration_4_3", new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 2),
			new ShortPair(5, 2),
			new ShortPair(6, 2),
			new ShortPair(7, 2),
			new ShortPair(8, 2),
			new ShortPair(9, 2),
			new ShortPair(10, 2),
			new ShortPair(11, 2),
			new ShortPair(12, 2),
			new ShortPair(13, 2),
			new ShortPair(14, 2),
			new ShortPair(15, 2)
		}, new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 2),
			new ShortPair(5, 2),
			new ShortPair(6, 2),
			new ShortPair(7, 2),
			new ShortPair(8, 2),
			new ShortPair(9, 2),
			new ShortPair(10, 2),
			new ShortPair(11, 2),
			new ShortPair(12, 2),
			new ShortPair(13, 2),
			new ShortPair(14, 2),
			new ShortPair(15, 2)
		}, 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(166, LocalStringManager.GetConfig("PunishmentType_language", "Name_166"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_166"), EPunishmentTypeDisplayType.Criminal, 3, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_166"), "ui9_prison_Illustration_4_3", new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 3),
			new ShortPair(5, 3),
			new ShortPair(6, 3),
			new ShortPair(7, 3),
			new ShortPair(8, 3),
			new ShortPair(9, 3),
			new ShortPair(10, 3),
			new ShortPair(11, 3),
			new ShortPair(12, 3),
			new ShortPair(13, 3),
			new ShortPair(14, 3),
			new ShortPair(15, 3)
		}, new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 3),
			new ShortPair(5, 3),
			new ShortPair(6, 3),
			new ShortPair(7, 3),
			new ShortPair(8, 3),
			new ShortPair(9, 3),
			new ShortPair(10, 3),
			new ShortPair(11, 3),
			new ShortPair(12, 3),
			new ShortPair(13, 3),
			new ShortPair(14, 3),
			new ShortPair(15, 3)
		}, 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(167, LocalStringManager.GetConfig("PunishmentType_language", "Name_167"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_167"), EPunishmentTypeDisplayType.Criminal, 4, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_167"), "ui9_prison_Illustration_4_3", new List<ShortPair>
		{
			new ShortPair(1, 4),
			new ShortPair(2, 4),
			new ShortPair(3, 4),
			new ShortPair(4, 4),
			new ShortPair(5, 4),
			new ShortPair(6, 4),
			new ShortPair(7, 4),
			new ShortPair(8, 4),
			new ShortPair(9, 4),
			new ShortPair(10, 4),
			new ShortPair(11, 4),
			new ShortPair(12, 4),
			new ShortPair(13, 4),
			new ShortPair(14, 4),
			new ShortPair(15, 4)
		}, new List<ShortPair>
		{
			new ShortPair(1, 4),
			new ShortPair(2, 4),
			new ShortPair(3, 4),
			new ShortPair(4, 4),
			new ShortPair(5, 4),
			new ShortPair(6, 4),
			new ShortPair(7, 4),
			new ShortPair(8, 4),
			new ShortPair(9, 4),
			new ShortPair(10, 4),
			new ShortPair(11, 4),
			new ShortPair(12, 4),
			new ShortPair(13, 4),
			new ShortPair(14, 4),
			new ShortPair(15, 4)
		}, 5000, 0u));
		_dataArray.Add(new PunishmentTypeItem(168, LocalStringManager.GetConfig("PunishmentType_language", "Name_168"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_168"), EPunishmentTypeDisplayType.Criminal, 2, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_168"), "ui9_prison_Illustration_4_3", new List<ShortPair>
		{
			new ShortPair(1, 2),
			new ShortPair(2, 2),
			new ShortPair(3, 2),
			new ShortPair(4, 2),
			new ShortPair(5, 2),
			new ShortPair(6, 2),
			new ShortPair(7, 2),
			new ShortPair(8, 2),
			new ShortPair(9, 2),
			new ShortPair(10, 2),
			new ShortPair(11, 2),
			new ShortPair(12, 2),
			new ShortPair(13, 2),
			new ShortPair(14, 2),
			new ShortPair(15, 2)
		}, new List<ShortPair>(), 3000, 0u));
		_dataArray.Add(new PunishmentTypeItem(169, LocalStringManager.GetConfig("PunishmentType_language", "Name_169"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_169"), EPunishmentTypeDisplayType.Criminal, 3, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_169"), "ui9_prison_Illustration_4_3", new List<ShortPair>
		{
			new ShortPair(1, 3),
			new ShortPair(2, 3),
			new ShortPair(3, 3),
			new ShortPair(4, 3),
			new ShortPair(5, 3),
			new ShortPair(6, 3),
			new ShortPair(7, 3),
			new ShortPair(8, 3),
			new ShortPair(9, 3),
			new ShortPair(10, 3),
			new ShortPair(11, 3),
			new ShortPair(12, 3),
			new ShortPair(13, 3),
			new ShortPair(14, 3),
			new ShortPair(15, 3)
		}, new List<ShortPair>(), 4000, 0u));
		_dataArray.Add(new PunishmentTypeItem(170, LocalStringManager.GetConfig("PunishmentType_language", "Name_170"), LocalStringManager.GetConfig("PunishmentType_language", "ShortName_170"), EPunishmentTypeDisplayType.Criminal, 4, isPermanent: false, LocalStringManager.GetConfig("PunishmentType_language", "PunishmentDesc_170"), "ui9_prison_Illustration_4_3", new List<ShortPair>
		{
			new ShortPair(1, 4),
			new ShortPair(2, 4),
			new ShortPair(3, 4),
			new ShortPair(4, 4),
			new ShortPair(5, 4),
			new ShortPair(6, 4),
			new ShortPair(7, 4),
			new ShortPair(8, 4),
			new ShortPair(9, 4),
			new ShortPair(10, 4),
			new ShortPair(11, 4),
			new ShortPair(12, 4),
			new ShortPair(13, 4),
			new ShortPair(14, 4),
			new ShortPair(15, 4)
		}, new List<ShortPair>(), 5000, 0u));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PunishmentTypeItem>(171);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
